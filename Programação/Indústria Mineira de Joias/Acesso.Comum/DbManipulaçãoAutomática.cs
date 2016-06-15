using Acesso.Comum.Acompanhamento;
using Acesso.Comum.Mapeamento;
using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum
{
    [Serializable]
	public abstract class DbManipula��oAutom�tica : DbManipula��o
	{
        private InfoManipula��o infoManipula��o;

        internal InfoManipula��o InfoManipula��o
        {
            get { return infoManipula��o; }
        }

        public DbManipula��oAutom�tica()
        {
            infoManipula��o = InfoManipula��o.ObterManipula��o(GetType());
        }

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
                    }
                }

                atualizado = cadastrado = true;

                Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Cadastrado));
                DispararDepoisDeCadastrar();
            }
		}

		protected internal override void Cadastrar(System.Data.IDbCommand cmd)
		{
            if (Transacionando || cmd.Transaction != null)
            {
                InfoManipula��oConex�o info;
                IDbCommand molde;

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

			FieldInfo [] vetorAutoIncremento = infoManipula��o.AutoIncremento;

			if (vetorAutoIncremento.Length == 1)
				vetorAutoIncremento[0].SetValue(this, Convert.ChangeType(Obter�ltimoC�digoInserido(cmd.Connection), vetorAutoIncremento[0].FieldType));
			
			else if (vetorAutoIncremento.Length > 1)
				throw new NotSupportedException("Existe mais de um valor auto-incrementado. N�o � poss�vel cadastrar automaticamente e atribuir valores auto-incrementados ao objeto.");

            DbManipula��o[] relacionamentos = infoManipula��o.ObterRelacionamentosInvertidos(this);

            foreach (DbManipula��o relacionamento in relacionamentos)
                if (relacionamento != null)
                    CadastrarEntidade(cmd, relacionamento);
		}

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
                        }
                    }

                    atualizado = true;

                    Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Atualizado));
                    DispararDepoisDeAtualizar();
                }
            }
        }

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

        protected internal override void Atualizar(System.Data.IDbCommand cmd)
		{
            if (!atualizado)
            {
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

            DbManipula��o[] relacionamentos = infoManipula��o.ObterRelacionamentosInvertidos(this);

            foreach (DbManipula��o relacionamento in relacionamentos)
                if (relacionamento != null)
                    AtualizarEntidade(cmd, relacionamento);
		}

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
                    }
                }

				cadastrado = atualizado = false;

                Usu�rios.Usu�rioAtual.NotificarDbA��o(GetType(), new DbA��oDados(this, DbA��o.Descadastrado));
                DispararDepoisDeDescadastrar();
			}
		}

		protected internal override void Descadastrar(System.Data.IDbCommand cmd)
		{
            DbManipula��o[] relacionamentos = infoManipula��o.ObterRelacionamentosInvertidos(this);

            foreach (DbManipula��o relacionamento in relacionamentos)
                if (relacionamento != null)
                    DescadastrarEntidade(cmd, relacionamento);

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

        public override bool Referente(DbManipula��o entidade)
        {
            if (this.GetType() != entidade.GetType())
                return false;

            bool referente = true;

            foreach (FieldInfo campo in infoManipula��o.ChavePrim�ria)
                referente &= campo.GetValue(this).Equals(campo.GetValue(entidade));

            return referente;
        }

        protected string Tabela
        {
            get
            {
                return infoManipula��o.Tabela;
            }
        }

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
