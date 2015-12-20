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
	/// Lista de usu�rios
	/// </summary>
	public abstract class Usu�rios // : ContextBoundObject
	{
		// Atributos
		private Dictionary<Chave, Usu�rio> usu�rios;

		// Delega��es
		public delegate void Usu�rioHandler(Usu�rio usu�rio);
        public delegate void ErroUsu�rioHandler(Usu�rio usu�rio, Exception e);

		// Eventos
		public event Usu�rioHandler AoEfetuarLogin;
		public event Usu�rioHandler AoEfetuarLogoff;

        /// <summary>
        /// Evento disparado quando uma conex�o com o banco de dados
        /// � estabelecida.
        /// </summary>
        /// <remarks>
        /// No primeiro disparo do evento, a propriedade usu�rio.GerenciadorConex�es
        /// � nula, visto que � chamada na construtora deste objeto.
        /// </remarks>
        public event Usu�rioHandler AoCriarConex�o;
        public event DbA��oHandler AoManipularDb;
        public event ErroUsu�rioHandler AoRegistrarErro;

		/// <summary>
		/// Controle de usu�rios
		/// </summary>
		public Usu�rios()
		{
			usu�rios = new Dictionary<Chave,Usu�rio>();
		}

		/// <summary>
		/// Efetua login de usu�rio no banco de dados
		/// </summary>
		public Usu�rio EfetuarLogin(string nomeUsu�rio, string senha)
		{
			Usu�rio usu�rio;
			usu�rio = ConstruirUsu�rio(nomeUsu�rio, senha);
			if (usu�rio == null)
				throw new NullReferenceException("Usu�rio constru�do � nulo");

			usu�rios[usu�rio.Chave] = usu�rio;

			CallContext.SetData("usu�rio", usu�rio);
	
			if (AoEfetuarLogin != null)
				AoEfetuarLogin(usu�rio);

			return usu�rio;
		}

		/// <summary>
		/// Efetua logoff de usu�rio
		/// </summary>
		public void EfetuarLogoff(Usu�rio usu�rio)
		{
			usu�rios.Remove(usu�rio.Chave);

			try
			{
				if (usu�rio.Conex�o.State != ConnectionState.Closed)
					usu�rio.Conex�o.Close();
			}
			finally
			{
				// CallContext.FreeNamedDataSlot("usu�rio");

				if (AoEfetuarLogoff != null)
					AoEfetuarLogoff(usu�rio);

                usu�rio.Dispose();

				GC.Collect();
			}
		}

		/// <summary>
		/// Constr�i objeto usu�rio
		/// </summary>
		/// <returns>Objeto constru�do</returns>
		protected abstract Usu�rio ConstruirUsu�rio(string usu�rio, string senha);

		/// <summary>
		/// Consulta no banco de dados, retornando bytes.
		/// Este m�todo � utilizado somente devido ao bug
		/// do ByteFX 0.76, e dever� ser removido logo
		/// que o bug de leitura de MEDIUMBLOB for solucionado.
		/// 
		/// Esta fun��o foi alocada em usu�rio para que
		/// a fun��o GetBytes seja executa em contexto local
		/// e n�o remoto. Quando executado em remoto,
		/// a passagem de refer�ncia de um objeto
		/// n�o passado por refer�ncia faz com que
		/// o resultado n�o seja passado pelo proxy.
		/// 
		/// Al�m desta fun��o, remover a equivalente em DbManipula��o.
		/// </summary>
		/// <param name="comando">Consulta SQL</param>
		/// <param name="bufLen">Tamanho do buffer</param>
		/// <returns>Dados lidos</returns>
		[Obsolete]
		public static byte [] ConsultarBytes(System.Data.IDbConnection conex�o, string comando, int bufLen)
		{
			byte [] dados = new byte[bufLen];
            IDataReader leitor = null;

			using (IDbCommand cmd = conex�o.CreateCommand())
			{
				cmd.CommandText = comando;

				lock (conex�o)
				{
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
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

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
				}
			}

			return dados;
		}

		/// <summary>
		/// Usu�rio atual.
		/// </summary>
		/// 
		/// <remarks>
		/// N�o ser� poss�vel recuperar o usu�rio atual caso o m�todo de
		/// origem seja chamado remotamente.
		/// </remarks>
		public static Usu�rio Usu�rioAtual
		{
			get
			{
				object obj;
				
				// Objeto do contexto
				obj = System.Runtime.Remoting.Messaging.CallContext.GetData("usu�rio");

				// Objeto da Thread atual
				if (obj == null)
				{
//					obj = System.Threading.Thread.GetDomain().GetData("usu�rio");

//					if (obj == null)
						obj = System.AppDomain.CurrentDomain.GetData("usu�rio");
				}

//#if DEBUG
//                Console.WriteLine("Usu�rio atual = {0}", obj.ToString());
//#endif

				if (obj == null)
					return usu�rioAtual;

				return obj as Usu�rio;
			}
			set
			{
				usu�rioAtual = value;
			}
		}

		private static Usu�rio usu�rioAtual = null;

		/// <summary>
		/// Conecta ao servidor de banco de dados
		/// </summary>
		/// <returns>Conex�o com o banco de dados</returns>
		/// <remarks>
		/// Antes estava marcado como protected internal, por�m
		/// na hora de reconstruir a conex�o (em caso de desconex�o),
		/// o objeto Usu�rio requer a utiliza��o do m�todo p�blico e
		/// externo, como no caso do MySQLUsu�rio.
		/// -- J�lio, 17 de novembro de 2004
		/// </remarks>
		public abstract IDbConnection Conectar(string usu�rio, string senha);

		/// <summary>
		/// Constr�i adaptador para conex�o
		/// </summary>
		/// <param name="conex�o">Conex�o</param>
		/// <returns>Adaptador</returns>
		protected internal abstract DbDataAdapter CriarAdaptador(IDbConnection conex�o, string comando);

		/// <summary>
		/// Obt�m �ltimo c�digo do auto-increment.
		/// </summary>
		/// <param name="conex�o">Conex�o.</param>
		/// <returns>�ltimo c�digo inserido.</returns>
		public abstract long Obter�ltimoC�digoInserido(IDbConnection conex�o);

        ///// <summary>
        ///// Tornar objeto remoto eterno
        ///// </summary>
        //public override object InitializeLifetimeService()
        //{
        //    return null;
        //}

		/// <summary>
		/// Usu�rio que possui chave espec�fica.
		/// </summary>
		public Usu�rio this[Chave chave]
		{
			get
			{
				string bla = this.ToString();

				return usu�rios[chave];
			}
		}

        /// <summary>
        /// Notifica a��o sobre entidade.
        /// </summary>
        /// <param name="tipo">Tipo da entidade.</param>
        /// <param name="dados">Dados da a��o e da entidade.</param>
        public void NotificarDbA��o(Type tipo, DbA��oDados dados)
        {
            if (AoManipularDb != null)
                AoManipularDb(tipo, dados);
        }

        /// <summary>
        /// Dispara evento ao criar conex�o.
        /// </summary>
        /// <param name="usu�rio">Usu�rio que criou a conex�o.</param>
        internal void DispararAoCriarConex�o(Usu�rio usu�rio)
        {
            if (AoCriarConex�o != null)
                AoCriarConex�o(usu�rio);
        }

        /// <summary>
        /// Dispara evento ao registrar um erro.
        /// </summary>
        /// <param name="usu�rio">Usu�rio que registrou o erro.</param>
        /// <param name="e">Exce��o levantada pelo usu�rio.</param>
        internal void DispararAoRegistrarErro(Usu�rio usu�rio, Exception e)
        {
            if (AoRegistrarErro != null)
                AoRegistrarErro(usu�rio, e);
        }
    }
}
