/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;

namespace Report.Layout.Simple
{
	public class Title : Section
	{
		private string		title = null;
		private float		spaceBefore = 0.393f * 30;
		private float		spaceAfter = 0.393f * 60;
		private bool		onlyOnFirstPage = true;

		/// <summary>
		/// Constructor
		/// </summary>
		public Title()
		{
			this.font = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
		}

        /// <summary>
        /// Constructor
        /// </summary>
        public Title(string text)
        {
            this.font = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
            Text = text;
        }

        #region Where this section should be printed

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
		/// Document's Title
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		[System.ComponentModel.DefaultValue(typeof(string), null)]
		public string Text
		{
			get { return title; }
			set { title = value; }
		}

		/// <summary>
		/// Print only on first page
		/// </summary>
		[System.ComponentModel.DefaultValue(true)]
		[System.ComponentModel.Category("Layout")]
		public bool OnlyOnFirstPage
		{
			get { return onlyOnFirstPage; }
			set { onlyOnFirstPage = value; }
		}

		/// <summary>
		/// Space before title
		/// </summary>
		[System.ComponentModel.DefaultValue(0.393f * 60)]
		[System.ComponentModel.Category("Layout")]
		public float SpaceBefore
		{
			get { return spaceBefore; }
			set { spaceBefore = value; }
		}

		/// <summary>
		/// Space after title
		/// </summary>
		[System.ComponentModel.Category("Layout")]
		[System.ComponentModel.DefaultValue(0.393f * 60)]
		public float SpaceAfter
		{
			get { return spaceAfter; }
			set { spaceAfter = value; }
		}

		/// <summary>
		/// Measure height
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override float MeasureHeight(Graphics g, RectangleF area, IList columns, int page)
		{
			if (page > 1 && onlyOnFirstPage)
				return 0;

			return g.MeasureString(title, font, (int) area.Width).Height + spaceBefore + spaceAfter;
		}

		/// <summary>
		/// Prepare to print
		/// </summary>
		public override void PreparePrinting(SimpleLayout sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (title == null)
				title = sender.Document.DocumentName;
		}

		/// <summary>
		/// Print section
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="area">Area where to print</param>
		/// <param name="columns">Columns</param>
		public override void Print(Graphics g, ref RectangleF area, System.Collections.IList columns, int page)
		{
			StringFormat stringFormat;

			// Verificar se deve ser impresso o title
			if (page > 1 && onlyOnFirstPage)
				return;

			// Construir formato da string
			stringFormat = new StringFormat(StringFormat.GenericDefault);
			stringFormat.Alignment = StringAlignment.Center;
			
			area.Y += spaceBefore;
			area.Height -= spaceBefore;

			// Desenhar
			g.DrawString(
				title,
				font,
				brush,
				area,
				stringFormat);

			// Recalcular area
			float height = MeasureHeight(g, area, columns, page);

			area.Y += height - spaceBefore;
			area.Height -= height - spaceBefore;
		}
	}
}
