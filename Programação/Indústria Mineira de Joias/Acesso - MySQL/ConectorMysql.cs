using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace Acesso.MySQL
{
    public class ConectorMysql
    {
        private static ConectorMysql instância = null;
        public static ConectorMysql Instância
        {
            get
            {
                if (instância == null)
                    instância = new ConectorMysql();

                return instância;
            }
        }

        private ConectorMysql()
        {
        }

        public DbDataAdapter CriarAdaptador(string comando, IDbConnection conexão)
        {
            return new MySqlDataAdapter(comando, (MySqlConnection) conexão);
        }

        public DbCommandBuilder CriarConstrutorDeComandos(DbDataAdapter adaptador)
        {
            return new MySqlCommandBuilder((MySqlDataAdapter) adaptador);
        }

        public IDbConnection CriarConexão(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}
