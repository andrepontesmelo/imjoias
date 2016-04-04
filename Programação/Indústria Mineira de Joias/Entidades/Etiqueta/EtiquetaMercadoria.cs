using System;
using System.Data;

namespace Entidades.Etiqueta
{
	/// <summary>
	/// Mapeamento de etiqueta para mercadoria
	/// </summary>
	public class EtiquetaMercadoria : Acesso.Comum.DbManipulação
	{
		private string referencia;
		private string formato;

		/// <summary>
		/// Constrói um mapeamento de etiqueta para mercadoria
		/// </summary>
		/// <param name="jáCadastrado">Informa se a entidade já foi cadastrada no BD</param>
		public EtiquetaMercadoria(string referênciaNumérica, string formato, bool jáCadastrado)
		{
			this.referencia = referênciaNumérica;
			this.formato    = formato;

			if (jáCadastrado)
                DefinirCadastrado();
		}

		/// <summary>
		/// Referência da mercadoria mapeada
		/// </summary>
		public string Referência
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
		/// Obtém mapeamento de etiqueta para mercadoria
		/// </summary>
		/// <param name="referênciaNumérica">Referência numérica, sem formatação</param>
		/// <returns>Mapeamento de etiqueta para mercadoria</returns>
		public static EtiquetaMercadoria ObterEtiquetaMercadoria(string referênciaNumérica)
		{
			object obj;
            IDbConnection conexão = Conexão;

			using (IDbCommand cmd = conexão.CreateCommand())
			{
				cmd.CommandText = "SELECT formato"
					+ " FROM etiquetamercadoria"
					+ " WHERE referencia = " + DbTransformar(referênciaNumérica);

				lock (conexão)
				{
					obj = cmd.ExecuteScalar();
				}
			}

			if (obj == null || obj == DBNull.Value)
				return null;

			EtiquetaMercadoria vinculoCadastrado = new EtiquetaMercadoria(referênciaNumérica, (string) obj, true);
				
			return vinculoCadastrado;
		}
	}
}
