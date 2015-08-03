using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using IMJWeb.Sessao;

namespace IMJWeb.Catalogo
{
    /// <summary>
    /// Catálogo de joias.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        private const int ListaLoginTamanhoInicial = 20;
        private const int ListaAnonimoTamanhoInicial = 16;
        private const int MiniaturaLargura = 89;
        private const int MiniaturaAltura = 89;
        private const int QuantidadeMiniaturasHorizontais = 4;
        private VisaoCatalogos visao;

        /// <summary>
        /// Componente de visão dos catálogos.
        /// </summary>
        protected VisaoCatalogos Visao
        {
            get
            {
                if (visao == null)
                    visao = new VisaoCatalogos(Session);

                return visao;
            }
        }

        /// <summary>
        /// Tamanho da lista de miniaturas.
        /// </summary>
        protected int TamanhoLista
        {
            get
            {
                var strMiniaturas = Request["miniaturas"];

                if (!string.IsNullOrEmpty(strMiniaturas))
                {
                    int miniaturas;

                    if (int.TryParse(strMiniaturas, out miniaturas))
                        return miniaturas;
                }

                if (User.Identity.IsAuthenticated)
                    return ListaLoginTamanhoInicial;
                else
                    return ListaAnonimoTamanhoInicial;
            }
        }

        /// <summary>
        /// Ocorre ao carregar a página.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            InterpretarCatalogo();
            InterpretarMercadoria();
            InterpretarMiniaturas();

            repCatalogo.DataSource = Visao.Catalogos;
            repCatalogo.DataBind();

            phMercadorias.Visible = visao.MercadoriasCatalogo.Count > 0;
            phSemMercadorias.Visible = !phMercadorias.Visible;
            phInformativoCadastro.Visible = !User.Identity.IsAuthenticated;

            PreencherListaDeMiniaturas();

