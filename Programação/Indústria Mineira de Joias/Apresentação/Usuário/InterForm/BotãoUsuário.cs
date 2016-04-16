using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Acesso.Comum;
using Apresentação.Formulários;
using Entidades.Privilégio;

[assembly: ExporBotão(typeof(Apresentação.Usuário.InterForm.BotãoUsuário))]

namespace Apresentação.Usuário.InterForm
{
	/// <summary>
	/// Botão de configuração do usuário.
	/// </summary>
	public class BotãoUsuário : Apresentação.Formulários.Botão
	{
		/// <summary>
		/// Altura ideal da foto em pixels.
		/// </summary>
		private const int alturaIdeal = 57;
		private const int tamanhoBorda = 4;

		/// <summary>
		/// Constrói o botão de configuração do usuário.
		/// </summary>
		public BotãoUsuário()
		{
            Imagem = Resource.empregado;
            this.Texto = "Usuário";
            Ordenação = int.MaxValue;
		}

		/// <summary>
		/// Delegação para atualizar botão com dados do funcionário.
		/// </summary>
		private delegate void DAtualizar(Entidades.Pessoa.Funcionário funcionário);

		/// <summary>
		/// Atualiza botão assincronamente.
		/// </summary>
		/// <param name="funcionário">Dados do funcionário.</param>
		internal void AtualizarAssincronamente(Entidades.Pessoa.Funcionário funcionário)
		{
			DAtualizar atualizar;

			atualizar = new DAtualizar(Atualizar);

			atualizar.BeginInvoke(
				funcionário,
				new AsyncCallback(AtualizarCallback),
				atualizar);
		}

		/// <summary>
		/// Ocorre ao finalizar a atualização assíncrona.
		/// </summary>
		private void AtualizarCallback(IAsyncResult resultado)
		{
			DAtualizar atualizar;

			atualizar = (DAtualizar) resultado.AsyncState;
			atualizar.EndInvoke(resultado);
		}

		/// <summary>
		/// Atualiza botão com os dados do funcionário.
		/// </summary>
		/// <param name="funcionário">Dados do funcionário.</param>
		internal void Atualizar(Entidades.Pessoa.Funcionário funcionário)
		{
			Texto  = funcionário.PrimeiroNome;
		}

		/// <summary>
		/// Recupera imagem original.
		/// </summary>
		private void RecuperarImagemOriginal()
		{
            this.Imagem = Resource.empregado;
		}

		/// <summary>
		/// Constrói borda na foto do usuário.
		/// </summary>
		/// <param name="foto">Foto a ser emoldurada.</param>
		/// <returns>Foto emoldurada.</returns>
		private Image ConstruirBorda(Image foto)
		{
			Bitmap    bmp;
			Brush     brushEsquerda, brushCima, brushDireita, brushBaixo;
			Pen       penEsquerda, penCima, penDireita, penBaixo;
			Rectangle retânguloED, retânguloCB;

			// Preparar brush e caneta.
			retânguloED = new Rectangle(0, 0, tamanhoBorda - 2, foto.Height - 2);
			retânguloCB = new Rectangle(0, 0, foto.Width - 2, tamanhoBorda - 2);

			penEsquerda = penCima = Pens.Gold;
			penDireita = penBaixo = Pens.Goldenrod;

			brushEsquerda = new LinearGradientBrush(retânguloED, Color.Gold, Color.Goldenrod, 90f);
			brushCima     = new LinearGradientBrush(retânguloCB, Color.Gold, Color.Goldenrod, 0f);
			brushDireita  = new LinearGradientBrush(retânguloED, Color.Goldenrod, Color.Gold, 90f);
			brushBaixo    = new LinearGradientBrush(retânguloCB, Color.Goldenrod, Color.Gold, 0f);

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
		/// Calcula tamanho ideal da foto do usuário.
		/// </summary>
		/// <param name="foto">Foto do usuário.</param>
		/// <returns>Tamanho ideal para o botão.</returns>
		private static Size CalcularTamanhoIdeal(Image foto)
		{
			float proporção = alturaIdeal / (float) foto.Height;

			return new Size(Convert.ToInt32(Math.Round(foto.Width * proporção)), alturaIdeal);
		}

		/// <summary>
		/// Constrói o controlador padrão do botão.
		/// </summary>
		/// <returns>Controlador do botão.</returns>
		protected override Apresentação.Formulários.ControladorBaseInferior ConstruirControladorPadrão()
		{
			return new ControladorUsuário(this);
		}
	}
}