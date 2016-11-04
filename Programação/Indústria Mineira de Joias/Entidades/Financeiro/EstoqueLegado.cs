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
            ExecutarComando("delete from estoquelegado");
            sql = new StringBuilder("insert into estoquelegado (referencia, estoque1, estoque2, estoque3, estoqueanterior) values ");

            foreach (DataRow item in tabelaCadmer.Rows)
                TransporItem(item);

            ExecutarComando(sql.ToString());
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
            return DbTransformar(item["CM_" + atributo].ToString().Trim());
        }
    }
}
