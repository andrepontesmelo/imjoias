using System;

namespace Negócio.Estoque
{
	public class ExceçãoReferênciaNãoEncontrada : Exception
	{
		private Referência referência;
		private Estoque estoque;

		public ExceçãoReferênciaNãoEncontrada(Referência referência, Estoque estoque)
		{
			this.referência = referência;
			this.estoque = estoque;
		}

		public Referência Referência
		{
			get { return referência; }
		}

		public Estoque Estoque
		{
			get { return estoque; }
		}

		public override string Message
		{
			get
			{
				return "A referência " + referência.ToString() + " não foi encontrada no estoque " + estoque.Nome + ".";
			}
		}

	}
}
