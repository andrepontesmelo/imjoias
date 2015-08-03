using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// T�tulo da base inferior.
	/// </summary>
	public sealed class T�tuloBaseInferior : System.Windows.Forms.UserControl
	{
        private const int tamanhoBordaArredondadaDo�cone = 8;
		private const int alturaM�xima = 70;
        private bool �coneArredondado = false;

		private System.Windows.Forms.PictureBox picImagem;
		private System.Windows.Forms.Label lblT�tulo;
		private System.Windows.Forms.Label lblDescri��o;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public T�tuloBaseInferior()
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
            this.lblT�tulo = new System.Windows.Forms.Label();
            this.lblDescri��o = new System.Windows.Forms.Label();
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
            // lblT�tulo
            // 
            this.lblT�tulo.AutoSize = true;
            this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT�tulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblT�tulo.Location = new System.Drawing.Point(3, 0);
            this.lblT�tulo.Name = "lblT�tulo";
            this.lblT�tulo.Size = new System.Drawing.Size(56, 24);
            this.lblT�tulo.TabIndex = 1;
            this.lblT�tulo.Text = "T�tulo";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescri��o.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDescri��o.Location = new System.Drawing.Point(3, 24);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Size = new System.Drawing.Size(333, 23);
            this.lblDescri��o.TabIndex = 2;
            this.lblDescri��o.Text = "Descri��o";
            // 
            // T�tuloBaseInferior
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDescri��o);
            this.Controls.Add(this.lblT�tulo);
            this.Controls.Add(this.picImagem);
            this.Name = "T�tuloBaseInferior";
            this.Size = new System.Drawing.Size(336, 80);
            this.Resize += new System.EventHandler(this.T�tuloBaseInferior_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Ocorre ao redimensionar a janela.
		/// </summary>
		private void T�tuloBaseInferior_Resize(object sender, System.EventArgs e)
		{
			this.Height = alturaM�xima;

			lblDescri��o.Width = ClientSize.Width - lblDescri��o.Left;
			lblDescri��o.Height = ClientSize.Height - lblDescri��o.Top;
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
					if (value.Size.Height <= alturaM�xima)
					{
						picImagem.SizeMode = PictureBoxSizeMode.AutoSize;
					}
					else
					{
						picImagem.SizeMode = PictureBoxSizeMode.StretchImage;
						picImagem.Width    = (int) Math.Round((float) alturaM�xima / value.Height * value.Width);
						picImagem.Height   = alturaM�xima;
					}

					picImagem.Image = value;
				}

				lblDescri��o.Left = lblT�tulo.Left = picImagem.Width + picImagem.Left + 8;
				lblDescri��o.Height = picImagem.Height - picImagem.Top - (lblDescri��o.Top - picImagem.Top);

                if (�coneArredondado)
                {              
                    GraphicsPath caminho = new GraphicsPath();

                    caminho.AddArc(0, 0, tamanhoBordaArredondadaDo�cone, tamanhoBordaArredondadaDo�cone, 180, 90);
                    caminho.AddArc(picImagem.Width - tamanhoBordaArredondadaDo�cone, 0, tamanhoBordaArredondadaDo�cone, tamanhoBordaArredondadaDo�cone, 270, 90);
                    caminho.AddArc(picImagem.Width - tamanhoBordaArredondadaDo�cone, picImagem.Height - tamanhoBordaArredondadaDo�cone, tamanhoBordaArredondadaDo�cone, tamanhoBordaArredondadaDo�cone, 0, 90);
                    caminho.AddArc(0, picImagem.Height - tamanhoBordaArredondadaDo�cone, tamanhoBordaArredondadaDo�cone, tamanhoBordaArredondadaDo�cone, 90, 90);
                    caminho.CloseFigure();

                    // Cria regi�o baseada nos limites
                    picImagem.Region = new Region(caminho);
                }

				Invalidate();
			}
		}

		public string T�tulo
		{
			get { return lblT�tulo.Text; }
			set 
            { 
                lblT�tulo.Text = value;
                lblDescri��o.Width = ClientSize.Width - lblDescri��o.Left;
                lblDescri��o.Height = ClientSize.Height - lblDescri��o.Top;
            }
		}

		public string Descri��o
		{
			get { return lblDescri��o.Text; }
			set 
            {
                lblDescri��o.Text = value;
                lblDescri��o.Width = ClientSize.Width - lblDescri��o.Left;
                lblDescri��o.Height = ClientSize.Height - lblDescri��o.Top;
            }
		}

        public bool �coneArredondado
        {
            get { return �coneArredondado; }
            set { �coneArredondado = value; }
        }
	}
}
