namespace Apresentação.Fiscal.Lista
{
    partial class ListaDocumentoSaída
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
            this.colCancelada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMáquina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFabricação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFabricação,
            this.colMáquina,
            this.colCancelada});
            // 
            // colCancelada
            // 
            this.colCancelada.Text = "Cancelada";
            // 
            // colMáquina
            // 
            this.colMáquina.Text = "Máquina";
            // 
            // colFabricação
            // 
            this.colFabricação.Text = "Fabricação";
            this.colFabricação.Width = 91;
            // 
            // ListaDocumentoSaída
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ListaDocumentoSaída";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colCancelada;
        private System.Windows.Forms.ColumnHeader colMáquina;
        private System.Windows.Forms.ColumnHeader colFabricação;
    }
}
