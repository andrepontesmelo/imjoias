using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Apresenta��o.Estat�stica.Windows
{
	public class Legenda : System.Windows.Forms.UserControl
	{
		private Gr�fico		gr�fico = null;
		private Color		corBorda = Color.LightSteelBlue;
		private int			espa�amento = 5;
		private Font		fonte = new Font("Arial", 10);
		private Brush		fonteBrush = Brushes.Black;
		private int			quadradoTamanho = 4;
		private int			distanciamento = 2;
		private bool		autoSize = true;
		private int			colunas = 1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Legenda()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.FromArgb(200, 240, 248, 255);
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
			// Legenda
			// 
			this.BackColor = System.Drawing.Color.AliceBlue;
			this.Name = "Legenda";
			this.Size = new System.Drawing.Size(160, 112);
			this.Resize += new System.EventHandler(this.Legenda_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Legenda_Paint);

		}
		#endregion

		private void Legenda_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			int coluna = 0;
			e.Graphics.DrawRectangle(new Pen(corBorda, 1), 0, 0, Width - 1, Height - 1);

			if (gr�fico == null || gr�fico.Legendas == null)
				return;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

			IDictionary props = gr�fico.PropriedadesDesenho;
			string [] legendas = gr�fico.Legendas;
			int altura = (int) e.Graphics.MeasureString("AjgX", fonte).Height + 1;
			int width = 0, height = 0;

			Rectangle quadrado = new Rectangle(espa�amento, espa�amento, quadradoTamanho, quadradoTamanho);
			PointF legenda = new PointF(
				espa�amento + quadradoTamanho + distanciamento,
				espa�amento + quadradoTamanho / 2 - altura / 2);

			for (int seq = 0; seq < legendas.Length; seq++)
			{
				e.Graphics.FillRectangle(
					(Brush) props["seqBrush" + seq.ToString()],
					quadrado);
				e.Graphics.DrawRectangle(
					(Pen) props["v�rticePen" + seq.ToString()],
					quadrado);

/*				e.Graphics.DrawString(
					legendas[seq],
					fonte,
					(Brush) props["seqBrush" + seq.ToString()],
					legenda.X + 1,
					legenda.Y + 1,
					StringFormat.GenericDefault);
*/
				e.Graphics.DrawString(
					legendas[seq],
					fonte,
					((Pen) props["v�rticePen" + seq.ToString()]).Brush, //fonteBrush,
					legenda,
					StringFormat.GenericDefault);

				legenda.Y += altura;
				quadrado.Y += altura;

				if (colunas > 1 && legenda.Y + altura > Height - distanciamento)
				{
					legenda = new PointF(
						espa�amento + quadradoTamanho + distanciamento + (Width / colunas) * ++coluna,
						espa�amento + quadradoTamanho / 2 - altura / 2);
					quadrado = new Rectangle(
						espa�amento + (Width / colunas) * coluna,
						espa�amento, quadradoTamanho, quadradoTamanho);
				}

				if (autoSize && width < e.Graphics.MeasureString(legendas[seq], fonte).Width)
					width = (int) e.Graphics.MeasureString(legendas[seq], fonte).Width;
			}

			if (autoSize)
			{
				width += (int) (espa�amento + legenda.X);
				height = (int) quadrado.Y - altura + quadradoTamanho + espa�amento;

				if (this.Width != width)
				{
					if ((this.Anchor & AnchorStyles.Right) > 0)
						this.Left += this.Width - width;

					this.Width = width;
				}
				if (this.Height != height)
				{
					if ((this.Anchor & AnchorStyles.Bottom) > 0)
						this.Top += this.Height - height;

					this.Height = height;
				}
			}
		}

		private void Legenda_Resize(object sender, System.EventArgs e)
		{
			this.Invalidate();
		}

		public Gr�fico Gr�fico
		{
			get { return gr�fico; }
			set { gr�fico = value; this.Invalidate(); }
		}

		public Color FundoCor
		{
			get { return BackColor; }
			set { BackColor = value; this.Invalidate(); }
		}

		public Color BordaCor
		{
			get { return corBorda; }
			set { corBorda = value; this.Invalidate(); }
		}

		public int Espa�amento
		{
			get { return espa�amento; }
			set { espa�amento = value; this.Invalidate(); }
		}

		public Font Fonte
		{
			get { return fonte; }
			set { fonte = value; this.Invalidate(); }
		}

		public Brush FonteBrush
		{
			get { return fonteBrush; }
			set { fonteBrush = value; this.Invalidate(); }
		}

		public int QuadradoTamanho
		{
			get { return quadradoTamanho; }
			set { quadradoTamanho = value; this.Invalidate(); }
		}

		public int Distanciamento
		{
			get { return distanciamento; }
			set { distanciamento = value; }
		}

		public bool AjustarTamanhoAutomaticamente
		{
			get { return autoSize; }
			set { autoSize = value; }
		}

		public int Colunas
		{
			get { return colunas; }
			set { colunas = value; }
		}
	}
}
