using System;
using System.Data;
using System.Collections;
using System.Globalization;

namespace IMJ�ias.An�liseEstat�stica
{
	public sealed class Visitantes
	{
		private Visitantes() {}

		#region Transforma��o de dados

		public static string DbTransformar(DateTime dt)
		{
			if (dt == DateTime.MinValue)
				return "null";
			else
				return "'" + dt.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(string s)
		{
			if (s == null)
				return "null";
			
			s = s.Replace("\\", "\\\\");
			s = s.Replace("'", "\\'");
			s = s.Replace("%", "\\%");

			return "'" + s + "'";
		}

		public static string DbTransformar(double d)
		{
			return "'" + d.ToString(NumberFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(long l)
		{
			return "'" + l.ToString(NumberFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(int i)
		{
			return "'" + i.ToString(NumberFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(bool b)
		{
			return b ? "'1'" : "'0'";
		}

		public static string DbTransformar(System.Reflection.MethodBase mb)
		{
			try
			{
				return mb == null ? "null" : "'" + mb.ToString() + "'";
			}
			catch
			{
				return "null";
			}
		}
		/*
				public string DbTransformar(byte [] bv)
				{
					string valor = "";

					foreach (byte b in bv)
					{
						if ((char) b == '\'')
							valor += "\\";
						valor += (char) b;
					}

					return valor;
				}
		*/
		#endregion

		/// <summary>
		/// Obt�m a quantidade de visitantes por dia e por setor
		/// dentro de um per�odo determinado.
		/// </summary>
		/// <param name="conex�o">Conex�o com o banco de dados</param>
		/// <param name="d1">Per�odo inicial</param>
		/// <param name="d2">Per�odo final</param>
		/// <param name="legenda">Legenda contendo nome dos setores</param>
		/// <returns>Visitantes por setor</returns>
		public static double [][] ObterVisitantesDi�riosSetor(IDbConnection conex�o, DateTime d1, DateTime d2, out string [] legenda)
		{
			IDbCommand		cmd;
			IDataReader		leitor = null;
			Hashtable		setores;
			Hashtable		pSetores;
			double [][]		resposta;
			int				contador;


			// Obt�m lista de setores
			setores = ObterSetores(conex�o);

			
			// Constr�i tabela de setores por posi��o de vetor
			IDictionaryEnumerator eSetor = setores.GetEnumerator();
			pSetores = new Hashtable();
			contador = 0;
			legenda  = new string[setores.Count];

			while (eSetor.MoveNext())
			{
				legenda[contador] = eSetor.Value as string;
				pSetores.Add(eSetor.Key, contador++);
			}

			
			// Criar vetor de resposta
			resposta = new double[CalcularDias(d1, d2) + 1][];

			for (int i = 0; i < resposta.Length; i++)
				resposta[i] = new double[setores.Count];

			
			// Consultar o banco de dados
			cmd = conex�o.CreateCommand();
			cmd.CommandText = "SELECT DATE(entrada) AS entrada, setor, COUNT(*)"
						   + " FROM `visita` WHERE setor IS NOT NULL AND entrada >= " + DbTransformar(d1) + " AND entrada <= " + DbTransformar(d2)
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
		private static int CalcularDias(DateTime d1, DateTime d2)
		{
			TimeSpan ts = d2 - d1;

			return ts.Days;
		}

		/// <summary>
		/// Obt�m setores de um banco de dados
		/// </summary>
		/// <param name="conex�o">Conex�o com o banco de dados</param>
		/// <returns>Dicion�rio de setores organizados por c�digo</returns>
		private static Hashtable ObterSetores(IDbConnection conex�o)
		{
			IDbCommand cmd = conex�o.CreateCommand();
			IDataReader leitor = null;
			Hashtable  setores = new Hashtable();

			cmd.CommandText = "SELECT codigo, nome FROM setor WHERE atendimento > 0";

			lock (conex�o)
			{
				try
				{
					leitor = cmd.ExecuteReader();

					while (leitor.Read())
						setores.Add(leitor.GetInt64(0), leitor.GetString(1));
				}
				finally
				{
					if (leitor != null)
						leitor.Close();
				}
			}

			return setores;
		}
	}
}
