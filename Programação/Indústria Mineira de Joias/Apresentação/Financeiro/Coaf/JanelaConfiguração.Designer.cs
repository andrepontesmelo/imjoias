﻿namespace Apresentação.Financeiro.Coaf
{
    partial class JanelaConfiguração
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currencyTextBox2 = new AMS.TextBox.CurrencyTextBox();
            this.currencyTextBox1 = new AMS.TextBox.CurrencyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grupoPeríodo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMeses = new System.Windows.Forms.NumericUpDown();
            this.btnRestaurarPadrão = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grupoPeríodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMeses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(116, 20);
            this.lblTítulo.Text = "Configuração";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(155, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.Logo_COAF;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.currencyTextBox2);
            this.groupBox1.Controls.Add(this.currencyTextBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limites mínimos";
            // 
            // currencyTextBox2
            // 
            this.currencyTextBox2.AllowNegative = true;
            this.currencyTextBox2.Flags = 7680;
            this.currencyTextBox2.Location = new System.Drawing.Point(56, 48);
            this.currencyTextBox2.MaxWholeDigits = 9;
            this.currencyTextBox2.Name = "currencyTextBox2";
            this.currencyTextBox2.RangeMax = 1.7976931348623157E+308D;
            this.currencyTextBox2.RangeMin = -1.7976931348623157E+308D;
            this.currencyTextBox2.Size = new System.Drawing.Size(143, 20);
            this.currencyTextBox2.TabIndex = 8;
            this.currencyTextBox2.Text = "R$ 30.000,00";
            // 
            // currencyTextBox1
            // 
            this.currencyTextBox1.AllowNegative = true;
            this.currencyTextBox1.Flags = 7680;
            this.currencyTextBox1.Location = new System.Drawing.Point(56, 25);
            this.currencyTextBox1.MaxWholeDigits = 9;
            this.currencyTextBox1.Name = "currencyTextBox1";
            this.currencyTextBox1.RangeMax = 1.7976931348623157E+308D;
            this.currencyTextBox1.RangeMin = -1.7976931348623157E+308D;
            this.currencyTextBox1.Size = new System.Drawing.Size(143, 20);
            this.currencyTextBox1.TabIndex = 7;
            this.currencyTextBox1.Text = "R$ 10.000,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Demais:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PPE:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(154, 297);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(73, 297);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grupoPeríodo
            // 
            this.grupoPeríodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grupoPeríodo.Controls.Add(this.label3);
            this.grupoPeríodo.Controls.Add(this.txtMeses);
            this.grupoPeríodo.Location = new System.Drawing.Point(12, 184);
            this.grupoPeríodo.Name = "grupoPeríodo";
            this.grupoPeríodo.Size = new System.Drawing.Size(217, 71);
            this.grupoPeríodo.TabIndex = 9;
            this.grupoPeríodo.TabStop = false;
            this.grupoPeríodo.Text = "Período: Últimos 6 meses";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Meses:";
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(56, 23);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(141, 20);
            this.txtMeses.TabIndex = 0;
            this.txtMeses.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.txtMeses.ValueChanged += new System.EventHandler(this.txtMeses_ValueChanged);
            // 
            // btnRestaurarPadrão
            // 
            this.btnRestaurarPadrão.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurarPadrão.Image = global::Apresentação.Resource.Edit_UndoHS;
            this.btnRestaurarPadrão.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRestaurarPadrão.Location = new System.Drawing.Point(73, 268);
            this.btnRestaurarPadrão.Name = "btnRestaurarPadrão";
            this.btnRestaurarPadrão.Size = new System.Drawing.Size(156, 23);
            this.btnRestaurarPadrão.TabIndex = 10;
            this.btnRestaurarPadrão.Text = "Restaurar Padrão";
            this.btnRestaurarPadrão.UseVisualStyleBackColor = true;
            // 
            // JanelaConfiguração
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 332);
            this.Controls.Add(this.btnRestaurarPadrão);
            this.Controls.Add(this.grupoPeríodo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "JanelaConfiguração";
            this.Text = "Configuração";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.grupoPeríodo, 0);
            this.Controls.SetChildIndex(this.btnRestaurarPadrão, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grupoPeríodo.ResumeLayout(false);
            this.grupoPeríodo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMeses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AMS.TextBox.CurrencyTextBox currencyTextBox2;
        private AMS.TextBox.CurrencyTextBox currencyTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grupoPeríodo;
        private System.Windows.Forms.Button btnRestaurarPadrão;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtMeses;
    }
}