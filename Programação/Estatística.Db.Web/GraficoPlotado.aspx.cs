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
using Estatística;

namespace Estatística.Db.Web
{
	/// <summary>
	/// Constrói um gráfico a partir da query string:
	/// 
	/// Parâmetros:
	/// 
	/// ref				Referência do gráfico
	/// largura			Largura doa imagem
	/// altura			Altura da imagem
	/// 
	/// Demais parâmetros são repassados às consultas
	/// </summary>
	public abstract class GraficoPlotado : System.Web.UI.Page
	{
		protected abstract System.IO.Stream ObterDefinições();

		protected abstract IDbConnection ObterConexão();

		private void ObterParâmetros(IDbCommand cmd)
		{
			for (int i = 0; i < this.Request.QueryString.Count; i++)
			{
				IDataParameter parâmetro;

				parâmetro               = cmd.CreateParameter();
				parâmetro.ParameterName = Request.QueryString.GetKey(i);
				parâmetro.Value         = Request.QueryString[i];
				cmd.Parameters.Add(parâmetro);
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Estatística.Db.Gráfico	gráfico;
			Desenhista				desenhista = new Desenhista();
			MemoryStream			memStream = new MemoryStream();
			Bitmap					bmp;
			Hashtable				propriedades;
			IDbCommand              cmd;
//			string []				legenda;

			gráfico = new Estatística.Db.Gráfico();
			gráfico.CarregarDefinições(ObterDefinições());

			cmd = ObterConexão().CreateCommand();
			ObterParâmetros(cmd);

			gráfico.ConfigurarGráfico(cmd, Request.QueryString["ref"].Replace("\t", ""), desenhista);

			propriedades = Estatística.Desenhista.ObterPropriedades();
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
