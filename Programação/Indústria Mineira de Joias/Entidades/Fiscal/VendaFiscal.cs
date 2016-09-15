using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class VendaFiscal
    {
        private DateTime dataEmissão;
        private TipoVenda tipoVenda;
        private string id;
        private List<VendaItemFiscal> itens;

        public VendaFiscal()
        {
        }

        public VendaFiscal(TipoVenda tipoVenda, DateTime dataEmissão, string id, List<VendaItemFiscal> itens)
        {
            this.tipoVenda = tipoVenda;
            this.dataEmissão = dataEmissão;
            this.id = id;
            this.itens = itens;
        }

        public TipoVenda TipoVenda => tipoVenda;
        public DateTime DataEmissão => dataEmissão;
        public string Id => id;
        public List<VendaItemFiscal> Itens => itens;
    }
}
