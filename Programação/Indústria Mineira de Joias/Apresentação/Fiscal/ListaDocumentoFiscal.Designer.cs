namespace Apresentação.Fiscal
{
    partial class ListaDocumentoFiscal
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
            this.lista = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmissão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCancelada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObservações = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colEmissão,
            this.colCancelada,
            this.colValor,
            this.colObservações});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(927, 399);
            this.lista.TabIndex = 1;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            // 
            // colId
            // 
            this.colId.Text = "Id";
            this.colId.Width = 192;
            // 
            // colEmissão
            // 
            this.colEmissão.DisplayIndex = 3;
            this.colEmissão.Text = "Emissão";
            this.colEmissão.Width = 120;
            // 
            // colCancelada
            // 
            this.colCancelada.Text = "Cancelada";
            this.colCancelada.Width = 85;
            // 
            // colValor
            // 
            this.colValor.DisplayIndex = 1;
            this.colValor.Text = "Valor";
            // 
            // colObservações
            // 
            this.colObservações.Text = "Observações";
            this.colObservações.Width = 500;
            // 
            // ListaDocumentoFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lista);
            this.Name = "ListaDocumentoFiscal";
            this.Size = new System.Drawing.Size(927, 399);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colCancelada;
        private System.Windows.Forms.ColumnHeader colEmissão;
        private System.Windows.Forms.ColumnHeader colObservações;
    }
}
