#define RASTRO
#define RASTRO_SIMPLES

using System;
using System.Data;
using System.Diagnostics;


namespace Acesso.Comum.Adaptadores
{
    /// <summary>
    /// Adaptador que permite verificar quando um DataReader
    /// está em uso.
    /// </summary>
    [Serializable]
    public class ComandoConcorrente : IDbCommand
    {
        private ConexãoConcorrente conexão;
        private IDbCommand cmd;

        public ComandoConcorrente(ConexãoConcorrente conexão, IDbCommand cmd)
        {
            this.conexão = conexão;
            this.cmd = cmd;
            conexão.Ocupado++;
            conexão.AguardarAté = DateTime.MinValue;

#if DEBUG
            conexão.cmdPilha = new System.Diagnostics.StackTrace(3, true);
            conexão.cmdCriação = DateTime.Now;

            conexão.cmdTexto = cmd.CommandText;
#endif
        }

#if DEBUG && RASTRO
        private void DepurarRastro()
		{
			try
			{
#if !RASTRO_SIMPLES
				System.Diagnostics.StackTrace pilha;
				System.Diagnostics.StackFrame quadro, quadro2;
				string arq1, arq2;
				string [] sep;
				int cnt = 0;

                pilha = new System.Diagnostics.StackTrace(3, true);
#endif
                Console.WriteLine();
				Console.WriteLine("{0}", CommandText);

                foreach (IDbDataParameter parâmetro in cmd.Parameters)
                    Console.WriteLine("=> Parâmetro {0} = {1}",
                        parâmetro.ParameterName, parâmetro.Value);

#if !RASTRO_SIMPLES
				do
				{
					quadro = pilha.GetFrame(cnt++);
					quadro2 = pilha.GetFrame(cnt);

                    if (quadro != null)
                        arq1 = quadro.GetFileName();
                    else
                    {
                        arq1 = null;
                        arq2 = null;
                        break;
                    }

                    if (quadro2 != null)
                        arq2 = quadro2.GetFileName();
                    else
                    {
                        arq2 = null;
                        break;
                    }
				} while (arq1 == null);

				if (arq1 != null)
				{
					sep = arq1.Split('\\');
				
					if (sep.Length > 0)
						arq1 = sep[sep.Length - 1];
				}

				if (arq2 != null)
				{
					sep = arq2.Split('\\');

					if (sep.Length > 0)
						arq2 = sep[sep.Length - 1];
				}

                if (arq1 != null)
				    Console.WriteLine("~ Comando <- {0} ({1}:{2})",
					    quadro.GetMethod().Name, arq1, quadro.GetFileLineNumber());

                if (arq2 != null)
				    Console.WriteLine("             {0} ({1}:{2})\n",
					    quadro2.GetMethod().Name, arq2, quadro2.GetFileLineNumber());
#endif
			}
			catch
			{
				Console.WriteLine("Erro ao rastrear comando!");
			}
		}

        private static void NotificarTempo(TimeSpan tempo)
        {
            if (tempo.TotalMilliseconds > 500)
                Console.Write(" {0} ms só de execução, ", tempo.TotalMilliseconds.ToString("#"));
        }
#endif

        public void Cancel()
        {
            cmd.Cancel();
        }

