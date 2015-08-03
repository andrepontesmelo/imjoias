using System;

namespace Neg�cio.Estoque
{
	public class Exce��oRefer�nciaN�oEncontrada : Exception
	{
		private Refer�ncia refer�ncia;
		private Estoque estoque;

		public Exce��oRefer�nciaN�oEncontrada(Refer�ncia refer�ncia, Estoque estoque)
		{
			this.refer�ncia = refer�ncia;
			this.estoque = estoque;
		}

		public Refer�ncia Refer�ncia
		{
			get { return refer�ncia; }
		}

		public Estoque Estoque
		{
			get { return estoque; }
		}

		public override string Message
		{
			get
			{
				return "A refer�ncia " + refer�ncia.ToString() + " n�o foi encontrada no estoque " + estoque.Nome + ".";
			}
		}

	}
}
