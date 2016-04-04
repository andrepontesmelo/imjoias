using System;

namespace Apresentação.Mercadoria.Etiqueta.Impressão.Layout
{
	/// <summary>
	/// Leiaute para mapeamento de faixa e grupo de uma mercadoria
	/// </summary>
	public class FaixaGrupo : Report.Layout.Complex.Label
	{
		public override string GetText(object obj)
		{
			if (!DesignMode)
			{
				Entidades.Mercadoria.Mercadoria mercadoria;

				mercadoria = (Entidades.Mercadoria.Mercadoria) obj;

				return (mercadoria.Faixa != null ? mercadoria.Faixa : "") + "-" + mercadoria.Grupo;
			}
			else
				return "F-G";
		}
	}
}
