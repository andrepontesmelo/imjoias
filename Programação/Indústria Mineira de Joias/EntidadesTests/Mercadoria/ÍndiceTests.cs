using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Mercadoria.Tests
{
    [TestClass()]
    public class ÍndiceTests
    {
        [TestMethod()]
        public void DeveCalcularCoeficienteDePeçaSemArredondamentoTest()
        {
            Assert.AreEqual(1.5, Índice.Calcular(1.5, 2, false, false));
        }

        [TestMethod()]
        public void DeveCalcularCoeficienteDePesoSemArredondamentoTest()
        {
            Assert.AreEqual(3, Índice.Calcular(1.5, 2, true, false));
        }

        [TestMethod()]
        public void DeveCalcularCoeficienteDePeçaComArredondamentoTest()
        {
            Assert.AreEqual(1.33, Índice.Calcular(1.329, 2, false, true));
        }

        [TestMethod()]
        public void DeveCalcularCoeficienteDePesoComArredondamentoTest()
        {
            Assert.AreEqual(2.66, Índice.Calcular(1.329, 2, true, true));
        }
    }
}