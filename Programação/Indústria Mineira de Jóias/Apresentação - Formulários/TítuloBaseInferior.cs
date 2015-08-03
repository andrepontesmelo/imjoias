using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Título da base inferior.
	/// </summary>
	public sealed class TítuloBaseInferior : System.Windows.Forms.UserControl
	{
        private const int tamanhoBordaArredondadaDoÍcone = 8;
		private const int alturaMáxima = 70;
        private bool íconeArredondado = false;

		private System.Windows.Forms.PictureBox picImagem;
		private System.Windows.Forms.Label lblTítulo;
		private System.Windows.Forms.Label lblDescrição;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TítuloBaseInferior()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.lblTítulo = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // picImagem
            // 
            this.picImagem.Location = new System.Drawing.Point(0, 0);
            this.picImagem.Name = "picImagem";
            this.picImagem.Size = new System.Drawing.Size(1, 48);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImagem.TabIndex = 0;
            this.picImagem.TabStop = false;
            // 
            // lblTítulo
            // 
            this.lblTítulo.AutoSize = true;
            this.lblTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTítulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTítulo.Location = new System.Drawing.Point(3, 0);
            this.lblTítulo.Name = "lblTítulo";
            this.lblTítulo.Size = new System.Drawing.Size(56, 24);
            this.lblTítulo.TabIndex = 1;
            this.lblTítulo.Text = "Título";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrição.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDescrição.Location = new System.Drawing.Point(3, 24);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(333, 23);
            this.lblDescrição.TabIndex = 2;
            this.lblDescrição.Text = "Descrição";
            // 
            // TítuloBaseInferior
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDescrição);
            this.Controls.Add(this.lblTítulo);
            this.Controls.Add(this.picImagem);
            this.Name = "TítuloBaseInferior";
            this.Size = new System.Drawing.Size(336, 80);
            this.Resize += new System.EventHandler(this.TítuloBaseInferior_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Ocorre ao redimensionar a janela.
		/// </summary>
		private void TítuloBaseInferior_Resize(object sender, System.EventArgs e)
		{
			this.Height = alturaMáxima;

			lblDescrição.Width = ClientSize.Width - lblDescrição.Left;
			lblDescrição.Height = ClientSize.Height - lblDescrição.Top;
		}

		/// <summary>
		/// Imagem ilustratitva.
		/// </summary>
		public Image Imagem
		{
			get { return picImagem.Image; }
			set
			{
				picImagem.Image = null;

				if (value != null)
				{
					if (value.Size.Height <= alturaMáxima)
					{
						picImagem.SizeMode = PictureBoxSizeMode.AutoSize;
					}
					else
					{
						picImagem.SizeMode = PictureBoxSizeMode.StretchImage;
						picImagem.Width    = (int) Math.Round((float) alturaMáxima / value.Height * value.Width);
						picImagem.Height   = alturaMáxima;
					}

					picImagem.Image = value;
				}

				lblDescrição.Left = lblTítulo.Left = picImagem.Width + picImagem.Left + 8;
				lblDescrição.Height = picImagem.Height - picImagem.Top - (lblDescrição.Top - picImagem.Top);

                if (íconeArredondado)
                {              
                    GraphicsPath caminho = new GraphicsPath();

                    caminho.AddArc(0, 0, tamanhoBordaArredondadaDoÍcone, tamanhoBordaArredondadaDoÍcone, 180, 90);
                    caminho.AddArc(picImagem.Width - tamanhoBordaArredondadaDoÍcone, 0, tamanhoBordaArredondadaDoÍcone, tamanhoBordaArredondadaDoÍcone, 270, 90);
                    caminho.AddArc(picImagem.Width - tamanhoBordaArredondadaDoÍcone, picImagem.Height - tamanhoBordaArredondadaDoÍcone, tamanhoBordaArredondadaDoÍcone, tamanhoBordaArredondadaDoÍcone, 0, 90);
                    caminho.AddArc(0, picImagem.Height - tamanhoBordaArredondadaDoÍcone, tamanhoBordaArredondadaDoÍcone, tamanhoBordaArredondadaDoÍcone, 90, 90);
                    caminho.CloseFigure();

                    // Cria região baseada nos limites
                    picImagem.Region = new Region(caminho);
                }

				Invalidate();
			}
		}

		public string Título
		{
			get { return lblTítulo.Text; }
			set 
            { 
                lblTítulo.Text = value;
                lblDescrição.Width = ClientSize.Width - lblDescrição.Left;
                lblDescrição.Height = ClientSize.Height - lblDescrição.Top;
            }
		}

		public string Descrição
		{
			get { return lblDescrição.Text; }
			set 
            {
                lblDescrição.Text = value;
                lblDescrição.Width = ClientSize.Width - lblDescrição.Left;
                lblDescrição.Height = ClientSize.Height - lblDescrição.Top;
            }
		}

        public bool ÍconeArredondado
        {
            get { return íconeArredondado; }
            set { íconeArredondado = value; }
        }
	}
}
