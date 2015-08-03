using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Álbum
{
	/// <summary>
	/// É um panel com várias fotos, uma do lado da outra.
	/// O seu tamanho é flexível e ajustável pela altura do controle. 
	/// Portanto, uma alteração na altura redimensiona as fotos para caberem.
	/// Existe um scrool horizontal.
	/// 
	/// As fotos podem ser selecionáveis.
	/// </summary>
	/// <remarks>
	/// Este panel é usado no catálogo.
	/// </remarks>
	public class PainelFotos : Panel
	{
		private const int		_espaçamentoFoto = 8;
		private int		        _próximaYFoto = 0;
		private int				_próximaXFoto = 0;
		private PictureBox		últimaFoto;					// Posicionamento picture fotos

        public enum Orientação { Horizontal, Vertical };
		
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// É necessário ter os controles à mão para que o descadastramento de eventos ocorra. 
		/// Usar o this.Controls é arriscado porque podem existir outros controles não 
		/// PictureBoxes específicos, o que ocasionaria em erro.
		/// </summary>
		private ArrayList lstPictBoxes = new ArrayList();  

		// Atributos referentes à propriedades
		private bool			selecionável = true;
		private PictureBox		fotoSelecionada = null;
        private Orientação      orientação = Orientação.Horizontal;

		// Delegações
		private EventHandler		delegatePicMouseEnter;
		private EventHandler		delegatePicMouseLeave;
		private EventHandler		delegatePicClick;
        private EventHandler        delegatePicDblClick;
		private PaintEventHandler	delegatePicPaint;
		public event EventHandler	FotoFoiSelecionada;

		public PainelFotos()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Criar elemento-de-prova pictureBox para posicionamento das fotos
			últimaFoto = new PictureBox();
			últimaFoto.Location = new Point(0,0);
			últimaFoto.Size = new Size(0,0);

			// Construir delegações
			delegatePicMouseEnter = new EventHandler(pic_MouseEnter);
			delegatePicMouseLeave = new EventHandler(pic_MouseLeave);
			delegatePicClick      = new EventHandler(pic_Click);
            delegatePicDblClick   = new EventHandler(pic_DoubleClick);
			delegatePicPaint      = new PaintEventHandler(pic_Paint);
		}

		#region Propriedades

		public Image FotoSelecionada
		{
			get
			{
				if (fotoSelecionada != null)
					return fotoSelecionada.Image;
				else 
					return null;
			}
		}

		[Browsable(true), DefaultValue(true), Description("Se o controle será selecionável ou não")]
		public bool Selecionável
		{
			get 
			{
				return selecionável;
			}
			set
			{
				if (lstPictBoxes.Count != 0) throw new NotImplementedException("Este controle não suporta mudança da propriedade Selecionável em tempo de execução.");
				
				selecionável = value;
			}
		}

        /// <summary>
        /// Orientação em que é inserida as imagens.
        /// </summary>
        public Orientação OrientaçãoFotos
        {
            get { return orientação; }
            set
            {
                if (lstPictBoxes.Count > 0)
                    throw new NotSupportedException("Não se pode alterar orientaçãom após inserir itens.");

                orientação = value;
            }
        }

		#endregion

		public void Limpar()
		{
            _próximaXFoto = _próximaYFoto = 0;
			fotoSelecionada = null;

			// Retira eventos dos PictureBoxes
			foreach (PictureBox pic in lstPictBoxes)
			{
				pic.MouseEnter -= delegatePicMouseEnter;
				pic.MouseLeave -= delegatePicMouseLeave;
				pic.Click      -= delegatePicClick;
				pic.Paint      -= delegatePicPaint;
                Controls.Remove(pic);
			}

			lstPictBoxes.Clear();
		}

		/// <summary>
		/// Retira a seleção de uma imagem,
		/// fotoSelecionada <- null
		/// </summary>
		public void Deselecionar()
		{
			fotoSelecionada = null;
			throw new NotImplementedException("retirar a seleção usando invalidade");
		}
		
		/// <summary>
		/// Adiciona uma imagem para seleção
		/// </summary>
		/// <param name="imagem">Imagem</param>
		public void AdicionarFoto(Image imagem)
		{
			PictureBox pic = new PictureBox();

			// Constrói o PictureBox
			pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))));

            switch (orientação)
            {
                case Orientação.Horizontal:
                    _próximaXFoto = últimaFoto.Location.X + últimaFoto.Width + _espaçamentoFoto;
                    pic.Height = this.ClientSize.Height;
                    pic.Width = (int)((float)imagem.Width / (float)imagem.Height * (float)pic.Height);
                    break;

                case Orientação.Vertical:
                    _próximaYFoto = últimaFoto.Location.Y + últimaFoto.Height + _espaçamentoFoto;
                    pic.Width = this.ClientSize.Width;
                    pic.Height = (int)((float)imagem.Height / (float)imagem.Width * (float)pic.Width);
                    break;

                default:
                    throw new NotSupportedException();
            }

			pic.Location = new Point(_próximaXFoto, _próximaYFoto);

			//_próximaXFoto += pic.Width + _espaçamentoFoto;
			pic.Visible  = true;
			pic.Name	 = "foto" + imagem.GetHashCode().ToString();
			pic.SizeMode = PictureBoxSizeMode.StretchImage;
			pic.Image    = new Bitmap(imagem);

            if (selecionável)
                pic.Cursor = Cursors.Hand;

			// Adiciona novo controle na lista
			lstPictBoxes.Add(pic);
			
			// Trata eventos do PictureBox
			pic.MouseEnter  += delegatePicMouseEnter;
			pic.MouseLeave  += delegatePicMouseLeave;
			pic.Click       += delegatePicClick;
            pic.DoubleClick += delegatePicDblClick;
			pic.Paint       += delegatePicPaint;
			
			// Ter noção do posicionamento
			últimaFoto = pic;

			SuspendLayout();
			Controls.Add(pic);
			ResumeLayout();

            this.ScrollToControl(pic);
		}

		/// <summary>
		/// Ocorre quando o mouse passa por cima da foto
		/// </summary>
		private void pic_MouseEnter(object sender, EventArgs e)
		{
			if (!selecionável) return;
			
			if (!object.ReferenceEquals(sender, fotoSelecionada))
			{
				PictureBox pic = (PictureBox) sender;

				using (Graphics g = Graphics.FromHwnd(pic.Handle))
				{
					g.DrawRectangle(Pens.Red, 0, 0, pic.ClientRectangle.Width - 2, pic.ClientRectangle.Height - 2);
					g.DrawRectangle(Pens.IndianRed, 1, 1, pic.ClientRectangle.Width - 2, pic.ClientRectangle.Height - 2);
				}
			}
		}
		/// <summary>
		/// Ocorre quando o mouse sai da foto
		/// </summary>
		private void pic_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox) sender).Invalidate();
		}

		/// <summary>
		/// Ocorre ao clicar na imagem
		/// </summary>
		private void pic_Click(object sender, EventArgs e)
		{
			if (selecionável)
			{
				PictureBox antiga = fotoSelecionada;

				fotoSelecionada = (PictureBox) sender;

				((PictureBox) sender).Invalidate();

				if (antiga != null)
					antiga.Invalidate();

				if (FotoFoiSelecionada != null)
					FotoFoiSelecionada(sender, e);
			}
		}

        /// <summary>
        /// Ocorre ao clicar duas vezes na imagem.
        /// </summary>
        private void pic_DoubleClick(object sender, EventArgs e)
        {
            if (fotoSelecionada != null)
                OnDoubleClick(e);
        }

		/// <summary>
		/// Ocorre ao desenhar uma foto
		/// </summary>
		private void pic_Paint(object sender, PaintEventArgs e)
		{
			if (object.ReferenceEquals(sender, fotoSelecionada))
			{
				e.Graphics.DrawRectangle(Pens.Gold, 0, 0, ((PictureBox) sender).ClientRectangle.Width - 2, ((PictureBox) sender).ClientRectangle.Height - 2);
				e.Graphics.DrawRectangle(Pens.Goldenrod, 1, 1, ((PictureBox) sender).ClientRectangle.Width - 2, ((PictureBox) sender).ClientRectangle.Height - 2);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

