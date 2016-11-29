using System.Collections.Generic;

namespace Entidades.Fiscal.Fabricação
{
    public class SaídaFabricaçãoFiscal : ItemFabricaçãoFiscal
    {
        internal static readonly string RELAÇÃO = "saidafabricacaofiscal";

        internal static string ObterSqlInserçãoSaída(FabricaçãoFiscal fabricação, decimal qtdReceitas, string referência, decimal quantidade, decimal valor)
        {
            return string.Format("INSERT INTO saidafabricacaofiscal (fabricacaofiscal, referencia, quantidade, valor) values ({0}, {1}, {2}, {3})",
                DbTransformar(fabricação.Código),
                DbTransformar(referência),
                DbTransformar(quantidade),
                DbTransformar(valor));
        }

        public static List<ItemFabricaçãoFiscal> Obter(int fabricação)
        {
            return Mapear<ItemFabricaçãoFiscal>(string.Format("select codigo, referencia, quantidade, valor from " +
                " saidafabricacaofiscal where fabricacaofiscal={0}", DbTransformar(fabricação)));
        }

        public SaídaFabricaçãoFiscal()
        {
        }
    }
}
