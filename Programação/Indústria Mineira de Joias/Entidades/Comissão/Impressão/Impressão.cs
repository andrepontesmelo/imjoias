using Acesso.Comum;
using System;
using System.Text;

namespace Entidades.Comissão.Impressão
{
    public abstract class Impressão : DbManipulaçãoAutomática
    {
        protected static void AplicarFiltro(StringBuilder str, Filtro filtro)
        {
            str.Append(" WHERE v.codigo IN ");
            str.Append(ObterSqlVendasData(filtro.DataInicial, filtro.DataFinal));
            if (filtro.Funcionário != null)
            {
                str.Append(" AND cv.comissaopara = ");
                str.Append(DbTransformar(filtro.Funcionário.Código));
            }
        }

        protected static String ObterSqlVendasData(DateTime? dataInicial, DateTime? dataFinal)
        {
            String str = " (SELECT codigo from venda where 1=1 ";

            if (dataInicial.HasValue)
            {
                str += " AND data > '";
                str += dataInicial.Value.ToString("yyyy-MM-dd");
                str += " 00:00:00'";
            }

            if (dataFinal.HasValue)
            {
                str += " AND data < '";
                str += dataFinal.Value.AddDays(1).ToString("yyyy-MM-dd");
                str += " 00:00:00'";
            }

            str += ") ";

            return str;
        }
    }
}
