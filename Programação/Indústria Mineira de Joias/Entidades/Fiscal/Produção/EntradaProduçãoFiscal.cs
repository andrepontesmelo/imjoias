using Entidades.Fiscal.Esquema;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal.Produção
{
    public class EntradaProduçãoFiscal : ItemProduçãoFiscal
    {
        internal static readonly string RELAÇÃO = "entradaproducaofiscal";

        internal static string ObterSqlInserçãoEntrada(ProduçãoFiscal produção, Ingrediente ingrediente, decimal qtdReceitas)
        {
            return string.Format("INSERT INTO entradaproducaofiscal (producaofiscal, referencia, quantidade) values ({0}, {1}, {2})",
                    DbTransformar(produção.Código),
                    DbTransformar(ingrediente.Referência),
                    DbTransformar(qtdReceitas * ingrediente.Quantidade));
        }

        public static List<ItemProduçãoFiscal> Obter(int produção)
        {
            return Mapear<ItemProduçãoFiscal>(string.Format("select referencia, sum(quantidade) as quantidade from " +
                " entradaproducaofiscal where producaofiscal={0} GROUP BY referencia", DbTransformar(produção)));
        }

        public EntradaProduçãoFiscal()
        {
        }
    }
}
