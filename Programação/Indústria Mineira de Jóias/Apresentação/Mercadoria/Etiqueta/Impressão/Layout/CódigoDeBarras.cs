using System;
using System.Drawing;
using Report.Layout;
using C�digoDeBarras;


namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o.Layout
{
	/// <summary>
	/// Leiaute para mapeamento do c�digo de barras
	/// </summary>
	public class C�digoDeBarras : Report.Layout.Complex.PrintableItem
	{
		private GeradorC�digoDeBarras	geradorC�digoBarras;
		private bool					_alterarTamanho = true;
		private MetricHInch				hInch = new MetricHInch();
		private Entidades.Mercadoria.Mercadoria	mercadoria = null;	// Fazer cache
		private Image					imagem     = null;	// Fazer cache

		/// <summary>
		/// Constr�i o c�digo de barras
		/// </summary>
		public C�digoDeBarras()
		{
			geradorC�digoBarras = new Interleaved25();
		}

		/// <summary>
		/// Imprime o c�digo de barras de uma mercadoria
		/// </summary>
		/// <param name="g">Gr�fico de destino</param>
		/// <param name="obj">Mercadoria</param>
		public override void Print(System.Drawing.Graphics g, object obj)
		{
			Entidades.Mercadoria.Mercadoria mercadoria;
			string				 c�digoBarras;

			mercadoria = (Entidades.Mercadoria.Mercadoria) obj;

			if (mercadoria != this.mercadoria)
			{
				this.mercadoria = mercadoria;

                c�digoBarras = mercadoria.Codificar();

				if (_alterarTamanho)
				{
					geradorC�digoBarras.Tamanho = new Size(
						(int) Math.Round(hInch.Reverse(Location.Width) * g.DpiX),
						(int) Math.Round(hInch.Reverse(Location.Height) * g.DpiY));

					_alterarTamanho = false;
				}
			
				imagem = geradorC�digoBarras.GerarImagem(c�digoBarras);
			}
			else if (imagem == null && DesignMode)
			{
				c�digoBarras = "01234567";

				imagem = geradorC�digoBarras.GerarImagem(c�digoBarras);
			}

			g.DrawImage(imagem, Location);
		}

		protected override void ChangingLocation()
		{
			_alterarTamanho = true;
		}

	}
}
