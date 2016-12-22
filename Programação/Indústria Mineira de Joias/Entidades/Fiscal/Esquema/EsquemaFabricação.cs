using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Text;
using System;

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

        public int Fechamento => fechamento;
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

        internal static EsquemaFabricação ObterÚnico(Fechamento fechamento, string referência)
        {
            var lista = Obter(fechamento, referência);

            if (lista.Count == 0)
                return null;

            return lista[0];
        }

        public static List<EsquemaFabricação> Obter(Fechamento fechamento)
        {
            return Obter(fechamento, null);
        }

        public static List<EsquemaFabricação> Obter(Fechamento fechamento, string referência)
        {
            return Mapear<EsquemaFabricação>("select e.*, m.nome as descricao, m.tipounidade, m.cfop from " + 
                " esquemafabricacaofiscal e join mercadoria m on e.referencia=m.referencia where fechamento=" + fechamento.Código
                + " AND e.referencia=" + (referência == null ? "e.referencia" : DbTransformar(referência)));
        }

        public static Dictionary<string, EsquemaFabricação> ObterHashEsquemas(Fechamento fechamento)
        {
            Dictionary<string, EsquemaFabricação> hash = new Dictionary<string, EsquemaFabricação>();
            var esquemas = Obter(fechamento, null);
            foreach (EsquemaFabricação esquema in esquemas)
                hash[esquema.Referência] = esquema;

            return hash;
        }

        public static void Excluir(List<EsquemaFabricação> seleção, Fechamento fechamento)
        {
            ExcluirEntidades(seleção, fechamento);
        }

        private static void ExcluirEntidades(List<EsquemaFabricação> seleção, Fechamento fechamento)
        {
            StringBuilder sql = new StringBuilder("delete from esquemafabricacaofiscal where fechamento=");
            sql.Append(fechamento.Código);

            sql.Append(" AND referencia in (");

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
