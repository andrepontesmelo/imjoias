using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Data;

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
            foreach (ItemFiscal item in itens)
                item.Cadastrar(idSaídaFiscal, transação, conexão);
        }

        protected abstract string Relação { get; }

        protected abstract string RelaçãoPai { get; }

        private void Cadastrar(string idSaídaFiscal, IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO {0} ({1}, referencia, descricao, cfop, " +
                    "tipounidade, quantidade, valorunitario, valor) values ({2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})",
                    Relação,
                    RelaçãoPai,
                    DbTransformar(idSaídaFiscal),
                    DbTransformar(referência),
                    DbTransformar(descrição),
                    DbTransformar(cfop),
                    DbTransformar((byte) tipoUnidade),
                    DbTransformar(quantidade),
                    DbTransformar(valorUnitário),
                    DbTransformar(valor));

                cmd.ExecuteNonQuery();
            }
        }
    }
}
