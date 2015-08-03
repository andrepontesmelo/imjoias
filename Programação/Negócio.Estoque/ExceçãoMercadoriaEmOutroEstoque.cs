using System;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Summary description for Exce��oMercadoriaEmOutroEstoque.
	/// </summary>
	public class Exce��oMercadoriaEmOutroEstoque : Exception
	{
		Mercadoria mercadoria;

		public Exce��oMercadoriaEmOutroEstoque(Mercadoria mercadoria)
		{
			this.mercadoria = mercadoria;
		}

		public Mercadoria Mercadoria
		{
			get { return mercadoria; }
		}

		public override string Message
		{
			get
			{
				return "A mercadoria " + mercadoria.ToString() + " j� se encontra em outro estoque.";
			}
		}

	}
}
