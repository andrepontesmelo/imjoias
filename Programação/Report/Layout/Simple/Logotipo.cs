/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;

namespace Report.Layout.Simple
{
	/// <summary>
	/// Summary description for Logotipo.
	/// </summary>
	public class Logotipo : Section
	{
		private Image		image = null;
		private float		spaceBefore = 0.393f * 30;
		private float		spaceAfter = 0.393f * 60;
		private bool		onlyOnFirstPage = true;

		[System.ComponentModel.DefaultValue(typeof(Image), null)]
		public Image Image
		{
			get { return image; }
			set { image = value; }
		}

		/// <summary>
		/// Prints only on first page
		/// </summary>
		[System.ComponentModel.DefaultValue(true)]
		public bool OnlyOnFirstPage
		{
			get { return onlyOnFirstPage; }
			set { onlyOnFirstPage = value; }
		}

		/// <summary>
		/// Space before
		/// </summary>
		[System.ComponentModel.DefaultValue(0.393f * 60)]
		public float SpaceBefore
		{
			get { return spaceBefore; }
			set { spaceBefore = value; }
		}

		/// <summary>
		/// Space after
		/// </summary>
		[System.ComponentModel.DefaultValue(0.393f * 60)]
		public float SpaceAfter
		{
			get { return spaceAfter; }
			set { spaceAfter = value; }
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
		/// Measure height
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override float MeasureHeight(Graphics g, RectangleF area, IList columns, int page)
		{
			if (image == null || (page > 1 && onlyOnFirstPage))
				return 0;

			return spaceBefore + image.Height + spaceAfter;
		}

		/// <summary>
		/// Print logotype
		/// </summary>
		public override void Print(Graphics g, ref RectangleF area, System.Collections.IList columns, int page)
		{
			if (image == null || (page > 1 && onlyOnFirstPage))
				return;
			
			area.Y      += spaceBefore;
			area.Height -= spaceBefore;

			// Draw on center
			g.DrawImage(image, area.Y, area.Width / 2 + area.Left - image.Width / 2);

			area.Y		+= image.Height + spaceAfter;
			area.Height -= image.Height + spaceAfter;
		}
	}
}
