using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo
{
    public class MySQL
    {
        public static Hashtable adaptadoresPelaTabela = new Hashtable();
        public static void AdicionarTabelaAoDataSet(DataSet ds, string tabela, List<IDbConnection> conexõesRemovidas)
        {
            IDbConnection conexão = null;
            System.Data.Common.DbDataAdapter adaptador;

            if (adaptadoresPelaTabela.Contains(tabela))
            {
                adaptador = (System.Data.Common.DbDataAdapter)adaptadoresPelaTabela[tabela];
            }
            else
            {
                conexão = Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.Conexão;

                Acesso.MySQL.MySQLUsuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                conexõesRemovidas.Add(conexão);
                adaptador = Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.CriarAdaptadorDados(conexão, "select * from " + tabela);
                adaptadoresPelaTabela.Add(tabela, adaptador);
            }

            adaptador.Fill(ds, tabela);
        }


        public static void GravarDataSet(DataSet ds, string tabela)
        {
            System.Data.Common.DbDataAdapter adaptador;
            adaptador = (System.Data.Common.DbDataAdapter)adaptadoresPelaTabela[tabela];

            adaptador.Update(ds, tabela);
        }


        public static void GravarDataSetTodasTabelas(DataSet ds)
        {
            foreach (System.Data.DataTable tabela in ds.Tables)
            {
                GravarDataSet(ds, tabela.TableName);
            }
        }

        static Dictionary<long, bool> clientesCadastrados = null;

        static public bool ExisteCliente(long código, DataSet mysql)
        {
            if (clientesCadastrados == null)
            {
                clientesCadastrados = new Dictionary<long, bool>();

                foreach (DataRow i in mysql.Tables["pessoa"].Rows)
                    clientesCadastrados.Add(long.Parse(i["codigo"].ToString()), true);
            }

            return clientesCadastrados.ContainsKey(código);
        }

        public static void AdicionarConexõesRemovidas(List<IDbConnection> conexõesRemovidas)
        {
            foreach (IDbConnection c in conexõesRemovidas)
                Acesso.MySQL.MySQLUsuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(c);
        }
    }
}
