using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using IMJWeb.Dominio.Util;
using IMJWeb.Dominio.Especificacao.AcessoUsuario;
using System.Diagnostics;

namespace IMJWeb.DAO.EF
{
    partial class Mercadoria : IMercadoria
    {
        private IValidadorAcessoUsuario<IMercadoria> validadorAcesso;

        partial void OnReferenciaChanged()
        {
            Referencia referencia = this.Referencia;

            if (this.Referencia != referencia.ValorNumerico)
                this.Referencia = referencia.ValorNumerico;
        }

        /// <summary>
        /// Validador de acesso ao catálogo.
        /// </summary>
        protected IValidadorAcessoUsuario<IMercadoria> ValidadorAcesso
        {
            get
            {
                if (validadorAcesso == null)
                    validadorAcesso = FabricaValidadorAcessoUsuario.Criar<IMercadoria>();

                return validadorAcesso;
            }
        }

        #region IMercadoria Members

        /// <summary>
        /// Referência da mercadoria.
        /// </summary>
        Referencia IMercadoria.Referencia
        {
            get
            {
                return this.Referencia;
            }
            set
            {
                this.Referencia = value;
            }
        }

        /// <summary>
        /// Catálogo da mercadoria.
        /// </summary>
        ICatalogo IMercadoria.Catalogo
        {
            get
            {
                if (!this.CatalogoReference.IsLoaded)
                    this.CatalogoReference.Load();

                return this.Catalogo;
            }
            set
            {
                this.Catalogo = value.ParaEF();
            }
        }

        #endregion

        private AdaptadorColecao<IFoto, Foto> adaptadorFoto;

        ICollection<IFoto> IMercadoria.Fotos
        {
            get
            {
                if (adaptadorFoto == null)
                {
                    if (!this.Fotos.IsLoaded)
                        this.Fotos.Load();

                    adaptadorFoto = new AdaptadorColecao<IFoto, Foto>(this.Fotos, (a, b) => a.IDFoto == b.IDFoto);
                }

                return adaptadorFoto;
            }
        }

        private AdaptadorColecaoIndice adaptadorIndice;

        ICollection<IIndice> IMercadoria.Indices
        {
            get
            {
                if (adaptadorIndice == null)
                {
                    if (!this.Indices.IsLoaded)
                        this.Indices.Load();

                    adaptadorIndice = new AdaptadorColecaoIndice(this);
                }

                return adaptadorIndice;
            }
        }

        /// <summary>
        /// Obtém a foto mais apropriada para a largura e altura desejada.
        /// </summary>
        /// <param name="largura">Largura desejada.</param>
        /// <param name="altura">Altura desejada.</param>
        /// <returns>Foto mais apropriada.</returns>
        public IFoto ObterFoto(int largura, int altura)
        {
            ModeloMercadorias modelo = new ModeloMercadorias();

            var dadosFotos = (from f in modelo.Fotos
                             where f.Mercadoria.Referencia == this.Referencia
                             select new {
                                 IDFoto = f.IDFoto,
                                 Largura = f.Largura,
                                 Altura = f.Altura
                             }).ToList();

            Debug.Assert(dadosFotos.Count > 0);

            var fotos = from f in dadosFotos
                        let dLargura = f.Largura - largura
                        let dAltura = f.Altura - altura
                        where dLargura >= 0 && dAltura >= 0
                        let criterio = dAltura == 0 ? 0 :  1.0f / (dLargura / (float)dAltura)
                        select new
                        {
                            IDFoto = f.IDFoto,
                            Criterio = criterio
                        };

            var resultado = fotos.OrderBy(f => f.Criterio).FirstOrDefault();

            if (resultado == null)
            {
                var item = dadosFotos.OrderByDescending(f => f.Largura / f.Altura).FirstOrDefault();

                if (item != null)
                    return modelo.Fotos.FirstOrDefault(foto => foto.IDFoto == item.IDFoto);
                else
                    return null;
            }
            else
                return modelo.Fotos.FirstOrDefault(f => f.IDFoto == resultado.IDFoto);
        }

        /// <summary>
        /// Verifica se o acesso ao usuário é permitido.
        /// </summary>
        /// <param name="usuario">Usuário cujo acesso será verificado.</param>
        /// <returns>Verdadeiro se usuário pode visualizar o catálogo.</returns>
        public bool PermiteAcesso(IUsuario usuario)
        {
            return ValidadorAcesso.PermiteAcesso(this, usuario);
        }

        /// <summary>
        /// Obtém o índice para o usuário.
        /// </summary>
        /// <param name="usuario">Usuário cujo índice será calculado.</param>
        /// <returns>Índice para o tipo de cliente do usuário.</returns>
        /// <remarks>
        /// O valor do índice da mercadoria varia de acordo a região do cliente,
        /// que define seu tipo (varejo, atacado, alto-atacado) e se a mercadoria
        /// é pesada ("de peso") ou não no momento da venda.
        /// </remarks>
        public decimal? ObterIndice(IUsuario usuario)
        {
            if (usuario == null || usuario.Tabela == null)
                throw new IndiceIndisponivelException(Referencia);

            using (ModeloMercadorias modelo = new ModeloMercadorias())
            {
                var indice = modelo.Indices.FirstOrDefault(i => i.Referencia == this.Referencia && i.IDTabela == usuario.Tabela.IDTabela);

                return indice != null ? indice.Valor : (decimal?)null;
            }
        }

        public override string ToString()
        {
            return new Referencia(Referencia).ValorFormatado;
        }
    }
}
