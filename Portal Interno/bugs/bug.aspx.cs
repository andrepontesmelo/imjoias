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

namespace bugs
{
	/// <summary>
	/// Summary description for bug.
	/// </summary>
	public class bug : System.Web.UI.Page
	{
		private ByteFX.Data.MySqlClient.MySqlConnection mySql;
		private MySqlDataReader leitor;

		private void Page_Load(object sender, System.EventArgs e)
		{
			mySql = new MySqlConnection();
			mySql.ConnectionString = 
				"Data Source=localhost"
				+ ";Database=imjoias"
				+ ";User Id=bug"
				+ ";Password=bugzzie";

			mySql.Open();
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


		protected void Detalhar(string código)
		{
			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = mySql;
			cmd.CommandText = "SELECT * FROM bug WHERE codigo = " + código.Trim();

			// Lê os dados
			leitor = cmd.ExecuteReader();

			while (leitor.Read())
			{
				this.Response.Write("<table>");
				
				for (int i = 0; i < leitor.FieldCount; i++)
				{
					this.Response.Write("<tr>");
					this.Response.Write("<td valign=top><b>" + leitor.GetName(i) + ":</b></td>");
					this.Response.Write("<td valign=top style=\"FONT-SIZE: 10pt; FONT-FAMILY: 'Monospace'\">" + leitor.GetString(i) + "</td>");
					this.Response.Write("</tr>");
				}

				this.Response.Write("</table>");
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
