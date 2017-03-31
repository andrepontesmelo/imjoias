using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Pessoa.Tests
{
    [TestClass()]
    public class PessoaFísicaTests
    {
        [TestMethod()]
        public void DeveAceitarCPFVálido()
        {
            Assert.IsTrue(PessoaFísica.ValidarCPF("07676631602"));
        }

        [TestMethod()]
        public void NãoDeveAceitarCPFInválidoNumérico()
        {
            Assert.IsFalse(PessoaFísica.ValidarCPF("07676631699"));
        }

        [TestMethod()]
        public void NãoDeveAceitarCPFVazio()
        {
            Assert.IsFalse(PessoaFísica.ValidarCPF(""));
        }

        [TestMethod()]
        public void NãoDeveAceitarCPFEmBranco()
        {
            Assert.IsFalse(PessoaFísica.ValidarCPF("           "));
        }

        [TestMethod()]
        public void NãoDeveAceitarCPFInválidoTexto()
        {
            Assert.IsFalse(PessoaFísica.ValidarCPF("aaabbbccccc"));
        }
    }
}