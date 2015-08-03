using System;
using Report.Layout.Complex;

namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o.Layout
{
	/// <summary>
	/// Leiaute para refer�ncia de mercadoria
	/// </summary>
	public class Refer�ncia : Report.Layout.Complex.TextMapped
	{
		/// <summary>
		/// Constr�i o mapeamento de refer�ncia
		/// </summary>
		public Refer�ncia() : base(typeof(Entidades.Mercadoria.Mercadoria), "Refer�ncia")
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
