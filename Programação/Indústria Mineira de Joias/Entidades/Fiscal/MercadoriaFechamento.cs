using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    [DbTabela("mercadoriafechamento")]
    public class MercadoriaFechamento : DbManipulaçãoSimples
    {
        private string referencia;
        private decimal valor;

        private static Dictionary<int, Dictionary<string, decimal>> hashFechamentos = new Dictionary<int, Dictionary<string, decimal>>();

        public static Dictionary<string, decimal> ObterHashReferênciaValor(int fechamento)
        {
            Dictionary<string, decimal> hash;

            if (hashFechamentos.TryGetValue(fechamento, out hash))
                return hash;

            hash = CarregarHash(fechamento);
            hashFechamentos[fechamento] = hash;

            return hash;
        }

        private static Dictionary<string, decimal> CarregarHash(int fechamento)
        {
            Dictionary<string, decimal> hash = new Dictionary<string, decimal>();
            var lista = Mapear<MercadoriaFechamento>("select referencia, valor from mercadoriafechamento where fechamento=" + fechamento.ToString());

            foreach (MercadoriaFechamento m in lista)
                hash[m.referencia] = m.valor;

            return hash;
        }
    }
}
