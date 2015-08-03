using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Data;
using SuporteWeb;
using Acesso.Comum;
using System.Runtime.Remoting.Lifetime;

namespace relatorio 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication, IDisposable
	{
		private static Usuários usuários;
		private static ClientSponsor sponsor;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{			
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			if (sponsor == null || usuários == null)
			{
				sponsor = new ClientSponsor();

				usuários = SuporteUsuários.ConstruirUsuários();
				sponsor.Register(usuários);
			}

			string a;

			a = usuários.ToString();

			Application.Add("usuários", usuários);
			Application.Add("teste", "coisa");
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			Session.Abandon();
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			Usuário usr = SuporteWeb.SuporteUsuários.ObterUsuárioAtual(Application, Session);

			if (usr != null)
				usuários.EfetuarLogoff(usr);
		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

