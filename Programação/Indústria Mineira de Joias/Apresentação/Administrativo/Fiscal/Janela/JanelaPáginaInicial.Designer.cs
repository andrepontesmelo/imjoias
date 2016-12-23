namespace Apresentação.Administrativo.Fiscal.Janela
{
    partial class JanelaPáginaInicial
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
            this.txtPrimeiraFolha = new AMS.TextBox.NumericTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(170, 20);
            this.lblTítulo.Text = "Numeração da folha";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(204, 32);
            this.lblDescrição.Text = "Entre com o número da primeira folha.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.repair;
            // 
            // txtPrimeiraFolha
            // 
            this.txtPrimeiraFolha.AllowNegative = true;
            this.txtPrimeiraFolha.DigitsInGroup = 0;
            this.txtPrimeiraFolha.Flags = 0;
            this.txtPrimeiraFolha.Location = new System.Drawing.Point(103, 136);
            this.txtPrimeiraFolha.MaxDecimalPlaces = 4;
            this.txtPrimeiraFolha.MaxWholeDigits = 9;
            this.txtPrimeiraFolha.Name = "txtPrimeiraFolha";
            this.txtPrimeiraFolha.Prefix = "";
            this.txtPrimeiraFolha.RangeMax = 1.7976931348623157E+308D;
            this.txtPrimeiraFolha.RangeMin = -1.7976931348623157E+308D;
            this.txtPrimeiraFolha.Size = new System.Drawing.Size(68, 20);
            this.txtPrimeiraFolha.TabIndex = 3;
            this.txtPrimeiraFolha.Text = "1";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(203, 182);
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
            this.label1.Location = new System.Drawing.Point(100, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Folha";
            // 
            // JanelaPáginaInicial
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 217);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPrimeiraFolha);
            this.Name = "JanelaPáginaInicial";
            this.Text = "Numeração";
            this.Controls.SetChildIndex(this.txtPrimeiraFolha, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.TextBox.NumericTextBox txtPrimeiraFolha;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
    }
}