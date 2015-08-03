using System;
using System.Collections;
using System.Data;

namespace Ind�stria_Mineira_de_J�ias.An�liseEstat�stica
{
	public sealed class Funcion�rios : Analisador
	{
		private IDbConnection conex�o;

		public Funcion�rios(IDbConnection conex�o)
		{
			this.conex�o = conex�o;
		}

		#region Telefonemas

		/// <summary>
		/// Constr�i estat�sticas sobre os telefonemas de um funcino�rio
		/// </summary>
		/// <param name="acesso">Objeto de acesso ao banco de dados</param>
		/// <param name="in�cio">Per�odo inicial</param>
		/// <param name="final">Per�odo final</param>
		/// <param name="funcion�rio">C�digo do funcion�rio</param>
		public void ObterTelefonemas(DateTime in�cio, DateTime final, long funcion�rio, out ArrayList telefonemas, out double [] telefonemasDi�rios, out double [] pizzaTelefonemas)
		{
			throw new NotImplementedException("Reimplementar!!!");
/*			long		total;
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
*/		}

		#endregion

		/// <summary>
		/// Dias entre duas datas
		/// </summary>
		private int Dias(DateTime in�cio, DateTime atual)
		{
			TimeSpan dif = atual.Date - in�cio.Date;

			return dif.Days;
		}
	}
}
