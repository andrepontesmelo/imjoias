using System;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Define validade de uma entidade em cache.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class Validade : Attribute
	{
		private TimeSpan prazo;

		/// <summary>
		/// Constrói a validade de uma entidade em cache.
		/// </summary>
		/// <param name="prazo">Prazo de validade.</param>
		public Validade(TimeSpan prazo)
		{
			this.prazo = prazo;
		}

        public Validade(int horas, int minutos, int segundos)
        {
            this.prazo = new TimeSpan(horas, minutos, segundos);
        }

		/// <summary>
		/// Prazo de validade da entidade em cache.
		/// </summary>
		public TimeSpan Prazo
		{
			get { return prazo; }
		}
	}
}
