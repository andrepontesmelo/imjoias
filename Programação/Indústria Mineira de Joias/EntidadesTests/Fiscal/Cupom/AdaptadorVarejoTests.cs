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
        public void DeveAdaptarId()
        {
            Assert.AreEqual("2015-04-01#17248#27735", adaptador.Transformar().Id);
        }

        [TestMethod()]
        public void DeveAdaptarListaItens()
        {
            Assert.AreEqual(1, adaptador.Transformar().Itens.Count);
        }

        [TestMethod()]
        public void DeveAdaptarReferência()
        {
            Assert.AreEqual("10800300100", adaptador.Transformar().Itens[0].Referência);
        }

        [TestMethod()]
        public void DeveAdaptarDescrição()
        {
            Assert.AreEqual("Medalha de Ouro", adaptador.Transformar().Itens[0].Descrição);
        }

        [TestMethod()]
        public void DeveAdaptarCFOP()
        {
            Assert.IsNull(adaptador.Transformar().Itens[0].CFOP);
        }

        [TestMethod()]
        public void DeveAdaptarTipoUnidade()
        {
            Assert.AreEqual(TipoUnidade.Pca, adaptador.Transformar().Itens[0].TipoUnidade);
        }


        [TestMethod()]
        public void DeveAdaptarQuantidade()
        {
            Assert.AreEqual(1, adaptador.Transformar().Itens[0].Quantidade);
        }

        [TestMethod()]
        public void DeveAdaptarValorUnitário()
        {
            Assert.AreEqual(2799.57M, adaptador.Transformar().Itens[0].ValorUnitário);
        }

        [TestMethod()]
        public void DeveAdaptarValor()
        {
            Assert.AreEqual(2799.57M, adaptador.Transformar().Itens[0].Valor);
        }

        [TestMethod()]
        public void DeveAdaptarValorTotalVenda()
        {
            Assert.AreEqual(2799.57M, adaptador.Transformar().ValorTotal);
        }
    }
}