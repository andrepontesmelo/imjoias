using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Entidades.Estatística.Gráficos
{
    public class GráficoLinhas : GráficoEmGrade
    {
        public const float padrãoTamanhoVértice = 5;
        public const bool padrãoMostrarVértice = false;

        private float tamanhoVértice = padrãoTamanhoVértice;
        private bool mostrarVértice = padrãoMostrarVértice;

        public bool MostrarVértice
        {
            get { return mostrarVértice; }
            set { mostrarVértice = value; }
        }

        public float VérticeTamanho
        {
            get { return tamanhoVértice; }
            set { tamanhoVértice = value; }
        }

        protected override void PlotarValor(int height, System.Collections.IDictionary props, System.Drawing.Graphics g, float puloX, int gapInferior, int seq, float pntAnteriorX, float pntAnteriorY, float pntAtualX, float pntAtualY, double valor)
        {
            g.DrawLine(
                (Pen)props["seqPen" + seq.ToString()],
                pntAnteriorX, pntAnteriorY, pntAtualX, pntAtualY);

            if (mostrarVértice)
            {
                g.FillRectangle(
                    (Brush)props["vérticeBrush" + seq.ToString()],
                    pntAnteriorX - tamanhoVértice / 2,
                    pntAnteriorY - tamanhoVértice / 2,
                    tamanhoVértice, tamanhoVértice);
                g.DrawRectangle(
                    (Pen)props["vérticePen" + seq.ToString()],
                    pntAnteriorX - tamanhoVértice / 2,
                    pntAnteriorY - tamanhoVértice / 2,
                    tamanhoVértice, tamanhoVértice);
            }
        }

        protected override void AoPlotarÚltimoValor(System.Collections.IDictionary props, System.Drawing.Graphics g, int seq, float pntX, float pntY)
        {
            base.AoPlotarÚltimoValor(props, g, seq, pntX, pntY);

            if (mostrarVértice)
            {
                g.FillRectangle(
                    (Brush)props["vérticeBrush" + seq.ToString()],
                    pntX - tamanhoVértice / 2,
                    pntY - tamanhoVértice / 2,
                    tamanhoVértice, tamanhoVértice);
                g.DrawRectangle(
                    (Pen)props["vérticePen" + seq.ToString()],
                    pntX - tamanhoVértice / 2,
                    pntY - tamanhoVértice / 2,
                    tamanhoVértice, tamanhoVértice);
            }
        }
    }
}
