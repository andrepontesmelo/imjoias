using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Pessoa.Tests
{
    [TestClass()]
    public class PessoaJurídicaTests
    {
        [TestMethod()]
        public void DeveValidarCNPJNãoNumérico()
        {
            Assert.IsFalse(PessoaJurídica.ValidarCNPJ("patricia nubia"));
        }

        [TestMethod()]
        public void DeveValidarCNPJVálidoFormatado()
        {
            Assert.IsTrue(PessoaJurídica.ValidarCNPJ("46.515.861/0001-03"));
        }

        [TestMethod()]
        public void DeveValidarCNPJVálidoNãoFormatado()
        {
            Assert.IsTrue(PessoaJurídica.ValidarCNPJ("46515861000103"));
        }


        [TestMethod()]
        public void DeveValidarCNPJInválido()
        {
            Assert.IsFalse(PessoaJurídica.ValidarCNPJ("46.515.861/9999-03"));
        }

        [TestMethod()]
        public void DeveValidarCNPJInválidoPequeno()
        {
            Assert.IsFalse(PessoaJurídica.ValidarCNPJ("123"));
        }
    }
}