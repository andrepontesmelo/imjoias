using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Moedas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Apresentação.Mercadoria.Cotação.Tests
{
    [TestClass()]
    public class TxtCotaçãoTests
    {
        [TestMethod()]
        public void TxtCotaçãoTest()
        {
            Aplicação.Executar(new Acesso.MySQL.MySQLUsuários(), true, new Splash());
            
            //var repo = new MockRepository(MockBehavior.Loose);
            //Mock<MoedaObtenção> moedaObtenção = repo.Create<MoedaObtenção>();
            //Moeda x = new Moeda();
            //moedaObtenção.Setup(u => u.ObterMoeda(MoedaSistema.Ouro)).Returns(x);
            //MoedaObtenção.Instância = moedaObtenção.Object;

            //Mock<DadosGlobais> globais = repo.Create<DadosGlobais>();
            //DadosGlobais.Instância = globais.Object;


            TxtCotação caixa = new TxtCotação();
            //var consumidor = caixa;
            //caixa.Consume(mockMoeda);

            caixa.Carregar();
            Assert.AreEqual(151, caixa.Valor);
        }
    }
}