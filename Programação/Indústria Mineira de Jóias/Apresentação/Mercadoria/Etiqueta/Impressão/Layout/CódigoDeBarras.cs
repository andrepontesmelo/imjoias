using System;
using System.Drawing;
using Report.Layout;
using CódigoDeBarras;


namespace Apresentação.Mercadoria.Etiqueta.Impressão.Layout
{
	/// <summary>
	/// Leiaute para mapeamento do código de barras
	/// </summary>
	public class CódigoDeBarras : Report.Layout.Complex.PrintableItem
	{
		private GeradorCódigoDeBarras	geradorCódigoBarras;
		private bool					_alterarTamanho = true;
		private MetricHInch				hInch = new MetricHInch();
		private Entidades.Mercadoria.Mercadoria	mercadoria = null;	// Fazer cache
		private Image					imagem     = null;	// Fazer cache

		/// <summary>
		/// Constrói o código de barras
		/// </summary>
		public CódigoDeBarras()
		{
			geradorCódigoBarras = new Interleaved25();
		}

		/// <summary>
		/// Imprime o código de barras de uma mercadoria
		/// </summary>
		/// <param name="g">Gráfico de destino</param>
		/// <param name="obj">Mercadoria</param>
		public override void Print(System.Drawing.Graphics g, object obj)
		{
			Entidades.Mercadoria.Mercadoria mercadoria;
			string				 códigoBarras;

			mercadoria = (Entidades.Mercadoria.Mercadoria) obj;

			if (mercadoria != this.mercadoria)
			{
				this.mercadoria = mercadoria;

                códigoBarras = mercadoria.Codificar();

				if (_alterarTamanho)
				{
					geradorCódigoBarras.Tamanho = new Size(
						(int) Math.Round(hInch.Reverse(Location.Width) * g.DpiX),
						(int) Math.Round(hInch.Reverse(Location.Height) * g.DpiY));

					_alterarTamanho = false;
				}
			
				imagem = geradorCódigoBarras.GerarImagem(códigoBarras);
			}
			else if (imagem == null && DesignMode)
			{
				códigoBarras = "01234567";

				imagem = geradorCódigoBarras.GerarImagem(códigoBarras);
			}

			g.DrawImage(imagem, Location);
		}

		protected override void ChangingLocation()
		{
			_alterarTamanho = true;
		}

	}
}
