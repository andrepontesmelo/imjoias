using System;

namespace Negócio.Estoque
{
	/// <summary>
	/// Summary description for ExceçãoImpostoNãoAgregável.
	/// </summary>
	public class ExceçãoImpostoNãoAgregável : Exception
	{
		private Imposto imposto;

		public ExceçãoImpostoNãoAgregável(Imposto imposto)
		{
			this.imposto = imposto;
		}

		/// <summary>
		/// Imposto que não pdoer ser agregado
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
					+ "\" não pode ser agregado ao preço de venda do produto.";
			}
		}
	}
}
