using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Data;
using System.Data.Common;

using Acesso.Comum.Acompanhamento;
using System.Collections.Generic;

namespace Acesso.Comum
{
	/// <summary>
	/// Lista de usuários
	/// </summary>
	public abstract class Usuários // : ContextBoundObject
	{
		// Atributos
		private Dictionary<Chave, Usuário> usuários;

		// Delegações
		public delegate void UsuárioHandler(Usuário usuário);
        public delegate void ErroUsuárioHandler(Usuário usuário, Exception e);

		// Eventos
		public event UsuárioHandler AoEfetuarLogin;
		public event UsuárioHandler AoEfetuarLogoff;

        /// <summary>
        /// Evento disparado quando uma conexão com o banco de dados
        /// é estabelecida.
        /// </summary>
        /// <remarks>
        /// No primeiro disparo do evento, a propriedade usuário.GerenciadorConexões
        /// é nula, visto que é chamada na construtora deste objeto.
        /// </remarks>
        public event UsuárioHandler AoCriarConexão;
        public event DbAçãoHandler AoManipularDb;
        public event ErroUsuárioHandler AoRegistrarErro;

		/// <summary>
		/// Controle de usuários
		/// </summary>
		public Usuários()
		{
			usuários = new Dictionary<Chave,Usuário>();
		}

		/// <summary>
		/// Efetua login de usuário no banco de dados
		/// </summary>
		public Usuário EfetuarLogin(string nomeUsuário, string senha)
		{
			Usuário usuário;
			usuário = ConstruirUsuário(nomeUsuário, senha);
			if (usuário == null)
				throw new NullReferenceException("Usuário construído é nulo");

			usuários[usuário.Chave] = usuário;

			CallContext.SetData("usuário", usuário);
	
			if (AoEfetuarLogin != null)
				AoEfetuarLogin(usuário);

			return usuário;
		}

		/// <summary>
		/// Efetua logoff de usuário
		/// </summary>
		public void EfetuarLogoff(Usuário usuário)
		{
			usuários.Remove(usuário.Chave);

			try
			{
				if (usuário.Conexão.State != ConnectionState.Closed)
					usuário.Conexão.Close();
			}
			finally
			{
				// CallContext.FreeNamedDataSlot("usuário");

				if (AoEfetuarLogoff != null)
					AoEfetuarLogoff(usuário);

                usuário.Dispose();

				GC.Collect();
			}
		}

		/// <summary>
		/// Constrói objeto usuário
		/// </summary>
		/// <returns>Objeto construído</returns>
		protected abstract Usuário ConstruirUsuário(string usuário, string senha);

		/// <summary>
		/// Consulta no banco de dados, retornando bytes.
		/// Este método é utilizado somente devido ao bug
		/// do ByteFX 0.76, e deverá ser removido logo
		/// que o bug de leitura de MEDIUMBLOB for solucionado.
		/// 
		/// Esta função foi alocada em usuário para que
		/// a função GetBytes seja executa em contexto local
		/// e não remoto. Quando executado em remoto,
		/// a passagem de referência de um objeto
		/// não passado por referência faz com que
		/// o resultado não seja passado pelo proxy.
		/// 
		/// Além desta função, remover a equivalente em DbManipulação.
		/// </summary>
		/// <param name="comando">Consulta SQL</param>
		/// <param name="bufLen">Tamanho do buffer</param>
		/// <returns>Dados lidos</returns>
		[Obsolete]
		public static byte [] ConsultarBytes(System.Data.IDbConnection conexão, string comando, int bufLen)
		{
			byte [] dados = new byte[bufLen];
            IDataReader leitor = null;

			using (IDbCommand cmd = conexão.CreateCommand())
			{
				cmd.CommandText = comando;

				lock (conexão)
				{
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            leitor.Read();
                            leitor.GetBytes(0, 0, dados, 0, bufLen);
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
				}
			}

			return dados;
		}

		/// <summary>
		/// Usuário atual.
		/// </summary>
		/// 
		/// <remarks>
		/// Não será possível recuperar o usuário atual caso o método de
		/// origem seja chamado remotamente.
		/// </remarks>
		public static Usuário UsuárioAtual
		{
			get
			{
				object obj;
				
				// Objeto do contexto
				obj = System.Runtime.Remoting.Messaging.CallContext.GetData("usuário");

				// Objeto da Thread atual
				if (obj == null)
				{
//					obj = System.Threading.Thread.GetDomain().GetData("usuário");

//					if (obj == null)
						obj = System.AppDomain.CurrentDomain.GetData("usuário");
				}

//#if DEBUG
//                Console.WriteLine("Usuário atual = {0}", obj.ToString());
//#endif

				if (obj == null)
					return usuárioAtual;

				return obj as Usuário;
			}
			set
			{
				usuárioAtual = value;
			}
		}

		private static Usuário usuárioAtual = null;

		/// <summary>
		/// Conecta ao servidor de banco de dados
		/// </summary>
		/// <returns>Conexão com o banco de dados</returns>
		/// <remarks>
		/// Antes estava marcado como protected internal, porém
		/// na hora de reconstruir a conexão (em caso de desconexão),
		/// o objeto Usuário requer a utilização do método público e
		/// externo, como no caso do MySQLUsuário.
		/// -- Júlio, 17 de novembro de 2004
		/// </remarks>
		public abstract IDbConnection Conectar(string usuário, string senha);

		/// <summary>
		/// Constrói adaptador para conexão
		/// </summary>
		/// <param name="conexão">Conexão</param>
		/// <returns>Adaptador</returns>
		protected internal abstract DbDataAdapter CriarAdaptador(IDbConnection conexão, string comando);

		/// <summary>
		/// Obtém último código do auto-increment.
		/// </summary>
		/// <param name="conexão">Conexão.</param>
		/// <returns>Último código inserido.</returns>
		public abstract long ObterÚltimoCódigoInserido(IDbConnection conexão);

        ///// <summary>
        ///// Tornar objeto remoto eterno
        ///// </summary>
        //public override object InitializeLifetimeService()
        //{
        //    return null;
        //}

		/// <summary>
		/// Usuário que possui chave específica.
		/// </summary>
		public Usuário this[Chave chave]
		{
			get
			{
				string bla = this.ToString();

				return usuários[chave];
			}
		}

        /// <summary>
        /// Notifica ação sobre entidade.
        /// </summary>
        /// <param name="tipo">Tipo da entidade.</param>
        /// <param name="dados">Dados da ação e da entidade.</param>
        public void NotificarDbAção(Type tipo, DbAçãoDados dados)
        {
            if (AoManipularDb != null)
                AoManipularDb(tipo, dados);
        }

        /// <summary>
        /// Dispara evento ao criar conexão.
        /// </summary>
        /// <param name="usuário">Usuário que criou a conexão.</param>
        internal void DispararAoCriarConexão(Usuário usuário)
        {
            if (AoCriarConexão != null)
                AoCriarConexão(usuário);
        }

        /// <summary>
        /// Dispara evento ao registrar um erro.
        /// </summary>
        /// <param name="usuário">Usuário que registrou o erro.</param>
        /// <param name="e">Exceção levantada pelo usuário.</param>
        internal void DispararAoRegistrarErro(Usuário usuário, Exception e)
        {
            if (AoRegistrarErro != null)
                AoRegistrarErro(usuário, e);
        }
    }
}
