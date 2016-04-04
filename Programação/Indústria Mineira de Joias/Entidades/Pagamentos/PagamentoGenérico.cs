using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Relacionamento.Venda;
using System.Data;

namespace Entidades.Pagamentos
{
    /// <summary>
    /// Classe com informações genéricas de um pagamento.
    /// </summary>
    /// <remarks>
    /// Esta classe é utilizada para cálculo rápido de pagamento de dívida.
    /// </remarks>
    [DbTabela("pagamento")]
    public class PagamentoGenérico : DbManipulaçãoAutomática, IPagamento
    {
#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'
        [DbChavePrimária()]
        [DbColuna("codigo")]
        private long código;
        private ulong cliente;
        private double valor;
        private DateTime data;
        private DateTime vencimento;
        private ulong registradoPor;
        private bool pendente;
        private bool cobrarJuros;
        private long vendas;
#pragma warning restore 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        public long Código
        {
            get { return código; }
        }

        public ulong Cliente
        {
            get { return cliente; }
        }

        public double Valor
        {
            get { return valor; }
        }

        public DateTime Data
        {
            get { return data; }
        }

        public DateTime ÚltimoVencimento
        {
            get { return vencimento; }
        }

        public Entidades.Pessoa.Funcionário RegistradoPor
        {
            get { return registradoPor; }
        }

        public bool Pendente
        {
            get { return pendente; }
            set { pendente = value; }
        }

        public bool CobrarJuros
        {
            get { return cobrarJuros; }
            set { cobrarJuros = value; }
        }

        public bool Compartilhado { get { return vendas > 1; } }

        public static IPagamento[] ObterPagamentos(IDadosVenda venda)
        {
            return Mapear<PagamentoGenérico>(
                string.Format(
                    "SELECT t.*, COUNT(*) AS vendas FROM"
                    + " ((SELECT p.codigo, p.cliente, p.valor, p.data, p.data AS vencimento, p.registradoPor, p.pendente FROM dinheiro d"
                    + " JOIN pagamento p ON d.codigo = p.codigo"
                    + " JOIN vinculovendapagamento v ON v.pagamento = p.codigo"
                    + " AND v.venda = {0})"
                    + " UNION (SELECT p.codigo, p.cliente, p.valor, p.data, p.data AS vencimento, p.registradoPor, p.pendente FROM credito cr"
                    + " JOIN pagamento p ON cr.codigo = p.codigo"
                    + " JOIN vinculovendapagamento v ON v.pagamento = p.codigo"
                    + " AND v.venda = {0})"
                    + " UNION (SELECT p.codigo, p.cliente, p.valor, p.data, n.vencimento, p.registradoPor, p.pendente FROM notapromissoria n"
                    + " JOIN pagamento p ON n.codigo = p.codigo"
                    + " JOIN vinculovendapagamento v ON v.pagamento = p.codigo"
                    + " AND v.venda = {0})"
                    + " UNION (SELECT p.codigo, p.cliente, p.valor, p.data, if(c.prorrogadopara is null, c.vencimento, c.prorrogadopara) as vencimento, p.registradoPor, p.pendente FROM cheque c"
                    + " JOIN pagamento p ON c.codigo = p.codigo"
                    + " JOIN vinculovendapagamento v ON v.pagamento = p.codigo"
                    + " AND v.venda = {0}))"
                    + " t JOIN vinculovendapagamento v ON v.pagamento = t.codigo"
                    + " GROUP BY t.codigo, t.cliente, t.valor, t.data, t.vencimento, t.registradoPor, t.pendente",
                    DbTransformar(venda.Código))).ToArray();
        }

        public static void MarcarPendência(long código, bool pendente)
        {
            using (IDbConnection conexão = Conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "update pagamento set pendente = " + DbTransformar(pendente)
                        + " where codigo = " + DbTransformar(código);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
