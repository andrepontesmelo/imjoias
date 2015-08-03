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

namespace Relatório
{
	public class Visitantes : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
//			MemoryStream memStream = new MemoryStream();
//			Desenhista	 desenhista = new Desenhista();
//			Bitmap		 bmp;
//			string []	 legenda;
//
//			desenhista.Dados = IMJóias.AnáliseEstatística.Visitantes.ObterVisitantesDiáriosSetor(
//				(IDbConnection) Session["conexão"],
//				DateTime.Now.Date.AddDays(-14),
//				DateTime.Now, out legenda);
//
//			desenhista.EixoX = "Dias";
//			desenhista.EixoY = "Visitas";
//			
//			bmp = desenhista.Desenhar(
//				int.Parse(Request.QueryString["largura"]),
//				int.Parse(Request.QueryString["altura"]),
//				Estatística.Desenhista.ObterPropriedades());
//			bmp.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);			
//
//			Response.Clear();
//			Response.Cache.SetCacheability(HttpCacheability.NoCache);
//			Response.ContentType = "image/png";
//			Response.BinaryWrite(memStream.ToArray());
//			Response.End();
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
