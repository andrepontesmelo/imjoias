using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMJWeb.Dominio;
using System.Security.Permissions;

namespace IMJWeb.Cadastro
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
    public partial class InstrucaoReenvioSenha : System.Web.UI.Page
    {
        protected IUsuario Usuario
        {
            get
            {
                return (IUsuario)Context.Items["Usuario"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
