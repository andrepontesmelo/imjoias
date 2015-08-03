using System;

namespace Negócio.Estoque
{
	/// <summary>
	/// Summary description for ExceçãoMercadoriaEmOutroEstoque.
	/// </summary>
	public class ExceçãoMercadoriaEmOutroEstoque : Exception
	{
		Mercadoria mercadoria;

		public ExceçãoMercadoriaEmOutroEstoque(Mercadoria mercadoria)
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
				return "A mercadoria " + mercadoria.ToString() + " já se encontra em outro estoque.";
			}
		}

	}
}
