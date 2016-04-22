namespace Apresentação.Pessoa
{
    partial class TextBoxCNPJ
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
            this.txtCNPJ = new AMS.TextBox.MultiMaskedTextBox();
            this.SuspendLayout();
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCNPJ.Flags = 0;
            this.txtCNPJ.Location = new System.Drawing.Point(0, 0);
            this.txtCNPJ.Mask = "##.###.###/####-##";
            this.txtCNPJ.MaxLength = 14;
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(150, 20);
            this.txtCNPJ.TabIndex = 5;
            this.txtCNPJ.Resize += new System.EventHandler(this.txtCNPJ_Resize);
            this.txtCNPJ.Validating += new System.ComponentModel.CancelEventHandler(this.txtCNPJ_Validating);
            // 
            // TextBoxCNPJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCNPJ);
            this.Name = "TextBoxCNPJ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.TextBox.MultiMaskedTextBox txtCNPJ;
    }
}
