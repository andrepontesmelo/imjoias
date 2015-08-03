using System;
using System.Drawing;

namespace CódigoDeBarras
{
	/// <summary>
	/// Interface de gerador de código de barras
	/// </summary>
	public abstract class GeradorCódigoDeBarras
	{
		private Size	     padrãoTamanho;
		private double	     padrãoLarguraBarraFina;
		private double	     padrãoFatorBarraGrossa;

		/// <summary>
		/// Tamanho padrão da imagem
		/// </summary>
		public virtual Size Tamanho
		{
			get { return padrãoTamanho; }
			set { padrãoTamanho = value; }
		}
		
		/// <summary>
		/// Largura padrão da barra fina
		/// </summary>
		public virtual double LarguraBarraFina
		{
			get { return padrãoLarguraBarraFina; }
			set { padrãoLarguraBarraFina = value; }
		}

		/// <summary>
		/// Fator multiplicativa padrão da barra grossa
		/// </summary>
		public virtual double PadrãoFatorBarraGrossa
		{
			get { return padrãoFatorBarraGrossa; }
			set { padrãoFatorBarraGrossa = value; }
		}

		/// <summary>
		/// Constrói a classe introduzindo valores padrões
		/// </summary>
		public GeradorCódigoDeBarras()
		{
			padrãoTamanho          = new Size(150, 100);
			padrãoLarguraBarraFina = 1;
			padrãoFatorBarraGrossa = 2;
		}

		/// <summary>
		/// Gera imagem de código de barras, enquadrando-o
		/// ao tamanho requerido.
		/// </summary>
		/// <returns>Imagem do código de barras</returns>
		public virtual Image GerarImagem(string código)
		{
			bool [] códigoBooleano;
			int     barrasGrossas;
			int     barrasFinas;
			double	larguraBarraFina;

			códigoBooleano = GerarCódigoBooleano(código);
			
			CalcularTamanho(códigoBooleano, out barrasFinas, out barrasGrossas);

			larguraBarraFina = (double) Tamanho.Width / (double) (barrasFinas + barrasGrossas * padrãoFatorBarraGrossa);

			return Desenhar(códigoBooleano, Tamanho, larguraBarraFina, padrãoFatorBarraGrossa);
		}

		/// <summary>
		/// Gera código booleano
		/// </summary>
		/// <param name="código">Código original</param>
		/// <returns>Código booleano</returns>
		protected abstract bool [] GerarCódigoBooleano(string código);

		/// <summary>
		/// Gera imagem de código de barras
		/// </summary>
		/// <param name="código">Codigo a ser gerado</param>
		/// <param name="tamanhoImagem">Tamanho em pixels da imagem</param>
		/// <param name="larguraBarraFina">Largura em pixels da barra fina</param>
		/// <param name="fatorBarraGrossa">Quantas vezes a barra grossa é maior que a barra fina</param>
		/// <returns>Imagem do código de barras</returns>
		protected abstract Image Desenhar(bool [] código, Size tamanhoImagem, double larguraBarraFina, double fatorBarraGrossa);

		/// <summary>
		/// Calcula a quantidade de barras finas e grossas
		/// </summary>
		/// <param name="código">Código a ser verificado</param>
		/// <param name="barrasFinas">Quantidade de barras finas calculdadas</param>
		/// <param name="barrasGrossas">Quantidade de barras grossas calculadas</param>
		protected abstract void CalcularTamanho(bool [] código, out int barrasFinas, out int barrasGrossas);
	}
}
