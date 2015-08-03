using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using SuporteWeb;

namespace Relatório.Graficos
{
	/// <summary>
	/// Summary description for Legenda.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Legenda runat=server></{0}:Legenda>")]
	public class Legenda : Estatística.Db.Web.Legenda
	{
		protected override System.IO.Stream ObterDefinições()
		{
			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			
			string [] resources = thisExe.GetManifestResourceNames();
			string list = "";

			// Build the string of resources.
			foreach (string resource in resources)
				list += resource + "\r\n";

			System.IO.Stream file = 
				thisExe.GetManifestResourceStream("Relatório.Graficos.definicoes.xml");

			return file;
		}
	}
}
