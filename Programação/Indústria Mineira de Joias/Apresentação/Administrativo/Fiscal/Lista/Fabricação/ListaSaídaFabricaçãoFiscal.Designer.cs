namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    partial class ListaSaídaFabricaçãoFiscal
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
            this.colEstoqueAnterior = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApuração = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEstoqueAnterior,
            this.colApuração});
            this.lista.Size = new System.Drawing.Size(1097, 471);
            // 
            // colEstoqueAnterior
            // 
            this.colEstoqueAnterior.Text = "Estoque";
            // 
            // colApuração
            // 
            this.colApuração.Text = "Apuração";
            // 
            // ListaSaídaFabricaçãoFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ListaSaídaFabricaçãoFiscal";
            this.Size = new System.Drawing.Size(1097, 471);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colEstoqueAnterior;
        private System.Windows.Forms.ColumnHeader colApuração;
    }
}
