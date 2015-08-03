using Entidades;
using Entidades.Pessoa;

using System;
using System.Collections;

namespace Indústria_Mineira_de_Jóias.AnáliseEstatística
{
	public sealed class Análises
	{
		private Análises() {}

		#region Telefonemas

		/// <summary>
		/// Constrói estatísticas sobre os telefonemas de um funcinoário
		/// </summary>
		/// <param name="acesso">Objeto de acesso ao banco de dados</param>
		/// <param name="início">Período inicial</param>
		/// <param name="final">Período final</param>
		public static void AnalisarTelefonemas(Negócio.Controle.IControle controle, DateTime início, DateTime final, Funcionário funcionário, out ArrayList telefonemas, out double [] telefonemasDiários, out double [] pizzaTelefonemas)
		{
			long		total;
			int			dias;

			dias = ((TimeSpan) (final.Date - início.Date)).Days + 1;

			// Coletar dados
			total = controle.ObterTelefonemas(início, final);
			telefonemas = controle.ObterTelefonemas(início, final, funcionário);

			// Analisar proporção das ligações
			pizzaTelefonemas = new double[2];
			pizzaTelefonemas[0] = telefonemas.Count;
			pizzaTelefonemas[1] = total - pizzaTelefonemas[0];

			// Analisar crescimento de ligações
			telefonemasDiários = new double[dias];

			foreach (Telefonema telefonema in telefonemas)
				telefonemasDiários[Dias(início, telefonema.Quando)]++;
		}

		#endregion

		/// <summary>
		/// Dias entre duas datas
		/// </summary>
		private static int Dias(DateTime início, DateTime atual)
		{
			TimeSpan dif = atual.Date - início.Date;

			return dif.Days;
		}

		#region Visitantes

		/// <summary>
		/// Espera de visitantes
		/// </summary>
		/// <param name="controle">Objeto de controle</param>
		/// <param name="nVisitantes">Quantidade de visitantes (últimos)</param>
		/// <param name="setor">Código do setor a ser analisado</param>
		public static double [] AnalisarEsperaXVisitantes(Negócio.Controle.IControle controle, int nVisitantes, long setor)
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
