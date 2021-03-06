﻿namespace Apresentação.Administrativo.Fiscal.BaseInferior
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
            this.txtVenda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            // txtVenda
            // 
            this.txtVenda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtVenda.Location = new System.Drawing.Point(509, 80);
            this.txtVenda.Name = "txtVenda";
            this.txtVenda.Size = new System.Drawing.Size(231, 20);
            this.txtVenda.TabIndex = 36;
            this.txtVenda.Validating += new System.ComponentModel.CancelEventHandler(this.txtVenda_Validating);
            this.txtVenda.Validated += new System.EventHandler(this.txtVenda_Validated);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(401, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Venda:";
            // 
            // DadosDocumentoSaída
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVenda);
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
            this.Controls.SetChildIndex(this.txtVenda, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCancelada;
        private ComboSetor cmbSetor;
        private System.Windows.Forms.Label label13;
        private Combo.ComboMáquina cmbMáquina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVenda;
        private System.Windows.Forms.Label label9;
    }
}
