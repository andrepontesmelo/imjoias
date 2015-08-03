/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.ComponentModel;
using System.Collections;
using System.Globalization;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;

namespace Report.Layout.Complex
{
	/// <summary>
	/// A layout for an item
	/// </summary>
	public class ItemLayout : System.ComponentModel.Component, ILayout
	{
		// Constants
		const string strGroupElements = "GroupElements";
		const string strSize = "Size";
		const string strDefaultTextFont = "DefaultTextFont";
		const string strDefaultTextBrush = "DefaultTextBrush";
		const string strDefaultBorder = "DefaultBorder";
		const string strDefaultAlignment = "DefaultAlignment";
		const string strDefaultMetric = "DefaultMetric";

		// Layout
		private CollectionIPrintableItem	printableItems = new CollectionIPrintableItem();
		private Font						defaultTextFont = new Font(FontFamily.GenericSansSerif, 12);
		private Brush						defaultTextBrush = Brushes.Black;
		private Border						defaultBorder;
		private ContentAlignment			defaultAlignment = ContentAlignment.TopLeft;
		private Metric						defaultMetric = new MetricCentimeter();
		private SizeF						itemSize = new SizeF(25.4f, 25.4f);

		// Behavior
		private int							groupElements = 1;

		// Runtime
		private bool						_designMode = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemLayout(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			SetDefaultBorder();
		}

		public ItemLayout()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			SetDefaultBorder();
		}

