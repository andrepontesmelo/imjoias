using System;

namespace Entidades.Configuração
{
	/// <summary>
	/// Ocorre quando a chave não existe.
	/// </summary>
	public class ChaveInexistente : Exception
	{
		public ChaveInexistente(string chave) : base("A chave \"" + chave + "\" não existe.")
		{}
	}
}
