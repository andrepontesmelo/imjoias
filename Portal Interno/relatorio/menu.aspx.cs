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
using SuporteWeb.WebForms;

namespace Relat�rio
{
	/// <summary>
	/// Summary description for menu.
	/// </summary>
	public class menu : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder ph;
	
		/// <summary>
		/// Ocorre ao carregar a p�gina
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			SuporteUsu�rios.RecuperarUsu�rio(this);
			SuporteWeb.SuporteUsu�rios.RegistrarUtiliza��o(this, Entidades.Log.Aplica��es.Relat�rio);
			
			MostrarSetores();
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

		/// <summary>
		/// Insere menus para setores de atendimento
		/// </summary>
		private void MostrarSetores()
		{
			foreach (Entidades.Setor setor in Entidades.Setor.ObterSetores())
				if (setor.Atendimento)
				{
					Menu menu = new Menu();

					menu.T�tulo = setor.Nome;
					menu.Descri��o = "Relat�rios para o setor de " + setor.Nome.ToLower();
					menu.�cone = "../interface/atendimento.jpg";
					menu.Link = "Menus/MenuSetorAtendimento.aspx?setor=" + setor.C�digo.ToString();

					ph.Controls.Add(menu);
				}
		}
	}
}

