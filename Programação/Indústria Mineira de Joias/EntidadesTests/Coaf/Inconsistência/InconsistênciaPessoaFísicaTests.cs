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
            var pessoa = new Pessoa.PessoaFísica(cpf: "999999999999");
            Assert.IsFalse(new InconsistênciaPessoaFísica(pessoa).VerificarCpfVálido());
        }

        [TestMethod()]
        public void DeveDetectarCpfVálidoExplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica(cpf: "07676631602");
            Assert.IsTrue(new InconsistênciaPessoaFísica(pessoa).VerificarCpfVálido());
        }

        [TestMethod()]
        public void DeveDetectarCpfNuloExplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica(cpf: null);
            Assert.IsFalse(new InconsistênciaPessoaFísica(pessoa).VerificarCpfVálido());
        }

        [TestMethod()]
        public void DeveDetectarCpfInválidoImplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica(cpf: "999999999999");
            Assert.IsTrue(new InconsistênciaPessoaFísica(pessoa).ObterInconsistências().Contains(EnumInconsistência.CpfInválido));
        }


        [TestMethod()]
        public void DeveDetectaIdentidadeNulaExplicitamenteInválida()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                DI = null
            };

            Assert.IsFalse(new InconsistênciaPessoaFísica(pessoa).VerificarIdentidadeVálida());
        }

        [TestMethod()]
        public void DeveDetectaIdentidadePequenaExplicitamenteInválida()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                DI = "1234"
            };

            Assert.IsFalse(new InconsistênciaPessoaFísica(pessoa).VerificarIdentidadeVálida());
        }

        [TestMethod()]
        public void DeveDetectaIdentidadeVálidaComPontuação()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                DI = "12.345"
            };

            Assert.IsTrue(new InconsistênciaPessoaFísica(pessoa).VerificarIdentidadeVálida());
        }

        [TestMethod()]
        public void DeveDetectaIdentidadeVálidaSemPontuação()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                DI = "12345"
            };

            Assert.IsTrue(new InconsistênciaPessoaFísica(pessoa).VerificarIdentidadeVálida());
        }

        [TestMethod()]
        public void DeveDetectarIdentidadeInválidoImplicitamente()
        {
            var pessoa = new Pessoa.PessoaFísica()
            {
                DI = "bla"
            };

            Assert.IsTrue(new InconsistênciaPessoaFísica(pessoa).ObterInconsistências().Contains(EnumInconsistência.IdentidadeInválida));
        }
    }
}