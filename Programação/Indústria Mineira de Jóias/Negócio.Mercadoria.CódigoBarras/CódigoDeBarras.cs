using System;
using System.Data;
using System.Globalization;
using Entidades;
using Acesso.Comum;
using Neg�cio.Exce��es;

/* Controle C�digo De Barras.
 * Objeto singlecall � disponibilizado no servi�o neg�cio.
 * Acesso pode ser feito atrav�s da integra��o.
 */

namespace Neg�cio.Controles
{
	/// <summary>
	/// Controle de c�digo de barras
	/// </summary>
	public class C�digoDeBarras : Neg�cio.Fachada.AcessoUsu�rio, Neg�cio.Controle.IC�digoBarras	
	{
		/// <summary>
		/// Codifica refer�ncia
		/// </summary>
		/// <returns>Codifica��o</returns>
		public string Codificar(string refer�ncia)
		{
			return Codificar(refer�ncia, 0);
		}

		/// <summary>
		/// Codifica refer�ncia e peso
		/// </summary>
		/// <returns>Codifica��o</returns>
		public string Codificar(string refer�ncia, double peso)
		{
			int c�digo;

			c�digo = ObterC�digoMapeamento(refer�ncia, peso);

			if (c�digo < 0)
				c�digo = GerarC�digoMapeamento(refer�ncia, peso);

			if (peso >= 90)
			{
				return string.Format("9{0:0000}{1:000}", Math.Floor(peso * 10), c�digo);
			}
			else
			{
				if (c�digo <= 999)
					return string.Format("{0:000}{1:000}", Math.Floor(peso * 10), c�digo);
				else if (c�digo <= 100999)
					return string.Format("{0:000}{1:00000}", Math.Floor(peso * 10), c�digo - 1000);
			}

			throw new NotSupportedException("N�o � poss�vel codificar todas as etiquetas necess�rias. O sistema est� saturado, necessitando reciclagem de mapeamentos de c�digo de barras!");
		}

		/// <summary>
		/// Obt�m do banco de dados o c�digo mapeado da mercadoria
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia da mercadoria</param>
		/// <param name="peso">Peso da mercadoria</param>
		/// <returns>C�digo de mapeamento</returns>
		/// <remarks>Caso n�o encontre, retorna -1</remarks>
		private int ObterC�digoMapeamento(string refer�ncia, double peso)
		{
			int           c�digo;
			IDbConnection conex�o;

			conex�o = Usu�rioRemoto.Conex�o;

			lock (conex�o)
			{
				using (IDbCommand cmd = conex�o.CreateCommand())
				{
					object obj;

					cmd.CommandText = "SELECT codigo FROM mercadoriaMapeamento "
						+ "WHERE referencia = '" + refer�ncia + "' "
						+ "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "'";

					obj = cmd.ExecuteScalar();

					if (obj == null || obj == DBNull.Value)
						c�digo = -1;
					else
						c�digo = Convert.ToInt32(obj);
				}
			}

			return c�digo;
		}

		/// <summary>
		/// Gera o c�digo de mapeamento, cadastrando-o no banco de dados
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia a ser mapeada</param>
		/// <param name="peso">Peso da mercadoria</param>
		/// <returns>C�digo de mapeamento</returns>
		private int GerarC�digoMapeamento(string refer�ncia, double peso)
		{
			int c�digo;
			IDbConnection conex�o;

			conex�o = Usu�rioRemoto.Conex�o;

			lock (conex�o)
			{
				using (IDbTransaction transa��o = conex�o.BeginTransaction())
				{
					using (IDbCommand cmd = conex�o.CreateCommand())
					{
						object obj;

						cmd.Transaction = transa��o;

						// Obter c�digo obsoleto
						cmd.CommandText = "SELECT codigo FROM mercadoriaMapeamento "
							+ "WHERE obsoleto = 1 "
							+ "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
							+ "LIMIT 1";

						obj = cmd.ExecuteScalar();

						if (obj != null && obj != DBNull.Value)
						{
							c�digo = Convert.ToInt32(obj);

							cmd.CommandText = "UPDATE mercadoriaMapeamento SET obsoleto = 0, "
								+ "referencia = '" + refer�ncia + "', "
								+ "peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
								+ "WHERE codigo = '" + c�digo + "'";

							cmd.ExecuteNonQuery();
						}
						else
						{
							cmd.CommandText = "SELECT MAX(codigo) FROM mercadoriaMapeamento "
								+ "WHERE peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "'";

							obj = cmd.ExecuteScalar();

							if (obj == DBNull.Value || obj == null)
								c�digo = 0;
							else
								c�digo = Convert.ToInt32(obj) + 1;

							cmd.CommandText = "INSERT INTO mercadoriaMapeamento (codigo, peso, referencia) "
								+ "VALUES ('" + c�digo + "', '" + peso.ToString(NumberFormatInfo.InvariantInfo)
								+ "', '" + refer�ncia + "')";

							cmd.ExecuteNonQuery();
						}

						transa��o.Commit();
					}
				}
			}
			
			return c�digo;
		}

