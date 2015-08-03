using System;
using System.Collections;
using System.Data;
using Acesso.Comum;
using Acesso.Comum.Exceções;
using Entidades.Configuração;

namespace Entidades.Etiqueta
{
	/// <summary>
	/// Formato para etiquetas
	/// </summary>
	[Serializable]
	public class EtiquetaFormato : Acesso.Comum.DbManipulação
	{
		private string   formato;
		private string   autor;
		private DateTime data;
		private string   configuracao;

		/// <summary>
		/// Constrói um formato de etiqueta
		/// </summary>
		/// <param name="formato">Nome do formato</param>
		public EtiquetaFormato(string formato)
		{
			this.formato = formato;
		}

		public EtiquetaFormato()
		{
		}

		#region Propriedades

		public string Formato
		{
			get { return formato; }
		}

		public string Autor
		{
			get { return autor; }
			set { autor = value; }
		}

		public DateTime Data
		{
			get { return data; }
			set { data = value; }
		}

		public string Configuração
		{
			get { return configuracao; }
			set
			{
				lock (this)
				{
                    DefinirDesatualizado();
					configuracao = value;
				}
			}
		}

		#endregion

		/// <summary>
		/// Exclui formato de etiqueta
		/// </summary>
		protected override void Descadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM etiquetaformato "
				+ "WHERE formato = " + DbTransformar(formato);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Cadastra etiqueta no banco de dados
		/// </summary>
		protected override void Cadastrar(IDbCommand cmd)
		{
			autor = Acesso.Comum.Usuários.UsuárioAtual.Nome;

			if (VerificarExistência(cmd, formato))
				throw new EntidadeJáExistente(this);

			// Cadastrar formato
			cmd.CommandText = "INSERT INTO etiquetaformato (formato, autor, data, configuracao) "
				+ "VALUES ("
				+ DbTransformar(formato) + ", "
				+ DbTransformar(autor) + ", "
                + DbTransformar(data = DadosGlobais.Instância.HoraDataAtual) + ", "
				+ DbTransformar(configuracao) + ")";

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Verifica existência de um formato
		/// </summary>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <param name="formato">Formato a ser verificado</param>
		/// <returns>Existência</returns>
		private static bool VerificarExistência(IDbCommand cmd, string formato)
		{
			// Verificar se já existe formato
			cmd.CommandText = "SELECT COUNT(*) FROM etiquetaformato "
				+ "WHERE formato = " + DbTransformar(formato);

			return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
		}

		/// <summary>
		/// Atualiza dados
		/// </summary>
		protected override void Atualizar(IDbCommand cmd)
		{
			autor = Acesso.Comum.Usuários.UsuárioAtual.Nome;

			cmd.CommandText = "UPDATE etiquetaformato SET"
				+ " autor = " + DbTransformar(autor)
                + ", data = " + DbTransformar(data = DadosGlobais.Instância.HoraDataAtual)
				+ ", configuracao = " + DbTransformar(configuracao)
				+ " WHERE formato = " + DbTransformar(formato);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Renomea no banco de dados o nome deste formato
		/// </summary>
		/// <param name="novoNome">Novo nome para o formato</param>
		public void Renomear(string novoNome)
		{
			if (!Cadastrado)
				throw new EntidadeNãoCadastrada(this);

            lock (this)
            {
                IDbConnection conexão = Conexão;

                lock (conexão)
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        if (VerificarExistência(cmd, novoNome))
                            throw new EntidadeJáExistente(this);

                        cmd.CommandText = "UPDATE etiquetaformato SET"
                            + " formato = " + DbTransformar(novoNome)
                            + " WHERE formato = " + DbTransformar(formato);

                        cmd.ExecuteNonQuery();

                        formato = novoNome;
                    }
            }
		}

		/// <summary>
		/// Reobtem as informações no mysql (configuração, data, autor) a partir do Formato.
		/// </summary>
		/// <returns></returns>
		public void ReobterInformações()
		{
			EtiquetaFormato nova = EtiquetaFormato.ObterEtiqueta(formato);

			configuracao = nova.Configuração;
			data = nova.Data;
			autor = nova.Autor;
			//formato = nova.Formato; //não precisa por razões óbvias
		}


		/// <summary>
		/// Obtém etiquetas
		/// </summary>
		/// <returns>DataSet contendo etiquetas</returns>
        public static EtiquetaFormato[] ObterEtiquetas()
        {
            return Mapear<EtiquetaFormato>("SELECT * FROM etiquetaformato").ToArray();
        }

		/// <summary>
		/// Obtém etiquetas
		/// </summary>
		/// <returns>DataSet contendo etiquetas</returns>
		public static EtiquetaFormato ObterEtiqueta(String formato)
		{
			EtiquetaFormato etiquetaObtida;
            IDbConnection conexão = Conexão;

			lock (conexão)
			{
				using (IDbCommand cmd = conexão.CreateCommand())
				{

					cmd.CommandText = "SELECT * FROM etiquetaformato where formato = " + DbTransformar(formato);

					etiquetaObtida = MapearÚnicaLinha<EtiquetaFormato>(cmd);
				}
			}

			return etiquetaObtida;
		}


		/// <summary>
		/// Cadastra um formato de etiqueta no banco de dados
		/// </summary>
		/// <param name="formato">Formato a ser cadastrado</param>
		/// <param name="configuração">Configuração do formato</param>
		/// <returns>Entidade construída</returns>
		public static EtiquetaFormato Cadastrar(string formato, string configuração)
		{
			EtiquetaFormato nova;

			nova = new EtiquetaFormato(formato);
			nova.configuracao = configuração;

			nova.Cadastrar();

			return nova;
		}

		public override string ToString()
		{
			return formato;
		}

		/// <summary>
		/// Compara igualdade entre formatos
		/// </summary>
		public static bool operator == (EtiquetaFormato a, EtiquetaFormato b)
		{
			if ((((Object) a) == null) || (((Object) b) == null))
				return (((Object) a) == ((Object) b));
			
			/* Inicialmente, a comparação era entre o nome do formato:
			 * return a.Formato == b.Formato;
			 * 
			 * Entretanto, acredito ser mais interessante comparar
			 * a configuração do formato, já que um formato pode
			 * ser renomeado. Formatos duplicados, com nomes diferentes
			 * também podem ser agrupados, considerando-se o mesmo
			 * formato, já que produzem a mesma impressão.
			 */
			return a.configuracao == b.configuracao;
		}

		public static bool operator != (EtiquetaFormato a, EtiquetaFormato b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Verifica equivalência entre objetos
		/// </summary>
		public override bool Equals(object obj)
		{
			return base.Equals (obj) || 
				(typeof(EtiquetaFormato).IsInstanceOfType(obj) && ((EtiquetaFormato) obj) == this);
		}

        public override int GetHashCode()
        {
            return this.configuracao.GetHashCode();
        }

        public string ObterHashSemelhança()
        {
            return this.configuracao;
        }

	}
}
