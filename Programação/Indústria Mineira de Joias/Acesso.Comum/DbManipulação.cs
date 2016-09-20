using Acesso.Comum.Acompanhamento;
using System;
using System.Collections.Generic;
using System.Data;

namespace Acesso.Comum
{
    [Serializable]
	public abstract class DbManipulação : DbManipulaçãoSimples
	{
		[DbAtributo(TipoAtributo.Ignorar)]
        internal bool cadastrado = false;

		[DbAtributo(TipoAtributo.Ignorar)]
        internal bool atualizado = false;

		[DbAtributo(TipoAtributo.Ignorar)]
		private bool transacionando = false;

        private List<DbManipulação> referentes;

        internal List<DbManipulação> Referentes
        {
            get
            {
                if (referentes == null)
                    referentes = new List<DbManipulação>();
                return referentes;
            }
        }

        internal bool PossuiReferentes { get { return referentes != null; } }

        public delegate void DbManipulaçãoHandler(DbManipulação entidade);
        public delegate void DbManipulaçãoCancelávelHandler(DbManipulação entidade, out bool cancelar);

        public event DbManipulaçãoHandler Alterado;
        public event DbManipulaçãoCancelávelHandler AntesDeCadastrar;
        public event DbManipulaçãoCancelávelHandler AntesDeAtualizar;
        public event DbManipulaçãoCancelávelHandler AntesDeDescadastrar;
        public event DbManipulaçãoHandler DepoisDeCadastrar;
        public event DbManipulaçãoHandler DepoisDeAtualizar;
        public event DbManipulaçãoHandler DepoisDeDescadastrar;

		public virtual bool Cadastrado
		{
			get { return cadastrado; }
		}

        public virtual bool Atualizado
        {
            get 
            { 
                return atualizado; 
            }
        }

        protected void DefinirCadastrado()
        {
            cadastrado = true;
        }

        protected void DefinirCadastrado(bool cadastrado)
        {
            this.cadastrado = cadastrado;
        }

        protected void DefinirAtualizado()
        {
            this.atualizado = true;
        }

        protected void DefinirAtualizado(bool atualizado)
        {
            this.atualizado = atualizado;

            if (!atualizado && Alterado != null)
                Alterado(this);
        }

        protected void DefinirDesatualizado()
        {
            this.atualizado = false;

            if (Alterado != null)
                Alterado(this);
        }

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

        public bool Transacionando => transacionando;

		private void MarcarTransação()
		{
			transacionando = true;
		}

		private void DesmarcarTransação()
		{
			transacionando = false;
		}

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
				Usuários.UsuárioAtual.RegistrarErro(e);
				
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
            if (AntesDeCadastrar != null)
            {
                bool cancelar;

                AntesDeCadastrar(this, out cancelar);

                if (cancelar)
                    throw new Exceções.OperaçãoCancelada(this);
            }
        }

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
		
		protected internal abstract void Cadastrar(IDbCommand cmd);

        public virtual void Atualizar()
        {
            lock (this)
            {
                IDbConnection conexão;
                IDbCommand cmd;

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
            if (AntesDeAtualizar != null)
            {
                bool cancelar;

                AntesDeAtualizar(this, out cancelar);

                if (cancelar)
                    throw new Exceções.OperaçãoCancelada(this);
            }
        }

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

		protected internal abstract void Atualizar(IDbCommand cmd);

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
				Usuários.UsuárioAtual.RegistrarErro(e);
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
            if (AntesDeDescadastrar != null)
            {
                bool cancelar;

                AntesDeDescadastrar(this, out cancelar);

                if (cancelar)
                    throw new Exceções.OperaçãoCancelada(this);
            }
        }

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

		protected internal abstract void Descadastrar(IDbCommand cmd);

        public virtual bool Referente(DbManipulação entidade)
        {
            return Equals(entidade);
        }

        protected void AtualizarEntidade(IDbCommand cmd, DbManipulação entidade)
        {
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

        protected void CadastrarEntidade(IDbCommand cmd, DbManipulação entidade)
        {
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

        protected void DescadastrarEntidade(IDbCommand cmd, DbManipulação entidade)
        {
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
