using Apresentação.Fiscal.Combobox;

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
            this.cmbTipoDocumento = new Apresentação.Fiscal.Combobox.ComboTipoDocumento();
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
            this.quadroLista = new Apresentação.Formulários.Quadro();
            this.lstItens = new Apresentação.Fiscal.Lista.ListaItem();
            this.quadroItem = new Apresentação.Formulários.Quadro();
            this.currencyTextBox2 = new AMS.TextBox.CurrencyTextBox();
            this.currencyTextBox1 = new AMS.TextBox.CurrencyTextBox();
            this.comboTipoUnidade1 = new Apresentação.Fiscal.Combobox.ComboTipoUnidade();
            this.numericTextBox1 = new AMS.TextBox.NumericTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabObservações = new System.Windows.Forms.TabPage();
            this.txtObservações = new System.Windows.Forms.TextBox();
            this.esquerda.SuspendLayout();
            this.quadroDocumento.SuspendLayout();
            this.quadroPDF.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabDados.SuspendLayout();
            this.grpDados.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.quadroLista.SuspendLayout();
            this.quadroItem.SuspendLayout();
            this.tabObservações.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPDF);
            this.esquerda.Controls.Add(this.quadroDocumento);
            this.esquerda.Size = new System.Drawing.Size(187, 652);
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
            this.título.Size = new System.Drawing.Size(913, 70);
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
            this.tab.Size = new System.Drawing.Size(939, 555);
            this.tab.TabIndex = 7;
            // 
            // tabDados
            // 
            this.tabDados.Controls.Add(this.grpDados);
            this.tabDados.Location = new System.Drawing.Point(4, 22);
            this.tabDados.Name = "tabDados";
            this.tabDados.Padding = new System.Windows.Forms.Padding(3);
            this.tabDados.Size = new System.Drawing.Size(931, 529);
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
            this.grpDados.Size = new System.Drawing.Size(919, 517);
            this.grpDados.TabIndex = 0;
            this.grpDados.TabStop = false;
            this.grpDados.Text = "Dados do documento";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(643, 28);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Seleção = null;
            this.cmbTipoDocumento.Size = new System.Drawing.Size(125, 21);
            this.cmbTipoDocumento.TabIndex = 13;
            this.cmbTipoDocumento.Validated += new System.EventHandler(this.cmbTipoDocumento_Validated);
            // 
            // txtEmitente
            // 
            this.txtEmitente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmitente.Location = new System.Drawing.Point(195, 158);
            this.txtEmitente.Name = "txtEmitente";
            this.txtEmitente.Size = new System.Drawing.Size(326, 20);
            this.txtEmitente.TabIndex = 12;
            this.txtEmitente.Validated += new System.EventHandler(this.txtEmitente_Validated);
            // 
            // dtEntradaSaída
            // 
            this.dtEntradaSaída.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtEntradaSaída.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtEntradaSaída.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEntradaSaída.Location = new System.Drawing.Point(195, 81);
            this.dtEntradaSaída.Name = "dtEntradaSaída";
            this.dtEntradaSaída.Size = new System.Drawing.Size(323, 20);
            this.dtEntradaSaída.TabIndex = 11;
            // 
            // dtEmissão
            // 
            this.dtEmissão.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtEmissão.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtEmissão.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEmissão.Location = new System.Drawing.Point(195, 55);
            this.dtEmissão.Name = "dtEmissão";
            this.dtEmissão.Size = new System.Drawing.Size(323, 20);
            this.dtEmissão.TabIndex = 10;
            this.dtEmissão.Validated += new System.EventHandler(this.dtEmissão_Validated);
            // 
            // txtNúmero
            // 
            this.txtNúmero.AllowNegative = true;
            this.txtNúmero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNúmero.DigitsInGroup = 0;
            this.txtNúmero.Flags = 0;
            this.txtNúmero.Location = new System.Drawing.Point(195, 132);
            this.txtNúmero.MaxDecimalPlaces = 4;
            this.txtNúmero.MaxWholeDigits = 9;
            this.txtNúmero.Name = "txtNúmero";
            this.txtNúmero.Prefix = "";
            this.txtNúmero.RangeMax = 1.7976931348623157E+308D;
            this.txtNúmero.RangeMin = -1.7976931348623157E+308D;
            this.txtNúmero.Size = new System.Drawing.Size(323, 20);
            this.txtNúmero.TabIndex = 9;
            this.txtNúmero.Text = "1";
            this.txtNúmero.Validated += new System.EventHandler(this.txtNúmero_Validated);
            // 
            // txtValor
            // 
            this.txtValor.AllowNegative = true;
            this.txtValor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValor.Flags = 7680;
            this.txtValor.Location = new System.Drawing.Point(195, 106);
            this.txtValor.MaxWholeDigits = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.RangeMax = 1.7976931348623157E+308D;
            this.txtValor.RangeMin = -1.7976931348623157E+308D;
            this.txtValor.Size = new System.Drawing.Size(323, 20);
            this.txtValor.TabIndex = 8;
            this.txtValor.Text = "R$ 1,00";
            this.txtValor.Validated += new System.EventHandler(this.txtValor_Validated);
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtId.Location = new System.Drawing.Point(195, 29);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(323, 20);
            this.txtId.TabIndex = 7;
            this.txtId.Validating += new System.ComponentModel.CancelEventHandler(this.txtId_Validating);
            this.txtId.Validated += new System.EventHandler(this.txtId_Validated);
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(535, 32);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(102, 13);
            this.lblTipoDocumento.TabIndex = 6;
            this.lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Emitente:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Número:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valor:";
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEntradaSaída.AutoSize = true;
            this.lblEntradaSaída.Location = new System.Drawing.Point(141, 87);
            this.lblEntradaSaída.Name = "lblEntradaSaída";
            this.lblEntradaSaída.Size = new System.Drawing.Size(48, 13);
            this.lblEntradaSaída.TabIndex = 2;
            this.lblEntradaSaída.Text = "Ent/Saí:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emissão:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // tabItens
            // 
            this.tabItens.Controls.Add(this.quadroLista);
            this.tabItens.Controls.Add(this.quadroItem);
            this.tabItens.Location = new System.Drawing.Point(4, 22);
            this.tabItens.Name = "tabItens";
            this.tabItens.Padding = new System.Windows.Forms.Padding(3);
            this.tabItens.Size = new System.Drawing.Size(931, 529);
            this.tabItens.TabIndex = 1;
            this.tabItens.Text = "Itens";
            this.tabItens.UseVisualStyleBackColor = true;
            // 
            // quadroLista
            // 
            this.quadroLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroLista.bInfDirArredondada = false;
            this.quadroLista.bInfEsqArredondada = false;
            this.quadroLista.bSupDirArredondada = true;
            this.quadroLista.bSupEsqArredondada = true;
            this.quadroLista.Controls.Add(this.lstItens);
            this.quadroLista.Cor = System.Drawing.Color.Black;
            this.quadroLista.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroLista.LetraTítulo = System.Drawing.Color.White;
            this.quadroLista.Location = new System.Drawing.Point(6, 156);
            this.quadroLista.MostrarBotãoMinMax = false;
            this.quadroLista.Name = "quadroLista";
            this.quadroLista.Size = new System.Drawing.Size(919, 370);
            this.quadroLista.TabIndex = 2;
            this.quadroLista.Tamanho = 30;
            this.quadroLista.Título = "Mercadorias";
            // 
            // lstItens
            // 
            this.lstItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItens.Location = new System.Drawing.Point(0, 24);
            this.lstItens.Name = "lstItens";
            this.lstItens.Size = new System.Drawing.Size(919, 346);
            this.lstItens.TabIndex = 2;
            // 
            // quadroItem
            // 
            this.quadroItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroItem.bInfDirArredondada = true;
            this.quadroItem.bInfEsqArredondada = true;
            this.quadroItem.bSupDirArredondada = true;
            this.quadroItem.bSupEsqArredondada = true;
            this.quadroItem.Controls.Add(this.currencyTextBox2);
            this.quadroItem.Controls.Add(this.currencyTextBox1);
            this.quadroItem.Controls.Add(this.comboTipoUnidade1);
            this.quadroItem.Controls.Add(this.numericTextBox1);
            this.quadroItem.Controls.Add(this.textBox3);
            this.quadroItem.Controls.Add(this.label12);
            this.quadroItem.Controls.Add(this.label11);
            this.quadroItem.Controls.Add(this.label10);
            this.quadroItem.Controls.Add(this.label9);
            this.quadroItem.Controls.Add(this.btnExcluir);
            this.quadroItem.Controls.Add(this.btnAlterar);
            this.quadroItem.Controls.Add(this.textBox2);
            this.quadroItem.Controls.Add(this.textBox1);
            this.quadroItem.Controls.Add(this.label8);
            this.quadroItem.Controls.Add(this.label7);
            this.quadroItem.Controls.Add(this.label4);
            this.quadroItem.Cor = System.Drawing.Color.Black;
            this.quadroItem.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroItem.LetraTítulo = System.Drawing.Color.White;
            this.quadroItem.Location = new System.Drawing.Point(6, 11);
            this.quadroItem.MostrarBotãoMinMax = false;
            this.quadroItem.Name = "quadroItem";
            this.quadroItem.Size = new System.Drawing.Size(919, 139);
            this.quadroItem.TabIndex = 1;
            this.quadroItem.Tamanho = 30;
            this.quadroItem.Título = "Detalhe do item";
            // 
            // currencyTextBox2
            // 
            this.currencyTextBox2.AllowNegative = true;
            this.currencyTextBox2.Flags = 7680;
            this.currencyTextBox2.Location = new System.Drawing.Point(501, 102);
            this.currencyTextBox2.MaxWholeDigits = 9;
            this.currencyTextBox2.Name = "currencyTextBox2";
            this.currencyTextBox2.RangeMax = 1.7976931348623157E+308D;
            this.currencyTextBox2.RangeMin = -1.7976931348623157E+308D;
            this.currencyTextBox2.Size = new System.Drawing.Size(94, 20);
            this.currencyTextBox2.TabIndex = 17;
            this.currencyTextBox2.Text = "R$ 2,00";
            // 
            // currencyTextBox1
            // 
            this.currencyTextBox1.AllowNegative = true;
            this.currencyTextBox1.Flags = 7680;
            this.currencyTextBox1.Location = new System.Drawing.Point(396, 102);
            this.currencyTextBox1.MaxWholeDigits = 9;
            this.currencyTextBox1.Name = "currencyTextBox1";
            this.currencyTextBox1.RangeMax = 1.7976931348623157E+308D;
            this.currencyTextBox1.RangeMin = -1.7976931348623157E+308D;
            this.currencyTextBox1.Size = new System.Drawing.Size(96, 20);
            this.currencyTextBox1.TabIndex = 16;
            this.currencyTextBox1.Text = "R$ 1,00";
            // 
            // comboTipoUnidade1
            // 
            this.comboTipoUnidade1.FormattingEnabled = true;
            this.comboTipoUnidade1.Items.AddRange(new object[] {
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas",
            "Peça",
            "Gramas"});
            this.comboTipoUnidade1.Location = new System.Drawing.Point(284, 102);
            this.comboTipoUnidade1.Name = "comboTipoUnidade1";
            this.comboTipoUnidade1.Size = new System.Drawing.Size(100, 21);
            this.comboTipoUnidade1.TabIndex = 15;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.AllowNegative = true;
            this.numericTextBox1.DigitsInGroup = 0;
            this.numericTextBox1.Flags = 0;
            this.numericTextBox1.Location = new System.Drawing.Point(207, 102);
            this.numericTextBox1.MaxDecimalPlaces = 4;
            this.numericTextBox1.MaxWholeDigits = 9;
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Prefix = "";
            this.numericTextBox1.RangeMax = 1.7976931348623157E+308D;
            this.numericTextBox1.RangeMin = -1.7976931348623157E+308D;
            this.numericTextBox1.Size = new System.Drawing.Size(59, 20);
            this.numericTextBox1.TabIndex = 14;
            this.numericTextBox1.Text = "1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(19, 102);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 20);
            this.textBox3.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(498, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Valor Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(393, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Valor Unitário";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(281, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Tipo de Unidade";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Quantidade";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(747, 99);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterar.Location = new System.Drawing.Point(828, 99);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 7;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(207, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(700, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Descrição";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "CFOP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Referência";
            // 
            // tabObservações
            // 
            this.tabObservações.Controls.Add(this.txtObservações);
            this.tabObservações.Location = new System.Drawing.Point(4, 22);
            this.tabObservações.Name = "tabObservações";
            this.tabObservações.Padding = new System.Windows.Forms.Padding(3);
            this.tabObservações.Size = new System.Drawing.Size(931, 529);
            this.tabObservações.TabIndex = 2;
            this.tabObservações.Text = "Observações";
            this.tabObservações.UseVisualStyleBackColor = true;
            // 
            // txtObservações
            // 
            this.txtObservações.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservações.Location = new System.Drawing.Point(3, 3);
            this.txtObservações.Multiline = true;
            this.txtObservações.Name = "txtObservações";
            this.txtObservações.Size = new System.Drawing.Size(925, 523);
            this.txtObservações.TabIndex = 0;
            this.txtObservações.Validated += new System.EventHandler(this.txtObservações_Validated);
            // 
            // BaseDocumento
            // 
            this.Controls.Add(this.tab);
            this.Controls.Add(this.título);
            this.MinimumSize = new System.Drawing.Size(989, 373);
            this.Name = "BaseDocumento";
            this.Size = new System.Drawing.Size(1135, 652);
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
            this.tabItens.ResumeLayout(false);
            this.quadroLista.ResumeLayout(false);
            this.quadroItem.ResumeLayout(false);
            this.quadroItem.PerformLayout();
            this.tabObservações.ResumeLayout(false);
            this.tabObservações.PerformLayout();
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
        private Pessoa.TextBoxCNPJ txtEmitente;
        protected System.Windows.Forms.DateTimePicker dtEntradaSaída;
        private System.Windows.Forms.DateTimePicker dtEmissão;
        protected System.Windows.Forms.Label lblEntradaSaída;
        protected System.Windows.Forms.Label lblTipoDocumento;
        protected ComboTipoDocumento cmbTipoDocumento;
        private Formulários.Quadro quadroLista;
        private Formulários.Quadro quadroItem;
        private Lista.ListaItem lstItens;
        private AMS.TextBox.NumericTextBox numericTextBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private AMS.TextBox.CurrencyTextBox currencyTextBox2;
        private AMS.TextBox.CurrencyTextBox currencyTextBox1;
        private ComboTipoUnidade comboTipoUnidade1;
        protected System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtObservações;
    }
}
