using IMJWeb.Dominio.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IMJWeb.Teste
{
    /// <summary>
    ///This is a test class for RegiaoFlyweightTest and is intended
    ///to contain all RegiaoFlyweightTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RegiaoFlyweightTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ObterRegiao
        ///</summary>
        [TestMethod()]
        public void ObterRegiaoTest()
        {
            Random random = new Random();

            var CriarRegiao = new Func<long, TabelaFlyweight>(id =>
            {
                TabelaFlyweight actual;

                actual = TabelaFlyweight.ObterRegiao(id);

                Assert.IsNotNull(actual);
                Assert.AreEqual(id, actual.IDTabela);
                Assert.AreSame(actual, TabelaFlyweight.ObterRegiao(id), "Não foi obtido o mesmo objeto flyweight.");

                return actual;
            });

            long id1 = random.Next(100), id2;
            
            do
            {
                id2 = random.Next(100);
            } while (id2 == id1);

            var r1 = CriarRegiao(id1);
            var r2 = CriarRegiao(id2);

            Assert.AreNotSame(r1, r2, "Objetos para regiões diferentes são o mesmo.");
            Assert.AreNotEqual(r1, r2, "Objetos para regiões diferentes são equivalentes.");
            Assert.AreNotEqual(r1.IDTabela, r2.IDTabela, "IDs para regiões são os mesmos.");
        }
    }
}
