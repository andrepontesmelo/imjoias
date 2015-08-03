using System;
using NUnit.Framework;
using Neg�cio.Mercadoria;
using Acesso.Comum;
using Acesso.MySQL;
using System.Data;
using Entidades;

namespace Teste
{
	/// <summary>
	/// Teste do funcionamento do c�digo de barras
	/// </summary>
	[TestFixture]
	public class TC�digoDeBarras
	{
		private C�digoDeBarras controle;

		private MySQLUsu�rios usu�rios;
		private Usu�rio  usu�rio;

		/// <summary>
		/// Prepara os testes
		/// </summary>
		[SetUp]
		public void PrepararTestes()
		{
			controle = new C�digoDeBarras();

			Console.Out.WriteLine("Controle c�digo de barras constru�do.");

			usu�rios = MySQLUsu�rios.Inst�ncia;

			Console.Out.WriteLine("Inst�ncia �nica de usu�rios carregado.");

			usu�rio = Acesso.MySQL.MySQLUsu�rios.Inst�ncia.EfetuarLogin("imjoias", "imj");

			Console.Out.WriteLine("Login efetuado.");
		}

		#region Teste de valida��o

		[Test]
		public void Valida��oFormatos()
		{
			Assert.IsFalse(FormatoV�lido("00"), "C�digo de barras de 1 par foi aceito como correto!");
			Assert.IsFalse(FormatoV�lido("0000"), "C�digo de barras de 2 pares foi aceito como correto!");
			Assert.IsFalse(FormatoV�lido("00000"), "C�digo de barras de 3 pares e meio foi aceito como correto!");
			Assert.IsFalse(FormatoV�lido("0000000"), "C�digo de barras de 4 pares e meio foi aceito como correto!");

			Assert.IsTrue(FormatoV�lido("000000"), "C�digo de barras de 3 pares n�o foi validado!");
			Assert.IsTrue(FormatoV�lido("00000000"), "C�digo de barras de 4 pares n�o foi validado!");
		}

		private bool FormatoV�lido(string c�digo)
		{
			int mapC�digo;
			double mapPeso;

			try
			{
				controle.Interpretar(c�digo, out mapC�digo, out mapPeso);

				return true;
			}
			catch (Neg�cio.Exce��es.C�digoBarrasInv�lido)
			{
				return false;
			}
		}

		#endregion

		#region Teste de interpreta��o

		/// <summary>
		/// Teste de interepreta��o de mercadorias de peso
		/// com 3 pares de c�digo.
		/// </summary>
		[Test]
		public void Interpreta��o3ParesPeso()
		{
			int c�digo;
			double peso;

			controle.Interpretar("001000", out c�digo, out peso);
			Assert.AreEqual(0, c�digo);
			Assert.AreEqual(0.1d, peso);

			controle.Interpretar("123456", out c�digo, out peso);
			Assert.AreEqual(456, c�digo);
			Assert.AreEqual(12.3d, peso);

			controle.Interpretar("999999", out c�digo, out peso);
			Assert.AreEqual(999, c�digo);
			Assert.AreEqual(99.9d, peso);
		}

		/// <summary>
		/// Teste de interepreta��o de mercadorias de peso
		/// com 4 pares de c�digo (Peso leve).
		/// </summary>
		[Test]
		public void Interpreta��o4ParesPesoLeve()
		{
			int c�digo;
			double peso;

			controle.Interpretar("00100000", out c�digo, out peso);
			Assert.AreEqual(1000, c�digo);
			Assert.AreEqual(0.1d, peso);

			controle.Interpretar("12345678", out c�digo, out peso);
			Assert.AreEqual(46678, c�digo);
			Assert.AreEqual(12.3d, peso);

			controle.Interpretar("89999999", out c�digo, out peso);
			Assert.AreEqual(100999, c�digo);
			Assert.AreEqual(89.9d, peso);
		}

