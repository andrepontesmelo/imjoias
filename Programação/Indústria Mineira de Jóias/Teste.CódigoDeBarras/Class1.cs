using System;
using NUnit.Framework;
using Negócio.Mercadoria;
using Acesso.Comum;
using Acesso.MySQL;
using System.Data;
using Entidades;

namespace Teste
{
	/// <summary>
	/// Teste do funcionamento do código de barras
	/// </summary>
	[TestFixture]
	public class TCódigoDeBarras
	{
		private CódigoDeBarras controle;

		private MySQLUsuários usuários;
		private Usuário  usuário;

		/// <summary>
		/// Prepara os testes
		/// </summary>
		[SetUp]
		public void PrepararTestes()
		{
			controle = new CódigoDeBarras();

			Console.Out.WriteLine("Controle código de barras construído.");

			usuários = MySQLUsuários.Instância;

			Console.Out.WriteLine("Instância única de usuários carregado.");

			usuário = Acesso.MySQL.MySQLUsuários.Instância.EfetuarLogin("imjoias", "imj");

			Console.Out.WriteLine("Login efetuado.");
		}

		#region Teste de validação

		[Test]
		public void ValidaçãoFormatos()
		{
			Assert.IsFalse(FormatoVálido("00"), "Código de barras de 1 par foi aceito como correto!");
			Assert.IsFalse(FormatoVálido("0000"), "Código de barras de 2 pares foi aceito como correto!");
			Assert.IsFalse(FormatoVálido("00000"), "Código de barras de 3 pares e meio foi aceito como correto!");
			Assert.IsFalse(FormatoVálido("0000000"), "Código de barras de 4 pares e meio foi aceito como correto!");

			Assert.IsTrue(FormatoVálido("000000"), "Código de barras de 3 pares não foi validado!");
			Assert.IsTrue(FormatoVálido("00000000"), "Código de barras de 4 pares não foi validado!");
		}

		private bool FormatoVálido(string código)
		{
			int mapCódigo;
			double mapPeso;

			try
			{
				controle.Interpretar(código, out mapCódigo, out mapPeso);

				return true;
			}
			catch (Negócio.Exceções.CódigoBarrasInválido)
			{
				return false;
			}
		}

		#endregion

		#region Teste de interpretação

		/// <summary>
		/// Teste de interepretação de mercadorias de peso
		/// com 3 pares de código.
		/// </summary>
		[Test]
		public void Interpretação3ParesPeso()
		{
			int código;
			double peso;

			controle.Interpretar("001000", out código, out peso);
			Assert.AreEqual(0, código);
			Assert.AreEqual(0.1d, peso);

			controle.Interpretar("123456", out código, out peso);
			Assert.AreEqual(456, código);
			Assert.AreEqual(12.3d, peso);

			controle.Interpretar("999999", out código, out peso);
			Assert.AreEqual(999, código);
			Assert.AreEqual(99.9d, peso);
		}

		/// <summary>
		/// Teste de interepretação de mercadorias de peso
		/// com 4 pares de código (Peso leve).
		/// </summary>
		[Test]
		public void Interpretação4ParesPesoLeve()
		{
			int código;
			double peso;

			controle.Interpretar("00100000", out código, out peso);
			Assert.AreEqual(1000, código);
			Assert.AreEqual(0.1d, peso);

			controle.Interpretar("12345678", out código, out peso);
			Assert.AreEqual(46678, código);
			Assert.AreEqual(12.3d, peso);

			controle.Interpretar("89999999", out código, out peso);
			Assert.AreEqual(100999, código);
			Assert.AreEqual(89.9d, peso);
		}

		/// <summary>
		/// Teste de interepretação de mercadorias de peso
		/// com 4 pares de código (Peso pesado).
		/// </summary>
		[Test]
		public void Interpretação4ParesPesoPesado()
		{
			int código;
			double peso;

			controle.Interpretar("90000000", out código, out peso);
			Assert.AreEqual(0, código);
			Assert.AreEqual(90d, peso);

			controle.Interpretar("91234567", out código, out peso);
			Assert.AreEqual(567, código);
			Assert.AreEqual(213.4d, peso);

			controle.Interpretar("99999999", out código, out peso);
			Assert.AreEqual(999, código);
			Assert.AreEqual(1089.9d, peso);
		}

		/// <summary>
		/// Teste de interepretação de mercadorias de linha
		/// com 3 pares de código.
		/// </summary>
		[Test]
		public void Interpretação3ParesSemPeso()
		{
			int código;
			double peso;

			controle.Interpretar("000000", out código, out peso);
			Assert.AreEqual(0, código);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("000456", out código, out peso);
			Assert.AreEqual(456, código);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("000999", out código, out peso);
			Assert.AreEqual(999, código);
			Assert.AreEqual(0d, peso);
		}

		/// <summary>
		/// Teste de interepretação de mercadorias de linha
		/// com 4 pares de código.
		/// </summary>
		[Test]
		public void Interpretação4ParesSemPeso()
		{
			int código;
			double peso;

			controle.Interpretar("00000000", out código, out peso);
			Assert.AreEqual(1000, código);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("00045678", out código, out peso);
			Assert.AreEqual(46678, código);
			Assert.AreEqual(0d, peso);

			controle.Interpretar("00099999", out código, out peso);
			Assert.AreEqual(100999, código);
			Assert.AreEqual(0d, peso);
		}

		#endregion

		#region Teste de codificação

		private string ObterReferênciaQualquer()
		{
			IDbCommand cmd = usuário.Conexão.CreateCommand();

			cmd.CommandText = "SELECT referencia FROM mercadoria ORDER BY RAND() LIMIT 1";

			return Convert.ToString(cmd.ExecuteScalar());
		}

		private void ValidarCodificação(string referência, double peso)
		{
			string     código;
			Mercadoria mercadoria;
			
			código = controle.Codificar(referência, peso);
			mercadoria = controle.Interpretar(código);

			Assert.IsNotNull(mercadoria);
			Assert.AreEqual(referência, mercadoria.ReferênciaNumérica);
			Assert.AreEqual(peso, mercadoria.Peso);
		}

		private void ValidarCodificação(double peso)
		{
			ValidarCodificação(ObterReferênciaQualquer(), peso);
		}

		/// <summary>
		/// Teste de interepretação de mercadorias de peso
		/// com 3 pares de código.
		/// </summary>
		[Test]
		public void CodificaçãoPesoLeve()
		{
			ValidarCodificação(0.1);
			ValidarCodificação(12.3d);
			ValidarCodificação(99.9d);
		}

		/// <summary>
		/// Teste de interepretação de mercadorias de peso
		/// com 4 pares de código (Peso pesado).
		/// </summary>
		[Test]
		public void CodificaçãoPesoPesado()
		{
			ValidarCodificação(90);

			ValidarCodificação(213.4d);

			ValidarCodificação(1089.9d);
		}

		/// <summary>
		/// Teste de interepretação de mercadorias de linha
		/// com 3 pares de código.
		/// </summary>
		[Test]
		public void CodificaçãoSemPeso()
		{
			ValidarCodificação(0d);
		}

		#endregion
	}
}
