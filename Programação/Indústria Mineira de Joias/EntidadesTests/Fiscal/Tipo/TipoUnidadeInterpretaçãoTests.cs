using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Fiscal.Tipo.Tests
{
    [TestClass()]
    public class TipoUnidadeInterpretaçãoTests
    {
        [TestMethod()]
        public void DeveInterpretarGramas()
        {
            Assert.AreEqual(TipoUnidadeSistema.Grs, TipoUnidadeInterpretação.Interpretar("gramas"));
        }

        [TestMethod()]
        public void DeveInterpretarUnidade()
        {
            Assert.AreEqual(TipoUnidadeSistema.Un, TipoUnidadeInterpretação.Interpretar("un"));
        }

        [TestMethod()]
        public void DeveInterpretarPar()
        {
            Assert.AreEqual(TipoUnidadeSistema.Par, TipoUnidadeInterpretação.Interpretar("par"));
        }

        [TestMethod()]
        public void DeveInterpretarPeça()
        {
            Assert.AreEqual(TipoUnidadeSistema.Pca, TipoUnidadeInterpretação.Interpretar("pca"));
        }

        [TestMethod()]
        public void DeveInterpretarBobina()
        {
            Assert.AreEqual(TipoUnidadeSistema.Un, TipoUnidadeInterpretação.Interpretar("bob"));
        }

        [TestMethod()]
        public void DeveInterpretarCaixa()
        {
            Assert.AreEqual(TipoUnidadeSistema.Cxa, TipoUnidadeInterpretação.Interpretar("cxa"));
        }

        [TestMethod()]
        public void DeveInterpretarQuilate()
        {
            Assert.AreEqual(TipoUnidadeSistema.Klt, TipoUnidadeInterpretação.Interpretar("KLT"));
        }

    }
}