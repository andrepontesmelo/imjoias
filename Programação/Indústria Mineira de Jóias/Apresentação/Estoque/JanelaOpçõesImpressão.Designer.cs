namespace Apresentação.Estoque
{
    partial class JanelaOpçõesImpressão
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkReferência = new System.Windows.Forms.CheckBox();
            this.chkPeso = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(182, 20);
            this.lblTítulo.Text = "Opções de impressão";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(223, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.impressora__altura_58_;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(143, 215);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(224, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPeso);
            this.groupBox1.Controls.Add(this.chkReferência);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 113);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incluir";
            // 
            // chkReferência
            // 
            this.chkReferência.AutoSize = true;
            this.chkReferência.Checked = true;
            this.chkReferência.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReferência.Location = new System.Drawing.Point(65, 39);
            this.chkReferência.Name = "chkReferência";
            this.chkReferência.Size = new System.Drawing.Size(154, 17);
            this.chkReferência.TabIndex = 0;
            this.chkReferência.Text = "Mercadorias de Referência";
            this.chkReferência.UseVisualStyleBackColor = true;
            // 
            // chkPeso
            // 
            this.chkPeso.AutoSize = true;
            this.chkPeso.Checked = true;
            this.chkPeso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPeso.Location = new System.Drawing.Point(65, 62);
            this.chkPeso.Name = "chkPeso";
            this.chkPeso.Size = new System.Drawing.Size(126, 17);
            this.chkPeso.TabIndex = 1;
            this.chkPeso.Text = "Mercadorias de Peso";
            this.chkPeso.UseVisualStyleBackColor = true;
            // 
            // JanelaOpçõesImpressão
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(311, 250);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Name = "JanelaOpçõesImpressão";
            this.Text = "Opções de Impressão";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPeso;
        private System.Windows.Forms.CheckBox chkReferência;
    }
}