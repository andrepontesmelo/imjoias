using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using IMJWeb.Sessao;
using System.Security;
using System.IO;

namespace IMJWeb
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
    public partial class Status_Site : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session.ObterUsuarioAtual().Administrador)
                throw new SecurityException("Usuário não autorizado.");
        }

        public string TesteDeEscrita
        {
            get
            {
                try
                {
                    String arq = Path.Combine(IMJWeb.Global.CaminhoEscrita, "teste.tmp");
                    File.Create(arq).Close();
                    File.Delete(arq);
                    return "OK";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }
    }
}