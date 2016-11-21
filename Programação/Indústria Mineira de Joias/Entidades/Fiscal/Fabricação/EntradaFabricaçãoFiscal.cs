using Entidades.Fiscal.Esquema;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal.Fabricação
{
    public class EntradaFabricaçãoFiscal : ItemFabricaçãoFiscal
    {
        internal static readonly string RELAÇÃO = "entradafabricacaofiscal";

        internal static string ObterSqlInserçãoEntrada(FabricaçãoFiscal fabricação, MateriaPrima ingrediente, decimal qtdReceitas)
        {
            return string.Format("INSERT INTO entradafabricacaofiscal (fabricacaofiscal, referencia, quantidade) values ({0}, {1}, {2})",
                    DbTransformar(fabricação.Código),
                    DbTransformar(ingrediente.Referência),
                    DbTransformar(qtdReceitas * ingrediente.Quantidade));
        }

        public static List<ItemFabricaçãoFiscal> Obter(int fabricação)
        {
            return Mapear<ItemFabricaçãoFiscal>(string.Format("select referencia, sum(quantidade) as quantidade from " +
                " entradafabricacaofiscal where fabricacaofiscal={0} GROUP BY referencia", DbTransformar(fabricação)));
        }

        public EntradaFabricaçãoFiscal()
        {
        }
    }
}
