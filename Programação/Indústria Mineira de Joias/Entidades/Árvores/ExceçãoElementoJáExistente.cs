using System;

namespace Entidades.Árvores
{
	public class ExceçãoElementoJáExistente : Exception
	{
		private object elemento;

		public ExceçãoElementoJáExistente(object elemento)
		{
			this.elemento = elemento;
		}

		public override string ToString()
		{
			return "Elemento já existente!";
		}

		public override string Message
		{
			get
			{
				return "Elemento já existente";
			}
		}

		public object Elemento
		{
			get
			{
				return elemento;
			}
		}
	}
}
