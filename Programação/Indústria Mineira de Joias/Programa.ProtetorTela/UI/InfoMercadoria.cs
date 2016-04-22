using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Álbum;
using System.Threading;
using Entidades.Mercadoria;

namespace Programa.ProtetorTela.UI
{
    class InfoMercadoria : IDisposable
    {
        private Foto foto;
        private string descrição;

        private Bitmap picture;

        //private System.Windows.Forms.Timer fadeTimer;
        private Point location;
        private Size size;
        private Point descriptionLocation;
        private Size descriptionSize;

        private int textAlpha = 0;
        //private int textAlphaDelta = 30;
        private int textAlphaMax = 200;

        private Color backColor;
        private Color borderColor;
        private Color foreColor;
        private Color descriptionForeColor;

        private Color lineColor;
        private float lineWidth;
        private Rectangle textRect;

        public Point Location { get { return location; } set { location = value; } }
        public Size Size { get { return size; } set { size = value; } }

        public Point DescriptionLocation { get { return descriptionLocation; } set { descriptionLocation = value; } }
        public Size DescriptionSize { get { return descriptionSize; } set { descriptionSize = value; } }

        public Color DescriptionForeColor { get { return descriptionForeColor; } set { descriptionForeColor = value; } }
        public Color ForeColor { get { return foreColor; } set { foreColor = value; } }
        public Color BackColor { get { return backColor; } set { backColor = value; } }
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }

        public float LineWidth { get { return lineWidth; } set { lineWidth = value; } }
        public Color LineColor { get { return lineColor; } set { lineColor = value; } }

        //public System.Windows.Forms.Timer FadeTimer { get { return fadeTimer; } }

        private Font textFont = new Font("Microsoft Sans Serif", 16, GraphicsUnit.Pixel);
        private Font titleFont = new Font("Microsoft Sans Serif", 24, GraphicsUnit.Pixel);

        //public event EventHandler FadingComplete;

        public InfoMercadoria(Foto mercadoria)
        {
            this.foto = mercadoria;

            //fadeTimer = new System.Windows.Forms.Timer();
            //fadeTimer.Tick += new EventHandler(scrollTimer_Tick);
            //fadeTimer.Enabled = true;
            //fadeTimer.Start();

            textAlpha = textAlphaMax;

            PrepararDescrição();
        }

        /// <summary>
        /// Prepara descrição para exibição.
        /// </summary>
        private void PrepararDescrição()
        {
            if (foto.Peso.HasValue)
                descrição = String.Format(
                    "{0}\nPeso: {1} g\n\n",
                    foto.ReferênciaFormatada,
                    foto.Peso.Value);
            else
                descrição = String.Format(
                    "{0}\n\n",
                    foto.ReferênciaFormatada);

            if (foto.Descrição.Trim().Length == 0)
            {
                Mercadoria mercadoria = Mercadoria.ObterMercadoria(foto.ReferênciaFormatada, Entidades.Tabela.TabelaPadrão);

                descrição += mercadoria.Descrição;
            }
            else
                descrição += foto.Descrição;
        }

        public void Paint(PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            // Settings to make the text drawing look nice
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            DrawBackground(g);
            DrawPicture(g);
            DrawTitle(g);
            DrawDescription(g);
        }

        /// <summary>
        /// Draws a title bar.
        /// </summary>
        /// <param name="g">The Graphics object to draw onto</param>
        private void DrawTitle(Graphics g)
        {
            //Point titleLocation = new Point(Location.X + padding, Location.Y + Size.Height - (RowHeight) - padding);
            //Size titleSize = new Size(Size.Width - (2 * padding), 2 * RowHeight);
            //Rectangle titleRectangle = new Rectangle(titleLocation, titleSize);

            // Draw the title box and the selected item box
            //using (Brush titleBackBrush = new SolidBrush(TitleBackColor))
            //{
            //    g.FillRectangle(titleBackBrush, titleRectangle);
            //}

            // Draw the title text
            StringFormat titleFormat = new StringFormat(StringFormatFlags.LineLimit);

            titleFormat.Alignment = StringAlignment.Far;
            titleFormat.Trimming = StringTrimming.EllipsisCharacter;

            //using (Brush titleBrush = new SolidBrush(TitleForeColor))
            using (Brush titleBrush = new SolidBrush(Color.FromArgb(textAlpha, Color.Goldenrod)))
            {
                SizeF tamanho = g.MeasureString(foto.ReferênciaFormatada, titleFont);
                g.DrawString(foto.ReferênciaFormatada, titleFont, titleBrush, Location.X - 8 + Size.Width, Location.Y - 8 + Size.Height - tamanho.Height, titleFormat);
            }
        }

