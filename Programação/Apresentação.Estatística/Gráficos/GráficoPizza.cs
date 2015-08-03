using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;

namespace Apresentação.Estatística.Comum.Gráficos
{
    public class GráficoPizza : Desenhista
    {
        public const int padrãoEspaçamento = 15;

        protected int espaçamento = padrãoEspaçamento;

        protected override System.Drawing.Bitmap PlotarGráfico(int width, int height, System.Collections.IDictionary props)
        {
            Bitmap bmp;		// Imagem a ser construída
            PointF centro;		// Centro do gráfico
            float raio;		// Raio da pizza
            PointF posição;	// Posição do gráfico
            float ânguloY;	// Ângulo/Y
            float porcentoY;	// 100/Y
            bool[] porcentagens;// Quais valores tem sua porcentagem escrita

            porcentagens = new bool[dados.Length];

            // Construir imagem
            bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                if (props["limparFundo"] != null)
                    g.FillRectangle((Brush)props["limparFundo"], 0, 0, bmp.Width, bmp.Height);

                // Determinar o centro
                centro = new PointF(width / 2, height / 2);

                // Determinar o raio
                raio = DeterminarRaioPizza(g, width, height, props);

                // Determinan a posição do gráfico
                posição = new PointF(centro.X - raio / 2, centro.Y - raio / 2);

                // Calcular ângulo por valores e porcentagem
                double soma = 0;

                foreach (double[] vetor in dados)
                    foreach (double valor in vetor)
                        soma += valor;

                ânguloY = (float)(360 / soma);
                porcentoY = (float)(100 / soma);

                // Desenhar o gráfico
                float ânguloAtual = 0;

                for (int seq = 0; seq < dados.Length; seq++)
                {
                    float valor = (float)SomaValores(dados[seq]);
                    float ânguloValor = ânguloY * valor;

                    // Colorir fundo
                    g.FillPie(
                        (Brush)props["seqBrush" + seq.ToString()],
                        posição.X, posição.Y,
                        raio, raio,
                        ânguloAtual,
                        ânguloValor);

                    // Desenhar borda
                    g.DrawPie(
                        new Pen(Color.Black, 1.5f),
                        posição.X, posição.Y,
                        raio, raio,
                        ânguloAtual,
                        ânguloValor);

                    // Área para desenho
                    System.Drawing.Drawing2D.GraphicsPath área = new GraphicsPath();
                    área.AddPie(posição.X, posição.Y, raio, raio, ânguloAtual, ânguloValor);

                    g.Flush(System.Drawing.Drawing2D.FlushIntention.Flush);
                    g.Clip = new Region(área);

                    área.Dispose();

                    // Verificar se é possível escrever a porcentagem dentro da fatia
                    string legenda;
                    SizeF tamanhoLegenda;



                    // Escrever legenda (porcentagem)
                    legenda = Math.Round(porcentoY * valor).ToString() + "%";
                    tamanhoLegenda = g.MeasureString(
                        legenda,
                        (Font)props["legendaFont"]);

                    PointF posiçãoLegenda;

                    float legRaio = raio / 5 - 5;

                    do
                    {
                        legRaio += 5;

                        posiçãoLegenda = new PointF(
                            (float)(centro.X + legRaio * Math.Cos(Math.PI * (ânguloAtual + ânguloValor / 2f) / 180) - tamanhoLegenda.Width / 2),
                            (float)(centro.Y + legRaio * Math.Sin(Math.PI * (ânguloAtual + ânguloValor / 2f) / 180) - tamanhoLegenda.Height / 2));

                    } while (legRaio < raio - espaçamento - Math.Max(tamanhoLegenda.Width, tamanhoLegenda.Height)
                        &&
                        tamanhoLegenda.Width >=
                        Distância(centro.X + legRaio * Math.Cos(Math.PI * ânguloAtual / 180) - tamanhoLegenda.Width / 2,
                        centro.X + legRaio * Math.Sin(Math.PI * ânguloAtual / 180) - tamanhoLegenda.Width / 2,
                        centro.X + legRaio * Math.Cos(Math.PI * (ânguloAtual + ânguloValor) / 180) - tamanhoLegenda.Width / 2,
                        centro.X + legRaio * Math.Sin(Math.PI * (ânguloAtual + ânguloValor) / 180) - tamanhoLegenda.Width / 2));

                    if (legRaio < raio - espaçamento - Math.Max(tamanhoLegenda.Width, tamanhoLegenda.Height))
                        g.DrawString(
                            legenda,
                            (Font)props["legendaFont"],
                            (Brush)props["legendaBrush"],
                            posiçãoLegenda);



                    // Escrever descrição (legenda da seqüência)
                    RectangleF regiãoExclusão = new RectangleF(posiçãoLegenda, tamanhoLegenda);

                    legenda = this.legendas[seq];

                    if (legenda.Length > 8 && legenda.IndexOf(' ') > 0)
                    {
                        string[] palavras = legenda.Split(' ');
                        int cnt;

                        legenda = palavras[0];
                        cnt = legenda.Length;

                        for (int i = 1; i < palavras.Length; i++)
                        {
                            cnt += palavras[i].Length;

                            legenda += (cnt > 10 ? '\n' : ' ') + palavras[i];
                        }
                    }

                    tamanhoLegenda = g.MeasureString(
                        legenda,
                        (Font)props["descriçãoFont"]);

                    RectangleF região;

                    do
                    {
                        legRaio += 10;

                        posiçãoLegenda = new PointF(
                            (float)(centro.X + legRaio * Math.Cos(Math.PI * (ânguloAtual + ânguloValor / 2) / 180) - tamanhoLegenda.Width / 2),
                            (float)(centro.Y + legRaio * Math.Sin(Math.PI * (ânguloAtual + ânguloValor / 2) / 180) - tamanhoLegenda.Height / 2));

                        região = new RectangleF(posiçãoLegenda, tamanhoLegenda);
                    } while (legRaio < raio + espaçamento
                        &&
                        regiãoExclusão.IntersectsWith(região));

                    if (legRaio < raio - espaçamento - Math.Max(tamanhoLegenda.Width, tamanhoLegenda.Height))
                        g.DrawString(
                            legenda,
                            (Font)props["descriçãoFont"],
                            (Brush)props["descriçãoBrush"],
                            posiçãoLegenda);

                    g.Flush(System.Drawing.Drawing2D.FlushIntention.Flush);
                    g.Clip = new Region();

                    // Acrescentar ângulo
                    ânguloAtual += ânguloValor;
                }
            }

