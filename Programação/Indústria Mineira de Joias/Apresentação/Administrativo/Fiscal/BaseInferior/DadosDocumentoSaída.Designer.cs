namespace Apresentação.Administrativo.Fiscal.BaseInferior
{
    partial class DadosDocumentoSaída
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
            this.chkCancelada = new System.Windows.Forms.CheckBox();
            this.cmbSetor = new Apresentação.ComboSetor();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbMáquina = new Apresentação.Administrativo.Fiscal.Combo.ComboMáquina();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCnpjEmissor = new Apresentação.Pessoa.TextBoxCNPJ();
            this.txtCpfEmissor = new Apresentação.Pessoa.TextBoxCPF();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Location = new System.Drawing.Point(509, 2);
            this.cmbTipoDocumento.Size = new System.Drawing.Size(231, 21);
            this.cmbTipoDocumento.TabIndex = 7;
            // 
            // dtEntradaSaída
            // 
            this.dtEntradaSaída.Validated += new System.EventHandler(this.dtEntradaSaída_Validated);
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Location = new System.Drawing.Point(401, 6);
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Size = new System.Drawing.Size(39, 13);
            this.lblEntradaSaída.Text = "Saída:";
            // 
            // txtEmitente
            // 
            this.txtEmitente.Location = new System.Drawing.Point(72, 186);
            this.txtEmitente.Size = new System.Drawing.Size(323, 20);
            // 
            // txtNúmero
            // 
            this.txtNúmero.Location = new System.Drawing.Point(72, 160);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(72, 132);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 193);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 167);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 139);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(72, 80);
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Location = new System.Drawing.Point(12, 87);
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(72, 106);
            // 
            // lblDesconto
            // 
            this.lblDesconto.Location = new System.Drawing.Point(12, 113);
            // 
            // chkCancelada
            // 
            this.chkCancelada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkCancelada.AutoSize = true;
            this.chkCancelada.Location = new System.Drawing.Point(72, 306);
            this.chkCancelada.Name = "chkCancelada";
            this.chkCancelada.Size = new System.Drawing.Size(77, 17);
            this.chkCancelada.TabIndex = 6;
            this.chkCancelada.Text = "Cancelada";
            this.chkCancelada.UseVisualStyleBackColor = true;
            this.chkCancelada.Validated += new System.EventHandler(this.chkCancelada_Validated);
            // 
            // cmbSetor
            // 
            this.cmbSetor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Location = new System.Drawing.Point(509, 27);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.Seleção = null;
            this.cmbSetor.Size = new System.Drawing.Size(231, 21);
            this.cmbSetor.TabIndex = 8;
            this.cmbSetor.Validated += new System.EventHandler(this.cmbSetor_Validated);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(401, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Setor:";
            // 
            // cmbMáquina
            // 
            this.cmbMáquina.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbMáquina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMáquina.FormattingEnabled = true;
            this.cmbMáquina.Location = new System.Drawing.Point(509, 53);
            this.cmbMáquina.Name = "cmbMáquina";
            this.cmbMáquina.Seleção = null;
            this.cmbMáquina.Size = new System.Drawing.Size(231, 21);
            this.cmbMáquina.TabIndex = 9;
            this.cmbMáquina.Validated += new System.EventHandler(this.cmbMáquina_Validated);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Máquina:";
            // 
            // txtCnpjEmissor
            // 
            this.txtCnpjEmissor.Location = new System.Drawing.Point(57, 21);
            this.txtCnpjEmissor.Name = "txtCnpjEmissor";
            this.txtCnpjEmissor.Size = new System.Drawing.Size(323, 20);
            this.txtCnpjEmissor.TabIndex = 31;
            this.txtCnpjEmissor.Validated += new System.EventHandler(this.txtCnpjEmissor_Validated);
            // 
            // txtCpfEmissor
            // 
            this.txtCpfEmissor.Location = new System.Drawing.Point(57, 47);
            this.txtCpfEmissor.Name = "txtCpfEmissor";
            this.txtCpfEmissor.Size = new System.Drawing.Size(323, 20);
            this.txtCpfEmissor.TabIndex = 32;
            this.txtCpfEmissor.Validated += new System.EventHandler(this.txtCpfEmissor_Validated);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCnpjEmissor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCpfEmissor);
            this.groupBox1.Location = new System.Drawing.Point(15, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 74);
            this.groupBox1.TabIndex = 34;
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
            // DadosDocumentoSaída
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMáquina);
            this.Controls.Add(this.chkCancelada);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.label13);
            this.Name = "DadosDocumentoSaída";
            this.Size = new System.Drawing.Size(752, 326);
            this.Controls.SetChildIndex(this.lblSubTotal, 0);
            this.Controls.SetChildIndex(this.txtSubtotal, 0);
            this.Controls.SetChildIndex(this.lblDesconto, 0);
            this.Controls.SetChildIndex(this.txtDesconto, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtValor, 0);
            this.Controls.SetChildIndex(this.txtNúmero, 0);
            this.Controls.SetChildIndex(this.dtEmissão, 0);
            this.Controls.SetChildIndex(this.txtEmitente, 0);
            this.Controls.SetChildIndex(this.lblEntradaSaída, 0);
            this.Controls.SetChildIndex(this.lblTipoDocumento, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.dtEntradaSaída, 0);
            this.Controls.SetChildIndex(this.cmbTipoDocumento, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbSetor, 0);
            this.Controls.SetChildIndex(this.chkCancelada, 0);
            this.Controls.SetChildIndex(this.cmbMáquina, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCancelada;
        private ComboSetor cmbSetor;
        private System.Windows.Forms.Label label13;
        private Combo.ComboMáquina cmbMáquina;
        private System.Windows.Forms.Label label4;
        private Pessoa.TextBoxCNPJ txtCnpjEmissor;
        private Pessoa.TextBoxCPF txtCpfEmissor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
    }
}