        private void DrawDescription(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Determine the placement of the lines that will be placed 
            // above and below the text
            float lineLeftX = DescriptionSize.Width / 4;
            float lineRightX = 3 * DescriptionSize.Width / 4;
            int lineVerticalBuffer = DescriptionSize.Height / 50;
            float lineTopY = DescriptionLocation.Y + lineVerticalBuffer;
            float lineBottomY = DescriptionLocation.Y + DescriptionSize.Height - lineVerticalBuffer;

            // Draw the two lines
            using (Pen linePen = new Pen(lineColor, lineWidth))
            {
                g.DrawLine(linePen, DescriptionLocation.X + lineLeftX, lineTopY, DescriptionLocation.X + lineRightX, lineTopY);
                g.DrawLine(linePen, DescriptionLocation.X + lineLeftX, lineBottomY, DescriptionLocation.X + lineRightX, lineBottomY);
            }

            // Draw the text of the article
            using (StringFormat textFormat = new StringFormat(StringFormatFlags.LineLimit))
            {
                textFormat.Alignment = StringAlignment.Near;
                textFormat.LineAlignment = StringAlignment.Near;
                textFormat.Trimming = StringTrimming.EllipsisWord;
                int textVerticalBuffer = 4 * lineVerticalBuffer;
                textRect = new Rectangle(DescriptionLocation.X, DescriptionLocation.Y + textVerticalBuffer, DescriptionSize.Width, DescriptionSize.Height - (2 * textVerticalBuffer));
                using (Brush textBrush = new SolidBrush(Color.FromArgb(Math.Min(textAlpha * 4, 255), DescriptionForeColor)))
                {
                    g.DrawString(descrição, textFont, textBrush, textRect, textFormat);
                }
            }
        }

        private void DrawPicture(Graphics g)
        {
            if (picture == null)
                picture = Entidades.Álbum.Foto.Redesenhar(foto.Imagem, Size.Width - 8, Size.Height - 8);

            g.DrawImageUnscaled(
                picture,
                Location.X + 4,
                Location.Y + 4);
        }

        /// <summary>
        /// Draws a box and border ontop of which the text of the items can be drawn.
        /// </summary>
        /// <param name="g">The Graphics object to draw onto</param>
        private void DrawBackground(Graphics g)
        {
            using (Brush backBrush = new SolidBrush(BackColor))
            {
                using (Pen borderPen = new Pen(BorderColor, 4))
                {
                    g.FillRectangle(backBrush, new Rectangle(Location.X + 4, Location.Y + 4, Size.Width - 8, Size.Height - 8));
                    g.DrawRectangle(borderPen, new Rectangle(Location, Size));
                }
            }

            using (Brush backBrush = new SolidBrush(Color.FromArgb(
                Math.Min(255, textAlpha * 6), Color.White)))
            {
                g.FillRectangle(backBrush, new Rectangle(Location.X + 4, Location.Y + 4, Size.Width - 8, Size.Height - 8));
            }
        }

        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            //// Change the alpha value of the text being drawn
            //// Moves up until it reaches textAlphaMax and then moves down
            //// Moves to the next article when it gets back to zero
            //textAlpha += textAlphaDelta;

            //if (textAlpha >= textAlphaMax)
            //{
            //    textAlphaDelta *= -1;
            //}
            //else if (textAlpha <= 0)
            //{
            //    FadingComplete(this, new EventArgs());
            //    textAlpha = 0;
            //    textAlphaDelta *= -1;
            //}
        }

        public void Dispose()
        {
            //fadeTimer.Dispose();
        }
    }
}
