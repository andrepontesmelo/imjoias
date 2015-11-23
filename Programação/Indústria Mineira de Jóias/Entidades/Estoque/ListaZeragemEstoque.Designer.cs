namespace Entidades.Estoque
{
    partial class ListaZeragemEstoque
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncionário = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObservação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.colComissãoVigente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colData,
            this.colFuncionário,
            this.colComissãoVigente,
            this.colObservação});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(794, 150);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 268;
            // 
            // colFuncionário
            // 
            this.colFuncionário.Text = "Funcionário";
            this.colFuncionário.Width = 175;
            // 
            // colObservação
            // 
            this.colObservação.DisplayIndex = 2;
            this.colObservação.Text = "Observação";
            this.colObservação.Width = 586;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // colComissãoVigente
            // 
            this.colComissãoVigente.DisplayIndex = 3;
            this.colComissãoVigente.Text = "Comissão Vigente";
            // 
            // ListaZeragemEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "ListaZeragemEstoque";
            this.Size = new System.Drawing.Size(794, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colFuncionário;
        private System.Windows.Forms.ColumnHeader colObservação;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ColumnHeader colComissãoVigente;
    }
}
