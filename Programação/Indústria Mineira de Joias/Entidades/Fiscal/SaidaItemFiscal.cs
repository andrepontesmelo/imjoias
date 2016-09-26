using Acesso.Comum;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class SaidaItemFiscal : DbManipulaçãoSimples
    {
        private string referência;
        private string descrição;
        private int? cfop;
        private TipoUnidade tipoUnidade;
        private decimal quantidade;
        private decimal valorUnitário;
        private decimal valor;

        public SaidaItemFiscal(string referência, string descrição, int? cfop,
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

        internal static void CadastrarItens(string idSaídaFiscal, List<SaidaItemFiscal> itens, IDbTransaction transação, IDbConnection conexão)
        {
            foreach (SaidaItemFiscal item in itens)
                item.Cadastrar(idSaídaFiscal, transação, conexão);
        }

        private void Cadastrar(string idSaídaFiscal, IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO saidaitemfiscal (saidafiscal, referencia, descricao, cfop, " +
                    "tipounidade, quantidade, valorunitario, valor) values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
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
