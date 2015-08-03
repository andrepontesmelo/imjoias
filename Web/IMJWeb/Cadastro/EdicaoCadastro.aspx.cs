using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMJWeb.Sessao;
using IMJWeb.Dominio;
using IMJWeb.Dominio.Util;
using IMJWeb.Servico.Usuario;
using System.Security.Permissions;

namespace IMJWeb.Cadastro
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
    public partial class EdicaoCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EMail.Text = Session.ObterUsuarioAtual().EMail;
        }

        protected void AlterarSenha(object sender, EventArgs e)
        {
            if (NovaSenha.Text != Confirmacao.Text)
            {
                Page.ClientScript.RegisterClientScriptInclude("AlterarSenha", ResolveUrl("~/Cadastro/alertarSenhaConfirmacaoInvalida.js"));
                return;
            }

            IUsuario usuario = Session.ObterUsuarioAtual();

            if (!usuario.ValidarSenha(SenhaAtual.Text))
                Page.ClientScript.RegisterClientScriptInclude("AlterarSenha", ResolveUrl("~/Cadastro/alertarSenhaInvalida.js"));

            using (ServicoUsuario login = InjecaoDependencia.Resolver<ServicoUsuario>())
            {
                login.DefinirSenha(usuario.Login, NovaSenha.Text);
            }
        }
    }
}
