using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using IMJWeb.DAO;
using Microsoft.Practices.Unity;
using System.Drawing;
using IMJWeb.Dominio.Util;
using System.Threading;
using System.Diagnostics;
using IMJWeb.Servico.Catalogo.TO;
using System.Transactions;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using IMJWeb.Servico.Comunicacao;
using System.IO;
using System.Drawing.Imaging;

namespace IMJWeb.Servico.Catalogo
{
    public class Mercadorias : IDisposable
    {
        private static object sincronizador = new object();

        [Dependency]
        public IMercadoriaDAO MercadoriaDAO { get; set; }

        [Dependency]
        public ICatalogoDAO CatalogoDAO { get; set; }

        public static string CaminhoCacheEmDisco { get; set; }

        private ICacheManager cache = CacheFactory.GetCacheManager();

        /// <summary>
        /// Obtém a foto mais adequada para uma mercadoria específica.
        /// </summary>
        /// <param name="idMercadoria">Identificador da mercadoria.</param>
        /// <param name="largura">Largura desejada para exibição.</param>
        /// <param name="altura">Altura desejada para exibição.</param>
        /// <returns>Foto mais adequada para exibição.</returns>
        /// <remarks>A proporção da foto sempre é mantida, mantendo fixo a maior dimensão.</remarks>
        public IFoto ObterFoto(IMercadoria mercadoria, int largura, int altura)
        {
            string chave = string.Format("{0}:{1}x{2}",
                   mercadoria.Referencia.ValorNumerico,
                   largura, altura);
            IFoto foto;

            foto = cache.GetData(chave) as IFoto;

            // Se não estiver em cache...
            if (foto == null)
            {
#if SALVAR_EM_DISCO
                foto = ObterFotoEmDisco(mercadoria);

                if (foto == null || foto.Altura < altura || foto.Largura < largura)
                {
                    foto = mercadoria.ObterFoto(largura, altura);
                    SalvarFotoEmDisco(mercadoria, foto);
                }

                if (foto == null) // Se não existir a foto...
                    return null;
#else
                foto = mercadoria.ObterFoto(largura, altura);

                if (foto == null) // Se não existir a foto...
                    return null;
#endif
                foto = ProcessarFoto(mercadoria, foto, largura, altura);

                cache.Add(chave, foto);
            }
            else
                Debug.Print("Aproveitando foto no cache com chave {0}.", chave);

            return foto;
        }

#if SALVAR_EM_DISCO
        private string ObterCaminhoFotoEmDisco(IMercadoria mercadoria)
        {
            return Path.Combine(CaminhoCacheEmDisco, string.Format("{0}.jpg", mercadoria.Referencia.ValorFormatado));
        }

