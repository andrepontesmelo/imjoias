using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using System.IO;
using System.Diagnostics;
using IMJWeb.DAO.Db4o.Entidades;

namespace IMJWeb.DAO.Db4o
{
    public class MercadoriaDAO : BaseDAODb4o<IMercadoria, Mercadoria, Referencia>, IMercadoriaDAO
    {
        public static string CaminhoDB { get; set; }

        public MercadoriaDAO() : base(CaminhoDB) { }

        //public MercadoriaDAO(string arquivo) : base(arquivo) { }

        /// <summary>
        /// Inclui uma foto.
        /// </summary>
        /// <param name="foto">Foto a ser incluída.</param>
        public void IncluirFoto(Dominio.IFoto foto)
        {
            lock (db)
            {
                if (db.Query<IFoto>(f => f.IDFoto == foto.IDFoto).Count == 0)
                {
                    Foto entidade = foto as Foto;

                    if (entidade == null)
                        entidade = Converter(foto);
                    
                    Debug.Print("Incluindo foto {0} para mercadoria {1} na base Db4o.", entidade.IDFoto, entidade.Mercadoria.Referencia);
                    db.Store(entidade);
                    db.Store(entidade.Mercadoria);

                    if (!foto.Mercadoria.Fotos.Contains(foto))
                        Debugger.Break();

                    db.Commit();
                }
            }
        }

        private Foto Converter(IFoto foto)
        {
            return Converter(Obter(foto.Mercadoria.Referencia), foto);
        }

        protected override void Copiar(IMercadoria origem, Mercadoria destino)
        {
            base.Copiar(origem, destino);

            destino.Catalogo = Converter(origem.Catalogo);
        }

        private Catalogo Converter(ICatalogo catalogo)
        {
            return db.Query<Catalogo>(c => c.IDCatalogo == catalogo.IDCatalogo).SingleOrDefault() ?? new Catalogo()
            {
                IDCatalogo = catalogo.IDCatalogo,
                IMJ_IDAlbum = catalogo.IMJ_IDAlbum,
                Nome = catalogo.Nome
            };
        }

        private Foto Converter(IMercadoria mercadoria, IFoto foto)
        {
            return new Foto(mercadoria)
            {
                Altura = foto.Altura,
                IDFoto = foto.IDFoto,
                Imagem = foto.Imagem,
                IMJ_IDFoto = foto.IMJ_IDFoto,
                Largura = foto.Largura
            };
        }

        /// <summary>
        /// Cria uma foto vazia para uma mercadoria.
        /// </summary>
        /// <param name="mercadoria">Mercadoria cuja foto será criada.</param>
        /// <returns>Foto vazia criada.</returns>
        public Dominio.IFoto CriarFoto(Dominio.IMercadoria mercadoria)
        {
            return new Foto(mercadoria);
        }

        /// <summary>
        /// Remove um índice de uma mercadoria.
        /// </summary>
        /// <param name="indice">Índice da mercadoria.</param>
        public void Remover(Dominio.IMercadoria mercadoria, Dominio.IIndice indice)
        {
            mercadoria.Indices.Remove(indice);
            db.Delete(indice);
            db.Store(mercadoria);
        }

        public long[] ObterFotos(Dominio.Referencia referencia)
        {
            return Obter(referencia).Fotos.Select(f => f.IDFoto).ToArray();
        }

        /// <summary>
        /// Exclui todas as fotos de uma mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        public void RemoverFotos(Dominio.Referencia referencia)
        {
            IMercadoria mercadoria = Obter(referencia);

            foreach (var foto in mercadoria.Fotos)
            {
                db.Delete(foto);
            }

            mercadoria.Fotos.Clear();
            db.Store(mercadoria);

            if (db.Query<IMercadoria>(CompararChave(referencia)).Count > 1)
                Debugger.Break();
        }

        /// <summary>
        /// Conta a quantidade de fotos.
        /// </summary>
        public int ContarFotos(Dominio.Referencia referencia)
        {
            return Obter(referencia).Fotos.Count;
        }

        /// <summary>
        /// Lista as mercadorias por parte da referência.
        /// </summary>
        /// <param name="parteReferencia">Parte da referência a ser procurada.</param>
        /// <returns>Lista de mercadorias.</returns>
        public List<Dominio.IMercadoria> ListarMercadorias(Dominio.Referencia parteReferencia)
        {
            string pesquisa = parteReferencia.ValorFormatado;

            return db.Query<IMercadoria>(m => m.Referencia.ValorFormatado.StartsWith(pesquisa)).ToList();
        }

        protected void IncremetarEstatistica(Referencia referencia, Action<EstatisticaMercadoria> acao)
        {
            EstatisticaMercadoria estatistica = db.Query<EstatisticaMercadoria>(e => e.Referencia.Equals(referencia)).SingleOrDefault();

            if (estatistica == null)
                estatistica = new EstatisticaMercadoria();

            acao(estatistica);
            db.Store(estatistica);
        }

