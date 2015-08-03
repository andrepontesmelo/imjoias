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

namespace Relat�rio.Graficos
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		// Atributos
		private Estat�stica.Db.Gr�fico gr�fico;

		// Html
		protected System.Web.UI.WebControls.Panel painelT�tulo;
		protected System.Web.UI.WebControls.RadioButtonList radioT�tulo;
		protected System.Web.UI.WebControls.Calendar per�odoInicial;
		protected System.Web.UI.WebControls.Calendar per�odoFinal;
		protected System.Web.UI.WebControls.Panel painelSetor;
		protected System.Web.UI.WebControls.RadioButtonList setor;
		protected System.Web.UI.WebControls.Panel painelEnvio;
		protected System.Web.UI.WebControls.Label lblT�tulo;
		protected System.Web.UI.WebControls.Panel painelPer�odo;
	
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
			this.radioT�tulo.SelectedIndexChanged += new System.EventHandler(this.radioT�tulo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this._Default_Init);

		}
		#endregion

		private System.IO.Stream ObterDefini��es()
		{
			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			
			string [] resources = thisExe.GetManifestResourceNames();
			string list = "";

			// Build the string of resources.
			foreach (string resource in resources)
				list += resource + "\r\n";

			System.IO.Stream file = 
				thisExe.GetManifestResourceStream("Relat�rio.Graficos.definicoes.xml");

			return file;
		}
/*
		protected void EscreverRadioT�tulo()
		{
			foreach (string t�tulo in gr�fico.Gr�ficos)
				Response.Write("<input type=radio value='" + t�tulo + "' name='ref'/>" + t�tulo + "<br/>");
		}
*/
		/// <summary>
		/// Carrega as defini��es de gr�fico
		/// </summary>
		private void _Default_Init(object sender, System.EventArgs e)
		{
			SuporteWeb.SuporteUsu�rios.RecuperarUsu�rio(this);

			gr�fico = new Estat�stica.Db.Gr�fico();
			gr�fico.CarregarDefini��es(ObterDefini��es());

			foreach (string refer�ncia in gr�fico.Gr�ficos)
			{
				string t�tulo = gr�fico.ObterT�tulo(refer�ncia);

				radioT�tulo.Items.Add(new ListItem(t�tulo, refer�ncia));
			}

			per�odoInicial.SelectedDate = per�odoFinal.SelectedDate = DateTime.Now;

			setor.DataSource = Entidades.Setor.ObterSetoresAtendimentoDataSet();
			setor.DataValueField = "codigo";
			setor.DataTextField = "nome";
			setor.DataBind();
		}

		/// <summary>
		/// Ocorre quando escolhe-se um t�tulo
		/// </summary>
		private void radioT�tulo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.radioT�tulo.Visible = false;
			this.lblT�tulo.Text = radioT�tulo.SelectedItem.Text;
			painelPer�odo.Visible = false;
			painelSetor.Visible = false;
			painelEnvio.Visible = true;

			foreach (string s in gr�fico.ObterRequisitos(radioT�tulo.SelectedValue))
			{
				if (string.Compare("per�odo", s, true) == 0)
					painelPer�odo.Visible = true;
				else if (string.Compare("setor", s, true) == 0)
					painelSetor.Visible = true;
			}
		}
	}
}
