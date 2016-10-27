namespace Entidades.Fiscal.Pdf
{
    public class EntradaFiscalPdf : FiscalPdf
    {
        private static CacheIds cacheIds = new CacheIds("entradafiscalpdf");

        public EntradaFiscalPdf(string id, byte[] pdf) : base(id, pdf)
        {
        }

        public EntradaFiscalPdf()
        {
        }

        public static CacheIds Cache => cacheIds;
    }
}
