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
	/// Summary description for atendimentosMensais.
	/// </summary>
	public class atendimentosMensais : System.Web.UI.Page
	{
		protected long setor;
		protected System.Web.UI.WebControls.Label lblSetor;
		protected Relatório.Graficos.Gráfico gráfico;
	
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

			DateTime períodoInicial;
			DateTime períodoFinal;

			SuporteWeb.SuporteUsuários.RecuperarUsuário(this);

			setor = long.Parse(this.Request.QueryString["setor"]);
			lblSetor.Text = Entidades.Setor.ObterSetorNome(setor);
			
			SuporteUsuários.RegistrarUtilização(this, Entidades.Log.Aplicações.RelatórioRecepção, "setor = " + lblSetor.Text);

			períodoInicial = DateTime.Now.Subtract(new TimeSpan(30 * 7, 0, 0, 0));
			períodoFinal = períodoInicial.AddMonths(6);

			gráfico.Setor = setor;
			gráfico.PeríodoInicial = períodoInicial;
			gráfico.PeríodoFinal = períodoFinal;
			/*
						legenda.Requisitos.Add("periodoInicial", períodoInicial.ToString("yyyy-MM-dd"));
						legenda.Requisitos.Add("periodoFinal", períodoFinal.ToString("yyyy-MM-dd"));
						legenda.Requisitos.Add("setor", setor.ToString());
			*/

		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
	}
}
