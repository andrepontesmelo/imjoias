namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDocumento));
            this.quadroDocumento = new Apresentação.Formulários.Quadro();
            this.opçãoExcluirDocumento = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadroPDF = new Apresentação.Formulários.Quadro();
            this.opçãoExcluirPDF = new Apresentação.Formulários.Opção();
            this.opçãoCarregar = new Apresentação.Formulários.Opção();
            this.opçãoAbrir = new Apresentação.Formulários.Opção();
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabDados = new System.Windows.Forms.TabPage();
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.cmbTipoDocumento = new Apresentação.Fiscal.ComboTipoDocumento();
            this.txtEmitente = new Apresentação.Pessoa.TextBoxCNPJ();
            this.dtEntradaSaída = new System.Windows.Forms.DateTimePicker();
            this.dtEmissão = new System.Windows.Forms.DateTimePicker();
            this.txtNúmero = new AMS.TextBox.NumericTextBox();
            this.txtValor = new AMS.TextBox.CurrencyTextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEntradaSaída = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabItens = new System.Windows.Forms.TabPage();
            this.tabObservações = new System.Windows.Forms.TabPage();
            this.esquerda.SuspendLayout();
            this.quadroDocumento.SuspendLayout();
            this.quadroPDF.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabDados.SuspendLayout();
            this.grpDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPDF);
            this.esquerda.Controls.Add(this.quadroDocumento);
            this.esquerda.Size = new System.Drawing.Size(187, 682);
            this.esquerda.Controls.SetChildIndex(this.quadroDocumento, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroPDF, 0);
            // 
            // quadroDocumento
            // 
            this.quadroDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroDocumento.bInfDirArredondada = true;
            this.quadroDocumento.bInfEsqArredondada = true;
            this.quadroDocumento.bSupDirArredondada = true;
            this.quadroDocumento.bSupEsqArredondada = true;
            this.quadroDocumento.Controls.Add(this.opçãoExcluirDocumento);
            this.quadroDocumento.Controls.Add(this.opçãoImprimir);
            this.quadroDocumento.Cor = System.Drawing.Color.Black;
            this.quadroDocumento.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDocumento.LetraTítulo = System.Drawing.Color.White;
            this.quadroDocumento.Location = new System.Drawing.Point(7, 13);
            this.quadroDocumento.MostrarBotãoMinMax = false;
            this.quadroDocumento.Name = "quadroDocumento";
            this.quadroDocumento.Size = new System.Drawing.Size(160, 80);
            this.quadroDocumento.TabIndex = 1;
            this.quadroDocumento.Tamanho = 30;
            this.quadroDocumento.Título = "Documento";
            // 
            // opçãoExcluirDocumento
            // 
            this.opçãoExcluirDocumento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirDocumento.Descrição = "Excluir";
            this.opçãoExcluirDocumento.Imagem = global::Apresentação.Resource.none;
            this.opçãoExcluirDocumento.Location = new System.Drawing.Point(7, 50);
            this.opçãoExcluirDocumento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluirDocumento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirDocumento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirDocumento.Name = "opçãoExcluirDocumento";
            this.opçãoExcluirDocumento.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluirDocumento.TabIndex = 3;
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora___163;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 30);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.TabIndex = 2;
            // 
            // quadroPDF
            // 
            this.quadroPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPDF.bInfDirArredondada = true;
            this.quadroPDF.bInfEsqArredondada = true;
            this.quadroPDF.bSupDirArredondada = true;
            this.quadroPDF.bSupEsqArredondada = true;
            this.quadroPDF.Controls.Add(this.opçãoExcluirPDF);
            this.quadroPDF.Controls.Add(this.opçãoCarregar);
            this.quadroPDF.Controls.Add(this.opçãoAbrir);
            this.quadroPDF.Cor = System.Drawing.Color.Black;
            this.quadroPDF.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPDF.LetraTítulo = System.Drawing.Color.White;
            this.quadroPDF.Location = new System.Drawing.Point(7, 99);
            this.quadroPDF.MostrarBotãoMinMax = false;
            this.quadroPDF.Name = "quadroPDF";
            this.quadroPDF.Size = new System.Drawing.Size(160, 94);
            this.quadroPDF.TabIndex = 2;
            this.quadroPDF.Tamanho = 30;
            this.quadroPDF.Título = "PDF";
            // 
            // opçãoExcluirPDF
            // 
            this.opçãoExcluirPDF.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirPDF.Descrição = "Excluir";
            this.opçãoExcluirPDF.Imagem = global::Apresentação.Resource.none;
            this.opçãoExcluirPDF.Location = new System.Drawing.Point(7, 70);
            this.opçãoExcluirPDF.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluirPDF.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirPDF.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirPDF.Name = "opçãoExcluirPDF";
            this.opçãoExcluirPDF.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluirPDF.TabIndex = 6;
            // 
            // opçãoCarregar
            // 
            this.opçãoCarregar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCarregar.Descrição = "Carregar";
            this.opçãoCarregar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoCarregar.Imagem")));
            this.opçãoCarregar.Location = new System.Drawing.Point(7, 50);
            this.opçãoCarregar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCarregar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCarregar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCarregar.Name = "opçãoCarregar";
            this.opçãoCarregar.Size = new System.Drawing.Size(150, 16);
            this.opçãoCarregar.TabIndex = 5;
            // 
            // opçãoAbrir
            // 
            this.opçãoAbrir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrir.Descrição = "Abrir";
            this.opçãoAbrir.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAbrir.Imagem")));
            this.opçãoAbrir.Location = new System.Drawing.Point(7, 30);
            this.opçãoAbrir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAbrir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.Name = "opçãoAbrir";
            this.opçãoAbrir.Size = new System.Drawing.Size(150, 18);
            this.opçãoAbrir.TabIndex = 4;
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Descrição";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.fiscal1;
            this.título.Location = new System.Drawing.Point(197, 13);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(986, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Editar documento fiscal";
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabDados);
            this.tab.Controls.Add(this.tabItens);
            this.tab.Controls.Add(this.tabObservações);
            this.tab.Location = new System.Drawing.Point(193, 85);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(994, 585);
            this.tab.TabIndex = 7;
            // 
            // tabDados
            // 
            this.tabDados.Controls.Add(this.grpDados);
            this.tabDados.Location = new System.Drawing.Point(4, 22);
            this.tabDados.Name = "tabDados";
            this.tabDados.Padding = new System.Windows.Forms.Padding(3);
            this.tabDados.Size = new System.Drawing.Size(986, 559);
            this.tabDados.TabIndex = 0;
            this.tabDados.Text = "Dados";
            this.tabDados.UseVisualStyleBackColor = true;
            // 
            // grpDados
            // 
            this.grpDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDados.Controls.Add(this.cmbTipoDocumento);
            this.grpDados.Controls.Add(this.txtEmitente);
            this.grpDados.Controls.Add(this.dtEntradaSaída);
            this.grpDados.Controls.Add(this.dtEmissão);
            this.grpDados.Controls.Add(this.txtNúmero);
            this.grpDados.Controls.Add(this.txtValor);
            this.grpDados.Controls.Add(this.txtId);
            this.grpDados.Controls.Add(this.lblTipoDocumento);
            this.grpDados.Controls.Add(this.label5);
            this.grpDados.Controls.Add(this.label6);
            this.grpDados.Controls.Add(this.label3);
            this.grpDados.Controls.Add(this.lblEntradaSaída);
            this.grpDados.Controls.Add(this.label2);
            this.grpDados.Controls.Add(this.label1);
            this.grpDados.Location = new System.Drawing.Point(6, 6);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(974, 547);
            this.grpDados.TabIndex = 0;
            this.grpDados.TabStop = false;
            this.grpDados.Text = "Dados do documento";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(678, 74);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(125, 21);
            this.cmbTipoDocumento.TabIndex = 13;
            // 
            // txtEmitente
            // 
            this.txtEmitente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmitente.Location = new System.Drawing.Point(241, 204);
            this.txtEmitente.Name = "txtEmitente";
            this.txtEmitente.Size = new System.Drawing.Size(293, 20);
            this.txtEmitente.TabIndex = 12;
            // 
            // dtEntradaSaída
            // 
            this.dtEntradaSaída.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtEntradaSaída.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtEntradaSaída.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEntradaSaída.Location = new System.Drawing.Point(241, 127);
            this.dtEntradaSaída.Name = "dtEntradaSaída";
            this.dtEntradaSaída.Size = new System.Drawing.Size(290, 20);
            this.dtEntradaSaída.TabIndex = 11;
            // 
            // dtEmissão
            // 
            this.dtEmissão.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtEmissão.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtEmissão.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEmissão.Location = new System.Drawing.Point(241, 101);
            this.dtEmissão.Name = "dtEmissão";
            this.dtEmissão.Size = new System.Drawing.Size(290, 20);
            this.dtEmissão.TabIndex = 10;
            // 
            // txtNúmero
            // 
            this.txtNúmero.AllowNegative = true;
            this.txtNúmero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNúmero.DigitsInGroup = 0;
            this.txtNúmero.Flags = 0;
            this.txtNúmero.Location = new System.Drawing.Point(241, 178);
            this.txtNúmero.MaxDecimalPlaces = 4;
            this.txtNúmero.MaxWholeDigits = 9;
            this.txtNúmero.Name = "txtNúmero";
            this.txtNúmero.Prefix = "";
            this.txtNúmero.RangeMax = 1.7976931348623157E+308D;
            this.txtNúmero.RangeMin = -1.7976931348623157E+308D;
            this.txtNúmero.Size = new System.Drawing.Size(290, 20);
            this.txtNúmero.TabIndex = 9;
            this.txtNúmero.Text = "1";
            // 
            // txtValor
            // 
            this.txtValor.AllowNegative = true;
            this.txtValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValor.Flags = 7680;
            this.txtValor.Location = new System.Drawing.Point(241, 152);
            this.txtValor.MaxWholeDigits = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.RangeMax = 1.7976931348623157E+308D;
            this.txtValor.RangeMin = -1.7976931348623157E+308D;
            this.txtValor.Size = new System.Drawing.Size(290, 20);
            this.txtValor.TabIndex = 8;
            this.txtValor.Text = "R$ 1,00";
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtId.Location = new System.Drawing.Point(241, 75);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(290, 20);
            this.txtId.TabIndex = 7;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(570, 78);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(102, 13);
            this.lblTipoDocumento.TabIndex = 6;
            this.lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Emitente:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Número:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valor:";
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEntradaSaída.AutoSize = true;
            this.lblEntradaSaída.Location = new System.Drawing.Point(187, 133);
            this.lblEntradaSaída.Name = "lblEntradaSaída";
            this.lblEntradaSaída.Size = new System.Drawing.Size(48, 13);
            this.lblEntradaSaída.TabIndex = 2;
            this.lblEntradaSaída.Text = "Ent/Saí:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emissão:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // tabItens
            // 
            this.tabItens.Location = new System.Drawing.Point(4, 22);
            this.tabItens.Name = "tabItens";
            this.tabItens.Padding = new System.Windows.Forms.Padding(3);
            this.tabItens.Size = new System.Drawing.Size(986, 559);
            this.tabItens.TabIndex = 1;
            this.tabItens.Text = "Itens";
            this.tabItens.UseVisualStyleBackColor = true;
            // 
            // tabObservações
            // 
            this.tabObservações.Location = new System.Drawing.Point(4, 22);
            this.tabObservações.Name = "tabObservações";
            this.tabObservações.Padding = new System.Windows.Forms.Padding(3);
            this.tabObservações.Size = new System.Drawing.Size(986, 559);
            this.tabObservações.TabIndex = 2;
            this.tabObservações.Text = "Observações";
            this.tabObservações.UseVisualStyleBackColor = true;
            // 
            // BaseDocumento
            // 
            this.Controls.Add(this.tab);
            this.Controls.Add(this.título);
            this.Name = "BaseDocumento";
            this.Size = new System.Drawing.Size(1208, 682);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroDocumento.ResumeLayout(false);
            this.quadroPDF.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabDados.ResumeLayout(false);
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadroDocumento;
        private Formulários.Quadro quadroPDF;
        private Formulários.Opção opçãoImprimir;
        private Formulários.Opção opçãoExcluirPDF;
        private Formulários.Opção opçãoCarregar;
        private Formulários.Opção opçãoAbrir;
        private Formulários.Opção opçãoExcluirDocumento;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabDados;
        private System.Windows.Forms.TabPage tabItens;
        private System.Windows.Forms.TabPage tabObservações;
        protected Formulários.TítuloBaseInferior título;
        protected System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private AMS.TextBox.NumericTextBox txtNúmero;
        private AMS.TextBox.CurrencyTextBox txtValor;
        private System.Windows.Forms.TextBox txtId;
        private Pessoa.TextBoxCNPJ txtEmitente;
        private System.Windows.Forms.DateTimePicker dtEntradaSaída;
        private System.Windows.Forms.DateTimePicker dtEmissão;
        protected System.Windows.Forms.Label lblEntradaSaída;
        protected System.Windows.Forms.Label lblTipoDocumento;
        protected ComboTipoDocumento cmbTipoDocumento;
    }
}
