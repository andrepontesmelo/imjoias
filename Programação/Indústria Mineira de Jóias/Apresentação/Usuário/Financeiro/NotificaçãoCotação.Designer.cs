namespace Apresenta��o.Usu�rio.Financeiro
{
    partial class Notifica��oCota��o
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notifica��oCota��o));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imagem = new System.Windows.Forms.PictureBox();
            this.r�tuloRespons�vel = new System.Windows.Forms.Label();
            this.lblRespons�vel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCota��o = new System.Windows.Forms.Label();
            this.quadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // quadro
            // 
            this.quadro.Controls.Add(this.lblCota��o);
            this.quadro.Controls.Add(this.r�tuloRespons�vel);
            this.quadro.Controls.Add(this.imagem);
            this.quadro.Controls.Add(this.lblRespons�vel);
            this.quadro.Controls.Add(this.label2);
            this.quadro.Controls.Add(this.lblData);
            this.quadro.Controls.Add(this.label1);
            this.quadro.Size = new System.Drawing.Size(288, 153);
            this.quadro.T�tulo = "Cota��o do Ouro";
            this.quadro.Controls.SetChildIndex(this.label1, 0);
            this.quadro.Controls.SetChildIndex(this.lblData, 0);
            this.quadro.Controls.SetChildIndex(this.label2, 0);
            this.quadro.Controls.SetChildIndex(this.lblRespons�vel, 0);
            this.quadro.Controls.SetChildIndex(this.imagem, 0);
            this.quadro.Controls.SetChildIndex(this.r�tuloRespons�vel, 0);
            this.quadro.Controls.SetChildIndex(this.lblCota��o, 0);
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
            this.imagem.BackgroundImage = global::Apresenta��o.Resource.bot�o___ouro;
            this.imagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imagem.Location = new System.Drawing.Point(20, 37);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(32, 32);
            this.imagem.TabIndex = 2;
            this.imagem.TabStop = false;
            // 
            // r�tuloRespons�vel
            // 
            this.r�tuloRespons�vel.AutoSize = true;
            this.r�tuloRespons�vel.Location = new System.Drawing.Point(58, 37);
            this.r�tuloRespons�vel.Name = "r�tuloRespons�vel";
            this.r�tuloRespons�vel.Size = new System.Drawing.Size(72, 13);
            this.r�tuloRespons�vel.TabIndex = 3;
            this.r�tuloRespons�vel.Text = "Respons�vel:";
            // 
            // lblRespons�vel
            // 
            this.lblRespons�vel.AutoSize = true;
            this.lblRespons�vel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespons�vel.Location = new System.Drawing.Point(58, 54);
            this.lblRespons�vel.Name = "lblRespons�vel";
            this.lblRespons�vel.Size = new System.Drawing.Size(93, 13);
            this.lblRespons�vel.TabIndex = 4;
            this.lblRespons�vel.Text = "lblRespons�vel";
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
            this.label2.Text = "Cota��o:";
            // 
            // lblCota��o
            // 
            this.lblCota��o.AutoSize = true;
            this.lblCota��o.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCota��o.Location = new System.Drawing.Point(58, 124);
            this.lblCota��o.Name = "lblCota��o";
            this.lblCota��o.Size = new System.Drawing.Size(84, 17);
            this.lblCota��o.TabIndex = 8;
            this.lblCota��o.Text = "lblCota��o";
            // 
            // Notifica��oCota��o
            // 
            this.ClientSize = new System.Drawing.Size(288, 153);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Notifica��oCota��o";
            this.T�tulo = "Cota��o do Ouro";
            this.quadro.ResumeLayout(false);
            this.quadro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label r�tuloRespons�vel;
        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Label lblRespons�vel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCota��o;
    }
}
