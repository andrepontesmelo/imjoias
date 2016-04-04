namespace Apresentação.Pessoa
{
    partial class FormatadorNome
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
            this.bgFormatação = new System.ComponentModel.BackgroundWorker();
            // 
            // bgFormatação
            // 
            this.bgFormatação.WorkerSupportsCancellation = true;
            this.bgFormatação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FormatarConteúdo);
            this.bgFormatação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AoFormatarAssincronamente);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgFormatação;
    }
}
