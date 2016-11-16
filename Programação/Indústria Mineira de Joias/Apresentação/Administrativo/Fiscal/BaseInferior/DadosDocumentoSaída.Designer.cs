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
            this.txtCliente = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.label7 = new System.Windows.Forms.Label();
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
            this.dtEntradaSaída.Location = new System.Drawing.Point(61, 55);
            this.dtEntradaSaída.Validated += new System.EventHandler(this.dtEntradaSaída_Validated);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(61, 3);
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Location = new System.Drawing.Point(401, 6);
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Location = new System.Drawing.Point(7, 61);
            this.lblEntradaSaída.Size = new System.Drawing.Size(39, 13);
            this.lblEntradaSaída.Text = "Saída:";
            // 
            // txtEmitente
            // 
            this.txtEmitente.Location = new System.Drawing.Point(61, 132);
            // 
            // dtEmissão
            // 
            this.dtEmissão.Location = new System.Drawing.Point(61, 29);
            // 
            // txtNúmero
            // 
            this.txtNúmero.Location = new System.Drawing.Point(61, 106);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(61, 80);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 136);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 113);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 87);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 35);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 6);
            // 
            // chkCancelada
            // 
            this.chkCancelada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkCancelada.AutoSize = true;
            this.chkCancelada.Location = new System.Drawing.Point(61, 179);
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
            // txtCliente
            // 
            this.txtCliente.AlturaProposta = 60;
            this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCliente.Location = new System.Drawing.Point(61, 158);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Pessoa = null;
            this.txtCliente.Size = new System.Drawing.Size(326, 20);
            this.txtCliente.TabIndex = 31;
            this.txtCliente.Selecionado += new System.EventHandler(this.txtCliente_Selecionado);
            this.txtCliente.Deselecionado += new System.EventHandler(this.txtCliente_Deselecionado);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Cliente:";
            // 
            // DadosDocumentoSaída
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMáquina);
            this.Controls.Add(this.chkCancelada);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.label13);
            this.Name = "DadosDocumentoSaída";
            this.Size = new System.Drawing.Size(752, 202);
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
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCancelada;
        private ComboSetor cmbSetor;
        private System.Windows.Forms.Label label13;
        private Combo.ComboMáquina cmbMáquina;
        private System.Windows.Forms.Label label4;
        private Pessoa.Consultas.TextBoxPessoa txtCliente;
        private System.Windows.Forms.Label label7;
    }
}
