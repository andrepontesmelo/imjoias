using Entidades.Fiscal.NotaFiscalEletronica;
using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace EntidadesTests.Fiscal.NotaFiscalEletronica
{
    [TestClass()]
    public class ParserXmlAtacadoCancelamentoTests
    {
        private static string ARQUIVO_NÃO_CANCELAMENTO = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\nfe.xml";

        private static string ARQUIVO_CANCELAMENTO = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\cancelamento_nfe_saida.xml";

        [TestMethod()]
        public void DeveInterpretarNãoCancelamento()
        {
            ParserXmlAtacadoCancelamento parser = new ParserXmlAtacadoCancelamento(ARQUIVO_NÃO_CANCELAMENTO);
            
            Assert.IsFalse(parser.Cancelamento);
        }

        [TestMethod()]
        public void DeveInterpretarCancelamento()
        {
            ParserXmlAtacadoCancelamento parser = new ParserXmlAtacadoCancelamento(ARQUIVO_CANCELAMENTO);

            Assert.IsTrue(parser.Cancelamento);
        }

        [TestMethod()]
        public void DeveInterpretarId()
        {
            ParserXmlAtacadoCancelamento parser = new ParserXmlAtacadoCancelamento(ARQUIVO_CANCELAMENTO);

            Assert.AreEqual("ID31101218219329000103550010000000988538006600", parser.Id);
        }
    }
}
