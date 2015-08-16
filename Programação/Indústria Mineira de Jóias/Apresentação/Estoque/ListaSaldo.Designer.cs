namespace Apresentação.Estoque
{
    partial class ListaSaldo
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Mercadorias de Peso", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Mercadorias de Referência", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaSaldo));
            this.lst = new System.Windows.Forms.ListView();
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPeso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEntrada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDevolução = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSaldo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRefFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.status = new System.Windows.Forms.StatusBar();
            this.panelReferencias = new System.Windows.Forms.StatusBarPanel();
            this.panelPesoTotal = new System.Windows.Forms.StatusBarPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPesquisa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnFiltrarFornecedor = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxFornecedor = new System.Windows.Forms.ToolStripComboBox();
            this.localizador = new Apresentação.Formulários.Localizador();
            ((System.ComponentModel.ISupportInitialize)(this.panelReferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPesoTotal)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência,
            this.colPeso,
            this.colEntrada,
            this.colVenda,
            this.colDevolução,
            this.colSaldo,
            this.colFornecedor,
            this.colRefFornecedor});
            this.lst.FullRowSelect = true;
            listViewGroup1.Header = "Mercadorias de Peso";
            listViewGroup1.Name = "grupoPeso";
            listViewGroup2.Header = "Mercadorias de Referência";
            listViewGroup2.Name = "grupoReferência";
            this.lst.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lst.Location = new System.Drawing.Point(0, 28);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(902, 159);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lst_ColumnClick);
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 119;
            // 
            // colPeso
            // 
            this.colPeso.Text = "Peso";
            // 
            // colEntrada
            // 
            this.colEntrada.Text = "Entrada";
            // 
            // colVenda
            // 
            this.colVenda.Text = "Venda";
            // 
            // colDevolução
            // 
            this.colDevolução.Text = "Devolução";
            this.colDevolução.Width = 94;
            // 
            // colSaldo
            // 
            this.colSaldo.Text = "Saldo";
            // 
            // colFornecedor
            // 
            this.colFornecedor.Text = "Fornecedor";
            this.colFornecedor.Width = 80;
            // 
            // colRefFornecedor
            // 
            this.colRefFornecedor.Text = "Ref. Fornecedor";
            this.colRefFornecedor.Width = 275;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 225);
            this.status.Margin = new System.Windows.Forms.Padding(0);
            this.status.Name = "status";
            this.status.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.panelReferencias,
            this.panelPesoTotal});
            this.status.ShowPanels = true;
            this.status.Size = new System.Drawing.Size(902, 21);
            this.status.SizingGrip = false;
            this.status.TabIndex = 6;
            // 
            // panelReferencias
            // 
            this.panelReferencias.Name = "panelReferencias";
            this.panelReferencias.Text = "Carregando...";
            // 
            // panelPesoTotal
            // 
            this.panelPesoTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelPesoTotal.Icon = ((System.Drawing.Icon)(resources.GetObject("panelPesoTotal.Icon")));
            this.panelPesoTotal.MinWidth = 100;
            this.panelPesoTotal.Name = "panelPesoTotal";
            this.panelPesoTotal.ToolTipText = "Somatória do peso levando em conta as quantidades";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPesquisa,
            this.toolStripSeparator1,
            this.toolStripBtnFiltrarFornecedor,
            this.toolStripComboBoxFornecedor});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(902, 25);
            this.toolStrip.TabIndex = 12;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPesquisa.Image = global::Apresentação.Resource.search;
            this.btnPesquisa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(23, 22);
            this.btnPesquisa.Text = "btnPesquisa";
            this.btnPesquisa.ToolTipText = "Localizar...";
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnFiltrarFornecedor
            // 
            this.toolStripBtnFiltrarFornecedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnFiltrarFornecedor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFiltrarFornecedor.Image")));
            this.toolStripBtnFiltrarFornecedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFiltrarFornecedor.Name = "toolStripBtnFiltrarFornecedor";
            this.toolStripBtnFiltrarFornecedor.Size = new System.Drawing.Size(107, 22);
            this.toolStripBtnFiltrarFornecedor.Text = "Filtrar Fornecedor:";
            this.toolStripBtnFiltrarFornecedor.Click += new System.EventHandler(this.toolStripBtnFiltrarFornecedor_Click);
            // 
            // toolStripComboBoxFornecedor
            // 
            this.toolStripComboBoxFornecedor.Enabled = false;
            this.toolStripComboBoxFornecedor.Name = "toolStripComboBoxFornecedor";
            this.toolStripComboBoxFornecedor.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxFornecedor.SelectedIndexChanged += new System.EventHandler(this.toolStripComboboxFornecedorSelectedIndexChanged);
            // 
            // localizador
            // 
            this.localizador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localizador.BotãoPesquisar = null;
            this.localizador.Location = new System.Drawing.Point(0, 193);
            this.localizador.Name = "localizador";
            this.localizador.Size = new System.Drawing.Size(899, 29);
            this.localizador.TabIndex = 7;
            this.localizador.Visible = false;
            this.localizador.RealçarItens += new Apresentação.Formulários.Localizador.RealçarDelegate(this.localizador_RealçarItens);
            this.localizador.DesrealçarTudo += new System.EventHandler(this.localizador_DesrealçarTudo);
            this.localizador.EncontrarItem += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItem);
            this.localizador.AoFechar += new System.EventHandler(this.localizador_AoFechar);
            // 
            // ListaSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.localizador);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lst);
            this.Name = "ListaSaldo";
            this.Size = new System.Drawing.Size(902, 246);
            ((System.ComponentModel.ISupportInitialize)(this.panelReferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPesoTotal)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colPeso;
        private System.Windows.Forms.ColumnHeader colEntrada;
        private System.Windows.Forms.ColumnHeader colDevolução;
        private System.Windows.Forms.ColumnHeader colVenda;
        private System.Windows.Forms.ColumnHeader colSaldo;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.StatusBar status;
        private System.Windows.Forms.StatusBarPanel panelPesoTotal;
        private System.Windows.Forms.StatusBarPanel panelReferencias;
        private System.Windows.Forms.ColumnHeader colFornecedor;
        private System.Windows.Forms.ColumnHeader colRefFornecedor;
        private Apresentação.Formulários.Localizador localizador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPesquisa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFornecedor;
        private System.Windows.Forms.ToolStripButton toolStripBtnFiltrarFornecedor;
    }
}
