using System;
using System.Drawing;

namespace Apresentação.Álbum.Edição.Álbuns.Desenhista
{
	/// <summary>
	/// Página infinita verticalmente
	/// </summary>
	public class PáginaInfinita : Página
	{
		private int largura;
		private int alturaItem;

		public PáginaInfinita(int largura)
		{
			this.largura = largura;
		}

		/// <summary>
		/// Largura da página
		/// </summary>
		public int Largura
		{
			get { return largura; }
			set { largura = value; }
		}

		public int AlturaItem
		{
			get { return alturaItem; }
			set { alturaItem = value; }
		}

        protected override void CalcularDimensõesitem(Graphics g, out SizeF itemDimensões, out SizeF fotoDimensões, float alturaCabeçalho, ItensImpressão itens)
		{
			itemDimensões = new SizeF(
				largura / Colunas - (Colunas - 1) * EspaçamentoMínimo,
				alturaItem);

			if (alturaItem <= 0)
				itemDimensões.Height = (int) ((float) itemDimensões.Width * (3f / 4f)) + 70;

			fotoDimensões = new SizeF(
				itemDimensões.Width, itemDimensões.Height - (int) Math.Ceiling(g.MeasureString("TjçÇÁÃ", Fonte).Height * linhasTexto));
		}
	}
}
