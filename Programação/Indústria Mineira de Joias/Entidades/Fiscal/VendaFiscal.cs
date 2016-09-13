using System;

namespace Entidades.Fiscal
{
    public class VendaFiscal
    {
        private DateTime dataEmissão;
        private TipoVenda tipoVenda;

        public VendaFiscal()
        {
        }

        public VendaFiscal(TipoVenda tipoVenda, DateTime dataEmissão)
        {
            this.tipoVenda = TipoVenda;
            this.dataEmissão = dataEmissão;
        }

        public TipoVenda TipoVenda => tipoVenda;
        public DateTime DataEmissão => dataEmissão;
    }
}