        public string CommandText
        {
            get
            {
                return cmd.CommandText;
            }
            set
            {
                cmd.CommandText = value;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return cmd.CommandTimeout;
            }
            set
            {
                cmd.CommandTimeout = value;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return cmd.CommandType;
            }
            set
            {
                cmd.CommandType = value;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return conexão;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public IDbDataParameter CreateParameter()
        {
            return cmd.CreateParameter();
        }

        public int ExecuteNonQuery()
        {
            conexão.Ocupado++;
            conexão.AguardarAté = DateTime.MinValue;

            try
            {
#if DEBUG
                if (conexão.cmdLeitor != null)
                    Debug.Fail("Comando liberado com leitor aberto",
                        string.Format("O comando {0} foi liberado com o leitor aberto.", conexão.cmdLeitor));

                conexão.cmdPilha = new StackTrace(3, true);
#endif
#if DEBUG && RASTRO
                DepurarRastro();
                DateTime início = DateTime.Now;

                int resultado = cmd.ExecuteNonQuery();

                TimeSpan dif = DateTime.Now - início;

                NotificarTempo(dif);

                return resultado;
#else
            return cmd.ExecuteNonQuery();
#endif
            }
            finally
            {
                conexão.Ocupado--;
            }
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            Debug.Assert(conexão.AguardarAté < DateTime.Now);

            conexão.Ocupado++;
            conexão.AguardarAté = DateTime.MinValue;

            try
            {
#if DEBUG
                if (conexão.cmdLeitor != null)
                    Debug.Fail("Comando liberado com leitor aberto",
                        string.Format("O comando {0} foi liberado com o leitor aberto.", conexão.cmdLeitor));

                conexão.cmdPilha = new StackTrace(3, true);
#endif
#if DEBUG && RASTRO
                DepurarRastro();

                DateTime início = DateTime.Now;

                IDataReader leitor = new LeitorConcorrente(conexão, cmd.ExecuteReader(behavior));

                TimeSpan dif = DateTime.Now - início;

                NotificarTempo(dif);

                return leitor;
#else
            return new LeitorConcorrente(conexão, cmd.ExecuteReader(behavior));
#endif
            }
            finally
            {
                conexão.Ocupado--;
            }
        }

        public IDataReader ExecuteReader()
        {
            Debug.Assert(conexão.AguardarAté < DateTime.Now);

            conexão.Ocupado++;
            conexão.AguardarAté = DateTime.MinValue;

            try
            {
#if DEBUG
                if (conexão.cmdLeitor != null)
                    Debug.Fail("Comando liberado com leitor aberto",
                        string.Format("O comando {0} foi liberado com o leitor aberto.", conexão.cmdLeitor));

                conexão.cmdPilha = new StackTrace(3, true);
#endif
#if DEBUG && RASTRO
                DepurarRastro();

                DateTime início = DateTime.Now;

                IDataReader leitor = new LeitorConcorrente(conexão, cmd.ExecuteReader());

                TimeSpan dif = DateTime.Now - início;

                NotificarTempo(dif);

                return leitor;
#else
            return new LeitorConcorrente(conexão, cmd.ExecuteReader());
#endif
            }
            finally
            {
                conexão.Ocupado--;
            }
        }

        public object ExecuteScalar()
        {
            Debug.Assert(conexão.AguardarAté < DateTime.Now);

            conexão.Ocupado++;
            conexão.AguardarAté = DateTime.MinValue;

            try
            {
#if DEBUG
            if (conexão.cmdLeitor != null)
                    Debug.Fail("Comando liberado com leitor aberto",
                        string.Format("O comando {0} foi liberado com o leitor aberto.", conexão.cmdLeitor));

                conexão.cmdPilha = new StackTrace(3, true);
#endif
                if (cmd == null)
                    throw new Exception("o comando é nulo");

#if DEBUG && RASTRO
                DepurarRastro();
                DateTime início = DateTime.Now;

                ConnectionState estadoDaConexao = cmd.Connection.State;
                Console.WriteLine(estadoDaConexao.ToString());

                object resultado = cmd.ExecuteScalar();

                TimeSpan dif = DateTime.Now - início;

                NotificarTempo(dif);

                return resultado;
#else
            return  cmd.ExecuteScalar();
#endif
            }
            finally
            {
                conexão.Ocupado--;
            }
        }

        public IDataParameterCollection Parameters
        {
            get { return cmd.Parameters; }
        }

        public void Prepare()
        {
            cmd.Prepare();
        }

        public IDbTransaction Transaction
        {
            get
            {
                return cmd.Transaction;
            }
            set
            {
                cmd.Transaction = value;
            }
        }

        public UpdateRowSource UpdatedRowSource
        {
            get
            {
                return cmd.UpdatedRowSource;
            }
            set
            {
                cmd.UpdatedRowSource = value;
            }
        }

        public void Dispose()
        {
#if DEBUG
            Debug.Assert(conexão.cmdLeitor == null,
                "Comando liberado com leitor aberto",
                string.Format("O comando {0} foi liberado com o leitor aberto.", conexão.cmdLeitor));

            Debug.Assert(conexão.AguardarAté < DateTime.Now);
#endif
            conexão.Ocupado--;
            cmd.Dispose();
        }
    }
}
