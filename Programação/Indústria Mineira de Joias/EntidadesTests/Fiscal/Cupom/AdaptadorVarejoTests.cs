﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using InterpretadorTDM;
using InterpretadorTDM.Registro;
using System;
using Entidades.Fiscal.Tipo;

namespace Entidades.Fiscal.Cupom.Tests
{
    [TestClass()]
    public class AdaptadorVarejoTests
    {
        private static string ARQUIVO_ENTRADA = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\Arquivos\arquivo.tdm";

        ITransformavelDocumentoFiscal adaptador;

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
            Assert.AreEqual((int) TipoDocumentoSistema.Cupom, adaptador.Transformar().TipoDocumento);
        }


        [TestMethod()]
        public void DeveAdaptarId()
        {
            Assert.AreEqual("27735@0", adaptador.Transformar().Id);
        }

        [TestMethod()]
        public void DeveAdaptarListaItens()
        {
            Assert.AreEqual(1, ((SaídaFiscal)adaptador.Transformar()).Itens.Count);
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
            Assert.IsNull(adaptador.Transformar().Itens[0].Cfop);
        }

        [TestMethod()]
        public void DeveAdaptarTipoUnidade()
        {
            Assert.AreEqual((int) TipoUnidadeSistema.Pca, adaptador.Transformar().Itens[0].TipoUnidade);
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

        [TestMethod()]
        public void DeveAdaptarNúmero()
        {
            Assert.AreEqual(2017, adaptador.Transformar().Número);
        }

        [TestMethod()]
        public void DeveAdaptarCancalamento()
        {
            Assert.IsTrue(((SaídaFiscal) adaptador.Transformar()).Cancelada);
        }
    }
}