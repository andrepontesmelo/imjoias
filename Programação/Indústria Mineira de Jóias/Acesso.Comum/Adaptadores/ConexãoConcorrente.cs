using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Acesso.Comum.Adaptadores
{
    /// <summary>
    /// Adaptador para controlar conexões em segmentos
    /// concorrentes. Com este adaptador, é possível verificar
    /// quando um DataReader está em execução na conexão.
    /// </summary>
    [Serializable]
    public class ConexãoConcorrente : IDbConnection
    {
        private IDbConnection conexão;
#if !DEBUG
        public volatile int Ocupado = 0;
#else
        private volatile int debug_ocupado = 0;
        //private string debug_últimaOcupante = null;
        private Stack<string> debug_ocupantes = new Stack<string>();

        public int Ocupado
        {
            get { return debug_ocupado; }
            set
            {
                lock (conexão)
                {
//                    System.Diagnostics.Debug.Assert(value < 3 && value >= 0, "Valor desproporcional para ocupação de conexão.\n\nAo recuperar a entidade, o IDbCommand e o IDataReader foram liberados?");
                    System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);

                    string arq = "N/D";

                    foreach (System.Diagnostics.StackFrame frame in st.GetFrames())
                    {
                        arq = frame.GetFileName();

                        if (arq != null && !arq.EndsWith("ConexãoConcorrente.cs") &&
                            !arq.EndsWith("DbManipulação.cs") &&
                            !arq.EndsWith("DbManipulaçãoSimples.cs") &&
                            !arq.EndsWith("DbManipulaçãoAutomática.cs") &&
                            !arq.EndsWith("InfoManipulação.cs") &&
                            !arq.EndsWith("ComandoConcorrente.cs") &&
                            !arq.EndsWith("LeitorConcorrente.cs") &&
                            !arq.EndsWith("MySQLUsuários.cs") &&
                            !arq.EndsWith("Usuário.cs"))
                        {
                            arq += ":" + frame.GetFileLineNumber();
                            break;
                        }
                    }

                    if (value > debug_ocupado)
                    {
                        //debug_últimaOcupante = st.ToString();
                        debug_ocupantes.Push(arq);
                    }
                    else if (value < debug_ocupado)
                    {
                        string a1, a2;

                        if (arq != null && debug_ocupantes.Count > 0)
                        {
                            a1 = arq.Split(':')[0];
                            a2 = debug_ocupantes.Peek().Split(':')[0];

                            System.Diagnostics.Debug.Assert(a1 == a2, "Comando liberado fora de ordem!\n\n" + a2 + " deveria ter liberado antes de " + a1 + "!");
                            debug_ocupantes.Pop();
                        }
                        else if (debug_ocupantes.Count > 0)
                            debug_ocupantes.Pop();
                    }

                    debug_ocupado = value;
                }
            }
        }
#endif

        internal DateTime AguardarAté = DateTime.Now;
#if DEBUG
        private static int debug_contador = 0;

        internal System.Diagnostics.StackTrace cmdPilha;
        internal DateTime cmdCriação;
        internal string cmdTexto;
        //, cmdAnterior;
        internal string cmdLeitor;
        public string Debug_ObtençãoConexão;
        public int Debug_ID = debug_contador++;

        public string PilhaDepuração { get { return cmdPilha.ToString(); } }
#endif

        ///// <summary>
        ///// Verifica se a conexão está ocupada.
        ///// </summary>
        //internal int Ocupado
        //{
        //    get { return ocupado; }
        //    set { ocupado = value; }
        //}

        ///// <summary>
        ///// Até quando aguardar para considerar desocupado.
        ///// </summary>
        //internal DateTime AguardarAté
        //{
        //    get { return aguardarAté; }
        //    set { aguardarAté = value; }
        //}

        public IDbConnection ConexãoOriginal
        {
            get { return conexão; }
        }

        public ConexãoConcorrente(IDbConnection conexão)
        {
            this.conexão = conexão;
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return conexão.BeginTransaction(il);
        }

        public IDbTransaction BeginTransaction()
        {
            return conexão.BeginTransaction();
        }

        public void ChangeDatabase(string databaseName)
        {
            conexão.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            conexão.Close();
        }

        public string ConnectionString
        {
            get
            {
                return conexão.ConnectionString;
            }
            set
            {
                conexão.ConnectionString = value;
            }
        }

        public int ConnectionTimeout
        {
            get { return conexão.ConnectionTimeout; }
        }

        public IDbCommand CreateCommand()
        {
            return new ComandoConcorrente(this, conexão.CreateCommand());
        }

        public string Database
        {
            get { return conexão.Database; }
        }

        public void Open()
        {
            conexão.Open();
        }

        public ConnectionState State
        {
            get { return conexão.State; }
        }

        public void Dispose()
        {
            conexão.Dispose();
        }
    }
}
