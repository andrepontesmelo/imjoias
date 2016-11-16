using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public sealed class Splash : Form
	{
		private PictureBox pictureBox1;
        private Label lblDesenvolvidoPor;
        private Label lblMensagem;
        private Label lblVersão;

        private System.ComponentModel.Container components = null;

        public Splash()
        {
            Cursor.Current = Cursors.AppStarting;

            InitializeComponent();

            lblVersão.Text = "";

            Application.DoEvents();
        }

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDesenvolvidoPor = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.lblVersão = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Apresentação.Resource.logo;
            this.pictureBox1.Location = new System.Drawing.Point(32, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblDesenvolvidoPor
            // 
            this.lblDesenvolvidoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesenvolvidoPor.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesenvolvidoPor.ForeColor = System.Drawing.Color.Black;
            this.lblDesenvolvidoPor.Location = new System.Drawing.Point(277, 225);
            this.lblDesenvolvidoPor.Name = "lblDesenvolvidoPor";
            this.lblDesenvolvidoPor.Size = new System.Drawing.Size(154, 31);
            this.lblDesenvolvidoPor.TabIndex = 1;
            this.lblDesenvolvidoPor.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblMensagem
            // 
            this.lblMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblMensagem.Location = new System.Drawing.Point(8, 231);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(263, 24);
            this.lblMensagem.TabIndex = 2;
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblVersão
            // 
            this.lblVersão.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersão.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblVersão.Location = new System.Drawing.Point(33, 9);
            this.lblVersão.Name = "lblVersão";
            this.lblVersão.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVersão.Size = new System.Drawing.Size(401, 20);
            this.lblVersão.TabIndex = 7;
            this.lblVersão.Text = ",";
            // 
            // Splash
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 262);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersão);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.lblDesenvolvidoPor);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closed += new System.EventHandler(this.Splash_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Splash_Closed(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Cursor.Current = Cursors.Default;
		}

		public string Mensagem
		{
			get { return lblMensagem.Text; }
			set
			{
				lblMensagem.Text = value;
				lblMensagem.Refresh();
                Application.DoEvents();
			}
		}
    }
}
