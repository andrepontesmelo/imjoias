using Entidades.Fiscal;
using Entidades.Fiscal.Tipo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal.Tests
{
    [TestClass()]
    public class ExtratoTests
    {
        [TestMethod()]
        public void ExtratoEntradaDeveSerTipoEntrada()
        {
            Assert.AreEqual("E", new Extrato("E").EntradaSaída);
        }

        [TestMethod()]
        public void ExtratoSaídaDeveSerTipoSaída()
        {
            Assert.AreEqual("S", new Extrato("S").EntradaSaída);
        }


        [TestMethod()]
        public void ExtratoTODeveSerTipoEntrada()
        {
            Assert.AreEqual("E", new Extrato("TO").EntradaSaída);
        }


        [TestMethod()]
        public void ExtratoOTDeveSerTipoSaída()
        {
            Assert.AreEqual("S", new Extrato("OT").EntradaSaída);
        }

        [TestMethod()]
        public void TipoResumidoDeveSerOTQuandoItemConsumido()
        {
            Assert.AreEqual("OT", new Extrato("OT").TipoResumido);
        }

        [TestMethod()]
        public void TipoResumidoDeveSerTOQuandoItemFabricado()
        {
            Assert.AreEqual("TO", new Extrato("TO").TipoResumido);
        }

        [TestMethod()]
        public void CupomDeveSerResumido()
        {
            var cupom = new Extrato("S", (int)TipoDocumentoSistema.Cupom);
            Assert.AreEqual("CP", cupom.TipoResumido);
        }

        [TestMethod()]
        public void NotaDeveSerResumido()
        {
            var cupom = new Extrato("S", (int)TipoDocumentoSistema.NFe);
            Assert.AreEqual("NF", cupom.TipoResumido);
        }

        [TestMethod()]
        public void DeveCacularEstoqueAcumuladoSemHistóricoItemÚnico()
        {
            List<Extrato> lista = new List<Extrato>();
            lista.Add(new Extrato("A", DateTime.Now, -5));
            
            Extrato.CalcularEstoqueAcumulado(lista, new Dictionary<string, decimal>());

            Assert.AreEqual(-5, lista[0].Estoque);
        }

        [TestMethod()]
        public void DeveCacularEstoqueAcumuladoSemHistóricoVáriosItens()
        {
            List<Extrato> lista = new List<Extrato>();
            lista.Add(new Extrato("A", DateTime.Now, 2));
            lista.Add(new Extrato("A", DateTime.Now, 3));

            Extrato.CalcularEstoqueAcumulado(lista, new Dictionary<string, decimal>());

            Assert.AreEqual(5, lista[1].Estoque);
        }

        [TestMethod()]
        public void DeveCacularEstoqueAcumuladoComHistóricoItemÚnico()
        {
            List<Extrato> lista = new List<Extrato>();
            lista.Add(new Extrato("A", DateTime.Now, 2));

            var histórico = new Dictionary<string, decimal>();
            histórico["A"] = 5;

            Extrato.CalcularEstoqueAcumulado(lista, histórico);

            Assert.AreEqual(7, lista[0].Estoque);
        }


        [TestMethod()]
        public void DeveCacularEstoqueAcumuladoComHistóricoVáriosItens()
        {
            List<Extrato> lista = new List<Extrato>();
            lista.Add(new Extrato("Z", DateTime.Now, 99));
            lista.Add(new Extrato("A", DateTime.Now, 2));
            lista.Add(new Extrato("A", DateTime.Now, 4));

            var histórico = new Dictionary<string, decimal>();
            histórico["A"] = 5;

            Extrato.CalcularEstoqueAcumulado(lista, histórico);

            Assert.AreEqual(11, lista[2].Estoque);
        }

    }
}