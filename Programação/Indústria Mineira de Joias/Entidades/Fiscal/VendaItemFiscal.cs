namespace Entidades.Fiscal
{
    public class VendaItemFiscal
    {
        private string referência;
        private string descrição;
        private int cfop;

        public VendaItemFiscal(string referência, string descrição, int cfop)
        {
            this.referência = referência;
            this.descrição = descrição;
            this.cfop = cfop;
        }

        public string Referência => referência;
        public string Descrição => descrição;

        public int CFOP => cfop;

        public TipoUnidade TipoUnidade { get; set; }
    }
}
