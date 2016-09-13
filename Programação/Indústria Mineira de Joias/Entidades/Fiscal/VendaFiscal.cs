using System;

namespace Entidades.Fiscal
{
    public class VendaFiscal
    {
        private DateTime dataEmissão;
        private TipoVenda tipoVenda;
        private bool cancelamento;

        public VendaFiscal()
        {
        }

        public VendaFiscal(TipoVenda tipoVenda, DateTime dataEmissão, bool cancelamento)
        {
            this.tipoVenda = tipoVenda;
            this.dataEmissão = dataEmissão;
            this.cancelamento = cancelamento;
        }

        public TipoVenda TipoVenda => tipoVenda;
        public DateTime DataEmissão => dataEmissão;
        public bool Cancelamento => cancelamento;
    }
}