            if (Visao.Catalogo != null)
                Title = string.Format("{0} - {1}", Visao.Catalogo.Nome, Title);
        }

        public override void Dispose()
        {
            if (visao != null)
                visao.Dispose();

            base.Dispose();
        }

        /// <summary>
        /// Interpreta o índice de início de exibição das mercadorias.
        /// </summary>
        private void InterpretarMiniaturas()
        {
            var idxMiniaturas = Request["idxMiniaturas"];

            if (!string.IsNullOrEmpty(idxMiniaturas))
            {
                int inicio;

                if (int.TryParse(idxMiniaturas, out inicio))
                    Visao.InicioListaMiniaturas = inicio;
            }
        }

        /// <summary>
        /// Preenche a lista de miniaturas.
        /// </summary>
        private void PreencherListaDeMiniaturas()
        {
            int final = Math.Min(Visao.InicioListaMiniaturas + TamanhoLista, Visao.MercadoriasCatalogo.Count);
            var mercadorias = Visao.MercadoriasCatalogo;

            for (int i = Visao.InicioListaMiniaturas; i < final; i++)
            {
                var mercadoria = mercadorias[i];
                var item = new HtmlGenericControl("li") { InnerText = " " };
                var link = new HtmlAnchor() { HRef = GerarParametros(Visao.Catalogo.IDCatalogo, i) };
                var imagem = new HtmlImage()
                {
                    Src = string.Format("Foto.ashx?recortar=true&ref={0}&largura={1}&altura={2}", mercadoria.Referencia.ValorFormatado, MiniaturaLargura, MiniaturaAltura),
                    Alt = mercadoria.Referencia.ValorFormatado
                };

                if (Request.Browser.IsBrowser("IE") && Request.Browser.MajorVersion == 6)
                    imagem.Src += "&formato=jpeg";

                link.Controls.Add(imagem);
                link.Attributes["indice"] = i.ToString();
                link.Title = string.Format("Ref. {0}", mercadoria.Referencia.ValorFormatado);
                item.Controls.Add(link);

                phListaJoias.Controls.Add(item);
            }
        }

        /// <summary>
        /// Interpreta o parâmetro de definição do catálogo.
        /// </summary>
        private void InterpretarCatalogo()
        {
            var id = Request["id"];
            long idCatalogo;

            if (id != null && long.TryParse(id, out idCatalogo))
                Visao.DefinirCatalogoAtual(idCatalogo);

            else
            {
                if (Visao.ServicoCatalogo.ObterNovidades().PermiteAcesso(Session.ObterUsuarioAtual()))
                    Visao.DefinirCatalogoAtual(Visao.ServicoCatalogo.ObterNovidades().IDCatalogo);
            }
        }

        /// <summary>
        /// Interpreta o parâmetro de definição da mercadoria.
        /// </summary>
        private void InterpretarMercadoria()
        {
            var referencia = Request["ref"];

            if (!string.IsNullOrEmpty(referencia))
            {
                if (!Visao.PesquisarMercadoria(referencia))
                {
                    Page.ClientScript.RegisterClientScriptInclude("Pesquisa", ResolveUrl("~/Catalogo/AlertarMercadoriaNaoEncontrada.js"));
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Default), "PesquisaValor", string.Format("$(function() {{ $('#txtReferencia').val('{0}'); }});", referencia), true);
                }
            }
            else
            {
                var strIdx = Request["indice"];
                int idx;

                if (strIdx != null && int.TryParse(strIdx, out idx))
                {
                    Visao.IndiceMercadoria = idx;

                    if (Visao.Mercadoria == null)
                        Server.Transfer("~/Erro-404.aspx");
                }
            }
        }

        /// <summary>
        /// Gera parâmetros para a requisição.
        /// </summary>
        /// <param name="idCatalogo">Identificador do catálogo.</param>
        /// <param name="idxMercadoria">Índice da mercadoria no catálogo.</param>
        /// <returns>Parâmetros do catálogo.</returns>
        protected string GerarParametros(long idCatalogo, int idxMercadoria)
        {
            return GerarParametros(idCatalogo, idxMercadoria, null, null);
        }

        /// <summary>
        /// Gera parâmetros para a requisição.
        /// </summary>
        /// <param name="idCatalogo">Identificador do catálogo.</param>
        /// <param name="idxMercadoria">Índice da mercadoria no catálogo.</param>
        /// <param name="idxMiniaturas">Índice de miniaturas.</param>
        /// <returns>Parâmetros do catálogo.</returns>
        protected string GerarParametros(long? idCatalogo, int? idxMercadoria, int? tamanhoListaMiniaturas, int? idxMiniaturas)
        {
            if (idxMercadoria.HasValue)
            {
                if (idxMercadoria.Value < 0)
                    return "#";

                else if (idxMercadoria.Value >= Visao.MercadoriasCatalogo.Count())
                    return "#";
            }

            return string.Format("?id={0}&indice={1}&miniaturas={2}&idxMiniaturas={3}",
                idCatalogo ?? Visao.Catalogo.IDCatalogo,
                idxMercadoria ?? Visao.IndiceMercadoria,
                tamanhoListaMiniaturas ?? TamanhoLista,
                idxMiniaturas ?? Visao.InicioListaMiniaturas);
        }

        /// <summary>
        /// Gera parâmetros para a requisição, realizando scroll para cima das miniaturas.
        /// </summary>
        /// <returns>Parâmetros do catálogo.</returns>
        protected string GerarParametrosScrollMiniaturasCima()
        {
            if (Visao.InicioListaMiniaturas > TamanhoLista)
                return GerarParametros(null, Visao.InicioListaMiniaturas - TamanhoLista, null, null);
            else
                return GerarParametros(null, Visao.InicioListaMiniaturas, null, null);
        }

        /// <summary>
        /// Gera parâmetros para a requisição, realizando scroll para baixo das miniaturas.
        /// </summary>
        /// <returns>Parâmetros do catálogo.</returns>
        protected string GerarParametrosScrollMiniaturasBaixo()
        {
            int maximo = Visao.MercadoriasCatalogo.Count - QuantidadeMiniaturasHorizontais;

            if (Visao.InicioListaMiniaturas + TamanhoLista < maximo)
                return GerarParametros(null, Visao.InicioListaMiniaturas + TamanhoLista, null, null);
            else
                return GerarParametros(null, maximo, null, null);
        }
    }
}