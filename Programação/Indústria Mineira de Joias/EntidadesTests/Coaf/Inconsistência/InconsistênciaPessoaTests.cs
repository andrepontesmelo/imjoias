using Entidades.Coaf.Inconsistência;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Fiscal.Cupom.Tests
{
    [TestClass()]
    public class InconsistênciaPessoaTests
    {
        [TestMethod()]
        public void DeveDetectarNomeInválidoExplicitamente()
        {
            var pessoa = new Pessoa.Pessoa()
            {
                Nome = "nome curto"
            };

            Assert.IsFalse(new InconsistênciaPessoa(pessoa).VerificarNomeConsistente());
        }

        [TestMethod()]
        public void DeveDetectarNomeVálidoExplicitamente()
        {
            var pessoa = new Pessoa.Pessoa()
            {
                Nome = "Maria das Dores Pereira Albuquerque"
            };

            Assert.IsTrue(new InconsistênciaPessoa(pessoa).VerificarNomeConsistente());
        }

        [TestMethod()]
        public void DeveDetectarNomeInválidoImplicitamente()
        {
            var pessoa = new Pessoa.Pessoa()
            {
                Nome = "nome curto"
            };

            Assert.IsTrue(new InconsistênciaPessoa(pessoa).ObterInconsistências().Contains(EnumInconsistência.NomeInválido));
        }
    }
}