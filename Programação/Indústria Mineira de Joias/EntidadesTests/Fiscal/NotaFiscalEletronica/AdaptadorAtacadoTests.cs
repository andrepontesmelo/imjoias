using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using Entidades.Fiscal.Tipo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace Entidades.Fiscal.NotaFiscalEletronica.Tests
{
    [TestClass()]
    public class AdaptadorAtacadoTests
    {
        private static string ARQUIVO_ENTRADA = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\nfe.xml";

        ITransformavelDocumentoFiscal adaptador;

        [TestInitialize]
        public void PreparaTestes()
        {
            adaptador = new AdaptadorAtacadoSaída(new ParserXmlAtacado(ARQUIVO_ENTRADA));
        }

        [TestMethod()]
        public void DeveAdaptarDataEmissão()
        {
            Assert.AreEqual(DateTime.Parse("2016-05-10 13:54:00"), adaptador.Transformar().DataEmissão);
        }

        [TestMethod()]
        public void DeveAdaptarTipoVenda()
        {
            Assert.AreEqual((int) TipoDocumentoSistema.NFe, ((SaídaFiscal) adaptador.Transformar()).TipoDocumento);
        }


        [TestMethod()]
        public void DeveAdaptarId()
        {
            Assert.AreEqual("NFe3112345678929000103550010000003481006016004", adaptador.Transformar().Id);
        }

        [TestMethod()]
        public void DeveAdaptarListaItens()
        {
            Assert.AreEqual(28, ((SaídaFiscal)adaptador.Transformar()).Itens.Count);
        }

        [TestMethod()]
        public void DeveAdaptarReferência()
        {
            Assert.AreEqual("102130001008", ((SaídaFiscal)adaptador.Transformar()).Itens[0].Referência);
        }

        [TestMethod()]
        public void DeveAdaptarDescrição()
        {
            Assert.AreEqual("Anel de Ouro", ((SaídaFiscal)adaptador.Transformar()).Itens[0].Descrição);
        }

        [TestMethod()]
        public void DeveAdaptarCFOP()
        {
            Assert.AreEqual(5101, ((SaídaFiscal)adaptador.Transformar()).Itens[0].Cfop);
        }

        [TestMethod()]
        public void DeveAdaptarTipoUnidade()
        {
            Assert.AreEqual((int) TipoUnidadeSistema.Par, ((SaídaFiscal)adaptador.Transformar()).Itens[0].TipoUnidade);
        }

        [TestMethod()]
        public void DeveAdaptarQuantidade()
        {
            Assert.AreEqual(1, ((SaídaFiscal) adaptador.Transformar()).Itens[0].Quantidade);
        }

        [TestMethod()]
        public void DeveAdaptarValorUnitário()
        {
            Assert.AreEqual(110.22M, ((SaídaFiscal) adaptador.Transformar()).Itens[0].ValorUnitário);
        }

        [TestMethod()]
        public void DeveAdaptarValor()
        {
            Assert.AreEqual(110.22M, ((SaídaFiscal) adaptador.Transformar()).Itens[0].Valor);
        }

        [TestMethod()]
        public void DeveAdaptarValorTotalVenda()
        {
            Assert.AreEqual(5800.06M, adaptador.Transformar().ValorTotal);
        }

        [TestMethod()]
        public void DeveAdaptarSubTotalVenda()
        {
            Assert.AreEqual(5800.06M, adaptador.Transformar().SubTotal);
        }

        [TestMethod()]
        public void DeveAdaptarNNF()
        {
            Assert.AreEqual(348, adaptador.Transformar().Número);
        }
    }
}