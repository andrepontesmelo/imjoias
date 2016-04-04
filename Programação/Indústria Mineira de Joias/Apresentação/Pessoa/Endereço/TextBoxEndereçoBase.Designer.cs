namespace Apresentação.Pessoa.Endereço
{
    partial class TextBoxEndereçoBase
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
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.WorkerSupportsCancellation = true;
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRecuperação_DoWork);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgRecuperação_RunWorkerCompleted);
            // 
            // TextBoxLocalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "TextBoxLocalidade";
            this.Enter += new System.EventHandler(this.TextBoxLocalidade_Enter);
            this.Leave += new System.EventHandler(this.TextBox_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.ComponentModel.BackgroundWorker bgRecuperação;
    }
}
