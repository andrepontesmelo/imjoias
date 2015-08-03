/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

namespace Report.Layout.Simple
{
	public abstract class Section
	{
		// Leiaute
		protected Font		font;
		protected Brush		brush;

		/// <summary>
		/// Constructor
		/// </summary>
		public Section()
		{
			font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
			brush = Brushes.Black;
		}
		
		/// <summary>
		/// Print section
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public abstract void Print(Graphics g, ref RectangleF area, IList columns, int page);

		/// <summary>
		/// Measure height
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public abstract float MeasureHeight(Graphics g, RectangleF area, IList columns, int page);

		/// <summary>
		/// Font
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public Font Font
		{
			get { return font; }
			set { font = value; }
		}

		/// <summary>
		/// Prepare to print
		/// </summary>
		public virtual void PreparePrinting(SimpleLayout sender, PrintEventArgs e)
		{
			// Do nothing
		}

		/// <summary>
		/// Print before data
		/// </summary>
		public abstract bool PrintBeforeData { get;	}

		/// <summary>
		/// Print after data
		/// </summary>
		public abstract bool PrintAfterData { get; }
	}
}