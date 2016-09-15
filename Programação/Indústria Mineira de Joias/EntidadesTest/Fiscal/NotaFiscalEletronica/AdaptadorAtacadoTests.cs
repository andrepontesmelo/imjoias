﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        ITransformavelVendaFiscal adaptador;

        [TestInitialize]
        public void PreparaTestes()
        {
            adaptador = new AdaptadorAtacado(new ParserXmlAtacado(ARQUIVO_ENTRADA));
        }

        [TestMethod()]
        public void DeveAdaptarDataEmissão()
        {
            Assert.AreEqual(DateTime.Parse("2016-05-10 13:54:00"), adaptador.Transformar().DataEmissão);
        }

        [TestMethod()]
        public void DeveAdaptarTipoVenda()
        {
            Assert.AreEqual(TipoVenda.NFe, adaptador.Transformar().TipoVenda);
        }


        [TestMethod()]
        public void DeveAdaptarId()
        {
            Assert.AreEqual("NFe3112345678929000103550010000003481006016004", adaptador.Transformar().Id);
        }

        [TestMethod()]
        public void DeveAdaptarListaItens()
        {
            Assert.AreEqual(28, adaptador.Transformar().Itens.Count);
        }

        [TestMethod()]
        public void DeveAdaptarReferência()
        {
            Assert.AreEqual("102130001008", adaptador.Transformar().Itens[0].Referência);
        }
    }
}