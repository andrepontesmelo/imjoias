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

namespace Relatório.Graficos
{
	/// <summary>
	/// Summary description for Plotar.
	/// </summary>
	public class Plotar : Estatística.Db.Web.GraficoPlotado
	{
		protected override System.IO.Stream ObterDefinições()
		{
			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();

			System.IO.Stream file = 
				thisExe.GetManifestResourceStream("Relatório.Graficos.definicoes.xml");

			return file;
		}

		protected override IDbConnection ObterConexão()
		{
			return SuporteUsuários.ObterUsuárioAtual(this).Conexão;
		}

		protected override void OnLoad(EventArgs e)
		{
			string l = Request.QueryString["l"];

			if (l == null || l != "n")
			{
				string   parâmetros = "";

				for (int i = 0; i < this.Request.QueryString.Count; i++)
					parâmetros += Request.QueryString.GetKey(i) + " = " + Request.QueryString[i] + "\n";

				SuporteUsuários.RegistrarUtilização(this, Entidades.Log.Aplicações.RelatórioConstrutorGráficos, parâmetros);
			}

			base.OnLoad (e);
		}

		protected override void OnInit(EventArgs e)
		{
			SuporteWeb.SuporteUsuários.RecuperarUsuário(this);

			base.OnInit (e);
		}

	}
}
