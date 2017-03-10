using Entidades.Coaf.Inconsistência;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Fiscal.Cupom.Tests
{
    [TestClass()]
    public class InconsistênciaPessoaFísicaTests
    {
        [TestMethod()]
        public void DeveDetectarCpfInválidoExplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                CPF = "999999999999"
            };

            Assert.IsFalse(new InconsistênciaPessoaFísica(pessoa).VerificarCpfVálido());
        }

        [TestMethod()]
        public void DeveDetectarCpfVálidoExplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                CPF = "07676631602"
            };

            Assert.IsTrue(new InconsistênciaPessoaFísica(pessoa).VerificarCpfVálido());
        }

        [TestMethod()]
        public void DeveDetectarCpfNuloExplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                CPF = null
            };

            Assert.IsFalse(new InconsistênciaPessoaFísica(pessoa).VerificarCpfVálido());
        }

        [TestMethod()]
        public void DeveDetectarCpfInválidoImplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                CPF = "999999999999"
            };

            Assert.IsTrue(new InconsistênciaPessoaFísica(pessoa).ObterInconsistências().Contains(EnumInconsistência.CpfInválido));
        }
    }
}