        /// <summary>
        /// Incrementa a contagem de hits na miniatura da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência cuja contagem de hits será incrementada.</param>
        public void IncrementarHitMiniaturaMercadoria(Dominio.Referencia referencia, ulong incremento)
        {
            IncremetarEstatistica(referencia, e => e.Hits += incremento);
        }

        /// <summary>
        /// Incrementa a contagem de hits na mercadoria.
        /// </summary>
        /// <param name="referencia">Referência cuja contagem de hits na miniatura será incrementada.</param>
        public void IncrementarVisualizacaoMercadoria(Dominio.Referencia referencia, ulong incremento)
        {
            IncremetarEstatistica(referencia, e => e.Visualizacoes += incremento);
        }

        /// <summary>
        /// Obtém data da última atualização.
        /// </summary>
        /// <returns>Data da última atualização.</returns>
        public DateTime? ObterDataUltimaAtualizacao()
        {
            return db.Query<ControleMercadoria>().Max(c => c.UltimaAtualizacao);
        }

        /// <summary>
        /// Obtém mercadorias a partir de uma data.
        /// </summary>
        /// <param name="data">Data de referência cujas mercadorias cadastradas após esta deverão ser retornadas.</param>
        /// <returns>Lista de mercadorias cadastradas após a data especificada.</returns>
        public IList<Dominio.IMercadoria> ObterMercadoriasAPartirDe(DateTime data)
        {
            var referencias = new HashSet<Referencia>(db.Query<ControleMercadoria>(c => c.UltimaAtualizacao >= data).Select(c => c.Referencia));
            var mercadorias = db.Query<IMercadoria>(m => referencias.Contains(m.Referencia));

            return mercadorias;
        }

        /// <summary>
        /// Conta a quantidade de mercadorias a partir de uma data.
        /// </summary>
        /// <param name="data">Data de referência.</param>
        /// <returns>Quantidade de mercadorias.</returns>
        public int ContarMercadoriasAPartirDe(DateTime data)
        {
            return db.Query<ControleMercadoria>(c => c.DataCriacao >= data).Count;
        }

        protected override void GerarChave(IMercadoria entidade)
        {
            throw new NotSupportedException("Não é possível gerar referência para mercadoria.");
        }

        protected override Referencia ExtrairChave(IMercadoria entidade)
        {
            return entidade.Referencia;
        }

        protected override Predicate<IMercadoria> CompararChave(Referencia identificador)
        {
            return new Predicate<IMercadoria>(m => m.Referencia.Equals(identificador));
        }

        public override IMercadoria Incluir(IMercadoria entidade)
        {
            Debug.Print("Incluindo mercadoria {0} na base Db4o.", entidade.Referencia);

            lock (db)
            {
                if (Obter(entidade.Referencia) == null)
                {
                    try
                    {
                        ControleMercadoria controle = new ControleMercadoria()
                        {
                            DataCriacao = DateTime.Now,
                            UltimaAtualizacao = DateTime.Now,
                            Referencia = entidade.Referencia
                        };

                        db.Store(controle);

                        var q1 = db.Query<IMercadoria>(CompararChave(ExtrairChave(entidade))).ToArray();

                        if (q1.Length > 0)
                            Debugger.Break();

                        entidade = base.Incluir(entidade);
                        db.Commit();

                        var q = db.Query<IMercadoria>(CompararChave(ExtrairChave(entidade))).ToArray();
                        
                        if (q.Length > 1)
                            Debugger.Break();
                    }
                    catch
                    {
                        db.Rollback();
                        throw;
                    }
                }
            }

            return entidade;
        }

        public override void Remover(IMercadoria entidade)
        {
            Debug.Print("Removendo mercadoria {0} da base Db4o.", entidade.Referencia);

            lock (db)
            {
                try
                {
                    foreach (ControleMercadoria controle in db.Query<ControleMercadoria>(c => c.Referencia.Equals(entidade.Referencia)).ToList())
                        db.Delete(controle);

                    base.Remover(entidade);
                    db.Commit();
                }
                catch
                {
                    db.Rollback();
                    throw;
                }
            }
        }

        public override void Atualizar(IMercadoria entidade)
        {
            Debug.Print("Atualizando mercadoria {0} da base Db4o.", entidade.Referencia);

            lock (db)
            {
                try
                {
                    ControleMercadoria controle = db.Query<ControleMercadoria>(c => c.Referencia.Equals(entidade.Referencia)).SingleOrDefault();

                    if (controle == null)
                    {
                        controle = new ControleMercadoria();
                        controle.DataCriacao = DateTime.Now;
                    }

                    controle.UltimaAtualizacao = DateTime.Now;
                    db.Store(controle);

                    base.Atualizar(entidade);
                }
                catch
                {
                    db.Rollback();
                    throw;
                }
            }
        }

        protected override Mercadoria Converter(IMercadoria origem)
        {
            var destino = base.Converter(origem);
            var fotos = new List<IFoto>(origem.Fotos);

            destino.Fotos.Clear();

            foreach (var foto in fotos)
                Converter(destino, foto);

            return destino;
        }
    }
}
