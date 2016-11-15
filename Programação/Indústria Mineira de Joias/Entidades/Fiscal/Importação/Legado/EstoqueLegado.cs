using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal.Importação.Legado
{
    public class EstoqueLegado : DbManipulaçãoSimples
    {
        private string referencia;
        private decimal estoqueanterior;

        public string Referência => referencia;
        public decimal Estoque => estoqueanterior;

        public EstoqueLegado()
        {
        }

        public static List<EstoqueLegado> Obter()
        {
            return Mapear<EstoqueLegado>("select m.referencia, ifnull(e.estoqueanterior,0) as estoqueanterior from " + 
                " mercadoria m left join estoquelegado e on m.referencia=e.referencia");
        }
    }
}
