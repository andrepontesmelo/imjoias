using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Pessoa.Tests
{
    [TestClass()]
    public class AbreviadorTests
    {
        [TestMethod()]
        public void DeveReduzirNomeÚnico()
        {
            Assert.AreEqual<string>("André", Abreviador.AbreviarNome("André"));
        }

        [TestMethod()]
        public void DeveReduzirNomeComposto()
        {
            Assert.AreEqual<string>("Maria J.", Abreviador.AbreviarNome("Maria José"));
        }

        [TestMethod()]
        public void DeveUsarApenasÚltimoSobrenome()
        {
            Assert.AreEqual<string>("Maria U.", Abreviador.AbreviarNome("Maria Primeiro Meio Ultimo"));
        }

        [TestMethod()]
        public void DeveIgnorarRepresentante()
        {
            Assert.AreEqual<string>("Tiago C.", Abreviador.AbreviarNome("Tiago Melo Correa Representante"));
        }

        [TestMethod()]
        public void DeveIgnorarFuncionário()
        {
            Assert.AreEqual<string>("Hoffman A.", Abreviador.AbreviarNome("Hoffman Abreu Funcionário"));
        }

        [TestMethod()]
        public void DeveIgnorarFuncionario()
        {
            Assert.AreEqual<string>("Hoffman A.", Abreviador.AbreviarNome("Hoffman Abreu Funcionario"));
        }

        [TestMethod()]
        public void DeveIgnorarFuncionária()
        {
            Assert.AreEqual<string>("Maria", Abreviador.AbreviarNome("Maria Funcionária"));
        }

        [TestMethod()]
        public void DeveIgnorarFuncionaria()
        {
            Assert.AreEqual<string>("Maria R.", Abreviador.AbreviarNome("Maria Rodrigues Funcionaria"));
        }

        [TestMethod()]
        public void DeveIgnorarHífen()
        {
            Assert.AreEqual<string>("Ilson S.", Abreviador.AbreviarNome("Ilson Sobrenome - Funcionário"));
        }

        [TestMethod()]
        public void DeveAbreviarJunior()
        {
            Assert.AreEqual<string>("Tiago Jr.", Abreviador.AbreviarNome("Tiago Correa Junior"));
        }

        [TestMethod()]
        public void NãoDeveAbreviarNomesJáAbreviadosComuns()
        {
            Assert.AreEqual<string>("Maria A.", Abreviador.AbreviarNome("Maria A."));
        }

        [TestMethod()]
        public void NãoDeveAbreviarNomesJáAbreviadosEspeciais()
        {
            Assert.AreEqual<string>("José Jr.", Abreviador.AbreviarNome("José Jr."));
        }

        [TestMethod()]
        public void DeveAcrescentarPontoNomesJáAbreviados()
        {
            Assert.AreEqual<string>("José Jr.", Abreviador.AbreviarNome("José Jr"));
        }

    }
}