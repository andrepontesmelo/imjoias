using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    [DbTabela("esquemaproducaofiscal")]
    public class EsquemaProdução : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        private string referencia;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;

        public string Referência => referencia;
        public decimal Quantidade => quantidade;
        public string Descrição => descricao;
        public TipoUnidade TipoUnidadeFiscal => TipoUnidade.Obter(tipounidade);

        public EsquemaProdução()
        {
        }

        private static List<EsquemaProdução> lstEsquemas;

        public static List<EsquemaProdução> Esquemas
        {
            get
            {
                if (lstEsquemas == null)
                    lstEsquemas = CarregarEsquemas();

                return lstEsquemas;
            }
        }

        private static List<EsquemaProdução> CarregarEsquemas()
        {
            return Mapear<EsquemaProdução>("select e.*, m.nome as descricao, m.tipounidade from esquemaproducaofiscal e join mercadoria m on e.referencia=m.referencia");
        }
    }
}
