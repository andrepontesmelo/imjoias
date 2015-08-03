using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Relat�rio.Graficos
{
	/// <summary>
	/// Summary description for Gr�fico.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Gr�fico runat=server></{0}:Gr�fico>")]
	public class Gr�fico : System.Web.UI.WebControls.WebControl
	{
		private long		setor;
		private string		refer�ncia;
		private DateTime	per�odoInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
		private DateTime	per�odoFinal = DateTime.Now;
		private int			largura = 480;
		private int			altura = 240;
		private string		plotter = "Graficos/Plotar.aspx";


		protected System.Web.UI.HtmlControls.HtmlGenericControl P1;

		protected Relat�rio.Graficos.Legenda legenda;

		public Gr�fico() : base(HtmlTextWriterTag.Img)
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
				Usu�rios usrs = (Usu�rios) Page.Application["usu�rios"];
				Usu�rio  usr  = usrs[Page.User.Identity.Name];

				legenda.Conex�o = usr.Conex�o;
				legenda.Refer�ncia = refer�ncia;
			
				legenda.Requisitos.Add("periodoInicial", per�odoInicial.ToString());
				legenda.Requisitos.Add("periodoFinal", per�odoFinal.ToString());
				legenda.Requisitos.Add("setor", setor.ToString());
			}
			catch
			{
			}
		}
*/

		public string Refer�ncia
		{
			get { return refer�ncia; }
			set { refer�ncia = value; }
		}

		public DateTime Per�odoInicial
		{
			get { return per�odoInicial; }
			set { per�odoInicial = value; }
		}

		public DateTime Per�odoFinal
		{
			get { return per�odoFinal; }
			set { per�odoFinal = value; }
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
				return "ref=" + refer�ncia
					+ "&periodoInicial=" + per�odoInicial.ToString("yyyy-MM-dd")
					+ "&periodoFinal=" + per�odoFinal.ToString("yyyy-MM-dd")
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
