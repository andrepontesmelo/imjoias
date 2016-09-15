namespace Entidades.Fiscal
{
    public class VendaItemFiscal
    {
        private string referência;
        private string descrição;
        private int cfop;
        private TipoUnidade tipoUnidade;

        public VendaItemFiscal(string referência, string descrição, int cfop, TipoUnidade tipoUnidade)
        {
            this.referência = referência;
            this.descrição = descrição;
            this.cfop = cfop;
            this.tipoUnidade = tipoUnidade;
        }

        public string Referência => referência;
        public string Descrição => descrição;
        public int CFOP => cfop;
        public TipoUnidade TipoUnidade => tipoUnidade;
    }
}
