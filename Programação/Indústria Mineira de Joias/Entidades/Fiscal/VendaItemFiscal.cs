namespace Entidades.Fiscal
{
    public class VendaItemFiscal
    {
        private string referência;

        public VendaItemFiscal(string referência)
        {
            this.referência = referência;
        }

        public string Referência => referência;
    }
}
