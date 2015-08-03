using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IMJWeb.Catalogo.TO;
using IMJWeb.Servico.Catalogo;
using IMJWeb.Dominio.Util;
using IMJWeb.Sessao;
using System.Web.SessionState;

namespace IMJWeb.Catalogo
{
    /// <summary>
    /// Summary description for Mercadoria1
    /// </summary>
    //[WebService(Namespace = "http://www.imjoias.com.br/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Mercadoria : System.Web.Services.WebService, IReadOnlySessionState
    {
        /// <summary>
        /// Obtém uma mercadoria a partir de sua referência.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <returns>Dados da mercadoria.</returns>
        [WebMethod(EnableSession = true)]
        public DadosMercadoria ObterMercadoria(string referencia)
        {
            using (Mercadorias servico = InjecaoDependencia.Resolver<Mercadorias>())
            {
                var usuario = HttpContext.Current.Session.ObterUsuarioAtual();
                var mercadoria = servico.ObterMercadoria(usuario, referencia);
                DadosMercadoria to = mercadoria != null ? new DadosMercadoria(mercadoria) : null;

                servico.ContabilizarVisualizacaoMercadoria(referencia);

                return to;
            }
        }

        /// <summary>
        /// Obtém as referências de uma mercadoria.
        /// </summary>
        /// <param name="idCatalogo">Identificador do catálogo.</param>
        /// <returns>Referências associadas ao catálogo.</returns>
        [WebMethod(EnableSession = true)]
        public string[] ObterReferenciasCatalogo(long idCatalogo)
        {
            using (Catalogos servico = InjecaoDependencia.Resolver<Catalogos>())
            {
                var usuario = HttpContext.Current.Session.ObterUsuarioAtual();
                var catalogo = servico.ObterCatalogo(usuario, idCatalogo);

                if (catalogo == null)
                    throw new ArgumentException(string.Format("Não foi possível encontrar o catálogo {0}.", idCatalogo));

                return catalogo.ObterMercadorias(usuario).Select(m => m.Referencia.ValorNumerico).ToArray();
            }
        }
    }
}
