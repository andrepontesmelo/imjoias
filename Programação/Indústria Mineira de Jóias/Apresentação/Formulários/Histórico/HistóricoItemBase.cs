using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Apresentação.Formulários.Histórico
{
    public abstract class HistóricoItemBase : IHistóricoItem
    {
        /// <summary>
        /// Localização do item no controle.
        /// </summary>
        private RectangleF localização;

        #region Propriedades

        public abstract DateTime Registro
        {
            get;
        }

        public abstract string Autor
        {
            get;
        }

        public System.Drawing.RectangleF Localização
        {
            get { return localização; }
            set { localização = value; }
        }

        public float Largura
        {
            get
            {
                return localização.Width;
            }
            set
            {
                localização.Width = value;
            }
        }

        public float Altura
        {
            get { return localização.Height; }
        }

        public System.Drawing.PointF Posição
        {
            get
            {
                return localização.Location;
            }
            set
            {
                localização.Location = value;
            }
        }

        public abstract string Texto
        {
            get;
        }

        #endregion

        /// <summary>
        /// Desenha o item do histórico.
        /// </summary>
        public virtual void Desenhar(System.Drawing.Graphics g)
        {
            SizeF tTamanhoData, tTamanhoAutor, tTamanhoTexto;
            bool outraLinha = false;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (Font tFonte = new Font(
                FontFamily.GenericSansSerif, 12,
                FontStyle.Bold, GraphicsUnit.Pixel))
            {
                Brush tBrush = Brushes.OliveDrab;
                string strData = Registro.ToLongDateString();

                g.DrawString(
                    strData,
                    tFonte, tBrush, localização.Location);

                tTamanhoData = g.MeasureString(strData, tFonte);
                tTamanhoAutor = g.MeasureString(Autor, tFonte);

                if (tTamanhoData.Width + tTamanhoAutor.Width < Largura)
                    g.DrawString(
                        Autor,
                        tFonte, tBrush,
                        localização.Width - tTamanhoAutor.Width,
                        localização.Top);
                else
                {
                    g.DrawString(
                        Autor,
                        tFonte, tBrush,
                        localização.X,
                        localização.Y + tTamanhoData.Height);

                    outraLinha = true;
                }
            }

            //using (Pen tPen = new Pen(Color.FromArgb(128, Color.White))
            //{
            //    g.DrawLine(tPen, localização.X, tTamanhoAutor.Height + localização.Y,
            //        localização.Right, tTamanhoAutor.Height + localização.Y);
            //}

            using (Pen tPen = new Pen(Color.FromArgb(128, Color.White)))
            {
                g.DrawLine(tPen, localização.X, tTamanhoAutor.Height + localização.Y + 1,
                    localização.Right, tTamanhoAutor.Height + localização.Y + 1);
            }

            using (Font txtFonte = new Font(
               FontFamily.GenericSansSerif, 12, GraphicsUnit.Pixel))
            {
                Brush txtBrush = Brushes.Black;

                using (StringFormat formato = new StringFormat(StringFormatFlags.LineLimit))
                {
                    formato.Alignment = StringAlignment.Near;
                    formato.LineAlignment = StringAlignment.Near;
                    formato.Trimming = StringTrimming.EllipsisWord;

                    tTamanhoTexto = g.MeasureString(
                        Texto,
                        txtFonte, new SizeF(
                        localização.Width, float.PositiveInfinity),
                        formato);

                    if (!outraLinha)
                    {
                        g.DrawString(
                            Texto,
                            txtFonte, txtBrush,
                            new RectangleF(
                            localização.Left, localização.Top + tTamanhoData.Height + 3,
                            localização.Width, tTamanhoTexto.Height),
                            formato);

                        localização.Height = tTamanhoData.Height + tTamanhoTexto.Height + 3;
                    }
                    else
                    {
                        g.DrawString(
                            Texto,
                            txtFonte, txtBrush,
                            new RectangleF(
                            localização.Left, localização.Top + tTamanhoAutor.Height + tTamanhoData.Height + 3,
                            localização.Width, tTamanhoTexto.Height),
                            formato);
                        
                        localização.Height = tTamanhoData.Height + tTamanhoAutor.Height + tTamanhoTexto.Height + 3;
                    }
                }
            }
        }
    }
}
