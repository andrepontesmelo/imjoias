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

namespace Relat�rio
{
	/// <summary>
	/// Summary description for Resumo.
	/// </summary>
	public class Resumo : System.Web.UI.Page
	{
		private long setor;
		private DateTime pInicial, pFinal;

		protected Relat�rio.Graficos.Legenda legendaPA;
		protected Relat�rio.Graficos.Gr�fico gr�ficoPA;
		protected System.Web.UI.WebControls.Label lblSetor;
		protected Relat�rio.Graficos.Gr�fico gr�ficoEspera;
		protected System.Web.UI.WebControls.DataGrid dataGrid;
		protected System.Web.UI.WebControls.Label lblPer�odo;

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

			SuporteWeb.SuporteUsu�rios.RecuperarUsu�rio(this);
/*			
			setor = usr.DbIMJoias.ObterSetorC�digo(
				Request.Cookies["Setor"] == null ? "Varejo" : this.Request.Cookies["Setor"].Value);

			lblSetor.Text = Request.Cookies["Setor"] == null ? "Varejo" : Request.Cookies["Setor"].Value;

			if (setor < 0)
			{
				setor = usr.DbIMJoias.ObterSetorC�digo("Varejo");
				lblSetor.Text = "Varejo";
			}
*/			
			setor = int.Parse(Request.QueryString["setor"]);

			lblSetor.Text = Entidades.Setor.ObterSetorNome(setor);

			SuporteUsu�rios.RegistrarUtiliza��o(this, Entidades.Log.Aplica��es.Relat�rioRecep��o, "setor = " + lblSetor.Text);

			gr�ficoPA.Setor = setor;
			gr�ficoEspera.Setor = setor;

			MostrarM�sAnterior();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}

		/// <summary>
		/// Mostra relat�rio do m�s anterior
		/// </summary>
		protected void MostrarM�sAnterior()
		{
			lblPer�odo.Text = "M�s Anterior";

			pInicial = new DateTime(
				DateTime.Now.Year - (DateTime.Now.Month == 1 ? 1 : 0),
				DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1,
				1);

			pFinal = pInicial.AddMonths(1);

			// Gr�fico PA
			gr�ficoPA.Per�odoInicial = pInicial;
			gr�ficoPA.Per�odoFinal = pFinal;
			AdequarLegenda(legendaPA, gr�ficoPA);

			// Gr�fico Espera
			gr�ficoEspera.Per�odoInicial = gr�ficoPA.Per�odoInicial;
			gr�ficoEspera.Per�odoFinal = gr�ficoPA.Per�odoFinal;

			MostrarDados();
		}

		private void AdequarLegenda(Relat�rio.Graficos.Legenda legenda, Relat�rio.Graficos.Gr�fico gr�fico)
		{
			legenda.Requisitos.Clear();
			legenda.Requisitos.Add("setor", setor.ToString());
			legenda.Requisitos.Add("periodoInicial", gr�fico.Per�odoInicial.ToString("yyyy-MM-dd"));
			legenda.Requisitos.Add("periodoFinal", gr�fico.Per�odoFinal.ToString("yyyy-MM-dd"));
			legenda.Conex�o = SuporteUsu�rios.ObterUsu�rioAtual(this).Conex�o;
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
