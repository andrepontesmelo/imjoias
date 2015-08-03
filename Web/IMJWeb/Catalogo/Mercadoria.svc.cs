using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using IMJWeb.Catalogo.TO;
using IMJWeb.Servico.Catalogo;
using IMJWeb.Dominio.Util;
using IMJWeb.Sessao;
using System.Web;
using IMJWeb.Dominio;

namespace IMJWeb.Catalogo
{
    [ServiceContract(Namespace = "IMJWeb")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    public class Mercadoria
    {
        /// <summary>
        /// Obtém uma mercadoria a partir de sua referência.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <returns>Dados da mercadoria.</returns>
        [OperationContract]
        public DadosMercadoria ObterMercadoria(string referencia)
        {
            Mercadorias servico = InjecaoDependencia.Resolver<Mercadorias>();
            var usuario = HttpContext.Current.Session.ObterUsuarioAtual();
            var mercadoria = servico.ObterMercadoria(usuario, referencia);
            DadosMercadoria to = mercadoria != null ? new DadosMercadoria(mercadoria) : null;

            return to;
        }

        /// <summary>
        /// Obtém as referências de uma mercadoria.
        /// </summary>
        /// <param name="idCatalogo">Identificador do catálogo.</param>
        /// <returns>Referências associadas ao catálogo.</returns>
        [OperationContract]
        public IEnumerable<string> ObterReferenciasCatalogo(long idCatalogo)
        {
            Catalogos servico = InjecaoDependencia.Resolver<Catalogos>();
            var usuario = HttpContext.Current.Session.ObterUsuarioAtual();
            var catalogo = servico.ObterCatalogo(usuario, idCatalogo);

            if (catalogo == null)
                throw new ArgumentException(string.Format("Não foi possível encontrar o catálogo {0}.", idCatalogo));

            return catalogo.ObterMercadorias(usuario).Select(m => m.Referencia.ValorNumerico);
        }
    }
}
