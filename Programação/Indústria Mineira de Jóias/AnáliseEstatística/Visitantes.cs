using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Globalization;

namespace Ind�stria_Mineira_de_J�ias.An�liseEstat�stica
{
	/// <summary>
	/// Summary description for Visitantes.
	/// </summary>
	public sealed class Visitantes : Analisador
	{
		private IDbConnection               conex�o;
        private Dictionary<long, string>    hashC�digoSetor;
        private Hashtable                   pSetores;
		private string []	                legendaSetores;

		public Visitantes(IDbConnection conex�o)
		{
			int contador;

			this.conex�o = conex�o;

			// Obt�m lista de setores
			hashC�digoSetor = ObterSetores();

			// Constr�i tabela de setores por posi��o de vetor
			IDictionaryEnumerator eSetor = hashC�digoSetor.GetEnumerator();
			pSetores = new Hashtable();
			contador = 0;

			legendaSetores = new string[hashC�digoSetor.Count];

			while (eSetor.MoveNext())
			{
				legendaSetores[contador] = eSetor.Value as string;
				pSetores.Add(eSetor.Key, contador++);
			}
		}

		/// <summary>
		/// Obt�m a quantidade de visitantes por dia e por setor
		/// dentro de um per�odo determinado.
		/// </summary>
		/// <param name="conex�o">Conex�o com o banco de dados</param>
		/// <param name="d1">Per�odo inicial</param>
		/// <param name="d2">Per�odo final</param>
		/// <param name="legenda">Legenda contendo nome dos setores</param>
		/// <returns>Visitantes por setor</returns>
		public double [][] ObterVisitantesDi�riosSetor(DateTime d1, DateTime d2, out string [] legenda)
		{
			IDbCommand		cmd;
			IDataReader		leitor = null;
			double [][]		resposta;

			legenda = this.legendaSetores;

			// Criar vetor de resposta
			resposta = new double[hashC�digoSetor.Count][];

			for (int i = 0; i < resposta.Length; i++)
				resposta[i] = new double[CalcularDias(d1, d2) + 1];

			
			// Consultar o banco de dados
			cmd = conex�o.CreateCommand();
			cmd.CommandText = "SELECT DATE(entrada) AS entrada, setor, COUNT(*)"
				+ " FROM `visita` WHERE setor IS NOT NULL AND entrada >= " + DbTransformar(d1.Date) + " AND entrada <= " + DbTransformar(d2)
				+ " GROUP BY entrada, setor";

			lock (conex�o)
			{
				try
				{
					leitor = cmd.ExecuteReader();

					while (leitor.Read())
						resposta[(int) pSetores[leitor.GetInt64(1)]][CalcularDias(d1, leitor.GetDateTime(0))] = leitor.GetInt64(2);
				}
				finally
				{
					if (leitor != null)
						leitor.Close();
				}
			}

			return resposta;
		}

		/// <summary>
		/// Calcula o n�mero de dias dentro de um per�odo
		/// </summary>
		/// <param name="d1">Per�odo inicial</param>
		/// <param name="d2">Per�odo final</param>
		/// <returns>N�mero de dias</returns>
		private int CalcularDias(DateTime d1, DateTime d2)
		{
			TimeSpan ts = d2.Date - d1.Date;

			return ts.Days;
		}

		/// <summary>
		/// Obt�m setores de um banco de dados
		/// </summary>
		/// <param name="conex�o">Conex�o com o banco de dados</param>
		/// <returns>Dicion�rio de setores organizados por c�digo</returns>
		private Dictionary<long, string> ObterSetores()
		{
			IDbCommand cmd = conex�o.CreateCommand();
			IDataReader leitor = null;
            Dictionary<long, string> hashC�digoSetor = new Dictionary<long, string>(); 

			cmd.CommandText = "SELECT codigo, nome FROM setor WHERE atendimento > 0";

			lock (conex�o)
			{
				try
				{
					leitor = cmd.ExecuteReader();

					while (leitor.Read())
						hashC�digoSetor.Add(leitor.GetInt64(0), leitor.GetString(1));
				}
				finally
				{
					if (leitor != null)
						leitor.Close();
				}
			}

			return hashC�digoSetor;
		}

		/// <summary>
		/// Espera de visitantes
		/// </summary>
		/// <param name="nVisitantes">Quantidade de visitantes (�ltimos)</param>
		public double [][] ObterEspera(int nVisitantes, out string [] legenda)
		{
			using (IDbCommand cmd = conex�o.CreateCommand())
			{
				IDataReader  	dao = null;
				double [][]		dados;

				legenda = this.legendaSetores;
				dados   = new double[pSetores.Count][];

				for (int i = 0; i < dados.Length; i++)
					dados[i] = new double[nVisitantes];

				lock (this.conex�o)
				{
					try
					{
						// Constr�i lista de visitas
						IDictionaryEnumerator eSetor = pSetores.GetEnumerator();

						while (eSetor.MoveNext())
						{
							int contador = 0;

							cmd.CommandText =
								"SELECT espera FROM visita v LEFT JOIN setor s ON v.setor = s.codigo " +
								"WHERE espera >= 0 " +
								"AND s.codigo = " + eSetor.Key.ToString() + " " + 
								"ORDER BY entrada DESC " +
								"LIMIT " + nVisitantes.ToString();

							dao = cmd.ExecuteReader();

							while (dao.Read())
								dados[(int) eSetor.Value][contador++] = dao.GetInt64(0) / 60f;

							dao.Close();
						}
					}
					catch (Exception e)
					{
						throw new Exception(e.ToString() + "\n\n" + cmd.CommandText);
					}
					finally
					{
						if (dao != null && !dao.IsClosed)
							dao.Close();
					}
				}

				return dados;
			}
			}
	}
}
