/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using System.ComponentModel;

namespace Report.Layout.Complex
{
	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Border : IPrintableItem, ICloneable
	{
		private Pen				borderPen = Pens.Black;
		private Brush			backgroundBrush = null;
		private IPrintableItem	owner;
		private bool			showBorder = false;

		/// <summary>
		/// Create a border
		/// </summary>
		/// <param name="container">Container</param>
		public Border(IPrintableItem container)
		{
			owner = container;
		}

		public Border()
		{
		}

		[Browsable(false)]
		public IPrintableItem Owner
		{
			get { return owner; }
			set { owner = value; }
		}

		/// <summary>
		/// Border pen
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		[Browsable(false), ReadOnly(true)]
		public Pen BorderPen
		{
			get { return borderPen; }
			set { borderPen = value; }
		}

		[System.ComponentModel.Category("Appearence")]
		public Color BorderColor
		{
			get { return borderPen.Color; }
			set { borderPen.Color = value; }
		}

		[System.ComponentModel.Category("Appearence")]
		public float BorderSize
		{
			get { return owner.Metric.Reverse(borderPen.Width); }
			set { borderPen.Width = owner.Metric.Convert(value); }
		}

		/// <summary>
		/// Background Brush
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		[Browsable(false), ReadOnly(true)]
		public Brush BackgroundBrush
		{
			get { return backgroundBrush; }
			set { backgroundBrush = value; }
		}

		[System.ComponentModel.Category("Appearence")]
		public Color BackgroundColor
		{
			get
			{
				SolidBrush brush = backgroundBrush as SolidBrush;

				return brush != null ? brush.Color : Color.Empty;
			}
			set { backgroundBrush = new SolidBrush(value); }
		}

		/// <summary>
		/// Location of printable item
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public RectangleF Location
		{
			get { return owner.Location; }
			set { owner.Location = value; }
		}

		/// <summary>
		/// Print an object data
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public void Print(Graphics g, object obj)
		{
			if (!showBorder)
				return;

			// First, set unit of measure to milimiters
			g.PageUnit = GraphicsUnit.Millimeter;

			if (backgroundBrush != null)
				g.FillRectangle(backgroundBrush, Location);

			g.DrawRectangle(borderPen, Location.Left, Location.Top, Location.Width, Location.Height);
		}

		/// <summary>
		/// Redraws border, ensuring it is visible.
		/// </summary>
		public void EnsureBorderVisible(Graphics g, object obj)
		{
			if (showBorder)
				g.DrawRectangle(borderPen, Location.Left, Location.Top, Location.Width, Location.Height);
		}

		#region ICloneable Members

		public object Clone()
		{
			Border clone = new Border();

			clone.borderPen = (Pen) borderPen.Clone();
			clone.backgroundBrush = (Brush) backgroundBrush.Clone();
			clone.showBorder = showBorder;

			return clone;
		}

		#endregion

		/// <summary>
		/// Set properties to pageLayout's default.
		/// </summary>
		/// <param name="pageLayout">PageLayout containing default properties</param>
		public void SetDefault(ILayout pageLayout)
		{
		}

		/// <summary>
		/// Metric used
		/// </summary>
		public Metric Metric
		{
			get { return (owner != null ? owner.Metric : null); }
			set { if (owner != null) owner.Metric = value; }
		}

		/// <summary>
		/// Design mode
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public bool DesignMode
		{
			get { return owner.DesignMode; }
			set { owner.DesignMode = value; }
		}

		/// <summary>
		/// Configure layout from xml
		/// </summary>
		public virtual void FromXml(XmlElement element, IDictionary typeDictionary)
		{
			this.BorderPen		 = DocumentLayout.CreatePenFromXml(element["BorderPen"]);
			this.BackgroundBrush = DocumentLayout.CreateBrushFromXml(element["BackgroundBrush"]);

			if (element.HasAttribute("Show"))
				this.showBorder = bool.Parse(element.GetAttribute("Show"));
			else
				this.showBorder = true;
		}

		/// <summary>
		/// Save printable item into a xml element
		/// </summary>
		public void SaveXml(XmlDocument doc, XmlElement element)
		{
			XmlElement pen, brush;

			pen = doc.CreateElement("BorderPen");
			PageLayout.SaveXmlPen(doc, pen, this.borderPen);
			element.AppendChild(pen);

			brush = doc.CreateElement("BackgroundBrush");
			PageLayout.SaveXmlBrush(doc, brush, this.backgroundBrush);
			element.AppendChild(brush);

			element.SetAttribute("Show", showBorder.ToString());
		}

		[System.ComponentModel.Category("Appearence")]
		public bool ShowBorder
		{
			get { return showBorder; }
			set { showBorder = value; }
		}
	}
}
