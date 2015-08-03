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

namespace Relat�rio.Recepcao
{
	/// <summary>
	/// Summary description for atendimentosMensais.
	/// </summary>
	public class atendimentosMensais : System.Web.UI.Page
	{
		protected long setor;
		protected System.Web.UI.WebControls.Label lblSetor;
		protected Relat�rio.Graficos.Gr�fico gr�fico;
	
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

			DateTime per�odoInicial;
			DateTime per�odoFinal;

			SuporteWeb.SuporteUsu�rios.RecuperarUsu�rio(this);

			setor = long.Parse(this.Request.QueryString["setor"]);
			lblSetor.Text = Entidades.Setor.ObterSetorNome(setor);
			
			SuporteUsu�rios.RegistrarUtiliza��o(this, Entidades.Log.Aplica��es.Relat�rioRecep��o, "setor = " + lblSetor.Text);

			per�odoInicial = DateTime.Now.Subtract(new TimeSpan(30 * 7, 0, 0, 0));
			per�odoFinal = per�odoInicial.AddMonths(6);

			gr�fico.Setor = setor;
			gr�fico.Per�odoInicial = per�odoInicial;
			gr�fico.Per�odoFinal = per�odoFinal;
			/*
						legenda.Requisitos.Add("periodoInicial", per�odoInicial.ToString("yyyy-MM-dd"));
						legenda.Requisitos.Add("periodoFinal", per�odoFinal.ToString("yyyy-MM-dd"));
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