		/// <summary>
		/// Interpreta o c�digo de barras
		/// </summary>
		/// <param name="c�digo">C�digo de barras</param>
		/// <param name="mapC�digo">C�digo de mapeamento</param>
		/// <param name="mapPeso">Peso de mapeamento</param>
		public void Interpretar(string c�digo, out int mapC�digo, out double mapPeso)
		{
			checked
			{
				switch (c�digo.Length)
				{
					case 6:
						mapC�digo = int.Parse(c�digo.Substring(3));
						mapPeso   = double.Parse(c�digo.Substring(0, 3)) / 10d;
						break;

					case 8:
						if (c�digo.StartsWith("9"))
						{
							mapC�digo = int.Parse(c�digo.Substring(5));
							mapPeso   = double.Parse(c�digo.Substring(1, 4)) / 10d + 90;
						}
						else
						{
							mapC�digo = int.Parse(c�digo.Substring(3)) + 1000;
							mapPeso   = double.Parse(c�digo.Substring(0, 3)) / 10d;
						}
						break;

					default:
						throw new C�digoBarrasInv�lido("C�digo de barras inv�lido!");
						//throw new Exception("C�digo de barras inv�lido!");
				}
			}
		}

		/// <summary>
		/// Interpreta o c�digo de barras
		/// </summary>
		/// <param name="c�digo">C�digo de barras</param>
		/// <returns>Mercadoria mapeada</returns>
		public Entidades.Mercadoria Interpretar(string c�digo)
		{
			int    mapC�digo;
			double mapPeso;
			string refer�ncia;

			Interpretar(c�digo, out mapC�digo, out mapPeso);

			refer�ncia = ObterRefer�nciaMapeada(mapC�digo, mapPeso);

			if (refer�ncia != null)
			{
				Entidades.Mercadoria mercadoria;
				
				mercadoria = Entidades.Mercadoria.ObterMercadoriaSemD�gito(refer�ncia);

				if (mapPeso > 0)
				{
					if (!mercadoria.DePeso)
						//throw new C�digoBarrasInv�lido("C�digo de barras cont�m peso para uma mercadoria de linha!");
						throw new Exception("C�digo de barras cont�m peso para uma mercadoria que n�o � pesada!");

					mercadoria.Peso = mapPeso;
				}

				return mercadoria;
			}
			else
				//throw new C�digoBarrasInv�lido("C�digo de barras incorreto!");
				throw new Exception("C�digo de barras incorreto!");
		}

		/// <summary>
		/// Obt�m refer�ncia mapeada
		/// </summary>
		/// <param name="c�digo">C�digo do mapeamento</param>
		/// <param name="peso">Peso do mapeamento</param>
		/// <returns>Refer�ncia mapeada</returns>
		private string ObterRefer�nciaMapeada(int c�digo, double peso)
		{
			string        refer�ncia;
			IDbConnection conex�o = Usu�rioRemoto.Conex�o;

			lock (conex�o)
			{
				using (IDbCommand cmd = conex�o.CreateCommand())
				{
					object obj;

					cmd.CommandText = "SELECT referencia FROM mercadoriaMapeamento "
						+ "WHERE codigo = '" + c�digo.ToString() + "' "
						+ "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
						+ "AND obsoleto = 0";

					obj = cmd.ExecuteScalar();

					if (obj == DBNull.Value || obj == null)
						return null;

					refer�ncia = Convert.ToString(obj);
				}
			}

			return refer�ncia;
		}

		/// <summary>
		/// Torna o objeto remoto eterno
		/// </summary>
		public override object InitializeLifetimeService()
		{
			return null;
		}
	}
}
