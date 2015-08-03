/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace Report.Layout.Simple
{
	public class Line
	{
		private CollectionColumns	columns;

		/// <summary>
		/// Construct a line
		/// </summary>
		public Line()
		{
			columns = new CollectionColumns(this);
		}

		/// <summary>
		/// Calculates the data printed size
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="obj">Object that contains data to be printed</param>
		/// <returns>Area needed to print data</returns>
		public SizeF MeasureDataPrint(Graphics g, object obj)
		{
			SizeF size = new SizeF(0 , 0);

			foreach (Column column in columns)
			{
				SizeF columnSize;

				columnSize = column.MeasureDataPrint(g, obj);

				if (size.Height < columnSize.Height)
					size.Height = columnSize.Height;
				
				if (size.Width < columnSize.Width + column.X)
					size.Width = columnSize.Width + column.X;
			}

			return size;
		}

		/// <summary>
		/// Print a line of data
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="obj">Object that contains data to be printed</param>
		/// <param name="y">Absolute Y position</param>
		public void Print(Graphics g, object obj, float y)
		{
			foreach (Column column in columns)
				column.Print(g, obj, y);
		}

		/// <summary>
		/// Columns to be printed
		/// </summary>
		public CollectionColumns Columns
		{
			get { return columns; }
		}
	}
}
