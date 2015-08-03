using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using SuporteWeb;

namespace Relat�rio.Graficos
{
	/// <summary>
	/// Summary description for Legenda.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Legenda runat=server></{0}:Legenda>")]
	public class Legenda : Estat�stica.Db.Web.Legenda
	{
		protected override System.IO.Stream ObterDefini��es()
		{
			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			
			string [] resources = thisExe.GetManifestResourceNames();
			string list = "";

			// Build the string of resources.
			foreach (string resource in resources)
				list += resource + "\r\n";

			System.IO.Stream file = 
				thisExe.GetManifestResourceStream("Relat�rio.Graficos.definicoes.xml");

			return file;
		}
	}
}
