using System;

namespace Negócio.Estoque
{
	public class ExceçãoUnidadesNoEstoque : System.Exception
	{
		Mercadoria mercadoria;

		public ExceçãoUnidadesNoEstoque(Mercadoria mercadoria)
		{
			this.mercadoria = mercadoria;
		}

		public override string Message
		{
			get
			{
				return "Há unidades da mercadoria " + mercadoria.ToString() + " no estoque.";
			}
		}

		public Mercadoria Mercadoria
		{
			get { return mercadoria; }
		}
	}
}
