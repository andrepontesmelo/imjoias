using System;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;

namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o.Layout
{
	/// <summary>
	/// Logotipo da Ind�stria Mineira de J�ias
	/// </summary>
	public class Logotipo : Report.Layout.Complex.PrintableItem
	{
		private Image logotipo;
		private float transpar�ncia = 0f;

		public Logotipo()
		{
			logotipo = ObterLogotipoOriginal();
			Width = 2;
			Height = 1;
		}

		/// <summary>
		/// Obt�m logotipo do reposit�rio
		/// </summary>
		/// <returns>Imagem contendo logotipo</returns>
		private Image ObterLogotipoOriginal()
		{
			Image logotipo;
			System.IO.BufferedStream buffer = new System.IO.BufferedStream(
				Assembly.GetExecutingAssembly().GetManifestResourceStream("Apresenta��o.Mercadoria.Etiqueta.Impress�o.Layout.Logo.jpg"));

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
		/// Transpar�ncia do logotipo
		/// </summary>
		[Browsable(true),
			Description("Transpar�ncia da logomarca. O intervalo para "
			+ "transpar�ncia � [0;100] em que 0 � sem transpar�ncia e 100 "
			+ "transpar�ncia total."),
			DefaultValue(0f),
			Category("Apar�ncia")]
		public float Transpar�ncia
		{
			get { return transpar�ncia; }
			set
			{
				transpar�ncia = value;

				if (transpar�ncia > 0)
				{
					Bitmap logotipo;

					logotipo = new Bitmap(ObterLogotipoOriginal());

					for (int y = 0; y < logotipo.Height; y++)
						for (int x = 0; x < logotipo.Width; x++)
							logotipo.SetPixel(x, y, Color.FromArgb(255 - (int) Math.Round(transpar�ncia / 100 * 255), logotipo.GetPixel(x, y)));

					this.logotipo = logotipo;
				}
				else
					this.logotipo = ObterLogotipoOriginal();
			}
		}

		/// <summary>
		/// Salva configura��es em xml
		/// </summary>
		/// <param name="doc">Documento xml</param>
		/// <param name="element">Elemento logotipo</param>
		public override void SaveXml(System.Xml.XmlDocument doc, System.Xml.XmlElement element)
		{
			base.SaveXml(doc, element);

			if (transpar�ncia > 0 && transpar�ncia <= 100)
				element.SetAttribute("transpar�ncia", transpar�ncia.ToString(NumberFormatInfo.InvariantInfo));
		}

		/// <summary>
		/// Carrega configura��es de um xml
		/// </summary>
		/// <param name="element">Elemento logotipo</param>
		/// <param name="typeDictionary">Dicion�rio de tipos</param>
		public override void FromXml(System.Xml.XmlElement element, System.Collections.IDictionary typeDictionary)
		{
			System.Xml.XmlAttribute atributo;

			base.FromXml(element, typeDictionary);

			atributo = element.Attributes["transpar�ncia"];

			if (atributo != null)
				Transpar�ncia = float.Parse(atributo.Value);
			else
				Transpar�ncia = 0;
		}
	}
}
