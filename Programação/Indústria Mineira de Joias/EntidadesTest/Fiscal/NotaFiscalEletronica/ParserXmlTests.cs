using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace Entidades.Fiscal.NotaFiscalEletronica.Tests
{
    [TestClass()]
    public class ParserXmlTests
    {
        public static string ARQUIVO_ENTRADA_RELATIVO = @"\Arquivos\nfe.xml";
        public static string ARQUIVO_ENTRADA = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + ARQUIVO_ENTRADA_RELATIVO;

        [TestMethod()]
        public void LerArquivoTest()
        {
            Assert.AreEqual(28, ParserXml.LerArquivo(ARQUIVO_ENTRADA).QuantidadeVendaItem);
        }
    }
}