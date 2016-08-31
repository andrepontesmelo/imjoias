using Acesso.Comum.Acompanhamento;
using System;
using System.Collections.Generic;
using System.Data;

namespace Acesso.Comum
{
    [Serializable]
	public abstract class DbManipula��o : DbManipula��oSimples
	{
		[DbAtributo(TipoAtributo.Ignorar)]
        internal bool cadastrado = false;

		[DbAtributo(TipoAtributo.Ignorar)]
        internal bool atualizado = false;

		[DbAtributo(TipoAtributo.Ignorar)]
		private bool transacionando = false;

        private List<DbManipula��o> referentes;

        internal List<DbManipula��o> Referentes
        {
            get
            {
                if (referentes == null)
                    referentes = new List<DbManipula��o>();
                return referentes;
            }
        }

        internal bool PossuiReferentes { get { return referentes != null; } }

        public delegate void DbManipula��oHandler(DbManipula��o entidade);
        public delegate void DbManipula��oCancel�velHandler(DbManipula��o entidade, out bool cancelar);

        public event DbManipula��oHandler Alterado;
        public event DbManipula��oCancel�velHandler AntesDeCadastrar;
        public event DbManipula��oCancel�velHandler AntesDeAtualizar;
        public event DbManipula��oCancel�velHandler AntesDeDescadastrar;
        public event DbManipula��oHandler DepoisDeCadastrar;
        public event DbManipula��oHandler DepoisDeAtualizar;
        public event DbManipula��oHandler DepoisDeDescadastrar;

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

		public bool Transa��oSegura
		{
			get
			{
				DbTransa��o [] atributos;
				Type           tipo;

				tipo      = this.GetType();
				atributos = (DbTransa��o []) tipo.GetCustomAttributes(typeof(DbTransa��o), true);

				return atributos.Length > 0;
			}
		}

        public bool Transacionando => transacionando;

		private void MarcarTransa��o()
		{
			transacionando = true;
		}

		private void DesmarcarTransa��o()
		{
			transacionando = false;
		}

