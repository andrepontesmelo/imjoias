using Aga.Controls.Tree;
namespace Apresentação.Financeiro.Comissões
{
    partial class ListaVendaComissão
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
            this.components = new System.ComponentModel.Container();
            this.nodeTextBox1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeTextBox2 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeTextBox3 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.lst = new System.Windows.Forms.ListView();
            this.colCódigoVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComissaoPara = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSetor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorComissão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maisDetalhesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.abrirVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirComissãoParaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selecionarTudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverterSeleçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.status = new System.Windows.Forms.StatusBar();
            this.panelVendaTotal = new System.Windows.Forms.StatusBarPanel();
            this.panelComissãoTotal = new System.Windows.Forms.StatusBarPanel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelVendaTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelComissãoTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // nodeTextBox1
            // 
            this.nodeTextBox1.DataPropertyName = "Teste";
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCódigoVenda,
            this.colData,
            this.colVendedor,
            this.colCliente,
            this.colComissaoPara,
            this.colSetor,
            this.colValorVenda,
            this.colValorComissão});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            this.lst.GridLines = true;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(735, 386);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lst_ColumnClick);
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            this.lst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lst_KeyDown);
            this.lst.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lst_MouseClick);
            this.lst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            // 
            // colCódigoVenda
            // 
            this.colCódigoVenda.Text = "Venda No";
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 88;
            // 
            // colVendedor
            // 
            this.colVendedor.Text = "Vendedor";
            this.colVendedor.Width = 103;
            // 
            // colCliente
            // 
            this.colCliente.Text = "Cliente";
            this.colCliente.Width = 111;
            // 
            // colComissaoPara
            // 
            this.colComissaoPara.Text = "Comissão Para";
            this.colComissaoPara.Width = 123;
            // 
            // colSetor
            // 
            this.colSetor.Text = "Setor";
            // 
            // colValorVenda
            // 
            this.colValorVenda.Text = "Venda";
            // 
            // colValorComissão
            // 
            this.colValorComissão.Text = "Comissão";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maisDetalhesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.abrirVendaToolStripMenuItem,
            this.abrirClienteToolStripMenuItem,
            this.abrirVendedorToolStripMenuItem,
            this.abrirComissãoParaToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selecionarTudoToolStripMenuItem,
            this.inverterSeleçãoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 170);
            // 
            // maisDetalhesToolStripMenuItem
            // 
            this.maisDetalhesToolStripMenuItem.Image = global::Apresentação.Resource.propriedades;
            this.maisDetalhesToolStripMenuItem.Name = "maisDetalhesToolStripMenuItem";
            this.maisDetalhesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.maisDetalhesToolStripMenuItem.Text = "Mais detalhes";
            this.maisDetalhesToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
            // 
            // abrirVendaToolStripMenuItem
            // 
            this.abrirVendaToolStripMenuItem.Image = global::Apresentação.Resource.moedaunica;
            this.abrirVendaToolStripMenuItem.Name = "abrirVendaToolStripMenuItem";
            this.abrirVendaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.abrirVendaToolStripMenuItem.Text = "Abrir venda";
            this.abrirVendaToolStripMenuItem.Click += new System.EventHandler(this.abrirVendaToolStripMenuItem_Click);
            // 
            // abrirClienteToolStripMenuItem
            // 
            this.abrirClienteToolStripMenuItem.Name = "abrirClienteToolStripMenuItem";
            this.abrirClienteToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.abrirClienteToolStripMenuItem.Text = "Abrir cliente";
            this.abrirClienteToolStripMenuItem.Click += new System.EventHandler(this.abrirFichaToolStripMenuItem_Click);
            // 
            // abrirVendedorToolStripMenuItem
            // 
            this.abrirVendedorToolStripMenuItem.Name = "abrirVendedorToolStripMenuItem";
            this.abrirVendedorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.abrirVendedorToolStripMenuItem.Text = "Abrir vendedor";
            this.abrirVendedorToolStripMenuItem.Click += new System.EventHandler(this.abrirVendedorToolStripMenuItem_Click);
            // 
            // abrirComissãoParaToolStripMenuItem
            // 
            this.abrirComissãoParaToolStripMenuItem.Name = "abrirComissãoParaToolStripMenuItem";
            this.abrirComissãoParaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.abrirComissãoParaToolStripMenuItem.Text = "Abrir comissão para";
            this.abrirComissãoParaToolStripMenuItem.Click += new System.EventHandler(this.abrirComissãoParaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 6);
            // 
            // selecionarTudoToolStripMenuItem
            // 
            this.selecionarTudoToolStripMenuItem.Name = "selecionarTudoToolStripMenuItem";
            this.selecionarTudoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.selecionarTudoToolStripMenuItem.Text = "Selecionar tudo";
            this.selecionarTudoToolStripMenuItem.Click += new System.EventHandler(this.selecionarTudoToolStripMenuItem_Click);
            // 
            // inverterSeleçãoToolStripMenuItem
            // 
            this.inverterSeleçãoToolStripMenuItem.Name = "inverterSeleçãoToolStripMenuItem";
            this.inverterSeleçãoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.inverterSeleçãoToolStripMenuItem.Text = "Inverter seleção";
            this.inverterSeleçãoToolStripMenuItem.Click += new System.EventHandler(this.inverterSeleçãoToolStripMenuItem_Click);
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 365);
            this.status.Margin = new System.Windows.Forms.Padding(0);
            this.status.Name = "status";
            this.status.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.panelVendaTotal,
            this.panelComissãoTotal});
            this.status.ShowPanels = true;
            this.status.Size = new System.Drawing.Size(735, 21);
            this.status.SizingGrip = false;
            this.status.TabIndex = 6;
            // 
            // panelVendaTotal
            // 
            this.panelVendaTotal.Name = "panelÍndiceTotal";
            this.panelVendaTotal.Text = "Venda:";
            this.panelVendaTotal.ToolTipText = "Somatória do índice";
            // 
            // panelComissãoTotal
            // 
            this.panelComissãoTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelComissãoTotal.Name = "panelPreçoTotal";
            this.panelComissãoTotal.Text = "Comissão:";
            this.panelComissãoTotal.Width = 68;
            // 
            // ListaVendaComissão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.status);
            this.Controls.Add(this.lst);
            this.Name = "ListaVendaComissão";
            this.Size = new System.Drawing.Size(735, 386);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelVendaTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelComissãoTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox1;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox2;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox3;
        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colCódigoVenda;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colVendedor;
        private System.Windows.Forms.ColumnHeader colCliente;
        private System.Windows.Forms.ColumnHeader colComissaoPara;
        private System.Windows.Forms.ColumnHeader colSetor;
        private System.Windows.Forms.ColumnHeader colValorComissão;
        private System.Windows.Forms.ColumnHeader colValorVenda;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maisDetalhesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirVendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirComissãoParaToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selecionarTudoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverterSeleçãoToolStripMenuItem;
        private System.Windows.Forms.StatusBar status;
        private System.Windows.Forms.StatusBarPanel panelComissãoTotal;
        internal System.Windows.Forms.StatusBarPanel panelVendaTotal;
    }
}
