using System;
using System.Drawing;

namespace CodigoBarrasProg
{
#region Explicação do Padrão Interleaved25 2:1
	/* 
	 * Caracteres possíveis: 0 a 9.
	 * Alternancia de barras gordas e magras.
	 * A barra pode ser preta ou branca (barra ou espaço)
	 * Além disso, a codificação ocorre de dois em dois caracteres.
	 * Ex: codificar 1.
	 * 1 = 01 (occore sempre de 2 em dois caracteres)
	 * Deve-se Codificar 01: 
		0		00110  (pela tabela de tradução, 0 = false, 1 = true)
		1: 		10001
		Resultado:
		01.00.10.10.01
		Explicação:
		Os conjuntos estão separados por pontos	
		O primeiro caractere de cada conjunto corresponde 
		ao codigo do 0, o segundo caractere corresponde 'ao  1.
		resultado final: inicio + 0100101001 + termiador
		os zeros significam barra fina. podendo ser preta ou branca.
		os 1s significam barra grossa. podendo ser preta ou branca
		Como saber se é preta ou branca ? vai alternando.
		A primeira é preta (claro, o leitor optico tem que ler)
		a segunda é branca, a outra é preta... etc.
	 * 
	*/
	#endregion
	public class CódigoDeBarras
	{
		#region Explicação de LARGURAGROSSA
		/*LARGURAGROSSA é quantas vezes a barra grossa
		 * será mais grossa que a barra mais fina.
		 * Caso seja 2, o padrão é o Interleaved 25 2:1
		 * Caso seja 3, o padrão é o Interleaved 25 3:1 (a barra obviamente fica maior)
		 * */
		#endregion
		const int LARGURAGROSSA = 2;

		private bool [,] tradução = new bool[10,5]; //depois tornar estático.
		#region Explicação de tradução
		/*
		 * Para cada caractere (0->9)que se deseja converter, existe uma sequencia
		 * de cinco símbolos. (cinco barras, sendo essas pretas e brancas alternadamente)
		 * tradução[ 0 , 0 ] = false
		 * tradução[ 0 , 1 ] = false 
		 * tradução[ 0 , 2 ] = true
		 * Isso quer dizer que o digito 0 será transformado em cinco digitos.
		 * o primeiro é uma barra false (fina)
		 * o segundo é uma barra false (fina)
		 * o terceiro é uma barra true (larga).
		 * 
		*/

		#endregion
		private char [] númerosEntrada; //entrada não pronta, sem inicio nem parada.
		private bool [] códigoBooleano; //barras prontas, com inicio e parada. true é largo, false é fino.
		
		private void PreencheTraduçãoPadrãoInterleaved25() 
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
		/// Contrutora: pega o string, e deixa criado códigoBooleano ([] bool)
		/// essencial para fazer a Imagem depois
		/// </summary>
		/// <param name="Código">caractéres de 0 a 9, código para confecção das barras</param>
		public CódigoDeBarras(string Código)
		{
			PreencheTraduçãoPadrãoInterleaved25();

			//123 -> 0123 O padrão só permite seqüências pares.
			if (Código.Length%2 != 0)
				Código = "0" + Código;
				
			númerosEntrada = Código.ToCharArray(0,Código.Length); 
			códigoBooleano = CriarBarra(númerosEntrada); 
		}
		
		/// <summary>
		/// True é gordo. False é fino.
		/// </summary>
		/// <param name="entradaDeDoisDigitos">Num para codificar. ex: ('0','1')</param>
		/// <returns></returns>
		private bool [] CriarBarra(Char [] entradaDeDoisDigitos)
		{
			//4+3 significa 4 digitos de inicio e 3 de parada.
			//5* porque cada digito se transforma em cinco.
			bool [] resultado = new bool[(5*entradaDeDoisDigitos.Length)+4+3];
			//Iniciador:
			resultado[0] = false;
			resultado[1] = false;
			resultado[2] = false;
			resultado[3] = false;
			//Finalizador: true false false
			resultado[resultado.Length-3] = true;
			resultado[resultado.Length-2] = false;
			resultado[resultado.Length-1] = false;

			//Preencher o miolo, de dois em dois algarismos.
			int gravePosiçãoAtual=4; //Salta os digitos iniciais
			//Veja explicação do padrão Interleaved para saber porque posEntrada+=2:
			for (int posEntrada = 0; posEntrada<entradaDeDoisDigitos.Length; posEntrada+=2)
			{
				for (int posTradução = 0; posTradução < 5; posTradução++ )
				{
					//O -48 decorre do fato de transformar de char para int. chr(48) = 0.
					resultado[gravePosiçãoAtual] = tradução[ entradaDeDoisDigitos[posEntrada]-48,posTradução];
					resultado[gravePosiçãoAtual+1] = tradução[ entradaDeDoisDigitos[posEntrada+1]-48,posTradução];
					gravePosiçãoAtual+=2;
				}
			}
			return resultado;
		}
		
		public Image GerarImagem(int largura,int altura,int larguraBarraFina) 
		{
			int posiçãoXAtual=0;
			bool agoraÉpreto=true;

			Image img = new Bitmap(largura, altura);
			
			using (Graphics g = Graphics.FromImage(img))
			{
				g.FillRectangle(Brushes.White, 0, 0,largura ,altura);
				for (int barraNúmero=0;barraNúmero<códigoBooleano.Length;barraNúmero++)
				{
					if (agoraÉpreto) //Imprimir barra. Observe que não precisa imprimir espaço, pois o fundo é branco.
					{
						if (códigoBooleano[barraNúmero]) 
						{
							g.FillRectangle(System.Drawing.Brushes.Black,posiçãoXAtual,0,larguraBarraFina*LARGURAGROSSA,altura);
						} 
						else
						{
							g.FillRectangle(System.Drawing.Brushes.Black,posiçãoXAtual,0,larguraBarraFina,altura);
						}
					} 
					if (códigoBooleano[barraNúmero])
					{
						posiçãoXAtual += larguraBarraFina * LARGURAGROSSA;
						
					} 
					else 
					{
						posiçãoXAtual += larguraBarraFina;
					}

					agoraÉpreto = !agoraÉpreto; //Alternancia entre barra e espaço
				}
			}
			return img;
		}
	}
}
