/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection;
using System.Xml;
using Report.Layout.Complex;

namespace Report.Layout
{
	/// <summary>
	/// Label Layout
	/// </summary>
	public class LabelLayout : Layout
	{
		// Layout
		private CollectionItemLayout	items = new CollectionItemLayout();
		private float					marginTop, marginBottom, marginLeft, marginRight;
		private float					gapVertical, gapHorizontal;
		private Metric					metric = new MetricCentimeter();
		private PaperSize				paperSize;

		// Runtime counters
		private int						_elementCount;

		#region Constructors and freeing

		public LabelLayout(System.ComponentModel.IContainer container) : base(container)
		{
			PageSettings page = new PageSettings();

			paperSize = page.PaperSize;
		}

		public LabelLayout()
		{
			PageSettings page = new PageSettings();

			paperSize = page.PaperSize;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				items.Clear();
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Public properties

		/// <summary>
		/// Top margin
		/// </summary>
		[Browsable(true), Category("Layout")]
		public float MarginTop
		{
			get { return metric.Reverse(marginTop); }
			set { marginTop = metric.Convert(value); }
		}

		/// <summary>
		/// Bottom margin
		/// </summary>
		[Browsable(true), Category("Layout")]
		public float MarginBottom
		{
			get { return metric.Reverse(marginBottom); }
			set { marginBottom = metric.Convert(value); }
		}

		/// <summary>
		/// Left margin
		/// </summary>
		[Browsable(true), Category("Layout")]
		public float MarginLeft
		{
			get { return metric.Reverse(marginLeft); }
			set { marginLeft = metric.Convert(value); }
		}

		/// <summary>
		/// Bottom margin
		/// </summary>
		[Browsable(true), Category("Layout")]
		public float MarginRight
		{
			get { return metric.Reverse(marginRight); }
			set { marginRight = metric.Convert(value); }
		}

		/// <summary>
		/// Vertical gap
		/// </summary>
		[Browsable(true), Category("Layout"), Description("Gap between Y's start position from each label's row")]
		public float GapVertical
		{
			get { return metric.Reverse(gapVertical); }
			set { gapVertical = metric.Convert(value); }
		}

		/// <summary>
		/// Vertical gap
		/// </summary>
		[Browsable(true), Category("Layout"), Description("Gap between X's start position from each label's row")]
		public float GapHorizontal
		{
			get { return metric.Reverse(gapHorizontal); }
			set { gapHorizontal = metric.Convert(value); }
		}

		/// <summary>
		/// Pages Layout Collection
		/// </summary>
		[Browsable(true)]
//		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ReadOnly(true)]
		public CollectionItemLayout Items
		{
			get { return items; }
		}

		[Browsable(true)]
		public PaperSize PaperSize
		{
			get { return paperSize; }
			set { paperSize = value; }
		}

		#endregion

		/// <summary>
		/// Prepare to print
		/// </summary>
		protected override void BeginPrint(object sender, PrintEventArgs e)
		{
			_elementCount = 0;
		}

		/// <summary>
		/// Handle a PrintPage event.
		/// </summary>
		protected override void PrintPage(object sender, PrintPageEventArgs e)
		{
			ItemLayout currentItem;
			PointF     startPosition;
			MetricHInch hInch = new MetricHInch();

			if (marginTop + items[0].Size.Height <= marginBottom)
				throw new Exception("Cannot start to print page! Item's size + top margin exceeds bottom margin!");

			startPosition = new PointF(marginLeft, marginTop);

			e.Graphics.PageUnit = GraphicsUnit.Millimeter;

			do
			{
				object       element = objects[_elementCount];
				GroupObjects group = element as GroupObjects;

				// Check if element is a group of objects
				if (group != null)
				{
					element     = group.Next;
					currentItem = (ItemLayout) group.Layout;

					if (!group.HasNext)
						_elementCount++;
				}
				else
				{
					_elementCount++;
					
					currentItem = items[0];
				}

				currentItem.Print(e.Graphics, element, startPosition);

				startPosition.X += gapHorizontal + currentItem.Size.Width;

				if (startPosition.X + currentItem.Size.Width >= hInch.Reverse(paperSize.Width) - marginRight)
				{
					startPosition.X = marginLeft;
					startPosition.Y += gapVertical + currentItem.Size.Height;
				}

			} while (_elementCount < objects.Count && startPosition.Y + currentItem.Size.Height <= hInch.Reverse(paperSize.Height) - marginBottom);

			e.HasMorePages = _elementCount < objects.Count;
		}

		/// <summary>
		/// Setup page settings
		/// </summary>
		protected override void QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
		{
			MetricHInch hInch = new MetricHInch();

			e.PageSettings.PaperSize = paperSize;
			e.PageSettings.Margins.Left = (int) Math.Round(hInch.Reverse(marginLeft));
			e.PageSettings.Margins.Top  = (int) Math.Round(hInch.Reverse(marginTop));
			//e.PageSettings.Margins.Right = (int) Math.Round(hInch.Reverse(marginRight));
			//e.PageSettings.Margins.Bottom = (int) Math.Round(hInch.Reverse(marginBottom));
		}

		/// <summary>
		/// Load settings from Xml
		/// </summary>
		/// <param name="doc">Xml document</param>
		/// <param name="designMode">If on design mode</param>
		public override void LoadFromXml(XmlDocument doc, bool designMode)
		{
			XmlElement paperSizeElement;

			ImportPageAttributes(doc["LabelLayout"]);

			// Imports printable items settings
			foreach (XmlElement element in doc["LabelLayout"].GetElementsByTagName("ItemLayout"))
			{
				ItemLayout importedItem;

				importedItem = new ItemLayout(this.components);
				importedItem.DesignMode = designMode;
				importedItem.LoadFromXml(element, typeDictionary);

				items.Add(importedItem);
			}

			paperSizeElement = doc["LabelLayout"]["PaperSize"];

			if (paperSizeElement != null)
				paperSize = CreatePaperSizeFromXml(paperSizeElement, metric);
		}

		/// <summary>
		/// Merge LabelLayout's items inside this
		/// </summary>
		/// <param name="doc">Xml document</param>
		/// <param name="designMode">If on design mode</param>
		public void MergeFromXml(XmlDocument doc, bool designMode)
		{
			// Imports printable items settings
			foreach (XmlElement element in doc["LabelLayout"].GetElementsByTagName("ItemLayout"))
			{
				ItemLayout importedItem;

				importedItem = new ItemLayout(this.components);
				importedItem.DesignMode = designMode;
				importedItem.LoadFromXml(element, typeDictionary);

				items.Add(importedItem);
			}
		}

		/// <summary>
		/// Merge LabelLayout's items inside this
		/// </summary>
		/// <param name="xml">Xml document</param>
		/// <param name="designMode">If on design mode</param>
		public void MergeFromXml(string xml, bool designMode)
		{
			XmlDocument doc = new XmlDocument();

			doc.LoadXml(xml);

			MergeFromXml(doc, designMode);
		}

		/// <summary>
		/// Import page attributes
		/// </summary>
		/// <param name="label">Label's root element</param>
		private void ImportPageAttributes(XmlElement label)
		{
			this.marginTop     = float.Parse(label.Attributes["top"].Value, NumberFormatInfo.InvariantInfo);
			this.marginLeft    = float.Parse(label.Attributes["left"].Value, NumberFormatInfo.InvariantInfo);
			this.marginBottom  = float.Parse(label.Attributes["bottom"].Value, NumberFormatInfo.InvariantInfo);
			this.marginRight   = float.Parse(label.Attributes["right"].Value, NumberFormatInfo.InvariantInfo);
			this.gapVertical   = float.Parse(label.Attributes["verticalGap"].Value, NumberFormatInfo.InvariantInfo);
			this.gapHorizontal = float.Parse(label.Attributes["horizontalGap"].Value, NumberFormatInfo.InvariantInfo);
		}

		/// <summary>
		/// Save settings to a xml document
		/// </summary>
		/// <param name="doc">Xml document</param>
		public override void SaveToXml(XmlDocument doc)
		{
			XmlElement root;

			if (doc.DocumentElement == null)
				doc.AppendChild(doc.CreateElement("LabelLayout"));

			root = doc.DocumentElement;

			root.SetAttribute("top", marginTop.ToString(NumberFormatInfo.InvariantInfo));
			root.SetAttribute("left", marginLeft.ToString(NumberFormatInfo.InvariantInfo));
			root.SetAttribute("bottom", marginBottom.ToString(NumberFormatInfo.InvariantInfo));
			root.SetAttribute("right", marginRight.ToString(NumberFormatInfo.InvariantInfo));
			root.SetAttribute("verticalGap", gapVertical.ToString(NumberFormatInfo.InvariantInfo));
			root.SetAttribute("horizontalGap", gapHorizontal.ToString(NumberFormatInfo.InvariantInfo));

			foreach (ItemLayout item in items)
			{
				XmlElement xmlItem;

				xmlItem = doc.CreateElement("ItemLayout");
				root.AppendChild(xmlItem);

				item.SaveToXml(doc, xmlItem);
			}

			SavePaperSizeToXml(doc, root);
		}

		private void SavePaperSizeToXml(XmlDocument doc, XmlElement root)
		{
			XmlElement paper;
			MetricHInch hInch = new MetricHInch();
			
			paper = doc.CreateElement("PaperSize");
			paper.SetAttribute("Width", metric.Reverse(hInch.Convert(paperSize.Width)).ToString(NumberFormatInfo.InvariantInfo));
			paper.SetAttribute("Height", metric.Reverse(hInch.Convert(paperSize.Height)).ToString(NumberFormatInfo.InvariantInfo));

			root.AppendChild(paper);
		}

		/// <summary>
		/// Check compatibility
		/// </summary>
		/// <param name="other">Another LabelLayout</param>
		public bool IsCompatible(LabelLayout other)
		{
			bool compatible;
			int  i = 0;

			compatible = this.paperSize.Width == other.paperSize.Width
				&& this.paperSize.Height == other.paperSize.Height
				&& this.items.Count == other.items.Count
				&& this.gapHorizontal == other.gapHorizontal
				&& this.gapVertical == other.gapVertical
				&& this.marginBottom == other.marginBottom
				&& this.marginLeft == other.marginLeft
				&& this.marginRight == other.marginRight
				&& this.marginBottom == other.marginBottom;

			while (compatible && i < items.Count)
			{
				compatible &= ((ItemLayout) this.items[i]).Size == ((ItemLayout) other.items[i]).Size;
				i++;
			}

			return compatible;
		}

		/// <summary>
		/// Labels per page
		/// </summary>
		public int LabelsPerPage
		{
			get
			{
				int        labels = 0;
				int        cycle = 0;
				PointF     startPosition;
				ItemLayout currentItem;
				MetricHInch hInch = new MetricHInch();

				startPosition = new PointF(marginLeft, marginTop);

				do
				{
					currentItem = items[cycle++];

					if (cycle >= items.Count)
						cycle = 0;

					labels++;

					startPosition.X += gapHorizontal + currentItem.Size.Width;

					if (startPosition.X + currentItem.Size.Width >= hInch.Reverse(paperSize.Width) - marginRight)
					{
						startPosition.X = marginLeft;
						startPosition.Y += gapVertical + currentItem.Size.Height;
					}

				} while (startPosition.Y + currentItem.Size.Height <= hInch.Reverse(paperSize.Height) - marginBottom);

				return labels;
			}
		}
	}
}
