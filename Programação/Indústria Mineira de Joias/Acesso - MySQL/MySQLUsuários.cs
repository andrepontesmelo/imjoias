using System;
using System.Data;
using System.Data.Common;
using Acesso.Comum;
using System.Text;

namespace Acesso.MySQL
{
	/// <summary>
	/// Gerenciador de usuários
	/// </summary>
	/// <remarks>Singleton</remarks>
	public class MySQLUsuários : Usuários
	{
        private static string últimaStrConexão; 

        private const string bdPadrão = "imjoias";

#if DEBUG
        private const string hostPadrão = "172.16.145.1";
        private const int portPadrão = 3306;
#else
        private const string hostPadrão = "192.168.1.25";
        private const int portPadrão = 46033;
#endif
        /// <summary>
        /// Host padrão, que pode ser substituído pelo registro "host"
        /// na chave "Local\Software\Indústria Mineira de Joias".
        /// </summary>

        private const int	   portaNegócio = 8085;

		/// <summary>
		/// Host padrão do servidor.
		/// </summary>
		public static string Host
		{
			get
			{
				try
				{
					string host;

					Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software");
					reg = reg.OpenSubKey("Indústria Mineira de Joias");

                    if (reg != null)
                        host = (string) reg.GetValue("host", hostPadrão);
                    else
                        host = hostPadrão;

					return host == null ? hostPadrão : host;
				}
				catch
				{
					return hostPadrão;
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
                    reg = reg.OpenSubKey("Indústria Mineira de Joias");

                    if (reg != null)
                        bd = (string)reg.GetValue("bd", bdPadrão);
                    else
                        bd = bdPadrão;

                    return bd ?? bdPadrão;
                }
                catch
                {
                    return bdPadrão;
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
                    reg = reg.OpenSubKey("Indústria Mineira de Joias");

                    if (reg != null)
                        port = Convert.ToInt32(reg.GetValue("port", portPadrão));
                    else
                        port = portPadrão;

                    return port;
                }
                catch
                {
                    return portPadrão;
                }
            }
        }

        /// <summary>
		/// Constrói um usuário
		/// </summary>
		/// <param name="usuário"></param>
		/// <param name="senha"></param>
		/// <returns></returns>
		protected override Usuário ConstruirUsuário(string usuário, string senha)
		{
			return new Usuário(this, usuário, senha);
		}

		/// <summary>
		/// Conecta ao servidor de banco de dados
		/// </summary>
		/// <returns>Conexão com o banco de dados</returns>
		public override IDbConnection Conectar(string usuário, string senha)
		{
            return Conectar(usuário, senha, Host, Port, BancoDeDados);
		}

		/// <summary>
		/// Constrói adaptador para conexão
		/// </summary>
		/// <param name="conexão">Conexão</param>
		/// <returns>Adaptador</returns>
		protected override DbDataAdapter CriarAdaptador(IDbConnection conexão, string comando)
		{
			DbDataAdapter       adaptador;
            DbCommandBuilder	cmdBuilder;

            if (conexão is Acesso.Comum.Adaptadores.ConexãoConcorrente)
                adaptador = ConectorMysql.Instância.CriarAdaptador(comando, (IDbConnection)(((Acesso.Comum.Adaptadores.ConexãoConcorrente)conexão).ConexãoOriginal));
            else
                adaptador = ConectorMysql.Instância.CriarAdaptador(comando, conexão);

            cmdBuilder = ConectorMysql.Instância.CriarConstrutorDeComandos(adaptador);

            return adaptador;
		}

		/// <summary>
		/// Obtém último código do auto-increment.
		/// </summary>
		/// <param name="conexão">Conexão.</param>
		/// <returns>Último código inserido.</returns>
		public override long ObterÚltimoCódigoInserido(IDbConnection conexão)
		{
            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID()";
                    return Convert.ToInt64(cmd.ExecuteScalar());
                }
            }
		}

        public static IDbConnection Conectar(string usuário, string senha, string host, int porta, string database)
        {
            IDbConnection  conexão = null;

            StringBuilder strConexão;

            strConexão = ObterStrConexão(usuário, senha, host, porta, database);

            conexão = ConectorMysql.Instância.CriarConexão(strConexão.ToString());
            conexão.Open();

            return conexão;
        }

        private static StringBuilder ObterStrConexão(string usuário, string senha, string host, int porta, string database)
        {
            StringBuilder strConexão = new StringBuilder("Data Source=" + host);
            
            strConexão.Append(";Database=");
            strConexão.Append(database);
            strConexão.Append(";User Id=");
            strConexão.Append(usuário);
            strConexão.Append(";Password=");
            strConexão.Append(senha);
            strConexão.Append(";Pooling=False");
            strConexão.Append(";Port=");
            strConexão.Append(porta.ToString());
            strConexão.Append(";Connection Timeout=600");

            últimaStrConexão = strConexão.ToString();

            return strConexão;
        }

        public static string ObterÚltimaStrConexão()
        {
            return últimaStrConexão;
        }
    }
}
