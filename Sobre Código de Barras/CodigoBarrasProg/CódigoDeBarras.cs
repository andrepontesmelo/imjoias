using System;
using System.Drawing;

namespace CodigoBarrasProg
{
#region Explica��o do Padr�o Interleaved25 2:1
	/* 
	 * Caracteres poss�veis: 0 a 9.
	 * Alternancia de barras gordas e magras.
	 * A barra pode ser preta ou branca (barra ou espa�o)
	 * Al�m disso, a codifica��o ocorre de dois em dois caracteres.
	 * Ex: codificar 1.
	 * 1 = 01 (occore sempre de 2 em dois caracteres)
	 * Deve-se Codificar 01: 
		0		00110  (pela tabela de tradu��o, 0 = false, 1 = true)
		1: 		10001
		Resultado:
		01.00.10.10.01
		Explica��o:
		Os conjuntos est�o separados por pontos	
		O primeiro caractere de cada conjunto corresponde 
		ao codigo do 0, o segundo caractere corresponde 'ao  1.
		resultado final: inicio + 0100101001 + termiador
		os zeros significam barra fina. podendo ser preta ou branca.
		os 1s significam barra grossa. podendo ser preta ou branca
		Como saber se � preta ou branca ? vai alternando.
		A primeira � preta (claro, o leitor optico tem que ler)
		a segunda � branca, a outra � preta... etc.
	 * 
	*/
	#endregion
	public class C�digoDeBarras
	{
		#region Explica��o de LARGURAGROSSA
		/*LARGURAGROSSA � quantas vezes a barra grossa
		 * ser� mais grossa que a barra mais fina.
		 * Caso seja 2, o padr�o � o Interleaved 25 2:1
		 * Caso seja 3, o padr�o � o Interleaved 25 3:1 (a barra obviamente fica maior)
		 * */
		#endregion
		const int LARGURAGROSSA = 2;

		private bool [,] tradu��o = new bool[10,5]; //depois tornar est�tico.
		#region Explica��o de tradu��o
		/*
		 * Para cada caractere (0->9)que se deseja converter, existe uma sequencia
		 * de cinco s�mbolos. (cinco barras, sendo essas pretas e brancas alternadamente)
		 * tradu��o[ 0 , 0 ] = false
		 * tradu��o[ 0 , 1 ] = false 
		 * tradu��o[ 0 , 2 ] = true
		 * Isso quer dizer que o digito 0 ser� transformado em cinco digitos.
		 * o primeiro � uma barra false (fina)
		 * o segundo � uma barra false (fina)
		 * o terceiro � uma barra true (larga).
		 * 
		*/

		#endregion
		private char [] n�merosEntrada; //entrada n�o pronta, sem inicio nem parada.
		private bool [] c�digoBooleano; //barras prontas, com inicio e parada. true � largo, false � fino.
		
		private void PreencheTradu��oPadr�oInterleaved25() 
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
		/// Contrutora: pega o string, e deixa criado c�digoBooleano ([] bool)
		/// essencial para fazer a Imagem depois
		/// </summary>
		/// <param name="C�digo">caract�res de 0 a 9, c�digo para confec��o das barras</param>
		public C�digoDeBarras(string C�digo)
		{
			PreencheTradu��oPadr�oInterleaved25();

			//123 -> 0123 O padr�o s� permite seq��ncias pares.
			if (C�digo.Length%2 != 0)
				C�digo = "0" + C�digo;
				
			n�merosEntrada = C�digo.ToCharArray(0,C�digo.Length); 
			c�digoBooleano = CriarBarra(n�merosEntrada); 
		}
		
		/// <summary>
		/// True � gordo. False � fino.
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
			int gravePosi��oAtual=4; //Salta os digitos iniciais
			//Veja explica��o do padr�o Interleaved para saber porque posEntrada+=2:
			for (int posEntrada = 0; posEntrada<entradaDeDoisDigitos.Length; posEntrada+=2)
			{
				for (int posTradu��o = 0; posTradu��o < 5; posTradu��o++ )
				{
					//O -48 decorre do fato de transformar de char para int. chr(48) = 0.
					resultado[gravePosi��oAtual] = tradu��o[ entradaDeDoisDigitos[posEntrada]-48,posTradu��o];
					resultado[gravePosi��oAtual+1] = tradu��o[ entradaDeDoisDigitos[posEntrada+1]-48,posTradu��o];
					gravePosi��oAtual+=2;
				}
			}
			return resultado;
		}
		
		public Image GerarImagem(int largura,int altura,int larguraBarraFina) 
		{
			int posi��oXAtual=0;
			bool agora�preto=true;

			Image img = new Bitmap(largura, altura);
			
			using (Graphics g = Graphics.FromImage(img))
			{
				g.FillRectangle(Brushes.White, 0, 0,largura ,altura);
				for (int barraN�mero=0;barraN�mero<c�digoBooleano.Length;barraN�mero++)
				{
					if (agora�preto) //Imprimir barra. Observe que n�o precisa imprimir espa�o, pois o fundo � branco.
					{
						if (c�digoBooleano[barraN�mero]) 
						{
							g.FillRectangle(System.Drawing.Brushes.Black,posi��oXAtual,0,larguraBarraFina*LARGURAGROSSA,altura);
						} 
						else
						{
							g.FillRectangle(System.Drawing.Brushes.Black,posi��oXAtual,0,larguraBarraFina,altura);
						}
					} 
					if (c�digoBooleano[barraN�mero])
					{
						posi��oXAtual += larguraBarraFina * LARGURAGROSSA;
						
					} 
					else 
					{
						posi��oXAtual += larguraBarraFina;
					}

					agora�preto = !agora�preto; //Alternancia entre barra e espa�o
				}
			}
			return img;
		}
	}
}
