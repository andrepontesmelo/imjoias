using System;
using System.Drawing;

namespace C�digoDeBarras
{
	/// <summary>
	/// Interface de gerador de c�digo de barras
	/// </summary>
	public abstract class GeradorC�digoDeBarras
	{
		private Size	     padr�oTamanho;
		private double	     padr�oLarguraBarraFina;
		private double	     padr�oFatorBarraGrossa;

		/// <summary>
		/// Tamanho padr�o da imagem
		/// </summary>
		public virtual Size Tamanho
		{
			get { return padr�oTamanho; }
			set { padr�oTamanho = value; }
		}
		
		/// <summary>
		/// Largura padr�o da barra fina
		/// </summary>
		public virtual double LarguraBarraFina
		{
			get { return padr�oLarguraBarraFina; }
			set { padr�oLarguraBarraFina = value; }
		}

		/// <summary>
		/// Fator multiplicativa padr�o da barra grossa
		/// </summary>
		public virtual double Padr�oFatorBarraGrossa
		{
			get { return padr�oFatorBarraGrossa; }
			set { padr�oFatorBarraGrossa = value; }
		}

		/// <summary>
		/// Constr�i a classe introduzindo valores padr�es
		/// </summary>
		public GeradorC�digoDeBarras()
		{
			padr�oTamanho          = new Size(150, 100);
			padr�oLarguraBarraFina = 1;
			padr�oFatorBarraGrossa = 2;
		}

		/// <summary>
		/// Gera imagem de c�digo de barras, enquadrando-o
		/// ao tamanho requerido.
		/// </summary>
		/// <returns>Imagem do c�digo de barras</returns>
		public virtual Image GerarImagem(string c�digo)
		{
			bool [] c�digoBooleano;
			int     barrasGrossas;
			int     barrasFinas;
			double	larguraBarraFina;

			c�digoBooleano = GerarC�digoBooleano(c�digo);
			
			CalcularTamanho(c�digoBooleano, out barrasFinas, out barrasGrossas);

			larguraBarraFina = (double) Tamanho.Width / (double) (barrasFinas + barrasGrossas * padr�oFatorBarraGrossa);

			return Desenhar(c�digoBooleano, Tamanho, larguraBarraFina, padr�oFatorBarraGrossa);
		}

		/// <summary>
		/// Gera c�digo booleano
		/// </summary>
		/// <param name="c�digo">C�digo original</param>
		/// <returns>C�digo booleano</returns>
		protected abstract bool [] GerarC�digoBooleano(string c�digo);

		/// <summary>
		/// Gera imagem de c�digo de barras
		/// </summary>
		/// <param name="c�digo">Codigo a ser gerado</param>
		/// <param name="tamanhoImagem">Tamanho em pixels da imagem</param>
		/// <param name="larguraBarraFina">Largura em pixels da barra fina</param>
		/// <param name="fatorBarraGrossa">Quantas vezes a barra grossa � maior que a barra fina</param>
		/// <returns>Imagem do c�digo de barras</returns>
		protected abstract Image Desenhar(bool [] c�digo, Size tamanhoImagem, double larguraBarraFina, double fatorBarraGrossa);

		/// <summary>
		/// Calcula a quantidade de barras finas e grossas
		/// </summary>
		/// <param name="c�digo">C�digo a ser verificado</param>
		/// <param name="barrasFinas">Quantidade de barras finas calculdadas</param>
		/// <param name="barrasGrossas">Quantidade de barras grossas calculadas</param>
		protected abstract void CalcularTamanho(bool [] c�digo, out int barrasFinas, out int barrasGrossas);
	}
}
