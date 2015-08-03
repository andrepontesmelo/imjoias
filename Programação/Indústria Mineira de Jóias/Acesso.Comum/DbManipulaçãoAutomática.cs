using System;
using System.Collections;
using System.Data;
using Acesso.Comum.Mapeamento;
using System.Reflection;
using Acesso.Comum.Acompanhamento;

namespace Acesso.Comum
{
	/// <summary>
	/// Classe abstrata para entidades que manipulam
	/// o banco de dados e não dependem de herança,
	/// possuindo uma implementação bastante simplificada
	/// e automática. Para maior controle, utilize
	/// a classe base <see cref="DbManipulação"/>.
	/// </summary>
	/// 
	/// <remarks>
	/// O nome da classe (em minúsculo) determina o
    /// nome da tabela que será utilizada na construção
    /// dos comandos de cadastramento, atualização e
    /// descadastramento. No entanto, o nome de mapeamento
    /// da tabela do banco de dados pode ser definido
    /// utilizando o atributo opcional "DbTabela" <see cref="DbTabela"/>,
    /// caso o implementador queira que a classe possua um
	/// nome diferente da tabela. Tal caso pode ser
	/// quando a classe possuir acentos ou caracteres
	/// não permitidos pelo banco de dados.
	/// 
	/// É necessário definir o(s) atributo(s) da classe que
	/// é(são) chave(s)-primária(s) da tabela, utilizando
	/// o atributo "DbChavePrimária". Caso o campo seja
	/// também de auto-incremento, basta passar o valor
	/// verdadeiro na construtora do atributo.
	/// 
	/// Campos auto-incrementados, que não são também
	/// chave-primária, podem ser definidos utilizando
	/// o atributo "DbAtributo", passando por parâmetro
	/// o valor "TipoAtributo.AutoIncremento".
    /// 
    /// Campos auto-incrementados nunca são cadastrados
    /// manualmente, sendo o valor na entidade ignorado
    /// no momento do cadastro e atribuído automaticamente
    /// com o valor cadastrado pelo banco de dados.
	/// 
	/// Campos da classe que não estejam contidos
	/// na tabela do banco de dados devem atribuir
	/// o atributo "DbAtributo" com o parâmetro
	/// "TipoAtributo.Ignorar", para que seu valor
	/// não seja passado nos comandos de manipulação
	/// do banco de dados, gerando erro no mesmo.
    /// 
    /// Relacionamentos podem definidos com o atributo
    /// "DbRelacionamento". Neste caso, o valor utilizado
    /// na coluna do banco de dados é definido pelo atributo.
    /// 
    /// Relacionamentos invertidos podem ser definidos com
    /// o atributo "DbRelacionamentoInvertido" na classe do objeto
    /// relacionado. Este nome é dado aos relacionamentos cuja
    /// entidade não carrega nenhuma informação do relacionamento,
    /// porém a entidade relacionada possui uma chave estrangeira
    /// para esta.
    /// 
    /// Composições podem ser implementadas utilizando a
    /// classe "DbComposição", que permite personalização dos métodos
    /// de cadastro, atualização e remoção. Toda composição é marcado
    /// com o atributo "DbRelacionamentoInvertido", sendo manipulado
    /// sempre após a entidade da "DbManipulaçãoAutomática" ao qual
    /// pertence.
	/// </remarks>
	/// 
	/// <example>
	/// <code>
	/// [DbTabela("item_agenda")]
	/// public class ItemAgenda : DbManipulaçãoAutomática
	/// {
	///		[DbChavePrimária(true), DbColuna("codigo")]
	///		private int código;
	///		
	///		// Atributos
	///		private string nome;
	///		
	///		[DbColuna("endereco")]
	///		private string endereço;
	///		
	///		private string telefone;
	///		
	///		[DbRelacionamento("codigo", "cidade")]
	///		private Cidade cidade;
	///		
	///		[DbAtributo(TipoAtributo.Ignorar)]
	///		private Thread despertador;
	/// }
	/// </code>
	/// 
	/// <seealso cref="Acesso.Comum.DbAtributo"/>
	/// <seealso cref="Acesso.Comum.DbColuna"/>
	/// <seealso cref="Acesso.Comum.DbTabela"/>
	/// <seealso cref="Acesso.Comum.DbRelacionamento"/>
    /// <seealso cref="Acesso.Comum.DbRelacionamentoInvertido"/>
    /// <seealso cref="Acesso.Comum.DbComposição"/>
	/// </example>
	[Serializable]
	public abstract class DbManipulaçãoAutomática : DbManipulação
	{
        /// <summary>
        /// Informações de manipulação do banco de dados.
        /// </summary>
        private InfoManipulação infoManipulação;

