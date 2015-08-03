/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Drawing;
using System.Globalization;
using System.Xml;
using System.Collections;
using System.ComponentModel;

namespace Report.Layout.Complex
{
	[Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
	public class TextMapped : MappingAlphanumeric, IPrintableItem
	{
		// Layout
		private RectangleF			location;
		private Font				font = new Font(FontFamily.GenericSansSerif, 12);
		private Brush				brush = Brushes.Black;
		private ContentAlignment	alignment = ContentAlignment.MiddleCenter;
		private Border				border = null;
		private Metric				metric = new MetricCentimeter();

		// Design mode
		private bool				designMode = false;
		private string				_memberName = null;
		private string				_typeName = null;

		/// <summary>
		/// Constructs a text mapped
		/// </summary>
		/// <param name="type">Type of object that contains data to be printed</param>
		/// <param name="member">Member containg data to be printed</param>
		public TextMapped(Type type, string member)
		{
			SetMember(type, member);

			_memberName = member;
			_typeName   = type.FullName;
		}

		public TextMapped()
		{
		}

		/// <summary>
		/// Location of printable item
		/// </summary>
		[System.ComponentModel.Category("Layout")]
		[System.ComponentModel.Browsable(false)]
		public System.Drawing.RectangleF Location
		{
			get { return location; }
			set { location = value; }
		}

		#region Location properties

		public float Top
		{
			get { return metric.Reverse(location.Y); }
			set { location.Y = metric.Convert(value); }
		}

		public float Left
		{
			get { return metric.Reverse(location.X); }
			set { location.X = metric.Convert(value); }
		}

		public float Width
		{
			get { return metric.Reverse(location.Width); }
			set { location.Width = metric.Convert(value); }
		}

		public float Height
		{
			get { return metric.Reverse(location.Height); }
			set { location.Height = metric.Convert(value); }
		}

		#endregion

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
		public new ContentAlignment Alignment
		{
			get { return alignment; }
			set { alignment = value; }
		}

		/// <summary>
		/// Label's border
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
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
		public void Print(System.Drawing.Graphics g, object obj)
		{
			RectangleF	location = this.Location;
			SizeF		size;
			float		inc;			// Increment (temp var)
			string		text;

			if (designMode || MatchTypeObject(obj))
			{
				// First, set unit of measure to milimiters
				g.PageUnit = GraphicsUnit.Millimeter;

				// Draw border
				if (border != null)
					border.Print(g, obj);

				// Check if it's a design mode
				if (designMode)
					text = GetDesignString();
				else
					text = GetString(obj);

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
						inc				= Math.Max(0, location.Height / 2f - size.Height / 2f);
						location.Y		+= inc;
						location.Height -= inc;
						break;
				}

				g.DrawString(text, font, brush, location);
			}
		}

		/// <summary>
		/// Configure layout from xml
		/// </summary>
		public virtual void FromXml(XmlElement element, IDictionary typeDictionary)
		{
			location = new RectangleF(
				metric.Parse(element.GetAttribute("Left")),
				metric.Parse(element.GetAttribute("Top")),
				metric.Parse(element.GetAttribute("Width")),
				metric.Parse(element.GetAttribute("Height")));

			#region Gets member

			// Gets member
			if (designMode)
			{
				XmlElement member = element["Member"];

				_memberName = member.GetAttribute("Name");
				_typeName = member.GetAttribute("Type");
			}
			else
				SetMember(element["Member"], typeDictionary);

			#endregion

			#region Gets Alignment

			// Get Alignment
			if (element.HasAttribute("Alignment"))
				this.Alignment = (ContentAlignment) Enum.Parse(typeof(ContentAlignment), element.GetAttribute("Alignment"));

			#endregion

			#region Gets Format

			// Get Format
			if (element.HasAttribute("Format"))
				this.Format = element.GetAttribute("Format");

			#endregion

			#region Gets Border

			// Get border
			XmlElement xmlBorder = element["Border"];

			if (xmlBorder != null)
			{
				this.Border = new Border(this);
				this.border.FromXml(xmlBorder, typeDictionary);
			}

			#endregion

			#region Gets font

			// Get font
			XmlElement xmlFont  = element["Font"];

			if (xmlFont != null)
				this.font = DocumentLayout.CreateFontFromXml(xmlFont);

			#endregion

			#region Gets Brush

			// Get brush
			XmlElement xmlBrush = element["Brush"];

			if (xmlBrush != null)
				this.Brush = DocumentLayout.CreateBrushFromXml(xmlBrush);

			#endregion
		}
		
		/// <summary>
		/// Save printable item into a xml element
		/// </summary>
		public virtual void SaveXml(XmlDocument doc, XmlElement element)
		{
			Type type;

			type = this.GetType();

			if (!type.FullName.StartsWith("Report.Layout.Complex."))
				element.SetAttribute("Type", this.GetType().FullName);

			element.SetAttribute("Left", metric.Reverse(location.X).ToString(NumberFormatInfo.InvariantInfo));
			element.SetAttribute("Top", metric.Reverse(location.Y).ToString(NumberFormatInfo.InvariantInfo));
			element.SetAttribute("Width", metric.Reverse(location.Width).ToString(NumberFormatInfo.InvariantInfo));
			element.SetAttribute("Height", metric.Reverse(location.Height).ToString(NumberFormatInfo.InvariantInfo));

			element.SetAttribute("Alignment", this.alignment.ToString());
			
			if (format != null)
				element.SetAttribute("Format", this.format.ToString());

			XmlElement xmlMember = doc.CreateElement("Member");
			xmlMember.SetAttribute("Name", _memberName);
			xmlMember.SetAttribute("Type", _typeName);
			element.AppendChild(xmlMember);

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
		public void SetDefault(ILayout pageLayout)
		{
			this.metric			= pageLayout.DefaultMetric;
			this.Border			= (Border) pageLayout.DefaultBorder.Clone();
			this.Brush			= (Brush) pageLayout.DefaultTextBrush.Clone();
			this.Font			= (Font) pageLayout.DefaultTextFont.Clone();
			this.Alignment		= pageLayout.DefaultAlignment;
		}

		/// <summary>
		/// Metric used
		/// </summary>
		public Metric Metric
		{
			get { return metric; }
			set { metric = value; }
		}

		/// <summary>
		/// Design mode
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public bool DesignMode
		{
			get { return designMode; }
			set { designMode = value; }
		}

		/// <summary>
		/// Member's name
		/// </summary>
		public string MemberName
		{
			get { return member != null ? member.Name : _memberName; }
			set { _memberName = value; member = null; }
		}

		/// <summary>
		/// Type member
		/// </summary>
		public string TypeName
		{
			get { return member != null ? member.DeclaringType.Namespace + "." + member.DeclaringType.Name : _typeName; }
			set { _typeName = value; member = null; }
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
		/// String to print when on design mode
		/// </summary>
		protected virtual string GetDesignString()
		{
			return TypeName + "." + MemberName + "\nTextMapped";
		}
	}
}
