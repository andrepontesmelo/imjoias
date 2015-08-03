/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Xml;

namespace Report.Layout.Complex
{
	/// <summary>
	/// A static label
	/// </summary>
	[Serializable]
	public sealed class StaticLabel : Label
	{
		private string				text;

		/// <summary>
		/// Text of static label
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public string Text
		{
			get { return text; }
			set { text = value; }
		}

		/// <summary>
		/// Configure layout from xml
		/// </summary>
		public override void FromXml(System.Xml.XmlElement element, IDictionary typeDictionary)
		{
			base.FromXml (element, typeDictionary);

			// Set attributes
			this.Text   = element.GetAttribute("Text");
		}

		/// <summary>
		/// Save printable item into a xml element
		/// </summary>
		public override void SaveXml(XmlDocument doc, XmlElement element)
		{
			base.SaveXml(doc, element);

			element.SetAttribute("Text", this.Text);
		}

		/// <summary>
		/// Gets a text for an object
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <returns>Text to print</returns>
		public override string GetText(object obj)
		{
			return text;
		}
	}
}
