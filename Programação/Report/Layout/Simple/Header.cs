/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;

namespace Report.Layout.Simple
{
	/// <summary>
	/// Header containg columns label
	/// </summary>
	public sealed class Header : Section
	{
		// Constants
		private const float lineDistance = 0.393f;

		// Layout
		private Pen			pen = Pens.Black;

		/// <summary>
		/// Constructor
		/// </summary>
		public Header()
		{
			font = new Font(font, FontStyle.Bold);
		}

		#region Where to print this section

		public override bool PrintBeforeData
		{
			get { return true; }
		}

		public override bool PrintAfterData
		{
			get { return false; }
		}

		#endregion
		
		/// <summary>
		/// Print header
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override void Print(Graphics g, ref RectangleF area, IList columns, int page)
		{
			StringFormat stringFormat;
			float		 height;

			stringFormat = new StringFormat(StringFormat.GenericDefault);
			height		 = font.GetHeight(g);

			// Write columns label
			foreach (Column column in columns)
			{
				RectangleF rect;

				stringFormat.Alignment = column.Alignment;

				rect = new RectangleF(
					column.X, area.Top,
					column.Width, height);

				g.DrawString(
					column.Label,
					font,
					brush,
					rect,
					stringFormat);
			}

			// Draw separator line
			g.DrawLine(pen, area.Left, area.Top + height + lineDistance, area.Right, area.Top + height + lineDistance);

			area.Y      += height + lineDistance * 2;
			area.Height -= height + lineDistance * 2;
		}

		/// <summary>
		/// Measure height
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override float MeasureHeight(Graphics g, RectangleF area, IList columns, int page)
		{
			return font.GetHeight(g) + lineDistance * 2;
		}
	}
}
