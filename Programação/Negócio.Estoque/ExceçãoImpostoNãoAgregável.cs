using System;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Summary description for Exce��oImpostoN�oAgreg�vel.
	/// </summary>
	public class Exce��oImpostoN�oAgreg�vel : Exception
	{
		private Imposto imposto;

		public Exce��oImpostoN�oAgreg�vel(Imposto imposto)
		{
			this.imposto = imposto;
		}

		/// <summary>
		/// Imposto que n�o pdoer ser agregado
		/// </summary>
		public Imposto Imposto
		{
			get { return imposto; }
		}

		public override string Message
		{
			get
			{
				return "O imposto \"" + imposto.Nome
					+ "\" n�o pode ser agregado ao pre�o de venda do produto.";
			}
		}
	}
}
