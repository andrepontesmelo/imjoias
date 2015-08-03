using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Acesso.MySQL
{
    public class ConectorMysql
    {
        private Assembly biblioteca;

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
            string arquivo = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "mysql.dll");

            if (!System.IO.File.Exists(arquivo))
            {
                throw new Exception("O conector não foi encontrado em " + arquivo);
            }
            
            biblioteca = Assembly.LoadFile(arquivo);
        }


        public DbDataAdapter CriarAdaptador(string comando, IDbConnection conexão)
        {
            object[] parâmetros = new object[2] { comando, conexão };

            DbDataAdapter adaptador = (DbDataAdapter) biblioteca.CreateInstance("MySql.Data.MySqlClient.MySqlDataAdapter", false, BindingFlags.CreateInstance, null, parâmetros, null, null);
            return adaptador;
        }

        public DbCommandBuilder CriarConstrutorDeComandos(DbDataAdapter adaptador)
        {
            object[] parâmetros = new object[1] { adaptador };

            DbCommandBuilder objeto = (DbCommandBuilder)biblioteca.CreateInstance("MySql.Data.MySqlClient.MySqlCommandBuilder", false, BindingFlags.CreateInstance, null, parâmetros, null, null);
            return objeto;
        }

        public IDbConnection CriarConexão(string connectionString)
        {
            object[] parâmetros = new object[1] { connectionString };

            IDbConnection conexão = (IDbConnection) biblioteca.CreateInstance("MySql.Data.MySqlClient.MySqlConnection", false, BindingFlags.CreateInstance, null, parâmetros, null, null);
            return conexão;
        }
    }
}
