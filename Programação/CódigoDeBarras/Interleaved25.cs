using System;
using System.Drawing;

namespace CódigoDeBarras
{
	/// <summary>
	/// Caracteres possíveis: 0 a 9.
	/// Alternancia de barras gordas e magras.
	/// A barra pode ser preta ou branca (barra ou espaço)
	/// Além disso, a codificação ocorre de dois em dois caracteres.
	/// Ex: codificar 1.
	/// 1 = 01 (occore sempre de 2 em dois caracteres)
	/// Deve-se Codificar 01:
	/// 0		00110  (pela tabela de tradução, 0 = false, 1 = true)
	/// 1: 		10001
	/// Resultado:
	/// 01.00.10.10.01
	/// Explicação:
	/// Os conjuntos estão separados por pontos	
	/// O primeiro caractere de cada conjunto corresponde 
	/// ao codigo do 0, o segundo caractere corresponde 'ao  1.
	/// Resultado final: inicio + 0100101001 + terminador
	/// Os zeros significam barra fina. podendo ser preta ou branca.
	/// Os 1s significam barra grossa. podendo ser preta ou branca.
	/// Como saber se é preta ou branca ? vai alternando.
	/// A primeira é preta (claro, o leitor optico tem que ler)
	/// a segunda é branca, a outra é preta... etc.
	/// </summary>
	public class Interleaved25 : GeradorCódigoDeBarras
	{
		/// <summary>
		/// Para cada caractere (0->9)que se deseja converter, existe uma sequencia
		/// de cinco símbolos. (cinco barras, sendo essas pretas e brancas alternadamente)
		/// tradução[ 0 , 0 ] = false
		/// tradução[ 0 , 1 ] = false 
		/// tradução[ 0 , 2 ] = true
		/// Isso quer dizer que o digito 0 será transformado em cinco digitos.
		/// o primeiro é uma barra false (fina)
		/// o segundo é uma barra false (fina)
		/// o terceiro é uma barra true (larga).
		/// </summary>
		private bool [,] tradução = new bool[10, 5];

		/// <summary>
		/// Constrói o padrão Interleaved 25
		/// </summary>
		public Interleaved25() 
		{
			//0 {false,false,true,true,false}
			tradução[0,0] = false;
			tradução[0,1] = false;
			tradução[0,2] = true;
			tradução[0,3] = true;
			tradução[0,4] = false;

			//1 {true,false,false,false,true}
			tradução[1,0] = true;
			tradução[1,1] = false;
			tradução[1,2] = false;
			tradução[1,3] = false;
			tradução[1,4] = true;

			//2 {false,true,false,false,true}
			tradução[2,0] = false;
			tradução[2,1] = true;
			tradução[2,2] = false;
			tradução[2,3] = false;
			tradução[2,4] = true;
			
			//3 {true,true,false,false,false}
			tradução[3,0] = true;
			tradução[3,1] = true;
			tradução[3,2] = false;
			tradução[3,3] = false;
			tradução[3,4] = false;

			//4 {false,false,true,false,true}
			tradução[4,0] = false;
			tradução[4,1] = false;
			tradução[4,2] = true;
			tradução[4,3] = false;
			tradução[4,4] = true;

			//5 {true,false,true,false,false}
			tradução[5,0] = true;
			tradução[5,1] = false;
			tradução[5,2] = true;
			tradução[5,3] = false;
			tradução[5,4] = false;
				
			//6 {false,true,true,false,false}
			tradução[6,0] = false;
			tradução[6,1] = true;
			tradução[6,2] = true;
			tradução[6,3] = false;
			tradução[6,4] = false;

			//7 {false,false,false,true,true}
			tradução[7,0] = false;
			tradução[7,1] = false;
			tradução[7,2] = false;
			tradução[7,3] = true;
			tradução[7,4] = true;

			//8 {true,false,false,true,false}
			tradução[8,0] = true;
			tradução[8,1] = false;
			tradução[8,2] = false;
			tradução[8,3] = true;
			tradução[8,4] = false;

			//9 {false,true,false,true,false}
			tradução[9,0] = false;
			tradução[9,1] = true;
			tradução[9,2] = false;
			tradução[9,3] = true;
			tradução[9,4] = false;
		}

		/// <summary>
		/// Gera código booleano
		/// </summary>
		/// <param name="código">Código original</param>
		/// <returns>Código booleano</returns>
		protected override bool[] GerarCódigoBooleano(string código)
		{
			// Padrão só permite números pares
			if (código.Length % 2 != 0)
				código = código.Insert(0, "0");

			return CriarBarra(código);
		}