        /// <summary>
        /// Informações de manipulação do banco de dados.
        /// </summary>
        internal InfoManipulação InfoManipulação
        {
            get { return infoManipulação; }
        }

        /// <summary>
        /// Constrói a entidade de manipulação automática.
        /// </summary>
        public DbManipulaçãoAutomática()
        {
            infoManipulação = InfoManipulação.ObterManipulação(GetType());
        }

        /// <summary>
        /// Obtém informações de manipulação da entidade no banco
        /// de dados.
        /// </summary>
        /// <param name="conexão">Conexão do banco de dados.</param>
        /// <returns>Informações de manipulação.</returns>
        private InfoManipulaçãoConexão ObterInfoManipulação(IDbConnection conexão)
        {
            ConexãoDbUsuário dbConexão;

            dbConexão = Usuários.UsuárioAtual.GerenciadorConexões.ObterInfoConexão(conexão);
            
            return dbConexão.ObterInfoManipulação(infoManipulação);
        }

        /// <summary>
        /// Faz uma cópia fiel de um comando.
        /// </summary>
        /// <param name="cmd">Comando a ser copiado.</param>
        /// <returns>Cópia do comando.</returns>
        private IDbCommand CopiarComando(IDbCommand cmd)
        {
            IDbCommand cópia;

            cópia = cmd.Connection.CreateCommand();
            cópia.CommandTimeout = cmd.CommandTimeout;
            cópia.UpdatedRowSource = cmd.UpdatedRowSource;
            cópia.Transaction = cmd.Transaction;

            CopiarMoldeComando(cmd, cópia);

            return cópia;
        }

