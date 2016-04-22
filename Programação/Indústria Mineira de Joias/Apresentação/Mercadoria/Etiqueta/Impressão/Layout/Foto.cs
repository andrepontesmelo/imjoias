using System;

namespace Apresentação.Mercadoria.Etiqueta.Impressão.Layout
{
	/// <summary>
	/// Leiaute para foto de mercadoria
	/// </summary>
	public class Foto : Report.Layout.Complex.ImageMapped
	{
		public Foto() : base(typeof(Entidades.Mercadoria.Mercadoria), "Foto")
		{
			Width = 1;
			Height = 1;
			Fit = true;
		}
	}
}
