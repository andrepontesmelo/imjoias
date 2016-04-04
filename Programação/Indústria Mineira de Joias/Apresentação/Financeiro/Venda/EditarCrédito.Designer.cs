namespace Apresentação.Financeiro.Venda
{
    partial class EditarCrédito
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblData = new System.Windows.Forms.Label();
            this.lblValorBruto = new System.Windows.Forms.Label();
            this.txtValorBruto = new AMS.TextBox.CurrencyTextBox();
            this.lblValorLíquido = new System.Windows.Forms.Label();
            this.lblDescrição1 = new System.Windows.Forms.Label();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.chkCobrarJuros = new System.Windows.Forms.CheckBox();
            this.lblDiasJuros = new System.Windows.Forms.Label();
            this.txtValorLíquido = new AMS.TextBox.CurrencyTextBox();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.txtDiasDeJuros = new AMS.TextBox.IntegerTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(67, 20);
            this.lblTítulo.Text = "Crédito";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Defina os valores a serem acrescentados na cobrança da venda.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.dinheiro;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblData, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblValorBruto, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtValorBruto, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblValorLíquido, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDescrição1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDescrição, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkCobrarJuros, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDiasJuros, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtValorLíquido, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.data, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDiasDeJuros, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 205);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblData
            // 
            this.lblData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(3, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(73, 30);
            this.lblData.TabIndex = 9;
            this.lblData.Text = "Data:";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorBruto
            // 
            this.lblValorBruto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorBruto.AutoSize = true;
            this.lblValorBruto.Location = new System.Drawing.Point(3, 30);
            this.lblValorBruto.Name = "lblValorBruto";
            this.lblValorBruto.Size = new System.Drawing.Size(73, 30);
            this.lblValorBruto.TabIndex = 1;
            this.lblValorBruto.Text = "Valor Bruto:";
            this.lblValorBruto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValorBruto
            // 
            this.txtValorBruto.AllowNegative = true;
            this.txtValorBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorBruto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValorBruto.Flags = 7680;
            this.txtValorBruto.Location = new System.Drawing.Point(82, 33);
            this.txtValorBruto.MaxWholeDigits = 9;
            this.txtValorBruto.Name = "txtValorBruto";
            this.txtValorBruto.RangeMax = 1.7976931348623157E+308D;
            this.txtValorBruto.RangeMin = 0D;
            this.txtValorBruto.Size = new System.Drawing.Size(267, 20);
            this.txtValorBruto.TabIndex = 1;
            this.txtValorBruto.Validated += new System.EventHandler(this.txtValor_Validated);
            // 
            // lblValorLíquido
            // 
            this.lblValorLíquido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorLíquido.AutoSize = true;
            this.lblValorLíquido.Location = new System.Drawing.Point(3, 60);
            this.lblValorLíquido.Name = "lblValorLíquido";
            this.lblValorLíquido.Size = new System.Drawing.Size(73, 30);
            this.lblValorLíquido.TabIndex = 4;
            this.lblValorLíquido.Text = "Valor Líquido:";
            this.lblValorLíquido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescrição1
            // 
            this.lblDescrição1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrição1.Location = new System.Drawing.Point(3, 90);
            this.lblDescrição1.Name = "lblDescrição1";
            this.lblDescrição1.Size = new System.Drawing.Size(73, 30);
            this.lblDescrição1.TabIndex = 0;
            this.lblDescrição1.Text = "Descrição:";
            this.lblDescrição1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescrição
            // 
            this.txtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescrição.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescrição.Location = new System.Drawing.Point(82, 93);
            this.txtDescrição.MaxLength = 255;
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrição.Size = new System.Drawing.Size(267, 24);
            this.txtDescrição.TabIndex = 3;
            this.txtDescrição.Validated += new System.EventHandler(this.txtDescrição_Validated);
            // 
            // chkCobrarJuros
            // 
            this.chkCobrarJuros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCobrarJuros.Location = new System.Drawing.Point(82, 123);
            this.chkCobrarJuros.Name = "chkCobrarJuros";
            this.chkCobrarJuros.Size = new System.Drawing.Size(267, 24);
            this.chkCobrarJuros.TabIndex = 4;
            this.chkCobrarJuros.Text = "Cobrar Juros";
            this.chkCobrarJuros.UseVisualStyleBackColor = true;
            this.chkCobrarJuros.CheckedChanged += new System.EventHandler(this.chkCobrarJuros_CheckedChanged);
            this.chkCobrarJuros.Validated += new System.EventHandler(this.chkCobrarJuros_Validated);
            // 
            // lblDiasJuros
            // 
            this.lblDiasJuros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiasJuros.AutoSize = true;
            this.lblDiasJuros.Location = new System.Drawing.Point(3, 150);
            this.lblDiasJuros.Name = "lblDiasJuros";
            this.lblDiasJuros.Size = new System.Drawing.Size(73, 30);
            this.lblDiasJuros.TabIndex = 5;
            this.lblDiasJuros.Text = "Dias de juros:";
            this.lblDiasJuros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValorLíquido
            // 
            this.txtValorLíquido.AllowNegative = true;
            this.txtValorLíquido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorLíquido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValorLíquido.Enabled = false;
            this.txtValorLíquido.Flags = 7680;
            this.txtValorLíquido.Location = new System.Drawing.Point(82, 63);
            this.txtValorLíquido.MaxWholeDigits = 9;
            this.txtValorLíquido.Name = "txtValorLíquido";
            this.txtValorLíquido.RangeMax = 1.7976931348623157E+308D;
            this.txtValorLíquido.RangeMin = 0D;
            this.txtValorLíquido.Size = new System.Drawing.Size(267, 20);
            this.txtValorLíquido.TabIndex = 2;
            this.txtValorLíquido.Validated += new System.EventHandler(this.txtValorLíquido_Validated);
            // 
            // data
            // 
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.Location = new System.Drawing.Point(82, 3);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(267, 20);
            this.data.TabIndex = 13;
            this.data.ValueChanged += new System.EventHandler(this.data_ValueChanged);
            this.data.Validated += new System.EventHandler(this.data_Validated);
            // 
            // txtDiasDeJuros
            // 
            this.txtDiasDeJuros.AllowNegative = true;
            this.txtDiasDeJuros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiasDeJuros.DigitsInGroup = 0;
            this.txtDiasDeJuros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiasDeJuros.Flags = 0;
            this.txtDiasDeJuros.Location = new System.Drawing.Point(82, 153);
            this.txtDiasDeJuros.MaxDecimalPlaces = 0;
            this.txtDiasDeJuros.MaxWholeDigits = 9;
            this.txtDiasDeJuros.Name = "txtDiasDeJuros";
            this.txtDiasDeJuros.Prefix = "";
            this.txtDiasDeJuros.RangeMax = 1.7976931348623157E+308D;
            this.txtDiasDeJuros.RangeMin = -1.7976931348623157E+308D;
            this.txtDiasDeJuros.Size = new System.Drawing.Size(267, 20);
            this.txtDiasDeJuros.TabIndex = 5;
            this.txtDiasDeJuros.Text = "1";
            this.txtDiasDeJuros.TextChanged += new System.EventHandler(this.txtDiasDeJuros_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(224, 314);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 314);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // EditarCrédito
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 349);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditarCrédito";
            this.Text = "Editar débito";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDescrição1;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Label lblValorBruto;
        private AMS.TextBox.CurrencyTextBox txtValorBruto;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkCobrarJuros;
        private System.Windows.Forms.Label lblDiasJuros;
        private System.Windows.Forms.Label lblValorLíquido;
        private System.Windows.Forms.Label lblData;
        private AMS.TextBox.CurrencyTextBox txtValorLíquido;
        private System.Windows.Forms.DateTimePicker data;
        private AMS.TextBox.IntegerTextBox txtDiasDeJuros;
    }
}