            return bmp;
        }

        /// <summary>
        /// Determina o tamanho da maior legenda a ser escrita
        /// </summary>
        private SizeF MaiorLegenda(Graphics g, Font fonte)
        {
            SizeF maior = new SizeF(0, 0);

            for (int i = (int)minX; i <= (int)maxX; i++)
            {
                SizeF tamanho = g.MeasureString(valorX(i), fonte);

                if (tamanho.Width > maior.Width)
                    maior.Width = tamanho.Width;
                else if (tamanho.Height > maior.Height)
                    maior.Height = tamanho.Height;
            }

            return maior;
        }

        /// <summary>
        /// Determina o raio do gráfico de pizza
        /// </summary>
        private float DeterminarRaioPizza(Graphics g, int width, int height, IDictionary props)
        {
            float raio;
            SizeF maiorLegenda;

            // Determinar o raio
            raio = Math.Min(width / 2, height / 2);

            maiorLegenda = MaiorLegenda(g, (Font)props["legendaFont"]);

            if (maiorLegenda.Width > width / 2 - raio)
                raio = width - maiorLegenda.Width - distânciaLegendaX;

            if (maiorLegenda.Height > height / 2 - raio)
                raio = height - maiorLegenda.Height - distânciaLegendaY;

            return raio;
        }

        /// <summary>
        /// Soma todos os valores dentro de um vetor.
        /// </summary>
        private double SomaValores(double[] valores)
        {
            double soma = 0;

            foreach (double valor in valores)
                soma += valor;

            return soma;
        }
    }
}
