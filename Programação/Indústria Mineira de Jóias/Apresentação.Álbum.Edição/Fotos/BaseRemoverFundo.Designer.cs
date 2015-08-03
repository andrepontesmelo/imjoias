namespace Apresentação.Álbum.Edição.Fotos
{
    partial class BaseRemoverFundo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.quadroFoto = new Apresentação.Formulários.Quadro();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProsseguir = new System.Windows.Forms.Button();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 453);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // quadroFoto
            // 
            this.quadroFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroFoto.bInfDirArredondada = false;
            this.quadroFoto.bInfEsqArredondada = false;
            this.quadroFoto.bSupDirArredondada = true;
            this.quadroFoto.bSupEsqArredondada = true;
            this.quadroFoto.Controls.Add(this.picFoto);
            this.quadroFoto.Cor = System.Drawing.Color.Black;
            this.quadroFoto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFoto.LetraTítulo = System.Drawing.Color.White;
            this.quadroFoto.Location = new System.Drawing.Point(205, 86);
            this.quadroFoto.MostrarBotãoMinMax = false;
            this.quadroFoto.Name = "quadroFoto";
            this.quadroFoto.Size = new System.Drawing.Size(400, 324);
            this.quadroFoto.TabIndex = 7;
            this.quadroFoto.Tamanho = 30;
            this.quadroFoto.Título = "Tratamento de Imagem";
            // 
            // picFoto
            // 
            this.picFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picFoto.BackgroundImage = global::Apresentação.Álbum.Edição.Properties.Resources.FundoTransparência;
            this.picFoto.Location = new System.Drawing.Point(1, 24);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(398, 299);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 1;
            this.picFoto.TabStop = false;
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Verifique se a remoção de fundo está adequada e ajustes os parâmetros, caso neces" +
                "sário.";
            this.títuloBaseInferior.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.camera1;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(489, 70);
            this.títuloBaseInferior.TabIndex = 8;
            this.títuloBaseInferior.Título = "Remoção de fundo";
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.Location = new System.Drawing.Point(626, 110);
            this.trackBar.Maximum = 50;
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar.Size = new System.Drawing.Size(45, 300);
            this.trackBar.TabIndex = 9;
            this.trackBar.TickFrequency = 5;
            this.trackBar.Value = 10;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tolerância";
            // 
            // btnProsseguir
            // 
            this.btnProsseguir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProsseguir.Enabled = false;
            this.btnProsseguir.Location = new System.Drawing.Point(530, 416);
            this.btnProsseguir.Name = "btnProsseguir";
            this.btnProsseguir.Size = new System.Drawing.Size(75, 23);
            this.btnProsseguir.TabIndex = 11;
            this.btnProsseguir.Text = "Prosseguir";
            this.btnProsseguir.UseVisualStyleBackColor = true;
            this.btnProsseguir.Click += new System.EventHandler(this.btnProsseguir_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.label2);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 106);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Instruções";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 66);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ajuste se necessário a tolerância de diferença com a imagem de fundo, caso parte " +
                "da mercadoria seja confundida com o fundo.";
            // 
            // BaseRemoverFundo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnProsseguir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.quadroFoto);
            this.Name = "BaseRemoverFundo";
            this.Size = new System.Drawing.Size(685, 453);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroFoto, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.trackBar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnProsseguir, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apresentação.Formulários.Quadro quadroFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private System.Windows.Forms.TrackBar trackBar;
        private Apresentação.Formulários.Quadro quadro1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProsseguir;
    }
}
