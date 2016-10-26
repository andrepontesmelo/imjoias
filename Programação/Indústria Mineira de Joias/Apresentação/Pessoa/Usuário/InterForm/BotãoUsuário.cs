using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Acesso.Comum;
using Apresenta��o.Formul�rios;
using Entidades.Privil�gio;

[assembly: ExporBot�o(typeof(Apresenta��o.Usu�rio.InterForm.Bot�oUsu�rio))]

namespace Apresenta��o.Usu�rio.InterForm
{
	/// <summary>
	/// Bot�o de configura��o do usu�rio.
	/// </summary>
	public class Bot�oUsu�rio : Apresenta��o.Formul�rios.Bot�o
	{
		/// <summary>
		/// Altura ideal da foto em pixels.
		/// </summary>
		private const int alturaIdeal = 57;
		private const int tamanhoBorda = 4;

		/// <summary>
		/// Constr�i o bot�o de configura��o do usu�rio.
		/// </summary>
		public Bot�oUsu�rio()
		{
            Imagem = Resource.empregado;
            this.Texto = "Usu�rio";
            Ordena��o = int.MaxValue;
		}

		/// <summary>
		/// Delega��o para atualizar bot�o com dados do funcion�rio.
		/// </summary>
		private delegate void DAtualizar(Entidades.Pessoa.Funcion�rio funcion�rio);

		/// <summary>
		/// Atualiza bot�o assincronamente.
		/// </summary>
		/// <param name="funcion�rio">Dados do funcion�rio.</param>
		internal void AtualizarAssincronamente(Entidades.Pessoa.Funcion�rio funcion�rio)
		{
			DAtualizar atualizar;

			atualizar = new DAtualizar(Atualizar);

			atualizar.BeginInvoke(
				funcion�rio,
				new AsyncCallback(AtualizarCallback),
				atualizar);
		}

		/// <summary>
		/// Ocorre ao finalizar a atualiza��o ass�ncrona.
		/// </summary>
		private void AtualizarCallback(IAsyncResult resultado)
		{
			DAtualizar atualizar;

			atualizar = (DAtualizar) resultado.AsyncState;
			atualizar.EndInvoke(resultado);
		}

		/// <summary>
		/// Atualiza bot�o com os dados do funcion�rio.
		/// </summary>
		/// <param name="funcion�rio">Dados do funcion�rio.</param>
		internal void Atualizar(Entidades.Pessoa.Funcion�rio funcion�rio)
		{
			Texto  = funcion�rio.PrimeiroNome;
		}

		/// <summary>
		/// Recupera imagem original.
		/// </summary>
		private void RecuperarImagemOriginal()
		{
            this.Imagem = Resource.empregado;
		}

		/// <summary>
		/// Constr�i borda na foto do usu�rio.
		/// </summary>
		/// <param name="foto">Foto a ser emoldurada.</param>
		/// <returns>Foto emoldurada.</returns>
		private Image ConstruirBorda(Image foto)
		{
			Bitmap    bmp;
			Brush     brushEsquerda, brushCima, brushDireita, brushBaixo;
			Pen       penEsquerda, penCima, penDireita, penBaixo;
			Rectangle ret�nguloED, ret�nguloCB;

			// Preparar brush e caneta.
			ret�nguloED = new Rectangle(0, 0, tamanhoBorda - 2, foto.Height - 2);
			ret�nguloCB = new Rectangle(0, 0, foto.Width - 2, tamanhoBorda - 2);

			penEsquerda = penCima = Pens.Gold;
			penDireita = penBaixo = Pens.Goldenrod;

			brushEsquerda = new LinearGradientBrush(ret�nguloED, Color.Gold, Color.Goldenrod, 90f);
			brushCima     = new LinearGradientBrush(ret�nguloCB, Color.Gold, Color.Goldenrod, 0f);
			brushDireita  = new LinearGradientBrush(ret�nguloED, Color.Goldenrod, Color.Gold, 90f);
			brushBaixo    = new LinearGradientBrush(ret�nguloCB, Color.Goldenrod, Color.Gold, 0f);

			// Desenhar.
			bmp =  new Bitmap(foto, CalcularTamanhoIdeal(foto));

			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.FillRectangle(brushEsquerda, 1, 1, tamanhoBorda - 2, bmp.Height - 2);
				g.FillRectangle(brushCima, tamanhoBorda - 1, 1, bmp.Width - tamanhoBorda, tamanhoBorda - 2);
				g.FillRectangle(brushDireita, bmp.Width - tamanhoBorda + 1, tamanhoBorda - 2, tamanhoBorda - 2, bmp.Height - tamanhoBorda);
				g.FillRectangle(brushBaixo, tamanhoBorda - 1, bmp.Height - tamanhoBorda + 1, bmp.Width - tamanhoBorda, tamanhoBorda - 2);
				
				// Linha externa
				g.DrawLine(penEsquerda, 0, 0, 0, bmp.Height - 1);
				g.DrawLine(penCima, 1, 0, bmp.Width - 1, 0);
				g.DrawLine(penDireita, bmp.Width - 1, 1, bmp.Width - 1, bmp.Height - 1);
				g.DrawLine(penBaixo, 1, bmp.Height - 1, bmp.Width - 1, bmp.Height - 1);

				// Linha interna
				g.DrawLine(penDireita, tamanhoBorda - 1, tamanhoBorda - 1, tamanhoBorda - 1, bmp.Height - tamanhoBorda);
				g.DrawLine(penBaixo, tamanhoBorda - 1, tamanhoBorda - 1, bmp.Width - tamanhoBorda, tamanhoBorda - 1);
				g.DrawLine(penEsquerda, bmp.Width - tamanhoBorda, tamanhoBorda - 1, bmp.Width - tamanhoBorda, bmp.Height - tamanhoBorda);
				g.DrawLine(penCima, tamanhoBorda - 1, bmp.Height - tamanhoBorda, bmp.Width - tamanhoBorda, bmp.Height - tamanhoBorda);
			}

			return bmp;
		}

		/// <summary>
		/// Calcula tamanho ideal da foto do usu�rio.
		/// </summary>
		/// <param name="foto">Foto do usu�rio.</param>
		/// <returns>Tamanho ideal para o bot�o.</returns>
		private static Size CalcularTamanhoIdeal(Image foto)
		{
			float propor��o = alturaIdeal / (float) foto.Height;

			return new Size(Convert.ToInt32(Math.Round(foto.Width * propor��o)), alturaIdeal);
		}

		/// <summary>
		/// Constr�i o controlador padr�o do bot�o.
		/// </summary>
		/// <returns>Controlador do bot�o.</returns>
		protected override Apresenta��o.Formul�rios.ControladorBaseInferior ConstruirControladorPadr�o()
		{
			return new ControladorUsu�rio(this);
		}
	}
}