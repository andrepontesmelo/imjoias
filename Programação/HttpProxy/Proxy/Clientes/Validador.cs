using System;

namespace Proxy.Clientes
{
	/// <summary>
	/// Valida um site
	/// </summary>
	public abstract class Validador
	{
		/// <summary>
		/// Obt�m permiss�o de acesso
		/// </summary>
		/// <param name="uri">URI de acesso</param>
		/// <param name="usu�rioIp">IP do usu�rio</param>
		/// <returns>Permiss�o</returns>
		public abstract bool Validar(Uri uri);
	}
}
