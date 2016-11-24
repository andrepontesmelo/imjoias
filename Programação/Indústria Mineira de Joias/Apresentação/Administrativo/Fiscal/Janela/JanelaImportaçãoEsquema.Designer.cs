namespace Apresentação.Administrativo.Fiscal.Janela
{
    partial class JanelaImportaçãoEsquema
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechamentoDestino = new System.Windows.Forms.TextBox();
            this.cmbFechamentoOrigem = new Apresentação.Administrativo.Fiscal.Combo.ComboFechamento();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(203, 20);
            this.lblTítulo.Text = "Importação de esquema";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(341, 34);
            this.lblDescrição.Text = "Substitui todas os esquemas do fechamento atual por esquemas de outro fechamento";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.Refazer;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(340, 248);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(259, 248);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Atual:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Copiar de:";
            // 
            // txtFechamentoDestino
            // 
            this.txtFechamentoDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechamentoDestino.Enabled = false;
            this.txtFechamentoDestino.Location = new System.Drawing.Point(78, 131);
            this.txtFechamentoDestino.Name = "txtFechamentoDestino";
            this.txtFechamentoDestino.Size = new System.Drawing.Size(337, 20);
            this.txtFechamentoDestino.TabIndex = 7;
            // 
            // cmbFechamentoOrigem
            // 
            this.cmbFechamentoOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFechamentoOrigem.Location = new System.Drawing.Point(77, 157);
            this.cmbFechamentoOrigem.Name = "cmbFechamentoOrigem";
            this.cmbFechamentoOrigem.Size = new System.Drawing.Size(338, 22);
            this.cmbFechamentoOrigem.TabIndex = 8;
            this.cmbFechamentoOrigem.SelectedIndexChanged += new System.EventHandler(this.cmbFechamentoOrigem_SelectedIndexChanged);
            // 
            // JanelaImportaçãoEsquema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 283);
            this.Controls.Add(this.cmbFechamentoOrigem);
            this.Controls.Add(this.txtFechamentoDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Name = "JanelaImportaçãoEsquema";
            this.Text = "Importação de esquema";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtFechamentoDestino, 0);
            this.Controls.SetChildIndex(this.cmbFechamentoOrigem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFechamentoDestino;
        private Combo.ComboFechamento cmbFechamentoOrigem;
    }
}