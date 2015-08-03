using System;

namespace Proxy.Clientes
{
	/// <summary>
	/// Valida um site
	/// </summary>
	public abstract class Validador
	{
		/// <summary>
		/// Obtém permissão de acesso
		/// </summary>
		/// <param name="uri">URI de acesso</param>
		/// <param name="usuárioIp">IP do usuário</param>
		/// <returns>Permissão</returns>
		public abstract bool Validar(Uri uri);
	}
}
