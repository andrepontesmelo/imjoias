using Acesso.Comum;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Fabricação
{
    [DbTabela("saidafabricacaofiscal")]
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

        public static void Alterar(ItemFabricaçãoFiscal entidade)
        {
            var sql = string.Format("UPDATE saidafabricacaofiscal set referencia={0}, quantidade={1}, valor={2} where codigo={3}",
            DbTransformar(entidade.Referência),
            DbTransformar(entidade.Quantidade),
            DbTransformar(entidade.Valor),
            DbTransformar(entidade.Código));

            ExecutarComando(sql);
        }
    }
}
