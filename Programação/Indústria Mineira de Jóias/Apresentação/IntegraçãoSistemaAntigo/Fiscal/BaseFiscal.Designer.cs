namespace Apresentação.IntegraçãoSistemaAntigo.Fiscal
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
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoInício = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroErros = new Apresentação.Formulários.Quadro();
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
            this.quadro1.Controls.Add(this.opçãoInício);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 67);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Iniciar";
            // 
            // opçãoInício
            // 
            this.opçãoInício.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoInício.Descrição = "Início";
            this.opçãoInício.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoInício.Imagem")));
            this.opçãoInício.Location = new System.Drawing.Point(5, 36);
            this.opçãoInício.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoInício.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoInício.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoInício.Name = "opçãoInício";
            this.opçãoInício.Size = new System.Drawing.Size(150, 24);
            this.opçãoInício.TabIndex = 2;
            this.opçãoInício.Click += new System.EventHandler(this.opçãoInício_Click);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Ao clicar início, dois arquivos serão gerados contendo os preços de varejo para i" +
                "mpressora fiscal. ";
            this.títuloBaseInferior1.Imagem = null;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(592, 70);
            this.títuloBaseInferior1.TabIndex = 7;
            this.títuloBaseInferior1.Título = "Geração de arquivo de entrada para impressora fiscal";
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
            this.quadroErros.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroErros.LetraTítulo = System.Drawing.Color.White;
            this.quadroErros.Location = new System.Drawing.Point(190, 112);
            this.quadroErros.MostrarBotãoMinMax = false;
            this.quadroErros.Name = "quadroErros";
            this.quadroErros.Size = new System.Drawing.Size(573, 171);
            this.quadroErros.TabIndex = 8;
            this.quadroErros.Tamanho = 30;
            this.quadroErros.Título = "Erros no processo";
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
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseFiscal";
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadroErros, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroErros.ResumeLayout(false);
            this.quadroErros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opçãoInício;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Apresentação.Formulários.Quadro quadroErros;
        private System.Windows.Forms.TextBox txtErros;
    }
}
