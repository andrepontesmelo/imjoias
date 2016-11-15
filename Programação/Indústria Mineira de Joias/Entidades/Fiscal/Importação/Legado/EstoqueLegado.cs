using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal.Importação.Legado
{
    public class EstoqueLegado : DbManipulaçãoSimples
    {
        private string referencia;
        private decimal estoque1;
        private decimal estoque2;
        private decimal estoque3;
        private decimal estoqueanterior;

        public string Referência => referencia;
        public decimal Estoque => estoque1;

        public EstoqueLegado()
        {
        }

        public static List<EstoqueLegado> Obter()
        {
            return Mapear<EstoqueLegado>("select * from estoquelegado");
        }
    }
}
