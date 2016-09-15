namespace Entidades.Fiscal
{
    public class VendaItemFiscal
    {
        private string referência;
        private string descrição;

        public VendaItemFiscal(string referência, string descrição)
        {
            this.referência = referência;
            this.descrição = descrição;
        }

        public string Referência => referência;
        public string Descrição => descrição;
    }
}
