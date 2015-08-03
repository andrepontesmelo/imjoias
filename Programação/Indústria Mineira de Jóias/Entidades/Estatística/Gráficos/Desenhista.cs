using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Entidades.Estat�stica.Gr�ficos
{
	public enum Estilo
	{
		Linhas, LinhasV�rtices, Barras, Pizza
	}

	[Serializable]
	public abstract class Desenhista
	{
        #region Par�metros

        #region Valores padr�es
        public const int padr�oDist�nciaLegendaY = 5;
        public const int padr�oDist�nciaLegendaX = 5;
        public const double padr�oMinX = 0;
        public const double padr�oMaxX = -1;
        public const double padr�oMaxY = double.MinValue;
        public const double padr�oMinY = double.MaxValue;
        protected string[] r�tulosX;
        #endregion

        protected double [][] dados = null;
        protected int seq��ncias = 0;
        protected int dist�nciaLegendaY = padr�oDist�nciaLegendaY;
        protected int dist�nciaLegendaX = padr�oDist�nciaLegendaX;
        protected string[] legendas;
        protected double maxY = padr�oMaxY;
        protected double minY = padr�oMinY;
        protected double minX = padr�oMinX;
        protected double maxX = padr�oMaxX;
        protected Convers�oValor valorY;
        protected Convers�oValor valorX;

		#endregion

		public Desenhista()
		{
            valorX = new Convers�oValor(Convers�oValorPadr�oX);
            valorY = new Convers�oValor(Convers�oValorPadr�oY);
        }

        public static Desenhista ConstruirDesenhista(Estilo estilo)
        {
            Desenhista desenhista = null;

            switch (estilo)
            {
                case Estilo.Linhas:
                    desenhista = new Gr�ficoLinhas();
                    break;

                case Estilo.LinhasV�rtices:
                    desenhista = new Gr�ficoLinhas();
                    ((Gr�ficoLinhas)desenhista).MostrarV�rtice = true;
                    break;

                case Estilo.Barras:
                    desenhista = new Gr�ficoBarras();
                    break;

                case Estilo.Pizza:
                    desenhista = new Gr�ficoPizza();
                    break;

                default:
                    throw new NotSupportedException();
            }

            return desenhista;
        }

		#region Propriedades padr�o

		/// <summary>
		/// Adquire as propriedades padr�o do desenhista
		/// </summary>
		/// <returns>Propriedades padr�o do desenhista</returns>
		public static Hashtable ObterPropriedades()
		{
			Hashtable props = new Hashtable();

			props["canetaBorda"] = new Pen(Color.FromArgb(181, 171, 117), 1);
			props["fundoBorda"] = null;
			props["eixoFont"] = new Font(FontFamily.GenericSansSerif, 8);
			props["eixoBrush"] = Brushes.Black;
			props["gradePen"] = new Pen(Color.FromArgb(30, 0, 0, 10), 1);
            props["valorFont"] = new Font(FontFamily.GenericSansSerif, 8);
            props["valorBrush"] = Brushes.DarkGray;
            props["legendaFont"] = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
			props["legendaBrush"] = Brushes.Black;
            props["descri��oFont"] = new Font(FontFamily.GenericSansSerif, 8);
			props["descri��oBrush"] = Brushes.Black;

			props["seqPen0"] = new Pen(Color.Orange, 2);
			props["v�rticePen0"] = new Pen(Color.Orange, 1);
			props["v�rticeBrush0"] = new SolidBrush(Color.FromArgb(200, 255, 240, 240));
			props["seqBrush0"] = new SolidBrush(Color.FromArgb(100, Color.Orange));
			props["seqBarraPen0"] = new Pen(Color.Orange, 1);

			props["seqPen1"] = new Pen(Color.Blue, 2);
			props["v�rticePen1"] = new Pen(Color.Blue, 1);
			props["v�rticeBrush1"] = new SolidBrush(Color.FromArgb(200, 240, 240, 255));
			props["seqBrush1"] = new SolidBrush(Color.FromArgb(100, Color.Blue));
			props["seqBarraPen1"] = new Pen(Color.Blue, 1);

			props["seqPen2"] = new Pen(Color.Green, 2);
			props["v�rticePen2"] = new Pen(Color.Green, 1);
			props["v�rticeBrush2"] = new SolidBrush(Color.FromArgb(200, 240, 255, 240));
			props["seqBrush2"] = new SolidBrush(Color.FromArgb(100, Color.Green));
			props["seqBarraPen2"] = new Pen(Color.Green, 1);

			props["seqPen3"] = new Pen(Color.Red, 2);
			props["v�rticePen3"] = new Pen(Color.Red, 1);
			props["v�rticeBrush3"] = new SolidBrush(Color.FromArgb(200, 255, 200, 200));
			props["seqBrush3"] = new SolidBrush(Color.FromArgb(100, Color.Red));
			props["seqBarraPen3"] = new Pen(Color.Red, 1);

			props["seqPen4"] = new Pen(Color.Purple, 2);
			props["v�rticePen4"] = new Pen(Color.Purple, 1);
			props["v�rticeBrush4"] = new SolidBrush(Color.FromArgb(200, 255, 240, 255));
			props["seqBrush4"] = new SolidBrush(Color.FromArgb(100, Color.Purple));
			props["seqBarraPen4"] = new Pen(Color.Purple, 1);

			props["seqPen5"] = new Pen(Color.Teal, 2);
			props["v�rticePen5"] = new Pen(Color.Teal, 1);
			props["v�rticeBrush5"] = new SolidBrush(Color.FromArgb(200, Color.Teal));
			props["seqBrush5"] = new SolidBrush(Color.FromArgb(100, Color.Teal));
			props["seqBarraPen5"] = new Pen(Color.Teal, 1);

			props["seqPen6"] = new Pen(Color.Gray, 2);
			props["v�rticePen6"] = new Pen(Color.Gray, 1);
			props["v�rticeBrush6"] = new SolidBrush(Color.FromArgb(200, Color.Gray));
			props["seqBrush6"] = new SolidBrush(Color.FromArgb(100, Color.Gray));
			props["seqBarraPen6"] = new Pen(Color.Gray, 1);

			props["seqPen7"] = new Pen(Color.Gold, 2);
			props["v�rticePen7"] = new Pen(Color.Gold, 1);
			props["v�rticeBrush7"] = new SolidBrush(Color.FromArgb(200, Color.Gold));
			props["seqBrush7"] = new SolidBrush(Color.FromArgb(100, Color.Gold));
			props["seqBarraPen7"] = new Pen(Color.Gold, 1);

			props["seqPen8"] = new Pen(Color.Violet, 2);
			props["v�rticePen8"] = new Pen(Color.Violet, 1);
			props["v�rticeBrush8"] = new SolidBrush(Color.FromArgb(200, Color.Violet));
			props["seqBrush8"] = new SolidBrush(Color.FromArgb(100, Color.Violet));
			props["seqBarraPen8"] = new Pen(Color.Violet, 1);

			props["seqPen9"] = new Pen(Color.Brown, 2);
			props["v�rticePen9"] = new Pen(Color.Brown, 1);
			props["v�rticeBrush9"] = new SolidBrush(Color.FromArgb(200, Color.Brown));
			props["seqBrush9"] = new SolidBrush(Color.FromArgb(100, Color.Brown));
			props["seqBarraPen9"] = new Pen(Color.Brown, 1);

			int sinal = -1;

			for (int i = 10; i <= 100; i++)
			{
				if (i % 10 == 0)
					sinal *= -1;

				Color cor = ((Pen) props["seqPen" + ((int)(i % 10)).ToString()]).Color;

				byte r, g, b;

				r = (byte) Math.Max((Math.Max(cor.B, cor.G) / 2 + cor.R / 2 * sinal) % 255, 0);
				g = (byte) Math.Max((Math.Min(cor.R, cor.B) / 2 + cor.G / 2 * sinal) % 255, 0);
				b = (byte) Math.Max((Math.Min(cor.R, cor.G) / 2 + cor.B / 2 * sinal) % 255, 0);

				cor = Color.FromArgb(r, g, b);

				props["seqPen" + i.ToString()] = new Pen(cor, 2);
				props["v�rticePen" + i.ToString()] = new Pen(cor, 1);
				props["v�rticeBrush" + i.ToString()] = new SolidBrush(Color.FromArgb(200, cor));
				props["seqBrush" + i.ToString()] = new SolidBrush(Color.FromArgb(100, cor));
				props["seqBarraPen" + i.ToString()] = new Pen(cor, 1);
			}

			return props;
		}


		#endregion

		/// <summary>
		/// Constr�i um Bitmap contendo o gr�fico solicitado
		/// </summary>
		public Bitmap Desenhar(int width, int height, IDictionary props)
		{
			try
			{
                return PlotarGr�fico(width, height, props);
			}
			catch (Exception e)
			{
				Bitmap bmp = new Bitmap(width, height);

				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.FillRectangle(Brushes.White, 0, 0, width, height);
					g.DrawLine(Pens.Red, 0, 0, width - 1, height - 1);
					g.DrawLine(Pens.Red,width - 1, 0, 0, height - 1);
					g.DrawRectangle(Pens.Black, 0, 0, width, height);

					g.DrawString(e.ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.White,
						new RectangleF(5, 5, width - 6, height - 6));
					g.DrawString(e.ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Blue,
						new RectangleF(6, 6, width - 5, height - 5));
				}

				return bmp;
			}
		}

        protected abstract Bitmap PlotarGr�fico(int width, int height, IDictionary props);

		#region Propriedades

        public string[] R�tulosX
        {
            get { return r�tulosX; }
            set { r�tulosX = value; }
        }

        public double MinX
        {
            get { return minX; }
            set { minX = value; }
        }

        public double MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }

        public Convers�oValor ValorX
        {
            get { return valorX; }
            set { valorX = (value == null ? new Convers�oValor(Convers�oValorPadr�oX) : value); }
        }

        public Convers�oValor ValorY
        {
            get { return valorY; }
            set { valorY = (value == null ? new Convers�oValor(Convers�oValorPadr�oY) : value); }
        }

		public string [] Legendas
		{
			get { return legendas; }
			set { legendas = value; }
		}

        /// <summary>
        /// Matriz contendo seq��ncia e valores.
        /// </summary>
		public double [][] Dados
		{
			get { return dados; }
			set
			{
				if (value == null)
					return;

				dados = (double [] []) value.Clone();

                AoAtribuirDados();

				seq��ncias = dados.Length;
			}
		}

        protected virtual void AoAtribuirDados()
        {
            foreach (double[] vetor in dados)
            {
                foreach (double valor in vetor)
                {
                    if (maxY < valor)
                        maxY = valor;

                    if (minY > valor)
                        minY = valor;
                }

                if (maxX < vetor.Length)
                    maxX = vetor.Length - 1;
            }
        }

        /// <summary>
        /// Vetor contendo valores da �nica seq��ncia de dados.
        /// </summary>
		public double [] Vetor�nico
		{
			get { return dados != null ? dados[0] : null; }
			set
			{
				if (value == null)
					return;

				dados = new double[1][];
				dados[0] = (double []) value.Clone();

				seq��ncias = 1;

                AoAtribuirDados();
			}
		}

		public int Seq��ncias
		{
			get { return seq��ncias; }
		}

		#endregion

		/// <summary>
		/// Calcula dist�ncia entre dois pontos
		/// </summary>
		protected static float Dist�ncia(double x1, double y1, double x2, double y2)
		{
			return (float) Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}

        public string Convers�oValorPadr�oX(double valor)
        {
            if (r�tulosX != null)
                try
                {
                    int x = (int)Math.Round(valor);

                    return r�tulosX[x] == null ? "" : r�tulosX[x];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new Exception("O valor obtido para convers�o do valor X n�o est� dentro dos limites entre 0 e a quantidade de r�tulos.");
                }
            else
                return ((int)valor).ToString();
        }

        public string Convers�oValorPadr�oY(double valor)
        {
            return (Math.Round(valor, 2)).ToString();
            //return ((int) valor).ToString();
        }
	}
}
