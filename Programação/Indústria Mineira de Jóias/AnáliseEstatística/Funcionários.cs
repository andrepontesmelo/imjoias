using System;
using System.Collections;
using System.Data;

namespace Indústria_Mineira_de_Jóias.AnáliseEstatística
{
	public sealed class Funcionários : Analisador
	{
		private IDbConnection conexão;

		public Funcionários(IDbConnection conexão)
		{
			this.conexão = conexão;
		}

		#region Telefonemas

		/// <summary>
		/// Constrói estatísticas sobre os telefonemas de um funcinoário
		/// </summary>
		/// <param name="acesso">Objeto de acesso ao banco de dados</param>
		/// <param name="início">Período inicial</param>
		/// <param name="final">Período final</param>
		/// <param name="funcionário">Código do funcionário</param>
		public void ObterTelefonemas(DateTime início, DateTime final, long funcionário, out ArrayList telefonemas, out double [] telefonemasDiários, out double [] pizzaTelefonemas)
		{
			throw new NotImplementedException("Reimplementar!!!");
/*			long		total;
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
*/		}

		#endregion

		/// <summary>
		/// Dias entre duas datas
		/// </summary>
		private int Dias(DateTime início, DateTime atual)
		{
			TimeSpan dif = atual.Date - início.Date;

			return dif.Days;
		}
	}
}
