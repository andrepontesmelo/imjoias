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

namespace Relat�rio.Graficos
{
	/// <summary>
	/// Summary description for Plotar.
	/// </summary>
	public class Plotar : Estat�stica.Db.Web.GraficoPlotado
	{
		protected override System.IO.Stream ObterDefini��es()
		{
			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();

			System.IO.Stream file = 
				thisExe.GetManifestResourceStream("Relat�rio.Graficos.definicoes.xml");

			return file;
		}

		protected override IDbConnection ObterConex�o()
		{
			return SuporteUsu�rios.ObterUsu�rioAtual(this).Conex�o;
		}

		protected override void OnLoad(EventArgs e)
		{
			string l = Request.QueryString["l"];

			if (l == null || l != "n")
			{
				string   par�metros = "";

				for (int i = 0; i < this.Request.QueryString.Count; i++)
					par�metros += Request.QueryString.GetKey(i) + " = " + Request.QueryString[i] + "\n";

				SuporteUsu�rios.RegistrarUtiliza��o(this, Entidades.Log.Aplica��es.Relat�rioConstrutorGr�ficos, par�metros);
			}

			base.OnLoad (e);
		}

		protected override void OnInit(EventArgs e)
		{
			SuporteWeb.SuporteUsu�rios.RecuperarUsu�rio(this);

			base.OnInit (e);
		}

	}
}
