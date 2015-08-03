/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace Report.Layout.Simple
{
	/// <summary>
	/// Sum of data columns
	/// </summary>
	public sealed class Sum : SectionVersátil
	{
		// Constantes
		private const float		distance = 0.393f * 50;
		private const float		margin = 0.393f * 30;
		private const float		lineDistance = 0.393f * 10;
		private const string	totalString = "Total";

		// Relacionamentos
		private SimpleLayout	layout;

		// Leiaute
		private Pen				penLine;

		// Tempo de execução (runtime)
		private int				_columns;

		/// <summary>
		/// Constructor
		/// </summary>
		public Sum()
		{
			font = new Font(font, FontStyle.Bold | FontStyle.Italic);
			penLine = new Pen(
				new System.Drawing.Drawing2D.HatchBrush(
				System.Drawing.Drawing2D.HatchStyle.SmallGrid,
				Color.Black, Color.White));
		}

		#region Where to print this section

		public override bool PrintBeforeData
		{
			get { return false; }
		}

		public override bool PrintAfterData
		{
			get { return true; }
		}

		#endregion

		public override void PreparePrinting(SimpleLayout sender, PrintEventArgs e)
		{
			_columns = 0;

			// Check which column is going to be sum
			foreach (Column column in sender.Columns)
				if (column.ToSum)
					_columns++;

			layout = sender;

			if (_columns == 0)
				this.printCompleted = true;
		}

		/// <summary>
		/// Check if sum should be printed
		/// </summary>
		/// <returns>Sum should be printed</returns>
		private bool AuthPrinting()
		{
			return _columns > 0 && layout.ElementCounter == layout.Objects.Count && !printCompleted;
		}

		/// <summary>
		/// Print section
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override void Print(System.Drawing.Graphics g, ref System.Drawing.RectangleF area, System.Collections.IList columns, int page)
		{
			float lineY;
			float x;				// Position
			SizeF size;

			// Check if this section should be printed
			if (!AuthPrinting())
				return;

			// Check if there is enough space
			if (area.Y + MeasureHeight(g, area, columns, page) >= area.Bottom)
				return;

			// Set positions and sizes
			area.Y			+= distance;
			area.Height		-= distance;
			lineY			 = (float) area.Y + font.GetHeight(g) / 2;
			size			 = g.MeasureString(totalString, font);
			x				 = area.Left + (area.Width - size.Width) / 2;

			// Draw text
			g.DrawString(
				"Total",
				font,
				brush,
				x,
				area.Y);
					
			// Draw lines
			g.DrawLine(
				penLine,
				area.Left,
				lineY,
				x - lineDistance,
				lineY);

			g.DrawLine(
				penLine,
				x + lineDistance + size.Width,
				lineY,
				area.Right,
				lineY);

			// Print sum
			area.Y		+= font.GetHeight(g);
			area.Height -= font.GetHeight(g);

			foreach (Column column in layout.Columns)
				if (column.ToSum)
					column.PrintData(
						g,
						String.Format(
							column.FormatProvider,
							column.Format,
							column.SumTotal),
						area.Y);

			this.printCompleted = true;
		}

		/// <summary>
		/// Measure height
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override float MeasureHeight(Graphics g, RectangleF area, IList columns, int page)
		{
			float height = 0;

			// Check if this section should be printed
			if (!AuthPrinting())
				return 0;

			// Get greatest height
			foreach (Column column in layout.Columns)
				if (column.ToSum)
					height = System.Math.Max(
						height,
						column.Font.GetHeight(g));

			return height +
				distance +
				font.GetHeight(g);
		}
	}
}
