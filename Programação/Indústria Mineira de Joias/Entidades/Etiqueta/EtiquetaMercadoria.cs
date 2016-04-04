using System;
using System.Data;

namespace Entidades.Etiqueta
{
	/// <summary>
	/// Mapeamento de etiqueta para mercadoria
	/// </summary>
	public class EtiquetaMercadoria : Acesso.Comum.DbManipula��o
	{
		private string referencia;
		private string formato;

		/// <summary>
		/// Constr�i um mapeamento de etiqueta para mercadoria
		/// </summary>
		/// <param name="j�Cadastrado">Informa se a entidade j� foi cadastrada no BD</param>
		public EtiquetaMercadoria(string refer�nciaNum�rica, string formato, bool j�Cadastrado)
		{
			this.referencia = refer�nciaNum�rica;
			this.formato    = formato;

			if (j�Cadastrado)
                DefinirCadastrado();
		}

		/// <summary>
		/// Refer�ncia da mercadoria mapeada
		/// </summary>
		public string Refer�ncia
		{
			get { return referencia; }
		}

		/// <summary>
		/// Formato mapeado para a mercadoria
		/// </summary>
		public string Formato
		{
			get { return formato; }
			set
			{
				lock (this)
				{
                    DefinirDesatualizado();
					formato = value;
				}
			}
		}

		/// <summary>
		/// Cadastra formato para mercadoria
		/// </summary>
		protected override void Cadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "INSERT INTO etiquetamercadoria"
				+ " (referencia, formato)"
				+ " VALUES (" + DbTransformar(referencia)
				+ ", " + DbTransformar(formato) + ")";

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Atualiza formato no banco de dados
		/// </summary>
		protected override void Atualizar(IDbCommand cmd)
		{
			cmd.CommandText = "UPDATE etiquetamercadoria"
				+ " SET formato = " + DbTransformar(formato)
				+ " WHERE referencia = " + DbTransformar(referencia);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Exclui formato do banco de dados
		/// </summary>
		protected override void Descadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM etiquetamercadoria"
				+ " WHERE referencia = " + DbTransformar(referencia);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Obt�m mapeamento de etiqueta para mercadoria
		/// </summary>
		/// <param name="refer�nciaNum�rica">Refer�ncia num�rica, sem formata��o</param>
		/// <returns>Mapeamento de etiqueta para mercadoria</returns>
		public static EtiquetaMercadoria ObterEtiquetaMercadoria(string refer�nciaNum�rica)
		{
			object obj;
            IDbConnection conex�o = Conex�o;

			using (IDbCommand cmd = conex�o.CreateCommand())
			{
				cmd.CommandText = "SELECT formato"
					+ " FROM etiquetamercadoria"
					+ " WHERE referencia = " + DbTransformar(refer�nciaNum�rica);

				lock (conex�o)
				{
					obj = cmd.ExecuteScalar();
				}
			}

			if (obj == null || obj == DBNull.Value)
				return null;

			EtiquetaMercadoria vinculoCadastrado = new EtiquetaMercadoria(refer�nciaNum�rica, (string) obj, true);
				
			return vinculoCadastrado;
		}
	}
}
