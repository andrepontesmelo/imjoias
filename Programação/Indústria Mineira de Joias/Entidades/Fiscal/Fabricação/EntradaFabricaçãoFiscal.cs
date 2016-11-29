using Entidades.Fiscal.Esquema;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal.Fabricação
{
    public class EntradaFabricaçãoFiscal : ItemFabricaçãoFiscal
    {
        internal static readonly string RELAÇÃO = "entradafabricacaofiscal";

        internal static string ObterSqlInserçãoEntrada(FabricaçãoFiscal fabricação, MateriaPrima ingrediente, decimal qtdReceitas, decimal valor)
        {
            return string.Format("INSERT INTO entradafabricacaofiscal (fabricacaofiscal, referencia, quantidade, valor) values ({0}, {1}, {2}, {3})",
                    DbTransformar(fabricação.Código),
                    DbTransformar(ingrediente.Referência),
                    DbTransformar(qtdReceitas * ingrediente.Quantidade),
                    DbTransformar(valor));
        }

        public static List<ItemFabricaçãoFiscal> Obter(int fabricação)
        {
            return Mapear<ItemFabricaçãoFiscal>(string.Format("select codigo, referencia, quantidade, valor from " +
                " entradafabricacaofiscal where fabricacaofiscal={0}", DbTransformar(fabricação)));
        }

        public EntradaFabricaçãoFiscal()
        {
        }
    }
}
