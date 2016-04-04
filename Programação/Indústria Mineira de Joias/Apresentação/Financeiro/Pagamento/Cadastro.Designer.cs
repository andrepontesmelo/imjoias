namespace Apresentação.Financeiro.Pagamento
{
    partial class Cadastro
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkListaVendas = new System.Windows.Forms.CheckedListBox();
            this.lnkMais = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.lblDescriçãoPagamento = new System.Windows.Forms.Label();
            this.chkCobrarJuros = new System.Windows.Forms.CheckBox();
            this.txtValor = new AMS.TextBox.CurrencyTextBox();
            this.chkPagamentoPendente = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(145, 20);
            this.lblTítulo.Text = "Novo Pagamento";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(172, 48);
            this.lblDescrição.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(104, 351);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.Location = new System.Drawing.Point(185, 351);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkListaVendas
            // 
            this.chkListaVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListaVendas.FormattingEnabled = true;
            this.chkListaVendas.Location = new System.Drawing.Point(6, 49);
            this.chkListaVendas.Name = "chkListaVendas";
            this.chkListaVendas.Size = new System.Drawing.Size(153, 139);
            this.chkListaVendas.Sorted = true;
            this.chkListaVendas.TabIndex = 5;
            this.chkListaVendas.TabStop = false;
            // 
            // lnkMais
            // 
            this.lnkMais.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkMais.AutoSize = true;
            this.lnkMais.Location = new System.Drawing.Point(96, 190);
            this.lnkMais.Name = "lnkMais";
            this.lnkMais.Size = new System.Drawing.Size(56, 13);
            this.lnkMais.TabIndex = 4;
            this.lnkMais.TabStop = true;
            this.lnkMais.Text = "Procurar...";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDescrição);
            this.groupBox1.Controls.Add(this.lblDescriçãoPagamento);
            this.groupBox1.Controls.Add(this.chkCobrarJuros);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.chkPagamentoPendente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.data);
            this.groupBox1.Location = new System.Drawing.Point(2, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 257);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do pagamento";
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Location = new System.Drawing.Point(9, 113);
            this.txtDescrição.MaxLength = 240;
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrição.Size = new System.Drawing.Size(242, 91);
            this.txtDescrição.TabIndex = 15;
            this.txtDescrição.Validated += new System.EventHandler(this.txtIdentificação_Validated);
            // 
            // lblDescriçãoPagamento
            // 
            this.lblDescriçãoPagamento.AutoSize = true;
            this.lblDescriçãoPagamento.Location = new System.Drawing.Point(6, 97);
            this.lblDescriçãoPagamento.Name = "lblDescriçãoPagamento";
            this.lblDescriçãoPagamento.Size = new System.Drawing.Size(55, 13);
            this.lblDescriçãoPagamento.TabIndex = 16;
            this.lblDescriçãoPagamento.Text = "Descrição";
            // 
            // chkCobrarJuros
            // 
            this.chkCobrarJuros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCobrarJuros.AutoSize = true;
            this.chkCobrarJuros.BackColor = System.Drawing.SystemColors.Control;
            this.chkCobrarJuros.Checked = true;
            this.chkCobrarJuros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCobrarJuros.Location = new System.Drawing.Point(6, 211);
            this.chkCobrarJuros.Name = "chkCobrarJuros";
            this.chkCobrarJuros.Size = new System.Drawing.Size(85, 17);
            this.chkCobrarJuros.TabIndex = 4;
            this.chkCobrarJuros.TabStop = false;
            this.chkCobrarJuros.Text = "Cobrar Juros";
            this.chkCobrarJuros.UseVisualStyleBackColor = false;
            // 
            // txtValor
            // 
            this.txtValor.AllowNegative = true;
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Flags = 7680;
            this.txtValor.Location = new System.Drawing.Point(6, 32);
            this.txtValor.MaxWholeDigits = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.RangeMax = 1.7976931348623157E+308D;
            this.txtValor.RangeMin = 0D;
            this.txtValor.Size = new System.Drawing.Size(245, 20);
            this.txtValor.TabIndex = 1;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Validated += new System.EventHandler(this.txtValor_Validated);
            // 
            // chkPagamentoPendente
            // 
            this.chkPagamentoPendente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPagamentoPendente.AutoSize = true;
            this.chkPagamentoPendente.BackColor = System.Drawing.SystemColors.Control;
            this.chkPagamentoPendente.Location = new System.Drawing.Point(6, 234);
            this.chkPagamentoPendente.Name = "chkPagamentoPendente";
            this.chkPagamentoPendente.Size = new System.Drawing.Size(151, 17);
            this.chkPagamentoPendente.TabIndex = 3;
            this.chkPagamentoPendente.TabStop = false;
            this.chkPagamentoPendente.Text = "Pagamento pendente";
            this.chkPagamentoPendente.UseVisualStyleBackColor = false;
            this.chkPagamentoPendente.CheckedChanged += new System.EventHandler(this.chkPagamentoPendente_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Recebimento:";
            // 
            // data
            // 
            this.data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data.Location = new System.Drawing.Point(6, 71);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(245, 20);
            this.data.TabIndex = 2;
            this.data.TabStop = false;
            this.data.Validated += new System.EventHandler(this.data_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkListaVendas);
            this.groupBox2.Controls.Add(this.lnkMais);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(406, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 206);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendas";
            this.groupBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "Este relaciona-se às seguintes vendas:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cadastro
            // 
            this.AcceptButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(260, 375);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Cadastro";
            this.ShowInTaskbar = true;
            this.Text = "Pagamento";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkListaVendas;
        private System.Windows.Forms.LinkLabel lnkMais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.CheckBox chkPagamentoPendente;
        protected AMS.TextBox.CurrencyTextBox txtValor;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.CheckBox chkCobrarJuros;
        private System.Windows.Forms.Label lblDescriçãoPagamento;
        protected System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.Button btnCancelar;
        protected System.Windows.Forms.DateTimePicker data;
        protected System.Windows.Forms.TextBox txtDescrição;
    }
}
