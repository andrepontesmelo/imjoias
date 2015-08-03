namespace Apresentação.Usuário.Financeiro
{
    partial class NotificaçãoCotação
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificaçãoCotação));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imagem = new System.Windows.Forms.PictureBox();
            this.rótuloResponsável = new System.Windows.Forms.Label();
            this.lblResponsável = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCotação = new System.Windows.Forms.Label();
            this.quadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // quadro
            // 
            this.quadro.Controls.Add(this.lblCotação);
            this.quadro.Controls.Add(this.rótuloResponsável);
            this.quadro.Controls.Add(this.imagem);
            this.quadro.Controls.Add(this.lblResponsável);
            this.quadro.Controls.Add(this.label2);
            this.quadro.Controls.Add(this.lblData);
            this.quadro.Controls.Add(this.label1);
            this.quadro.Size = new System.Drawing.Size(288, 153);
            this.quadro.Título = "Cotação do Ouro";
            this.quadro.Controls.SetChildIndex(this.label1, 0);
            this.quadro.Controls.SetChildIndex(this.lblData, 0);
            this.quadro.Controls.SetChildIndex(this.label2, 0);
            this.quadro.Controls.SetChildIndex(this.lblResponsável, 0);
            this.quadro.Controls.SetChildIndex(this.imagem, 0);
            this.quadro.Controls.SetChildIndex(this.rótuloResponsável, 0);
            this.quadro.Controls.SetChildIndex(this.lblCotação, 0);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "aumento");
            this.imageList.Images.SetKeyName(1, "queda");
            // 
            // imagem
            // 
            this.imagem.BackColor = System.Drawing.Color.Transparent;
            this.imagem.BackgroundImage = global::Apresentação.Resource.botão___ouro;
            this.imagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imagem.Location = new System.Drawing.Point(20, 37);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(32, 32);
            this.imagem.TabIndex = 2;
            this.imagem.TabStop = false;
            // 
            // rótuloResponsável
            // 
            this.rótuloResponsável.AutoSize = true;
            this.rótuloResponsável.Location = new System.Drawing.Point(58, 37);
            this.rótuloResponsável.Name = "rótuloResponsável";
            this.rótuloResponsável.Size = new System.Drawing.Size(72, 13);
            this.rótuloResponsável.TabIndex = 3;
            this.rótuloResponsável.Text = "Responsável:";
            // 
            // lblResponsável
            // 
            this.lblResponsável.AutoSize = true;
            this.lblResponsável.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponsável.Location = new System.Drawing.Point(58, 54);
            this.lblResponsável.Name = "lblResponsável";
            this.lblResponsável.Size = new System.Drawing.Size(93, 13);
            this.lblResponsável.TabIndex = 4;
            this.lblResponsável.Text = "lblResponsável";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(58, 89);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(47, 13);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "lblData";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cotação:";
            // 
            // lblCotação
            // 
            this.lblCotação.AutoSize = true;
            this.lblCotação.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCotação.Location = new System.Drawing.Point(58, 124);
            this.lblCotação.Name = "lblCotação";
            this.lblCotação.Size = new System.Drawing.Size(84, 17);
            this.lblCotação.TabIndex = 8;
            this.lblCotação.Text = "lblCotação";
            // 
            // NotificaçãoCotação
            // 
            this.ClientSize = new System.Drawing.Size(288, 153);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NotificaçãoCotação";
            this.Título = "Cotação do Ouro";
            this.quadro.ResumeLayout(false);
            this.quadro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label rótuloResponsável;
        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Label lblResponsável;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCotação;
    }
}
