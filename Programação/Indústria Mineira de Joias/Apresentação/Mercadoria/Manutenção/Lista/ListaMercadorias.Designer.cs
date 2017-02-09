using Apresentação.Formulários;

namespace Apresentação.Mercadoria.Manutenção.Lista
{
    partial class ListaMercadorias
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "101.001.01.121-4",
            "1.41",
            "Não",
            "74",
            "R$ 432,05",
            "Meia aliança de ouro com 0.21k de brilhantes"}, -1);
            this.lista = new Apresentação.Formulários.ListViewUsabilidade();
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPeso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDePeso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPreçoCusto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência,
            this.colPeso,
            this.colDePeso,
            this.colFornecedor,
            this.colPreçoCusto,
            this.colDescrição});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(756, 277);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 117;
            // 
            // colPeso
            // 
            this.colPeso.Text = "Peso";
            // 
            // colDePeso
            // 
            this.colDePeso.Text = "De Peso";
            // 
            // colFornecedor
            // 
            this.colFornecedor.Text = "Fornecedor";
            this.colFornecedor.Width = 96;
            // 
            // colPreçoCusto
            // 
            this.colPreçoCusto.Text = "Preço de custo";
            this.colPreçoCusto.Width = 122;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 262;
            // 
            // ListaMercadorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lista);
            this.Name = "ListaMercadorias";
            this.Size = new System.Drawing.Size(756, 277);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewUsabilidade lista;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colPeso;
        private System.Windows.Forms.ColumnHeader colDePeso;
        private System.Windows.Forms.ColumnHeader colFornecedor;
        private System.Windows.Forms.ColumnHeader colPreçoCusto;
        private System.Windows.Forms.ColumnHeader colDescrição;
    }
}
