using System.Collections.Generic;

namespace Entidades.Fiscal.Fabricação
{
    public class SaídaFabricaçãoFiscal : ItemFabricaçãoFiscal
    {
        internal static readonly string RELAÇÃO = "saidafabricacaofiscal";

        internal static string ObterSqlInserçãoSaída(FabricaçãoFiscal fabricação, decimal qtdReceitas, string referência, decimal quantidade)
        {
            return string.Format("INSERT INTO saidafabricacaofiscal (fabricacaofiscal, referencia, quantidade) values ({0}, {1}, {2})",
                DbTransformar(fabricação.Código),
                DbTransformar(referência),
                DbTransformar(quantidade));
        }

        public static List<ItemFabricaçãoFiscal> Obter(int fabricação)
        {
            return Mapear<ItemFabricaçãoFiscal>(string.Format("select referencia, sum(quantidade) as quantidade from " +
                " saidafabricacaofiscal where fabricacaofiscal={0} GROUP BY referencia", DbTransformar(fabricação)));
        }

        public SaídaFabricaçãoFiscal()
        {
        }
    }
}
