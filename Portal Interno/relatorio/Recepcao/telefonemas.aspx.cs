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

namespace Relatório.Recepcao
{
	/// <summary>
	/// Summary description for telefonemas.
	/// </summary>
	public class telefonemas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblInfoEspera;
		protected System.Web.UI.WebControls.DataGrid dgTelefones;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);

			SuporteUsuários.RecuperarUsuário(this);
			SuporteUsuários.RegistrarUtilização(this, Entidades.Log.Aplicações.Telefonemas);
			
			ObterTelefonemas();
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

		private void ObterTelefonemas()
		{
			DataSet ds;

			ds = Entidades.Telefonema.ObterÚltimosTelefonemas(20);
			
			dgTelefones.DataSource = ds;
			dgTelefones.DataBind();
		}
	}
}
