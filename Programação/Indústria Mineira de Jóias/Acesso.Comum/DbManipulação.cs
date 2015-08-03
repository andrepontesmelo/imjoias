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
	/// Para criar uma transa��o em uma classe hier�rquica,
	/// (exemplo: Pessoa, PessoaF�sica e Representante),
	/// utilize o atributo <see cref="DbTransa��o"/> no in�cio da classe.
	/// 
	/// <seealso cref="DbTransa��o"/>
	/// </remarks>
	[Serializable]
	public abstract class DbManipula��o : DbManipula��oSimples
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
		/// Marca se objeto est� transacionando.
		/// </summary>
		[DbAtributo(TipoAtributo.Ignorar)]
		private bool transacionando = false;

        private List<DbManipula��o> referentes;

        /// <summary>
        /// Lista de entidades que referenciam esta.
        /// </summary>
        /// <remarks>
        /// Esta lista � utilizada para remover da cache outras
        /// entidades que podem ser afetadas por altera��o nesta.
        /// </remarks>
        internal List<DbManipula��o> Referentes
        {
            get
            {
                if (referentes == null)
                    referentes = new List<DbManipula��o>();
                return referentes;
            }
        }

        /// <summary>
        /// Determina se esta entidade possui outras que a referenciam.
        /// </summary>
        internal bool PossuiReferentes { get { return referentes != null; } }

        public delegate void DbManipula��oHandler(DbManipula��o entidade);
        public delegate void DbManipula��oCancel�velHandler(DbManipula��o entidade, out bool cancelar);

        /// <summary>
        /// Disparado sempre que atualizado for atribu�do
        /// com o valor falso.
        /// </summary>
        public event DbManipula��oHandler Alterado;

        /// <summary>
        /// Evento disparado antes de cadastrar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipula��oCancel�velHandler AntesDeCadastrar;

        /// <summary>
        /// Evento disparado antes de atualizar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipula��oCancel�velHandler AntesDeAtualizar;

        /// <summary>
        /// Evento disparado antes de remover entidade
        /// do banco de dados.
        /// </summary>
        public event DbManipula��oCancel�velHandler AntesDeDescadastrar;

        /// <summary>
        /// Evento disparado depois de cadastrar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipula��oHandler DepoisDeCadastrar;

        /// <summary>
        /// Evento disparado depois de atualizar entidade
        /// no banco de dados.
        /// </summary>
        public event DbManipula��oHandler DepoisDeAtualizar;

        /// <summary>
        /// Evento disparado depois de remover entidade
        /// do banco de dados.
        /// </summary>
        public event DbManipula��oHandler DepoisDeDescadastrar;

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

