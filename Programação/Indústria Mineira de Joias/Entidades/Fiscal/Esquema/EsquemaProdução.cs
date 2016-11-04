using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System;
using System.Text;

namespace Entidades.Fiscal.Esquema
{
    [DbTabela("esquemaproducaofiscal")]
    public class EsquemaProdução : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        private string referencia;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;
        private int cfop;

        public string Referência => referencia;
        public decimal Quantidade => quantidade;
        public string Descrição => descricao;
        public TipoUnidade TipoUnidadeFiscal => TipoUnidade.Obter(tipounidade);
        public int CFOP => cfop;

        public EsquemaProdução()
        {
        }

        private static List<EsquemaProdução> lstEsquemas;

        public static List<EsquemaProdução> Esquemas
        {
            get
            {
                if (lstEsquemas == null)
                    CarregarCache();

                return lstEsquemas;
            }
        }

        private static void CarregarCache()
        {
            lstEsquemas = Mapear<EsquemaProdução>("select e.*, m.nome as descricao, m.tipounidade, m.cfop from " + 
                " esquemaproducaofiscal e join mercadoria m on e.referencia=m.referencia");
        }

        public static void ExcluirRecarregandoCache(List<EsquemaProdução> seleção)
        {
            Excluir(seleção);
            CarregarCache();
        }

        private static void Excluir(List<EsquemaProdução> seleção)
        {
            StringBuilder sql = new StringBuilder("delete from esquemaproducaofiscal where referencia in (");

            bool primeiro = true;
            foreach (EsquemaProdução e in seleção)
            {
                if (!primeiro)
                    sql.Append(",");

                sql.Append(DbTransformar(e.Referência));
                primeiro = false;
            }
            sql.Append(")");

            ExecutarComando(sql.ToString());
        }
    }
}