        /// <summary>
        /// Copia molde de comando para outro.
        /// </summary>
        /// <param name="cmd">Molde de comando.</param>
        /// <param name="cópia">Comando onde será copiado.</param>
        private static void CopiarMoldeComando(IDbCommand molde, IDbCommand cmd)
        {
            if (cmd == molde)
                throw new Exception("Molde não pode ser o mesmo objeto do comando!");

            cmd.CommandText = molde.CommandText;
            cmd.CommandType = molde.CommandType;

            cmd.Parameters.Clear();

            foreach (IDataParameter parâmetro in molde.Parameters)
            {
                IDataParameter novoParâmetro = molde.CreateParameter();

                novoParâmetro.DbType = parâmetro.DbType;
                novoParâmetro.Direction = parâmetro.Direction;
                novoParâmetro.ParameterName = parâmetro.ParameterName;
                novoParâmetro.SourceColumn = parâmetro.SourceColumn;
                novoParâmetro.SourceVersion = parâmetro.SourceVersion;
                novoParâmetro.Value = parâmetro.Value;

                cmd.Parameters.Add(novoParâmetro);
            }
        }

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador deverá atribuir o valor
		/// verdadeiro para os atributos "cadastrado"
		/// e "atualizado".
        /// 
        /// Se você precisar cadastrar uma outra entidade dentro de um
        /// método de cadastro, utize o método CadastrarEntidade(entidade).
		/// </remarks>
		public override void Cadastrar()
		{
            lock (this)
            {
                IDbConnection conexão;

                if (Cadastrado)
                    throw new Exceções.EntidadeJáExistente(this);

                DispararAntesDeCadastrar();

                conexão = Conexão;

                lock (conexão)
                {
                    try
                    {
                        //Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                        /* Transações modificam o comando para cada
                         * execução. Para preservar o molde do comando,
                         * a transação deve trabalhar com cópias.
                         */
                        if (TransaçãoSegura)
                        {
                            using (IDbCommand cmd = conexão.CreateCommand())
                                CadastrarTransação(conexão, cmd);
                        }
                        else
                        {
                            InfoManipulaçãoConexão info;
                            IDbCommand cmd;

                            info = ObterInfoManipulação(conexão);
                            cmd = info.PrepararCadastramento(this);

                            Cadastrar(cmd);
                        }
                    } finally
                    {
                        //Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }

                atualizado = cadastrado = true;

                Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Cadastrado));
                DispararDepoisDeCadastrar();
            }
		}

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O comando já está preparado para cadastrar.
		/// </remarks>
		protected internal override void Cadastrar(System.Data.IDbCommand cmd)
		{
            /* Transações modificam o comando para cada
             * execução. Para preservar o molde do comando,
             * a transação deve trabalhar com cópias.
             */
            if (Transacionando || cmd.Transaction != null)
            {
                InfoManipulaçãoConexão info;
                IDbCommand             molde;

                info  = ObterInfoManipulação(cmd.Connection);
                molde = info.PrepararCadastramento(this);

                CopiarMoldeComando(molde, cmd);
            }
#if DEBUG
			try 
			{
#endif
				cmd.ExecuteNonQuery();
#if DEBUG
			} 
			catch (Exception e)
			{
				throw new Exception("Comando SQL: " + cmd.CommandText + "\n" + e.ToString());
			}
#endif

			// Atribuir valores auto-incrementados.
			System.Reflection.FieldInfo [] vetorAutoIncremento;
			
			vetorAutoIncremento = infoManipulação.AutoIncremento;

			if (vetorAutoIncremento.Length == 1)
				vetorAutoIncremento[0].SetValue(this, Convert.ChangeType(ObterÚltimoCódigoInserido(cmd.Connection), vetorAutoIncremento[0].FieldType));
			
			else if (vetorAutoIncremento.Length > 1)
				throw new NotSupportedException("Existe mais de um valor auto-incrementado. Não é possível cadastrar automaticamente e atribuir valores auto-incrementados ao objeto.");

            // Cadastrar relacionamentos invertidos.
            DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

            foreach (DbManipulação relacionamento in relacionamentos)
                if (relacionamento != null)
                    CadastrarEntidade(cmd, relacionamento);
		}

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador deverá atribuir o valor
		/// verdadeiro para o atributo "atualizado".
		/// </remarks>
        public override void Atualizar()
        {
            lock (this)
            {
                IDbConnection conexão;

                if (!Cadastrado)
                    throw new Exceções.EntidadeNãoCadastrada(this);

                if (!Atualizado)
                {
                    DispararAntesDeAtualizar();

                    conexão = Conexão;

                    lock (conexão)
                    {
                        try
                        {
                            //Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                            /* Transações modificam o comando para cada
                             * execução. Para preservar o molde do comando,
                             * a transação deve trabalhar com cópias.
                             */
                            if (TransaçãoSegura)
                            {
                                using (IDbCommand cmd = conexão.CreateCommand())
                                    AtualizarTransação(conexão, cmd);
                            }
                            else
                            {
                                IDbCommand cmd;
                                InfoManipulaçãoConexão info;

                                info = ObterInfoManipulação(conexão);
                                cmd = info.PrepararAtualização(this);

                                Atualizar(cmd);
                            }
                        }
                        finally
                        {
                            //Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                        }
                    }

                    atualizado = true;

                    Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Atualizado));
                    DispararDepoisDeAtualizar();
                }
            }
        }