		public virtual void Cadastrar()
		{
			try
			{
                lock (this)
                {
                    IDbConnection conex�o;
                    IDbCommand cmd;

                    if (Cadastrado)
                        throw new Exce��es.EntidadeJ�Existente(this);

                    DispararAntesDeCadastrar();

                    conex�o = Conex�o;

                    lock (conex�o)
                    {
                        try
                        {
                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                            using (cmd = conex�o.CreateCommand())
                            {
                                if (Transa��oSegura)
                                    CadastrarTransa��o(conex�o, cmd);
                                else
                                    Cadastrar(cmd);
                            }
                        }
                        finally
                        {
                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                        }
                    }

                    atualizado = cadastrado = true;

                    Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Cadastrado));
                    DispararDepoisDeCadastrar();
                }
			}
			catch (Exception e)
			{
				Console.WriteLine("Ocorreu um erro cadastrando um objeto {0} no banco de dados.", this.GetType().FullName);
				Console.WriteLine(e.ToString());
				Usu�rios.Usu�rioAtual.RegistrarErro(e);
				
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
                    throw new Exce��es.Opera��oCancelada(this);
            }
        }

		protected void CadastrarTransa��o(IDbConnection conex�o, IDbCommand cmd)
		{
			IDbTransaction transa��o;

			MarcarTransa��o();

			using (transa��o = conex�o.BeginTransaction())
			{
				cmd.Transaction = transa��o;

				try
				{
					Cadastrar(cmd);

					transa��o.Commit();
				}
				catch (Exception e)
				{
					transa��o.Rollback();
                    throw new Exception("N�o foi poss�vel concluir o cadastro. \n" + cmd.CommandText, e);
				}
				finally
				{
					DesmarcarTransa��o();
				}
			}
		}
		
		protected internal abstract void Cadastrar(IDbCommand cmd);

        public virtual void Atualizar()
        {
            lock (this)
            {
                IDbConnection conex�o;
                IDbCommand cmd;

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

                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                            using (cmd = conex�o.CreateCommand())
                            {
                                if (Transa��oSegura)
                                    AtualizarTransa��o(conex�o, cmd);
                                else
                                    Atualizar(cmd);
                            }
                        }
                        finally
                        {
                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                        }
                    }

                    atualizado = true;

                    Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Atualizado));
                    DispararDepoisDeAtualizar();
                }
            }
        }

        protected void DispararDepoisDeAtualizar()
        {
            if (referentes != null)
            {
                foreach (DbManipula��o referente in referentes)
                    Cache.CacheDb.Inst�ncia.Remover(referente);

                referentes = null;
            }

            Cache.CacheDb.Inst�ncia.Remover(this);

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
                    throw new Exce��es.Opera��oCancelada(this);
            }
        }

		protected void AtualizarTransa��o(IDbConnection conex�o, IDbCommand cmd)
		{
			IDbTransaction transa��o;

			MarcarTransa��o();

            try
            {
                using (transa��o = conex�o.BeginTransaction())
                {
                    cmd.Transaction = transa��o;

                    try
                    {
                        Atualizar(cmd);

                        transa��o.Commit();
                    }
                    catch (Exception e)
                    {
                        transa��o.Rollback();

                        throw new Exception("N�o foi poss�vel concluir a atualiza��o!", e);
                    }
                }
            }
            finally
            {
                DesmarcarTransa��o();
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
                    IDbConnection conex�o;

                    if (!Cadastrado)
                        throw new Exce��es.EntidadeN�oCadastrada(this);

                    DispararAntesDeDescadastrar();

                    conex�o = Conex�o;

                    lock (conex�o)
                    {
                        try
                        {
                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                            using (cmd = conex�o.CreateCommand())
                            {
                                if (Transa��oSegura)
                                    DescadastrarTransa��o(conex�o, cmd);
                                else
                                    Descadastrar(cmd);
                            }
                        }
                        finally
                        {
                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                        }
                    }

                    cadastrado = atualizado = false;

                    Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Descadastrado));
                    DispararDepoisDeDescadastrar();
                }
			}
			catch (Exception e)
			{
				Console.WriteLine("Ocorreu um erro descadastrando um objeto {0} no banco de dados.", this.GetType().FullName);
				Console.WriteLine(e.ToString());
				Usu�rios.Usu�rioAtual.RegistrarErro(e);
				throw new Exception("Ocorreu um erro descadastrando um objeto do tipo " + GetType().FullName + ".\n" + cmd == null ? "" : cmd.CommandText, e);
			}
		}

        protected void DispararDepoisDeDescadastrar()
        {
            if (referentes != null)
            {
                foreach (DbManipula��o referente in referentes)
                    Cache.CacheDb.Inst�ncia.Remover(referente);

                referentes = null;
            }

            Cache.CacheDb.Inst�ncia.Remover(this);

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
                    throw new Exce��es.Opera��oCancelada(this);
            }
        }

		protected void DescadastrarTransa��o(IDbConnection conex�o, IDbCommand cmd)
		{
			IDbTransaction transa��o;

			MarcarTransa��o();

            try
            {
                using (transa��o = conex�o.BeginTransaction())
                {
                    cmd.Transaction = transa��o;

                    try
                    {
                        Descadastrar(cmd);

                        transa��o.Commit();
                    }
                    catch (Exception e)
                    {
                        transa��o.Rollback();
                        throw new Exception("N�o foi poss�vel concluir a transa��o.", e);
                    }
                }
            }
            finally
            {
                DesmarcarTransa��o();
            }
		}

		protected internal abstract void Descadastrar(IDbCommand cmd);

        public virtual bool Referente(DbManipula��o entidade)
        {
            return Equals(entidade);
        }

        protected void AtualizarEntidade(IDbCommand cmd, DbManipula��o entidade)
        {
            if (!Transacionando)
                throw new NotSupportedException("N�o � permitido o uso de compartilhamento de IDbCommand sem o uso do atributo \"DbTransa��o\".");

            entidade.MarcarTransa��o();

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
                entidade.DesmarcarTransa��o();
            }
        }

        protected void CadastrarEntidade(IDbCommand cmd, DbManipula��o entidade)
        {
            if (!Transacionando)
                throw new NotSupportedException("N�o � permitido o uso de compartilhamento de IDbCommand sem o uso do atributo \"DbTransa��o\".");

            entidade.MarcarTransa��o();

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
                entidade.DesmarcarTransa��o();
            }
        }

        protected void DescadastrarEntidade(IDbCommand cmd, DbManipula��o entidade)
        {
            if (!Transacionando)
                throw new NotSupportedException("N�o � permitido o uso de compartilhamento de IDbCommand sem o uso do atributo \"DbTransa��o\".");

            entidade.MarcarTransa��o();

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
                entidade.DesmarcarTransa��o();
            }
        }
    }
}
