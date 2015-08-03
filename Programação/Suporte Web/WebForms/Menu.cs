using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace SuporteWeb.WebForms
{
	/// <summary>
	/// Menu com ícone
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Menu runat=server></{0}:Menu>")]
	public class Menu : System.Web.UI.WebControls.WebControl
	{
		private string	título;
		private string	descrição;
		private string	link;
		private string	ícone;
	
		#region Propriedades

		public string Título
		{
			get { return título; }
			set { título = value; }
		}

		public string Descrição
		{
			get { return descrição; }
			set { descrição = value; }
		}

		public string Link
		{
			get { return link; }
			set { link = value; }
		}

		public string Ícone
		{
			get { return ícone; }
			set { ícone = value; }
		}

		#endregion

		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{
 			output.Write("<div class='menuDireita'>\n"); // onClick='open(\"" + link + "\")'>\n");
			output.Write("<table border=0 cellpadding=0 cellspacing=0>\n");
			output.Write("<tr>\n");
			output.Write("<td>\n");
			output.Write("<a href=\"" + link + "\"><img class='menuDireitaIcone' src='" + ícone + "' align=absmiddle border=0></a>\n");
			output.Write("</td>\n");
			output.Write("<td width=5px></td>\n");
			output.Write("<td>\n");
			output.Write("<a class='menuDireitaTitulo' href=\"" + link + "\">" + título + "</a><br/>\n");
			output.Write("<a class='menuDireitaDescricao' href=\"" + link + "\">" + descrição + "</a>\n");
			output.Write("</td>\n");
			output.Write("</tr>\n");
			output.Write("</table>\n");
			output.Write("</div>&nbsp;");
		}
	}
}
