using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Relatório.Graficos
{
	/// <summary>
	/// Summary description for Gráfico.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Gráfico runat=server></{0}:Gráfico>")]
	public class Gráfico : System.Web.UI.WebControls.WebControl
	{
		private long		setor;
		private string		referência;
		private DateTime	períodoInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
		private DateTime	períodoFinal = DateTime.Now;
		private int			largura = 480;
		private int			altura = 240;
		private string		plotter = "Graficos/Plotar.aspx";


		protected System.Web.UI.HtmlControls.HtmlGenericControl P1;

		protected Relatório.Graficos.Legenda legenda;

		public Gráfico() : base(HtmlTextWriterTag.Img)
		{
		}

		protected override void Render(HtmlTextWriter writer)
		{
			writer.Write("<IMG src=\"" + Plotter + "?{0}\">", QueryString);
		}

/*		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				Usuários usrs = (Usuários) Page.Application["usuários"];
				Usuário  usr  = usrs[Page.User.Identity.Name];

				legenda.Conexão = usr.Conexão;
				legenda.Referência = referência;
			
				legenda.Requisitos.Add("periodoInicial", períodoInicial.ToString());
				legenda.Requisitos.Add("periodoFinal", períodoFinal.ToString());
				legenda.Requisitos.Add("setor", setor.ToString());
			}
			catch
			{
			}
		}
*/

		public string Referência
		{
			get { return referência; }
			set { referência = value; }
		}

		public DateTime PeríodoInicial
		{
			get { return períodoInicial; }
			set { períodoInicial = value; }
		}

		public DateTime PeríodoFinal
		{
			get { return períodoFinal; }
			set { períodoFinal = value; }
		}

		public long Setor
		{
			get { return setor; }
			set { setor = value; }
		}

		[System.ComponentModel.DefaultValue(480)]
		public int Largura
		{
			get { return largura; }
			set { largura = value; }
		}

		[System.ComponentModel.DefaultValue(240)]
		public int Altura
		{
			get { return altura; }
			set { altura = value; }
		}

		protected string QueryString
		{
			get
			{
				return "ref=" + referência
					+ "&periodoInicial=" + períodoInicial.ToString("yyyy-MM-dd")
					+ "&periodoFinal=" + períodoFinal.ToString("yyyy-MM-dd")
					+ "&setor=" + setor.ToString()
					+ "&largura=" + largura.ToString()
					+ "&altura=" + altura.ToString()
					+ "&l=n";
			}
		}

		public string Plotter
		{
			get { return plotter; }
			set { plotter = value; }
		}
	}
}
