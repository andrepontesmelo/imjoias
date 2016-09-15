namespace Entidades.Fiscal
{
    public class VendaItemFiscal
    {
        private string referência;
        private string descrição;
        private int cfop;
        private TipoUnidade tipoUnidade;
        private decimal quantidade;

        public VendaItemFiscal(string referência, string descrição, int cfop, 
            TipoUnidade tipoUnidade, decimal quantidade)
        {
            this.referência = referência;
            this.descrição = descrição;
            this.cfop = cfop;
            this.tipoUnidade = tipoUnidade;
            this.quantidade = quantidade;
        }

        public string Referência => referência;
        public string Descrição => descrição;
        public int CFOP => cfop;
        public TipoUnidade TipoUnidade => tipoUnidade;
        public decimal Quantidade => quantidade;

        public double ValorUnitário { get; set; }
    }
}