		/// <summary>
		/// True é gordo. False é fino.
		/// </summary>
		/// <param name="entradaDeDoisDigitos">Num para codificar. ex: ('0','1')</param>
		/// <returns></returns>
		private bool [] CriarBarra(string entradaDeDoisDigitos)
		{
			// 4 + 3 significa 4 dígitos de início e 3 de parada.
			// 5 * porque cada dígito se transforma em cinco.
			bool [] resultado = new bool[(5 * entradaDeDoisDigitos.Length) + 4 + 3];

			// Iniciador:
			resultado[0] = false;
			resultado[1] = false;
			resultado[2] = false;
			resultado[3] = false;

			// Finalizador: true false false
			resultado[resultado.Length - 3] = true;
			resultado[resultado.Length - 2] = false;
			resultado[resultado.Length - 1] = false;

			// Preencher o miolo, de dois em dois algarismos.
			int gravePosiçãoAtual = 4;			// Salta os digitos iniciais

			// Veja explicação do padrão Interleaved para saber porque posEntrada += 2:
			for (int posEntrada = 0; posEntrada < entradaDeDoisDigitos.Length; posEntrada += 2)
			{
				for (int posTradução = 0; posTradução < 5; posTradução++)
				{
					resultado[gravePosiçãoAtual] = tradução[entradaDeDoisDigitos[posEntrada] - '0', posTradução];
					resultado[gravePosiçãoAtual + 1] = tradução[entradaDeDoisDigitos[posEntrada + 1] - '0', posTradução];
					gravePosiçãoAtual += 2;
				}
			}

			return resultado;
		}

		/// <summary>
		/// Gera imagem de código de barras
		/// </summary>
		/// <param name="código">Codigo a ser gerado</param>
		/// <param name="tamanhoImagem">Tamanho em pixels da imagem</param>
		/// <param name="larguraBarraFina">Largura em pixels da barra fina</param>
		/// <param name="fatorBarraGrossa">Quantas vezes a barra grossa é maior que a barra fina</param>
		/// <returns>Imagem do código de barras</returns>
		protected override Image Desenhar(bool [] códigoBooleano, Size tamanhoImagem, double larguraBarraFina, double fatorBarraGrossa)
		{
			double	posiçãoXAtual = 0;
			bool    agoraÉPreto   = true;

			Bitmap img = new Bitmap(tamanhoImagem.Width, tamanhoImagem.Height);
			
			using (Graphics g = Graphics.FromImage(img))
			{
				g.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height);

				for (int barraNúmero = 0; barraNúmero < códigoBooleano.Length; barraNúmero++)
				{
					if (agoraÉPreto) //Imprimir barra. Observe que não precisa imprimir espaço, pois o fundo é branco.
					{
						if (códigoBooleano[barraNúmero]) 
							g.FillRectangle(
								Brushes.Black,
								(float) posiçãoXAtual,
								0,
								(float) (larguraBarraFina * fatorBarraGrossa),
								tamanhoImagem.Height);
						else
							g.FillRectangle(
								Brushes.Black,
								(float) posiçãoXAtual,
								0,
								(float) larguraBarraFina,
								tamanhoImagem.Height);
					} 

					if (códigoBooleano[barraNúmero])
						posiçãoXAtual += larguraBarraFina * fatorBarraGrossa;
					else 
						posiçãoXAtual += larguraBarraFina;

					agoraÉPreto = !agoraÉPreto; // Alternancia entre barra e espaço
				}
			}

			if (Math.Round(posiçãoXAtual) > tamanhoImagem.Width)
				throw new OverflowException("Não foi possível desenhar código de barras no espaço delimitado!");

			return img;
		}

		/// <summary>
		/// Calcula a quantidade de barras finas e grossas
		/// </summary>
		/// <param name="código">Código a ser verificado</param>
		/// <param name="barrasFinas">Quantidade de barras finas calculdadas</param>
		/// <param name="barrasGrossas">Quantidade de barras grossas calculadas</param>
		protected override void CalcularTamanho(bool [] código, out int barrasFinas, out int barrasGrossas)
		{
			int n = código.Length;

			barrasFinas = ((n - 7) / 5) * 3 + 6;
			barrasGrossas = ((n - 7) / 5) * 2 + 1;
		}
	}
}
