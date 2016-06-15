using Acesso.Comum.Acompanhamento;
using Acesso.Comum.Mapeamento;
using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum
{
    [Serializable]
	public abstract class DbManipulaçãoAutomática : DbManipulação
	{
        private InfoManipulação infoManipulação;

        internal InfoManipulação InfoManipulação
        {
            get { return infoManipulação; }
        }

        public DbManipulaçãoAutomática()
        {
            infoManipulação = InfoManipulação.ObterManipulação(GetType());
        }

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
                    }
                }

                atualizado = cadastrado = true;

                Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Cadastrado));
                DispararDepoisDeCadastrar();
            }
		}

		protected internal override void Cadastrar(System.Data.IDbCommand cmd)
		{
            if (Transacionando || cmd.Transaction != null)
            {
                InfoManipulaçãoConexão info;
                IDbCommand molde;

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

			FieldInfo [] vetorAutoIncremento = infoManipulação.AutoIncremento;

			if (vetorAutoIncremento.Length == 1)
				vetorAutoIncremento[0].SetValue(this, Convert.ChangeType(ObterÚltimoCódigoInserido(cmd.Connection), vetorAutoIncremento[0].FieldType));
			
			else if (vetorAutoIncremento.Length > 1)
				throw new NotSupportedException("Existe mais de um valor auto-incrementado. Não é possível cadastrar automaticamente e atribuir valores auto-incrementados ao objeto.");

            DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

            foreach (DbManipulação relacionamento in relacionamentos)
                if (relacionamento != null)
                    CadastrarEntidade(cmd, relacionamento);
		}

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
                        }
                    }

                    atualizado = true;

                    Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Atualizado));
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
                    DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

                    foreach (DbManipulação relacionamento in relacionamentos)
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
                    InfoManipulaçãoConexão info;
                    IDbCommand molde;

                    info = ObterInfoManipulação(cmd.Connection);
                    molde = info.PrepararAtualização(this);

                    CopiarMoldeComando(molde, cmd);
                }

                cmd.ExecuteNonQuery();
            }

            DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

            foreach (DbManipulação relacionamento in relacionamentos)
                if (relacionamento != null)
                    AtualizarEntidade(cmd, relacionamento);
		}

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
                    }
                }

				cadastrado = atualizado = false;

                Usuários.UsuárioAtual.NotificarDbAção(GetType(), new DbAçãoDados(this, DbAção.Descadastrado));
                DispararDepoisDeDescadastrar();
			}
		}

		protected internal override void Descadastrar(System.Data.IDbCommand cmd)
		{
            DbManipulação[] relacionamentos = infoManipulação.ObterRelacionamentosInvertidos(this);

            foreach (DbManipulação relacionamento in relacionamentos)
                if (relacionamento != null)
                    DescadastrarEntidade(cmd, relacionamento);

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

        public override bool Referente(DbManipulação entidade)
        {
            if (this.GetType() != entidade.GetType())
                return false;

            bool referente = true;

            foreach (FieldInfo campo in infoManipulação.ChavePrimária)
                referente &= campo.GetValue(this).Equals(campo.GetValue(entidade));

            return referente;
        }

        protected string Tabela
        {
            get
            {
                return infoManipulação.Tabela;
            }
        }

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
