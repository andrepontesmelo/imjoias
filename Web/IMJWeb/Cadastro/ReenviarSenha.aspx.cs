using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using System.Security;
using IMJWeb.Sessao;
using IMJWeb.Servico.Usuario;
using IMJWeb.DAO;
using IMJWeb.Dominio.Util;
using IMJWeb.Dominio;

namespace IMJWeb.Cadastro
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
    public partial class ReenviarSenha : System.Web.UI.Page
    {
        public IUsuario Usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session.ObterUsuarioAtual().Administrador)
                throw new SecurityException("Usuário não autorizado.");

            using (IUsuarioDAO dao = InjecaoDependencia.Resolver<IUsuarioDAO>())
            {
                Usuario = dao.ObterPorLogin(Request["login"]);
            }
        }

        protected void ConfirmarReenvio(object sender, EventArgs e)
        {
            using (ServicoUsuario servico = InjecaoDependencia.Resolver<ServicoUsuario>())
            {
                servico.RedefinirSenha(Usuario.Login, Usuario.EMail);

                Context.Items["Usuario"] = Usuario;
                Server.Transfer("InstrucaoReenvioSenha.aspx", true);
            }
        }
    }
}
