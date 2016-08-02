using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace Entidades.Fiscal.NotaFiscalEletronica.Tests
{
    [TestClass()]
    public class ParserXmlTests
    {
        private static string ARQUIVO_ENTRADA = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\nfe.xml";

        ParserXml parser;

        [TestInitialize]
        public void PreparaTestes()
        {
            parser = ParserXml.LerArquivo(ARQUIVO_ENTRADA);
        }

        [TestMethod()]
        public void DeveLerQuantidadeVendaItens()
        {
            Assert.AreEqual(28, parser.QuantidadeVendaItem);
        }

        [TestMethod()]
        public void DeveLerTipoUnidade()
        {
            Assert.AreEqual(TipoUnidade.Pca, parser.ObterTipoUnidade(10));
        }

        [TestMethod()]
        public void DeveLerReferência()
        {
            Assert.AreEqual("202459001007", parser.ObterReferência(10));
        }

        [TestMethod()]
        public void DeveLerQuantidadeItens()
        {
            Assert.AreEqual(5, parser.ObterQuantidadeItens(11));
        }

        [TestMethod()]
        public void DeveLerValorUnitario()
        {
            Assert.AreEqual(132, parser.ObterValorUnitario(11));
        }

        [TestMethod()]
        public void DeveLerValor()
        {
            Assert.AreEqual(660, parser.ObterValorUnitario(11));
        }

        [TestMethod()]
        public void DeveLerDescrição()
        {
            Assert.AreEqual("Cordao de Ouro", parser.ObterDescrição(11));
        }
    }
}