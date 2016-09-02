namespace Apresentação.Fiscal
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
            this.opçãoImportaçãoXMLAtacado = new Apresentação.Formulários.Opção();
            this.opçãoImportaçãoTDMVarejo = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
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
            this.quadro1.Controls.Add(this.opçãoImportaçãoXMLAtacado);
            this.quadro1.Controls.Add(this.opçãoImportaçãoTDMVarejo);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 14);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 76);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Importação";
            // 
            // opçãoImportaçãoXMLAtacado
            // 
            this.opçãoImportaçãoXMLAtacado.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportaçãoXMLAtacado.Descrição = "Atacado - XML";
            this.opçãoImportaçãoXMLAtacado.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImportaçãoXMLAtacado.Imagem")));
            this.opçãoImportaçãoXMLAtacado.Location = new System.Drawing.Point(7, 30);
            this.opçãoImportaçãoXMLAtacado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportaçãoXMLAtacado.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportaçãoXMLAtacado.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoXMLAtacado.Name = "opçãoImportaçãoXMLAtacado";
            this.opçãoImportaçãoXMLAtacado.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoXMLAtacado.TabIndex = 3;
            this.opçãoImportaçãoXMLAtacado.Click += new System.EventHandler(this.opçãoImportaçãoXMLAtacado_Click);
            // 
            // opçãoImportaçãoTDMVarejo
            // 
            this.opçãoImportaçãoTDMVarejo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportaçãoTDMVarejo.Descrição = "Varejo - TDM";
            this.opçãoImportaçãoTDMVarejo.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImportaçãoTDMVarejo.Imagem")));
            this.opçãoImportaçãoTDMVarejo.Location = new System.Drawing.Point(7, 50);
            this.opçãoImportaçãoTDMVarejo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportaçãoTDMVarejo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportaçãoTDMVarejo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoTDMVarejo.Name = "opçãoImportaçãoTDMVarejo";
            this.opçãoImportaçãoTDMVarejo.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoTDMVarejo.TabIndex = 2;
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Acesso aos documentos fiscais da empresa.";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = ((System.Drawing.Image)(resources.GetObject("títuloBaseInferior1.Imagem")));
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 14);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(591, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Fiscal";
            // 
            // BaseFiscal
            // 
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseFiscal";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoImportaçãoTDMVarejo;
        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Opção opçãoImportaçãoXMLAtacado;
    }
}