		/// <summary>
		/// Teste de interepreta��o de mercadorias de peso
		/// com 4 pares de c�digo (Peso pesado).
		/// </summary>
		[Test]
		public void Interpreta��o4ParesPesoPesado()
		{
			int c�digo;
			double peso;

			controle.Interpretar("90000000", out c�digo, out peso);
			Assert.AreEqual(0, c�digo);
			Assert.AreEqual(90d, peso);

			controle.Interpretar("91234567", out c�digo, out peso);
			Assert.AreEqual(567, c�digo);
			Assert.AreEqual(213.4d, peso);

			controle.Interpretar("99999999", out c�digo, out peso);
			Assert.AreEqual(999, c�digo);
			Assert.AreEqual(1089.9d, peso);
		}

		/// <summary>
		/// Teste de interepreta��o de mercadorias de linha
		/// com 3 pares de c�digo.
		/// </summary>
		[Test]
		public void Interpreta��o3ParesSemPeso()
		{
			int c�digo;
			double peso;

			controle.Interpretar("000000", out c�digo, out peso);
			Assert.AreEqual(0, c�digo);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("000456", out c�digo, out peso);
			Assert.AreEqual(456, c�digo);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("000999", out c�digo, out peso);
			Assert.AreEqual(999, c�digo);
			Assert.AreEqual(0d, peso);
		}

		/// <summary>
		/// Teste de interepreta��o de mercadorias de linha
		/// com 4 pares de c�digo.
		/// </summary>
		[Test]
		public void Interpreta��o4ParesSemPeso()
		{
			int c�digo;
			double peso;

			controle.Interpretar("00000000", out c�digo, out peso);
			Assert.AreEqual(1000, c�digo);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("00045678", out c�digo, out peso);
			Assert.AreEqual(46678, c�digo);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("00099999", out c�digo, out peso);
			Assert.AreEqual(100999, c�digo);
			Assert.AreEqual(0d, peso);
		}

		#endregion

		#region Teste de codifica��o

		private string ObterRefer�nciaQualquer()
		{
			IDbCommand cmd = usu�rio.Conex�o.CreateCommand();

			cmd.CommandText = "SELECT referencia FROM mercadoria ORDER BY RAND() LIMIT 1";

			return Convert.ToString(cmd.ExecuteScalar());
		}

		private void ValidarCodifica��o(string refer�ncia, double peso)
		{
			string     c�digo;
			Mercadoria mercadoria;
			
			c�digo = controle.Codificar(refer�ncia, peso);
			mercadoria = controle.Interpretar(c�digo);

			Assert.IsNotNull(mercadoria);
			Assert.AreEqual(refer�ncia, mercadoria.Refer�nciaNum�rica);
			Assert.AreEqual(peso, mercadoria.Peso);
		}

		private void ValidarCodifica��o(double peso)
		{
			ValidarCodifica��o(ObterRefer�nciaQualquer(), peso);
		}

		/// <summary>
		/// Teste de interepreta��o de mercadorias de peso
		/// com 3 pares de c�digo.
		/// </summary>
		[Test]
		public void Codifica��oPesoLeve()
		{
			ValidarCodifica��o(0.1);
			ValidarCodifica��o(12.3d);
			ValidarCodifica��o(99.9d);
		}

		/// <summary>
		/// Teste de interepreta��o de mercadorias de peso
		/// com 4 pares de c�digo (Peso pesado).
		/// </summary>
		[Test]
		public void Codifica��oPesoPesado()
		{
			ValidarCodifica��o(90);

			ValidarCodifica��o(213.4d);

			ValidarCodifica��o(1089.9d);
		}

		/// <summary>
		/// Teste de interepreta��o de mercadorias de linha
		/// com 3 pares de c�digo.
		/// </summary>
		[Test]
		public void Codifica��oSemPeso()
		{
			ValidarCodifica��o(0d);
		}

		#endregion
	}
}
