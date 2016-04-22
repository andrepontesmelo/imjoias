using System.Drawing;
using System.IO;

namespace Entidades
{
	/// <summary>
	/// Interface para a classe de acesso de mercadoria
	/// </summary>
	public interface IAcessoMercadoria
	{
		/// <summary>
		/// Obt�m foto da mercadoria
		/// </summary>
		/// <param name="mercadoria">Mercadoria cuja foto ser� obtida</param>
		/// <returns>Foto da mercadoria</returns>
		MemoryStream ObterFoto(Entidades.Mercadoria.Mercadoria mercadoria);

		/// <summary>
		/// Obt�m �cone da mercadoria
		/// </summary>
		/// <param name="mercadoria">Mercadoria cujo �cone ser� obtido</param>
		/// <returns>�cone da mercadoria</returns>
		MemoryStream Obter�cone(Mercadoria.Mercadoria mercadoria);
	}
}