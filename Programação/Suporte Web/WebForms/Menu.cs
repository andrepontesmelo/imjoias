using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace SuporteWeb.WebForms
{
	/// <summary>
	/// Menu com �cone
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Menu runat=server></{0}:Menu>")]
	public class Menu : System.Web.UI.WebControls.WebControl
	{
		private string	t�tulo;
		private string	descri��o;
		private string	link;
		private string	�cone;
	
		#region Propriedades

		public string T�tulo
		{
			get { return t�tulo; }
			set { t�tulo = value; }
		}

		public string Descri��o
		{
			get { return descri��o; }
			set { descri��o = value; }
		}

		public string Link
		{
			get { return link; }
			set { link = value; }
		}

		public string �cone
		{
			get { return �cone; }
			set { �cone = value; }
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
			output.Write("<a href=\"" + link + "\"><img class='menuDireitaIcone' src='" + �cone + "' align=absmiddle border=0></a>\n");
			output.Write("</td>\n");
			output.Write("<td width=5px></td>\n");
			output.Write("<td>\n");
			output.Write("<a class='menuDireitaTitulo' href=\"" + link + "\">" + t�tulo + "</a><br/>\n");
			output.Write("<a class='menuDireitaDescricao' href=\"" + link + "\">" + descri��o + "</a>\n");
			output.Write("</td>\n");
			output.Write("</tr>\n");
			output.Write("</table>\n");
			output.Write("</div>&nbsp;");
		}
	}
}
