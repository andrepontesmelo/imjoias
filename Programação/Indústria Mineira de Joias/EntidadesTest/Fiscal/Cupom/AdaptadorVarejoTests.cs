using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using InterpretadorTDM;
using InterpretadorTDM.Registro;
using System;

namespace Entidades.Fiscal.Cupom.Tests
{
    [TestClass()]
    public class AdaptadorVarejoTests
    {
        private static string ARQUIVO_ENTRADA = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\arquivo.tdm";

        ITransformavelVendaFiscal adaptador;

        [TestInitialize]
        public void PreparaTestes()
        {
            Interpretador interpretador = Interpretador.InterpretaArquivo(ARQUIVO_ENTRADA);
            CupomFiscal primeiroCupom = interpretador.CuponsFiscais[0];

            adaptador = new AdaptadorVarejo(primeiroCupom);
        }

        [TestMethod()]
        public void DeveAdaptarDataEmissão()
        {
            Assert.AreEqual(DateTime.Parse("2015-04-01"), adaptador.Transformar().DataEmissão);
        }

        [TestMethod()]
        public void DeveAdaptarTipoVenda()
        {
            Assert.AreEqual(TipoVenda.Cupom, adaptador.Transformar().TipoVenda);
        }

        [TestMethod()]
        public void DeveAdaptarCancelamento()
        {
            Assert.IsFalse(adaptador.Transformar().Cancelamento);
        }
    }
}