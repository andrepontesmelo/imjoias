using System;

namespace Entidades.�rvores
{
	public class Exce��oElementoJ�Existente : Exception
	{
		private object elemento;

		public Exce��oElementoJ�Existente(object elemento)
		{
			this.elemento = elemento;
		}

		public override string ToString()
		{
			return "Elemento j� existente!";
		}

		public override string Message
		{
			get
			{
				return "Elemento j� existente";
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
