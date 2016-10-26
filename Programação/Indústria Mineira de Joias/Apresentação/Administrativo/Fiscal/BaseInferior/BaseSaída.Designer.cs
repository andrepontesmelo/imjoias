namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseSaída
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
            this.grpDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Descrição = "Edição de uma saída fiscal";
            this.título.Título = "Editar saída fiscal";
            // 
            // grpDados
            // 
            this.grpDados.Text = "Dados da saída";
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Size = new System.Drawing.Size(39, 13);
            this.lblEntradaSaída.Text = "Saída:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Size = new System.Drawing.Size(76, 13);
            this.lblTipoDocumento.Text = "Tipo de saída:";
            // 
            // BaseSaída
            // 
            this.Name = "BaseSaída";
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
