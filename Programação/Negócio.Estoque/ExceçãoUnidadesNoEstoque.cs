using System;

namespace Neg�cio.Estoque
{
	public class Exce��oUnidadesNoEstoque : System.Exception
	{
		Mercadoria mercadoria;

		public Exce��oUnidadesNoEstoque(Mercadoria mercadoria)
		{
			this.mercadoria = mercadoria;
		}

		public override string Message
		{
			get
			{
				return "H� unidades da mercadoria " + mercadoria.ToString() + " no estoque.";
			}
		}

		public Mercadoria Mercadoria
		{
			get { return mercadoria; }
		}
	}
}
