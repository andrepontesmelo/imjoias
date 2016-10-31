namespace Apresentação.Fiscal.Lista
{
    partial class ListaItem
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
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCFOP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipoUnidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorUnitário = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusReferências = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusItens = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPeso = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência,
            this.colDescrição,
            this.colCFOP,
            this.colTipoUnidade,
            this.colQuantidade,
            this.colValorUnitário,
            this.colValorTotal});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(929, 320);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 102;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 236;
            // 
            // colCFOP
            // 
            this.colCFOP.Text = "CFOP";
            // 
            // colTipoUnidade
            // 
            this.colTipoUnidade.Text = "Tipo de Unidade";
            this.colTipoUnidade.Width = 100;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Text = "Quantidade";
            this.colQuantidade.Width = 96;
            // 
            // colValorUnitário
            // 
            this.colValorUnitário.Text = "Valor Unitário";
            this.colValorUnitário.Width = 113;
            // 
            // colValorTotal
            // 
            this.colValorTotal.Text = "Valor Total";
            this.colValorTotal.Width = 99;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusReferências,
            this.statusItens,
            this.statusPeso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(929, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusReferências
            // 
            this.statusReferências.Name = "statusReferências";
            this.statusReferências.Size = new System.Drawing.Size(88, 17);
            this.statusReferências.Text = "150 Referências";
            // 
            // statusItens
            // 
            this.statusItens.Name = "statusItens";
            this.statusItens.Size = new System.Drawing.Size(59, 17);
            this.statusItens.Text = "1421 itens";
            // 
            // statusPeso
            // 
            this.statusPeso.Name = "statusPeso";
            this.statusPeso.Size = new System.Drawing.Size(41, 17);
            this.statusPeso.Text = "26,31g";
            // 
            // ListaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lista);
            this.Name = "ListaItem";
            this.Size = new System.Drawing.Size(929, 320);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusReferências;
        private System.Windows.Forms.ToolStripStatusLabel statusItens;
        private System.Windows.Forms.ToolStripStatusLabel statusPeso;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colCFOP;
        private System.Windows.Forms.ColumnHeader colTipoUnidade;
        private System.Windows.Forms.ColumnHeader colQuantidade;
        private System.Windows.Forms.ColumnHeader colValorUnitário;
        private System.Windows.Forms.ColumnHeader colValorTotal;
    }
}
