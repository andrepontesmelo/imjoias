using System;

namespace Entidades.Configura��o
{
	/// <summary>
	/// Ocorre quando a chave n�o existe.
	/// </summary>
	public class ChaveInexistente : Exception
	{
		public ChaveInexistente(string chave) : base("A chave \"" + chave + "\" n�o existe.")
		{}
	}
}
