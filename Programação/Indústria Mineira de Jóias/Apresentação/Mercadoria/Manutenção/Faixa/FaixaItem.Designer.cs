﻿namespace Apresentação.Mercadoria.Manutenção.Faixa
{
    partial class FaixaItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFaixa = new Apresentação.Mercadoria.CmbFaixa();
            this.txtFator = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Faixa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fator:";
            // 
            // cmbFaixa
            // 
            this.cmbFaixa.FormattingEnabled = true;
            this.cmbFaixa.Location = new System.Drawing.Point(0, 13);
            this.cmbFaixa.Name = "cmbFaixa";
            this.cmbFaixa.Size = new System.Drawing.Size(75, 21);
            this.cmbFaixa.TabIndex = 2;
            // 
            // txtFator
            // 
            this.txtFator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFator.Location = new System.Drawing.Point(81, 13);
            this.txtFator.Name = "txtFator";
            this.txtFator.Size = new System.Drawing.Size(65, 20);
            this.txtFator.TabIndex = 3;
            // 
            // FaixaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFator);
            this.Controls.Add(this.cmbFaixa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FaixaItem";
            this.Size = new System.Drawing.Size(152, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CmbFaixa cmbFaixa;
        private System.Windows.Forms.TextBox txtFator;
    }
}
