namespace Apresentação.Pessoa
{
    partial class TextBoxCPF
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
            this.txtCPF = new AMS.TextBox.MultiMaskedTextBox();
            this.SuspendLayout();
            // 
            // txtCPF
            // 
            this.txtCPF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCPF.Flags = 0;
            this.txtCPF.Location = new System.Drawing.Point(0, 0);
            this.txtCPF.Mask = "###.###.###-##";
            this.txtCPF.MaxLength = 14;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(150, 20);
            this.txtCPF.TabIndex = 4;
            this.txtCPF.Resize += new System.EventHandler(this.txtCPF_Resize);
            this.txtCPF.Validating += new System.ComponentModel.CancelEventHandler(this.txtCPF_Validating);
            this.txtCPF.TextChanged += new System.EventHandler(this.txtCPF_TextChanged);
            // 
            // TextBoxCPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCPF);
            this.Name = "TextBoxCPF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.TextBox.MultiMaskedTextBox txtCPF;
    }
}
