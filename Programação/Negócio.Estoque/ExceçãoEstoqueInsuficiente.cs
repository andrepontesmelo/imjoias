using System;

namespace Negócio.Estoque
{
	public class ExceçãoEstoqueInsuficiente : Exception
	{
		Mercadoria mercadoria;

		public ExceçãoEstoqueInsuficiente(Mercadoria mercadoria)
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
