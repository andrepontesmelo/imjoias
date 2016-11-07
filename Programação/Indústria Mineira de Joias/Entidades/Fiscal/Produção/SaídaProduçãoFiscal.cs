using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal.Produção
{
    public class SaídaProduçãoFiscal : ItemProduçãoFiscal
    {
        internal static void InserirProduçãoSaída(ProduçãoFiscal produção, decimal qtdReceitas, string referência, decimal quantidade, IDbTransaction transação)
        {
            ExecutarComandoTransação(string.Format("INSERT INTO saidaproducaofiscal (producaofiscal, referencia, quantidade) values ({0}, {1}, {2})",
                DbTransformar(produção.Código),
                DbTransformar(referência),
                DbTransformar(qtdReceitas * quantidade)), transação);
        }

        public static List<ItemProduçãoFiscal> Obter(int produção)
        {
            return Mapear<ItemProduçãoFiscal>(string.Format("select referencia, sum(quantidade) as quantidade from " +
                " saidaproducaofiscal where producaofiscal={0} GROUP BY referencia", DbTransformar(produção)));
        }

        public SaídaProduçãoFiscal()
        {
        }
    }
}
