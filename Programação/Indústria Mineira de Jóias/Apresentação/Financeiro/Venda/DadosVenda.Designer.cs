namespace Apresentação.Financeiro.Venda
{
    partial class DadosVenda
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtControle = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtPercentualDesconto = new System.Windows.Forms.TextBox();
            this.btnTrocarClienteVendedor = new System.Windows.Forms.Panel();
            this.chkSedex = new System.Windows.Forms.CheckBox();
            this.txtTaxaJuros = new System.Windows.Forms.TextBox();
            this.txtPrestações = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotal = new AMS.TextBox.CurrencyTextBox();
            this.lblValorPagar = new System.Windows.Forms.Label();
            this.txtValorPago = new AMS.TextBox.CurrencyTextBox();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.txtSaldoDataVenda = new AMS.TextBox.CurrencyTextBox();
            this.lblSaldoNaDataVenda = new System.Windows.Forms.Label();
            this.lblPrestações = new System.Windows.Forms.Label();
            this.bgAtualizarPreços = new System.ComponentModel.BackgroundWorker();
            this.chkVendaQuitada = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAcerto = new System.Windows.Forms.TextBox();
            this.btnAcerto = new System.Windows.Forms.Button();
            this.txtDiasSemJuros = new AMS.TextBox.IntegerTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblValorPagoLíquido = new System.Windows.Forms.Label();
            this.txtValorPagoLíquido = new AMS.TextBox.CurrencyTextBox();
            this.lblInfoDívida = new System.Windows.Forms.Label();
            this.lblItens = new System.Windows.Forms.Label();
            this.txtValorItens = new AMS.TextBox.CurrencyTextBox();
            this.lblDébitos = new System.Windows.Forms.Label();
            this.txtSubtotal = new AMS.TextBox.CurrencyTextBox();
            this.lblValorVenda = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.txtDesconto = new AMS.TextBox.CurrencyTextBox();
            this.lblJuros = new System.Windows.Forms.Label();
            this.txtJuros = new AMS.TextBox.CurrencyTextBox();
            this.txtValorDébitos = new AMS.TextBox.CurrencyTextBox();
            this.txtSaldoHoje = new AMS.TextBox.CurrencyTextBox();
            this.lblSaldoHoje = new System.Windows.Forms.Label();
            this.txtValorCréditos = new AMS.TextBox.CurrencyTextBox();
            this.lblCréditos = new System.Windows.Forms.Label();
            this.lblDevolução = new System.Windows.Forms.Label();
            this.txtDevolução = new System.Windows.Forms.TextBox();
            this.chkRastreada = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmbTabela = new Apresentação.Financeiro.ComboTabela();
            this.txtCotação = new Apresentação.Mercadoria.Cotação.TxtCotação();
            this.txtVendedor = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.txtCliente = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.txtData = new Apresentação.Mercadoria.Cotação.TxtDataCotação();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendedor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cotação:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(245, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Controle:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtControle
            // 
            this.txtControle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtControle.Location = new System.Drawing.Point(323, 90);
            this.txtControle.Name = "txtControle";
            this.txtControle.Size = new System.Drawing.Size(169, 20);
            this.txtControle.TabIndex = 10;
            this.toolTip.SetToolTip(this.txtControle, "O número de controle que consta na folha de venda ou da nota-fiscal.");
            this.txtControle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtControle_KeyPress);
            this.txtControle.Validating += new System.ComponentModel.CancelEventHandler(this.txtControle_Validating);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Descrição do campo";
            // 
            // txtPercentualDesconto
            // 
            this.txtPercentualDesconto.Location = new System.Drawing.Point(86, 170);
            this.txtPercentualDesconto.Name = "txtPercentualDesconto";
            this.txtPercentualDesconto.Size = new System.Drawing.Size(150, 20);
            this.txtPercentualDesconto.TabIndex = 18;
            this.txtPercentualDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.txtPercentualDesconto, "O número de controle que consta na folha de venda ou da nota-fiscal.");
            this.txtPercentualDesconto.Validated += new System.EventHandler(this.txtPercentualDesconto_Validated);
            // 
            // btnTrocarClienteVendedor
            // 
            this.btnTrocarClienteVendedor.BackgroundImage = global::Apresentação.Resource.arrow_switch;
            this.btnTrocarClienteVendedor.Location = new System.Drawing.Point(-1, 25);
            this.btnTrocarClienteVendedor.Name = "btnTrocarClienteVendedor";
            this.btnTrocarClienteVendedor.Size = new System.Drawing.Size(27, 25);
            this.btnTrocarClienteVendedor.TabIndex = 82;
            this.toolTip.SetToolTip(this.btnTrocarClienteVendedor, "Troca o cliente com o vendedor");
            this.btnTrocarClienteVendedor.Click += new System.EventHandler(this.btnTrocarClienteVendedor_Click);
            // 
            // chkSedex
            // 
            this.chkSedex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSedex.AutoSize = true;
            this.chkSedex.Location = new System.Drawing.Point(3, 492);
            this.chkSedex.Name = "chkSedex";
            this.chkSedex.Size = new System.Drawing.Size(56, 17);
            this.chkSedex.TabIndex = 83;
            this.chkSedex.Text = "Sedex";
            this.toolTip.SetToolTip(this.chkSedex, "Tem efeito sobre o balanço. Vendas de sedex são somadas ao invés de subtraídas.");
            this.chkSedex.UseVisualStyleBackColor = true;
            this.chkSedex.CheckedChanged += new System.EventHandler(this.chkSedex_CheckedChanged);
            // 
            // txtTaxaJuros
            // 
            this.txtTaxaJuros.BackColor = System.Drawing.Color.White;
            this.txtTaxaJuros.Location = new System.Drawing.Point(86, 197);
            this.txtTaxaJuros.Name = "txtTaxaJuros";
            this.txtTaxaJuros.Size = new System.Drawing.Size(150, 20);
            this.txtTaxaJuros.TabIndex = 21;
            this.txtTaxaJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTaxaJuros.Validated += new System.EventHandler(this.txtTaxaJuros_Validated);
            // 
            // txtPrestações
            // 
            this.txtPrestações.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtPrestações.Location = new System.Drawing.Point(86, 222);
            this.txtPrestações.Name = "txtPrestações";
            this.txtPrestações.ReadOnly = true;
            this.txtPrestações.Size = new System.Drawing.Size(150, 20);
            this.txtPrestações.TabIndex = 24;
            this.txtPrestações.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tabela:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 35);
            this.label10.TabIndex = 14;
            this.label10.Text = "Percentual de desconto:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Taxa de juros:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotal
            // 
            this.txtTotal.AllowNegative = true;
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtTotal.Flags = 7680;
            this.txtTotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(323, 301);
            this.txtTotal.MaxWholeDigits = 9;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RangeMax = 1.7976931348623157E+308D;
            this.txtTotal.RangeMin = -1.7976931348623157E+308D;
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(169, 20);
            this.txtTotal.TabIndex = 26;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorPagar
            // 
            this.lblValorPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPagar.ForeColor = System.Drawing.Color.Black;
            this.lblValorPagar.Location = new System.Drawing.Point(211, 301);
            this.lblValorPagar.Name = "lblValorPagar";
            this.lblValorPagar.Size = new System.Drawing.Size(106, 18);
            this.lblValorPagar.TabIndex = 25;
            this.lblValorPagar.Text = "(=) SubTotal:";
            this.lblValorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValorPago
            // 
            this.txtValorPago.AllowNegative = true;
            this.txtValorPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtValorPago.Flags = 7680;
            this.txtValorPago.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPago.Location = new System.Drawing.Point(323, 336);
            this.txtValorPago.MaxWholeDigits = 9;
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.RangeMax = 1.7976931348623157E+308D;
            this.txtValorPago.RangeMin = -1.7976931348623157E+308D;
            this.txtValorPago.ReadOnly = true;
            this.txtValorPago.Size = new System.Drawing.Size(169, 20);
            this.txtValorPago.TabIndex = 28;
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorPago
            // 
            this.lblValorPago.AutoSize = true;
            this.lblValorPago.Location = new System.Drawing.Point(254, 343);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(63, 13);
            this.lblValorPago.TabIndex = 27;
            this.lblValorPago.Text = "Pago Bruto:";
            // 
            // txtSaldoDataVenda
            // 
            this.txtSaldoDataVenda.AllowNegative = true;
            this.txtSaldoDataVenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoDataVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtSaldoDataVenda.Flags = 7680;
            this.txtSaldoDataVenda.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoDataVenda.ForeColor = System.Drawing.Color.Black;
            this.txtSaldoDataVenda.Location = new System.Drawing.Point(323, 414);
            this.txtSaldoDataVenda.MaxWholeDigits = 9;
            this.txtSaldoDataVenda.Name = "txtSaldoDataVenda";
            this.txtSaldoDataVenda.RangeMax = 1.7976931348623157E+308D;
            this.txtSaldoDataVenda.RangeMin = -1.7976931348623157E+308D;
            this.txtSaldoDataVenda.ReadOnly = true;
            this.txtSaldoDataVenda.Size = new System.Drawing.Size(169, 20);
            this.txtSaldoDataVenda.TabIndex = 30;
            this.txtSaldoDataVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldoNaDataVenda
            // 
            this.lblSaldoNaDataVenda.AutoSize = true;
            this.lblSaldoNaDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoNaDataVenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSaldoNaDataVenda.Location = new System.Drawing.Point(168, 421);
            this.lblSaldoNaDataVenda.Name = "lblSaldoNaDataVenda";
            this.lblSaldoNaDataVenda.Size = new System.Drawing.Size(147, 13);
            this.lblSaldoNaDataVenda.TabIndex = 29;
            this.lblSaldoNaDataVenda.Text = "Saldo na data da venda:";
            // 
            // lblPrestações
            // 
            this.lblPrestações.Location = new System.Drawing.Point(5, 224);
            this.lblPrestações.Name = "lblPrestações";
            this.lblPrestações.Size = new System.Drawing.Size(75, 20);
            this.lblPrestações.TabIndex = 56;
            this.lblPrestações.Text = "Prestações";
            this.lblPrestações.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkVendaQuitada
            // 
            this.chkVendaQuitada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVendaQuitada.AutoSize = true;
            this.chkVendaQuitada.Location = new System.Drawing.Point(3, 459);
            this.chkVendaQuitada.Name = "chkVendaQuitada";
            this.chkVendaQuitada.Size = new System.Drawing.Size(95, 17);
            this.chkVendaQuitada.TabIndex = 31;
            this.chkVendaQuitada.Text = "Venda quitada";
            this.chkVendaQuitada.UseVisualStyleBackColor = true;
            this.chkVendaQuitada.CheckedChanged += new System.EventHandler(this.chkVendaQuitada_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Acerto:";
            // 
            // txtAcerto
            // 
            this.txtAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcerto.Location = new System.Drawing.Point(86, 64);
            this.txtAcerto.Name = "txtAcerto";
            this.txtAcerto.ReadOnly = true;
            this.txtAcerto.Size = new System.Drawing.Size(387, 20);
            this.txtAcerto.TabIndex = 5;
            // 
            // btnAcerto
            // 
            this.btnAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcerto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAcerto.Image = global::Apresentação.Resource.Acerto__Pequeno_;
            this.btnAcerto.Location = new System.Drawing.Point(472, 64);
            this.btnAcerto.Name = "btnAcerto";
            this.btnAcerto.Size = new System.Drawing.Size(20, 20);
            this.btnAcerto.TabIndex = 6;
            this.btnAcerto.UseVisualStyleBackColor = true;
            this.btnAcerto.Click += new System.EventHandler(this.btnAcerto_Click);
            // 
            // txtDiasSemJuros
            // 
            this.txtDiasSemJuros.AllowNegative = true;
            this.txtDiasSemJuros.DigitsInGroup = 0;
            this.txtDiasSemJuros.Flags = 0;
            this.txtDiasSemJuros.Location = new System.Drawing.Point(86, 144);
            this.txtDiasSemJuros.MaxDecimalPlaces = 0;
            this.txtDiasSemJuros.MaxWholeDigits = 9;
            this.txtDiasSemJuros.Name = "txtDiasSemJuros";
            this.txtDiasSemJuros.Prefix = "";
            this.txtDiasSemJuros.RangeMax = 1.7976931348623157E+308D;
            this.txtDiasSemJuros.RangeMin = 0D;
            this.txtDiasSemJuros.Size = new System.Drawing.Size(150, 20);
            this.txtDiasSemJuros.TabIndex = 57;
            this.txtDiasSemJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiasSemJuros.Validated += new System.EventHandler(this.txtDiasSemJuros_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "Dias sem juros:";
            // 
            // lblValorPagoLíquido
            // 
            this.lblValorPagoLíquido.AutoSize = true;
            this.lblValorPagoLíquido.Location = new System.Drawing.Point(243, 369);
            this.lblValorPagoLíquido.Name = "lblValorPagoLíquido";
            this.lblValorPagoLíquido.Size = new System.Drawing.Size(74, 13);
            this.lblValorPagoLíquido.TabIndex = 61;
            this.lblValorPagoLíquido.Text = "Pago Líquido:";
            // 
            // txtValorPagoLíquido
            // 
            this.txtValorPagoLíquido.AllowNegative = true;
            this.txtValorPagoLíquido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorPagoLíquido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtValorPagoLíquido.Flags = 7680;
            this.txtValorPagoLíquido.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPagoLíquido.Location = new System.Drawing.Point(323, 362);
            this.txtValorPagoLíquido.MaxWholeDigits = 9;
            this.txtValorPagoLíquido.Name = "txtValorPagoLíquido";
            this.txtValorPagoLíquido.RangeMax = 1.7976931348623157E+308D;
            this.txtValorPagoLíquido.RangeMin = -1.7976931348623157E+308D;
            this.txtValorPagoLíquido.ReadOnly = true;
            this.txtValorPagoLíquido.Size = new System.Drawing.Size(169, 20);
            this.txtValorPagoLíquido.TabIndex = 62;
            this.txtValorPagoLíquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInfoDívida
            // 
            this.lblInfoDívida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoDívida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInfoDívida.Location = new System.Drawing.Point(320, 467);
            this.lblInfoDívida.Name = "lblInfoDívida";
            this.lblInfoDívida.Size = new System.Drawing.Size(172, 62);
            this.lblInfoDívida.TabIndex = 63;
            this.lblInfoDívida.Text = "O subtotal é trazido para a data de hoje e é abatido o valor pago líquido.";
            // 
            // lblItens
            // 
            this.lblItens.AutoSize = true;
            this.lblItens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItens.Location = new System.Drawing.Point(269, 151);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(48, 13);
            this.lblItens.TabIndex = 64;
            this.lblItens.Text = "(+) Itens:";
            this.lblItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValorItens
            // 
            this.txtValorItens.AllowNegative = true;
            this.txtValorItens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorItens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtValorItens.Flags = 7680;
            this.txtValorItens.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorItens.ForeColor = System.Drawing.Color.Black;
            this.txtValorItens.Location = new System.Drawing.Point(323, 142);
            this.txtValorItens.MaxWholeDigits = 9;
            this.txtValorItens.Name = "txtValorItens";
            this.txtValorItens.RangeMax = 1.7976931348623157E+308D;
            this.txtValorItens.RangeMin = -1.7976931348623157E+308D;
            this.txtValorItens.ReadOnly = true;
            this.txtValorItens.Size = new System.Drawing.Size(169, 20);
            this.txtValorItens.TabIndex = 65;
            this.txtValorItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDébitos
            // 
            this.lblDébitos.AutoSize = true;
            this.lblDébitos.Location = new System.Drawing.Point(256, 254);
            this.lblDébitos.Name = "lblDébitos";
            this.lblDébitos.Size = new System.Drawing.Size(61, 13);
            this.lblDébitos.TabIndex = 66;
            this.lblDébitos.Text = "(+) Débitos:";
            this.lblDébitos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.AllowNegative = true;
            this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtSubtotal.Flags = 7680;
            this.txtSubtotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.ForeColor = System.Drawing.Color.Black;
            this.txtSubtotal.Location = new System.Drawing.Point(323, 222);
            this.txtSubtotal.MaxWholeDigits = 9;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.RangeMax = 1.7976931348623157E+308D;
            this.txtSubtotal.RangeMin = -1.7976931348623157E+308D;
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(169, 20);
            this.txtSubtotal.TabIndex = 69;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorVenda
            // 
            this.lblValorVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorVenda.ForeColor = System.Drawing.Color.Black;
            this.lblValorVenda.Location = new System.Drawing.Point(236, 218);
            this.lblValorVenda.Name = "lblValorVenda";
            this.lblValorVenda.Size = new System.Drawing.Size(81, 26);
            this.lblValorVenda.TabIndex = 68;
            this.lblValorVenda.Text = "(=) SubTotal:";
            this.lblValorVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(249, 197);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(68, 13);
            this.lblDesconto.TabIndex = 70;
            this.lblDesconto.Text = "(-) Desconto:";
            this.lblDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDesconto
            // 
            this.txtDesconto.AllowNegative = true;
            this.txtDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesconto.Flags = 7680;
            this.txtDesconto.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Location = new System.Drawing.Point(323, 195);
            this.txtDesconto.MaxWholeDigits = 9;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.RangeMax = 1.7976931348623157E+308D;
            this.txtDesconto.RangeMin = -1.7976931348623157E+308D;
            this.txtDesconto.Size = new System.Drawing.Size(169, 20);
            this.txtDesconto.TabIndex = 71;
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.Validated += new System.EventHandler(this.txtDesconto_Validated);
            // 
            // lblJuros
            // 
            this.lblJuros.AutoSize = true;
            this.lblJuros.Location = new System.Drawing.Point(233, 395);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(84, 13);
            this.lblJuros.TabIndex = 72;
            this.lblJuros.Text = "Difereça (Juros):";
            // 
            // txtJuros
            // 
            this.txtJuros.AllowNegative = true;
            this.txtJuros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJuros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtJuros.Flags = 7680;
            this.txtJuros.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJuros.Location = new System.Drawing.Point(323, 388);
            this.txtJuros.MaxWholeDigits = 9;
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.RangeMax = 1.7976931348623157E+308D;
            this.txtJuros.RangeMin = -1.7976931348623157E+308D;
            this.txtJuros.ReadOnly = true;
            this.txtJuros.Size = new System.Drawing.Size(169, 20);
            this.txtJuros.TabIndex = 73;
            this.txtJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorDébitos
            // 
            this.txtValorDébitos.AllowNegative = true;
            this.txtValorDébitos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorDébitos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtValorDébitos.Flags = 7680;
            this.txtValorDébitos.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDébitos.ForeColor = System.Drawing.Color.Black;
            this.txtValorDébitos.Location = new System.Drawing.Point(323, 248);
            this.txtValorDébitos.MaxWholeDigits = 9;
            this.txtValorDébitos.Name = "txtValorDébitos";
            this.txtValorDébitos.RangeMax = 1.7976931348623157E+308D;
            this.txtValorDébitos.RangeMin = -1.7976931348623157E+308D;
            this.txtValorDébitos.ReadOnly = true;
            this.txtValorDébitos.Size = new System.Drawing.Size(169, 20);
            this.txtValorDébitos.TabIndex = 74;
            this.txtValorDébitos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoHoje
            // 
            this.txtSaldoHoje.AllowNegative = true;
            this.txtSaldoHoje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoHoje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtSaldoHoje.Flags = 7680;
            this.txtSaldoHoje.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoHoje.ForeColor = System.Drawing.Color.Black;
            this.txtSaldoHoje.Location = new System.Drawing.Point(323, 440);
            this.txtSaldoHoje.MaxWholeDigits = 9;
            this.txtSaldoHoje.Name = "txtSaldoHoje";
            this.txtSaldoHoje.RangeMax = 1.7976931348623157E+308D;
            this.txtSaldoHoje.RangeMin = -1.7976931348623157E+308D;
            this.txtSaldoHoje.ReadOnly = true;
            this.txtSaldoHoje.Size = new System.Drawing.Size(169, 20);
            this.txtSaldoHoje.TabIndex = 75;
            this.txtSaldoHoje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldoHoje
            // 
            this.lblSaldoHoje.AutoSize = true;
            this.lblSaldoHoje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSaldoHoje.Location = new System.Drawing.Point(255, 447);
            this.lblSaldoHoje.Name = "lblSaldoHoje";
            this.lblSaldoHoje.Size = new System.Drawing.Size(60, 13);
            this.lblSaldoHoje.TabIndex = 76;
            this.lblSaldoHoje.Text = "Saldo hoje:";
            // 
            // txtValorCréditos
            // 
            this.txtValorCréditos.AllowNegative = true;
            this.txtValorCréditos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorCréditos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtValorCréditos.Flags = 7680;
            this.txtValorCréditos.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCréditos.ForeColor = System.Drawing.Color.Black;
            this.txtValorCréditos.Location = new System.Drawing.Point(323, 275);
            this.txtValorCréditos.MaxWholeDigits = 9;
            this.txtValorCréditos.Name = "txtValorCréditos";
            this.txtValorCréditos.RangeMax = 1.7976931348623157E+308D;
            this.txtValorCréditos.RangeMin = -1.7976931348623157E+308D;
            this.txtValorCréditos.ReadOnly = true;
            this.txtValorCréditos.Size = new System.Drawing.Size(169, 20);
            this.txtValorCréditos.TabIndex = 78;
            this.txtValorCréditos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCréditos
            // 
            this.lblCréditos.AutoSize = true;
            this.lblCréditos.Location = new System.Drawing.Point(257, 281);
            this.lblCréditos.Name = "lblCréditos";
            this.lblCréditos.Size = new System.Drawing.Size(60, 13);
            this.lblCréditos.TabIndex = 77;
            this.lblCréditos.Text = "(-) Créditos:";
            this.lblCréditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDevolução
            // 
            this.lblDevolução.AutoSize = true;
            this.lblDevolução.Location = new System.Drawing.Point(243, 170);
            this.lblDevolução.Name = "lblDevolução";
            this.lblDevolução.Size = new System.Drawing.Size(74, 13);
            this.lblDevolução.TabIndex = 80;
            this.lblDevolução.Text = "(-) Devolução:";
            this.lblDevolução.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDevolução
            // 
            this.txtDevolução.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDevolução.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(213)))), ((int)(((byte)(175)))));
            this.txtDevolução.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevolução.Location = new System.Drawing.Point(323, 166);
            this.txtDevolução.Name = "txtDevolução";
            this.txtDevolução.Size = new System.Drawing.Size(169, 20);
            this.txtDevolução.TabIndex = 79;
            this.txtDevolução.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkRastreada
            // 
            this.chkRastreada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRastreada.AutoSize = true;
            this.chkRastreada.Location = new System.Drawing.Point(3, 476);
            this.chkRastreada.Name = "chkRastreada";
            this.chkRastreada.Size = new System.Drawing.Size(216, 17);
            this.chkRastreada.TabIndex = 81;
            this.chkRastreada.Text = "Constar no rastreamento de mercadorias";
            this.chkRastreada.UseVisualStyleBackColor = true;
            this.chkRastreada.CheckedChanged += new System.EventHandler(this.chkRastreada_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Location = new System.Drawing.Point(0, 544);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 13);
            this.linkLabel1.TabIndex = 84;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Associar corretor..";
            this.linkLabel1.Visible = false;
            // 
            // cmbTabela
            // 
            this.cmbTabela.Cotação = this.txtCotação;
            this.cmbTabela.DisplayMember = "Nome";
            this.cmbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.FormattingEnabled = true;
            this.cmbTabela.Location = new System.Drawing.Point(86, 117);
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(150, 21);
            this.cmbTabela.TabIndex = 13;
            this.cmbTabela.SelectedIndexChanged += new System.EventHandler(this.cmbTabela_SelectedIndexChanged);
            // 
            // txtCotação
            // 
            this.txtCotação.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCotação.Cotação = null;
            this.txtCotação.Location = new System.Drawing.Point(323, 116);
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Size = new System.Drawing.Size(169, 20);
            this.txtCotação.TabIndex = 15;
            this.toolTip.SetToolTip(this.txtCotação, "Cotação que foi utilizada na venda. ");
            this.txtCotação.Valor = 0D;
            this.txtCotação.EscolheuCotação += new Apresentação.Mercadoria.Cotação.TxtCotação.Escolha(this.txtCotação_EscolheuCotação);
            // 
            // txtVendedor
            // 
            this.txtVendedor.AlturaProposta = 60;
            this.txtVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendedor.Location = new System.Drawing.Point(86, 12);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Pessoa = null;
            this.txtVendedor.Size = new System.Drawing.Size(406, 20);
            this.txtVendedor.SomenteCadastrado = true;
            this.txtVendedor.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtVendedor, "Pode ser o representante ou o funcionário da empresa que realizou a venda.");
            this.txtVendedor.Vendedores = true;
            this.txtVendedor.Selecionado += new System.EventHandler(this.txtVendedor_Selecionado);
            this.txtVendedor.Deselecionado += new System.EventHandler(this.txtVendedor_Deselecionado);
            // 
            // txtCliente
            // 
            this.txtCliente.AlturaProposta = 60;
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(86, 38);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Pessoa = null;
            this.txtCliente.Size = new System.Drawing.Size(406, 20);
            this.txtCliente.SomenteCadastrado = true;
            this.txtCliente.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtCliente, "O cliente da venda precisa estar cadastrado no banco de dados.");
            this.txtCliente.Selecionado += new System.EventHandler(this.txtCliente_Selecionado);
            this.txtCliente.Deselecionado += new System.EventHandler(this.txtCliente_Deselecionado);
            // 
            // txtData
            // 
            this.txtData.ControleCotação = this.txtCotação;
            this.txtData.CustomFormat = "dd/MM/yyyy";
            this.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtData.Location = new System.Drawing.Point(86, 90);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(150, 20);
            this.txtData.TabIndex = 8;
            this.toolTip.SetToolTip(this.txtData, "Data em que foi realizada a venda.");
            this.txtData.ValueChanged += new System.EventHandler(this.txtData_ValueChanged);
            this.txtData.Validated += new System.EventHandler(this.txtData_Validated);
            // 
            // DadosVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.chkSedex);
            this.Controls.Add(this.btnTrocarClienteVendedor);
            this.Controls.Add(this.chkRastreada);
            this.Controls.Add(this.lblDevolução);
            this.Controls.Add(this.txtDevolução);
            this.Controls.Add(this.txtValorCréditos);
            this.Controls.Add(this.lblCréditos);
            this.Controls.Add(this.lblSaldoHoje);
            this.Controls.Add(this.txtSaldoHoje);
            this.Controls.Add(this.txtValorDébitos);
            this.Controls.Add(this.lblJuros);
            this.Controls.Add(this.txtJuros);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblValorVenda);
            this.Controls.Add(this.lblDébitos);
            this.Controls.Add(this.txtValorItens);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.lblInfoDívida);
            this.Controls.Add(this.txtValorPagoLíquido);
            this.Controls.Add(this.lblValorPagoLíquido);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtDiasSemJuros);
            this.Controls.Add(this.btnAcerto);
            this.Controls.Add(this.txtAcerto);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chkVendaQuitada);
            this.Controls.Add(this.txtPrestações);
            this.Controls.Add(this.txtTaxaJuros);
            this.Controls.Add(this.lblPrestações);
            this.Controls.Add(this.txtSaldoDataVenda);
            this.Controls.Add(this.lblSaldoNaDataVenda);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.lblValorPago);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblValorPagar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbTabela);
            this.Controls.Add(this.txtPercentualDesconto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtControle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCotação);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "DadosVenda";
            this.Size = new System.Drawing.Size(504, 557);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtVendedor;
        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtCliente;
        private System.Windows.Forms.Label label2;
        private Apresentação.Mercadoria.Cotação.TxtDataCotação txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Apresentação.Mercadoria.Cotação.TxtCotação txtCotação;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtControle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPercentualDesconto;
        private ComboTabela cmbTabela;
        private System.Windows.Forms.Label label12;
        private AMS.TextBox.CurrencyTextBox txtTotal;
        private System.Windows.Forms.Label lblValorPagar;
        private AMS.TextBox.CurrencyTextBox txtValorPago;
        private System.Windows.Forms.Label lblValorPago;
        private AMS.TextBox.CurrencyTextBox txtSaldoDataVenda;
        private System.Windows.Forms.Label lblSaldoNaDataVenda;
        private System.Windows.Forms.Label lblPrestações;
        private System.Windows.Forms.TextBox txtTaxaJuros;
        private System.Windows.Forms.TextBox txtPrestações;
        private System.ComponentModel.BackgroundWorker bgAtualizarPreços;
        private System.Windows.Forms.CheckBox chkVendaQuitada;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAcerto;
        private System.Windows.Forms.Button btnAcerto;
        private AMS.TextBox.IntegerTextBox txtDiasSemJuros;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblValorPagoLíquido;
        private AMS.TextBox.CurrencyTextBox txtValorPagoLíquido;
        private System.Windows.Forms.Label lblInfoDívida;
        private System.Windows.Forms.Label lblItens;
        private AMS.TextBox.CurrencyTextBox txtValorItens;
        private System.Windows.Forms.Label lblDébitos;
        private AMS.TextBox.CurrencyTextBox txtSubtotal;
        private System.Windows.Forms.Label lblValorVenda;
        private System.Windows.Forms.Label lblDesconto;
        private AMS.TextBox.CurrencyTextBox txtDesconto;
        private System.Windows.Forms.Label lblJuros;
        private AMS.TextBox.CurrencyTextBox txtJuros;
        private AMS.TextBox.CurrencyTextBox txtValorDébitos;
        private AMS.TextBox.CurrencyTextBox txtSaldoHoje;
        private System.Windows.Forms.Label lblSaldoHoje;
        private AMS.TextBox.CurrencyTextBox txtValorCréditos;
        private System.Windows.Forms.Label lblCréditos;
        private System.Windows.Forms.Label lblDevolução;
        private System.Windows.Forms.TextBox txtDevolução;
        private System.Windows.Forms.CheckBox chkRastreada;
        private System.Windows.Forms.Panel btnTrocarClienteVendedor;
        private System.Windows.Forms.CheckBox chkSedex;
        private System.Windows.Forms.LinkLabel linkLabel1;

    }
}
