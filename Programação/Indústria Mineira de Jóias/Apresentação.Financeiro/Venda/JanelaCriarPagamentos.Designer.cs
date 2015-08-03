namespace Apresentação.Financeiro.Venda
{
    partial class JanelaCriarPagamentos
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblValorComDesconto = new System.Windows.Forms.Label();
            this.txtDescontoPercentual = new System.Windows.Forms.TextBox();
            this.botãoLiberarDesconto = new Apresentação.Formulários.BotãoLiberarRecurso();
            this.txtDesconto = new AMS.TextBox.CurrencyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.cmbPrestações = new System.Windows.Forms.ComboBox();
            this.botãoLiberarPrestações = new Apresentação.Formulários.BotãoLiberarRecurso();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDívida = new System.Windows.Forms.Label();
            this.lblPrestação = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValorFinal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblJuros = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.botãoLiberarDiasSemJuros = new Apresentação.Formulários.BotãoLiberarRecurso();
            this.txtDiasSemJuros = new AMS.TextBox.IntegerTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioDinheiro = new System.Windows.Forms.RadioButton();
            this.radioCheque = new System.Windows.Forms.RadioButton();
            this.radioCrédito = new System.Windows.Forms.RadioButton();
            this.radioDébito = new System.Windows.Forms.RadioButton();
            this.radioPromissória = new System.Windows.Forms.RadioButton();
            this.radioPersonalizar = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.timerAtualizar = new System.Windows.Forms.Timer(this.components);
            this.lnkDatas = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(180, 20);
            this.lblTítulo.Text = "Forma de pagamento";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(390, 48);
            this.lblDescrição.Text = "Defina qual a forma de pagamento a ser utilizada.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Financeiro.Properties.Resources.money_bag1;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblValor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblValorComDesconto, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDescontoPercentual, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.botãoLiberarDesconto, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDesconto, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPago, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbPrestações, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.botãoLiberarPrestações, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDívida, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblPrestação, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblValorFinal, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblJuros, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.botãoLiberarDiasSemJuros, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtDiasSemJuros, 1, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 269);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValor
            // 
            this.lblValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValor.Location = new System.Drawing.Point(145, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(121, 26);
            this.lblValor.TabIndex = 1;
            this.lblValor.Text = "lblValor";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Percentual de desconto:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Desconto:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(3, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 26);
            this.label7.TabIndex = 7;
            this.label7.Text = "Valor com desconto:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorComDesconto
            // 
            this.lblValorComDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorComDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorComDesconto.Location = new System.Drawing.Point(145, 78);
            this.lblValorComDesconto.Name = "lblValorComDesconto";
            this.lblValorComDesconto.Size = new System.Drawing.Size(121, 26);
            this.lblValorComDesconto.TabIndex = 8;
            this.lblValorComDesconto.Text = "lbl...";
            this.lblValorComDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescontoPercentual
            // 
            this.txtDescontoPercentual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescontoPercentual.Location = new System.Drawing.Point(145, 29);
            this.txtDescontoPercentual.Name = "txtDescontoPercentual";
            this.txtDescontoPercentual.ReadOnly = true;
            this.txtDescontoPercentual.Size = new System.Drawing.Size(121, 20);
            this.txtDescontoPercentual.TabIndex = 3;
            this.txtDescontoPercentual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoPercentual.TextChanged += new System.EventHandler(this.txtDescontoPercentual_TextChanged);
            this.txtDescontoPercentual.Leave += new System.EventHandler(this.txtDescontoPercentual_Leave);
            // 
            // botãoLiberarDesconto
            // 
            this.botãoLiberarDesconto.AutoSize = true;
            this.botãoLiberarDesconto.Descrição = "Permite dar um desconto ao cliente na venda.";
            this.botãoLiberarDesconto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botãoLiberarDesconto.Location = new System.Drawing.Point(272, 29);
            this.botãoLiberarDesconto.Name = "botãoLiberarDesconto";
            this.botãoLiberarDesconto.Privilégios = Entidades.Privilégio.Permissão.PersonalizarVenda;
            this.botãoLiberarDesconto.Recurso = "Desconto na Venda";
            this.botãoLiberarDesconto.Size = new System.Drawing.Size(19, 20);
            this.botãoLiberarDesconto.TabIndex = 4;
            this.botãoLiberarDesconto.Texto = "";
            this.botãoLiberarDesconto.LiberarRecurso += new System.EventHandler(this.botãoLiberarDesconto_LiberarRecurso);
            // 
            // txtDesconto
            // 
            this.txtDesconto.AllowNegative = true;
            this.txtDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesconto.Flags = 7680;
            this.txtDesconto.Location = new System.Drawing.Point(145, 55);
            this.txtDesconto.MaxWholeDigits = 9;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.RangeMax = 1.7976931348623157E+308;
            this.txtDesconto.RangeMin = 0;
            this.txtDesconto.ReadOnly = true;
            this.txtDesconto.Size = new System.Drawing.Size(121, 20);
            this.txtDesconto.TabIndex = 6;
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            this.txtDesconto.Leave += new System.EventHandler(this.txtDescontoPercentual_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "Valor já pago:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPago
            // 
            this.lblPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(145, 104);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(121, 26);
            this.lblPago.TabIndex = 19;
            this.lblPago.Text = "lblPago";
            this.lblPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPrestações
            // 
            this.cmbPrestações.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrestações.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrestações.FormattingEnabled = true;
            this.cmbPrestações.Items.AddRange(new object[] {
            "0",
            "30",
            "30x60",
            "30x60x90"});
            this.cmbPrestações.Location = new System.Drawing.Point(145, 159);
            this.cmbPrestações.Name = "cmbPrestações";
            this.cmbPrestações.Size = new System.Drawing.Size(121, 21);
            this.cmbPrestações.TabIndex = 10;
            this.cmbPrestações.SelectedIndexChanged += new System.EventHandler(this.cmbPrestações_SelectedIndexChanged);
            this.cmbPrestações.TextUpdate += new System.EventHandler(this.cmbPrestações_TextUpdate);
            // 
            // botãoLiberarPrestações
            // 
            this.botãoLiberarPrestações.AutoSize = true;
            this.botãoLiberarPrestações.Descrição = "Permite a personalização das prestações em quantos dias o usuário desejar.";
            this.botãoLiberarPrestações.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botãoLiberarPrestações.Location = new System.Drawing.Point(272, 159);
            this.botãoLiberarPrestações.Name = "botãoLiberarPrestações";
            this.botãoLiberarPrestações.Privilégios = Entidades.Privilégio.Permissão.PersonalizarVenda;
            this.botãoLiberarPrestações.Recurso = "Personalizar Prestações";
            this.botãoLiberarPrestações.Size = new System.Drawing.Size(19, 20);
            this.botãoLiberarPrestações.TabIndex = 11;
            this.botãoLiberarPrestações.Texto = "";
            this.botãoLiberarPrestações.LiberarRecurso += new System.EventHandler(this.botãoLiberarPrestações_LiberarRecurso);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(3, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 26);
            this.label9.TabIndex = 9;
            this.label9.Text = "Prestações*:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 26);
            this.label8.TabIndex = 20;
            this.label8.Text = "Dívida:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDívida
            // 
            this.lblDívida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDívida.AutoSize = true;
            this.lblDívida.Location = new System.Drawing.Point(145, 130);
            this.lblDívida.Name = "lblDívida";
            this.lblDívida.Size = new System.Drawing.Size(121, 26);
            this.lblDívida.TabIndex = 21;
            this.lblDívida.Text = "lblDívida";
            this.lblDívida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrestação
            // 
            this.lblPrestação.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrestação.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestação.Location = new System.Drawing.Point(145, 248);
            this.lblPrestação.Name = "lblPrestação";
            this.lblPrestação.Size = new System.Drawing.Size(121, 21);
            this.lblPrestação.TabIndex = 17;
            this.lblPrestação.Text = "lbl...";
            this.lblPrestação.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(3, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Valor prestação:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Valor final:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorFinal
            // 
            this.lblValorFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorFinal.Location = new System.Drawing.Point(145, 232);
            this.lblValorFinal.Name = "lblValorFinal";
            this.lblValorFinal.Size = new System.Drawing.Size(121, 16);
            this.lblValorFinal.TabIndex = 15;
            this.lblValorFinal.Text = "lblValorFinal";
            this.lblValorFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(3, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 24);
            this.label11.TabIndex = 12;
            this.label11.Text = "Juros:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJuros
            // 
            this.lblJuros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJuros.Location = new System.Drawing.Point(145, 208);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(121, 24);
            this.lblJuros.TabIndex = 13;
            this.lblJuros.Text = "lbl...";
            this.lblJuros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(3, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 26);
            this.label10.TabIndex = 22;
            this.label10.Text = "Dias sem juros:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // botãoLiberarDiasSemJuros
            // 
            this.botãoLiberarDiasSemJuros.AutoSize = true;
            this.botãoLiberarDiasSemJuros.Descrição = "Permite definir dias sem juros.";
            this.botãoLiberarDiasSemJuros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botãoLiberarDiasSemJuros.Location = new System.Drawing.Point(272, 185);
            this.botãoLiberarDiasSemJuros.Name = "botãoLiberarDiasSemJuros";
            this.botãoLiberarDiasSemJuros.Privilégios = Entidades.Privilégio.Permissão.PersonalizarVenda;
            this.botãoLiberarDiasSemJuros.Recurso = "Dias sem juros na venda";
            this.botãoLiberarDiasSemJuros.Size = new System.Drawing.Size(19, 20);
            this.botãoLiberarDiasSemJuros.TabIndex = 4;
            this.botãoLiberarDiasSemJuros.Texto = "";
            this.botãoLiberarDiasSemJuros.LiberarRecurso += new System.EventHandler(this.botãoLiberarDiasSemJuros_LiberarRecurso);
            // 
            // txtDiasSemJuros
            // 
            this.txtDiasSemJuros.AllowNegative = true;
            this.txtDiasSemJuros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiasSemJuros.DigitsInGroup = 0;
            this.txtDiasSemJuros.Flags = 0;
            this.txtDiasSemJuros.Location = new System.Drawing.Point(145, 185);
            this.txtDiasSemJuros.MaxDecimalPlaces = 0;
            this.txtDiasSemJuros.MaxWholeDigits = 9;
            this.txtDiasSemJuros.Name = "txtDiasSemJuros";
            this.txtDiasSemJuros.Prefix = "";
            this.txtDiasSemJuros.RangeMax = 1.7976931348623157E+308;
            this.txtDiasSemJuros.RangeMin = -1.7976931348623157E+308;
            this.txtDiasSemJuros.ReadOnly = true;
            this.txtDiasSemJuros.Size = new System.Drawing.Size(121, 20);
            this.txtDiasSemJuros.TabIndex = 23;
            this.txtDiasSemJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiasSemJuros.TextChanged += new System.EventHandler(this.txtDiasSemJuros_TextChanged);
            this.txtDiasSemJuros.Leave += new System.EventHandler(this.txtDiasSemJuros_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.radioDinheiro);
            this.flowLayoutPanel1.Controls.Add(this.radioCheque);
            this.flowLayoutPanel1.Controls.Add(this.radioCrédito);
            this.flowLayoutPanel1.Controls.Add(this.radioDébito);
            this.flowLayoutPanel1.Controls.Add(this.radioPromissória);
            this.flowLayoutPanel1.Controls.Add(this.radioPersonalizar);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(126, 269);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // radioDinheiro
            // 
            this.radioDinheiro.AutoSize = true;
            this.radioDinheiro.Location = new System.Drawing.Point(3, 3);
            this.radioDinheiro.Name = "radioDinheiro";
            this.radioDinheiro.Size = new System.Drawing.Size(64, 17);
            this.radioDinheiro.TabIndex = 0;
            this.radioDinheiro.Text = "Dinheiro";
            this.radioDinheiro.UseVisualStyleBackColor = true;
            // 
            // radioCheque
            // 
            this.radioCheque.AutoSize = true;
            this.radioCheque.Checked = true;
            this.radioCheque.Location = new System.Drawing.Point(3, 26);
            this.radioCheque.Name = "radioCheque";
            this.radioCheque.Size = new System.Drawing.Size(62, 17);
            this.radioCheque.TabIndex = 0;
            this.radioCheque.TabStop = true;
            this.radioCheque.Text = "Cheque";
            this.radioCheque.UseVisualStyleBackColor = true;
            // 
            // radioCrédito
            // 
            this.radioCrédito.AutoSize = true;
            this.radioCrédito.Enabled = false;
            this.radioCrédito.Location = new System.Drawing.Point(3, 49);
            this.radioCrédito.Name = "radioCrédito";
            this.radioCrédito.Size = new System.Drawing.Size(106, 17);
            this.radioCrédito.TabIndex = 1;
            this.radioCrédito.Text = "Cartão de crédito";
            this.radioCrédito.UseVisualStyleBackColor = true;
            // 
            // radioDébito
            // 
            this.radioDébito.AutoSize = true;
            this.radioDébito.Enabled = false;
            this.radioDébito.Location = new System.Drawing.Point(3, 72);
            this.radioDébito.Name = "radioDébito";
            this.radioDébito.Size = new System.Drawing.Size(103, 17);
            this.radioDébito.TabIndex = 2;
            this.radioDébito.Text = "Cartão de débito";
            this.radioDébito.UseVisualStyleBackColor = true;
            // 
            // radioPromissória
            // 
            this.radioPromissória.AutoSize = true;
            this.radioPromissória.Location = new System.Drawing.Point(3, 95);
            this.radioPromissória.Name = "radioPromissória";
            this.radioPromissória.Size = new System.Drawing.Size(103, 17);
            this.radioPromissória.TabIndex = 3;
            this.radioPromissória.Text = "Nota promissória";
            this.radioPromissória.UseVisualStyleBackColor = true;
            // 
            // radioPersonalizar
            // 
            this.radioPersonalizar.AutoSize = true;
            this.radioPersonalizar.Location = new System.Drawing.Point(3, 118);
            this.radioPersonalizar.Name = "radioPersonalizar";
            this.radioPersonalizar.Size = new System.Drawing.Size(82, 17);
            this.radioPersonalizar.TabIndex = 4;
            this.radioPersonalizar.Text = "Personalizar";
            this.radioPersonalizar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monetário";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(325, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 294);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Forma de pagamento";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(310, 413);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(391, 413);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtualizar.AutoSize = true;
            this.btnAtualizar.Image = global::Apresentação.Financeiro.Properties.Resources.RefreshDocViewHS;
            this.btnAtualizar.Location = new System.Drawing.Point(12, 405);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(110, 23);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Atualizar valores";
            this.btnAtualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Visible = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // timerAtualizar
            // 
            this.timerAtualizar.Interval = 1000;
            this.timerAtualizar.Tick += new System.EventHandler(this.timerAtualizar_Tick);
            // 
            // lnkDatas
            // 
            this.lnkDatas.AutoSize = true;
            this.lnkDatas.Location = new System.Drawing.Point(15, 431);
            this.lnkDatas.Name = "lnkDatas";
            this.lnkDatas.Size = new System.Drawing.Size(95, 13);
            this.lnkDatas.TabIndex = 5;
            this.lnkDatas.TabStop = true;
            this.lnkDatas.Text = "*Escolher as datas";
            this.lnkDatas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDatas_LinkClicked);
            // 
            // JanelaCriarPagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 448);
            this.Controls.Add(this.lnkDatas);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JanelaCriarPagamentos";
            this.Text = "Forma de pagamento";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAtualizar, 0);
            this.Controls.SetChildIndex(this.lnkDatas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblPrestação;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblValorComDesconto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.TextBox txtDescontoPercentual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValorFinal;
        private System.Windows.Forms.Label label6;
        private Apresentação.Formulários.BotãoLiberarRecurso botãoLiberarDesconto;
        private System.Windows.Forms.ComboBox cmbPrestações;
        private Apresentação.Formulários.BotãoLiberarRecurso botãoLiberarPrestações;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioDinheiro;
        private System.Windows.Forms.RadioButton radioCheque;
        private System.Windows.Forms.RadioButton radioCrédito;
        private System.Windows.Forms.RadioButton radioDébito;
        private System.Windows.Forms.RadioButton radioPersonalizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Timer timerAtualizar;
        private System.Windows.Forms.RadioButton radioPromissória;
        private AMS.TextBox.CurrencyTextBox txtDesconto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDívida;
        private System.Windows.Forms.Label label10;
        private Apresentação.Formulários.BotãoLiberarRecurso botãoLiberarDiasSemJuros;
        private AMS.TextBox.IntegerTextBox txtDiasSemJuros;
        private System.Windows.Forms.LinkLabel lnkDatas;
    }
}