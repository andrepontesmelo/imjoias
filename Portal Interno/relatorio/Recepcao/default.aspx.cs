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

namespace Relat�rio.Recep��o
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblT�tulo;
		protected System.Web.UI.WebControls.Calendar per�odoInicial;
		protected System.Web.UI.WebControls.Calendar per�odoFinal;
		protected System.Web.UI.WebControls.DropDownList cmbSetor;
		protected System.Web.UI.WebControls.Button cmdGerarRelat�rio;
		protected System.Web.UI.WebControls.Label lblResumo;
		protected System.Web.UI.WebControls.DataGrid dataGrid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			SuporteUsu�rios.RecuperarUsu�rio(this);

			this.cmbSetor.DataSource = Entidades.Setor.ObterSetoresAtendimentoDataSet().Tables[0];
			this.cmbSetor.DataValueField = "codigo";
			this.cmbSetor.DataTextField = "nome";
			this.cmbSetor.DataBind();

			per�odoInicial.SelectedDate = DateTime.Now;
			per�odoFinal.SelectedDate = DateTime.Now;
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.per�odoInicial.SelectionChanged += new System.EventHandler(this.LimparDados);
			this.per�odoFinal.SelectionChanged += new System.EventHandler(this.LimparDados);
			this.cmbSetor.SelectedIndexChanged += new System.EventHandler(this.LimparDados);
			this.cmdGerarRelat�rio.Click += new System.EventHandler(this.cmdGerarRelat�rio_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Ocorre ao clicar em gerar relat�rio
		/// </summary>
		private void cmdGerarRelat�rio_Click(object sender, System.EventArgs e)
		{
			DateTime pInicial, pFinal;
			DataSet dataset;

			pInicial = this.per�odoInicial.SelectedDate;
			pFinal   = this.per�odoFinal.SelectedDate.AddDays(1);

			dataset = Entidades.Visita.ObterVisitas(pInicial, pFinal, long.Parse(this.cmbSetor.SelectedValue));

			dataGrid.DataSource = dataset.Tables[0];
			dataGrid.DataBind();

			dataGrid.Visible = true;

			lblT�tulo.Text = "Visitantes do setor " + cmbSetor.SelectedItem.Text + " no per�odo de " + pInicial.ToShortDateString() + " a " + pFinal.ToShortDateString();
			lblT�tulo.Visible = true;

			lblResumo.Text = dataset.Tables[0].Rows.Count + " entradas registradas";
			lblResumo.Visible = true;

			SuporteUsu�rios.RegistrarUtiliza��o(this, Entidades.Log.Aplica��es.Relat�rioRecep��o,
                "Per�odo inicial: " + pInicial.ToString() + "\n"
				+ "Per�odo final: " + pFinal.ToString() + "\n"
				+ "Setor: " + cmbSetor.SelectedItem.Text);
		}

		/// <summary>
		/// Limpa dados do formul�rio
		/// </summary>
		private void LimparDados(object sender, System.EventArgs e)
		{
			lblT�tulo.Visible = false;
			lblResumo.Visible = false;
			dataGrid.Visible = false;
			dataGrid.DataSource = null;
		}
	}
}
