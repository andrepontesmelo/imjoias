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
        public void DeveLerTipoUnidadePar()
        {
            Assert.AreEqual(TipoUnidade.Par, parser.ObterTipoUnidade(1));
        }

        [TestMethod()]
        public void DeveLerTipoUnidadeParPeça()
        {
            Assert.AreEqual(TipoUnidade.Pca, parser.ObterTipoUnidade(2));
        }

        [TestMethod()]
        public void DeveLerReferência()
        {
            Assert.AreEqual("108025101006", parser.ObterReferência(12));
        }

        [TestMethod()]
        public void DeveLerQuantidadeItens()
        {
            Assert.AreEqual(2, parser.ObterQuantidadeItens(12));
        }

        [TestMethod()]
        public void DeveLerValorUnitario()
        {
            Assert.AreEqual(71.57M, parser.ObterValorUnitario(12));
        }

        [TestMethod()]
        public void DeveLerValor()
        {
            Assert.AreEqual(143.14M, parser.ObterValor(12));
        }

        [TestMethod()]
        public void DeveLerDescrição()
        {
            Assert.AreEqual("Gargantilha de Ouro", parser.ObterDescrição(11));
        }
    }
}