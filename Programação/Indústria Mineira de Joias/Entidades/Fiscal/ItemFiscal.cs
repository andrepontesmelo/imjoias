using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades.Fiscal
{
    public abstract class ItemFiscal : DbManipulaçãoSimples
    {
        private string referência;
        private string descrição;
        private int? cfop;
        private TipoUnidade tipoUnidade;
        private decimal quantidade;
        private decimal valorUnitário;
        private decimal valor;

        public ItemFiscal(string referência, string descrição, int? cfop,
            TipoUnidade tipoUnidade, decimal quantidade, decimal valorUnitário,
            decimal valor)
        {
            this.referência = referência;
            this.descrição = descrição;
            this.cfop = cfop;
            this.tipoUnidade = tipoUnidade;
            this.quantidade = quantidade;
            this.valorUnitário = valorUnitário;
            this.valor = valor;
        }

        public string Referência => referência;
        public string Descrição => descrição;
        public int? CFOP => cfop;
        public TipoUnidade TipoUnidade => tipoUnidade;
        public decimal Quantidade => quantidade;
        public decimal ValorUnitário => valorUnitário;
        public decimal Valor => valor;

        internal static void CadastrarItens(string idSaídaFiscal, List<ItemFiscal> itens, IDbTransaction transação, IDbConnection conexão)
        {
            if (itens.Count == 0)
                return;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = ObterSqlInserção(idSaídaFiscal, itens);
                cmd.ExecuteNonQuery();
            }
        }

        private static string ObterSqlInserção(string idSaídaFiscal, List<ItemFiscal> itens)
        {
            var sql = new StringBuilder(string.Format("INSERT INTO {0} ({1}, referencia, descricao, cfop, " +
                "tipounidade, quantidade, valorunitario, valor) values (", itens[0].Relação, itens[0].RelaçãoPai));

            bool primeiro = true;

            foreach (ItemFiscal item in itens)
            {
                if (!primeiro)
                    sql.Append(",(");

                sql.Append(DbTransformar(idSaídaFiscal) + ",");
                sql.Append(DbTransformar(item.referência) + ",");
                sql.Append(DbTransformar(item.descrição) + ",");
                sql.Append(DbTransformar(item.cfop) + ",");
                sql.Append(DbTransformar((byte)item.tipoUnidade) + ",");
                sql.Append(DbTransformar(item.quantidade) + ",");
                sql.Append(DbTransformar(item.valorUnitário) + ",");
                sql.Append(DbTransformar(item.valor));

                sql.Append(")");
                primeiro = false;
            }

            return sql.ToString();
        }

        protected abstract string Relação { get; }

        protected abstract string RelaçãoPai { get; }
    }
}
