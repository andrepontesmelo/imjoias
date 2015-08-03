namespace Apresentação.Financeiro.Comissões
{
    partial class ListViewComissionados
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Varejo", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Atacado", System.Windows.Forms.HorizontalAlignment.Left);
            this.lst = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComissãoFechada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEstorno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAReceber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colValor,
            this.colComissãoFechada,
            this.colEstorno,
            this.colAReceber});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            this.lst.GridLines = true;
            listViewGroup1.Header = "Varejo";
            listViewGroup1.Name = "Varejo";
            listViewGroup2.Header = "Atacado";
            listViewGroup2.Name = "Atacado";
            this.lst.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lst.HoverSelection = true;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(464, 241);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            // 
            // colNome
            // 
            this.colNome.Text = "Comissão Para";
            this.colNome.Width = 97;
            // 
            // colValor
            // 
            this.colValor.Text = "Aberto";
            this.colValor.Width = 115;
            // 
            // colComissãoFechada
            // 
            this.colComissãoFechada.Text = "Fechado";
            this.colComissãoFechada.Width = 115;
            // 
            // colEstorno
            // 
            this.colEstorno.Text = "Estorno";
            this.colEstorno.Width = 83;
            // 
            // colAReceber
            // 
            this.colAReceber.Text = "Pagamento";
            this.colAReceber.Width = 96;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // ListViewComissionados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst);
            this.Name = "ListViewComissionados";
            this.Size = new System.Drawing.Size(464, 241);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ColumnHeader colComissãoFechada;
        private System.Windows.Forms.ColumnHeader colEstorno;
        private System.Windows.Forms.ColumnHeader colAReceber;
    }
}
