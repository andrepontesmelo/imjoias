using System;
using System.ComponentModel;
using System.Xml;

namespace Apresentação.Mercadoria.Etiqueta.Impressão.Layout
{
	/// <summary>
	/// Leiaute para mapeamento de peso
	/// </summary>
	public class Peso : Report.Layout.Complex.TextMapped
	{
		private string prefixo, sufixo;

		public Peso() : base(typeof(Entidades.Mercadoria.Mercadoria), "Peso")
		{
			Width = 1;
			Height = 0.5f;

			prefixo = sufixo = "9";

			this.format = "{0:###0.0}";
		}

		/// <summary>
		/// Gera a string para impressão
		/// </summary>
		/// <param name="obj">Objeto a ser impresso</param>
		/// <returns>String a ser impresso</returns>
		protected override string GetString(object obj)
		{
			return prefixo + base.GetString(obj) + sufixo;
		}

		/// <summary>
		/// Prefixo a ser impresso
		/// </summary>
		[Browsable(true), DefaultValue("9"), Category("Layout"),
		Description("Texto que será impresso antes do índice.")]
		public string Prefixo
		{
			get { return prefixo; }
			set { prefixo = value; }
		}

		/// <summary>
		/// Sufixo a ser impresso
		/// </summary>
		[Browsable(true), DefaultValue("9"), Category("Layout"),
		Description("Texto que será impresso logo após o índice.")]
		public string Sufixo
		{
			get { return sufixo; }
			set { sufixo = value; }
		}

		/// <summary>
		/// Carrega definições de um xml
		/// </summary>
		public override void FromXml(System.Xml.XmlElement element, System.Collections.IDictionary typeDictionary)
		{
			XmlAttribute xmlPrefixo, xmlSufixo;

			base.FromXml (element, typeDictionary);

			xmlPrefixo = element.Attributes["prefixo"];
			xmlSufixo  = element.Attributes["sufixo"];

			if (xmlPrefixo != null)
				prefixo = xmlPrefixo.Value;

			if (xmlSufixo != null)
				sufixo = xmlSufixo.Value;
		}

		/// <summary>
		/// Salva definições em um xml
		/// </summary>
		public override void SaveXml(XmlDocument doc, XmlElement element)
		{
			base.SaveXml (doc, element);

			element.SetAttribute("prefixo", prefixo);
			element.SetAttribute("sufixo", sufixo);
		}

		/// <summary>
		/// String a ser impressa em modo design
		/// </summary>
		protected override string GetDesignString()
		{
			return prefixo + "12,3" + sufixo;
		}
	}
}
