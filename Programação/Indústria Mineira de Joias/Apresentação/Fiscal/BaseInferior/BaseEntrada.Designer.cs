namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseEntrada
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
            Entidades.Fiscal.Tipo.TipoDocumento tipoDocumento1 = new Entidades.Fiscal.Tipo.TipoDocumento();
            this.grpDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // título
            // 
            this.título.Descrição = "Edição de uma entrada fiscal";
            this.título.Título = "Editar entrada fiscal";
            // 
            // grpDados
            // 
            this.grpDados.Text = "Dados da entrada";
            // 
            // lblEntradaSaída
            // 
            this.lblEntradaSaída.Size = new System.Drawing.Size(47, 13);
            this.lblEntradaSaída.Text = "Entrada:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Size = new System.Drawing.Size(85, 13);
            this.lblTipoDocumento.Text = "Tipo de entrada:";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Seleção = tipoDocumento1;
            // 
            // BaseEntrada
            // 
            this.Name = "BaseEntrada";
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
