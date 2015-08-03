using System;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;

namespace Apresentação.Mercadoria.Etiqueta.Impressão.Layout
{
	/// <summary>
	/// Logotipo da Indústria Mineira de Jóias
	/// </summary>
	public class Logotipo : Report.Layout.Complex.PrintableItem
	{
		private Image logotipo;
		private float transparência = 0f;

		public Logotipo()
		{
			logotipo = ObterLogotipoOriginal();
			Width = 2;
			Height = 1;
		}

		/// <summary>
		/// Obtém logotipo do repositório
		/// </summary>
		/// <returns>Imagem contendo logotipo</returns>
		private Image ObterLogotipoOriginal()
		{
			Image logotipo;
			System.IO.BufferedStream buffer = new System.IO.BufferedStream(
				Assembly.GetExecutingAssembly().GetManifestResourceStream("Apresentação.Mercadoria.Etiqueta.Impressão.Layout.Logo.jpg"));

			logotipo = Image.FromStream(buffer);

			buffer.Close();

			return logotipo;
		}

		/// <summary>
		/// Imprime logotipo
		/// </summary>
		public override void Print(Graphics g, object obj)
		{
			float imgProportion = logotipo.Width / logotipo.Height;
			float locProportion = Location.Width / Location.Height;
			Size  newSize;

			if (imgProportion >= locProportion)
				newSize = new Size((int) Math.Round(Location.Width), (int) Math.Round(Location.Width / imgProportion));
			else
				newSize = new Size((int) Math.Round(Location.Height * imgProportion), (int) Math.Round(Location.Height));

			g.DrawImage(
				logotipo,
				Location.Left + (Location.Width - newSize.Width) / 2,
				Location.Top + (Location.Height - newSize.Height) / 2,
				newSize.Width,
				newSize.Height);
		}

		/// <summary>
		/// Transparência do logotipo
		/// </summary>
		[Browsable(true),
			Description("Transparência da logomarca. O intervalo para "
			+ "transparência é [0;100] em que 0 é sem transparência e 100 "
			+ "transparência total."),
			DefaultValue(0f),
			Category("Aparência")]
		public float Transparência
		{
			get { return transparência; }
			set
			{
				transparência = value;

				if (transparência > 0)
				{
					Bitmap logotipo;

					logotipo = new Bitmap(ObterLogotipoOriginal());

					for (int y = 0; y < logotipo.Height; y++)
						for (int x = 0; x < logotipo.Width; x++)
							logotipo.SetPixel(x, y, Color.FromArgb(255 - (int) Math.Round(transparência / 100 * 255), logotipo.GetPixel(x, y)));

					this.logotipo = logotipo;
				}
				else
					this.logotipo = ObterLogotipoOriginal();
			}
		}

		/// <summary>
		/// Salva configurações em xml
		/// </summary>
		/// <param name="doc">Documento xml</param>
		/// <param name="element">Elemento logotipo</param>
		public override void SaveXml(System.Xml.XmlDocument doc, System.Xml.XmlElement element)
		{
			base.SaveXml(doc, element);

			if (transparência > 0 && transparência <= 100)
				element.SetAttribute("transparência", transparência.ToString(NumberFormatInfo.InvariantInfo));
		}

		/// <summary>
		/// Carrega configurações de um xml
		/// </summary>
		/// <param name="element">Elemento logotipo</param>
		/// <param name="typeDictionary">Dicionário de tipos</param>
		public override void FromXml(System.Xml.XmlElement element, System.Collections.IDictionary typeDictionary)
		{
			System.Xml.XmlAttribute atributo;

			base.FromXml(element, typeDictionary);

			atributo = element.Attributes["transparência"];

			if (atributo != null)
				Transparência = float.Parse(atributo.Value);
			else
				Transparência = 0;
		}
	}
}
