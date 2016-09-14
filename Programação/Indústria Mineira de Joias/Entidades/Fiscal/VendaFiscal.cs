using System;

namespace Entidades.Fiscal
{
    public class VendaFiscal
    {
        private DateTime dataEmissão;
        private TipoVenda tipoVenda;
        private string id;

        public VendaFiscal()
        {
        }

        public VendaFiscal(TipoVenda tipoVenda, DateTime dataEmissão, string id)
        {
            this.tipoVenda = tipoVenda;
            this.dataEmissão = dataEmissão;
            this.id = id;
        }

        public TipoVenda TipoVenda => tipoVenda;
        public DateTime DataEmissão => dataEmissão;
        public string Id => id;
    }
}
