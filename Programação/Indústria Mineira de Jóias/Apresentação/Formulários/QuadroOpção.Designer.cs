namespace Apresentação.Formulários
{
    partial class QuadroOpção
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.quadroSimples1 = new Apresentação.Formulários.QuadroSimples();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblTítulo = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.quadroSimples1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // quadroSimples1
            // 
            this.quadroSimples1.Borda = System.Drawing.Color.LightBlue;
            this.quadroSimples1.Controls.Add(this.lblDescrição);
            this.quadroSimples1.Controls.Add(this.lblTítulo);
            this.quadroSimples1.Controls.Add(this.pic);
            this.quadroSimples1.Cor1 = System.Drawing.Color.White;
            this.quadroSimples1.Cor2 = System.Drawing.Color.LightBlue;
            this.quadroSimples1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadroSimples1.Location = new System.Drawing.Point(0, 0);
            this.quadroSimples1.Name = "quadroSimples1";
            this.quadroSimples1.Size = new System.Drawing.Size(295, 70);
            this.quadroSimples1.TabIndex = 0;
            this.quadroSimples1.Click += new System.EventHandler(this.AoClicar);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            this.pic.Image = global::Apresentação.Resource.ooops;
            this.pic.Location = new System.Drawing.Point(3, 3);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(64, 64);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.AoClicar);
            // 
            // lblTítulo
            // 
            this.lblTítulo.AutoSize = true;
            this.lblTítulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTítulo.Location = new System.Drawing.Point(73, 3);
            this.lblTítulo.Name = "lblTítulo";
            this.lblTítulo.Size = new System.Drawing.Size(53, 20);
            this.lblTítulo.TabIndex = 1;
            this.lblTítulo.Text = "Título";
            this.lblTítulo.UseMnemonic = false;
            this.lblTítulo.Click += new System.EventHandler(this.AoClicar);
            // 
            // lblDescrição
            // 
            this.lblDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrição.BackColor = System.Drawing.Color.Transparent;
            this.lblDescrição.Location = new System.Drawing.Point(73, 23);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(219, 44);
            this.lblDescrição.TabIndex = 2;
            this.lblDescrição.Text = "Descrição";
            this.lblDescrição.UseMnemonic = false;
            this.lblDescrição.Click += new System.EventHandler(this.AoClicar);
            // 
            // QuadroOpção
            // 
            this.Controls.Add(this.quadroSimples1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximumSize = new System.Drawing.Size(600, 70);
            this.MinimumSize = new System.Drawing.Size(200, 70);
            this.Name = "QuadroOpção";
            this.Size = new System.Drawing.Size(295, 70);
            this.quadroSimples1.ResumeLayout(false);
            this.quadroSimples1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QuadroSimples quadroSimples1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblDescrição;
        private System.Windows.Forms.Label lblTítulo;
    }
}
