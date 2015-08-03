/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Xml;
using System.ComponentModel;

namespace Report.Layout.Complex
{
	[Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
	public abstract class PrintableItem : IPrintableItem
	{
		private RectangleF	location = new RectangleF(0, 0, 5, 5);
		private Metric		metric = new MetricCentimeter();

		// Design mode
		private bool		designMode = false;

//		public delegate void DesignChangeHandler(PrintableItem item);
//		public event DesignChangeHandler DesignChanged;
//
		/// <summary>
		/// Location of printable item. This is measured in milimiters, ready for
		/// drawing. To use unit of measure defined by user, use Top, Left, Width
		/// and Height properties.
		/// </summary>
		[System.ComponentModel.Category("Layout")]
		[System.ComponentModel.Browsable(false)]
		public System.Drawing.RectangleF Location
		{
			get { return location; }
			set { location = value; ChangingLocation(); }
		}

		#region Location properties

		public float Top
		{
			get { return metric.Reverse(location.Y); }
			set { location.Y = metric.Convert(value); ChangingLocation(); }
		}

		public float Left
		{
			get { return metric.Reverse(location.X); }
			set { location.X = metric.Convert(value); ChangingLocation(); }
		}

		public float Width
		{
			get { return metric.Reverse(location.Width); }
			set { location.Width = metric.Convert(value); ChangingLocation(); }
		}

		public float Height
		{
			get { return metric.Reverse(location.Height); }
			set { location.Height = metric.Convert(value); ChangingLocation(); }
		}

		protected virtual void ChangingLocation()
		{
			return;
		}

		#endregion

		/// <summary>
		/// Print an object data
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public abstract void Print(System.Drawing.Graphics g, object obj);

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
		}

		/// <summary>
		/// Set properties to pageLayout's default.
		/// </summary>
		/// <param name="pageLayout">PageLayout containing default properties</param>
		public virtual void SetDefault(ILayout pageLayout)
		{
			metric = pageLayout.DefaultMetric;
		}

		/// <summary>
		/// Metric used
		/// </summary>
		[System.ComponentModel.Category("Layout")]
		public Metric Metric
		{
			get { return metric; }
			set { metric = value; }
		}

		/// <summary>
		/// Design mode
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public virtual bool DesignMode
		{
			get { return designMode; }
			set { designMode = value; }
		}

		protected static float GetFactorConvert(GraphicsUnit unit)
		{
			switch (unit)
			{
				case GraphicsUnit.Millimeter:
					return 25.4f;

				case GraphicsUnit.Inch:
					return 1f;

				default:
					throw new NotImplementedException("Cannot convert to unit of measure");
			}
		}
	}
}
