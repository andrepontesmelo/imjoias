using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.�lbum
{
	/// <summary>
	/// � um panel com v�rias fotos, uma do lado da outra.
	/// O seu tamanho � flex�vel e ajust�vel pela altura do controle. 
	/// Portanto, uma altera��o na altura redimensiona as fotos para caberem.
	/// Existe um scrool horizontal.
	/// 
	/// As fotos podem ser selecion�veis.
	/// </summary>
	/// <remarks>
	/// Este panel � usado no cat�logo.
	/// </remarks>
	public class PainelFotos : Panel
	{
		private const int		_espa�amentoFoto = 8;
		private int		        _pr�ximaYFoto = 0;
		private int				_pr�ximaXFoto = 0;
		private PictureBox		�ltimaFoto;					// Posicionamento picture fotos

        public enum Orienta��o { Horizontal, Vertical };
		
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// � necess�rio ter os controles � m�o para que o descadastramento de eventos ocorra. 
		/// Usar o this.Controls � arriscado porque podem existir outros controles n�o 
		/// PictureBoxes espec�ficos, o que ocasionaria em erro.
		/// </summary>
		private ArrayList lstPictBoxes = new ArrayList();  

		// Atributos referentes � propriedades
		private bool			selecion�vel = true;
		private PictureBox		fotoSelecionada = null;
        private Orienta��o      orienta��o = Orienta��o.Horizontal;

		// Delega��es
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
			�ltimaFoto = new PictureBox();
			�ltimaFoto.Location = new Point(0,0);
			�ltimaFoto.Size = new Size(0,0);

			// Construir delega��es
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

		[Browsable(true), DefaultValue(true), Description("Se o controle ser� selecion�vel ou n�o")]
		public bool Selecion�vel
		{
			get 
			{
				return selecion�vel;
			}
			set
			{
				if (lstPictBoxes.Count != 0) throw new NotImplementedException("Este controle n�o suporta mudan�a da propriedade Selecion�vel em tempo de execu��o.");
				
				selecion�vel = value;
			}
		}

        /// <summary>
        /// Orienta��o em que � inserida as imagens.
        /// </summary>
        public Orienta��o Orienta��oFotos
        {
            get { return orienta��o; }
            set
            {
                if (lstPictBoxes.Count > 0)
                    throw new NotSupportedException("N�o se pode alterar orienta��om ap�s inserir itens.");

                orienta��o = value;
            }
        }

		#endregion

		public void Limpar()
		{
            _pr�ximaXFoto = _pr�ximaYFoto = 0;
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
		/// Retira a sele��o de uma imagem,
		/// fotoSelecionada <- null
		/// </summary>
		public void Deselecionar()
		{
			fotoSelecionada = null;
			throw new NotImplementedException("retirar a sele��o usando invalidade");
		}
		
		/// <summary>
		/// Adiciona uma imagem para sele��o
		/// </summary>
		/// <param name="imagem">Imagem</param>
		public void AdicionarFoto(Image imagem)
		{
			PictureBox pic = new PictureBox();

			// Constr�i o PictureBox
			pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))));

            switch (orienta��o)
            {
                case Orienta��o.Horizontal:
                    _pr�ximaXFoto = �ltimaFoto.Location.X + �ltimaFoto.Width + _espa�amentoFoto;
                    pic.Height = this.ClientSize.Height;
                    pic.Width = (int)((float)imagem.Width / (float)imagem.Height * (float)pic.Height);
                    break;

                case Orienta��o.Vertical:
                    _pr�ximaYFoto = �ltimaFoto.Location.Y + �ltimaFoto.Height + _espa�amentoFoto;
                    pic.Width = this.ClientSize.Width;
                    pic.Height = (int)((float)imagem.Height / (float)imagem.Width * (float)pic.Width);
                    break;

                default:
                    throw new NotSupportedException();
            }

			pic.Location = new Point(_pr�ximaXFoto, _pr�ximaYFoto);

			//_pr�ximaXFoto += pic.Width + _espa�amentoFoto;
			pic.Visible  = true;
			pic.Name	 = "foto" + imagem.GetHashCode().ToString();
			pic.SizeMode = PictureBoxSizeMode.StretchImage;
			pic.Image    = new Bitmap(imagem);

            if (selecion�vel)
                pic.Cursor = Cursors.Hand;

			// Adiciona novo controle na lista
			lstPictBoxes.Add(pic);
			
			// Trata eventos do PictureBox
			pic.MouseEnter  += delegatePicMouseEnter;
			pic.MouseLeave  += delegatePicMouseLeave;
			pic.Click       += delegatePicClick;
            pic.DoubleClick += delegatePicDblClick;
			pic.Paint       += delegatePicPaint;
			
			// Ter no��o do posicionamento
			�ltimaFoto = pic;

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
			if (!selecion�vel) return;
			
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
			if (selecion�vel)
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

