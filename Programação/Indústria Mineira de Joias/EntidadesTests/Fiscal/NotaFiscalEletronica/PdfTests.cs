using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Fiscal.NotaFiscalEletronica.Tests
{
    [TestClass()]
    public class PdfTests
    {
        [TestMethod()]
        public void DeveExtrairNfeEntreEspaços()
        {
            Assert.AreEqual(303, Pdf.ExtrairNfe("Relojoaria Bahia Ltda 000303 19052015.pdf"));
        }

        [TestMethod()]
        public void DeveExtrairNfeSozinho()
        {
            Assert.AreEqual(303, Pdf.ExtrairNfe("000303.pdf"));
        }

    }
}