        private IFoto ObterFotoEmDisco(IMercadoria mercadoria)
        {
            try
            {
                if (string.IsNullOrEmpty(CaminhoCacheEmDisco))
                    return null;

                string arquivo = ObterCaminhoFotoEmDisco(mercadoria);

                if (File.Exists(arquivo) && File.GetLastWriteTime(arquivo).Subtract(DateTime.Now).Days < 5)
                {
                    IFoto foto = MercadoriaDAO.CriarFoto(mercadoria);

                    PreencherFoto(foto, Image.FromFile(arquivo), foto.IMJ_IDFoto);

                    return foto;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        private void SalvarFotoEmDisco(IMercadoria mercadoria, IFoto foto)
        {
            ThreadPool.QueueUserWorkItem(delegate(object obj)
            {
                try
                {
                    string arquivo = ObterCaminhoFotoEmDisco(mercadoria);

                    if (!File.Exists(arquivo))
                    {
                        lock (sincronizador)
                        {
                            foto.Imagem.Save(arquivo, ImageFormat.Jpeg);
                        }
                    }
                }
                catch { }
            });
        }
#endif

        private IFoto ProcessarFoto(IMercadoria mercadoria, IFoto foto, int largura, int altura)
        {
            Debug.Print("Mercadoria {0}; Foto {1}; {2}x{3}", mercadoria.Referencia, foto.IDFoto, largura, altura);

            // Mantém a proporção original da imagem.
            if (largura > altura)
                altura = (int)Math.Round(largura * foto.Altura / (float)foto.Largura);
            else
                largura = (int)Math.Round(altura * foto.Largura / (float)foto.Altura);

            if (largura * 1.1 < foto.Largura || altura * 1.1 < foto.Altura)
            {
                // Cria a foto redimensionada.
                IFoto novaFoto = MercadoriaDAO.CriarFoto(mercadoria);
                var imgRedimensionada = ImagemHelper.Redimensionar(foto.Imagem, largura, altura);

                PreencherFoto(novaFoto, imgRedimensionada, foto.IMJ_IDFoto);

#if GRAVAR_REDIMENSIONAMENTO
                if (foto.Largura >= 1.25 * largura && foto.Altura >= 1.25 * altura)
                {
                    // Agenda a inclusão da foto no banco de dados de forma assíncrona.
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        using (IMercadoriaDAO dao = InjecaoDependencia.Resolver<IMercadoriaDAO>())
                        {
                            int cnt = dao.ContarFotos(mercadoria.Referencia);

                            if (cnt < 3)
                            {
                                using (TransactionScope transacao = new TransactionScope())
                                {
                                    dao.IncluirFoto(novaFoto);

                                    if (cnt + 1 == MercadoriaDAO.ContarFotos(mercadoria.Referencia))
                                        transacao.Complete();
                                }
                            }
                        }
                    });

                    return novaFoto;
                }
#endif

                return novaFoto;
            }
            else if (largura > foto.Largura || altura > foto.Altura)
            {
                /* Se a foto for menor que os requisitos, criar uma nova
                 * preenchida com área branca e a foto centralizada,
                 * para evitar distorções no navegador.
                 */
                IFoto novaFoto = MercadoriaDAO.CriarFoto(mercadoria);
                var imgReposicionada = ImagemHelper.Recortar(foto.Imagem, largura, altura);

                PreencherFoto(novaFoto, imgReposicionada, foto.IMJ_IDFoto);

                return novaFoto;
            }
            else
                return foto;
        }

        /// <summary>
        /// Obtém mercadoria a partir de sua referência.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <returns>Mercadoria.</returns>
        public IMercadoria ObterMercadoria(IUsuario usuario, Referencia referencia)
        {
            if (referencia.Completa)
            {
                var mercadoria = MercadoriaDAO.Obter(referencia);

                if (mercadoria != null && mercadoria.PermiteAcesso(usuario))
                    return mercadoria;
                else
                    return null;
            }
            else
            {
                var mercadorias = MercadoriaDAO.ListarMercadorias(referencia);

                foreach (var mercadoria in mercadorias)
                    if (mercadoria.PermiteAcesso(usuario))
                        return mercadoria;

                return null;
            }
        }

        /// <summary>
        /// Cadastra foto no banco de dados.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <param name="imagem">Foto da imagem.</param>
        /// <param name="id_imj">Identificador da foto no sistema da IMJ.</param>
        public void CadastrarFoto(Referencia referencia, Image imagem, long? id_imj)
        {
#if USAR_TRANSACAO
            using (TransactionScope transacao = new TransactionScope())
#endif
            {
                MercadoriaDAO.RemoverFotos(referencia);

                var mercadoria = MercadoriaDAO.Obter(referencia);
                var foto = MercadoriaDAO.CriarFoto(mercadoria);

                PreencherFoto(foto, imagem, id_imj);
                MercadoriaDAO.IncluirFoto(foto);
#if USAR_TRANSACAO
                transacao.Complete();
#endif
            }

            //ThreadPool.QueueUserWorkItem(delegate(object obj)
            //{
            //    IMercadoria mercadoria = MercadoriaDAO.Obter(obj.ToString());

            //    ObterFoto(mercadoria, 89, 89);
            //    ObterFoto(mercadoria, 640, 300);
            //}, referencia);
        }

        /// <summary>
        /// Preenche uma entidade de foto.
        /// </summary>
        /// <param name="foto">Entidade a ser preenchida.</param>
        /// <param name="imagem">Imagem da mercadoria.</param>
        /// <param name="id_imj">Identificador da foto no sistema IMJ.</param>
        private static void PreencherFoto(IFoto foto, Image imagem, long? id_imj)
        {
            foto.Imagem = imagem;
            foto.Largura = imagem.Width;
            foto.Altura = imagem.Height;
            foto.IMJ_IDFoto = id_imj;
        }

        /// <summary>
        /// Cadastra uma mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <param name="descricao">Descrição da mercadoria.</param>
        /// <param name="peso">Peso da mercadoria.</param>
        /// <param name="idAlbum">Identificador do catálogo local da IMJ.</param>
        public IMercadoria Cadastrar(string referencia, string descricao, decimal? peso, long idAlbum)
        {
            MercadoriaTO mercadoria = new MercadoriaTO()
            {
                Referencia = referencia,
                Descricao = descricao,
                Peso = peso,
                Catalogo = CatalogoDAO.ObterPorAlbum(idAlbum)
            };

            if (mercadoria.Catalogo.IMJ_IDAlbum.Value != idAlbum)
                mercadoria.Exclusiva = true;

            CatalogoDAO.Liberar(mercadoria.Catalogo);

            return MercadoriaDAO.Incluir(mercadoria);
        }

        /// <summary>
        /// Atualiza os índices de uma mercadoria.
        /// </summary>
        /// <param name="referencia">Mercadoria a ser atualizada.</param>
        /// <param name="indices">Índices da mercadoria.</param>
        /// <remarks>Todos os índices já existentes são substituídos.</remarks>
        public void Atualizar(string referencia, IndiceTO[] indices)
        {
#if USAR_TRANSACAO
            using (TransactionScope transacao = new TransactionScope())
#endif
            {
                IMercadoria mercadoria = MercadoriaDAO.Obter(referencia);

                mercadoria.Indices.Clear();

                foreach (var indice in indices)
                    mercadoria.Indices.Add(indice);

                MercadoriaDAO.Atualizar(mercadoria);
#if USAR_TRANSACAO
                transacao.Complete();
#endif
            }
        }

        public void Atualizar(string referencia, string descricao, decimal? peso, long album, IndiceTO[] indices)
        {
#if USAR_TRANSACAO
            using (TransactionScope transacao = new TransactionScope())
#endif
            {
                IMercadoria mercadoria = MercadoriaDAO.Obter(referencia);

                if (mercadoria == null)
                    mercadoria = Cadastrar(referencia, descricao, peso, album);
                else
                {
                    mercadoria.Descricao = descricao;
                    mercadoria.Peso = peso;

                    if (mercadoria.Catalogo.IMJ_IDAlbum != album)
                    {
                        CatalogoDAO.AssociarSe(MercadoriaDAO);

                        mercadoria.Catalogo = CatalogoDAO.ObterPorAlbum(album);
                    }

                    mercadoria.Exclusiva = mercadoria.Catalogo.IMJ_IDAlbum.Value != album;
                }

                foreach (var indice in mercadoria.Indices.ToArray())
                    MercadoriaDAO.Remover(mercadoria, indice);
                    
                mercadoria.Indices.Clear();

                foreach (var indice in indices)
                    mercadoria.Indices.Add(indice);

                MercadoriaDAO.Atualizar(mercadoria);
#if USAR_TRANSACAO
                transacao.Complete();
#endif
            }
        }

        /// <summary>
        /// Contabiliza hits na miniatura da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <remarks>Ocorre assincronamente.</remarks>
        [Obsolete]
        public void ContabilizarHitMiniatura(Referencia referencia)
        {
            //ContadorVisualizacoes.ContabilizarHitMiniatura(referencia);
        }

        /// <summary>
        /// Contabiliza hits na visualização da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <remarks>Ocorre assincronamente.</remarks>
        [Obsolete]
        public void ContabilizarVisualizacaoMercadoria(Referencia referencia)
        {
            //ContadorVisualizacoes.ContabilizarVisualizacaoMercadoria(referencia);
        }

        #region IDisposable Members

        public void Dispose()
        {
            MercadoriaDAO.Dispose();
            CatalogoDAO.Dispose();
        }

        #endregion
    }
}
