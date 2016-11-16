using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entidades.Financeiro
{
    public class EstoqueLegado : DbManipulaçãoSimples
    {
        private DataTable tabelaCadmer;
        private StringBuilder sql;
        private bool primeiro = true;

        public EstoqueLegado(System.Data.DataSet dataSetLegado)
        {
            tabelaCadmer = dataSetLegado.Tables["cadmer"];
        }

        public void Transpor()
        {
            Console.WriteLine("EstoqueLegado - início");

            var conexão = Conexão;
            var inícioSql = "insert into estoquelegado (referencia, estoque1, estoque2, estoque3, estoqueanterior) values ";
            lock (conexão)
            {
                using (IDbTransaction transação = conexão.BeginTransaction())
                {
                    ExecutarComandoTransação("delete from estoquelegado", transação);

                    int x = 0;
                    sql = new StringBuilder(inícioSql);

                    foreach (DataRow item in tabelaCadmer.Rows)
                    {
                        x++;

                        if (x >= 100)
                        {
                            x = 0;
                            primeiro = true;
                            ExecutarComandoTransação(sql.ToString(), transação);
                            sql.Clear();
                            sql.AppendLine(inícioSql);
                        }

                        TransporItem(item);
                    }

                    ExecutarComandoTransação(sql.ToString(), transação);
                    transação.Commit();
                    Console.WriteLine("EstoqueLegado - commit");
                }
            }
        }

        private void TransporItem(DataRow item)
        {
            if (!primeiro)
                sql.Append(", ");

            sql.Append(string.Format("({0}, {1}, {2}, {3}, {4})",
                ObterAtributo(item, "CODMER"),
                ObterAtributo(item, "ESTOQ01"),
                ObterAtributo(item, "ESTOQ02"),
                ObterAtributo(item, "ESTOQ03"),
                ObterAtributo(item, "ESTOQAN")));

            primeiro = false;
        }

        private static string ObterAtributo(DataRow item, string atributo)
        {
            var valor = item["CM_" + atributo];

            if (valor is string)
                valor = ((string) valor).Trim();

            if (valor is DBNull)
                return DbTransformar("0");

            return DbTransformar(valor);
        }
    }
}