		private void SetDefaultBorder()
		{
			defaultBorder = new Border();
			defaultBorder.BorderPen = new Pen(Color.FromArgb(0, 0, 0, 0));
			defaultBorder.BackgroundBrush = new SolidBrush(Color.FromArgb(0, 255, 255, 255));
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		/// <summary>
		/// Print an object
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public void Print(Graphics g, object obj, PointF location)
		{
			foreach (IPrintableItem item in printableItems)
			{
				RectangleF locationBackup = item.Location;

				item.Location = new RectangleF(
					item.Location.X + location.X,
					item.Location.Y + location.Y,
					item.Location.Width,
					item.Location.Height);

				item.Print(g, obj);

				item.Location = locationBackup;
			}
		}

		/// <summary>
		/// Print an object
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public void Print(Graphics g, object obj)
		{
			Print(g, obj, new PointF(0, 0));
		}

		/// <summary>
		/// Printable items
		/// </summary>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public CollectionIPrintableItem Items
		{
			get { return printableItems; }
		}

		/// <summary>
		/// Number of elements grouped into a single paper
		/// </summary>
		[Browsable(true)]
		[Category("Layout"), DefaultValue(1)]
		[Description("Number of elements grouped into a single page")]
		public int GroupElements
		{
			get { return groupElements; }
			set
			{
				if (value < 1)
					throw new ArgumentException("GroupElements cannot be smaller than one.");

				groupElements = value;
			}
		}

		/// <summary>
		/// Item's size
		/// </summary>
		[Category("Layout")]
		[Browsable(false), ReadOnly(true)]
		public SizeF Size
		{
			get { return itemSize; }
			set { itemSize = value; }
		}

		/// <summary>
		/// Item's width
		/// </summary>
		[Category("Layout")]
		[Browsable(true)]
		public float Width
		{
			get { return defaultMetric.Reverse(itemSize.Width); }
			set { itemSize.Width = defaultMetric.Convert(value); }
		}

		/// <summary>
		/// Item's height
		/// </summary>
		[Category("Layout")]
		[Browsable(true)]
		public float Height
		{
			get { return defaultMetric.Reverse(itemSize.Height); }
			set { itemSize.Height = defaultMetric.Convert(value); }
		}

		/// <summary>
		/// Default text font
		/// </summary>
		public Font DefaultTextFont
		{
			get { return defaultTextFont; }
			set { defaultTextFont = value; }
		}

		/// <summary>
		/// Default text brush
		/// </summary>
		public Brush DefaultTextBrush
		{
			get { return defaultTextBrush; }
			set { defaultTextBrush = value; }
		}

		/// <summary>
		/// Default border
		/// </summary>
		[DefaultValue(null), ReadOnly(true)]
		public Border DefaultBorder
		{
			get
			{
				if (defaultBorder == null)
					SetDefaultBorder();

				return defaultBorder;
			}
			set { defaultBorder = value; }
		}

		/// <summary>
		/// Default alignment
		/// </summary>
		public ContentAlignment	DefaultAlignment
		{
			get { return defaultAlignment; }
			set { defaultAlignment = value; }
		}

		/// <summary>
		/// Default metric
		/// </summary>
		public Metric DefaultMetric
		{
			get { return defaultMetric; }
			set { defaultMetric = value; }
		}

		/// <summary>
		/// Design mode
		/// </summary>
		[System.ComponentModel.Browsable(false), ReadOnly(true)]
		public new bool DesignMode
		{
			get { return _designMode; }
			set
			{
				_designMode = value;

				foreach (IPrintableItem item in printableItems)
					item.DesignMode = value;
			}
		}

		/// <summary>
		/// Construct item's layout from xml
		/// </summary>
		public void LoadFromXml(XmlElement root, IDictionary typeDictionary)
		{
			// Configure items's layout
			if (root.HasAttribute(strGroupElements))
				this.groupElements = int.Parse(root.GetAttribute(strGroupElements));

			// Create printable items
			foreach (XmlNode node in root)
			{
				IPrintableItem item = null;
				XmlElement	   element;

				element = node as XmlElement;

				if (element == null)
					continue;

				if (element.LocalName == strSize)
				{
					Width = float.Parse(element.GetAttribute("Width"), NumberFormatInfo.InvariantInfo);
					Height = float.Parse(element.GetAttribute("Height"), NumberFormatInfo.InvariantInfo);
				}
				else if (element.LocalName.StartsWith("Default"))
				{
					if (element.LocalName == strDefaultTextFont)
						defaultTextFont = DocumentLayout.CreateFontFromXml(element);
					else if (element.LocalName == strDefaultTextBrush)
						defaultTextBrush = DocumentLayout.CreateBrushFromXml(element);
					else if (element.LocalName == strDefaultBorder)
						defaultBorder.FromXml(element, typeDictionary);
					else if (element.LocalName == strDefaultAlignment)
						defaultAlignment = (ContentAlignment) Enum.Parse(typeof(ContentAlignment), element.GetAttribute("Value"));
					else if (element.LocalName == strDefaultMetric)
						defaultMetric = Metric.GetMetricParser(element.GetAttribute("Value"));
					else
						throw new Exception("Default parameter unrecognized!");
				}
				else
				{
					// Get object instance
					if (element.HasAttribute("Type"))
					{
						foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
						{
							item = (IPrintableItem)
								assembly.CreateInstance(element.GetAttribute("Type"));

							if (item != null)
								break;
						}
					}
					else
					{
						item = (IPrintableItem)
							Assembly.GetExecutingAssembly().CreateInstance("Report.Layout.Complex." + element.Name);
					}

					item.DesignMode = this._designMode;

					item.SetDefault(this);
					item.FromXml(element, typeDictionary);
					printableItems.Add(item);
				}
			}
		}

		/// <summary>
		/// Save configuration to a XML file
		/// </summary>
		/// <param name="filename">The full path filename to save configuration</param>
		public void SaveToXml(string filename)
		{
			System.IO.BufferedStream xmlStream = null;
			byte [] xmlData;
			const int bufferSize = 4096;
			XmlDocument doc;

			#region Create doc, loading default xml

			// Load default xml from resource
			xmlStream = new System.IO.BufferedStream(
				Assembly.GetExecutingAssembly().GetManifestResourceStream("Report.Layout.Complex.DefaultLabelLayout.xml"),
				bufferSize);

			xmlData = new byte[xmlStream.Length];

			while (xmlStream.Position < xmlStream.Length)
				xmlStream.Read((byte[]) xmlData, (int) xmlStream.Position, (int) Math.Min(bufferSize, xmlStream.Length - xmlStream.Position));
				
			xmlStream.Close();

			string strDefaultXml = System.Text.Encoding.UTF8.GetString(xmlData);

			strDefaultXml = strDefaultXml.Substring(strDefaultXml.IndexOf('<'));

			doc = new XmlDocument();
			doc.LoadXml(strDefaultXml);

			#endregion

			SaveToXml(doc, doc["LabelLayout"]["ItemLayout"]);

			doc.Save(filename);
		}

		public void SaveToXml(XmlDocument doc, XmlElement root)
		{
			root.SetAttribute(strGroupElements, this.groupElements.ToString(NumberFormatInfo.InvariantInfo));

			XmlElement newElement;

//			MetricHInch convMetric = new MetricHInch();

			// DefaultMetric
			newElement = doc.CreateElement(strDefaultMetric);
			newElement.SetAttribute("Value", this.defaultMetric.ToString());
			root.AppendChild(newElement);

			// Paper size
			newElement = doc.CreateElement("Size");
			newElement.SetAttribute("Width",  Width.ToString(NumberFormatInfo.InvariantInfo));
			newElement.SetAttribute("Height", Height.ToString(NumberFormatInfo.InvariantInfo));
			//newElement.SetAttribute("Metric", "Centimeters");
			root.AppendChild(newElement);

			// Default border
			newElement = doc.CreateElement(strDefaultBorder);
			defaultBorder.SaveXml(doc, newElement);
			root.AppendChild(newElement);

			// Default text font
			newElement = doc.CreateElement(strDefaultTextFont);
			SaveXmlFont(doc, newElement, defaultTextFont);
			root.AppendChild(newElement);

			// Default text brush
			newElement = doc.CreateElement(strDefaultTextBrush);
			SaveXmlBrush(doc, newElement, defaultTextBrush);
			root.AppendChild(newElement);

			// Default alignment
			newElement = doc.CreateElement(strDefaultAlignment);
			SaveXmlAlignment(doc, newElement, defaultAlignment);
			root.AppendChild(newElement);

			// Save printable items
			foreach (IPrintableItem item in this.printableItems)
			{
				newElement = doc.CreateElement(item.GetType().Name);
				item.SaveXml(doc, newElement);
				root.AppendChild(newElement);
			}
		}

		static internal void SaveXmlFont(XmlDocument doc, XmlElement newElement, Font font)
		{
			newElement.SetAttribute("Name", font.Name);
			newElement.SetAttribute("Size", font.Size.ToString(NumberFormatInfo.InvariantInfo));

			if (font.Bold)
			{
				XmlElement bold = doc.CreateElement("Style");
				//bold.AppendChild(doc.CreateTextNode("Bold"));
				bold.SetAttribute("Style", "Bold");
				newElement.AppendChild(bold);
			}

			if (font.Italic)
			{
				XmlElement bold = doc.CreateElement("Style");
				//bold.AppendChild(doc.CreateTextNode("Italic"));
				bold.SetAttribute("Style", "Italic");
				newElement.AppendChild(bold);
			}

			if (font.Strikeout)
			{
				XmlElement bold = doc.CreateElement("Style");
				//bold.AppendChild(doc.CreateTextNode("Strikeout"));
				bold.SetAttribute("Style", "Strikeout");
				newElement.AppendChild(bold);
			}

			if (font.Underline)
			{
				XmlElement bold = doc.CreateElement("Style");
				//bold.AppendChild(doc.CreateTextNode("Underline"));
				bold.SetAttribute("Style", "Underline");
				newElement.AppendChild(bold);
			}
		}

		static internal void SaveXmlBrush(XmlDocument doc, XmlElement newElement, Brush brush)
		{
			if (brush.GetType() == typeof(SolidBrush))
			{
				XmlElement color = doc.CreateElement("Color");
				SaveXmlColor(doc, color, ((SolidBrush) brush).Color);
				newElement.AppendChild(color);
			}
			else
				throw new NotImplementedException("Cannot save this brush!");
		}

		static internal void SaveXmlPen(XmlDocument doc, XmlElement newElement, Pen pen)
		{
			newElement.SetAttribute("Width", pen.Width.ToString(NumberFormatInfo.InvariantInfo));
			XmlElement color = doc.CreateElement("Color");
			SaveXmlColor(doc, color, pen.Color);
			newElement.AppendChild(color);
		}

		static internal void SaveXmlColor(XmlDocument doc, XmlElement newElement, Color color)
		{
			newElement.SetAttribute("Alpha", color.A.ToString(NumberFormatInfo.InvariantInfo));
			newElement.SetAttribute("Red", color.R.ToString(NumberFormatInfo.InvariantInfo));
			newElement.SetAttribute("Green", color.G.ToString(NumberFormatInfo.InvariantInfo));
			newElement.SetAttribute("Blue", color.B.ToString(NumberFormatInfo.InvariantInfo));
		}

		static internal void SaveXmlAlignment(XmlDocument doc, XmlElement newElement, ContentAlignment alignment)
		{
			newElement.SetAttribute("Value", alignment.ToString());
		}
	}
}
