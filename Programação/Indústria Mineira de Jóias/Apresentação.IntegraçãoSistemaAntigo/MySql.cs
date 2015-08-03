using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo
{
    public class MySql
    {
        public static Hashtable adaptadoresPelaTabela = new Hashtable();
        public static void AdicionarTabelaAoDataSet(DataSet ds, string tabela)
        {
            System.Data.Common.DbDataAdapter adaptador;

            if (adaptadoresPelaTabela.Contains(tabela))
            {
                adaptador = (System.Data.Common.DbDataAdapter)adaptadoresPelaTabela[tabela];
            }
            else
            {
                adaptador = Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.CriarAdaptadorDados(Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.Conexão, "select * from " + tabela);
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
    }
}
