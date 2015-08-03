/************************************************************
 * Developped by J�lio C�sar e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;

namespace Report.Layout.Simple
{
	/// <summary>
	/// Summary description for Footer.
	/// </summary>
	public class Footer : Section
	{
		// Constantes
		public const float  lineDistance = 0.393f;
		protected string	   pageLabel = "P�gina";

        //// Relacionamento
        //private SimpleLayout	layout;

//		// Runtime
//		private bool			_somat�rios = false;
//		private itn				_somat�rioLines = 0;
		
        ///// <summary>
        ///// Constructor
        ///// </summary>
        //public Footer(SimpleLayout layout)
        //{
        //    this.layout = layout;
        //}

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

		/// <summary>
		/// Print footer
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override void Print(Graphics g, ref RectangleF areaRef, IList columns, int page)
		{
			StringFormat stringFormat;
			RectangleF area;
			float height;

			stringFormat = new StringFormat(StringFormat.GenericDefault);
			stringFormat.Alignment = StringAlignment.Center;

			height = MeasureHeight(g, areaRef, columns, page);

			// Posicionar no final da page
			area = areaRef;
			area.Y += area.Height - height;
			area.Height = height;
			areaRef.Y -= height;

			// Desenhar line
			area.Y += lineDistance;
			area.Height -= lineDistance;

			g.DrawLine(
				Pens.Black,
				area.Left,
				area.Top,
				area.Right,
				area.Top);

			area.Y += lineDistance;

//			// Escrever somat�rio, se houver
//			if (_somat�rios)
//			{
//				if (page > 1)
//				{
//					g.DrawString(
//				}
//
//				// Desenhar line
//				area.Y += lineDistance;
//
//				g.DrawLine(
//					Pens.Black,
//					area.Left,
//					area.Top,
//					area.Right,
//					area.Top);
//
//				area.Y += lineDistance;
//			}

			// Draw
			g.DrawString(
                pageLabel + " " + page.ToString(),
				font,
				brush,
				area,
				stringFormat);
		}

		/// <summary>
		/// Measure height
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override float MeasureHeight(Graphics g, RectangleF area, IList columns, int page)
		{
			StringFormat stringFormat;
			stringFormat = new StringFormat(StringFormat.GenericDefault);
			float height;
			float columnHeight = font.GetHeight(g);

			height = font.GetHeight(g) + lineDistance * 2;

//			// Verificar se h� somat�rios e a page � maior que 1
//			if (page == 1)
//			{
//				_somat�rios = false;
//
//				foreach (Column column in columns)
//					if (column.Somar)
//					{
//						_somat�rios = true;
//						columnHeight = Math.Max(columnHeight, column.Fonte.GetHeight(g));
//					}
//			}
//
//			if (_somat�rios)
//			{
//				_somat�rioLines = ((Column) columns[0]).Somar ? 2 : 1;
//
//				if (page == 1)
//					height += columnHeight * _somat�rioLines;
//				else
//					height += columnHeight * 2 * _somat�rioLines;
//
//				height += + lineDistance * 2;
//			}

			return height;
		}
	}
}
