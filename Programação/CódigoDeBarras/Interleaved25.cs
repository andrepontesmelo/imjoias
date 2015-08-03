using System;
using System.Drawing;

namespace C�digoDeBarras
{
	/// <summary>
	/// Caracteres poss�veis: 0 a 9.
	/// Alternancia de barras gordas e magras.
	/// A barra pode ser preta ou branca (barra ou espa�o)
	/// Al�m disso, a codifica��o ocorre de dois em dois caracteres.
	/// Ex: codificar 1.
	/// 1 = 01 (occore sempre de 2 em dois caracteres)
	/// Deve-se Codificar 01:
	/// 0		00110  (pela tabela de tradu��o, 0 = false, 1 = true)
	/// 1: 		10001
	/// Resultado:
	/// 01.00.10.10.01
	/// Explica��o:
	/// Os conjuntos est�o separados por pontos	
	/// O primeiro caractere de cada conjunto corresponde 
	/// ao codigo do 0, o segundo caractere corresponde 'ao  1.
	/// Resultado final: inicio + 0100101001 + terminador
	/// Os zeros significam barra fina. podendo ser preta ou branca.
	/// Os 1s significam barra grossa. podendo ser preta ou branca.
	/// Como saber se � preta ou branca ? vai alternando.
	/// A primeira � preta (claro, o leitor optico tem que ler)
	/// a segunda � branca, a outra � preta... etc.
	/// </summary>
	public class Interleaved25 : GeradorC�digoDeBarras
	{
		/// <summary>
		/// Para cada caractere (0->9)que se deseja converter, existe uma sequencia
		/// de cinco s�mbolos. (cinco barras, sendo essas pretas e brancas alternadamente)
		/// tradu��o[ 0 , 0 ] = false
		/// tradu��o[ 0 , 1 ] = false 
		/// tradu��o[ 0 , 2 ] = true
		/// Isso quer dizer que o digito 0 ser� transformado em cinco digitos.
		/// o primeiro � uma barra false (fina)
		/// o segundo � uma barra false (fina)
		/// o terceiro � uma barra true (larga).
		/// </summary>
		private bool [,] tradu��o = new bool[10, 5];

		/// <summary>
		/// Constr�i o padr�o Interleaved 25
		/// </summary>
		public Interleaved25() 
		{
			//0 {false,false,true,true,false}
			tradu��o[0,0] = false;
			tradu��o[0,1] = false;
			tradu��o[0,2] = true;
			tradu��o[0,3] = true;
			tradu��o[0,4] = false;

			//1 {true,false,false,false,true}
			tradu��o[1,0] = true;
			tradu��o[1,1] = false;
			tradu��o[1,2] = false;
			tradu��o[1,3] = false;
			tradu��o[1,4] = true;

			//2 {false,true,false,false,true}
			tradu��o[2,0] = false;
			tradu��o[2,1] = true;
			tradu��o[2,2] = false;
			tradu��o[2,3] = false;
			tradu��o[2,4] = true;
			
			//3 {true,true,false,false,false}
			tradu��o[3,0] = true;
			tradu��o[3,1] = true;
			tradu��o[3,2] = false;
			tradu��o[3,3] = false;
			tradu��o[3,4] = false;

			//4 {false,false,true,false,true}
			tradu��o[4,0] = false;
			tradu��o[4,1] = false;
			tradu��o[4,2] = true;
			tradu��o[4,3] = false;
			tradu��o[4,4] = true;

			//5 {true,false,true,false,false}
			tradu��o[5,0] = true;
			tradu��o[5,1] = false;
			tradu��o[5,2] = true;
			tradu��o[5,3] = false;
			tradu��o[5,4] = false;
				
			//6 {false,true,true,false,false}
			tradu��o[6,0] = false;
			tradu��o[6,1] = true;
			tradu��o[6,2] = true;
			tradu��o[6,3] = false;
			tradu��o[6,4] = false;

			//7 {false,false,false,true,true}
			tradu��o[7,0] = false;
			tradu��o[7,1] = false;
			tradu��o[7,2] = false;
			tradu��o[7,3] = true;
			tradu��o[7,4] = true;

			//8 {true,false,false,true,false}
			tradu��o[8,0] = true;
			tradu��o[8,1] = false;
			tradu��o[8,2] = false;
			tradu��o[8,3] = true;
			tradu��o[8,4] = false;

			//9 {false,true,false,true,false}
			tradu��o[9,0] = false;
			tradu��o[9,1] = true;
			tradu��o[9,2] = false;
			tradu��o[9,3] = true;
			tradu��o[9,4] = false;
		}

