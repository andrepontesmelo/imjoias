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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.opçãoImportaçãoXMLAtacadoEntrada = new Apresentação.Formulários.Opção();
            this.opçãoImportaçãoPDFAtacadoSaída = new Apresentação.Formulários.Opção();
            this.opçãoImportaçãoXMLAtacadoSaída = new Apresentação.Formulários.Opção();
            this.opçãoImportaçãoTDMVarejoSaída = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.opçãoCancelamentoXMLAtacadoSaída = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 303);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoCancelamentoXMLAtacadoSaída);
            this.quadro1.Controls.Add(this.label2);
            this.quadro1.Controls.Add(this.label1);
            this.quadro1.Controls.Add(this.opçãoImportaçãoXMLAtacadoEntrada);
            this.quadro1.Controls.Add(this.opçãoImportaçãoPDFAtacadoSaída);
            this.quadro1.Controls.Add(this.opçãoImportaçãoXMLAtacadoSaída);
            this.quadro1.Controls.Add(this.opçãoImportaçãoTDMVarejoSaída);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 14);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 197);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Importação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Saída";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Entrada";
            // 
            // opçãoImportaçãoXMLAtacadoEntrada
            // 
            this.opçãoImportaçãoXMLAtacadoEntrada.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportaçãoXMLAtacadoEntrada.Descrição = "XML @ Atacado";
            this.opçãoImportaçãoXMLAtacadoEntrada.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImportaçãoXMLAtacadoEntrada.Imagem")));
            this.opçãoImportaçãoXMLAtacadoEntrada.Location = new System.Drawing.Point(7, 50);
            this.opçãoImportaçãoXMLAtacadoEntrada.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportaçãoXMLAtacadoEntrada.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportaçãoXMLAtacadoEntrada.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoXMLAtacadoEntrada.Name = "opçãoImportaçãoXMLAtacadoEntrada";
            this.opçãoImportaçãoXMLAtacadoEntrada.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoXMLAtacadoEntrada.TabIndex = 5;
            this.opçãoImportaçãoXMLAtacadoEntrada.Click += new System.EventHandler(this.opçãoImportaçãoXMLAtacadoEntrada_Click);
            // 
            // opçãoImportaçãoPDFAtacadoSaída
            // 
            this.opçãoImportaçãoPDFAtacadoSaída.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportaçãoPDFAtacadoSaída.Descrição = "PDF @ Atacado";
            this.opçãoImportaçãoPDFAtacadoSaída.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImportaçãoPDFAtacadoSaída.Imagem")));
            this.opçãoImportaçãoPDFAtacadoSaída.Location = new System.Drawing.Point(7, 132);
            this.opçãoImportaçãoPDFAtacadoSaída.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportaçãoPDFAtacadoSaída.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportaçãoPDFAtacadoSaída.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoPDFAtacadoSaída.Name = "opçãoImportaçãoPDFAtacadoSaída";
            this.opçãoImportaçãoPDFAtacadoSaída.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoPDFAtacadoSaída.TabIndex = 4;
            this.opçãoImportaçãoPDFAtacadoSaída.Click += new System.EventHandler(this.opçãoImportaçãoPDFAtacado_Click);
            // 
            // opçãoImportaçãoXMLAtacadoSaída
            // 
            this.opçãoImportaçãoXMLAtacadoSaída.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportaçãoXMLAtacadoSaída.Descrição = "XML @ Atacado";
            this.opçãoImportaçãoXMLAtacadoSaída.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImportaçãoXMLAtacadoSaída.Imagem")));
            this.opçãoImportaçãoXMLAtacadoSaída.Location = new System.Drawing.Point(7, 92);
            this.opçãoImportaçãoXMLAtacadoSaída.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportaçãoXMLAtacadoSaída.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportaçãoXMLAtacadoSaída.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoXMLAtacadoSaída.Name = "opçãoImportaçãoXMLAtacadoSaída";
            this.opçãoImportaçãoXMLAtacadoSaída.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoXMLAtacadoSaída.TabIndex = 3;
            this.opçãoImportaçãoXMLAtacadoSaída.Click += new System.EventHandler(this.opçãoImportaçãoXMLAtacado_Click);
            // 
            // opçãoImportaçãoTDMVarejoSaída
            // 
            this.opçãoImportaçãoTDMVarejoSaída.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportaçãoTDMVarejoSaída.Descrição = "TDM @ Varejo";
            this.opçãoImportaçãoTDMVarejoSaída.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImportaçãoTDMVarejoSaída.Imagem")));
            this.opçãoImportaçãoTDMVarejoSaída.Location = new System.Drawing.Point(7, 152);
            this.opçãoImportaçãoTDMVarejoSaída.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportaçãoTDMVarejoSaída.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportaçãoTDMVarejoSaída.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoTDMVarejoSaída.Name = "opçãoImportaçãoTDMVarejoSaída";
            this.opçãoImportaçãoTDMVarejoSaída.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportaçãoTDMVarejoSaída.TabIndex = 2;
            this.opçãoImportaçãoTDMVarejoSaída.Click += new System.EventHandler(this.opçãoImportaçãoTDMVarejoSaída_Click);
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
            this.títuloBaseInferior1.Size = new System.Drawing.Size(592, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Fiscal";
            // 
            // opçãoCancelamentoXMLAtacadoSaída
            // 
            this.opçãoCancelamentoXMLAtacadoSaída.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCancelamentoXMLAtacadoSaída.Descrição = "XMLs de Cancelamento";
            this.opçãoCancelamentoXMLAtacadoSaída.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoCancelamentoXMLAtacadoSaída.Imagem")));
            this.opçãoCancelamentoXMLAtacadoSaída.Location = new System.Drawing.Point(6, 111);
            this.opçãoCancelamentoXMLAtacadoSaída.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCancelamentoXMLAtacadoSaída.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCancelamentoXMLAtacadoSaída.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCancelamentoXMLAtacadoSaída.Name = "opçãoCancelamentoXMLAtacadoSaída";
            this.opçãoCancelamentoXMLAtacadoSaída.Size = new System.Drawing.Size(150, 17);
            this.opçãoCancelamentoXMLAtacadoSaída.TabIndex = 8;
            this.opçãoCancelamentoXMLAtacadoSaída.Click += new System.EventHandler(this.opçãoCancelamentoXMLAtacadoSaída_Click);
            // 
            // BaseFiscal
            // 
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseFiscal";
            this.Size = new System.Drawing.Size(801, 303);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoImportaçãoTDMVarejoSaída;
        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Opção opçãoImportaçãoXMLAtacadoSaída;
        private Formulários.Opção opçãoImportaçãoPDFAtacadoSaída;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Formulários.Opção opçãoImportaçãoXMLAtacadoEntrada;
        private Formulários.Opção opçãoCancelamentoXMLAtacadoSaída;
    }
}
