using Entidades.Fiscal;
using Entidades.Fiscal.Tipo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Fiscal.Tests
{
    [TestClass()]
    public class ExtratoTests
    {
        [TestMethod()]
        public void ExtratoEntradaDeveSerTipoEntrada()
        {
            Assert.AreEqual("E", new Extrato("E").EntradaSaída);
        }

        [TestMethod()]
        public void ExtratoSaídaDeveSerTipoSaída()
        {
            Assert.AreEqual("S", new Extrato("S").EntradaSaída);
        }


        [TestMethod()]
        public void ExtratoTODeveSerTipoEntrada()
        {
            Assert.AreEqual("E", new Extrato("TO").EntradaSaída);
        }


        [TestMethod()]
        public void ExtratoOTDeveSerTipoSaída()
        {
            Assert.AreEqual("S", new Extrato("OT").EntradaSaída);
        }

        [TestMethod()]
        public void TipoResumidoDeveSerOTQuandoItemConsumido()
        {
            Assert.AreEqual("OT", new Extrato("OT").TipoResumido);
        }

        [TestMethod()]
        public void TipoResumidoDeveSerTOQuandoItemFabricado()
        {
            Assert.AreEqual("TO", new Extrato("TO").TipoResumido);
        }

        [TestMethod()]
        public void CupomDeveSerResumido()
        {
            var cupom = new Extrato("S", (int) TipoDocumentoSistema.Cupom);
            Assert.AreEqual("CP", cupom.TipoResumido);
        }

        [TestMethod()]
        public void NotaDeveSerResumido()
        {
            var cupom = new Extrato("S", (int) TipoDocumentoSistema.NFe);
            Assert.AreEqual("NF", cupom.TipoResumido);
        }
    }
}