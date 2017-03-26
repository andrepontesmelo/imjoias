using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntidadesTest
{
    [TestClass]
    public class Preço
    {
        [TestMethod]
        public void DeveSomarDiasTabelaComercial()
        {
            DateTime dataBase = DateTime.Parse("2015-07-01");
            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, 1);
            Assert.AreEqual(dataBase.AddDays(1), resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialInverso()
        {
            DateTime dataBase = DateTime.Parse("2015-07-02");
            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, -1);
            Assert.AreEqual(dataBase.AddDays(-1), resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialUltimoDiaSimples()
        {
            DateTime dataBase = DateTime.Parse("2015-07-29");
            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, 1);

            Assert.AreEqual(DateTime.Parse("2015-07-30"), resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialUltimoDiaSimplesInverso()
        {
            DateTime dataBase = DateTime.Parse("2015-07-30");
            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, -1);

            Assert.AreEqual(DateTime.Parse("2015-07-29"), resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialDia30()
        {
            DateTime dataBase = DateTime.Parse("2015-07-30");
            DateTime proximoMes = DateTime.Parse("2015-08-01");
            
            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, 1);

            Assert.AreEqual(proximoMes, resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialDia30Inverso()
        {
            DateTime dataBase = DateTime.Parse("2015-07-30");
            DateTime proximoMes = DateTime.Parse("2015-08-01");

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(proximoMes, -1);

            Assert.AreEqual(dataBase, resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialMudançaMês()
        {
            DateTime dataBase = DateTime.Parse("2015-02-26");
            DateTime proximoMes = DateTime.Parse("2015-03-01");

            // +1 27;
            // +2 28;
            // +3 29;
            // +4 30;
            // +5 01;

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, 5);

            Assert.AreEqual(proximoMes, resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialMudançaMêsInverso()
        {
            DateTime dataBase = DateTime.Parse("2015-02-26");
            DateTime proximoMes = DateTime.Parse("2015-03-01");

            // +1 27;
            // +2 28;
            // +3 29;
            // +4 30;
            // +5 01;

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(proximoMes, -5);

            Assert.AreEqual(dataBase, resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialMudançaMêsComSobra()
        {
            DateTime dataBase = DateTime.Parse("2015-02-26");
            DateTime esperado = DateTime.Parse("2015-03-02");

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, 6);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void DeveSomarDiasTabelaComercialMudançaMêsComSobraInverso()
        {
            DateTime dataBase = DateTime.Parse("2015-02-26");
            DateTime após6dias = DateTime.Parse("2015-03-02");

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(após6dias, -6);

            Assert.AreEqual(dataBase, resultado);
        }

        [TestMethod]
        public void DeveSomar6Mêses()
        {
            DateTime dataBase = DateTime.Parse("2015-01-15");
            DateTime após6mêses = DateTime.Parse("2015-07-15");

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, 6 * 30);

            Assert.AreEqual(após6mêses, resultado);
        }

        [TestMethod]
        public void DeveSomar6MêsesInverso()
        {
            DateTime dataBase = DateTime.Parse("2015-01-15");
            DateTime após6mêses = DateTime.Parse("2015-07-15");

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(após6mêses, -6 * 30);

            Assert.AreEqual(dataBase, resultado);
        }

        [TestMethod]
        public void DeveSomar10Anos()
        {
            DateTime dataBase = DateTime.Parse("2017-01-01");
            DateTime após10Anos = DateTime.Parse("2027-01-01");

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(dataBase, 10 * 12 * 30);

            Assert.AreEqual(após10Anos, resultado);
        }

        [TestMethod]
        public void DeveSomar10AnosInverso()
        {
            DateTime dataBase = DateTime.Parse("2017-01-01");
            DateTime após10Anos = DateTime.Parse("2027-01-01");

            DateTime resultado = Entidades.Preço.SomarDiasTabelaComercial(após10Anos, -10 * 12 * 30);

            Assert.AreEqual(dataBase, resultado);
        }


        [TestMethod]
        public void DeveCalcularDiasSimples()
        {

            DateTime inicio = DateTime.Parse("2015-02-01");
            DateTime fim = DateTime.Parse("2015-02-28");

            Assert.AreEqual(27, Entidades.Preço.CalcularDias(inicio, fim));
        }

        [TestMethod]
        public void DeveCalcularDias()
        {
            DateTime inicio = DateTime.Parse("2015-02-28");
            DateTime fim = DateTime.Parse("2015-03-01");

            // 28 - 0
            // 29 - 1
            // 30 - 2
            // 01 - 3;
            
            Assert.AreEqual(3, Entidades.Preço.CalcularDias(inicio, fim));
        }

        [TestMethod]
        public void DeveCalcularDiasComSobra()
        {
            DateTime inicio = DateTime.Parse("2015-02-28");
            DateTime fim = DateTime.Parse("2015-03-02");

            // 28 - 0
            // 29 - 1
            // 30 - 2
            // 01 - 3;
            // 02 - 4 

            Assert.AreEqual(4, Entidades.Preço.CalcularDias(inicio, fim));
        }
    }
}
