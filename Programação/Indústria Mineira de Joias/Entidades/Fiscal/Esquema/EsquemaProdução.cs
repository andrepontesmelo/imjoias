using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Entidades.Fiscal.Esquema
{
    [DbTabela("esquemaproducaofiscal")]
    public class EsquemaProdução : DbManipulaçãoAutomática
    {
        private string referencia;
        private string referenciaAlterada;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;
        private int cfop;

        public string Referência
        {
            get
            {
                return referenciaAlterada == null ? referencia : referenciaAlterada;
            }
            set
            {
                referenciaAlterada = value;
            }
        }

        public decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

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

        private static void EsquecerCache()
        {
            lstEsquemas = null;
        }

        private static void CarregarCache()
        {
            lstEsquemas = Mapear<EsquemaProdução>("select e.*, m.nome as descricao, m.tipounidade, m.cfop from " + 
                " esquemaproducaofiscal e join mercadoria m on e.referencia=m.referencia");
        }

        internal static EsquemaProdução Obter(string referência)
        {
            return (from esquema in Esquemas where esquema.Referência.Equals(referência) select esquema).FirstOrDefault();
        }

        public static void Excluir(List<EsquemaProdução> seleção)
        {
            ExcluirEntidades(seleção);
            EsquecerCache();
        }

        private static void ExcluirEntidades(List<EsquemaProdução> seleção)
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

        public void Persistir()
        {
            if (!Cadastrado)
                CadastrarEntidade();
            else
                AtualizarEntidade();

            EsquecerCache();
        }

        private void AtualizarEntidade()
        {
            ExecutarComando(string.Format("UPDATE esquemaproducaofiscal set quantidade={0}, referencia={1} WHERE referencia={2}",
                DbTransformar(quantidade),
                (DbTransformar(referenciaAlterada == null ? referencia : referenciaAlterada)),
                DbTransformar(referencia)));

            DefinirAtualizado();
        }

        private void CadastrarEntidade()
        {
            ExecutarComando(string.Format("INSERT INTO esquemaproducaofiscal (quantidade, referencia) values ({0}, {1})",
                DbTransformar(quantidade),
                (DbTransformar(referenciaAlterada == null ? referencia : referenciaAlterada))));

            DefinirCadastrado();
        }
    }
}
