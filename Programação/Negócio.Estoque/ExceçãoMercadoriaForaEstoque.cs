using System;

namespace Negócio.Estoque
{
	/// <summary>
	/// Summary description for ExceçãoMercadoriaForaEstoque.
	/// </summary>
	public class ExceçãoMercadoriaForaEstoque : Exception
	{
		private Mercadoria mercadoria;
		private Estoque estoque;

		public ExceçãoMercadoriaForaEstoque(Mercadoria mercadoria, Estoque estoque)
		{
			this.mercadoria = mercadoria;
			this.estoque = estoque;
		}

		public override string Message
		{
			get
			{
				return "A mercadoria " + mercadoria.ToString() + " não foi inserida no estoque " + estoque.Nome + ".";
			}
		}

		public Mercadoria Mercadoria
		{
			get { return mercadoria; }
		}

		public Estoque Estoque
		{
			get { return estoque; }
		}
	}
}
