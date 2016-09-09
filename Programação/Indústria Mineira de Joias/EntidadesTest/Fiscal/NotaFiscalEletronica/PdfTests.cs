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

        [TestMethod()]
        public void DeveExtrairNfeNoFinal()
        {
            Assert.AreEqual(292, Pdf.ExtrairNfe("S&I Comercio e Repres. Ltda 03022015 000292.pdf"));
        }

        [TestMethod()]
        public void DeveIgnorarArquivoMaiusculo()
        {
            Assert.AreEqual(292, Pdf.ExtrairNfe("S&I Comercio e Repres. Ltda 03022015 000292.PDF"));
        }

        [TestMethod()]
        [ExpectedException(typeof(ExcessãoNãoPodeExtrairNfeNomeArquivo))]
        public void NaoDeveExtrairNumeroQualquerNoFinal()
        {
             Pdf.ExtrairNfe("S&I Comercio e Repres. Ltda 03022015292.pdf");
        }

        [TestMethod()]
        [ExpectedException(typeof(ExcessãoNãoPodeExtrairNfeNomeArquivo))]
        public void NaoDeveExtrairMaisUmCódigo()
        {
            Pdf.ExtrairNfe("Bla 000001 000002 Ltda.pdf");
        }

        [TestMethod()]
        [ExpectedException(typeof(ExcessãoNãoPodeExtrairNfeNomeArquivo))]
        public void NãoDeveExtrairNfeInternoSemEspaço()
        {
            Assert.AreEqual(42, Pdf.ExtrairNfe("danfe000042-20042010.pdf"));
        }
    }
}