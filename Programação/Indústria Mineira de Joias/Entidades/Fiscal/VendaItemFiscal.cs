using System;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades.Fiscal
{
    public class VendaItemFiscal : DbManipulaçãoSimples
    {
        private string referência;
        private string descrição;
        private int? cfop;
        private TipoUnidade tipoUnidade;
        private decimal quantidade;
        private decimal valorUnitário;
        private decimal valor;

        public VendaItemFiscal(string referência, string descrição, int? cfop,
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

        internal static void CadastrarItens(string idVendaFiscal, List<VendaItemFiscal> itens, IDbTransaction transação, IDbConnection conexão)
        {
            foreach (VendaItemFiscal item in itens)
                item.Cadastrar(idVendaFiscal, transação, conexão);
        }

        private void Cadastrar(string idVendaFiscal, IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO vendaitemfiscal (vendafiscal, referencia, descricao, cfop, " +
                    "tipounidade, quantidade, valorunitario, valor) values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                    DbTransformar(idVendaFiscal),
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
