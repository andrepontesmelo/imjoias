using System;
using System.Data;
using System.Data.Common;
using Acesso.Comum;
using System.Text;

namespace Acesso.MySQL
{
	/// <summary>
	/// Gerenciador de usu�rios
	/// </summary>
	/// <remarks>Singleton</remarks>
	public class MySQLUsu�rios : Usu�rios
	{
        private static string �ltimaStrConex�o; 

        private const string bdPadr�o = "imjoias";

#if DEBUG
        private const string hostPadr�o = "172.16.145.1";
        private const int portPadr�o = 3306;
#else
        private const string hostPadr�o = "192.168.1.25";
        private const int portPadr�o = 46033;
#endif
        /// <summary>
        /// Host padr�o, que pode ser substitu�do pelo registro "host"
        /// na chave "Local\Software\Ind�stria Mineira de Joias".
        /// </summary>

        private const int	   portaNeg�cio = 8085;

		/// <summary>
		/// Host padr�o do servidor.
		/// </summary>
		public static string Host
		{
			get
			{
				try
				{
					string host;

					Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software");
					reg = reg.OpenSubKey("Ind�stria Mineira de Joias");

                    if (reg != null)
                        host = (string) reg.GetValue("host", hostPadr�o);
                    else
                        host = hostPadr�o;

					return host == null ? hostPadr�o : host;
				}
				catch
				{
					return hostPadr�o;
				}
			}
		}

        public static string BancoDeDados
        {
            get
            {
                try
                {
                    string bd;

                    Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software");
                    reg = reg.OpenSubKey("Ind�stria Mineira de Joias");

                    if (reg != null)
                        bd = (string)reg.GetValue("bd", bdPadr�o);
                    else
                        bd = bdPadr�o;

                    return bd ?? bdPadr�o;
                }
                catch
                {
                    return bdPadr�o;
                }
            }
        }

        public static int Port
        {
            get
            {
                try
                {
                    int port;

                    Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software");
                    reg = reg.OpenSubKey("Ind�stria Mineira de Joias");

                    if (reg != null)
                        port = Convert.ToInt32(reg.GetValue("port", portPadr�o));
                    else
                        port = portPadr�o;

                    return port;
                }
                catch
                {
                    return portPadr�o;
                }
            }
        }

        /// <summary>
		/// Constr�i um usu�rio
		/// </summary>
		/// <param name="usu�rio"></param>
		/// <param name="senha"></param>
		/// <returns></returns>
		protected override Usu�rio ConstruirUsu�rio(string usu�rio, string senha)
		{
			return new Usu�rio(this, usu�rio, senha);
		}

		/// <summary>
		/// Conecta ao servidor de banco de dados
		/// </summary>
		/// <returns>Conex�o com o banco de dados</returns>
		public override IDbConnection Conectar(string usu�rio, string senha)
		{
            return Conectar(usu�rio, senha, Host, Port, BancoDeDados);
		}

		/// <summary>
		/// Constr�i adaptador para conex�o
		/// </summary>
		/// <param name="conex�o">Conex�o</param>
		/// <returns>Adaptador</returns>
		protected override DbDataAdapter CriarAdaptador(IDbConnection conex�o, string comando)
		{
			DbDataAdapter       adaptador;
            DbCommandBuilder	cmdBuilder;

            if (conex�o is Acesso.Comum.Adaptadores.Conex�oConcorrente)
                adaptador = ConectorMysql.Inst�ncia.CriarAdaptador(comando, (IDbConnection)(((Acesso.Comum.Adaptadores.Conex�oConcorrente)conex�o).Conex�oOriginal));
            else
                adaptador = ConectorMysql.Inst�ncia.CriarAdaptador(comando, conex�o);

            cmdBuilder = ConectorMysql.Inst�ncia.CriarConstrutorDeComandos(adaptador);

            return adaptador;
		}

		/// <summary>
		/// Obt�m �ltimo c�digo do auto-increment.
		/// </summary>
		/// <param name="conex�o">Conex�o.</param>
		/// <returns>�ltimo c�digo inserido.</returns>
		public override long Obter�ltimoC�digoInserido(IDbConnection conex�o)
		{
            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID()";
                    return Convert.ToInt64(cmd.ExecuteScalar());
                }
            }
		}

        public static IDbConnection Conectar(string usu�rio, string senha, string host, int porta, string database)
        {
            IDbConnection  conex�o = null;

            StringBuilder strConex�o;

            strConex�o = ObterStrConex�o(usu�rio, senha, host, porta, database);

            conex�o = ConectorMysql.Inst�ncia.CriarConex�o(strConex�o.ToString());
            conex�o.Open();

            return conex�o;
        }

        private static StringBuilder ObterStrConex�o(string usu�rio, string senha, string host, int porta, string database)
        {
            StringBuilder strConex�o = new StringBuilder("Data Source=" + host);
            
            strConex�o.Append(";Database=");
            strConex�o.Append(database);
            strConex�o.Append(";User Id=");
            strConex�o.Append(usu�rio);
            strConex�o.Append(";Password=");
            strConex�o.Append(senha);
            strConex�o.Append(";Pooling=False");
            strConex�o.Append(";Port=");
            strConex�o.Append(porta.ToString());
            strConex�o.Append(";Connection Timeout=600");

            �ltimaStrConex�o = strConex�o.ToString();

            return strConex�o;
        }

        public static string Obter�ltimaStrConex�o()
        {
            return �ltimaStrConex�o;
        }
    }
}
