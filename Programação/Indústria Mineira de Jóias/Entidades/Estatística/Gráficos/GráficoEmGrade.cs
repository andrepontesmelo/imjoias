using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Entidades.Estatística.Gráficos
{
    public abstract class GráficoEmGrade : Desenhista
    {
        public const bool padrãoGradeHorizontal = true;
        public const bool padrãoGradeVertical = true;
        public const int padrãoGapVertical = 20;
        public const int padrãoGapHorizontal = 0;
        public const bool padrãoValoresY = true;
        public const bool padrãoValoresX = true;
        public const bool padrãoAcomodarY = true;
        public const bool padrãoAcomodarX = true;
        public const bool padrãoForçarValoresX = false;
        public const int padrãoEspaçamento = 15;
        public const bool padrãoInteiroY = true;
        public const bool padrãoInteiroX = true;

        protected string eixoY = "Eixo Y";
        protected string eixoX = "Eixo X";
        protected bool gradeHorizontal = padrãoGradeHorizontal;
        protected bool gradeVertical = padrãoGradeVertical;
        protected int gapVertical = padrãoGapVertical;
        protected int gapHorizontal = padrãoGapHorizontal;
        protected bool acomodarY = padrãoAcomodarY;
        protected bool acomodarX = padrãoAcomodarX;
        protected bool forçarValoresX = padrãoForçarValoresX;
        protected int espaçamento = padrãoEspaçamento;
        protected bool inteiroY = padrãoInteiroY;
        protected bool inteiroX = padrãoInteiroX;
        protected bool valoresY = padrãoValoresY;
        protected bool valoresX = padrãoValoresX;

        public GráficoEmGrade()
        {
        }

        #region Propriedades

        public string EixoY
        {
            get { return eixoY; }
            set { eixoY = value; }
        }

        public string EixoX
        {
            get { return eixoX; }
            set { eixoX = value; }
        }

        public bool GradeHorizontal
        {
            get { return gradeHorizontal; }
            set { gradeHorizontal = value; }
        }

        public bool GradeVertical
        {
            get { return gradeVertical; }
            set { gradeVertical = value; }
        }

        public int GapVertical
        {
            get { return gapVertical; }
            set { gapVertical = value; }
        }

        public int GapHorizontal
        {
            get { return gapHorizontal; }
            set { gapHorizontal = value; }
        }

        public double MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }

        public double MinY
        {
            get { return minY; }
            set { minY = value; }
        }

        public bool ValoresY
        {
            get { return valoresY; }
            set { valoresY = value; }
        }

        public bool ValoresX
        {
            get { return valoresX; }
            set { valoresX = value; }
        }

        public bool ForçarEscritaValoresX
        {
            get { return forçarValoresX; }
            set { forçarValoresX = value; }
        }

        public bool InteiroY
        {
            get { return inteiroY; }
            set { inteiroY = value; }
        }

        #endregion

        protected override Bitmap PlotarGráfico(int width, int height, System.Collections.IDictionary props)
        {
			Bitmap bmp = new Bitmap(width, height);
			
			using (Graphics g = Graphics.FromImage(bmp))
			{
				float puloY;
				double pontoY;
				float puloX;
				double pontoX;
				int gapEsquerdo;
				int gapInferior = Math.Min(espaçamento, 15);
				int gapSuperior = Math.Min(espaçamento, 15);
				int gapDireito = Math.Min(espaçamento, 15);
				float iniEixoX;

                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                //if (estilo == Estilo.Barras)
                //    maxX++;

                DefinirEspaçamento(width, height, props, bmp, g, gapInferior, gapSuperior, gapDireito, out puloY, out pontoY, out puloX, out pontoX, out gapEsquerdo);

                iniEixoX = EscreverLegendaEixos(width, height, props, g, gapInferior);

                DesenharFundo(width, height, props, g, gapEsquerdo, gapInferior, gapSuperior, gapDireito);

				#region Desenha grade

				if (gradeHorizontal)
					for (float i = height - gapInferior; i > gapSuperior; i -= puloY)
						g.DrawLine((Pen) props["gradePen"], gapEsquerdo, i, width - gapDireito, i);

				if (gradeVertical)
					for (float i = gapEsquerdo + puloX; i < width - gapDireito; i += puloX)
						g.DrawLine((Pen) props["gradePen"], i, gapSuperior, i, height - gapInferior);

                #endregion

                EscreverValoresEixoY(height, props, g, puloY, pontoY, gapEsquerdo, gapInferior, gapSuperior);
                EscreverValoresEixoX(width, height, props, g, puloX, pontoX, gapEsquerdo, gapInferior, gapDireito, iniEixoX);

				if (dados != null && dados.Length > 0)
                    PlotarDados(width, height, props, g, puloY, puloX, pontoX, gapEsquerdo, gapInferior, gapSuperior, gapDireito);

				#region Desenhar borda

				g.DrawRectangle(
					(Pen) props["canetaBorda"],
					gapEsquerdo, gapSuperior, width - gapEsquerdo - gapDireito, height - gapInferior - gapSuperior);

				#endregion
			}

			return bmp;
        }

        /// <summary>
        /// Plota o gráfico.
        /// </summary>
        private void PlotarDados(int width, int height, System.Collections.IDictionary props, Graphics g, float puloY, float puloX, double pontoX, int gapEsquerdo, int gapInferior, int gapSuperior, int gapDireito)
        {
            puloX = (float)(width - gapEsquerdo - gapDireito) / (float)(maxX - minX);
            pontoX = (float)(maxX - minX) / (float)(width - gapEsquerdo - gapDireito);
            puloY = (float)(height - gapInferior - gapSuperior) / (float)(maxY - minY);

            for (int seq = 0; seq < seqüências; seq++)
            {
                float pntAnteriorX = gapEsquerdo;
                float pntAnteriorY = height - gapInferior - ((float)(double)(dados[seq][0] - minY) * puloY);

                float pntAtualX = gapEsquerdo;
                float pntAtualY = height - gapInferior - ((float)(double)(dados[seq][0] - minY) * puloY);

                foreach (double valor in dados[seq])
                {
                    pntAtualY = height - gapInferior - (float)(valor - minY) * puloY;

                    PlotarValor(height, props, g, puloX, gapInferior, seq, pntAnteriorX, pntAnteriorY, pntAtualX, pntAtualY, valor);

                    pntAnteriorX = pntAtualX;
                    pntAnteriorY = pntAtualY;
                    pntAtualX = pntAnteriorX + puloX;
                }

                AoPlotarÚltimoValor(props, g, seq, pntAnteriorX, pntAnteriorY);
            }
        }

        protected virtual void AoPlotarÚltimoValor(System.Collections.IDictionary props, Graphics g, int seq, float pntX, float pntY)
        {
            // Fazer nada
        }

        /// <summary>
        /// Plota o valor do gráfico.
        /// </summary>
        protected abstract void PlotarValor(int height, System.Collections.IDictionary props, Graphics g, float puloX, int gapInferior, int seq, float pntAnteriorX, float pntAnteriorY, float pntAtualX, float pntAtualY, double valor);

        /// <summary>
        /// Escreve valores no eixo Y.
        /// </summary>
        protected virtual void EscreverValoresEixoY(int height, System.Collections.IDictionary props, Graphics g, float puloY, double pontoY, int gapEsquerdo, int gapInferior, int gapSuperior)
        {
            if (valoresY)
            {
                for (float i = height - gapInferior; i > gapSuperior; i -= puloY)
                {
                    string s = valorY(((height - gapInferior - i)) * pontoY + minY);
                    SizeF tam = g.MeasureString(s, (Font)props["valorFont"]);

                    g.DrawString(s,
                        (Font)props["valorFont"],
                        (Brush)props["valorBrush"],
                        gapEsquerdo - 2 - tam.Width,
                        i - tam.Height / 2,
                        StringFormat.GenericDefault);
                }
            }
        }

        /// <summary>
        /// Escreve valores no eixo X.
        /// </summary>
        protected virtual void EscreverValoresEixoX(int width, int height, System.Collections.IDictionary props, Graphics g, float puloX, double pontoX, int gapEsquerdo, int gapInferior, int gapDireito, float iniEixoX)
        {
            if (valoresX)
            {
                float ini;
                float pAnterior = 0;

                ini = gapEsquerdo + puloX;

                for (float i = ini; i <= width - gapDireito; i += puloX)
                {
                    string s;

                    s = valorX((i - gapEsquerdo) * pontoX + minX);

                    if (s.Length < 1)
                        continue;

                    SizeF tam = g.MeasureString(s, (Font)props["valorFont"]);

                    if (!forçarValoresX && i + tam.Width / 2 >= iniEixoX)
                        break;

                    if (!forçarValoresX && i - tam.Width / 2 <= pAnterior)
                        continue;

                    g.DrawString(s,
                        (Font)props["valorFont"],
                        (Brush)props["valorBrush"],
                        i - tam.Width / 2,
                        height - gapInferior + 2,
                        StringFormat.GenericDefault);

                    pAnterior = i + tam.Width / 2 + 2;
                }
            }
        }

        /// <summary>
        /// Desenha o fundo do gráfico.
        /// </summary>
        protected virtual void DesenharFundo(int width, int height, System.Collections.IDictionary props, Graphics g, int gapEsquerdo, int gapInferior, int gapSuperior, int gapDireito)
        {
            Brush fundo;

            if (props["fundoBorda"] == null)
            {
                fundo = new LinearGradientBrush(
                    new Rectangle(0, 0, width, height),
                    Color.FromArgb(240, 240, 230),
                    //Color.FromArgb(234, 232, 219),
                    Color.FromArgb(232, 227, 202),
                    35, false);
            }
            else
                fundo = (Brush)props["fundoBorda"];

            g.FillRectangle(
                fundo,
                gapEsquerdo, gapSuperior, width - gapEsquerdo - gapDireito, height - gapInferior - gapSuperior);
        }

        /// <summary>
        /// Escreve legenda nos eixos e define onde inicia o eixo X.
        /// </summary>
        /// <returns>Início do eixo X.</returns>
        protected virtual float EscreverLegendaEixos(int width, int height, System.Collections.IDictionary props, Graphics g, int gapInferior)
        {
            float iniEixoX;
            g.DrawString(eixoY,
                (Font)props["eixoFont"],
                (Brush)props["eixoBrush"],
                0, 0,
                StringFormat.GenericDefault);

            g.DrawString(eixoX,
                (Font)props["eixoFont"],
                (Brush)props["eixoBrush"],
                iniEixoX = width - g.MeasureString(eixoX, (Font)props["eixoFont"]).Width,
                height - gapInferior + 2,
                StringFormat.GenericDefault);
            return iniEixoX;
        }

        /// <summary>
        /// Define espaçamentos da grade.
        /// </summary>
        /// <param name="gapInferior">Espaçamento inferior.</param>
        /// <param name="gapSuperior">Espaçamento superior.</param>
        /// <param name="gapDireito">Espaçamento da direita.</param>
        /// <param name="gapEsquerdo">Espaçamento da esquerda</param>
        /// <param name="puloY">Pulo da grade em Y.</param>
        /// <param name="pontoY">Valor do pixel em Y.</param>
        /// <param name="puloX">Pulo da grade em X.</param>
        /// <param name="pontoX">Valor do pixel em X.</param>
        protected virtual void DefinirEspaçamento(int width, int height, System.Collections.IDictionary props, Bitmap bmp, Graphics g, int gapInferior, int gapSuperior, int gapDireito, out float puloY, out double pontoY, out float puloX, out double pontoX, out int gapEsquerdo)
        {
            if (props["limparFundo"] != null)
                g.FillRectangle((Brush)props["limparFundo"], 0, 0, bmp.Width, bmp.Height);

            gapEsquerdo = (int)g.MeasureString(valorY(maxY), (Font)props["valorFont"]).Width + 5;

            if (dados != null)
                foreach (double[] vetor in dados)
                    foreach (double valor in vetor)
                        gapEsquerdo = Math.Max(gapEsquerdo, (int)g.MeasureString(valorY(valor), (Font)props["valorFont"]).Width + 5);

            if (acomodarY)
            {
                int q = (height - gapInferior - gapSuperior) / gapVertical;
                int r = (height - gapInferior - gapSuperior) % gapVertical;

                puloY = (float)gapVertical + (float)r / (float)q;
            }
            else
                puloY = (float)gapVertical;

            pontoY = (float)(maxY - minY) / (float)(height - gapInferior - gapSuperior);

            if ((height - gapInferior - gapSuperior) / puloY > maxY - minY)
                puloY = (float)(height - gapInferior - gapSuperior) / (float)(maxY - minY);

            if (inteiroY)
            {
                float p1;

                p1 = (float)(Math.Floor(puloY * pontoY) / pontoY);

                if (p1 < gapVertical || p1 < 10)
                    puloY = (float)(Math.Ceiling(puloY * pontoY) / pontoY);
                else
                    puloY = p1;
            }

            if (gapHorizontal > 0)
            {
                if (acomodarX)
                {
                    int q = (width - gapEsquerdo - gapDireito) / gapHorizontal;
                    int r = (width - gapEsquerdo - gapDireito) % gapHorizontal;

                    puloX = (float)gapHorizontal + (float)r / (float)q;
                }
                else
                    puloX = (float)gapHorizontal;

                if ((width - gapEsquerdo - gapDireito) / puloY > maxX - minX)
                    puloX = (float)(width - gapEsquerdo - gapDireito) / (float)(maxX - minX);

                pontoX = (float)(maxX - minX) / (float)(width - gapEsquerdo - gapDireito);
            }
            else
            {
                puloX = (float)(width - gapEsquerdo - gapDireito) / (float)(maxX - minX);
                pontoX = (float)(maxX - minX) / (float)(width - gapEsquerdo - gapDireito);

                if (gradeVertical && puloX < 15)
                {
                    int q = (width - gapEsquerdo - gapDireito) / 15;
                    int r = (width - gapEsquerdo - gapDireito) % 15;

                    puloX = (float)15 + (float)r / (float)q;
                }
            }

            if (inteiroX)
            {
                float nPuloX = (float)(Math.Floor(puloX * pontoX) / pontoX);

                if (nPuloX > 0)
                    puloX = nPuloX;
            }

            if (puloX <= 20)
                puloX = (float)(Math.Ceiling((gapHorizontal > 0 ? gapHorizontal : 50) * pontoX) / (float)pontoX);

            if (puloY <= 20)
                puloY = (float)(Math.Ceiling((gapVertical > 0 ? gapVertical : 50) * pontoY) / (float)pontoY);
        }
    }
}
