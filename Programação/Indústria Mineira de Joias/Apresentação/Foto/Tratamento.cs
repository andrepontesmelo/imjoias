using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Apresenta��o.�lbum.Edi��o.Fotos
{
	/// <summary>
	/// Tratamento de j�ias baseado em cores de fundo
	/// </summary>
	public class TratamentoCores
	{
		// Atributos
		private float limiarBrilho			= 0.004f;		// Entre 0 e 1
		private float limiarProje��o		= 0.03f;		// Entre 0 e 1
		private float limiar�rea			= 0.10f;		// Entre 0 e 1
		private float limiarReconstru��o	= 0.003f;		// Entre 0 e 1
		private float limiarTransparentes	= 0.99f;		// Entre 0 e 1
        private const int verificarMargem   = 50;
        private float limiarMargem          = 8f;          // Entre 0 e 360

		/// <summary>
		/// Insere na pilha para o flood-fill
		/// </summary>
		/// <param name="pilha">Pilha contendo pontos e brilho</param>
		/// <param name="brilho">Brilho de refer�ncia</param>
		/// <param name="x">Posi��o X</param>
		/// <param name="y">Posi��o Y</param>
		private static void InserirPilha(Stack pilha, float brilho, int x, int y)
		{
			pilha.Push(brilho);
			pilha.Push(new Point(x, y));
		}

		/// <summary>
		/// Encontra cores de fundo em um bitmap
		/// </summary>
		/// <param name="origem">Imagem original</param>
		/// <returns>Dicion�rio de cores do fundo</returns>
		private Dictionary<Color, Color> EncontrarCoresFundo(Bitmap origem)
		{
			Dictionary<Color, Color> cores = new Dictionary<Color, Color>();	// Cores do fundo
			Stack	  pilha = new Stack();		                // Pilha para flood-fill
			bool [,]  marcado;					                // Pontos marcados no flood-fill

			marcado = new bool[origem.Width, origem.Height];

			/* A cor de fundo � encontrada realizando um flood-fill
				 * nas bordas da imagem. As cores encontradas cujo brilho
				 * se difere de um determinado limiar s�o consideradas como
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
		/// Calcula a �rea de uma ilha
		/// </summary>
		/// <param name="marca��o">Marca��o de pontos preenchidos com fundo</param>
		/// <param name="x">Coordenada X</param>
		/// <param name="y">Coordenada Y</param>
		/// <param name="pontos">Pontos da ilha</param>
		/// <returns>�rea da ilha</returns>
		private static long Calcular�rea(bool [,] marca��o, int x, int y, out ArrayList pontos)
		{
			Stack pilha = new Stack();
			long  �rea = 0;
			
			pontos = new ArrayList(100000);
			pilha.Push(new Point(x, y));

			while (pilha.Count > 0)
			{
				Point ponto = (Point) pilha.Pop();

				if (ponto.X >= 0 && ponto.X <= marca��o.GetUpperBound(0)
					&& ponto.Y >= 0 && ponto.Y <= marca��o.GetUpperBound(1)
					&& !marca��o[ponto.X, ponto.Y])
				{
					�rea++;
					pilha.Push(new Point(ponto.X, ponto.Y - 1));
					pilha.Push(new Point(ponto.X + 1, ponto.Y));
					pilha.Push(new Point(ponto.X, ponto.Y + 1));
					pilha.Push(new Point(ponto.X - 1, ponto.Y));
					marca��o[ponto.X, ponto.Y] = true;
					pontos.Add(ponto);
				}
			}

			return �rea;
		}

		/// <summary>
		/// Remove ilhas
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="marca��oOriginal">Pontos verificados</param>
		private void RemoverIlhas(Bitmap imagem, bool [,] marca��oOriginal)
		{
			float limiar�rea;

			limiar�rea = this.limiar�rea * Calcular�reaN�oTransparente(marca��oOriginal);

			for (int y = 0; y < imagem.Height; y++)
				for (int x = 0; x < imagem.Width; x++)
					if (!marca��oOriginal[x, y])
					{
						ArrayList pontos;
						long      �rea;

						�rea = Calcular�rea(marca��oOriginal, x, y, out pontos);

						// Adicionar cores da ilha
						if (�rea < limiar�rea)
							foreach (Point p in pontos)
								imagem.SetPixel(p.X, p.Y, Color.FromArgb(0, imagem.GetPixel(p.X, p.Y)));
					}
		}

		/// <summary>
		/// Calcula �rea n�o transparente
		/// </summary>
		/// <param name="transparentes">Pontos transparentes</param>
		/// <returns>�rea n�o transparente</returns>
		private static long Calcular�reaN�oTransparente(bool [,] transparentes)
		{
			long �rea = 0;

			foreach (bool b in transparentes)
				if (!b)
					�rea++;

			return �rea;
		}

		/// <summary>
		/// Delimita uma imagem conforme transpar�ncia
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <returns>�rea contendo imagem</returns>
		private Rectangle Delimitar(Bitmap imagem)
		{
			int x1, x2, y1, y2;
			float limiarProje��oHorizontal, limiarProje��oVertical;

			x1 = 0;
			x2 = imagem.Width - 1;
			y1 = 0;
			y2 = imagem.Height - 1;

			limiarProje��oHorizontal = imagem.Width * limiarProje��o;
			limiarProje��oVertical = imagem.Height * limiarProje��o;

			/// Encontrar o topo
			while (CalcularProje��oHorizontal(imagem, y1) < limiarProje��oHorizontal && y1 < y2)
				y1++;

			// Encontrar o limite inferior
			while (CalcularProje��oHorizontal(imagem, y2) < limiarProje��oHorizontal && y2 > y1)
				y2--;

			// Encontrar a esquerda
			while (CalcularProje��oVertical(imagem, x1) < limiarProje��oVertical && x1 < x2)
				x1++;

			// Encontrar a direita
			while (CalcularProje��oVertical(imagem, x2) < limiarProje��oVertical && x2 > x1)
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
			while (CalcularProje��oHorizontal(imagem, y1) == 0 && y1 > 0)
				y1--;

			// Encontrar o limite inferior
			while (CalcularProje��oHorizontal(imagem, y2) == 0 && y2 < imagem.Height - 1)
				y2++;

			// Encontrar a esquerda
			while (CalcularProje��oVertical(imagem, x1) == 0 && x1 > 0)
				x1--;

			// Encontrar a direita
			while (CalcularProje��oVertical(imagem, x2) == 0 && x2 < imagem.Width - 1)
				x2++;

			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}

		/// <summary>
		/// Calcula a proje��o horizontal
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="y">Linha onde ser� calculada a proje��o horizontal</param>
		/// <returns>Proje��o da linha</returns>
		private static long CalcularProje��oHorizontal(Bitmap imagem, int y)
		{
			long proje��o = 0;

			for (int x = 0; x < imagem.Width; x++)
				if (imagem.GetPixel(x, y).A > 0)
					proje��o++;

			return proje��o;
		}

		/// <summary>
		/// Calcula a proje��o vertical
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="x">Coluna onde ser� calculada a proje��o vertical</param>
		/// <returns>Proje��o da coluna</returns>
		private static long CalcularProje��oVertical(Bitmap imagem, int x)
		{
			long proje��o = 0;

			for (int y = 0; y < imagem.Height; y++)
				if (imagem.GetPixel(x, y).A > 0)
					proje��o++;

			return proje��o;
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

					// Suavizar transpar�ncia
					using (Bitmap suaviza��o = SuavizarTranspar�ncia(processamento))
					{
                        // N�o cortar foto
                        final = new Bitmap(suaviza��o);
					}
				}
			}

            final.Tag = imagem.Clone();

			return final;
		}

		/// <summary>
		/// Reconstr�i imagem processada, tentando remover �reas transparentes
		/// que s�o j�ias
		/// </summary>
		/// <param name="bmp">Imagem processada</param>
		/// <param name="transparente">Pontos transparentes</param>
		private void ReconstruirImagem(Bitmap bmp, bool [,] transparente)
		{
			bool [,] marcas = new bool[bmp.Width, bmp.Height];
			float limiarReconstru��o;

			limiarReconstru��o = this.limiarReconstru��o * bmp.Width * bmp.Height;

			for (int i = 0; i < bmp.Width; i++)
				for (int j = 0; j < bmp.Height; j++)
					marcas[i, j] = !transparente[i, j];

			for (int y = 0; y < bmp.Height; y++)
				for (int x = 0; x < bmp.Width; x++)
					if (transparente[x, y] && !marcas[x, y])
					{
						long �rea;
						ArrayList pontos;

						�rea = Calcular�rea(marcas, x, y, out pontos);

						if (�rea < limiarReconstru��o)
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
		/// Suaviza a transpar�ncia
		/// </summary>
		/// <param name="bmp">Imagem a ter sua transpar�ncia suavizada</param>
		/// <returns>Imagem com transpar�ncia suavizada</returns>
		private static Bitmap SuavizarTranspar�ncia(Bitmap bmp)
		{
			Bitmap suaviza��o = new Bitmap(bmp);

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

					suaviza��o.SetPixel(x, y, Color.FromArgb((int) Math.Round(a), pixel));
				}

			return suaviza��o;
		}

        /// <summary>
        /// Algumas placas de captura preenchem a borda com uma
        /// faixa colorida. A imagem � cortada nesta faixa por
        /// esta fun��o.
        /// </summary>
        /// <param name="img">Imagem a ser tratada.</param>
        /// <returns>Borda removida.</returns>
        public Bitmap CorrigirBorda(Bitmap img)
        {
            /* Percorrer as boras em toda sua extens�o verificando
             * quando o padr�o de cores se estabiliza, visto que
             * praticamente sempre nas bordas temos uma grande parte
             * em fundo braco. A faixa de ru�do apresentar� um
             * padr�o ou n�o at� encontrar o fundo.
             */
            int esq = verificarMargem, dir = img.Width - verificarMargem,
                cima = verificarMargem, baixo = img.Height - verificarMargem;

            // Vertical
            for (int y = 0; y < img.Height; y += (img.Height >> 3))
            {
                // Esquerda
                if (esq > 0)
                {
                    float refer�ncia = img.GetPixel(esq, y).GetHue();

                    for (int x = esq - 1; x >= 0; x--)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - refer�ncia) < limiarMargem)
                            esq = x;
                    }
                }

                // Direita
                if (dir < img.Width)
                {
                    float refer�ncia = img.GetPixel(dir, y).GetHue();

                    for (int x = dir + 1; x < img.Width; x++)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - refer�ncia) < limiarMargem)
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
                    float refer�ncia = img.GetPixel(x, cima).GetHue();

                    for (int y = cima - 1; y >= 0; y--)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - refer�ncia) < limiarMargem)
                            cima = y;
                    }
                }

                // Baixo
                if (baixo < img.Height)
                {
                    float refer�ncia = img.GetPixel(x, baixo).GetHue();

                    for (int y = baixo + 1; y < img.Height; y++)
                    {
                        float pixel = img.GetPixel(x, y).GetHue();

                        if (Math.Abs(pixel - refer�ncia) < limiarMargem)
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
