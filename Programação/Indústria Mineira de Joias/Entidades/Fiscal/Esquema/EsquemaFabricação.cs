using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Fiscal.Esquema
{
    [DbTabela("esquemafabricacaofiscal")]
    public class EsquemaFabricação : DbManipulaçãoAutomática
    {
        private string referencia;
        private string referenciaAlterada;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;
        private int cfop;
        private int fechamento;

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

        public EsquemaFabricação()
        {
        }

        public EsquemaFabricação(Fechamento fechamento)
        {
            quantidade = 1;
            this.fechamento = fechamento.Código;
        }

        public static List<EsquemaFabricação> Obter(Fechamento fechamento)
        {
            return Mapear<EsquemaFabricação>("select e.*, m.nome as descricao, m.tipounidade, m.cfop from " + 
                " esquemafabricacaofiscal e join mercadoria m on e.referencia=m.referencia where fechamento=" + fechamento.Código);
        }

        public static Dictionary<string, EsquemaFabricação> ObterHash(Fechamento fechamento)
        {
            var esquemas = Obter(fechamento);
            Dictionary<string, EsquemaFabricação> hash = new Dictionary<string, Esquema.EsquemaFabricação>();
            foreach (var esquema in esquemas)
                hash[esquema.referencia] = esquema;

            return hash;
        }

        public static void Excluir(List<EsquemaFabricação> seleção)
        {
            ExcluirEntidades(seleção);
        }

        private static void ExcluirEntidades(List<EsquemaFabricação> seleção)
        {
            StringBuilder sql = new StringBuilder("delete from esquemafabricacaofiscal where referencia in (");

            bool primeiro = true;
            foreach (EsquemaFabricação e in seleção)
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
        }

        private void AtualizarEntidade()
        {
            ExecutarComando(string.Format("UPDATE esquemafabricacaofiscal set quantidade={0}, referencia={1} WHERE referencia={2} and fechamento={3}",
                DbTransformar(quantidade),
                (DbTransformar(referenciaAlterada == null ? referencia : referenciaAlterada)),
                DbTransformar(referencia),
                DbTransformar(fechamento)));

            DefinirAtualizado();
        }

        private void CadastrarEntidade()
        {
            ExecutarComando(string.Format("INSERT INTO esquemafabricacaofiscal (quantidade, referencia, fechamento) values ({0}, {1}, {2})",
                DbTransformar(quantidade),
                (DbTransformar(referenciaAlterada == null ? referencia : referenciaAlterada)),
                DbTransformar(fechamento)));

            DefinirCadastrado();
        }
    }
}
