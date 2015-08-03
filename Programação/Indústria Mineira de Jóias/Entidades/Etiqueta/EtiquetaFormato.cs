using System;
using System.Collections;
using System.Data;
using Acesso.Comum;
using Acesso.Comum.Exce��es;
using Entidades.Configura��o;

namespace Entidades.Etiqueta
{
	/// <summary>
	/// Formato para etiquetas
	/// </summary>
	[Serializable]
	public class EtiquetaFormato : Acesso.Comum.DbManipula��o
	{
		private string   formato;
		private string   autor;
		private DateTime data;
		private string   configuracao;

		/// <summary>
		/// Constr�i um formato de etiqueta
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

		public string Configura��o
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
			autor = Acesso.Comum.Usu�rios.Usu�rioAtual.Nome;

			if (VerificarExist�ncia(cmd, formato))
				throw new EntidadeJ�Existente(this);

			// Cadastrar formato
			cmd.CommandText = "INSERT INTO etiquetaformato (formato, autor, data, configuracao) "
				+ "VALUES ("
				+ DbTransformar(formato) + ", "
				+ DbTransformar(autor) + ", "
                + DbTransformar(data = DadosGlobais.Inst�ncia.HoraDataAtual) + ", "
				+ DbTransformar(configuracao) + ")";

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Verifica exist�ncia de um formato
		/// </summary>
		/// <param name="cmd">Comando do banco de dados</param>
		/// <param name="formato">Formato a ser verificado</param>
		/// <returns>Exist�ncia</returns>
		private static bool VerificarExist�ncia(IDbCommand cmd, string formato)
		{
			// Verificar se j� existe formato
			cmd.CommandText = "SELECT COUNT(*) FROM etiquetaformato "
				+ "WHERE formato = " + DbTransformar(formato);

			return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
		}

		/// <summary>
		/// Atualiza dados
		/// </summary>
		protected override void Atualizar(IDbCommand cmd)
		{
			autor = Acesso.Comum.Usu�rios.Usu�rioAtual.Nome;

			cmd.CommandText = "UPDATE etiquetaformato SET"
				+ " autor = " + DbTransformar(autor)
                + ", data = " + DbTransformar(data = DadosGlobais.Inst�ncia.HoraDataAtual)
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
				throw new EntidadeN�oCadastrada(this);

            lock (this)
            {
                IDbConnection conex�o = Conex�o;

                lock (conex�o)
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        if (VerificarExist�ncia(cmd, novoNome))
                            throw new EntidadeJ�Existente(this);

                        cmd.CommandText = "UPDATE etiquetaformato SET"
                            + " formato = " + DbTransformar(novoNome)
                            + " WHERE formato = " + DbTransformar(formato);

                        cmd.ExecuteNonQuery();

                        formato = novoNome;
                    }
            }
		}

		/// <summary>
		/// Reobtem as informa��es no mysql (configura��o, data, autor) a partir do Formato.
		/// </summary>
		/// <returns></returns>
		public void ReobterInforma��es()
		{
			EtiquetaFormato nova = EtiquetaFormato.ObterEtiqueta(formato);

			configuracao = nova.Configura��o;
			data = nova.Data;
			autor = nova.Autor;
			//formato = nova.Formato; //n�o precisa por raz�es �bvias
		}


		/// <summary>
		/// Obt�m etiquetas
		/// </summary>
		/// <returns>DataSet contendo etiquetas</returns>
        public static EtiquetaFormato[] ObterEtiquetas()
        {
            return Mapear<EtiquetaFormato>("SELECT * FROM etiquetaformato").ToArray();
        }

		/// <summary>
		/// Obt�m etiquetas
		/// </summary>
		/// <returns>DataSet contendo etiquetas</returns>
		public static EtiquetaFormato ObterEtiqueta(String formato)
		{
			EtiquetaFormato etiquetaObtida;
            IDbConnection conex�o = Conex�o;

			lock (conex�o)
			{
				using (IDbCommand cmd = conex�o.CreateCommand())
				{

					cmd.CommandText = "SELECT * FROM etiquetaformato where formato = " + DbTransformar(formato);

					etiquetaObtida = Mapear�nicaLinha<EtiquetaFormato>(cmd);
				}
			}

			return etiquetaObtida;
		}


		/// <summary>
		/// Cadastra um formato de etiqueta no banco de dados
		/// </summary>
		/// <param name="formato">Formato a ser cadastrado</param>
		/// <param name="configura��o">Configura��o do formato</param>
		/// <returns>Entidade constru�da</returns>
		public static EtiquetaFormato Cadastrar(string formato, string configura��o)
		{
			EtiquetaFormato nova;

			nova = new EtiquetaFormato(formato);
			nova.configuracao = configura��o;

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
			
			/* Inicialmente, a compara��o era entre o nome do formato:
			 * return a.Formato == b.Formato;
			 * 
			 * Entretanto, acredito ser mais interessante comparar
			 * a configura��o do formato, j� que um formato pode
			 * ser renomeado. Formatos duplicados, com nomes diferentes
			 * tamb�m podem ser agrupados, considerando-se o mesmo
			 * formato, j� que produzem a mesma impress�o.
			 */
			return a.configuracao == b.configuracao;
		}

		public static bool operator != (EtiquetaFormato a, EtiquetaFormato b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Verifica equival�ncia entre objetos
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

        public string ObterHashSemelhan�a()
        {
            return this.configuracao;
        }

	}
}
