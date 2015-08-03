using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Acesso.Comum;
using MySql.Data.MySqlClient;

namespace Portal
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "Portal")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(true)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [System.Web.Script.Services.ScriptMethod]
        [WebMethod]
        public string[] GetCompletionList(string prefixText, int count)
        {
            AcessoBD.AssegurarConectado();

            Entidades.Mercadoria.Mercadoria[] mercadorias =
                Entidades.Mercadoria.Mercadoria.ObterMercadorias(prefixText, count, Entidades.Tabela.TabelaPadrão, true);

            string[] strings = new string[mercadorias.Length];

            for (int i = 0; i < mercadorias.Length; i++)
                strings[i] = mercadorias[i].Referência;

            return strings;
        }

        [System.Web.Script.Services.ScriptMethod]
        [WebMethod]
        public string[] ObterListaAutoCompletarPessoas(string prefixText, int count)
        {
            AcessoBD.AssegurarConectado();

            return Entidades.Pessoa.Pessoa.ObterNomes(prefixText, count);
        }
    }
}
