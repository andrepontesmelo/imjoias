using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMJWeb.Servico.Usuario;
using IMJWeb.Dominio.Util;
using System.Web.Security;
using IMJWeb.Dominio;
using IMJWeb.Sessao;
using System.Diagnostics;
using System.Web.UI.HtmlControls;

namespace IMJWeb
{
    /// <summary>
    /// Leiaute principal do sítio.
    /// </summary>
    public partial class Leiaute : System.Web.UI.MasterPage
    {
#if DEBUG
        protected const bool _debug = true;
#else
        protected const bool _debug = false;
#endif
        /// <summary>
        /// xuacompatible control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.HtmlControls.HtmlMeta xuacompatible;
        
        /// <summary>
        /// Ocorre ao carregar a página.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            DesabilitarMenuParaItemAtual();
            AjustarLeiauteLogin();

            /* Caso o usuário esteja usando IE 6, podemos melhorar o desempenho do
             * navegador utilizando o Google Chrome Frame.
             */
#if CHROME_FRAME
            if (Request.Browser.Browser == "IE" && Request.Browser.MajorVersion == 6)
                xuacompatible.Content = "chrome=1";
#endif
        }

        /// <summary>
        /// Ajusta os itens de login.
        /// </summary>
        private void AjustarLeiauteLogin()
        {
            PHEfetuarLogin.Visible = !Page.User.Identity.IsAuthenticated;
            PHLoginEfetuado.Visible = Page.User.Identity.IsAuthenticated;

            if (Page.User.Identity.IsAuthenticated)
                LnkCadastro.Text = "Cadastro";
        }

        /// <summary>
        /// Desabilita o menu para a página em exibição.
        /// </summary>
        private void DesabilitarMenuParaItemAtual()
        {
            string caminho = Page.MapPath(Request.Path);

            foreach (HyperLink link in frmLogin.Controls.OfType<HyperLink>())
                if (caminho.StartsWith(Page.MapPath(link.NavigateUrl)))
                    link.Enabled = false;
        }

        /// <summary>
        /// Ocorre antes de renderizar a página.
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (PHLoginEfetuado.Visible)
            {
                try
                {
                    nomeUsuario.InnerText = Session.ObterUsuarioAtual().Nome;
                }
                catch
                {
                    EfetuarLogout(sender, e);
                    Debug.WriteLine("Ocorreu um erro tentando recuperar usuário da sessão.");
                }
            }
        }

        /// <summary>
        /// Efetua o login do usuário.
        /// </summary>
        protected void EfetuarLogin(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Value;
            string senha = txtSenha.Value;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                Page.ClientScript.RegisterClientScriptInclude("Login", ResolveUrl("~/Login/alertarParametroObrigatorio.js"));
                return;
            }

            using (var servicoLogin = InjecaoDependencia.Resolver<IMJWeb.Servico.Usuario.ServicoUsuario>())
            {
                try
                {
                    IUsuario entidade = servicoLogin.EfetuarLogin(usuario, senha);
                    FormsAuthentication.RedirectFromLoginPage(usuario, false);

                    Session.DefinirUsuarioAtual(entidade);
                }
                catch (UsuarioNaoEncontradoException)
                {
                    Page.ClientScript.RegisterClientScriptInclude("Login", ResolveUrl("~/Login/alertarUsuarioIncorreto.js"));
                }
                catch (SenhaInvalidaException)
                {
                    Page.ClientScript.RegisterClientScriptInclude("Login", ResolveUrl("~/Login/alertarSenhaInvalida.js"));
                }
            }
        }

        /// <summary>
        /// Efetua o logout do usuário.
        /// </summary>
        protected void EfetuarLogout(object sender, EventArgs e)
        {
            Session.DefinirUsuarioAtual(null);

            FormsAuthentication.SignOut();
            Session.Abandon();

            PHEfetuarLogin.Visible = true;
            PHLoginEfetuado.Visible = false;

            Response.Redirect("~");
        }
    }
}