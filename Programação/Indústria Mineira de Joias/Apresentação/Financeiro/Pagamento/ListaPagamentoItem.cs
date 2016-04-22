using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Financeiro.Pagamento
{
    public class ListaPagamentoItem
    {
        private Entidades.Pagamentos.Pagamento pagamento;
        private DateTime? prorrogadoPara;
        private DateTime? vencimento;
        private double valorLíquido;
        private int dias;

        public int Dias
        {
            get { return dias; }
            set { dias = value; }
        }

        public DateTime? ProrrogadoPara
        {
            get { return prorrogadoPara; }
            set { prorrogadoPara = value; }
        }

        public DateTime? Vencimento
        {
            get { return vencimento; }
            set { vencimento = value; }
        }

        public double ValorLíquido
        {
            get { return valorLíquido; }
            set { valorLíquido = value; }
        }

        public Entidades.Pagamentos.Pagamento Pagamento
        {
            get { return pagamento; }
        }

        public ListaPagamentoItem(Entidades.Pagamentos.Pagamento pagamento)
        {
            this.pagamento = pagamento;
        }
    }
}
