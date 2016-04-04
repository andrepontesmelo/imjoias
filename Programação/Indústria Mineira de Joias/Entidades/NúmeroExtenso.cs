using System;

namespace Entidades
{
	/// <summary>
	/// Converte número para formato extenso 
	/// </summary>
	public sealed class NúmeroExtenso
	{
		private NúmeroExtenso() {}

		/// <summary>
		/// Transforma um número real para o formato extenso
		/// </summary>
		/// <param name="número">Valor a ser formatado</param>
		/// <returns>Número extenso</returns>
		public static string Transformar(decimal valor)
		{
			int conta, parte;
			string [] s_singular = new string [] {"REAL", "MIL", "MILHÃO", "BILHÃO", "TRILHÃO"};
			string [] s_plural = new string [] {"REAIS", "MIL", "MILHÕES", "BILHÕES", "TRILHÕES"};
			string [] s_unidade = new string [] {"ZERO", "UM", "DOIS", "TRÊS", "QUATRO", "CINCO",
				"SEIS", "SETE", "OITO", "NOVE", "DEZ", "ONZE", "DOZE", "TREZE",
				"QUATORZE", "QUINZE", "DEZESSEIS", "DEZESSETE", "DEZOITO", "DEZENOVE"};
			string [] s_dezena = new string [] {"", "", "VINTE", "TRINTA", "QUARENTA",
				"CINQÜENTA", "SESSENTA", "SETENTA", "OITENTA", "NOVENTA", "CEM"};
			string [] s_centena = new string [] {"", "CENTO", "DUZENTOS", "TREZENTOS",
				"QUATROCENTOS", "QUINHENTOS", "SEISCENTOS", "SETECENTOS",
				"OITOCENTOS", "NOVECENTOS"};
			const string s_espaco = " ", s_e = " E ";
			bool anterior = false;
			int i = 0, cont;
			string txt;
			string extenso = "";

			if (valor < 0)
				return null;

			if (valor == 0)
				return s_unidade[0];

			parte = (int) valor;

			do
			{
				txt = "";

				conta = parte % 1000;
				cont = 0;

				if (anterior)
				{
					extenso = ", " + extenso;
					anterior = false;
				}

				if (conta > 100)
				{
					txt = s_centena[conta / 100];
					conta %= 100;
					anterior = true;
					cont = 3;
				}

				if (conta > 19)
				{
					if (anterior)
						txt = txt + s_e + s_dezena[conta / 10];
					else
						txt = s_dezena[conta / 10];
					anterior = true;
					conta %= 10;
					cont += 2;
				}

				if (conta > 0)
				{
					if (i != 1 || parte != 1)
					{
						if (anterior)
							txt = txt + s_e + s_unidade[conta];
						else
							txt = s_unidade[conta];
					}
					cont++;
					anterior = true;
				}

				if (i == 0 && parte % 1000 <= 1 && Math.Floor(valor) > 1)
					extenso = txt + s_espaco + s_plural[i] + extenso;
				else if (parte % 1000 > 0)
					extenso = txt + s_espaco + (parte > 1 ? s_plural[i] : s_singular[i]) + extenso;

				if (i++ == 0 && cont <= 3 && cont > 0 && valor > 999)
				{
					extenso = s_e + extenso;
					anterior = false;
				}

				parte /= 1000;
			} while (parte > 0);

			if (extenso.Length > 0)
				switch (extenso[0])
				{
				case ' ':
					extenso = extenso.Trim();
					break;
			
				case 'U':
					extenso = "H" + extenso;
					break;
				}

			//txt.Format("%f", (valor - (int) valor) * 100);
			int fracao = (int) ((valor - (int) valor) * 100);

			if (fracao > 0)
			{
				txt = "";

				if (fracao > 19)
				{
					if (fracao % 10 > 0)
						txt = txt + s_dezena[fracao / 10] + s_e  + s_unidade[fracao % 10];
			
					else
						txt = s_dezena[fracao / 10];
				}
				else
					txt = s_unidade[fracao];

				if (extenso.Length > 0)
					extenso = extenso + s_e + txt;
			
				else
					extenso = txt;

				if (fracao > 1)
					extenso += " CENTAVOS";
				else
					extenso += " CENTAVO";
			}

			return extenso;
		}
	}
}
