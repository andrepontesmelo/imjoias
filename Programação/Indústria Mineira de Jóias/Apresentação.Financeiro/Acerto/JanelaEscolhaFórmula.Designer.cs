namespace Apresentação.Financeiro.Acerto
{
    partial class JanelaEscolhaFórmula
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.opçãoIgualVenda = new System.Windows.Forms.RadioButton();
            this.opçãoPadrão = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(123, 20);
            this.lblTítulo.Text = "Coluna Acerto";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(220, 48);
            this.lblDescrição.Text = "A coluna \'acerto\', pode ser calculado de duas fórmas. ";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Financeiro.Properties.Resources.propriedades;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(219, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(138, 223);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.opçãoIgualVenda);
            this.groupBox1.Controls.Add(this.opçãoPadrão);
            this.groupBox1.Location = new System.Drawing.Point(3, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 129);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fórmula";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Geralmente utiliza-se o acerto igual a venda na fase final de acerto de auto-atac" +
                "ado. Leia o manual de acerto de auto-atacado para mais informações.";
            // 
            // opçãoIgualVenda
            // 
            this.opçãoIgualVenda.AutoSize = true;
            this.opçãoIgualVenda.Location = new System.Drawing.Point(23, 52);
            this.opçãoIgualVenda.Name = "opçãoIgualVenda";
            this.opçãoIgualVenda.Size = new System.Drawing.Size(160, 17);
            this.opçãoIgualVenda.TabIndex = 1;
            this.opçãoIgualVenda.Text = "Acerto = Venda - Devolução";
            this.opçãoIgualVenda.UseVisualStyleBackColor = true;
            // 
            // opçãoPadrão
            // 
            this.opçãoPadrão.AutoSize = true;
            this.opçãoPadrão.Checked = true;
            this.opçãoPadrão.Location = new System.Drawing.Point(23, 29);
            this.opçãoPadrão.Name = "opçãoPadrão";
            this.opçãoPadrão.Size = new System.Drawing.Size(184, 17);
            this.opçãoPadrão.TabIndex = 0;
            this.opçãoPadrão.TabStop = true;
            this.opçãoPadrão.Text = "Acerto = Saída - Retorno - Venda";
            this.opçãoPadrão.UseVisualStyleBackColor = true;
            // 
            // JanelaEscolhaFórmula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 258);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Name = "JanelaEscolhaFórmula";
            this.Text = "Escolha da fórmula";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton opçãoIgualVenda;
        private System.Windows.Forms.RadioButton opçãoPadrão;
        private System.Windows.Forms.Label label1;
    }
}
