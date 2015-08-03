using System;

namespace Neg�cio.Estoque
{
	public class Exce��oEstoqueInsuficiente : Exception
	{
		Mercadoria mercadoria;

		public Exce��oEstoqueInsuficiente(Mercadoria mercadoria)
		{
			this.mercadoria = mercadoria;
		}

		public override string Message
		{
			get
			{
				return "Estoque insufiente de mercadorias " + mercadoria.ToString() + ".";
			}
		}

		public Mercadoria Mercadoria
		{
			get { return mercadoria; }
		}
	}
}
