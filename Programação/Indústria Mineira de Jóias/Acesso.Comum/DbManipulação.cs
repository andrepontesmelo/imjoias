using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using Acesso;
using Acesso.Comum.Acompanhamento;

namespace Acesso.Comum
{
	/// <summary>
	/// Classe abstrata para entidades que manipulam o
	/// banco de dados.
	/// </summary>
	/// 
	/// <remarks>
	/// Para criar uma transação em uma classe hierárquica,
	/// (exemplo: Pessoa, PessoaFísica e Representante),
	/// utilize o atributo <see cref="DbTransação"/> no início da classe.
	/// 
	/// <seealso cref="DbTransação"/>
	/// </remarks>
	[Serializable]
	public abstract class DbManipulação : DbManipulaçãoSimples
	{
		/// <summary>
		/// Determina se a entidade encontra-se cadastrada
		/// no banco de dados.
		/// </summary>
		[DbAtributo(TipoAtributo.Ignorar)]
        internal bool cadastrado = false;

		/// <summary>
		/// Determina se a entidade encontra-se atualizada
		/// no banco de dados.
		/// </summary>
		[DbAtributo(TipoAtributo.Ignorar)]
        internal bool atualizado = false;

		/// <summary>
		/// Marca se objeto está transacionando.
		/// </summary>
		[DbAtributo(TipoAtributo.Ignorar)]
		private bool transacionando = false;

        private List<DbManipulação> referentes;

        /// <summary>
        /// Lista de entidades que referenciam esta.
        /// </summary>
        /// <remarks>
        /// Esta lista é utilizada para remover da cache outras
        /// entidades que podem ser afetadas por alteração nesta.
        /// </remarks>
        internal List<DbManipulação> Referentes
        {
            get
            {
                if (referentes == null)
                    referentes = new List<DbManipulação>();
                return referentes;
            }
        }

        /// <summary>
        /// Determina se esta entidade possui outras que a referenciam.
        /// </summary>
        internal bool PossuiReferentes { get { return referentes != null; } }

        public delegate void DbManipulaçãoHandler(DbManipulação entidade);
        public delegate void DbManipulaçãoCancelávelHandler(DbManipulação entidade, out bool cancelar);

        /// <summary>
        /// Disparado sempre que atualizado for atribuído
        /// com o valor falso.
        /// </summary>
        public event DbManipulaçãoHandler Alterado;

        /// <summary>
        /// Evento disparado antes de cadastrar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipulaçãoCancelávelHandler AntesDeCadastrar;

        /// <summary>
        /// Evento disparado antes de atualizar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipulaçãoCancelávelHandler AntesDeAtualizar;

        /// <summary>
        /// Evento disparado antes de remover entidade
        /// do banco de dados.
        /// </summary>
        public event DbManipulaçãoCancelávelHandler AntesDeDescadastrar;

        /// <summary>
        /// Evento disparado depois de cadastrar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipulaçãoHandler DepoisDeCadastrar;

        /// <summary>
        /// Evento disparado depois de atualizar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipulaçãoHandler DepoisDeAtualizar;

        /// <summary>
        /// Evento disparado depois de remover entidade
        /// do banco de dados.
        /// </summary>
        public event DbManipulaçãoHandler DepoisDeDescadastrar;

		#region Propriedades

        /// <summary>
		/// Determina se a entidade encontra-se cadastrada
		/// no banco de dados.
		/// </summary>
		public virtual bool Cadastrado
		{
			get { return cadastrado; }
		}

        /// <summary>
        /// Determina se a entidade encontra-se atualizada
        /// com o banco de dados.
        /// </summary>
        public virtual bool Atualizado
        {
            get 
            { 
                return atualizado; 
            }
        }

        /// <summary>
        /// Define verdadeira a propriedade cadastrado.
        /// </summary>
        protected void DefinirCadastrado()
        {
            cadastrado = true;
        }

        /// <summary>
        /// Define o valor da propriedade cadastrado.
        /// </summary>
        protected void DefinirCadastrado(bool cadastrado)
        {
            this.cadastrado = cadastrado;
        }

        /// <summary>
        /// Define verdadeira a propriedade atualizado.
        /// </summary>
        protected void DefinirAtualizado()
        {
            this.atualizado = true;
        }

        /// <summary>
        /// Define o valor da propriedade atualizado.
        /// </summary>
        protected void DefinirAtualizado(bool atualizado)
        {
            this.atualizado = atualizado;

            if (!atualizado && Alterado != null)
                Alterado(this);
        }

