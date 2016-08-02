using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.Fiscal.NotaFiscalEletronica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.AreEqual(ParserXml.LerArquivo(ARQUIVO_ENTRADA).QuantidadeVendaItem, 28);
        }
    }
}