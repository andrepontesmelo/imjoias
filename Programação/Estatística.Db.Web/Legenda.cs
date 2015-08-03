using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;

namespace Estatística.Db.Web
{
	[ToolboxData("<{0}:Legenda runat=server></{0}:Legenda>")]
	public abstract class Legenda : System.Web.UI.WebControls.WebControl
	{
		private string	referência;
		private int		itemLargura = 50;
		private Gráfico.ListaRequisitos requisitos = new Estatística.Db.Web.Gráfico.ListaRequisitos();
		private IDbConnection conexão;

		protected abstract System.IO.Stream ObterDefinições();

		private void ObterParâmetros(IDbCommand cmd)
		{
			for (int i = 0; i < this.Requisitos.Count; i++)
			{
				IDataParameter parâmetro;

				parâmetro = cmd.CreateParameter();
				parâmetro.ParameterName = Requisitos[i].Chave;
				parâmetro.Value = Requisitos[i].Valor;
				cmd.Parameters.Add(parâmetro);
			}
		}

		public IDbConnection Conexão
		{
			get { return conexão; }
			set { conexão = value; }
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
			Estatística.Db.Gráfico	gráfico;
			MemoryStream			memStream = new MemoryStream();
			Hashtable				propriedades;
			string []				legenda;
			IDbCommand              cmd;

			propriedades = Estatística.Desenhista.ObterPropriedades();
			propriedades["limparFundo"] = Brushes.White;

			gráfico = new Estatística.Db.Gráfico();
			gráfico.CarregarDefinições(ObterDefinições());

			cmd = Conexão.CreateCommand();
			
			ObterParâmetros(cmd);

			legenda = gráfico.ObterLegendas(cmd, referência);

			output.WriteLine("<table border=0 cellspacing=2px cellpadding=0>");

			// Desenhar legenda
			for (int i = 0; i < legenda.Length; i++)
			{
				Pen pen = (Pen) propriedades["vérticePen" + i.ToString()];

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
		/// Referência do gráfico
		/// </summary>
		public string Referência
		{
			get { return referência; }
			set { referência = value; }
		}

		/// <summary>
		/// Largura de cada item
		/// </summary>
		public int ItemLargura
		{
			get { return itemLargura; }
			set { itemLargura = value; }
		}

		public Gráfico.ListaRequisitos Requisitos
		{
			get { return requisitos; }
			set { requisitos = value; }
		}
	}
}
