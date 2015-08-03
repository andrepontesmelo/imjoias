using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SuporteWeb;
using Acesso.Comum;

namespace Relatório.Menus
{
	/// <summary>
	/// Página contendo menu para obter relatório
	/// de setores de atendimento.
	/// </summary>
	public class MenuSetorAtendimento : System.Web.UI.Page
	{
		protected SuporteWeb.WebForms.Menu menuAtendimentosMensais;
		protected SuporteWeb.WebForms.Menu menuAtendimentos;
	
		/// <summary>
		/// Ocorre ao carregar a página
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			Usuário usr = SuporteUsuários.ObterUsuárioAtual(this);

			/* Acrescentar query_string para setor em cada
			 * controle de menu do formulário ASP.
			 */
			menuAtendimentos.Link += "?setor=" + Request.QueryString["setor"];
			menuAtendimentosMensais.Link += "?setor=" + Request.QueryString["setor"];

			SuporteUsuários.RegistrarUtilização(this, Entidades.Log.Aplicações.Relatório, "Setor = " + Request.QueryString["setor"]);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