		/// <summary>
		/// Gera c�digo booleano
		/// </summary>
		/// <param name="c�digo">C�digo original</param>
		/// <returns>C�digo booleano</returns>
		protected override bool[] GerarC�digoBooleano(string c�digo)
		{
			// Padr�o s� permite n�meros pares
			if (c�digo.Length % 2 != 0)
				c�digo = c�digo.Insert(0, "0");

			return CriarBarra(c�digo);
		}

		/// <summary>
		/// True � gordo. False � fino.
		/// </summary>
		/// <param name="entradaDeDoisDigitos">Num para codificar. ex: ('0','1')</param>
		/// <returns></returns>
		private bool [] CriarBarra(string entradaDeDoisDigitos)
		{
			// 4 + 3 significa 4 d�gitos de in�cio e 3 de parada.
			// 5 * porque cada d�gito se transforma em cinco.
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
			int gravePosi��oAtual = 4;			// Salta os digitos iniciais

			// Veja explica��o do padr�o Interleaved para saber porque posEntrada += 2:
			for (int posEntrada = 0; posEntrada < entradaDeDoisDigitos.Length; posEntrada += 2)
			{
				for (int posTradu��o = 0; posTradu��o < 5; posTradu��o++)
				{
					resultado[gravePosi��oAtual] = tradu��o[entradaDeDoisDigitos[posEntrada] - '0', posTradu��o];
					resultado[gravePosi��oAtual + 1] = tradu��o[entradaDeDoisDigitos[posEntrada + 1] - '0', posTradu��o];
					gravePosi��oAtual += 2;
				}
			}

			return resultado;
		}

		/// <summary>
		/// Gera imagem de c�digo de barras
		/// </summary>
		/// <param name="c�digo">Codigo a ser gerado</param>
		/// <param name="tamanhoImagem">Tamanho em pixels da imagem</param>
		/// <param name="larguraBarraFina">Largura em pixels da barra fina</param>
		/// <param name="fatorBarraGrossa">Quantas vezes a barra grossa � maior que a barra fina</param>
		/// <returns>Imagem do c�digo de barras</returns>
		protected override Image Desenhar(bool [] c�digoBooleano, Size tamanhoImagem, double larguraBarraFina, double fatorBarraGrossa)
		{
			double	posi��oXAtual = 0;
			bool    agora�Preto   = true;

			Bitmap img = new Bitmap(tamanhoImagem.Width, tamanhoImagem.Height);
			
			using (Graphics g = Graphics.FromImage(img))
			{
				g.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height);

				for (int barraN�mero = 0; barraN�mero < c�digoBooleano.Length; barraN�mero++)
				{
					if (agora�Preto) //Imprimir barra. Observe que n�o precisa imprimir espa�o, pois o fundo � branco.
					{
						if (c�digoBooleano[barraN�mero]) 
							g.FillRectangle(
								Brushes.Black,
								(float) posi��oXAtual,
								0,
								(float) (larguraBarraFina * fatorBarraGrossa),
								tamanhoImagem.Height);
						else
							g.FillRectangle(
								Brushes.Black,
								(float) posi��oXAtual,
								0,
								(float) larguraBarraFina,
								tamanhoImagem.Height);
					} 

					if (c�digoBooleano[barraN�mero])
						posi��oXAtual += larguraBarraFina * fatorBarraGrossa;
					else 
						posi��oXAtual += larguraBarraFina;

					agora�Preto = !agora�Preto; // Alternancia entre barra e espa�o
				}
			}

			if (Math.Round(posi��oXAtual) > tamanhoImagem.Width)
				throw new OverflowException("N�o foi poss�vel desenhar c�digo de barras no espa�o delimitado!");

			return img;
		}

		/// <summary>
		/// Calcula a quantidade de barras finas e grossas
		/// </summary>
		/// <param name="c�digo">C�digo a ser verificado</param>
		/// <param name="barrasFinas">Quantidade de barras finas calculdadas</param>
		/// <param name="barrasGrossas">Quantidade de barras grossas calculadas</param>
		protected override void CalcularTamanho(bool [] c�digo, out int barrasFinas, out int barrasGrossas)
		{
			int n = c�digo.Length;

			barrasFinas = ((n - 7) / 5) * 3 + 6;
			barrasGrossas = ((n - 7) / 5) * 2 + 1;
		}
	}
}
