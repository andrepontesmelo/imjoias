namespace Apresentação.Financeiro.Comissões
{
    partial class JanelaNovaComissão
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaNovaComissão));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.labelLayout1 = new Report.Layout.LabelLayout(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dataMês = new System.Windows.Forms.DateTimePicker();
            this.chkComissãoPaga = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(129, 20);
            this.lblTítulo.Text = "Nova comissão";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(176, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.document1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 110);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(27, 13);
            label1.TabIndex = 5;
            label1.Text = "Mês";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDescrição);
            this.groupBox1.Location = new System.Drawing.Point(12, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descrição";
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Location = new System.Drawing.Point(6, 19);
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(228, 57);
            this.txtDescrição.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(96, 248);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // labelLayout1
            // 
            this.labelLayout1.Document = null;
            this.labelLayout1.GapHorizontal = 0F;
            this.labelLayout1.GapVertical = 0F;
            this.labelLayout1.MarginBottom = 0F;
            this.labelLayout1.MarginLeft = 0F;
            this.labelLayout1.MarginRight = 0F;
            this.labelLayout1.MarginTop = 0F;
            this.labelLayout1.Objects = null;
            this.labelLayout1.PaperSize = ((System.Drawing.Printing.PaperSize)(resources.GetObject("labelLayout1.PaperSize")));
            this.labelLayout1.XmlFileName = null;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(177, 248);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dataMês
            // 
            this.dataMês.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataMês.CustomFormat = "MMMM/yyyy";
            this.dataMês.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataMês.Location = new System.Drawing.Point(50, 104);
            this.dataMês.Name = "dataMês";
            this.dataMês.Size = new System.Drawing.Size(194, 20);
            this.dataMês.TabIndex = 4;
            // 
            // chkComissãoPaga
            // 
            this.chkComissãoPaga.AutoSize = true;
            this.chkComissãoPaga.Location = new System.Drawing.Point(20, 137);
            this.chkComissãoPaga.Name = "chkComissãoPaga";
            this.chkComissãoPaga.Size = new System.Drawing.Size(98, 17);
            this.chkComissãoPaga.TabIndex = 6;
            this.chkComissãoPaga.Text = "Comissão paga";
            this.chkComissãoPaga.UseVisualStyleBackColor = true;
            // 
            // JanelaNovaComissão
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(264, 283);
            this.Controls.Add(this.chkComissãoPaga);
            this.Controls.Add(label1);
            this.Controls.Add(this.dataMês);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.KeyPreview = true;
            this.Name = "JanelaNovaComissão";
            this.Text = "Comissão";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.dataMês, 0);
            this.Controls.SetChildIndex(label1, 0);
            this.Controls.SetChildIndex(this.chkComissãoPaga, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private Report.Layout.LabelLayout labelLayout1;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.DateTimePicker dataMês;
        private System.Windows.Forms.CheckBox chkComissãoPaga;
    }
}