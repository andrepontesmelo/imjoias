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
	/// Summary description for Status.
	/// </summary>
	public class Status : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgEspera;
		protected System.Web.UI.WebControls.Label lblInfoEspera;
		protected System.Web.UI.WebControls.Label lblInfoAtendimentos;
		protected System.Web.UI.WebControls.DataGrid dgAtendimentos;

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
			
			PreencherTabelaUsu�riosEsperando();
			PreencherTabelaUsu�riosAtendimentos();
			SuporteUsu�rios.RegistrarUtiliza��o(this, Entidades.Log.Aplica��es.StatusRecep��o);
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

		private void PreencherTabelaUsu�riosEsperando()
		{
			int pessoasEsperando;
			DataSet ds;

			ds = Entidades.Visita.ObterVisitantesEsperandoAtendimento();
			dgEspera.DataSource = ds;
			dgEspera.DataBind();
			pessoasEsperando = ds.Tables[0].Rows.Count;
			if (pessoasEsperando == 0) 
			{
				lblInfoEspera.Text = "N�o existem visitantes em espera na recep��o";
				dgEspera.Visible = false;
			} 
			else
			{
				lblInfoEspera.Text = "Existem " + pessoasEsperando + " pessoas esperando por atendimento";
				dgEspera.Visible = true;
			}
		}
		private void PreencherTabelaUsu�riosAtendimentos()
		{
			int qtdAtendimentos;
			DataSet ds;

			ds = Entidades.Visita.ObterVisitantesEmAtendimento();
			dgAtendimentos.DataSource = ds;
			dgAtendimentos.DataBind();
			qtdAtendimentos = ds.Tables[0].Rows.Count;

			if (qtdAtendimentos == 0)
			{
				lblInfoAtendimentos.Text = "N�o existem visitantes em atendimento";
				dgAtendimentos.Visible = false;
			} 
			else
			{
				lblInfoAtendimentos.Text = "Existem " + qtdAtendimentos + " pessoas em atendimento";
				dgAtendimentos.Visible = true;
			}
			
		}


	}
}
