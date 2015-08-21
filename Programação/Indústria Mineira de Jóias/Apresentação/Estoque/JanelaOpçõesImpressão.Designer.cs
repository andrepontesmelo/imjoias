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
            this.chkPeso = new System.Windows.Forms.CheckBox();
            this.chkReferência = new System.Windows.Forms.CheckBox();
            this.comboBoxFornecedor = new Apresentação.Fornecedor.ComboboxFornecedor();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFiltrarFornecedor = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkPesoMédio = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.btnOk.Location = new System.Drawing.Point(143, 296);
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
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(224, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkPeso);
            this.groupBox1.Controls.Add(this.chkReferência);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 68);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Mercadoria";
            // 
            // chkPeso
            // 
            this.chkPeso.AutoSize = true;
            this.chkPeso.Checked = true;
            this.chkPeso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPeso.Location = new System.Drawing.Point(65, 42);
            this.chkPeso.Name = "chkPeso";
            this.chkPeso.Size = new System.Drawing.Size(126, 17);
            this.chkPeso.TabIndex = 1;
            this.chkPeso.Text = "Mercadorias de Peso";
            this.chkPeso.UseVisualStyleBackColor = true;
            // 
            // chkReferência
            // 
            this.chkReferência.AutoSize = true;
            this.chkReferência.Checked = true;
            this.chkReferência.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReferência.Location = new System.Drawing.Point(65, 19);
            this.chkReferência.Name = "chkReferência";
            this.chkReferência.Size = new System.Drawing.Size(154, 17);
            this.chkReferência.TabIndex = 0;
            this.chkReferência.Text = "Mercadorias de Referência";
            this.chkReferência.UseVisualStyleBackColor = true;
            // 
            // comboBoxFornecedor
            // 
            this.comboBoxFornecedor.Enabled = false;
            this.comboBoxFornecedor.Location = new System.Drawing.Point(65, 41);
            this.comboBoxFornecedor.Name = "comboBoxFornecedor";
            this.comboBoxFornecedor.Size = new System.Drawing.Size(216, 21);
            this.comboBoxFornecedor.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkFiltrarFornecedor);
            this.groupBox2.Controls.Add(this.comboBoxFornecedor);
            this.groupBox2.Location = new System.Drawing.Point(12, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 68);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fornecedor";
            // 
            // chkFiltrarFornecedor
            // 
            this.chkFiltrarFornecedor.AutoSize = true;
            this.chkFiltrarFornecedor.Location = new System.Drawing.Point(66, 18);
            this.chkFiltrarFornecedor.Name = "chkFiltrarFornecedor";
            this.chkFiltrarFornecedor.Size = new System.Drawing.Size(108, 17);
            this.chkFiltrarFornecedor.TabIndex = 3;
            this.chkFiltrarFornecedor.Text = "Filtrar Fornecedor";
            this.chkFiltrarFornecedor.UseVisualStyleBackColor = true;
            this.chkFiltrarFornecedor.CheckedChanged += new System.EventHandler(this.chkFiltrarFornecedor_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkPesoMédio);
            this.groupBox3.Location = new System.Drawing.Point(12, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 46);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Peso";
            // 
            // chkPesoMédio
            // 
            this.chkPesoMédio.AutoSize = true;
            this.chkPesoMédio.Location = new System.Drawing.Point(66, 18);
            this.chkPesoMédio.Name = "chkPesoMédio";
            this.chkPesoMédio.Size = new System.Drawing.Size(105, 17);
            this.chkPesoMédio.TabIndex = 3;
            this.chkPesoMédio.Text = "Usar peso médio";
            this.chkPesoMédio.UseVisualStyleBackColor = true;
            // 
            // JanelaOpçõesImpressão
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(311, 331);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Name = "JanelaOpçõesImpressão";
            this.Text = "Opções de Impressão";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPeso;
        private System.Windows.Forms.CheckBox chkReferência;
        
        private Apresentação.Fornecedor.ComboboxFornecedor comboBoxFornecedor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFiltrarFornecedor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkPesoMédio;
    }
}