using Entidades;
using Entidades.Pessoa;

using System;
using System.Collections;

namespace Ind�stria_Mineira_de_J�ias.An�liseEstat�stica
{
	public sealed class An�lises
	{
		private An�lises() {}

		#region Telefonemas

		/// <summary>
		/// Constr�i estat�sticas sobre os telefonemas de um funcino�rio
		/// </summary>
		/// <param name="acesso">Objeto de acesso ao banco de dados</param>
		/// <param name="in�cio">Per�odo inicial</param>
		/// <param name="final">Per�odo final</param>
		public static void AnalisarTelefonemas(Neg�cio.Controle.IControle controle, DateTime in�cio, DateTime final, Funcion�rio funcion�rio, out ArrayList telefonemas, out double [] telefonemasDi�rios, out double [] pizzaTelefonemas)
		{
			long		total;
			int			dias;

			dias = ((TimeSpan) (final.Date - in�cio.Date)).Days + 1;

			// Coletar dados
			total = controle.ObterTelefonemas(in�cio, final);
			telefonemas = controle.ObterTelefonemas(in�cio, final, funcion�rio);

			// Analisar propor��o das liga��es
			pizzaTelefonemas = new double[2];
			pizzaTelefonemas[0] = telefonemas.Count;
			pizzaTelefonemas[1] = total - pizzaTelefonemas[0];

			// Analisar crescimento de liga��es
			telefonemasDi�rios = new double[dias];

			foreach (Telefonema telefonema in telefonemas)
				telefonemasDi�rios[Dias(in�cio, telefonema.Quando)]++;
		}

		#endregion

		/// <summary>
		/// Dias entre duas datas
		/// </summary>
		private static int Dias(DateTime in�cio, DateTime atual)
		{
			TimeSpan dif = atual.Date - in�cio.Date;

			return dif.Days;
		}

		#region Visitantes

		/// <summary>
		/// Espera de visitantes
		/// </summary>
		/// <param name="controle">Objeto de controle</param>
		/// <param name="nVisitantes">Quantidade de visitantes (�ltimos)</param>
		/// <param name="setor">C�digo do setor a ser analisado</param>
		public static double [] AnalisarEsperaXVisitantes(Neg�cio.Controle.IControle controle, int nVisitantes, long setor)
		{
			double [] dados;
			double [] esperas;

			dados = new double [nVisitantes];
			esperas  = controle.ObterEsperas(nVisitantes, setor);

			// Preencher dados
			for (int i = nVisitantes - 1; i >= nVisitantes - esperas.Length; i--)
				dados[i] = esperas[nVisitantes - i - 1];

			return dados;
		}

		#endregion
	}
}
