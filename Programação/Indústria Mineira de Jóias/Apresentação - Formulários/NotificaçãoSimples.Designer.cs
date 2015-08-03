namespace Apresentação.Formulários
{
    partial class NotificaçãoSimples
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
            this.lblDescrição = new System.Windows.Forms.Label();
            this.quadro.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadro
            // 
            this.quadro.Controls.Add(this.lblDescrição);
            this.quadro.Controls.SetChildIndex(this.lblDescrição, 0);
            // 
            // lblDescrição
            // 
            this.lblDescrição.Location = new System.Drawing.Point(12, 36);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(267, 75);
            this.lblDescrição.TabIndex = 2;
            // 
            // NotificaçãoSimples
            // 
            this.ClientSize = new System.Drawing.Size(288, 120);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NotificaçãoSimples";
            this.quadro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescrição;
    }
}
