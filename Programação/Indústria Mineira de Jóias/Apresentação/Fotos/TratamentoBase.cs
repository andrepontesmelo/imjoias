using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Formulários;
using System.Drawing;

namespace Apresentação.Álbum.Edição.Fotos
{
    abstract class TratamentoBase 
    {
        private static float limiarProjeção = 0.03f;		// Entre 0 e 1
        private static int verificarMargem = 50;
        private static float limiarMargem = 8f;          // Entre 0 e 360

        protected bool cancelado = false;

        public abstract Bitmap RealizarTrabalho(Bitmap img);

        /// <summary>
        /// Suaviza a transparência
        /// </summary>
        /// <param name="bmp">Imagem a ter sua transparência suavizada</param>
        /// <returns>Imagem com transparência suavizada</returns>
        protected Bitmap SuavizarTransparência(Bitmap bmp)
        {
            Bitmap suavização = new Bitmap(bmp);

            for (int y = 1; y < bmp.Height - 2 && !cancelado; y+= 10)
                for (int x = 1; x < bmp.Width - 2 && !cancelado; x+= 10)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    float a = pixel.A;

                    a += bmp.GetPixel(x - 1, y - 1).A;
                    a += bmp.GetPixel(x, y - 1).A;
                    a += bmp.GetPixel(x + 1, y - 1).A;
                    a += bmp.GetPixel(x + 1, y).A;
                    a += bmp.GetPixel(x + 1, y + 1).A;
                    a += bmp.GetPixel(x, y + 1).A;
                    a += bmp.GetPixel(x - 1, y + 1).A;
                    a += bmp.GetPixel(x - 1, y).A;

                    a /= 9f;

                    a = Math.Min(pixel.A, a);

                    suavização.SetPixel(x, y, Color.FromArgb((int)Math.Round(a), pixel));
                }

            return suavização;
        }


