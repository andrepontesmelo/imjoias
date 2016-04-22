using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Apresentação.Álbum.Edição.Fotos
{
	/// <summary>
	/// Tratamento de jóias baseado em cores de fundo
	/// </summary>
	public class TratamentoCores
	{
		// Atributos
		private float limiarBrilho			= 0.004f;		// Entre 0 e 1
		private float limiarProjeção		= 0.03f;		// Entre 0 e 1
		private float limiarÁrea			= 0.10f;		// Entre 0 e 1
		private float limiarReconstrução	= 0.003f;		// Entre 0 e 1
		private float limiarTransparentes	= 0.99f;		// Entre 0 e 1
        private const int verificarMargem   = 50;
        private float limiarMargem          = 8f;          // Entre 0 e 360

		/// <summary>
		/// Insere na pilha para o flood-fill
		/// </summary>
		/// <param name="pilha">Pilha contendo pontos e brilho</param>
		/// <param name="brilho">Brilho de referência</param>
		/// <param name="x">Posição X</param>
		/// <param name="y">Posição Y</param>
		private static void InserirPilha(Stack pilha, float brilho, int x, int y)
		{
			pilha.Push(brilho);
			pilha.Push(new Point(x, y));
		}

		/// <summary>
		/// Encontra cores de fundo em um bitmap
		/// </summary>
		/// <param name="origem">Imagem original</param>
		/// <returns>Dicionário de cores do fundo</returns>
		private Dictionary<Color, Color> EncontrarCoresFundo(Bitmap origem)
		{
			Dictionary<Color, Color> cores = new Dictionary<Color, Color>();	// Cores do fundo
			Stack	  pilha = new Stack();		                // Pilha para flood-fill
			bool [,]  marcado;					                // Pontos marcados no flood-fill

			marcado = new bool[origem.Width, origem.Height];

			/* A cor de fundo é encontrada realizando um flood-fill
				 * nas bordas da imagem. As cores encontradas cujo brilho
				 * se difere de um determinado limiar são consideradas como
				 * cores de fundos.
				 */
			InserirPilha(pilha, origem.GetPixel(0, 0).GetBrightness(), 0, 0);
			InserirPilha(pilha, origem.GetPixel(origem.Width - 1, 0).GetBrightness(), origem.Width - 1, 0);
			InserirPilha(pilha, origem.GetPixel(origem.Width - 1, origem.Height - 1).GetBrightness(), origem.Width - 1, 0);
			InserirPilha(pilha, origem.GetPixel(0, origem.Height - 1).GetBrightness(), 0, origem.Height - 1);
			
			while (pilha.Count > 0)
			{
				Point ponto;
				float brilhoAnterior;
				Color corAtual;

				ponto = (Point) pilha.Pop();
				brilhoAnterior = (float) pilha.Pop();

				if (ponto.X < 0 || ponto.X >= origem.Width
					|| ponto.Y < 0 || ponto.Y >= origem.Height
					|| marcado[ponto.X, ponto.Y])
					continue;

				corAtual = origem.GetPixel(ponto.X, ponto.Y);

				if (Math.Abs(corAtual.GetBrightness() - brilhoAnterior) < limiarBrilho)
				{
					float brilhoAtual = corAtual.GetBrightness();

					cores[corAtual] = Color.Black;
					marcado[ponto.X, ponto.Y] = true;
						
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X + 1, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X + 1, ponto.Y);
					InserirPilha(pilha, brilhoAtual, ponto.X + 1, ponto.Y + 1);
					InserirPilha(pilha, brilhoAtual, ponto.X, ponto.Y + 1);
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y + 1);
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y);
				}
			}

			return cores;
		}

		/// <summary>
		/// Calcula a área de uma ilha
		/// </summary>
		/// <param name="marcação">Marcação de pontos preenchidos com fundo</param>
		/// <param name="x">Coordenada X</param>
		/// <param name="y">Coordenada Y</param>
		/// <param name="pontos">Pontos da ilha</param>
		/// <returns>Área da ilha</returns>
		private static long CalcularÁrea(bool [,] marcação, int x, int y, out ArrayList pontos)
		{
			Stack pilha = new Stack();
			long  área = 0;
			
			pontos = new ArrayList(100000);
			pilha.Push(new Point(x, y));

			while (pilha.Count > 0)
			{
				Point ponto = (Point) pilha.Pop();

				if (ponto.X >= 0 && ponto.X <= marcação.GetUpperBound(0)
					&& ponto.Y >= 0 && ponto.Y <= marcação.GetUpperBound(1)
					&& !marcação[ponto.X, ponto.Y])
				{
					área++;
					pilha.Push(new Point(ponto.X, ponto.Y - 1));
					pilha.Push(new Point(ponto.X + 1, ponto.Y));
					pilha.Push(new Point(ponto.X, ponto.Y + 1));
					pilha.Push(new Point(ponto.X - 1, ponto.Y));
					marcação[ponto.X, ponto.Y] = true;
					pontos.Add(ponto);
				}
			}

			return área;
		}

		/// <summary>
		/// Remove ilhas
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="marcaçãoOriginal">Pontos verificados</param>
		private void RemoverIlhas(Bitmap imagem, bool [,] marcaçãoOriginal)
		{
			float limiarÁrea;

			limiarÁrea = this.limiarÁrea * CalcularÁreaNãoTransparente(marcaçãoOriginal);

			for (int y = 0; y < imagem.Height; y++)
				for (int x = 0; x < imagem.Width; x++)
					if (!marcaçãoOriginal[x, y])
					{
						ArrayList pontos;
						long      área;

						área = CalcularÁrea(marcaçãoOriginal, x, y, out pontos);

						// Adicionar cores da ilha
						if (área < limiarÁrea)
							foreach (Point p in pontos)
								imagem.SetPixel(p.X, p.Y, Color.FromArgb(0, imagem.GetPixel(p.X, p.Y)));
					}
		}

		/// <summary>
		/// Calcula área não transparente
		/// </summary>
		/// <param name="transparentes">Pontos transparentes</param>
		/// <returns>Área não transparente</returns>
		private static long CalcularÁreaNãoTransparente(bool [,] transparentes)
		{
			long área = 0;

			foreach (bool b in transparentes)
				if (!b)
					área++;

			return área;
		}

		/// <summary>
		/// Delimita uma imagem conforme transparência
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <returns>Área contendo imagem</returns>
		private Rectangle Delimitar(Bitmap imagem)
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
		private static long CalcularProjeçãoHorizontal(Bitmap imagem, int y)
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
		private static long CalcularProjeçãoVertical(Bitmap imagem, int x)
		{
			long projeção = 0;

			for (int y = 0; y < imagem.Height; y++)
				if (imagem.GetPixel(x, y).A > 0)
					projeção++;

			return projeção;
		}

		/// <summary>
		/// Processa a imagem
		/// </summary>
		/// <param name="imagem">Imagem a ser processada</param>
		public Image ProcessarImagem(Image imagem)
		{
			Bitmap	                    final;						// Imagens
			Dictionary<Color, Color>    cores;						// Cores do fundo
            //Rectangle                   limites;
			bool [,]                    transparente;
			long	                    transparentes = 0;

			// Processar imagem
			using (Bitmap processamento = new Bitmap(imagem))
			{
				// Determinar cores de fundo
				cores = EncontrarCoresFundo(processamento);

				transparente = new bool[processamento.Width, processamento.Height];

				/* Verifica-se todos os pixels da imagem, eliminando
				* as cores de fundo
				*/
                for (int y = 0; y < processamento.Height; y++)
					for (int x = 0; x < processamento.Width; x++)
					{
						Color cor = processamento.GetPixel(x, y);

						if (!(transparente[x, y] = cores.ContainsKey(cor)))
							processamento.SetPixel(x, y, cor);
						else
						{
							processamento.SetPixel(x, y, Color.FromArgb(0, cor));
							transparentes++;
						}
					}

				if (transparentes >= limiarTransparentes * imagem.Width * imagem.Height)
					final = new Bitmap(imagem);
				else
				{
					RemoverIlhas(processamento, transparente);

					// Suavizar transparência
					using (Bitmap suavização = SuavizarTransparência(processamento))
					{
                        // Não cortar foto
                        final = new Bitmap(suavização);
					}
				}
			}

            final.Tag = imagem.Clone();

			return final;
		}

		/// <summary>
		/// Reconstrói imagem processada, tentando remover áreas transparentes
		/// que são jóias
		/// </summary>
		/// <param name="bmp">Imagem processada</param>
		/// <param name="transparente">Pontos transparentes</param>
		private void ReconstruirImagem(Bitmap bmp, bool [,] transparente)
		{
			bool [,] marcas = new bool[bmp.Width, bmp.Height];
			float limiarReconstrução;

			limiarReconstrução = this.limiarReconstrução * bmp.Width * bmp.Height;

			for (int i = 0; i < bmp.Width; i++)
				for (int j = 0; j < bmp.Height; j++)
					marcas[i, j] = !transparente[i, j];

			for (int y = 0; y < bmp.Height; y++)
				for (int x = 0; x < bmp.Width; x++)
					if (transparente[x, y] && !marcas[x, y])
					{
						long área;
						ArrayList pontos;

						área = CalcularÁrea(marcas, x, y, out pontos);

						if (área < limiarReconstrução)
						{
							foreach (Point p in pontos)
							{
								Color cor = bmp.GetPixel(p.X, p.Y);
								bmp.SetPixel(p.X, p.Y, Color.FromArgb(255, cor.R, cor.G, cor.B));
							}
						}
					}
		}

		/// <summary>
		/// Suaviza a transparência
		/// </summary>
		/// <param name="bmp">Imagem a ter sua transparência suavizada</param>
		/// <returns>Imagem com transparência suavizada</returns>
		private static Bitmap SuavizarTransparência(Bitmap bmp)
		{
			Bitmap suavização = new Bitmap(bmp);

			for (int y = 1; y < bmp.Height - 2; y++)
				for (int x = 1; x < bmp.Width - 2; x++)
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

					suavização.SetPixel(x, y, Color.FromArgb((int) Math.Round(a), pixel));
				}

			return suavização;
		}

        /// <summary>
        /// Algumas placas de captura preenchem a borda com uma
        /// faixa colorida. A imagem é cortada nesta faixa por
        /// esta função.
        /// </summary>
        /// <param name="img">Imagem a ser tratada.</param>
        /// <returns>Borda removida.</returns>
        public Bitmap CorrigirBorda(Bitmap img)
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
