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
using ByteFX.Data.MySqlClient;
using ByteFX.Data.Common;

namespace bugs
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class Relatório : System.Web.UI.Page
	{
		private ByteFX.Data.MySqlClient.MySqlConnection mySql;
		private MySqlDataReader leitor;
		private System.ComponentModel.IContainer components;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			mySql = new MySqlConnection();
			mySql.ConnectionString = 
				"Data Source=localhost"
				+ ";Database=imjoias"
				+ ";User Id=bug"
				+ ";Password=bugzzie";

			mySql.Open();

			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = mySql;
			cmd.CommandText = "SELECT codigo, ultimaData, ocorrencias, source, message FROM bug WHERE corrigido = 0 ORDER BY ultimaData DESC";

			// Lê os dados
			leitor = cmd.ExecuteReader();
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

		protected void MostrarLinhas()
		{
			this.Response.Write("<tr>");

			for (int i = 0; i < leitor.FieldCount; i++)
				this.Response.Write("<td>" + leitor.GetName(i) + "</td>");

			this.Response.Write("</tr>");

			while (leitor.Read())
			{
				this.Response.Write("<tr valign=top>");
				
				for (int i = 0; i < leitor.FieldCount; i++)
					this.Response.Write("<td style=\"FONT-SIZE: 10pt; FONT-FAMILY: 'Sans Serif'\"><a href='bug.aspx?codigo=" + leitor.GetString(0) + "'>" + leitor.GetString(i) + "</a></td>");

				this.Response.Write("</tr>");
			}

			leitor.Close();
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload (e);

			mySql.Close();
		}

	}
}
