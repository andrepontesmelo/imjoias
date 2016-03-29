namespace Apresenta��o.Integra��oSistemaAntigo.Fiscal
{
    partial class BaseFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFiscal));
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.op��oIn�cio = new Apresenta��o.Formul�rios.Op��o();
            this.t�tuloBaseInferior1 = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadroErros = new Apresenta��o.Formul�rios.Quadro();
            this.txtErros = new System.Windows.Forms.TextBox();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroErros.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.op��oIn�cio);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 67);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "Iniciar";
            // 
            // op��oIn�cio
            // 
            this.op��oIn�cio.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oIn�cio.Descri��o = "In�cio";
            this.op��oIn�cio.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oIn�cio.Imagem")));
            this.op��oIn�cio.Location = new System.Drawing.Point(5, 36);
            this.op��oIn�cio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oIn�cio.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oIn�cio.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oIn�cio.Name = "op��oIn�cio";
            this.op��oIn�cio.Size = new System.Drawing.Size(150, 24);
            this.op��oIn�cio.TabIndex = 2;
            this.op��oIn�cio.Click += new System.EventHandler(this.op��oIn�cio_Click);
            // 
            // t�tuloBaseInferior1
            // 
            this.t�tuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior1.Descri��o = "Ao clicar in�cio, dois arquivos ser�o gerados contendo os pre�os de varejo para i" +
                "mpressora fiscal. ";
            this.t�tuloBaseInferior1.Imagem = null;
            this.t�tuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.t�tuloBaseInferior1.Name = "t�tuloBaseInferior1";
            this.t�tuloBaseInferior1.Size = new System.Drawing.Size(592, 70);
            this.t�tuloBaseInferior1.TabIndex = 7;
            this.t�tuloBaseInferior1.T�tulo = "Gera��o de arquivo de entrada para impressora fiscal";
            // 
            // quadroErros
            // 
            this.quadroErros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroErros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroErros.bInfDirArredondada = false;
            this.quadroErros.bInfEsqArredondada = false;
            this.quadroErros.bSupDirArredondada = true;
            this.quadroErros.bSupEsqArredondada = true;
            this.quadroErros.Controls.Add(this.txtErros);
            this.quadroErros.Cor = System.Drawing.Color.Black;
            this.quadroErros.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroErros.LetraT�tulo = System.Drawing.Color.White;
            this.quadroErros.Location = new System.Drawing.Point(190, 112);
            this.quadroErros.MostrarBot�oMinMax = false;
            this.quadroErros.Name = "quadroErros";
            this.quadroErros.Size = new System.Drawing.Size(573, 171);
            this.quadroErros.TabIndex = 8;
            this.quadroErros.Tamanho = 30;
            this.quadroErros.T�tulo = "Erros no processo";
            this.quadroErros.Visible = false;
            // 
            // txtErros
            // 
            this.txtErros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErros.Location = new System.Drawing.Point(3, 25);
            this.txtErros.Multiline = true;
            this.txtErros.Name = "txtErros";
            this.txtErros.ReadOnly = true;
            this.txtErros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErros.Size = new System.Drawing.Size(567, 143);
            this.txtErros.TabIndex = 7;
            // 
            // BaseFiscal
            // 
            this.Controls.Add(this.quadroErros);
            this.Controls.Add(this.t�tuloBaseInferior1);
            this.Name = "BaseFiscal";
            this.Controls.SetChildIndex(this.t�tuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadroErros, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroErros.ResumeLayout(false);
            this.quadroErros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.Quadro quadro1;
        private Apresenta��o.Formul�rios.Op��o op��oIn�cio;
        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior1;
        private Apresenta��o.Formul�rios.Quadro quadroErros;
        private System.Windows.Forms.TextBox txtErros;
    }
}
