using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Entidades.Estatística.Gráficos
{
    public class GráficoBarras : GráficoEmGrade
    {
        public GráficoBarras()
        {
            MinY = 0;
        }

        protected override void PlotarValor(int height, System.Collections.IDictionary props, System.Drawing.Graphics g, float puloX, int gapInferior, int seq, float pntAnteriorX, float pntAnteriorY, float pntAtualX, float pntAtualY, double valor)
        {
            if (valor > 0)
            {
                float tamanho = System.Math.Min(30, puloX - 5);
                float tamSeq = tamanho / seqüências;

                g.FillRectangle(
                    (Brush)props["seqBrush" + seq.ToString()],
                    pntAtualX + puloX / 2 - tamanho / 2 + seq * tamSeq,
                    pntAtualY,
                    tamSeq,
                    height - gapInferior - pntAtualY);
                g.DrawRectangle(
                    (Pen)props["seqBarraPen" + seq.ToString()],
                    pntAtualX + puloX / 2 - tamanho / 2 + seq * tamSeq,
                    pntAtualY,
                    tamSeq,
                    height - gapInferior - pntAtualY);
            }
        }

        protected override void AoAtribuirDados()
        {
            base.AoAtribuirDados();

            MaxX++;
        }

        protected override void EscreverValoresEixoX(int width, int height, System.Collections.IDictionary props, System.Drawing.Graphics g, float puloX, double pontoX, int gapEsquerdo, int gapInferior, int gapDireito, float iniEixoX)
        {
            if (valoresX)
            {
                float ini;
                float pAnterior = 0;

                ini = gapEsquerdo + puloX;
                ini -= puloX / 2;

                for (float i = ini; i <= width - gapDireito; i += puloX)
                {
                    string s;

                    s = valorX(Math.Floor((i - gapEsquerdo) * pontoX + minX));

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

                    pAnterior = i + tam.Width / 2 + 1;
                }
            }
        }

        protected override void DefinirEspaçamento(int width, int height, System.Collections.IDictionary props, Bitmap bmp, Graphics g, int gapInferior, int gapSuperior, int gapDireito, out float puloY, out double pontoY, out float puloX, out double pontoX, out int gapEsquerdo)
        {
            if (props["limparFundo"] != null)
                g.FillRectangle((Brush)props["limparFundo"], 0, 0, bmp.Width, bmp.Height);

            gapEsquerdo = (int)g.MeasureString(valorY(maxY), (Font)props["valorFont"]).Width + 5;

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
                puloX = (float)(width - gapEsquerdo - gapDireito) / (float)(maxX - minX);

            if (puloY <= 20)
                puloY = (float)(Math.Ceiling((gapVertical > 0 ? gapVertical : 50) * pontoY) / (float)pontoY);
        }
    }
}