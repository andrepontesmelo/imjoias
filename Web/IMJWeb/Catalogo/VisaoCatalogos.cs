using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IMJWeb.Dominio;
using IMJWeb.Dominio.Util;
using IMJWeb.Sessao;
using IMJWeb.Servico.Catalogo;
using System.Web.SessionState;
using System.Web.UI;

namespace IMJWeb.Catalogo
{
    public class VisaoCatalogos : IDisposable
    {
        /// <summary>
        /// Serviço de catálogos.
        /// </summary>
        private Catalogos servicoCatalogo;

        /// <summary>
        /// Serviço de catálogos.
        /// </summary>
        public Catalogos ServicoCatalogo
        {
            get
            {
                if (servicoCatalogo == null)
                    servicoCatalogo = InjecaoDependencia.Resolver<Catalogos>();

                return servicoCatalogo;
            }
        }

        /// <summary>
        /// Serviço de mercadorias.
        /// </summary>
        private Mercadorias servicoMercadoria;

        /// <summary>
        /// Serviço de mercadorias.
        /// </summary>
        public Mercadorias ServicoMercadoria
        {
            get
            {
                if (servicoMercadoria == null)
                    servicoMercadoria = InjecaoDependencia.Resolver<Mercadorias>();

                return servicoMercadoria;
            }
        }
        /// <summary>
        /// Dicionário de catálogos.
        /// </summary>
        private IDictionary<long, string> catalogos;

        /// <summary>
        /// Sessão Web.
        /// </summary>
        private HttpSessionState Session { get; set; }

        /// <summary>
        /// Dicionário de catálogos.
        /// </summary>
        public IDictionary<long, string> Catalogos
        {
            get
            {
                if (catalogos == null)
                    catalogos = ServicoCatalogo.ListarCatalogos(Session.ObterUsuarioAtual());

                return catalogos;
            }
        }

        /// <summary>
        /// Constrói a visão de catálogos.
        /// </summary>
        /// <param name="sessao"></param>
        public VisaoCatalogos(HttpSessionState sessao)
        {
            this.Session = sessao;
        }

        public string ObterNome(object item)
        {
            return ((KeyValuePair<long, string>)item).Value;
        }

        public long ObterChave(object item)
        {
            return ((KeyValuePair<long, string>)item).Key;
        }

        public bool CatalogoAtual(object item)
        {
            return Catalogo.IDCatalogo == ObterChave(item);
        }

        /// <summary>
        /// Define o catálogo atual.
        /// </summary>
        /// <param name="idCatalogo">Identificador do catálogo atual.</param>
        public void DefinirCatalogoAtual(long idCatalogo)
        {
            Catalogo = ServicoCatalogo.ObterCatalogo(Session.ObterUsuarioAtual(), idCatalogo);
        }

        private ICatalogo _catalogo;

        public ICatalogo Catalogo
        {
            get
            {
                if (_catalogo == null)
                {
                    DefinirCatalogoAtual(Catalogos.First().Key);
                }

                return _catalogo;
            }
            set
            {
                _catalogo = value;
            }
        }

        public int IndiceMercadoria { get; set; }

        public IMercadoria Mercadoria
        {
            get
            {
                try
                {
                    return MercadoriasCatalogo[IndiceMercadoria];
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
            }
        }

        private IList<IMercadoria> cacheMercadoriasCatalogo;

        public IList<IMercadoria> MercadoriasCatalogo
        {
            get
            {
                if (cacheMercadoriasCatalogo == null)
                    cacheMercadoriasCatalogo = Catalogo.ObterMercadorias(Session.ObterUsuarioAtual());

                return cacheMercadoriasCatalogo;
            }
        }

        public string ObterIndiceMercadoria()
        {
            try
            {
                return MercadoriaHelper.FormatarIndice(Mercadoria.ObterIndice(Session.ObterUsuarioAtual()));
            }
            catch (IndiceIndisponivelException)
            {
                return MercadoriaHelper.FormatarIndice(null);
            }
        }

        public string ObterPesoMercadoria()
        {
            return MercadoriaHelper.FormatarPeso(Mercadoria.Peso);
        }

        /// <summary>
        /// Pesquisa uma determinada mercadoria pela referência.
        /// </summary>
        /// <param name="referencia">Referência a ser pesquisada.</param>
        /// <returns>Verdadeiro quando a mercadoria for encontrada.</returns>
        public bool PesquisarMercadoria(string referencia)
        {
            var usuario = Session.ObterUsuarioAtual();
            var mercadoria = ServicoMercadoria.ObterMercadoria(usuario, referencia);

            if (mercadoria == null)
                return false;

            Catalogo = mercadoria.Catalogo;
            IndiceMercadoria = MercadoriasCatalogo.IndexOf(mercadoria);

            servicoMercadoria.ContabilizarVisualizacaoMercadoria(referencia);

            return true;
        }

        public int InicioListaMiniaturas { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
            if (servicoCatalogo != null)
                servicoCatalogo.Dispose();

            if (servicoMercadoria != null)
                servicoMercadoria.Dispose();
        }

        #endregion
    }
}