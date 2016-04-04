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
		/// Obtém foto da mercadoria
		/// </summary>
		/// <param name="mercadoria">Mercadoria cuja foto será obtida</param>
		/// <returns>Foto da mercadoria</returns>
		MemoryStream ObterFoto(Entidades.Mercadoria.Mercadoria mercadoria);

		/// <summary>
		/// Obtém ícone da mercadoria
		/// </summary>
		/// <param name="mercadoria">Mercadoria cujo ícone será obtido</param>
		/// <returns>Ícone da mercadoria</returns>
		MemoryStream ObterÍcone(Mercadoria.Mercadoria mercadoria);
	}
}