namespace Entidades.Fiscal
{
    public class VendaItemFiscal
    {
        private string referência;
        private string descrição;
        private int? cfop;
        private TipoUnidade tipoUnidade;
        private decimal quantidade;
        private decimal valorUnitário;
        private decimal valor;

        public VendaItemFiscal(string referência, string descrição, int? cfop, 
            TipoUnidade tipoUnidade, decimal quantidade, decimal valorUnitário,
            decimal valor)
        {
            this.referência = referência;
            this.descrição = descrição;
            this.cfop = cfop;
            this.tipoUnidade = tipoUnidade;
            this.quantidade = quantidade;
            this.valorUnitário = valorUnitário;
            this.valor = valor;
        }

        public string Referência => referência;
        public string Descrição => descrição;
        public int? CFOP => cfop;
        public TipoUnidade TipoUnidade => tipoUnidade;
        public decimal Quantidade => quantidade;
        public decimal ValorUnitário => valorUnitário;
        public decimal Valor => valor;
    }
}
