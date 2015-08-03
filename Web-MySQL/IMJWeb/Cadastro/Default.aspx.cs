using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMJWeb.Sessao;

namespace IMJWeb.Cadastro
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Session.ObterUsuarioAtual().Administrador)
                    Server.Transfer("GerenciarUsuarios.aspx");
                else
                    Server.Transfer("EdicaoCadastro.aspx");
            }
            else if (Request.Browser.IsBrowser("IE") && Request.Browser.MajorVersion == 6)
                Server.Transfer("Cadastro-IE6.aspx");
        }
    }
}