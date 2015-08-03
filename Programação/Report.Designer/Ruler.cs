/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Report.Designer
{
	public class Ruler : System.Windows.Forms.UserControl
	{
		public enum Orientation
		{
			Horizontal,
			Vertical
		};

		// Attributes
		private GraphicsUnit	unit = GraphicsUnit.Inch;
		private Orientation		orientation = Orientation.Horizontal;
		private	float			nearDistance = 0;
		private float			farDistance = 0;
		private Brush			brush = Brushes.Black;
		private Font			font = new Font(FontFamily.GenericSansSerif, 7);

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Ruler()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.SetStyle(ControlStyles.Selectable, false);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Ruler
			// 
			this.Name = "Ruler";
			this.Size = new System.Drawing.Size(232, 24);
			this.Resize += new System.EventHandler(this.Ruler_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Ruler_Paint);

		}
		#endregion

		private void Ruler_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			SizeF textSize;
            PointF paperSize;
            PointF[] vpSize;

			e.Graphics.PageUnit = unit;
            paperSize = new PointF(Width, Height);
            e.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page, System.Drawing.Drawing2D.CoordinateSpace.Device, vpSize = new PointF[] { paperSize });
            paperSize = vpSize[0];

			textSize = e.Graphics.MeasureString("500", font);

			if (orientation == Orientation.Horizontal)
			{
				float y1, y2, y3, y4;

				y1 = (paperSize.Y - textSize.Height) * 0.05f;
                y2 = (paperSize.Y - textSize.Height) * 0.95f;
                y3 = (paperSize.Y - textSize.Height) * 0.30f;
                y4 = (paperSize.Y - textSize.Height) * 0.70f;

				Pen pen = new Pen(brush, 1 / e.Graphics.DpiX);

				for (float i = 0; i < Width * 10; i++)
				{
					if (i % 10 == 0)
					{
						SizeF size = e.Graphics.MeasureString((i / 10).ToString(), font);

						e.Graphics.DrawLine(pen, i, y1, i, y2);
						e.Graphics.DrawString(
							(i / 10).ToString(),
							font, brush,
							i - size.Width / 2,
                            paperSize.Y - size.Height);
					}
					else
						e.Graphics.DrawLine(pen, i, y3, i, y4);
				}
			}
			else
			{
				float x1, x2, x3, x4;

				x1 = (paperSize.X - textSize.Width) * 0.05f;
                x2 = (paperSize.X - textSize.Width) * 0.95f;
                x3 = (paperSize.X - textSize.Width) * 0.30f;
                x4 = (paperSize.X - textSize.Width) * 0.70f;

				Pen pen = new Pen(brush, 1 / e.Graphics.DpiY);

				for (float i = 0; i < Height * 10; i++)
				{
					if (i % 10 == 0)
					{
						SizeF size = e.Graphics.MeasureString((i / 10).ToString(), font);

						e.Graphics.DrawLine(pen, x1, i, x2, i);
                        e.Graphics.DrawString(
							(i / 10).ToString(),
							font, brush,
                            paperSize.X - size.Width,
                            i - size.Height / 2);
                    }
					else
						e.Graphics.DrawLine(pen, x3, i, x4, i);
				}
			}
		}

		private void Ruler_Resize(object sender, System.EventArgs e)
		{
			this.Invalidate();
		}

		[DefaultValue(GraphicsUnit.Inch)]
		public GraphicsUnit Unit
		{
			get { return unit; }
			set { unit = value; this.Invalidate(); }
		}

		[DefaultValue(Orientation.Horizontal)]
		public Orientation RulerOrientation
		{
			get { return orientation; }
			set { orientation = value; this.Invalidate();  }
		}

		public float NearDistance
		{
			get { return nearDistance; }
			set { nearDistance = value; this.Invalidate(); }
		}

		public float FarDistance
		{
			get { return farDistance; }
			set { farDistance = value; this.Invalidate(); }
		}

		public static float GetFactorConvert(GraphicsUnit unit)
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

		public static float Convert(int pixel, Graphics g)
		{
			float inchConverter = GetFactorConvert(g.PageUnit);

			return pixel * inchConverter / g.DpiX;
		}

		public float Convert(int pixel)
		{
			using (Graphics g = this.CreateGraphics())
			{
				g.PageUnit = unit;
				return Convert(pixel, g);
			}
		}

		public void SetSize(int hInch)
		{
			using (Graphics g = this.CreateGraphics())
			{
				int size = (int) Math.Round(hInch * g.DpiX / GetFactorConvert(unit)); // * 100 / (int) g.DpiX;

				if (orientation == Orientation.Horizontal)
					Width = size;
				else
					Height = size;
			}
		}
	}
}
