using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;

namespace Estat�stica.Db.Web
{
	[ToolboxData("<{0}:Legenda runat=server></{0}:Legenda>")]
	public abstract class Legenda : System.Web.UI.WebControls.WebControl
	{
		private string	refer�ncia;
		private int		itemLargura = 50;
		private Gr�fico.ListaRequisitos requisitos = new Estat�stica.Db.Web.Gr�fico.ListaRequisitos();
		private IDbConnection conex�o;

		protected abstract System.IO.Stream ObterDefini��es();

		private void ObterPar�metros(IDbCommand cmd)
		{
			for (int i = 0; i < this.Requisitos.Count; i++)
			{
				IDataParameter par�metro;

				par�metro = cmd.CreateParameter();
				par�metro.ParameterName = Requisitos[i].Chave;
				par�metro.Value = Requisitos[i].Valor;
				cmd.Parameters.Add(par�metro);
			}
		}

		public IDbConnection Conex�o
		{
			get { return conex�o; }
			set { conex�o = value; }
		}


		public Legenda() : base(HtmlTextWriterTag.Div)
		{
			Style estilo;

			estilo = new Style();
			estilo.BackColor = Color.FromArgb(200, 240, 248, 255);
			estilo.BorderColor = Color.LightSteelBlue;
			estilo.BorderStyle = BorderStyle.Solid;
			estilo.BorderWidth = 1;
			estilo.Font.Name = "Arial";
			estilo.Font.Size = 10;
			estilo.Font.Bold = false;
			estilo.Width = Width;

			this.ApplyStyle(estilo);
		}

		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		//protected override void Render(HtmlTextWriter output)
		protected override void RenderContents(HtmlTextWriter output)
		{
			Estat�stica.Db.Gr�fico	gr�fico;
			MemoryStream			memStream = new MemoryStream();
			Hashtable				propriedades;
			string []				legenda;
			IDbCommand              cmd;

			propriedades = Estat�stica.Desenhista.ObterPropriedades();
			propriedades["limparFundo"] = Brushes.White;

			gr�fico = new Estat�stica.Db.Gr�fico();
			gr�fico.CarregarDefini��es(ObterDefini��es());

			cmd = Conex�o.CreateCommand();
			
			ObterPar�metros(cmd);

			legenda = gr�fico.ObterLegendas(cmd, refer�ncia);

			output.WriteLine("<table border=0 cellspacing=2px cellpadding=0>");

			// Desenhar legenda
			for (int i = 0; i < legenda.Length; i++)
			{
				Pen pen = (Pen) propriedades["v�rticePen" + i.ToString()];

				output.WriteLine("<tr>");
				output.WriteLine("<td style='background-color: "
					+ "#" + pen.Color.R.ToString("X2")
					+ pen.Color.G.ToString("X2")
					+ pen.Color.B.ToString("X2")
					+ "; font-family: sans-serif; font-size: 12px'>::</td>");

				output.WriteLine("<td style='color: "
					+ "#" + pen.Color.R.ToString("X2")
					+ pen.Color.G.ToString("X2")
					+ pen.Color.B.ToString("X2")
					+ "; font-family: sans-serif; font-size: 12px'>" + legenda[i] + "</td>");

				output.WriteLine("</tr>");
			}

			output.WriteLine("</table>");
		}

		/// <summary>
		/// Refer�ncia do gr�fico
		/// </summary>
		public string Refer�ncia
		{
			get { return refer�ncia; }
			set { refer�ncia = value; }
		}

		/// <summary>
		/// Largura de cada item
		/// </summary>
		public int ItemLargura
		{
			get { return itemLargura; }
			set { itemLargura = value; }
		}

		public Gr�fico.ListaRequisitos Requisitos
		{
			get { return requisitos; }
			set { requisitos = value; }
		}
	}
}
