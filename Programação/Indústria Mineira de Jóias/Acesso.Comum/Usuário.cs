using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace Acesso.Comum
{
	/// <summary>
	/// Usu�rio para base das implementa��es espec�ficas
	/// de cliente do sistema.
	/// 
	/// Este objeto, por ser serializ�vel, n�o propaga
	/// altera��es quando recuperado do contexto do usu�rio.
	/// Assim, toda altera��o relevante e persistente em
	/// seus atributos deve chamar o m�todo AtualizarContexto.
	/// 
	/// ILogicalThreadAffinative serve para que os objetos
	/// do CallContext sejam transmitidos na chamada de 
	/// objeto-remoto.
	/// </summary>
	[Serializable]
	public class Usu�rio : System.Runtime.Remoting.Messaging.ILogicalThreadAffinative, IDisposable
	{
		#region Atributos

		/// <summary>
		/// Ancestral "Usu�rios"
		/// </summary>
		internal Usu�rios usu�rios;

        /// <summary>
        /// Usu�riod o banco de dados.
        /// </summary>
        private string nome;

		/// <summary>
		/// Chave de identifica��o no ancestral
		/// </summary>
		private Chave chave;

		/// <summary>
		/// Conex�o com o banco de dados a ser utilizado pelo usu�rio
		/// </summary>
        private Queue<Conex�oDbUsu�rio> conex�es = new Queue<Conex�oDbUsu�rio>();

		/// <summary>
		/// Controle de registro de conex�o remota
		/// </summary>
		private bool conex�oRemotaRegistrada = false;

        private GerenciadorConex�es gerenciadorConex�es;

		#endregion

        public Usu�rios Usu�rios
        {
            get { return usu�rios; }
        }

		/// <summary>
		/// Constr�i o usu�rio, conectando-se ao servidor
		/// </summary>
		public Usu�rio(Usu�rios pai, string usu�rio, string senha)
		{
            Acesso.Comum.Adaptadores.Conex�oConcorrente conex�o;

			if (pai == null)
				throw new ArgumentNullException("pai", "Pai de Usu�rio deve ser um objeto Usu�rios");

			usu�rios = pai;
            nome = usu�rio;

            gerenciadorConex�es = new GerenciadorConex�es(this, usu�rio, senha);
            gerenciadorConex�es.AtualizarContexto += new GerenciadorConex�es.AtualizarContextoCallback(AtualizarContexto);

            conex�o = gerenciadorConex�es.ObterConex�o();
            conex�o.AguardarAt� = DateTime.MinValue;

			if (conex�o.State != ConnectionState.Broken && conex�o.State != ConnectionState.Closed)
				Chave = new Chave(usu�rio, senha);

           
		}

		/// <summary>
		/// Atualiza dados do contexto atual.
		/// 
		/// Esta fun��o deve ser chamada toda vez que alguma mudan�a
		/// relevante � feita nos atributos do objeto, propagando,
		/// assim, os novos valores.
		/// 
		/// Caso ela n�o seja chamada, as mudan�as ser�o descartadas
		/// logo ap�s a utiliza��o da c�pia do objeto obtido.
		/// </summary>
		private void AtualizarContexto()
		{
            if (System.Runtime.Remoting.Messaging.CallContext.GetData("usu�rio") != null)
            {
                //Console.WriteLine("Atualizando contexto:");
                //Console.WriteLine("- Anterior: {0}", System.Runtime.Remoting.Messaging.CallContext.GetData("usu�rio").ToString());

                System.Runtime.Remoting.Messaging.CallContext.SetData("usu�rio", this);

                //Console.WriteLine("- Atual: {0}", System.Runtime.Remoting.Messaging.CallContext.GetData("usu�rio").ToString());
            }
            else // Objeto da Thread atual
                System.Threading.Thread.GetDomain().SetData("usu�rio", this);
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
		/// Conex�o com o banco de dados
		/// </summary>
		public IDbConnection Conex�o
		{
			get
			{
                IDbConnection conex�o;

                if (gerenciadorConex�es == null)
                    throw new Exception("Gerenciador de conex�es � nulo em Acesso.Como.Usu�rio.");

                conex�o = gerenciadorConex�es.ObterConex�o();
            
                // A conex�o pode ainda n�o estar registrada
                if (!conex�oRemotaRegistrada && System.Runtime.Remoting.RemotingServices.IsTransparentProxy(conex�o))
                {
                    conex�oRemotaRegistrada = true;

                    AtualizarContexto();
                }

                return conex�o;
            }
		}

        /// <summary>
        /// Gerenciador de conex�es do usu�rio.
        /// </summary>
        public GerenciadorConex�es GerenciadorConex�es
        {
            get { return gerenciadorConex�es; }
        }

		public override string ToString()
		{
			return "Usu�rio identificado: " + Nome;
		}

		/// <summary>
		/// Nome do usu�rio
		/// </summary>
		public string Nome
		{
			get { return nome; }
		}

        /// <summary>
        /// Constr�i um adaptador de banco de dados
        /// </summary>
        /// <returns>Adaptador</returns>
        public DbDataAdapter CriarAdaptadorDados(IDbConnection conex�o, string comando)
        {
            return usu�rios.CriarAdaptador(conex�o, comando);
        }

		/// <summary>
		/// Obt�m �ltimo c�digo do auto-increment.
		/// </summary>
		/// <returns>�ltimo c�digo inserido.</returns>
        [Obsolete("Favor utilizar Obter�ltimoC�digoInserido(conex�o)", true)]
        public static long Obter�ltimoC�digoInserido()
		{
            throw new NotSupportedException();
		}

        /// <summary>
        /// Obt�m �ltimo c�digo do auto-increment.
        /// </summary>
        /// <returns>�ltimo c�digo inserido.</returns>
        public long Obter�ltimoC�digoInserido(IDbConnection conex�o)
        {
            return usu�rios.Obter�ltimoC�digoInserido(conex�o);
        }
        
        /// <summary>
		/// Registra erro ocorrido no sistema com o usu�rio
		/// </summary>
		/// <param name="e">Erro ocorrido</param>
        public void RegistrarErro(Exception e)
        {
            IDbConnection conex�o = Conex�o;
            IDataReader leitor = null;
            usu�rios.DispararAoRegistrarErro(this, e);
            bool bugJaExistia = false;

            lock (conex�o)
            {
                GerenciadorConex�es.RemoverConex�o(conex�o);
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    IDbTransaction transa��o;

                    cmd.Transaction = transa��o = conex�o.BeginTransaction();

                    try
                    {
                        string cmdStr;

                        // Procurar pelo erro
                        cmd.CommandText = cmdStr = "SELECT codigo, ocorrencias FROM bug WHERE "
                            + "message = " + DbManipula��o.DbTransformar(e.Message) + " AND "
                            + "source = " + DbManipula��o.DbTransformar(e.Source) + " AND "
                            + "stackTrace = " + DbManipula��o.DbTransformar(e.StackTrace) + " AND "
                            + "targetSite " + (e.TargetSite != null ? "= " + DbManipula��o.DbTransformar(e.TargetSite.ToString()) : "IS NULL") + " AND "
                            + "innerException " + (e.InnerException != null ? "= " + DbManipula��o.DbTransformar(e.InnerException.ToString()) : "IS NULL");
                        //							+ " FOR UPDATE";

                        try {
                            using (leitor = cmd.ExecuteReader()) 
                            { 
                                // Verificar se erro j� existe
                                bugJaExistia = leitor.Read();
                                if (bugJaExistia)
                                {
                                    // Incrementar contador
                                    cmdStr = "UPDATE bug SET "
                                        + "ultimaData = " + DbManipula��o.DbTransformar(DateTime.Now)
                                        + ", stackTrace = " + DbManipula��o.DbTransformar(e.StackTrace)
                                        + ", ocorrencias = " + DbManipula��o.DbTransformar(Convert.ToInt64(leitor.GetValue(1)) + 1)
                                        + ", corrigido = 0"
                                        + ", innerException = " + (e.InnerException != null ? DbManipula��o.DbTransformar(e.InnerException.ToString()) : "NULL")
                                        + " WHERE codigo = " + DbManipula��o.DbTransformar(Convert.ToInt64(leitor.GetValue(0)));
                            
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
                                + " VALUES (" + DbManipula��o.DbTransformar(DateTime.Now) + ", "
                                + DbManipula��o.DbTransformar(DateTime.Now) + ", "
                                + DbManipula��o.DbTransformar(e.Message) + ", "
                                + DbManipula��o.DbTransformar(e.Source) + ", "
                                + DbManipula��o.DbTransformar(e.StackTrace) + ", "
                                + DbManipula��o.DbTransformar(e.TargetSite) + ", "
                                + "1, "
                                + (e.InnerException != null ? DbManipula��o.DbTransformar(e.InnerException.ToString()) : "NULL")
                                + ")";

                            cmd.ExecuteNonQuery();
                        }

                        transa��o.Commit();
          
                    }
                    catch
                    {
                        transa��o.Rollback();
                    }
                    finally
                    {
                        GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }
        }

        /// <summary>
        /// Notifica a��o sobre entidade.
        /// </summary>
        /// <param name="tipo">Tipo da entidade.</param>
        /// <param name="dados">Dados da a��o e da entidade.</param>
        internal void NotificarDbA��o(Type tipo, Acompanhamento.DbA��oDados dados)
        {
            usu�rios.NotificarDbA��o(tipo, dados);
        }
        
        public void Dispose()
        {
            foreach (Conex�oDbUsu�rio cUsr in conex�es)
            {
                cUsr.Conex�o.Close();
                cUsr.Conex�o.Dispose();
                cUsr.Dispose();
            }
        }

        public static implicit operator string(Usu�rio usu�rio)
        {
            return usu�rio.Nome;
        }
    }
}
