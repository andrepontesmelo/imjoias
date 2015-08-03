using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace Acesso.Comum
{
	/// <summary>
	/// Usuário para base das implementações específicas
	/// de cliente do sistema.
	/// 
	/// Este objeto, por ser serializável, não propaga
	/// alterações quando recuperado do contexto do usuário.
	/// Assim, toda alteração relevante e persistente em
	/// seus atributos deve chamar o método AtualizarContexto.
	/// 
	/// ILogicalThreadAffinative serve para que os objetos
	/// do CallContext sejam transmitidos na chamada de 
	/// objeto-remoto.
	/// </summary>
	[Serializable]
	public class Usuário : System.Runtime.Remoting.Messaging.ILogicalThreadAffinative, IDisposable
	{
		#region Atributos

		/// <summary>
		/// Ancestral "Usuários"
		/// </summary>
		internal Usuários usuários;

        /// <summary>
        /// Usuáriod o banco de dados.
        /// </summary>
        private string nome;

		/// <summary>
		/// Chave de identificação no ancestral
		/// </summary>
		private Chave chave;

		/// <summary>
		/// Conexão com o banco de dados a ser utilizado pelo usuário
		/// </summary>
        private Queue<ConexãoDbUsuário> conexões = new Queue<ConexãoDbUsuário>();

		/// <summary>
		/// Controle de registro de conexão remota
		/// </summary>
		private bool conexãoRemotaRegistrada = false;

        private GerenciadorConexões gerenciadorConexões;

		#endregion

        public Usuários Usuários
        {
            get { return usuários; }
        }

		/// <summary>
		/// Constrói o usuário, conectando-se ao servidor
		/// </summary>
		public Usuário(Usuários pai, string usuário, string senha)
		{
            Acesso.Comum.Adaptadores.ConexãoConcorrente conexão;

			if (pai == null)
				throw new ArgumentNullException("pai", "Pai de Usuário deve ser um objeto Usuários");

			usuários = pai;
            nome = usuário;

            gerenciadorConexões = new GerenciadorConexões(this, usuário, senha);
            gerenciadorConexões.AtualizarContexto += new GerenciadorConexões.AtualizarContextoCallback(AtualizarContexto);

            conexão = gerenciadorConexões.ObterConexão();
            conexão.AguardarAté = DateTime.MinValue;

			if (conexão.State != ConnectionState.Broken && conexão.State != ConnectionState.Closed)
				Chave = new Chave(usuário, senha);

           
		}

		/// <summary>
		/// Atualiza dados do contexto atual.
		/// 
		/// Esta função deve ser chamada toda vez que alguma mudança
		/// relevante é feita nos atributos do objeto, propagando,
		/// assim, os novos valores.
		/// 
		/// Caso ela não seja chamada, as mudanças serão descartadas
		/// logo após a utilização da cópia do objeto obtido.
		/// </summary>
		private void AtualizarContexto()
		{
            if (System.Runtime.Remoting.Messaging.CallContext.GetData("usuário") != null)
            {
                //Console.WriteLine("Atualizando contexto:");
                //Console.WriteLine("- Anterior: {0}", System.Runtime.Remoting.Messaging.CallContext.GetData("usuário").ToString());

                System.Runtime.Remoting.Messaging.CallContext.SetData("usuário", this);

                //Console.WriteLine("- Atual: {0}", System.Runtime.Remoting.Messaging.CallContext.GetData("usuário").ToString());
            }
            else // Objeto da Thread atual
                System.Threading.Thread.GetDomain().SetData("usuário", this);
		}

		/// <summary>
		/// Chave de acesso
		/// </summary>
		public Chave Chave
		{
			get
			{
				return chave;
			}
			set
			{
				chave = value;
			}
		}			

		/// <summary>
		/// Conexão com o banco de dados
		/// </summary>
		public IDbConnection Conexão
		{
			get
			{
                IDbConnection conexão;

                if (gerenciadorConexões == null)
                    throw new Exception("Gerenciador de conexões é nulo em Acesso.Como.Usuário.");

                conexão = gerenciadorConexões.ObterConexão();
            
                // A conexão pode ainda não estar registrada
                if (!conexãoRemotaRegistrada && System.Runtime.Remoting.RemotingServices.IsTransparentProxy(conexão))
                {
                    conexãoRemotaRegistrada = true;

                    AtualizarContexto();
                }

                return conexão;
            }
		}

        /// <summary>
        /// Gerenciador de conexões do usuário.
        /// </summary>
        public GerenciadorConexões GerenciadorConexões
        {
            get { return gerenciadorConexões; }
        }

		public override string ToString()
		{
			return "Usuário identificado: " + Nome;
		}

		/// <summary>
		/// Nome do usuário
		/// </summary>
		public string Nome
		{
			get { return nome; }
		}

        /// <summary>
        /// Constrói um adaptador de banco de dados
        /// </summary>
        /// <returns>Adaptador</returns>
        public DbDataAdapter CriarAdaptadorDados(IDbConnection conexão, string comando)
        {
            return usuários.CriarAdaptador(conexão, comando);
        }

		/// <summary>
		/// Obtém último código do auto-increment.
		/// </summary>
		/// <returns>Último código inserido.</returns>
        [Obsolete("Favor utilizar ObterÚltimoCódigoInserido(conexão)", true)]
        public static long ObterÚltimoCódigoInserido()
		{
            throw new NotSupportedException();
		}

        /// <summary>
        /// Obtém último código do auto-increment.
        /// </summary>
        /// <returns>Último código inserido.</returns>
        public long ObterÚltimoCódigoInserido(IDbConnection conexão)
        {
            return usuários.ObterÚltimoCódigoInserido(conexão);
        }
        
        /// <summary>
		/// Registra erro ocorrido no sistema com o usuário
		/// </summary>
		/// <param name="e">Erro ocorrido</param>
        public void RegistrarErro(Exception e)
        {
            IDbConnection conexão = Conexão;
            IDataReader leitor = null;
            usuários.DispararAoRegistrarErro(this, e);
            bool bugJaExistia = false;

            lock (conexão)
            {
                GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    IDbTransaction transação;

                    cmd.Transaction = transação = conexão.BeginTransaction();

                    try
                    {
                        string cmdStr;

                        // Procurar pelo erro
                        cmd.CommandText = cmdStr = "SELECT codigo, ocorrencias FROM bug WHERE "
                            + "message = " + DbManipulação.DbTransformar(e.Message) + " AND "
                            + "source = " + DbManipulação.DbTransformar(e.Source) + " AND "
                            + "stackTrace = " + DbManipulação.DbTransformar(e.StackTrace) + " AND "
                            + "targetSite " + (e.TargetSite != null ? "= " + DbManipulação.DbTransformar(e.TargetSite.ToString()) : "IS NULL") + " AND "
                            + "innerException " + (e.InnerException != null ? "= " + DbManipulação.DbTransformar(e.InnerException.ToString()) : "IS NULL");
                        //							+ " FOR UPDATE";

                        try {
                            using (leitor = cmd.ExecuteReader()) 
                            { 
                                // Verificar se erro já existe
                                bugJaExistia = leitor.Read();
                                if (bugJaExistia)
                                {
                                    // Incrementar contador
                                    cmdStr = "UPDATE bug SET "
                                        + "ultimaData = " + DbManipulação.DbTransformar(DateTime.Now)
                                        + ", stackTrace = " + DbManipulação.DbTransformar(e.StackTrace)
                                        + ", ocorrencias = " + DbManipulação.DbTransformar(Convert.ToInt64(leitor.GetValue(1)) + 1)
                                        + ", corrigido = 0"
                                        + ", innerException = " + (e.InnerException != null ? DbManipulação.DbTransformar(e.InnerException.ToString()) : "NULL")
                                        + " WHERE codigo = " + DbManipulação.DbTransformar(Convert.ToInt64(leitor.GetValue(0)));
                            
                                    cmd.CommandText = cmdStr;
                                    cmd.ExecuteNonQuery();
                                } 
                            }
                        } finally 
                        {
                            if (leitor != null)
                                leitor.Close();
                        }

                        if (!bugJaExistia)
                        {
                            // Inserir nova entrada
                            cmd.CommandText = cmdStr = "INSERT INTO bug (primeiraData, ultimaData, message, source, stacktrace, targetsite, ocorrencias, innerException)"
                                + " VALUES (" + DbManipulação.DbTransformar(DateTime.Now) + ", "
                                + DbManipulação.DbTransformar(DateTime.Now) + ", "
                                + DbManipulação.DbTransformar(e.Message) + ", "
                                + DbManipulação.DbTransformar(e.Source) + ", "
                                + DbManipulação.DbTransformar(e.StackTrace) + ", "
                                + DbManipulação.DbTransformar(e.TargetSite) + ", "
                                + "1, "
                                + (e.InnerException != null ? DbManipulação.DbTransformar(e.InnerException.ToString()) : "NULL")
                                + ")";

                            cmd.ExecuteNonQuery();
                        }

                        transação.Commit();
          
                    }
                    catch
                    {
                        transação.Rollback();
                    }
                    finally
                    {
                        GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
        }

        /// <summary>
        /// Notifica ação sobre entidade.
        /// </summary>
        /// <param name="tipo">Tipo da entidade.</param>
        /// <param name="dados">Dados da ação e da entidade.</param>
        internal void NotificarDbAção(Type tipo, Acompanhamento.DbAçãoDados dados)
        {
            usuários.NotificarDbAção(tipo, dados);
        }
        
        public void Dispose()
        {
            foreach (ConexãoDbUsuário cUsr in conexões)
            {
                cUsr.Conexão.Close();
                cUsr.Conexão.Dispose();
                cUsr.Dispose();
            }
        }

        public static implicit operator string(Usuário usuário)
        {
            return usuário.Nome;
        }
    }
}
