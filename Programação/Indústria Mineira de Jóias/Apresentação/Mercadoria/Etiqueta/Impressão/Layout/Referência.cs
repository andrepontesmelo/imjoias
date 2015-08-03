using System;
using Report.Layout.Complex;

namespace Apresentação.Mercadoria.Etiqueta.Impressão.Layout
{
	/// <summary>
	/// Leiaute para referência de mercadoria
	/// </summary>
	public class Referência : Report.Layout.Complex.TextMapped
	{
		/// <summary>
		/// Constrói o mapeamento de referência
		/// </summary>
		public Referência() : base(typeof(Entidades.Mercadoria.Mercadoria), "Referência")
		{
			Width = 1;
			Height = 0.5f;
		}

		/// <summary>
		/// String a ser impressa em modo design
		/// </summary>
		protected override string GetDesignString()
		{
			return "123.456.78.901-2";
		}
	}
}
