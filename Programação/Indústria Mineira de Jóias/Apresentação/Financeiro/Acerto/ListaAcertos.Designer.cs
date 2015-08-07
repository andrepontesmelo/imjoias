namespace Apresentação.Financeiro.Acerto
{
    partial class ListaAcertos
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Sem previsão", System.Windows.Forms.HorizontalAlignment.Left);
            this.lst = new System.Windows.Forms.ListView();
            this.colAcerto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPessoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMarcação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrevisão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAcerto,
            this.colPessoa,
            this.colMarcação,
            this.colPrevisão});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            listViewGroup1.Header = "Sem previsão";
            listViewGroup1.Name = "grpSemPrevisão";
            this.lst.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(355, 150);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lst_ColumnClick);
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.DoubleClick += new System.EventHandler(this.ListaAcertos_DoubleClick);
            // 
            // colAcerto
            // 
            this.colAcerto.Text = "Acerto";
            // 
            // colPessoa
            // 
            this.colPessoa.Text = "Pessoa";
            // 
            // colMarcação
            // 
            this.colMarcação.Text = "Marcado em";
            // 
            // colPrevisão
            // 
            this.colPrevisão.Text = "Previsão";
            // 
            // ListaAcertos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst);
            this.Name = "ListaAcertos";
            this.Size = new System.Drawing.Size(355, 150);
            this.DoubleClick += new System.EventHandler(this.ListaAcertos_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colAcerto;
        private System.Windows.Forms.ColumnHeader colPessoa;
        private System.Windows.Forms.ColumnHeader colMarcação;
        private System.Windows.Forms.ColumnHeader colPrevisão;
    }
}