        /// <summary>
        /// Define falsa a propriedade atualizado.
        /// </summary>
        protected void DefinirDesatualizado()
        {
            this.atualizado = false;

            if (Alterado != null)
                Alterado(this);
        }

		#endregion

#region Manipulação de dados (abstrato)

		/// <summary>
		/// Verifica se este objeto utiliza transação segura
		/// para cadastrar, atualizar e descadastrar.
		/// </summary>
		public bool TransaçãoSegura
		{
			get
			{
				DbTransação [] atributos;
				Type           tipo;

				tipo      = this.GetType();
				atributos = (DbTransação []) tipo.GetCustomAttributes(typeof(DbTransação), true);

				return atributos.Length > 0;
			}
		}

		/// <summary>
		/// Verifica se o objeto está transacionando.
		/// </summary>
		/// <remarks>
		/// Considera que existe o atributo.
		/// </remarks>
		public bool Transacionando
		{
			get
			{
				return transacionando;
			}
		}

		/// <summary>
		/// Marca início de transação.
		/// </summary>
		/// <remarks>
		/// Considera que existe o atributo.
		/// </remarks>
		private void MarcarTransação()
		{
			transacionando = true;
		}

		/// <summary>
		/// Retirar marca da transação.
		/// </summary>
		/// <remarks>
		/// Considera que existe o atributo.
		/// </remarks>
		private void DesmarcarTransação()
		{
			transacionando = false;
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
		public virtual void Cadastrar()
		{
			try
			{
                lock (this)
                {
                    IDbConnection conexão;
                    IDbCommand cmd;

                    if (Cadastrado)
                        throw new Exceções.EntidadeJáExistente(this);

                    DispararAntesDeCadastrar();

                    // Efetuar cadastro.
                    conexão = Conexão;

                    lock (conexão)
                    {
                        try
                        {
                            Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                            using (cmd = conexão.CreateCommand())
                            {
                                if (TransaçãoSegura)
                                    CadastrarTransação(conexão, cmd);
                                else
                                    Cadastrar(cmd);
                            }
                        }
                        finally
                        {
                            Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                        }
                    }

                    atualizado = cadastrado = true;

                    Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Cadastrado));
                    DispararDepoisDeCadastrar();
                }
			}
			catch (Exception e)
			{
				Console.WriteLine("Ocorreu um erro cadastrando um objeto {0} no banco de dados.", this.GetType().FullName);
				Console.WriteLine(e.ToString());
				Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
				
                throw new Exception("Ocorreu um erro cadastrando um objeto do tipo " + GetType().FullName + ".", e);
			}
		}

        protected void DispararDepoisDeCadastrar()
        {
            if (DepoisDeCadastrar != null)
                DepoisDeCadastrar(this);
        }

        internal void DispararAntesDeCadastrar()
        {
            // Verificar se operação será cancelada pelo sistema.
            if (AntesDeCadastrar != null)
            {
                bool cancelar;

                AntesDeCadastrar(this, out cancelar);

                if (cancelar)
                    throw new Exceções.OperaçãoCancelada(this);
            }
        }

