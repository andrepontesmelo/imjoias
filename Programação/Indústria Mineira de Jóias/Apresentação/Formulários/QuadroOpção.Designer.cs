namespace Apresenta��o.Formul�rios
{
    partial class QuadroOp��o
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
            this.quadroSimples1 = new Apresenta��o.Formul�rios.QuadroSimples();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblT�tulo = new System.Windows.Forms.Label();
            this.lblDescri��o = new System.Windows.Forms.Label();
            this.quadroSimples1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // quadroSimples1
            // 
            this.quadroSimples1.Borda = System.Drawing.Color.LightBlue;
            this.quadroSimples1.Controls.Add(this.lblDescri��o);
            this.quadroSimples1.Controls.Add(this.lblT�tulo);
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
            this.pic.Image = global::Apresenta��o.Resource.ooops;
            this.pic.Location = new System.Drawing.Point(3, 3);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(64, 64);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.AoClicar);
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.AutoSize = true;
            this.lblT�tulo.BackColor = System.Drawing.Color.Transparent;
            this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT�tulo.Location = new System.Drawing.Point(73, 3);
            this.lblT�tulo.Name = "lblT�tulo";
            this.lblT�tulo.Size = new System.Drawing.Size(53, 20);
            this.lblT�tulo.TabIndex = 1;
            this.lblT�tulo.Text = "T�tulo";
            this.lblT�tulo.UseMnemonic = false;
            this.lblT�tulo.Click += new System.EventHandler(this.AoClicar);
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescri��o.BackColor = System.Drawing.Color.Transparent;
            this.lblDescri��o.Location = new System.Drawing.Point(73, 23);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Size = new System.Drawing.Size(219, 44);
            this.lblDescri��o.TabIndex = 2;
            this.lblDescri��o.Text = "Descri��o";
            this.lblDescri��o.UseMnemonic = false;
            this.lblDescri��o.Click += new System.EventHandler(this.AoClicar);
            // 
            // QuadroOp��o
            // 
            this.Controls.Add(this.quadroSimples1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximumSize = new System.Drawing.Size(600, 70);
            this.MinimumSize = new System.Drawing.Size(200, 70);
            this.Name = "QuadroOp��o";
            this.Size = new System.Drawing.Size(295, 70);
            this.quadroSimples1.ResumeLayout(false);
            this.quadroSimples1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QuadroSimples quadroSimples1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblDescri��o;
        private System.Windows.Forms.Label lblT�tulo;
    }
}
