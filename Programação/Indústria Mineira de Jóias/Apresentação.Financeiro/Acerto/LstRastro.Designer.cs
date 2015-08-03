namespace Apresentação.Financeiro.Acerto
{
    partial class LstRastro
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("grupoSaída", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("grupoVenda", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("grupoRetorno", System.Windows.Forms.HorizontalAlignment.Left);
            this.lista = new System.Windows.Forms.ListView();
            this.colData = new System.Windows.Forms.ColumnHeader();
            this.colDocumento = new System.Windows.Forms.ColumnHeader();
            this.colQuantidade = new System.Windows.Forms.ColumnHeader();
            this.colDescrição = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colData,
            this.colDocumento,
            this.colQuantidade,
            this.colDescrição});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            listViewGroup1.Header = "grupoSaída";
            listViewGroup1.Name = "grupoSaída";
            listViewGroup2.Header = "grupoVenda";
            listViewGroup2.Name = "grupoVenda";
            listViewGroup3.Header = "grupoRetorno";
            listViewGroup3.Name = "grupoRetorno";
            this.lista.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.ShowGroups = false;
            this.lista.Size = new System.Drawing.Size(447, 304);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 177;
            // 
            // colDocumento
            // 
            this.colDocumento.Text = "Documento";
            this.colDocumento.Width = 173;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Text = "Quantidade";
            this.colQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQuantidade.Width = 75;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 2;
            // 
            // LstRastro
            // 
            this.Controls.Add(this.lista);
            this.Name = "LstRastro";
            this.Size = new System.Drawing.Size(447, 304);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colDocumento;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colQuantidade;
    }
}
