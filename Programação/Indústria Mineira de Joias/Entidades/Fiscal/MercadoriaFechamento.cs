using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    [DbTabela("mercadoriafechamento")]
    public class MercadoriaFechamento : DbManipulaçãoSimples
    {

        [DbColuna("referencia")]
        private string referência;

        [DbColuna("descricao")]
        private string descricao;

        private decimal valor;
        private decimal peso;

        public string Referência => referência;
        public decimal Valor => valor;
        public string Descrição => descricao;
        public decimal Peso => peso;

        private static Dictionary<int, Dictionary<string, MercadoriaFechamento>> hashFechamentos = new Dictionary<int, Dictionary<string, MercadoriaFechamento>>();

        public static Dictionary<string, MercadoriaFechamento> ObterHash(int fechamento)
        {
            Dictionary<string, MercadoriaFechamento> hash;

            if (hashFechamentos.TryGetValue(fechamento, out hash))
                return hash;

            hash = CarregarHash(fechamento);
            hashFechamentos[fechamento] = hash;

            return hash;
        }

        private static Dictionary<string, MercadoriaFechamento> CarregarHash(int fechamento)
        {
            Dictionary<string, MercadoriaFechamento> hash = new Dictionary<string, MercadoriaFechamento>();
            var lista = Mapear<MercadoriaFechamento>("select referencia, valor, descricao, peso from mercadoriafechamento where fechamento=" + fechamento.ToString());

            foreach (MercadoriaFechamento m in lista)
                hash[m.referência] = m;

            return hash;
        }
    }
}