        /// <summary>
        /// Determina se a entidade encontra-se atualizada com o banco de dados.
        /// </summary>
        public override bool Atualizado
        {
            get
            {
                bool atualizado = base.Atualizado;

                if (atualizado)
                {
                    DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

                    foreach (DbManipulação relacionamento in relacionamentos)
                        if (relacionamento != null)
                            atualizado &= relacionamento.Atualizado;
                }

                return atualizado;
            }
        }

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O comando já está preparado para atualizar.
		/// </remarks>
		protected internal override void Atualizar(System.Data.IDbCommand cmd)
		{
            /* Em Atualizar(), verifica-se se a propriedade Atualizado
             * é falsa. Ela pode ser fala, mesmo que a variável "atualizado"
             * seja verdadeira, uma vez que alteração nos relacionamentos
             * pode tornar a entidade em si desatualizada, enquanto a tabela
             * principal da entidade encontra-se atualizada.
             * -- Júlio, 12/04/2006
             */
            if (!atualizado)
            {
                /* Transações modificam o comando para cada
                 * execução. Para preservar o molde do comando,
                 * a transação deve trabalhar com cópias.
                 */
                if (Transacionando || cmd.Transaction != null)
                {
                    InfoManipulaçãoConexão info;
                    IDbCommand molde;

                    info = ObterInfoManipulação(cmd.Connection);
                    molde = info.PrepararAtualização(this);

                    CopiarMoldeComando(molde, cmd);
                }

                cmd.ExecuteNonQuery();
            }

            // Atualiza relacionamentos invertidos.
            DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

            foreach (DbManipulação relacionamento in relacionamentos)
                if (relacionamento != null)
                    AtualizarEntidade(cmd, relacionamento);
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador deverá atribuir o valor
		/// falso para os atributos "cadastrado" e
		/// "atualizado".
		/// </remarks>
		public override void Descadastrar()
		{
			lock (this)
			{
				IDbConnection conexão;

				if (!Cadastrado)
					throw new Exceções.EntidadeNãoCadastrada(this);

                DispararAntesDeDescadastrar();

				conexão = Conexão;

                lock (conexão)
                {
                    try
                    {
                        //Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        /* Transações modificam o comando para cada
                         * execução. Para preservar o molde do comando,
                         * a transação deve trabalhar com cópias.
                         */
                        if (TransaçãoSegura)
                        {
                            using (IDbCommand cmd = conexão.CreateCommand())
                                DescadastrarTransação(conexão, cmd);
                        }
                        else
                        {
                            IDbCommand cmd;
                            InfoManipulaçãoConexão info;

                            info = ObterInfoManipulação(conexão);
                            cmd = info.PrepararDescadastramento(this);

                            Descadastrar(cmd);
                        }
                    }
                    finally
                    {
                        //Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }

				cadastrado = atualizado = false;

                Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Descadastrado));
                DispararDepoisDeDescadastrar();
			}
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O comando já está preparado para o descadastro.
		/// </remarks>
		protected internal override void Descadastrar(System.Data.IDbCommand cmd)
		{
            // Descadastra relacionamentos invertidos.
            DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

            foreach (DbManipulação relacionamento in relacionamentos)
                if (relacionamento != null)
                    DescadastrarEntidade(cmd, relacionamento);

            /* Transações modificam o comando para cada
             * execução. Para preservar o molde do comando,
             * a transação deve trabalhar com cópias.
             */
            if (Transacionando || cmd.Transaction != null)
            {
                InfoManipulaçãoConexão info;
                IDbCommand molde;

                info  = ObterInfoManipulação(cmd.Connection);
                molde = info.PrepararDescadastramento(this);

                CopiarMoldeComando(molde, cmd);
            }

            cmd.ExecuteNonQuery();
		}

        /// <summary>
        /// Verifica se uma entidade possuia a mesma referência
        /// chave primária que outra.
        /// </summary>
        public override bool Referente(DbManipulação entidade)
        {
            if (this.GetType() != entidade.GetType())
                return false;

            bool referente = true;

            foreach (FieldInfo campo in infoManipulação.ChavePrimária)
                referente &= campo.GetValue(this).Equals(campo.GetValue(entidade));

            return referente;
        }

        /// <summary>
        /// Nome da tabela no banco de dados.
        /// </summary>
        protected string Tabela
        {
            get
            {
                return infoManipulação.Tabela;
            }
        }

        /// <summary>
        /// Verifica se duas entidades são iguais, comparando
        /// as chaves primárias e se estão atualizadas.
        /// </summary>
        public override bool Equals(object obj)
        {
            DbManipulaçãoAutomática entidade = obj as DbManipulaçãoAutomática;

            if (entidade != null && entidade.GetType() == GetType())
            {
                return (Cadastrado && entidade.Cadastrado && Atualizado && entidade.Atualizado && Referente(entidade)) || base.Equals(obj);
            }
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hash = 0;

            foreach (FieldInfo campo in infoManipulação.ChavePrimária)
                hash ^= campo.GetHashCode();

            return hash;
        }
	}
}
