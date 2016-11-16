using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Fiscal.Registro
{
    public class InventárioAnterior : DbManipulaçãoSimples
    {
        private string referencia;
        private decimal quantidade;

        public string Referência => referencia;
        public decimal Quantidade => quantidade;

        public InventárioAnterior()
        {
        }

        public static Dictionary<string, decimal> ObterHashReferênciaQuantidade(DateTime data)
        {
            var hash = new Dictionary<string, decimal>();
            List<InventárioAnterior> lst = ObterInventárioAnterior(data);

            foreach (var i in lst)
                hash[i.Referência] = i.Quantidade;

            return hash;
        }

        private static List<InventárioAnterior> ObterInventárioAnterior(DateTime data)
        {
            return Mapear<InventárioAnterior>(string.Format("select referencia, sum(quantidade) as quantidade from extratoinventario where data < {0} group by referencia",
                DbTransformar(data)));
        }
    }
}
