using System;
using System.Drawing;

namespace Apresenta��o.�lbum.Edi��o.�lbuns.Desenhista
{
	/// <summary>
	/// P�gina infinita verticalmente
	/// </summary>
	public class P�ginaInfinita : P�gina
	{
		private int largura;
		private int alturaItem;

		public P�ginaInfinita(int largura)
		{
			this.largura = largura;
		}

		/// <summary>
		/// Largura da p�gina
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

        protected override void CalcularDimens�esitem(Graphics g, out SizeF itemDimens�es, out SizeF fotoDimens�es, float alturaCabe�alho, ItensImpress�o itens)
		{
			itemDimens�es = new SizeF(
				largura / Colunas - (Colunas - 1) * Espa�amentoM�nimo,
				alturaItem);

			if (alturaItem <= 0)
				itemDimens�es.Height = (int) ((float) itemDimens�es.Width * (3f / 4f)) + 70;

			fotoDimens�es = new SizeF(
				itemDimens�es.Width, itemDimens�es.Height - (int) Math.Ceiling(g.MeasureString("Tj����", Fonte).Height * linhasTexto));
		}
	}
}
