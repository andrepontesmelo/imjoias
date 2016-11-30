using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal.Registro
{
    public class InventárioRelativo : DbManipulaçãoSimples
    {
        private string referencia;
        private decimal quantidade;

        public string Referência => referencia;
        public decimal Quantidade => quantidade;

        public InventárioRelativo()
        {
        }

        public static Dictionary<string, decimal> ObterHashReferênciaQuantidadeInventárioAnterior(DateTime data)
        {
            return ObterHashReferênciaQuantidade(ObterInventárioAnterior(data));
        }

        public static Dictionary<string, decimal> ObterHashReferênciaQuantidadeInventárioPosterior(DateTime data)
        {
            return ObterHashReferênciaQuantidade(ObterInventárioPosterior(data));
        }

        public static Dictionary<string, decimal> ObterHashReferênciaQuantidade(List<InventárioRelativo> lst)
        {
            var hash = new Dictionary<string, decimal>();

            foreach (var i in lst)
                hash[i.Referência] = i.Quantidade;

            return hash;
        }

        private static List<InventárioRelativo> ObterInventárioAnterior(DateTime data)
        {
            return Mapear<InventárioRelativo>(string.Format("select referencia, sum(quantidade) as quantidade from extratoinventario where data < {0} group by referencia",
                DbTransformar(data)));
        }

        private static List<InventárioRelativo> ObterInventárioPosterior(DateTime data)
        {
            return Mapear<InventárioRelativo>(string.Format("select referencia, sum(quantidade) as quantidade from extratoinventario where data <= {0} group by referencia",
                DbTransformar(data)));
        }
    }
}
