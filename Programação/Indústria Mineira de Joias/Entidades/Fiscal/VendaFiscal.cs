using System;

namespace Entidades.Fiscal
{
    public class VendaFiscal
    {
        private DateTime dataEmissão;

        public VendaFiscal()
        {
        }

        public VendaFiscal(DateTime dataEmissão)
        {
            this.dataEmissão = dataEmissão;
        }

        public DateTime DataEmissão => dataEmissão;
    }
}