#region Manipula��o de dados (abstrato)

		/// <summary>
		/// Verifica se este objeto utiliza transa��o segura
		/// para cadastrar, atualizar e descadastrar.
		/// </summary>
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

		/// <summary>
		/// Verifica se o objeto est� transacionando.
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
		/// Marca in�cio de transa��o.
		/// </summary>
		/// <remarks>
		/// Considera que existe o atributo.
		/// </remarks>
		private void MarcarTransa��o()
		{
			transacionando = true;
		}

		/// <summary>
		/// Retirar marca da transa��o.
		/// </summary>
		/// <remarks>
		/// Considera que existe o atributo.
		/// </remarks>
		private void DesmarcarTransa��o()
		{
			transacionando = false;
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

                    // Efetuar cadastro.
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
				Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
				
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
            // Verificar se opera��o ser� cancelada pelo sistema.
            if (AntesDeCadastrar != null)
            {
                bool cancelar;

                AntesDeCadastrar(this, out cancelar);

                if (cancelar)
                    throw new Exce��es.Opera��oCancelada(this);
            }
        }

		/// <summary>
		/// Cadastra a entidade no banco de dados em uma
		/// transa��o segura.
		/// </summary>
		/// <param name="conex�o">Conex�o do banco de dados.</param>
		/// <param name="cmd">Comando da transa��o.</param>
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
		
		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		protected internal abstract void Cadastrar(IDbCommand cmd);

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador dever� atribuir o valor
		/// verdadeiro para o atributo "atualizado".
		/// </remarks>
		public virtual void Atualizar()
		{
            //try
            //{
				lock (this)
				{
					IDbConnection conex�o;
					IDbCommand    cmd;

					if (!Cadastrado)
						throw new Exce��es.EntidadeN�oCadastrada(this);

                    if (!Atualizado)
                    {
                        DispararAntesDeAtualizar();

                        // Efetuar atualiza��o.
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
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Ocorreu um erro atualizando um objeto {0} no banco de dados.", this.GetType().FullName);
            //    Console.WriteLine(e.ToString());
            //    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
            //    throw new Exception("Ocorreu um erro atualizando o objeto do tipo " + GetType().FullName, e);
            //}
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
            // Verificar se opera��o ser� cancelada pelo sistema.
            if (AntesDeAtualizar != null)
            {
                bool cancelar;

                AntesDeAtualizar(this, out cancelar);

                if (cancelar)
                    throw new Exce��es.Opera��oCancelada(this);
            }
        }

		/// <summary>
		/// Atualiza a entidade no banco de dados em uma
		/// transa��o segura.
		/// </summary>
		/// <param name="conex�o">Conex�o do banco de dados.</param>
		/// <param name="cmd">Comando da transa��o.</param>
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

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		protected internal abstract void Atualizar(IDbCommand cmd);

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		/// <remarks>
		/// O implementador dever� atribuir o valor
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
                    IDbConnection conex�o;

                    if (!Cadastrado)
                        throw new Exce��es.EntidadeN�oCadastrada(this);

                    DispararAntesDeDescadastrar();

                    // Efetuar descadastro.
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
				Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
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
            // Verificar se opera��o ser� cancelada pelo sistema.
            if (AntesDeDescadastrar != null)
            {
                bool cancelar;

                AntesDeDescadastrar(this, out cancelar);

                if (cancelar)
                    throw new Exce��es.Opera��oCancelada(this);
            }
        }

		/// <summary>
		/// Descadastra a entidade no banco de dados em uma
		/// transa��o segura.
		/// </summary>
		/// <param name="conex�o">Conex�o do banco de dados.</param>
		/// <param name="cmd">Comando da transa��o.</param>
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

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		protected internal abstract void Descadastrar(IDbCommand cmd);

		#endregion

        /// <summary>
        /// Verifica se uma entidade possuia a mesma refer�ncia
        /// (mesma chave prim�ria) que outra.
        /// </summary>
        public virtual bool Referente(DbManipula��o entidade)
        {
            return Equals(entidade);
        }

        /// <summary>
        /// Atualiza uma entidade utilizando um comando j� existente,
        /// recomendado em relacionamentos para opera��es com transa��o.
        /// </summary>
        /// <remarks>
        /// S� � poss�vel utilizar este comando em conjunto com o atributo
        /// Dbtransa��o.
        /// </remarks>
        protected void AtualizarEntidade(IDbCommand cmd, DbManipula��o entidade)
        {
            /* Necess�rio o uso de transa��o, caso contr�rio
             * objetos do tipo DbManipula��oAutom�tica n�o substituir�o
             * o comando.
             */
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

        /// <summary>
        /// Cadastra uma entidade utilizando um comando j� existente,
        /// recomendado em relacionamentos para opera��es com transa��o.
        /// </summary>
        /// <remarks>
        /// S� � poss�vel utilizar este comando em conjunto com o atributo
        /// Dbtransa��o.
        /// </remarks>
        protected void CadastrarEntidade(IDbCommand cmd, DbManipula��o entidade)
        {
            /* Necess�rio o uso de transa��o, caso contr�rio
             * objetos do tipo DbManipula��oAutom�tica n�o substituir�o
             * o comando.
             */
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

        /// <summary>
        /// Descadastra uma entidade utilizando um comando j� existente,
        /// recomendado em relacionamentos para opera��es com transa��o.
        /// </summary>
        /// <remarks>
        /// S� � poss�vel utilizar este comando em conjunto com o atributo
        /// Dbtransa��o.
        /// </remarks>
        protected void DescadastrarEntidade(IDbCommand cmd, DbManipula��o entidade)
        {
            /* Necess�rio o uso de transa��o, caso contr�rio
             * objetos do tipo DbManipula��oAutom�tica n�o substituir�o
             * o comando.
             */
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
