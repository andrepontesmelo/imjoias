using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Fiscal.Tests
{
    [TestClass()]
    public class InventárioTests
    {
        [TestMethod()]
        public void DeveFormatarClassificaçãoFiscal()
        {
            var inventário = new Inventário();
            inventário.ClassificaçãoFiscal = "7113190100";

            Assert.AreEqual("711.31.9.01.00", inventário.ClassificaçãoFiscalFormatada);
        }

        [TestMethod()]
        public void DeveFormatarClassificaçãoFiscalMenor10Dígitos()
        {
            var inventário = new Inventário();
            inventário.ClassificaçãoFiscal = "113190100";

            Assert.AreEqual("011.31.9.01.00", inventário.ClassificaçãoFiscalFormatada);
        }

        [TestMethod()]
        public void DeveFormatarClassificaçãoFiscalMaior10Dígitos()
        {
            var inventário = new Inventário();
            inventário.ClassificaçãoFiscal = "7113190100A";

            Assert.AreEqual("711.31.9.01.00", inventário.ClassificaçãoFiscalFormatada);
        }

        [TestMethod()]
        public void DeveFormatarClassificaçãoFiscalNula()
        {
            var inventário = new Inventário();
            Assert.AreEqual("000.00.0.00.00", inventário.ClassificaçãoFiscalFormatada);
        }
    }
}