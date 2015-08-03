using System;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Summary description for Exce��oMercadoriaForaEstoque.
	/// </summary>
	public class Exce��oMercadoriaForaEstoque : Exception
	{
		private Mercadoria mercadoria;
		private Estoque estoque;

		public Exce��oMercadoriaForaEstoque(Mercadoria mercadoria, Estoque estoque)
		{
			this.mercadoria = mercadoria;
			this.estoque = estoque;
		}

		public override string Message
		{
			get
			{
				return "A mercadoria " + mercadoria.ToString() + " n�o foi inserida no estoque " + estoque.Nome + ".";
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
