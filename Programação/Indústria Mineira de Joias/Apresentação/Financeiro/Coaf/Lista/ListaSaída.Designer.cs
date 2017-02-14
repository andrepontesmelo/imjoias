namespace Apresentação.Financeiro.Coaf.Lista
{
    partial class ListaSaída
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
            this.colSaída = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataSaída = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNotificação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStripTotalSeleção = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripTotalSeleção.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSaída,
            this.colDataSaída,
            this.colTotal,
            this.colVenda,
            this.colNotificação});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(716, 283);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colSaída
            // 
            this.colSaída.Text = "Saída ID";
            this.colSaída.Width = 246;
            // 
            // colDataSaída
            // 
            this.colDataSaída.Text = "Data";
            this.colDataSaída.Width = 122;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total";
            this.colTotal.Width = 104;
            // 
            // colVenda
            // 
            this.colVenda.Text = "Cód. Venda";
            this.colVenda.Width = 94;
            // 
            // colNotificação
            // 
            this.colNotificação.Text = "Notificação";
            this.colNotificação.Width = 115;
            // 
            // statusStripTotalSeleção
            // 
            this.statusStripTotalSeleção.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusTotal});
            this.statusStripTotalSeleção.Location = new System.Drawing.Point(0, 261);
            this.statusStripTotalSeleção.Name = "statusStripTotalSeleção";
            this.statusStripTotalSeleção.Size = new System.Drawing.Size(716, 22);
            this.statusStripTotalSeleção.TabIndex = 1;
            this.statusStripTotalSeleção.Text = "Total da seleção: R$ 0,00";
            // 
            // toolStripStatusTotal
            // 
            this.toolStripStatusTotal.Name = "toolStripStatusTotal";
            this.toolStripStatusTotal.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusTotal.Text = "Total: R$ 100,00";
            // 
            // ListaSaída
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStripTotalSeleção);
            this.Controls.Add(this.lista);
            this.Name = "ListaSaída";
            this.Size = new System.Drawing.Size(716, 283);
            this.statusStripTotalSeleção.ResumeLayout(false);
            this.statusStripTotalSeleção.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colSaída;
        private System.Windows.Forms.ColumnHeader colDataSaída;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.ColumnHeader colVenda;
        private System.Windows.Forms.ColumnHeader colNotificação;
        private System.Windows.Forms.StatusStrip statusStripTotalSeleção;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTotal;
    }
}
