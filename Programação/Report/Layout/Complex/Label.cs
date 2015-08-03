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
	/// A label
	/// </summary>
	[Serializable]
	public abstract class Label : PrintableItem
	{
		private Font				font = new Font(FontFamily.GenericSansSerif, 12);
		private Brush				brush = Brushes.Black;
		private ContentAlignment	alignment = ContentAlignment.MiddleCenter;
		private Border				border = null;

		/// <summary>
		/// Label's font
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public Font Font
		{
			get { return font; }
			set { font = value; }
		}

		/// <summary>
		/// Label's brush
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public Brush Brush
		{
			get { return brush; }
			set { brush = value; }
		}

		/// <summary>
		/// Label's alignment
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public ContentAlignment Alignment
		{
			get { return alignment; }
			set { alignment = value; }
		}

		/// <summary>
		/// Label's border
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
		public Border Border
		{
			get { return border; }
			set
			{
				border = value;

				if (border != null)
					border.Owner = this;
			}
		}

		/// <summary>
		/// Print static label
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public override void Print(System.Drawing.Graphics g, object obj)
		{
			RectangleF	location = this.Location;
			SizeF		size;
			float		inc;			// Increment (temp var)
			string      text;

			text = GetText(obj);

			// First, set unit of measure to milimiters
			g.PageUnit = GraphicsUnit.Millimeter;

			// Draws border
			if (border != null)
				border.Print(g, obj);

			size = g.MeasureString(text, font, (int) Math.Ceiling(location.Width));

			// Aligns text horizontally
			switch (alignment)
			{
				case ContentAlignment.BottomCenter:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.TopCenter:
					inc				= Math.Max(0, location.Width / 2f - size.Width / 2f);
					location.X     += inc;
					location.Width -= inc;
					break;

				case ContentAlignment.BottomRight:
				case ContentAlignment.MiddleRight:
				case ContentAlignment.TopRight:
					inc				= Math.Max(0, location.Width - size.Width);
					location.X     += inc;
					location.Width -= inc;
					break;
			}

			// Aligns text vertically
			switch (alignment)
			{
				case ContentAlignment.BottomCenter:
				case ContentAlignment.BottomLeft:
				case ContentAlignment.BottomRight:
					inc				= Math.Max(0, location.Height - size.Height);
					location.Y		+= inc;
					location.Height	-= inc;
					break;

				case ContentAlignment.MiddleCenter:
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.MiddleRight:
					inc				= Math.Max(0, (float) location.Height / 2f - (float) size.Height / 2f);
					location.Y		+= inc;
					location.Height -= inc;
					break;
			}

			g.DrawString(text, font, brush, location);
		}

		/// <summary>
		/// Configure layout from xml
		/// </summary>
		public override void FromXml(System.Xml.XmlElement element, IDictionary typeDictionary)
		{
			base.FromXml (element, typeDictionary);

			if (element.HasAttribute("Alignment"))
				this.Alignment = (ContentAlignment) Enum.Parse(typeof(ContentAlignment), element.GetAttribute("Alignment"));

			// Get border
			XmlElement xmlBorder = element["Border"];

			if (xmlBorder != null)
			{
				this.Border = new Border(this);
				this.border.FromXml(xmlBorder, typeDictionary);
			}

			// Get font
			XmlElement xmlFont  = element["Font"];

			if (xmlFont != null)
				this.font = DocumentLayout.CreateFontFromXml(xmlFont);

			// Get brush
			XmlElement xmlBrush = element["Brush"];

			if (xmlBrush != null)
				this.Brush = DocumentLayout.CreateBrushFromXml(xmlBrush);
		}

		/// <summary>
		/// Save printable item into a xml element
		/// </summary>
		public override void SaveXml(XmlDocument doc, XmlElement element)
		{
			base.SaveXml(doc, element);

			element.SetAttribute("Alignment", this.alignment.ToString());

			if (this.border != null)
			{
				XmlElement xmlBorder = doc.CreateElement("Border");
				border.SaveXml(doc, xmlBorder);
				element.AppendChild(xmlBorder);
			}

			XmlElement xmlFont = doc.CreateElement("Font");
			PageLayout.SaveXmlFont(doc, xmlFont, this.font);
			element.AppendChild(xmlFont);

			XmlElement xmlBrush = doc.CreateElement("Brush");
			PageLayout.SaveXmlBrush(doc, xmlBrush, this.brush);
			element.AppendChild(xmlBrush);
		}

		/// <summary>
		/// Set properties to pageLayout's default.
		/// </summary>
		/// <param name="pageLayout">PageLayout containing default properties</param>
		[System.ComponentModel.Browsable(false)]
		public override void SetDefault(ILayout pageLayout)
		{
			base.SetDefault(pageLayout);

			this.Border			= (Border) pageLayout.DefaultBorder.Clone();
			this.Brush			= (Brush) pageLayout.DefaultTextBrush.Clone();
			this.Font			= (Font) pageLayout.DefaultTextFont.Clone();
			this.Alignment		= pageLayout.DefaultAlignment;
		}

		[System.ComponentModel.Category("Appearence")]
		public Color FontColor
		{
			get
			{
				SolidBrush sBrush = brush as SolidBrush;
				return sBrush != null ? sBrush.Color : Color.Empty;
			}
			set
			{
				SolidBrush sBrush = brush as SolidBrush;
				
				if (sBrush != null)
					sBrush.Color = value;
				else
					brush = new SolidBrush(value);
			}
		}

		/// <summary>
		/// Get text for object
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <returns>Text to print</returns>
		public abstract string GetText(object obj);
	}
}