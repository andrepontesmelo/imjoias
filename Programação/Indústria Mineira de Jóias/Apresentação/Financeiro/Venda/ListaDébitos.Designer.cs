namespace Apresentação.Financeiro.Venda
{
    partial class ListaDébitos
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
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lista = new System.Windows.Forms.ListView();
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorBruto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorLíquido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = new System.Windows.Forms.StatusBar();
            this.statusTxtQtd = new System.Windows.Forms.StatusBarPanel();
            this.statusTxtBruto = new System.Windows.Forms.StatusBarPanel();
            this.statusTxtLíquido = new System.Windows.Forms.StatusBarPanel();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.bgCarregar = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusTxtQtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTxtBruto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTxtLíquido)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = global::Apresentação.Resource.propriedades;
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(62, 22);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.ToolTipText = "Altera o pagamento selecionado.";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lista);
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 182);
            this.panel1.TabIndex = 5;
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colData,
            this.colDescrição,
            this.colDias,
            this.colValorBruto,
            this.colValorLíquido});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.HideSelection = false;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(664, 182);
            this.lista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lista.TabIndex = 3;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 82;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 220;
            // 
            // colDias
            // 
            this.colDias.Text = "Dias";
            this.colDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDias.Width = 50;
            // 
            // colValorBruto
            // 
            this.colValorBruto.Text = "Bruto";
            this.colValorBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValorBruto.Width = 80;
            // 
            // colValorLíquido
            // 
            this.colValorLíquido.Text = "Líquido";
            this.colValorLíquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValorLíquido.Width = 80;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 207);
            this.status.Name = "status";
            this.status.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusTxtQtd,
            this.statusTxtBruto,
            this.statusTxtLíquido});
            this.status.ShowPanels = true;
            this.status.Size = new System.Drawing.Size(670, 22);
            this.status.TabIndex = 0;
            // 
            // statusTxtQtd
            // 
            this.statusTxtQtd.Name = "statusTxtQtd";
            this.statusTxtQtd.Text = "0 Débitos";
            this.statusTxtQtd.Width = 535;
            // 
            // statusTxtBruto
            // 
            this.statusTxtBruto.Name = "statusTxtBruto";
            this.statusTxtBruto.Width = 110;
            // 
            // statusTxtLíquido
            // 
            this.statusTxtLíquido.Name = "statusTxtLíquido";
            this.statusTxtLíquido.Width = 120;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = global::Apresentação.Resource.Excluir;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(61, 22);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.ToolTipText = "Exclui o pagamento selecionado.";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnExcluir,
            this.btnAlterar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(670, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::Apresentação.Resource.moedaunica;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(87, 22);
            this.btnAdicionar.Text = "Adicionar...";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // bgCarregar
            // 
            this.bgCarregar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCarregar_DoWork);
            this.bgCarregar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCarregar_RunWorkerCompleted);
            // 
            // ListaDébitos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip);
            this.Name = "ListaDébitos";
            this.Size = new System.Drawing.Size(670, 229);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusTxtQtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTxtBruto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTxtLíquido)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnAlterar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.ComponentModel.BackgroundWorker bgCarregar;
        private System.Windows.Forms.StatusBar status;
        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colDias;
        private System.Windows.Forms.ColumnHeader colValorBruto;
        private System.Windows.Forms.ColumnHeader colValorLíquido;
        private System.Windows.Forms.StatusBarPanel statusTxtQtd;
        private System.Windows.Forms.StatusBarPanel statusTxtBruto;
        private System.Windows.Forms.StatusBarPanel statusTxtLíquido;
    }
}
