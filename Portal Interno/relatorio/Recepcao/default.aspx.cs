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

namespace Relatório.Recepção
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTítulo;
		protected System.Web.UI.WebControls.Calendar períodoInicial;
		protected System.Web.UI.WebControls.Calendar períodoFinal;
		protected System.Web.UI.WebControls.DropDownList cmbSetor;
		protected System.Web.UI.WebControls.Button cmdGerarRelatório;
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

			SuporteUsuários.RecuperarUsuário(this);

			this.cmbSetor.DataSource = Entidades.Setor.ObterSetoresAtendimentoDataSet().Tables[0];
			this.cmbSetor.DataValueField = "codigo";
			this.cmbSetor.DataTextField = "nome";
			this.cmbSetor.DataBind();

			períodoInicial.SelectedDate = DateTime.Now;
			períodoFinal.SelectedDate = DateTime.Now;
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.períodoInicial.SelectionChanged += new System.EventHandler(this.LimparDados);
			this.períodoFinal.SelectionChanged += new System.EventHandler(this.LimparDados);
			this.cmbSetor.SelectedIndexChanged += new System.EventHandler(this.LimparDados);
			this.cmdGerarRelatório.Click += new System.EventHandler(this.cmdGerarRelatório_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Ocorre ao clicar em gerar relatório
		/// </summary>
		private void cmdGerarRelatório_Click(object sender, System.EventArgs e)
		{
			DateTime pInicial, pFinal;
			DataSet dataset;

			pInicial = this.períodoInicial.SelectedDate;
			pFinal   = this.períodoFinal.SelectedDate.AddDays(1);

			dataset = Entidades.Visita.ObterVisitas(pInicial, pFinal, long.Parse(this.cmbSetor.SelectedValue));

			dataGrid.DataSource = dataset.Tables[0];
			dataGrid.DataBind();

			dataGrid.Visible = true;

			lblTítulo.Text = "Visitantes do setor " + cmbSetor.SelectedItem.Text + " no período de " + pInicial.ToShortDateString() + " a " + pFinal.ToShortDateString();
			lblTítulo.Visible = true;

			lblResumo.Text = dataset.Tables[0].Rows.Count + " entradas registradas";
			lblResumo.Visible = true;

			SuporteUsuários.RegistrarUtilização(this, Entidades.Log.Aplicações.RelatórioRecepção,
                "Período inicial: " + pInicial.ToString() + "\n"
				+ "Período final: " + pFinal.ToString() + "\n"
				+ "Setor: " + cmbSetor.SelectedItem.Text);
		}

		/// <summary>
		/// Limpa dados do formulário
		/// </summary>
		private void LimparDados(object sender, System.EventArgs e)
		{
			lblTítulo.Visible = false;
			lblResumo.Visible = false;
			dataGrid.Visible = false;
			dataGrid.DataSource = null;
		}
	}
}
