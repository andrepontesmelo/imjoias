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

namespace Relatório
{
	/// <summary>
	/// Summary description for Resumo.
	/// </summary>
	public class Resumo : System.Web.UI.Page
	{
		private long setor;
		private DateTime pInicial, pFinal;

		protected Relatório.Graficos.Legenda legendaPA;
		protected Relatório.Graficos.Gráfico gráficoPA;
		protected System.Web.UI.WebControls.Label lblSetor;
		protected Relatório.Graficos.Gráfico gráficoEspera;
		protected System.Web.UI.WebControls.DataGrid dataGrid;
		protected System.Web.UI.WebControls.Label lblPeríodo;

		public Resumo()
		{
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			SuporteWeb.SuporteUsuários.RecuperarUsuário(this);
/*			
			setor = usr.DbIMJoias.ObterSetorCódigo(
				Request.Cookies["Setor"] == null ? "Varejo" : this.Request.Cookies["Setor"].Value);

			lblSetor.Text = Request.Cookies["Setor"] == null ? "Varejo" : Request.Cookies["Setor"].Value;

			if (setor < 0)
			{
				setor = usr.DbIMJoias.ObterSetorCódigo("Varejo");
				lblSetor.Text = "Varejo";
			}
*/			
			setor = int.Parse(Request.QueryString["setor"]);

			lblSetor.Text = Entidades.Setor.ObterSetorNome(setor);

			SuporteUsuários.RegistrarUtilização(this, Entidades.Log.Aplicações.RelatórioRecepção, "setor = " + lblSetor.Text);

			gráficoPA.Setor = setor;
			gráficoEspera.Setor = setor;

			MostrarMêsAnterior();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}

		/// <summary>
		/// Mostra relatório do mês anterior
		/// </summary>
		protected void MostrarMêsAnterior()
		{
			lblPeríodo.Text = "Mês Anterior";

			pInicial = new DateTime(
				DateTime.Now.Year - (DateTime.Now.Month == 1 ? 1 : 0),
				DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1,
				1);

			pFinal = pInicial.AddMonths(1);

			// Gráfico PA
			gráficoPA.PeríodoInicial = pInicial;
			gráficoPA.PeríodoFinal = pFinal;
			AdequarLegenda(legendaPA, gráficoPA);

			// Gráfico Espera
			gráficoEspera.PeríodoInicial = gráficoPA.PeríodoInicial;
			gráficoEspera.PeríodoFinal = gráficoPA.PeríodoFinal;

			MostrarDados();
		}

		private void AdequarLegenda(Relatório.Graficos.Legenda legenda, Relatório.Graficos.Gráfico gráfico)
		{
			legenda.Requisitos.Clear();
			legenda.Requisitos.Add("setor", setor.ToString());
			legenda.Requisitos.Add("periodoInicial", gráfico.PeríodoInicial.ToString("yyyy-MM-dd"));
			legenda.Requisitos.Add("periodoFinal", gráfico.PeríodoFinal.ToString("yyyy-MM-dd"));
			legenda.Conexão = SuporteUsuários.ObterUsuárioAtual(this).Conexão;
		}

		private void MostrarDados()
		{
			DataSet dataset;

			dataset = Entidades.Visita.ObterVisitas(pInicial, pFinal, setor);

			dataGrid.DataSource = dataset.Tables[0];
			dataGrid.DataBind();
		}
	}
}
