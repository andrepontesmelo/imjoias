using System;
using System.Data;
using System.Collections;
using System.Globalization;

namespace IMJóias.AnáliseEstatística
{
	public sealed class Visitantes
	{
		private Visitantes() {}

		#region Transformação de dados

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
		/// Obtém a quantidade de visitantes por dia e por setor
		/// dentro de um período determinado.
		/// </summary>
		/// <param name="conexão">Conexão com o banco de dados</param>
		/// <param name="d1">Período inicial</param>
		/// <param name="d2">Período final</param>
		/// <param name="legenda">Legenda contendo nome dos setores</param>
		/// <returns>Visitantes por setor</returns>
		public static double [][] ObterVisitantesDiáriosSetor(IDbConnection conexão, DateTime d1, DateTime d2, out string [] legenda)
		{
			IDbCommand		cmd;
			IDataReader		leitor = null;
			Hashtable		setores;
			Hashtable		pSetores;
			double [][]		resposta;
			int				contador;


			// Obtém lista de setores
			setores = ObterSetores(conexão);

			
			// Constrói tabela de setores por posição de vetor
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
			cmd = conexão.CreateCommand();
			cmd.CommandText = "SELECT DATE(entrada) AS entrada, setor, COUNT(*)"
						   + " FROM `visita` WHERE setor IS NOT NULL AND entrada >= " + DbTransformar(d1) + " AND entrada <= " + DbTransformar(d2)
						   + " GROUP BY entrada, setor";

			lock (conexão)
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
		/// Calcula o número de dias dentro de um período
		/// </summary>
		/// <param name="d1">Período inicial</param>
		/// <param name="d2">Período final</param>
		/// <returns>Número de dias</returns>
		private static int CalcularDias(DateTime d1, DateTime d2)
		{
			TimeSpan ts = d2 - d1;

			return ts.Days;
		}

		/// <summary>
		/// Obtém setores de um banco de dados
		/// </summary>
		/// <param name="conexão">Conexão com o banco de dados</param>
		/// <returns>Dicionário de setores organizados por código</returns>
		private static Hashtable ObterSetores(IDbConnection conexão)
		{
			IDbCommand cmd = conexão.CreateCommand();
			IDataReader leitor = null;
			Hashtable  setores = new Hashtable();

			cmd.CommandText = "SELECT codigo, nome FROM setor WHERE atendimento > 0";

			lock (conexão)
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