        /// <summary>
        /// Delimita uma imagem conforme transparência
        /// </summary>
        /// <param name="imagem">Imagem original</param>
        /// <returns>Área contendo imagem</returns>
        public static Rectangle Delimitar(Bitmap imagem)
        {
            int x1, x2, y1, y2;
            float limiarProjeçãoHorizontal, limiarProjeçãoVertical;

            x1 = 0;
            x2 = imagem.Width - 1;
            y1 = 0;
            y2 = imagem.Height - 1;

            limiarProjeçãoHorizontal = imagem.Width * limiarProjeção;
            limiarProjeçãoVertical = imagem.Height * limiarProjeção;

            /// Encontrar o topo
            while (CalcularProjeçãoHorizontal(imagem, y1) < limiarProjeçãoHorizontal && y1 < y2)
                y1++;

            // Encontrar o limite inferior
            while (CalcularProjeçãoHorizontal(imagem, y2) < limiarProjeçãoHorizontal && y2 > y1)
                y2--;

            // Encontrar a esquerda
            while (CalcularProjeçãoVertical(imagem, x1) < limiarProjeçãoVertical && x1 < x2)
                x1++;

            // Encontrar a direita
            while (CalcularProjeçãoVertical(imagem, x2) < limiarProjeçãoVertical && x2 > x1)
                x2--;

            if (x1 == x2)
            {
                x1 = 0;
                x2 = imagem.Width - 1;
            }

            if (y1 == y2)
            {
                y1 = 0;
                y2 = imagem.Height - 1;
            }

            /// Encontrar o topo
            while (CalcularProjeçãoHorizontal(imagem, y1) == 0 && y1 > 0)
                y1--;

            // Encontrar o limite inferior
            while (CalcularProjeçãoHorizontal(imagem, y2) == 0 && y2 < imagem.Height - 1)
                y2++;

            // Encontrar a esquerda
            while (CalcularProjeçãoVertical(imagem, x1) == 0 && x1 > 0)
                x1--;

            // Encontrar a direita
            while (CalcularProjeçãoVertical(imagem, x2) == 0 && x2 < imagem.Width - 1)
                x2++;

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Calcula a projeção horizontal
        /// </summary>
        /// <param name="imagem">Imagem original</param>
        /// <param name="y">Linha onde será calculada a projeção horizontal</param>
        /// <returns>Projeção da linha</returns>
        public static long CalcularProjeçãoHorizontal(Bitmap imagem, int y)
        {
            long projeção = 0;

            for (int x = 0; x < imagem.Width; x++)
                if (imagem.GetPixel(x, y).A > 0)
                    projeção++;

            return projeção;
        }

        /// <summary>
        /// Calcula a projeção vertical
        /// </summary>
        /// <param name="imagem">Imagem original</param>
        /// <param name="x">Coluna onde será calculada a projeção vertical</param>
        /// <returns>Projeção da coluna</returns>
        public static long CalcularProjeçãoVertical(Bitmap imagem, int x)
        {
            long projeção = 0;

            for (int y = 0; y < imagem.Height; y++)
                if (imagem.GetPixel(x, y).A > 0)
                    projeção++;

            return projeção;
        }

        public static Bitmap Cortar(Bitmap imagem)
        {
            imagem = CorrigirBorda(imagem);

            Bitmap final;
            Rectangle limites = Delimitar(imagem);

            final = new Bitmap(limites.Width, limites.Height);

            using (Graphics g = Graphics.FromImage(final))
            {
                g.DrawImage(imagem,
                    new Rectangle(new Point(0, 0), final.Size),
                    limites, GraphicsUnit.Pixel);
            }

            return final;
        }

        /// <summary>
        /// Algumas placas de captura preenchem a borda com uma
        /// faixa colorida. A imagem é cortada nesta faixa por
        /// esta função.
        /// </summary>
        /// <param name="img">Imagem a ser tratada.</param>
        /// <returns>Borda removida.</returns>
        public static Bitmap CorrigirBorda(Bitmap img)
        {
            /* Percorrer as boras em toda sua extensão verificando
             * quando o padrão de cores se estabiliza, visto que
             * praticamente sempre nas bordas temos uma grande parte
             * em fundo braco. A faixa de ruído apresentará um
             * padrão ou não até encontrar o fundo.
             */
            int esq = verificarMargem, dir = img.Width - verificarMargem,
                cima = verificarMargem, baixo = img.Height - verificarMargem;

            // Vertical
            for (int y = 0; y < img.Height; y += (img.Height >> 3))
            {
                // Esquerda
                if (esq > 0)
                {
                    float referência = img.GetPixel(esq, y).GetHue();

                    for (int x = esq - 1; x >= 0; x--)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - referência) < limiarMargem)
                            esq = x;
                    }
                }

                // Direita
                if (dir < img.Width)
                {
                    float referência = img.GetPixel(dir, y).GetHue();

                    for (int x = dir + 1; x < img.Width; x++)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - referência) < limiarMargem)
                            dir = x;
                    }
                }
            }

            // Horizontal
            for (int x = 0; x < img.Width; x += (img.Width >> 3))
            {
                // Cima
                if (cima > 0)
                {
                    float referência = img.GetPixel(x, cima).GetHue();

                    for (int y = cima - 1; y >= 0; y--)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - referência) < limiarMargem)
                            cima = y;
                    }
                }

                // Baixo
                if (baixo < img.Height)
                {
                    float referência = img.GetPixel(x, baixo).GetHue();

                    for (int y = baixo + 1; y < img.Height; y++)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - referência) < limiarMargem)
                            baixo = x;
                    }
                }
            }

            if (esq == verificarMargem)
                esq = 0;
            else if (esq > 0)
                esq += 10;

            if (dir == img.Width - verificarMargem)
                dir = img.Width;
            else if (dir < img.Width)
                dir -= 9;

            if (cima == verificarMargem)
                cima = 0;
            else if (cima > 0)
                cima += 10;

            if (baixo == img.Height - verificarMargem)
                baixo = img.Height;
            else if (baixo < img.Height)
                baixo -= 9;

            if ((cima > 0 || baixo < img.Height || esq > 0 || dir < img.Width)
                && cima < img.Height && baixo > 0 && esq < img.Width && dir > 0)
            {
                Bitmap bmp = new Bitmap(dir - esq, baixo - cima);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(
                        img,
                        0, 0,
                        new Rectangle(esq, cima, dir, baixo),
                        GraphicsUnit.Pixel);
                }

                return bmp;
            }
            else
                return img;
        }
    }
}
