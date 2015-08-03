using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SuporteWeb;
using Acesso.Comum;

namespace Relatório
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button cmdEntrar;
		protected System.Web.UI.HtmlControls.HtmlInputText usuario;
		protected System.Web.UI.WebControls.Label lblMensagem;
		protected System.Web.UI.HtmlControls.HtmlInputText senha;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdEntrar.Click += new System.EventHandler(this.cmdEntrar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdEntrar_Click(object sender, System.EventArgs e)
		{
			Usuários usuários;
			object bla = Application["teste"];

			usuários = (Usuários) Application["usuários"];

			string a;

			a = usuários.ToString();

			try
			{
				Usuário usr = usuários.EfetuarLogin(this.usuario.Value, this.senha.Value);

				lblMensagem.Text = "Aguarde... redirecionando, " + this.usuario.Value + "!";

				FormsAuthentication.RedirectFromLoginPage(this.usuario.Value, false);
				Session.Add("chave", usr.Chave);
			}
			catch
			{
				lblMensagem.Text = "Não foi possível autenticá-lo no servidor!";
			}
		}
	}
}
