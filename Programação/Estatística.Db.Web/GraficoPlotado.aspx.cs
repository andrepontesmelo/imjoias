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
using System.IO;
using Estat�stica;

namespace Estat�stica.Db.Web
{
	/// <summary>
	/// Constr�i um gr�fico a partir da query string:
	/// 
	/// Par�metros:
	/// 
	/// ref				Refer�ncia do gr�fico
	/// largura			Largura doa imagem
	/// altura			Altura da imagem
	/// 
	/// Demais par�metros s�o repassados �s consultas
	/// </summary>
	public abstract class GraficoPlotado : System.Web.UI.Page
	{
		protected abstract System.IO.Stream ObterDefini��es();

		protected abstract IDbConnection ObterConex�o();

		private void ObterPar�metros(IDbCommand cmd)
		{
			for (int i = 0; i < this.Request.QueryString.Count; i++)
			{
				IDataParameter par�metro;

				par�metro               = cmd.CreateParameter();
				par�metro.ParameterName = Request.QueryString.GetKey(i);
				par�metro.Value         = Request.QueryString[i];
				cmd.Parameters.Add(par�metro);
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Estat�stica.Db.Gr�fico	gr�fico;
			Desenhista				desenhista = new Desenhista();
			MemoryStream			memStream = new MemoryStream();
			Bitmap					bmp;
			Hashtable				propriedades;
			IDbCommand              cmd;
//			string []				legenda;

			gr�fico = new Estat�stica.Db.Gr�fico();
			gr�fico.CarregarDefini��es(ObterDefini��es());

			cmd = ObterConex�o().CreateCommand();
			ObterPar�metros(cmd);

			gr�fico.ConfigurarGr�fico(cmd, Request.QueryString["ref"].Replace("\t", ""), desenhista);

			propriedades = Estat�stica.Desenhista.ObterPropriedades();
			propriedades["limparFundo"] = Brushes.White;

			bmp = desenhista.Desenhar(
				int.Parse(Request.QueryString["largura"]),
				int.Parse(Request.QueryString["altura"]),
				propriedades);

			bmp.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);

			Response.Clear();
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "image/jpeg";
			Response.BinaryWrite(memStream.ToArray());
			Response.End();
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
