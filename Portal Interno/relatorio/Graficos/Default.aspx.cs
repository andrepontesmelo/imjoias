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

namespace Relatório.Graficos
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		// Atributos
		private Estatística.Db.Gráfico gráfico;

		// Html
		protected System.Web.UI.WebControls.Panel painelTítulo;
		protected System.Web.UI.WebControls.RadioButtonList radioTítulo;
		protected System.Web.UI.WebControls.Calendar períodoInicial;
		protected System.Web.UI.WebControls.Calendar períodoFinal;
		protected System.Web.UI.WebControls.Panel painelSetor;
		protected System.Web.UI.WebControls.RadioButtonList setor;
		protected System.Web.UI.WebControls.Panel painelEnvio;
		protected System.Web.UI.WebControls.Label lblTítulo;
		protected System.Web.UI.WebControls.Panel painelPeríodo;
	
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
			this.radioTítulo.SelectedIndexChanged += new System.EventHandler(this.radioTítulo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this._Default_Init);

		}
		#endregion

		private System.IO.Stream ObterDefinições()
		{
			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			
			string [] resources = thisExe.GetManifestResourceNames();
			string list = "";

			// Build the string of resources.
			foreach (string resource in resources)
				list += resource + "\r\n";

			System.IO.Stream file = 
				thisExe.GetManifestResourceStream("Relatório.Graficos.definicoes.xml");

			return file;
		}
/*
		protected void EscreverRadioTítulo()
		{
			foreach (string título in gráfico.Gráficos)
				Response.Write("<input type=radio value='" + título + "' name='ref'/>" + título + "<br/>");
		}
*/
		/// <summary>
		/// Carrega as definições de gráfico
		/// </summary>
		private void _Default_Init(object sender, System.EventArgs e)
		{
			SuporteWeb.SuporteUsuários.RecuperarUsuário(this);

			gráfico = new Estatística.Db.Gráfico();
			gráfico.CarregarDefinições(ObterDefinições());

			foreach (string referência in gráfico.Gráficos)
			{
				string título = gráfico.ObterTítulo(referência);

				radioTítulo.Items.Add(new ListItem(título, referência));
			}

			períodoInicial.SelectedDate = períodoFinal.SelectedDate = DateTime.Now;

			setor.DataSource = Entidades.Setor.ObterSetoresAtendimentoDataSet();
			setor.DataValueField = "codigo";
			setor.DataTextField = "nome";
			setor.DataBind();
		}

		/// <summary>
		/// Ocorre quando escolhe-se um título
		/// </summary>
		private void radioTítulo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.radioTítulo.Visible = false;
			this.lblTítulo.Text = radioTítulo.SelectedItem.Text;
			painelPeríodo.Visible = false;
			painelSetor.Visible = false;
			painelEnvio.Visible = true;

			foreach (string s in gráfico.ObterRequisitos(radioTítulo.SelectedValue))
			{
				if (string.Compare("período", s, true) == 0)
					painelPeríodo.Visible = true;
				else if (string.Compare("setor", s, true) == 0)
					painelSetor.Visible = true;
			}
		}
	}
}
