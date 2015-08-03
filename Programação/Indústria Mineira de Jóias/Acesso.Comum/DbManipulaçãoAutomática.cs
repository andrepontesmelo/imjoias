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
	/// o banco de dados e n�o dependem de heran�a,
	/// possuindo uma implementa��o bastante simplificada
	/// e autom�tica. Para maior controle, utilize
	/// a classe base <see cref="DbManipula��o"/>.
	/// </summary>
	/// 
	/// <remarks>
	/// O nome da classe (em min�sculo) determina o
    /// nome da tabela que ser� utilizada na constru��o
    /// dos comandos de cadastramento, atualiza��o e
    /// descadastramento. No entanto, o nome de mapeamento
    /// da tabela do banco de dados pode ser definido
    /// utilizando o atributo opcional "DbTabela" <see cref="DbTabela"/>,
    /// caso o implementador queira que a classe possua um
	/// nome diferente da tabela. Tal caso pode ser
	/// quando a classe possuir acentos ou caracteres
	/// n�o permitidos pelo banco de dados.
	/// 
	/// � necess�rio definir o(s) atributo(s) da classe que
	/// �(s�o) chave(s)-prim�ria(s) da tabela, utilizando
	/// o atributo "DbChavePrim�ria". Caso o campo seja
	/// tamb�m de auto-incremento, basta passar o valor
	/// verdadeiro na construtora do atributo.
	/// 
	/// Campos auto-incrementados, que n�o s�o tamb�m
	/// chave-prim�ria, podem ser definidos utilizando
	/// o atributo "DbAtributo", passando por par�metro
	/// o valor "TipoAtributo.AutoIncremento".
    /// 
    /// Campos auto-incrementados nunca s�o cadastrados
    /// manualmente, sendo o valor na entidade ignorado
    /// no momento do cadastro e atribu�do automaticamente
    /// com o valor cadastrado pelo banco de dados.
	/// 
	/// Campos da classe que n�o estejam contidos
	/// na tabela do banco de dados devem atribuir
	/// o atributo "DbAtributo" com o par�metro
	/// "TipoAtributo.Ignorar", para que seu valor
	/// n�o seja passado nos comandos de manipula��o
	/// do banco de dados, gerando erro no mesmo.
    /// 
    /// Relacionamentos podem definidos com o atributo
    /// "DbRelacionamento". Neste caso, o valor utilizado
    /// na coluna do banco de dados � definido pelo atributo.
    /// 
    /// Relacionamentos invertidos podem ser definidos com
    /// o atributo "DbRelacionamentoInvertido" na classe do objeto
    /// relacionado. Este nome � dado aos relacionamentos cuja
    /// entidade n�o carrega nenhuma informa��o do relacionamento,
    /// por�m a entidade relacionada possui uma chave estrangeira
    /// para esta.
    /// 
    /// Composi��es podem ser implementadas utilizando a
    /// classe "DbComposi��o", que permite personaliza��o dos m�todos
    /// de cadastro, atualiza��o e remo��o. Toda composi��o � marcado
    /// com o atributo "DbRelacionamentoInvertido", sendo manipulado
    /// sempre ap�s a entidade da "DbManipula��oAutom�tica" ao qual
    /// pertence.
	/// </remarks>
	/// 
	/// <example>
	/// <code>
	/// [DbTabela("item_agenda")]
	/// public class ItemAgenda : DbManipula��oAutom�tica
	/// {
	///		[DbChavePrim�ria(true), DbColuna("codigo")]
	///		private int c�digo;
	///		
	///		// Atributos
	///		private string nome;
	///		
	///		[DbColuna("endereco")]
	///		private string endere�o;
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
    /// <seealso cref="Acesso.Comum.DbComposi��o"/>
	/// </example>
	[Serializable]
	public abstract class DbManipula��oAutom�tica : DbManipula��o
	{
        /// <summary>
        /// Informa��es de manipula��o do banco de dados.
        /// </summary>
        private InfoManipula��o infoManipula��o;

        /// <summary>
        /// Informa��es de manipula��o do banco de dados.
        /// </summary>
        internal InfoManipula��o InfoManipula��o
        {
            get { return infoManipula��o; }
        }

        /// <summary>
        /// Constr�i a entidade de manipula��o autom�tica.
        /// </summary>
        public DbManipula��oAutom�tica()
        {
            infoManipula��o = InfoManipula��o.ObterManipula��o(GetType());
        }

        /// <summary>
        /// Obt�m informa��es de manipula��o da entidade no banco
        /// de dados.
        /// </summary>
        /// <param name="conex�o">Conex�o do banco de dados.</param>
        /// <returns>Informa��es de manipula��o.</returns>
        private InfoManipula��oConex�o ObterInfoManipula��o(IDbConnection conex�o)
        {
            Conex�oDbUsu�rio dbConex�o;

            dbConex�o = Usu�rios.Usu�rioAtual.GerenciadorConex�es.ObterInfoConex�o(conex�o);
            
            return dbConex�o.ObterInfoManipula��o(infoManipula��o);
        }

        /// <summary>
        /// Faz uma c�pia fiel de um comando.
        /// </summary>
        /// <param name="cmd">Comando a ser copiado.</param>
        /// <returns>C�pia do comando.</returns>
        private IDbCommand CopiarComando(IDbCommand cmd)
        {
            IDbCommand c�pia;

            c�pia = cmd.Connection.CreateCommand();
            c�pia.CommandTimeout = cmd.CommandTimeout;
            c�pia.UpdatedRowSource = cmd.UpdatedRowSource;
            c�pia.Transaction = cmd.Transaction;

            CopiarMoldeComando(cmd, c�pia);

            return c�pia;
        }

        /// <summary>
        /// Copia molde de comando para outro.
        /// </summary>
        /// <param name="cmd">Molde de comando.</param>
        /// <param name="c�pia">Comando onde ser� copiado.</param>
        private static void CopiarMoldeComando(IDbCommand molde, IDbCommand cmd)
        {
            if (cmd == molde)
                throw new Exception("Molde n�o pode ser o mesmo objeto do comando!");

            cmd.CommandText = molde.CommandText;
            cmd.CommandType = molde.CommandType;

            cmd.Parameters.Clear();

            foreach (IDataParameter par�metro in molde.Parameters)
            {
                IDataParameter novoPar�metro = molde.CreateParameter();

                novoPar�metro.DbType = par�metro.DbType;
                novoPar�metro.Direction = par�metro.Direction;
                novoPar�metro.ParameterName = par�metro.ParameterName;
                novoPar�metro.SourceColumn = par�metro.SourceColumn;
                novoPar�metro.SourceVersion = par�metro.SourceVersion;
                novoPar�metro.Value = par�metro.Value;

                cmd.Parameters.Add(novoPar�metro);
            }
        }

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador dever� atribuir o valor
		/// verdadeiro para os atributos "cadastrado"
		/// e "atualizado".
        /// 
        /// Se voc� precisar cadastrar uma outra entidade dentro de um
        /// m�todo de cadastro, utize o m�todo CadastrarEntidade(entidade).
		/// </remarks>
		public override void Cadastrar()
		{
            lock (this)
            {
                IDbConnection conex�o;

                if (Cadastrado)
                    throw new Exce��es.EntidadeJ�Existente(this);

                DispararAntesDeCadastrar();

                conex�o = Conex�o;

                lock (conex�o)
                {
                    try
                    {
                        //Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                        /* Transa��es modificam o comando para cada
                         * execu��o. Para preservar o molde do comando,
                         * a transa��o deve trabalhar com c�pias.
                         */
                        if (Transa��oSegura)
                        {
                            using (IDbCommand cmd = conex�o.CreateCommand())
                                CadastrarTransa��o(conex�o, cmd);
                        }
                        else
                        {
                            InfoManipula��oConex�o info;
                            IDbCommand cmd;

                            info = ObterInfoManipula��o(conex�o);
                            cmd = info.PrepararCadastramento(this);

                            Cadastrar(cmd);
                        }
                    } finally
                    {
                        //Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }

                atualizado = cadastrado = true;

                Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Cadastrado));
                DispararDepoisDeCadastrar();
            }
		}

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O comando j� est� preparado para cadastrar.
		/// </remarks>
		protected internal override void Cadastrar(System.Data.IDbCommand cmd)
		{
            /* Transa��es modificam o comando para cada
             * execu��o. Para preservar o molde do comando,
             * a transa��o deve trabalhar com c�pias.
             */
            if (Transacionando || cmd.Transaction != null)
            {
                InfoManipula��oConex�o info;
                IDbCommand             molde;

                info  = ObterInfoManipula��o(cmd.Connection);
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
			
			vetorAutoIncremento = infoManipula��o.AutoIncremento;

			if (vetorAutoIncremento.Length == 1)
				vetorAutoIncremento[0].SetValue(this, Convert.ChangeType(Obter�ltimoC�digoInserido(cmd.Connection), vetorAutoIncremento[0].FieldType));
			
			else if (vetorAutoIncremento.Length > 1)
				throw new NotSupportedException("Existe mais de um valor auto-incrementado. N�o � poss�vel cadastrar automaticamente e atribuir valores auto-incrementados ao objeto.");

            // Cadastrar relacionamentos invertidos.
            DbManipula��o[] relacionamentos = infoManipula��o.ObterRelacionamentosInvertidos(this);

            foreach (DbManipula��o relacionamento in relacionamentos)
                if (relacionamento != null)
                    CadastrarEntidade(cmd, relacionamento);
		}

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador dever� atribuir o valor
		/// verdadeiro para o atributo "atualizado".
		/// </remarks>
        public override void Atualizar()
        {
            lock (this)
            {
                IDbConnection conex�o;

                if (!Cadastrado)
                    throw new Exce��es.EntidadeN�oCadastrada(this);

                if (!Atualizado)
                {
                    DispararAntesDeAtualizar();

                    conex�o = Conex�o;

                    lock (conex�o)
                    {
                        try
                        {
                            //Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                            /* Transa��es modificam o comando para cada
                             * execu��o. Para preservar o molde do comando,
                             * a transa��o deve trabalhar com c�pias.
                             */
                            if (Transa��oSegura)
                            {
                                using (IDbCommand cmd = conex�o.CreateCommand())
                                    AtualizarTransa��o(conex�o, cmd);
                            }
                            else
                            {
                                IDbCommand cmd;
                                InfoManipula��oConex�o info;

                                info = ObterInfoManipula��o(conex�o);
                                cmd = info.PrepararAtualiza��o(this);

                                Atualizar(cmd);
                            }
                        }
                        finally
                        {
                            //Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                        }
                    }

                    atualizado = true;

                    Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Atualizado));
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
                    DbManipula��o[] relacionamentos = infoManipula��o.ObterRelacionamentosInvertidos(this);

                    foreach (DbManipula��o relacionamento in relacionamentos)
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
		/// O comando j� est� preparado para atualizar.
		/// </remarks>
		protected internal override void Atualizar(System.Data.IDbCommand cmd)
		{
            /* Em Atualizar(), verifica-se se a propriedade Atualizado
             * � falsa. Ela pode ser fala, mesmo que a vari�vel "atualizado"
             * seja verdadeira, uma vez que altera��o nos relacionamentos
             * pode tornar a entidade em si desatualizada, enquanto a tabela
             * principal da entidade encontra-se atualizada.
             * -- J�lio, 12/04/2006
             */
            if (!atualizado)
            {
                /* Transa��es modificam o comando para cada
                 * execu��o. Para preservar o molde do comando,
                 * a transa��o deve trabalhar com c�pias.
                 */
                if (Transacionando || cmd.Transaction != null)
                {
                    InfoManipula��oConex�o info;
                    IDbCommand molde;

                    info = ObterInfoManipula��o(cmd.Connection);
                    molde = info.PrepararAtualiza��o(this);

                    CopiarMoldeComando(molde, cmd);
                }

                cmd.ExecuteNonQuery();
            }

            // Atualiza relacionamentos invertidos.
            DbManipula��o[] relacionamentos = infoManipula��o.ObterRelacionamentosInvertidos(this);

            foreach (DbManipula��o relacionamento in relacionamentos)
                if (relacionamento != null)
                    AtualizarEntidade(cmd, relacionamento);
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador dever� atribuir o valor
		/// falso para os atributos "cadastrado" e
		/// "atualizado".
		/// </remarks>
		public override void Descadastrar()
		{
			lock (this)
			{
				IDbConnection conex�o;

				if (!Cadastrado)
					throw new Exce��es.EntidadeN�oCadastrada(this);

                DispararAntesDeDescadastrar();

				conex�o = Conex�o;

                lock (conex�o)
                {
                    try
                    {
                        //Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        /* Transa��es modificam o comando para cada
                         * execu��o. Para preservar o molde do comando,
                         * a transa��o deve trabalhar com c�pias.
                         */
                        if (Transa��oSegura)
                        {
                            using (IDbCommand cmd = conex�o.CreateCommand())
                                DescadastrarTransa��o(conex�o, cmd);
                        }
                        else
                        {
                            IDbCommand cmd;
                            InfoManipula��oConex�o info;

                            info = ObterInfoManipula��o(conex�o);
                            cmd = info.PrepararDescadastramento(this);

                            Descadastrar(cmd);
                        }
                    }
                    finally
                    {
                        //Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }

				cadastrado = atualizado = false;

                Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Descadastrado));
                DispararDepoisDeDescadastrar();
			}
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O comando j� est� preparado para o descadastro.
		/// </remarks>
		protected internal override void Descadastrar(System.Data.IDbCommand cmd)
		{
            // Descadastra relacionamentos invertidos.
            DbManipula��o[] relacionamentos = infoManipula��o.ObterRelacionamentosInvertidos(this);

            foreach (DbManipula��o relacionamento in relacionamentos)
                if (relacionamento != null)
                    DescadastrarEntidade(cmd, relacionamento);

            /* Transa��es modificam o comando para cada
             * execu��o. Para preservar o molde do comando,
             * a transa��o deve trabalhar com c�pias.
             */
            if (Transacionando || cmd.Transaction != null)
            {
                InfoManipula��oConex�o info;
                IDbCommand molde;

                info  = ObterInfoManipula��o(cmd.Connection);
                molde = info.PrepararDescadastramento(this);

                CopiarMoldeComando(molde, cmd);
            }

            cmd.ExecuteNonQuery();
		}

        /// <summary>
        /// Verifica se uma entidade possuia a mesma refer�ncia
        /// chave prim�ria que outra.
        /// </summary>
        public override bool Referente(DbManipula��o entidade)
        {
            if (this.GetType() != entidade.GetType())
                return false;

            bool referente = true;

            foreach (FieldInfo campo in infoManipula��o.ChavePrim�ria)
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
                return infoManipula��o.Tabela;
            }
        }

        /// <summary>
        /// Verifica se duas entidades s�o iguais, comparando
        /// as chaves prim�rias e se est�o atualizadas.
        /// </summary>
        public override bool Equals(object obj)
        {
            DbManipula��oAutom�tica entidade = obj as DbManipula��oAutom�tica;

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

            foreach (FieldInfo campo in infoManipula��o.ChavePrim�ria)
                hash ^= campo.GetHashCode();

            return hash;
        }
	}
}