		/// <summary>
		/// Cadastra a entidade no banco de dados em uma
		/// transação segura.
		/// </summary>
		/// <param name="conexão">Conexão do banco de dados.</param>
		/// <param name="cmd">Comando da transação.</param>
		protected void CadastrarTransação(IDbConnection conexão, IDbCommand cmd)
		{
			IDbTransaction transação;

			MarcarTransação();

			using (transação = conexão.BeginTransaction())
			{
				cmd.Transaction = transação;

				try
				{
					Cadastrar(cmd);

					transação.Commit();
				}
				catch (Exception e)
				{
					transação.Rollback();
                    throw new Exception("Não foi possível concluir o cadastro. \n" + cmd.CommandText, e);
				}
				finally
				{
					DesmarcarTransação();
				}
			}
		}
		
		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		protected internal abstract void Cadastrar(IDbCommand cmd);

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador deverá atribuir o valor
		/// verdadeiro para o atributo "atualizado".
		/// </remarks>
		public virtual void Atualizar()
		{
            //try
            //{
				lock (this)
				{
					IDbConnection conexão;
					IDbCommand    cmd;

					if (!Cadastrado)
						throw new Exceções.EntidadeNãoCadastrada(this);

                    if (!Atualizado)
                    {
                        DispararAntesDeAtualizar();

                        // Efetuar atualização.
                        conexão = Conexão;

                        lock (conexão)
                        {
                            try
                            {

                                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                                using (cmd = conexão.CreateCommand())
                                {
                                    if (TransaçãoSegura)
                                        AtualizarTransação(conexão, cmd);
                                    else
                                        Atualizar(cmd);
                                }
                            }
                            finally
                            {
                                Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                            }
                        }

                        atualizado = true;

                        Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Atualizado));
                        DispararDepoisDeAtualizar();
                    }
				}
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Ocorreu um erro atualizando um objeto {0} no banco de dados.", this.GetType().FullName);
            //    Console.WriteLine(e.ToString());
            //    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            //    throw new Exception("Ocorreu um erro atualizando o objeto do tipo " + GetType().FullName, e);
            //}
		}

        protected void DispararDepoisDeAtualizar()
        {
            if (referentes != null)
            {
                foreach (DbManipulação referente in referentes)
                    Cache.CacheDb.Instância.Remover(referente);

                referentes = null;
            }

            Cache.CacheDb.Instância.Remover(this);

            if (DepoisDeAtualizar != null)
                DepoisDeAtualizar(this);
        }

        internal void DispararAntesDeAtualizar()
        {
            // Verificar se operação será cancelada pelo sistema.
            if (AntesDeAtualizar != null)
            {
                bool cancelar;

                AntesDeAtualizar(this, out cancelar);

                if (cancelar)
                    throw new Exceções.OperaçãoCancelada(this);
            }
        }

		/// <summary>
		/// Atualiza a entidade no banco de dados em uma
		/// transação segura.
		/// </summary>
		/// <param name="conexão">Conexão do banco de dados.</param>
		/// <param name="cmd">Comando da transação.</param>
		protected void AtualizarTransação(IDbConnection conexão, IDbCommand cmd)
		{
			IDbTransaction transação;

			MarcarTransação();

            try
            {
                using (transação = conexão.BeginTransaction())
                {
                    cmd.Transaction = transação;

                    try
                    {
                        Atualizar(cmd);

                        transação.Commit();
                    }
                    catch (Exception e)
                    {
                        transação.Rollback();

                        throw new Exception("Não foi possível concluir a atualização!", e);
                    }
                }
            }
            finally
            {
                DesmarcarTransação();
            }
		}

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		protected internal abstract void Atualizar(IDbCommand cmd);

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador deverá atribuir o valor
		/// falso para os atributos "cadastrado" e
		/// "atualizado".
		/// </remarks>
		public virtual void Descadastrar()
		{
            IDbCommand cmd = null;

			try
			{
                lock (this)
                {
                    IDbConnection conexão;

                    if (!Cadastrado)
                        throw new Exceções.EntidadeNãoCadastrada(this);

                    DispararAntesDeDescadastrar();

                    // Efetuar descadastro.
                    conexão = Conexão;

                    lock (conexão)
                    {
                        try
                        {
                            Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                            using (cmd = conexão.CreateCommand())
                            {
                                if (TransaçãoSegura)
                                    DescadastrarTransação(conexão, cmd);
                                else
                                    Descadastrar(cmd);
                            }
                        }
                        finally
                        {
                            Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                        }
                    }

                    cadastrado = atualizado = false;

                    Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Descadastrado));
                    DispararDepoisDeDescadastrar();
                }
			}
			catch (Exception e)
			{
				Console.WriteLine("Ocorreu um erro descadastrando um objeto {0} no banco de dados.", this.GetType().FullName);
				Console.WriteLine(e.ToString());
				Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
				throw new Exception("Ocorreu um erro descadastrando um objeto do tipo " + GetType().FullName + ".\n" + cmd == null ? "" : cmd.CommandText, e);
			}
		}

        protected void DispararDepoisDeDescadastrar()
        {
            if (referentes != null)
            {
                foreach (DbManipulação referente in referentes)
                    Cache.CacheDb.Instância.Remover(referente);

                referentes = null;
            }

            Cache.CacheDb.Instância.Remover(this);

            if (DepoisDeDescadastrar != null)
                DepoisDeDescadastrar(this);
        }

        internal void DispararAntesDeDescadastrar()
        {
            // Verificar se operação será cancelada pelo sistema.
            if (AntesDeDescadastrar != null)
            {
                bool cancelar;

                AntesDeDescadastrar(this, out cancelar);

                if (cancelar)
                    throw new Exceções.OperaçãoCancelada(this);
            }
        }

		/// <summary>
		/// Descadastra a entidade no banco de dados em uma
		/// transação segura.
		/// </summary>
		/// <param name="conexão">Conexão do banco de dados.</param>
		/// <param name="cmd">Comando da transação.</param>
		protected void DescadastrarTransação(IDbConnection conexão, IDbCommand cmd)
		{
			IDbTransaction transação;

			MarcarTransação();

            try
            {
                using (transação = conexão.BeginTransaction())
                {
                    cmd.Transaction = transação;

                    try
                    {
                        Descadastrar(cmd);

                        transação.Commit();
                    }
                    catch (Exception e)
                    {
                        transação.Rollback();
                        throw new Exception("Não foi possível concluir a transação.", e);
                    }
                }
            }
            finally
            {
                DesmarcarTransação();
            }
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		protected internal abstract void Descadastrar(IDbCommand cmd);

		#endregion

        /// <summary>
        /// Verifica se uma entidade possuia a mesma referência
        /// (mesma chave primária) que outra.
        /// </summary>
        public virtual bool Referente(DbManipulação entidade)
        {
            return Equals(entidade);
        }

        /// <summary>
        /// Atualiza uma entidade utilizando um comando já existente,
        /// recomendado em relacionamentos para operações com transação.
        /// </summary>
        /// <remarks>
        /// Só é possível utilizar este comando em conjunto com o atributo
        /// Dbtransação.
        /// </remarks>
        protected void AtualizarEntidade(IDbCommand cmd, DbManipulação entidade)
        {
            /* Necessário o uso de transação, caso contrário
             * objetos do tipo DbManipulaçãoAutomática não substituirão
             * o comando.
             */
            if (!Transacionando)
                throw new NotSupportedException("Não é permitido o uso de compartilhamento de IDbCommand sem o uso do atributo \"DbTransação\".");

            entidade.MarcarTransação();

            try
            {
                entidade.DispararAntesDeAtualizar();
                entidade.Atualizar(cmd);
                entidade.atualizado = true;

                if (entidade.DepoisDeAtualizar != null)
                    entidade.DepoisDeAtualizar(entidade);
            }
            finally
            {
                entidade.DesmarcarTransação();
            }
        }

        /// <summary>
        /// Cadastra uma entidade utilizando um comando já existente,
        /// recomendado em relacionamentos para operações com transação.
        /// </summary>
        /// <remarks>
        /// Só é possível utilizar este comando em conjunto com o atributo
        /// Dbtransação.
        /// </remarks>
        protected void CadastrarEntidade(IDbCommand cmd, DbManipulação entidade)
        {
            /* Necessário o uso de transação, caso contrário
             * objetos do tipo DbManipulaçãoAutomática não substituirão
             * o comando.
             */
            if (!Transacionando)
                throw new NotSupportedException("Não é permitido o uso de compartilhamento de IDbCommand sem o uso do atributo \"DbTransação\".");

            entidade.MarcarTransação();

            try
            {
                entidade.DispararAntesDeCadastrar();
                entidade.Cadastrar(cmd);
                entidade.cadastrado = true;
                entidade.atualizado = true;

                if (entidade.DepoisDeCadastrar != null)
                    entidade.DepoisDeCadastrar(entidade);
            }
            finally
            {
                entidade.DesmarcarTransação();
            }
        }

        /// <summary>
        /// Descadastra uma entidade utilizando um comando já existente,
        /// recomendado em relacionamentos para operações com transação.
        /// </summary>
        /// <remarks>
        /// Só é possível utilizar este comando em conjunto com o atributo
        /// Dbtransação.
        /// </remarks>
        protected void DescadastrarEntidade(IDbCommand cmd, DbManipulação entidade)
        {
            /* Necessário o uso de transação, caso contrário
             * objetos do tipo DbManipulaçãoAutomática não substituirão
             * o comando.
             */
            if (!Transacionando)
                throw new NotSupportedException("Não é permitido o uso de compartilhamento de IDbCommand sem o uso do atributo \"DbTransação\".");

            entidade.MarcarTransação();

            try
            {
                entidade.DispararAntesDeDescadastrar();
                entidade.Descadastrar(cmd);
                entidade.cadastrado = false;
                entidade.atualizado = false;

                if (entidade.DepoisDeDescadastrar != null)
                    entidade.DepoisDeDescadastrar(entidade);
            }
            finally
            {
                entidade.DesmarcarTransação();
            }
        }
    }
}
