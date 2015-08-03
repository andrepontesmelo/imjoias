using System;
using System.Data;
using System.Globalization;
using Entidades;
using Acesso.Comum;
using Negócio.Exceções;

/* Controle Código De Barras.
 * Objeto singlecall é disponibilizado no serviço negócio.
 * Acesso pode ser feito através da integração.
 */

namespace Negócio.Controles
{
	/// <summary>
	/// Controle de código de barras
	/// </summary>
	public class CódigoDeBarras : Negócio.Fachada.AcessoUsuário, Negócio.Controle.ICódigoBarras	
	{
		/// <summary>
		/// Codifica referência
		/// </summary>
		/// <returns>Codificação</returns>
		public string Codificar(string referência)
		{
			return Codificar(referência, 0);
		}

		/// <summary>
		/// Codifica referência e peso
		/// </summary>
		/// <returns>Codificação</returns>
		public string Codificar(string referência, double peso)
		{
			int código;

			código = ObterCódigoMapeamento(referência, peso);

			if (código < 0)
				código = GerarCódigoMapeamento(referência, peso);

			if (peso >= 90)
			{
				return string.Format("9{0:0000}{1:000}", Math.Floor(peso * 10), código);
			}
			else
			{
				if (código <= 999)
					return string.Format("{0:000}{1:000}", Math.Floor(peso * 10), código);
				else if (código <= 100999)
					return string.Format("{0:000}{1:00000}", Math.Floor(peso * 10), código - 1000);
			}

			throw new NotSupportedException("Não é possível codificar todas as etiquetas necessárias. O sistema está saturado, necessitando reciclagem de mapeamentos de código de barras!");
		}

		/// <summary>
		/// Obtém do banco de dados o código mapeado da mercadoria
		/// </summary>
		/// <param name="referência">Referência da mercadoria</param>
		/// <param name="peso">Peso da mercadoria</param>
		/// <returns>Código de mapeamento</returns>
		/// <remarks>Caso não encontre, retorna -1</remarks>
		private int ObterCódigoMapeamento(string referência, double peso)
		{
			int           código;
			IDbConnection conexão;

			conexão = UsuárioRemoto.Conexão;

			lock (conexão)
			{
				using (IDbCommand cmd = conexão.CreateCommand())
				{
					object obj;

					cmd.CommandText = "SELECT codigo FROM mercadoriaMapeamento "
						+ "WHERE referencia = '" + referência + "' "
						+ "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "'";

					obj = cmd.ExecuteScalar();

					if (obj == null || obj == DBNull.Value)
						código = -1;
					else
						código = Convert.ToInt32(obj);
				}
			}

			return código;
		}

		/// <summary>
		/// Gera o código de mapeamento, cadastrando-o no banco de dados
		/// </summary>
		/// <param name="referência">Referência a ser mapeada</param>
		/// <param name="peso">Peso da mercadoria</param>
		/// <returns>Código de mapeamento</returns>
		private int GerarCódigoMapeamento(string referência, double peso)
		{
			int código;
			IDbConnection conexão;

			conexão = UsuárioRemoto.Conexão;

			lock (conexão)
			{
				using (IDbTransaction transação = conexão.BeginTransaction())
				{
					using (IDbCommand cmd = conexão.CreateCommand())
					{
						object obj;

						cmd.Transaction = transação;

						// Obter código obsoleto
						cmd.CommandText = "SELECT codigo FROM mercadoriaMapeamento "
							+ "WHERE obsoleto = 1 "
							+ "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
							+ "LIMIT 1";

						obj = cmd.ExecuteScalar();

						if (obj != null && obj != DBNull.Value)
						{
							código = Convert.ToInt32(obj);

							cmd.CommandText = "UPDATE mercadoriaMapeamento SET obsoleto = 0, "
								+ "referencia = '" + referência + "', "
								+ "peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
								+ "WHERE codigo = '" + código + "'";

							cmd.ExecuteNonQuery();
						}
						else
						{
							cmd.CommandText = "SELECT MAX(codigo) FROM mercadoriaMapeamento "
								+ "WHERE peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "'";

							obj = cmd.ExecuteScalar();

							if (obj == DBNull.Value || obj == null)
								código = 0;
							else
								código = Convert.ToInt32(obj) + 1;

							cmd.CommandText = "INSERT INTO mercadoriaMapeamento (codigo, peso, referencia) "
								+ "VALUES ('" + código + "', '" + peso.ToString(NumberFormatInfo.InvariantInfo)
								+ "', '" + referência + "')";

							cmd.ExecuteNonQuery();
						}

						transação.Commit();
					}
				}
			}
			
			return código;
		}

