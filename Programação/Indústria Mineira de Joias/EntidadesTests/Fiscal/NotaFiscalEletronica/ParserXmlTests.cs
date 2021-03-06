﻿using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using Entidades.Fiscal.Tipo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace Entidades.Fiscal.NotaFiscalEletronica.Tests
{
    [TestClass()]
    public class ParserXmlTests
    {
        private static string ARQUIVO_ENTRADA = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\nfe.xml";

        private static string ARQUIVO_ENTRADA_VERSÂO_2 = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
           Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\nfev2.xml";

        private static string ARQUIVO_ENTRADA_GRAMAS = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\nfe_gramas.xml";

        private static string ARQUIVO_ENTRADA_UNIDADE = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\nfe_unidade.xml";

        ParserXmlAtacado parser;

        [TestInitialize]
        public void PreparaTestes()
        {
            parser = ParserXmlAtacado.LerArquivo(ARQUIVO_ENTRADA);
        }

        [TestMethod()]
        public void DeveLerQuantidadeVendaItens()
        {
            Assert.AreEqual(28, parser.QuantidadeVendaItem);
        }

        [TestMethod()]
        public void DeveLerTipoUnidadePar()
        {
            Assert.AreEqual(TipoUnidadeSistema.Par, parser.ObterTipoUnidade(1));
        }

        [TestMethod()]
        public void DeveLerTipoUnidadeParPeça()
        {
            Assert.AreEqual(TipoUnidadeSistema.Pca, parser.ObterTipoUnidade(2));
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
        public void DeveLerDesconto()
        {
            Assert.AreEqual(0M, parser.LerValorDesconto());
        }

        [TestMethod()]
        public void DeveLerDescrição()
        {
            Assert.AreEqual("Gargantilha de Ouro", parser.ObterDescrição(11));
        }

        [TestMethod()]
        public void DeveLerUnidadeComercialGramas()
        {
            parser = ParserXmlAtacado.LerArquivo(ARQUIVO_ENTRADA_GRAMAS);
            Assert.AreEqual(TipoUnidadeSistema.Grs, parser.ObterTipoUnidade(1));
        }

        [TestMethod()]
        public void DeveLerUnidadeComercialUnidade()
        {
            parser = ParserXmlAtacado.LerArquivo(ARQUIVO_ENTRADA_UNIDADE);
            Assert.AreEqual(TipoUnidadeSistema.Un, parser.ObterTipoUnidade(1));
        }

        [TestMethod()]
        public void DeveLerUnidadeComercialPeça()
        {
            Assert.AreEqual(TipoUnidadeSistema.Pca, TipoUnidadeInterpretação.Interpretar("peca"));
        }

        [TestMethod()]
        public void DeveLerUnidadeComercialGramasDoisDigitos()
        {
            Assert.AreEqual(TipoUnidadeSistema.Grs, TipoUnidadeInterpretação.Interpretar("gr"));
        }

        [TestMethod()]
        public void DeveLerUnidadeComercialGramasCincoDigitos()
        {
            Assert.AreEqual(TipoUnidadeSistema.Grs, TipoUnidadeInterpretação.Interpretar("grama"));
        }

        [TestMethod()]
        public void DeveLerCódigo()
        {
            Assert.AreEqual("NFe3112345678929000103550010000003481006016004", parser.LerId());
        }

        [TestMethod()]
        public void DeveLerNNF()
        {
            Assert.AreEqual(348, parser.LerNNF());
        }

        [TestMethod()]
        public void DeveLerDataEmissão()
        {
            DateTime emissão = DateTime.Parse("2016-05-10T13:54:00-03:00");
            Assert.AreEqual(emissão, parser.LerDataEmissão());
        }

        [TestMethod()]
        public void DeveLerDataEntradaSaída()
        {
            DateTime dataEntradaSaída = DateTime.Parse("2016-05-10T14:09:00-03:00");
            Assert.AreEqual(dataEntradaSaída, parser.LerDataEntradaSaída());
        }

        [TestMethod()]
        public void DeveLerDataEmissãoXmlVersão2()
        {
            DateTime emissão = DateTime.Parse("2013-06-07");
            ParserXmlAtacado parserVersão2 = ParserXmlAtacado.LerArquivo(ARQUIVO_ENTRADA_VERSÂO_2);

            Assert.AreEqual(emissão, parserVersão2.LerDataEmissão());
        }

        [TestMethod()]
        public void DeveLerCNPJEmitente()
        {
            Assert.AreEqual("18219329000103", parser.LerCNPJEmitente());
        }

        [TestMethod()]
        public void DeveLerCNJPEmissor()
        {
            Assert.AreEqual("00093400000199", parser.LerCNPJEmissor());
        }

        [TestMethod()]
        public void DeveLerCPFEmissor()
        {
            Assert.IsNull(parser.LerCPFEmissor());
        }
    }
}