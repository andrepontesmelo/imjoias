using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Mercadoria.Tests
{
    [TestClass()]
    public class MercadoriaTests
    {
        [TestMethod()]
        public void DeveMascararReferência11Dígitos()
        {
            Assert.AreEqual("999.000.00.021", Mercadoria.MascararReferência("99900000021"));
        }

        [TestMethod()]
        public void DeveMascararReferência8Dígitos()
        {
            Assert.AreEqual("123.456.78", Mercadoria.MascararReferência("12345678"));
        }

        [TestMethod()]
        public void NãoDeveMascararReferência7Dígitos()
        {
            Assert.AreEqual("1234567", Mercadoria.MascararReferência("1234567"));
        }
    }
}