		/// <summary>
		/// Interpreta o código de barras
		/// </summary>
		/// <param name="código">Código de barras</param>
		/// <param name="mapCódigo">Código de mapeamento</param>
		/// <param name="mapPeso">Peso de mapeamento</param>
		public void Interpretar(string código, out int mapCódigo, out double mapPeso)
		{
			checked
			{
				switch (código.Length)
				{
					case 6:
						mapCódigo = int.Parse(código.Substring(3));
						mapPeso   = double.Parse(código.Substring(0, 3)) / 10d;
						break;

					case 8:
						if (código.StartsWith("9"))
						{
							mapCódigo = int.Parse(código.Substring(5));
							mapPeso   = double.Parse(código.Substring(1, 4)) / 10d + 90;
						}
						else
						{
							mapCódigo = int.Parse(código.Substring(3)) + 1000;
							mapPeso   = double.Parse(código.Substring(0, 3)) / 10d;
						}
						break;

					default:
						throw new CódigoBarrasInválido("Código de barras inválido!");
						//throw new Exception("Código de barras inválido!");
				}
			}
		}

		/// <summary>
		/// Interpreta o código de barras
		/// </summary>
		/// <param name="código">Código de barras</param>
		/// <returns>Mercadoria mapeada</returns>
		public Entidades.Mercadoria Interpretar(string código)
		{
			int    mapCódigo;
			double mapPeso;
			string referência;

			Interpretar(código, out mapCódigo, out mapPeso);

			referência = ObterReferênciaMapeada(mapCódigo, mapPeso);

			if (referência != null)
			{
				Entidades.Mercadoria mercadoria;
				
				mercadoria = Entidades.Mercadoria.ObterMercadoriaSemDígito(referência);

				if (mapPeso > 0)
				{
					if (!mercadoria.DePeso)
						//throw new CódigoBarrasInválido("Código de barras contém peso para uma mercadoria de linha!");
						throw new Exception("Código de barras contém peso para uma mercadoria que não é pesada!");

					mercadoria.Peso = mapPeso;
				}

				return mercadoria;
			}
			else
				//throw new CódigoBarrasInválido("Código de barras incorreto!");
				throw new Exception("Código de barras incorreto!");
		}

		/// <summary>
		/// Obtém referência mapeada
		/// </summary>
		/// <param name="código">Código do mapeamento</param>
		/// <param name="peso">Peso do mapeamento</param>
		/// <returns>Referência mapeada</returns>
		private string ObterReferênciaMapeada(int código, double peso)
		{
			string        referência;
			IDbConnection conexão = UsuárioRemoto.Conexão;

			lock (conexão)
			{
				using (IDbCommand cmd = conexão.CreateCommand())
				{
					object obj;

					cmd.CommandText = "SELECT referencia FROM mercadoriaMapeamento "
						+ "WHERE codigo = '" + código.ToString() + "' "
						+ "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
						+ "AND obsoleto = 0";

					obj = cmd.ExecuteScalar();

					if (obj == DBNull.Value || obj == null)
						return null;

					referência = Convert.ToString(obj);
				}
			}

			return referência;
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
