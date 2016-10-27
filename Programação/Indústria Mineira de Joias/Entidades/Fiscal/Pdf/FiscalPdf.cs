using Acesso.Comum;

namespace Entidades.Fiscal.Pdf
{
    public abstract class FiscalPdf : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        protected string id;
        protected byte[] pdf;

        public FiscalPdf(string id, byte[] pdf)
        {
            this.id = id;
            this.pdf = pdf;
        }

        public FiscalPdf()
        {
        }

        public string Id => id;
        public byte[] Pdf => pdf;
    }
}
