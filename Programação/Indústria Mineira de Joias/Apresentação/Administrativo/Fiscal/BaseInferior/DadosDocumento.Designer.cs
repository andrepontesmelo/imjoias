namespace Apresentação.Administrativo.Fiscal.BaseInferior
{
    partial class DadosDocumento
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
            this.txtSubtotal = new AMS.TextBox.CurrencyTextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtDesconto = new AMS.TextBox.CurrencyTextBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new Apresentação.Fiscal.Combobox.ComboTipoDocumento();
            this.txtEmitente = new Apresentação.Pessoa.TextBoxCNPJ();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCnpjEmissor = new Apresentação.Pessoa.TextBoxCNPJ();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCpfEmissor = new Apresentação.Pessoa.TextBoxCPF();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtEntradaSaída
            // 
            this.dtEntradaSaída.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtEntradaSaída.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtEntradaSaída.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEntradaSaída.Location = new System.Drawing.Point(72, 55);
            this.dtEntradaSaída.Name = "dtEntradaSaída";
            this.dtEntradaSaída.Size = new System.Drawing.Size(323, 20);
            this.dtEntradaSaída.TabIndex = 2;
            // 
            // dtEmissão
            // 
            this.dtEmissão.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtEmissão.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtEmissão.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEmissão.Location = new System.Drawing.Point(72, 29);
            this.dtEmissão.Name = "dtEmissão";
            this.dtEmissão.Size = new System.Drawing.Size(323, 20);
            this.dtEmissão.TabIndex = 1;
            this.dtEmissão.Validated += new System.EventHandler(this.dtEmissão_Validated);
            // 
            // txtNúmero
            // 
            this.txtNúmero.AllowNegative = true;
            this.txtNúmero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNúmero.DigitsInGroup = 0;
            this.txtNúmero.Flags = 0;
            this.txtNúmero.Location = new System.Drawing.Point(72, 161);
            this.txtNúmero.MaxDecimalPlaces = 4;
            this.txtNúmero.MaxWholeDigits = 9;
            this.txtNúmero.Name = "txtNúmero";
            this.txtNúmero.Prefix = "";
            this.txtNúmero.RangeMax = 1.7976931348623157E+308D;
            this.txtNúmero.RangeMin = -1.7976931348623157E+308D;
            this.txtNúmero.Size = new System.Drawing.Size(323, 20);
            this.txtNúmero.TabIndex = 4;
            this.txtNúmero.Text = "1";
            this.txtNúmero.Validated += new System.EventHandler(this.txtNúmero_Validated);
            // 
            // txtValor
            // 
            this.txtValor.AllowNegative = true;
            this.txtValor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValor.Flags = 7680;
            this.txtValor.Location = new System.Drawing.Point(72, 135);
            this.txtValor.MaxWholeDigits = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.RangeMax = 1.7976931348623157E+308D;
            this.txtValor.RangeMin = -1.7976931348623157E+308D;
            this.txtValor.Size = new System.Drawing.Size(323, 20);
            this.txtValor.TabIndex = 3;
            this.txtValor.Text = "R$ 1,00";
            this.txtValor.Validated += new System.EventHandler(this.txtValor_Validated);
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtId.Location = new System.Drawing.Point(72, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(323, 20);
            this.txtId.TabIndex = 0;
            this.txtId.Validating += new System.ComponentModel.CancelEventHandler(this.txtId_Validating);
            this.txtId.Validated += new System.EventHandler(this.txtId_Validated);
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(407, 6);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(102, 13);
            this.lblTipoDocumento.TabIndex = 20;
            this.lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Emitente:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Número:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Total:";
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEntradaSaída.AutoSize = true;
            this.lblEntradaSaída.Location = new System.Drawing.Point(12, 61);
            this.lblEntradaSaída.Name = "lblEntradaSaída";
            this.lblEntradaSaída.Size = new System.Drawing.Size(48, 13);
            this.lblEntradaSaída.TabIndex = 16;
            this.lblEntradaSaída.Text = "Ent/Saí:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Emissão:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Id:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.AllowNegative = true;
            this.txtSubtotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSubtotal.Flags = 7680;
            this.txtSubtotal.Location = new System.Drawing.Point(72, 82);
            this.txtSubtotal.MaxWholeDigits = 9;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.RangeMax = 1.7976931348623157E+308D;
            this.txtSubtotal.RangeMin = -1.7976931348623157E+308D;
            this.txtSubtotal.Size = new System.Drawing.Size(323, 20);
            this.txtSubtotal.TabIndex = 21;
            this.txtSubtotal.Text = "R$ 1,00";
            this.txtSubtotal.Validated += new System.EventHandler(this.txtSubtotal_Validated);
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(12, 89);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(49, 13);
            this.lblSubTotal.TabIndex = 22;
            this.lblSubTotal.Text = "Subtotal:";
            // 
            // txtDesconto
            // 
            this.txtDesconto.AllowNegative = true;
            this.txtDesconto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDesconto.Flags = 7680;
            this.txtDesconto.Location = new System.Drawing.Point(72, 108);
            this.txtDesconto.MaxWholeDigits = 9;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.RangeMax = 1.7976931348623157E+308D;
            this.txtDesconto.RangeMin = -1.7976931348623157E+308D;
            this.txtDesconto.Size = new System.Drawing.Size(323, 20);
            this.txtDesconto.TabIndex = 23;
            this.txtDesconto.Text = "R$ 1,00";
            this.txtDesconto.Validated += new System.EventHandler(this.txtDesconto_Validated);
            // 
            // lblDesconto
            // 
            this.lblDesconto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(12, 115);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(56, 13);
            this.lblDesconto.TabIndex = 24;
            this.lblDesconto.Text = "Desconto:";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(515, 2);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Seleção = null;
            this.cmbTipoDocumento.Size = new System.Drawing.Size(125, 21);
            this.cmbTipoDocumento.TabIndex = 6;
            this.cmbTipoDocumento.Validated += new System.EventHandler(this.cmbTipoDocumento_Validated);
            // 
            // txtEmitente
            // 
            this.txtEmitente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmitente.Location = new System.Drawing.Point(72, 187);
            this.txtEmitente.Name = "txtEmitente";
            this.txtEmitente.Size = new System.Drawing.Size(326, 20);
            this.txtEmitente.TabIndex = 5;
            this.txtEmitente.Validated += new System.EventHandler(this.txtEmitente_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCnpjEmissor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCpfEmissor);
            this.groupBox1.Location = new System.Drawing.Point(15, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 74);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Emissor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "CPF:";
            // 
            // txtCnpjEmissor
            // 
            this.txtCnpjEmissor.Location = new System.Drawing.Point(57, 21);
            this.txtCnpjEmissor.Name = "txtCnpjEmissor";
            this.txtCnpjEmissor.Size = new System.Drawing.Size(323, 20);
            this.txtCnpjEmissor.TabIndex = 31;
            this.txtCnpjEmissor.Validated += new System.EventHandler(this.txtCnpjEmissor_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "CNPJ:";
            // 
            // txtCpfEmissor
            // 
            this.txtCpfEmissor.Location = new System.Drawing.Point(57, 47);
            this.txtCpfEmissor.Name = "txtCpfEmissor";
            this.txtCpfEmissor.Size = new System.Drawing.Size(323, 20);
            this.txtCpfEmissor.TabIndex = 32;
            this.txtCpfEmissor.Validated += new System.EventHandler(this.txtCpfEmissor_Validated);
            // 
            // DadosDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.cmbTipoDocumento);
            this.Controls.Add(this.txtEmitente);
            this.Controls.Add(this.dtEntradaSaída);
            this.Controls.Add(this.dtEmissão);
            this.Controls.Add(this.txtNúmero);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEntradaSaída);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DadosDocumento";
            this.Size = new System.Drawing.Size(654, 297);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Apresentação.Fiscal.Combobox.ComboTipoDocumento cmbTipoDocumento;
        protected System.Windows.Forms.DateTimePicker dtEntradaSaída;
        protected System.Windows.Forms.TextBox txtId;
        protected System.Windows.Forms.Label lblTipoDocumento;
        protected System.Windows.Forms.Label lblEntradaSaída;
        protected Pessoa.TextBoxCNPJ txtEmitente;
        protected System.Windows.Forms.DateTimePicker dtEmissão;
        protected AMS.TextBox.NumericTextBox txtNúmero;
        protected AMS.TextBox.CurrencyTextBox txtValor;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected AMS.TextBox.CurrencyTextBox txtSubtotal;
        protected System.Windows.Forms.Label lblSubTotal;
        protected AMS.TextBox.CurrencyTextBox txtDesconto;
        protected System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private Pessoa.TextBoxCNPJ txtCnpjEmissor;
        private System.Windows.Forms.Label label7;
        private Pessoa.TextBoxCPF txtCpfEmissor;
    }
}
