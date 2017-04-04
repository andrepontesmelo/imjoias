namespace Apresentação.Mercadoria
{
    partial class RastrearMercadoria
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Saída #22132 - 290.001.00.002-8 - 5");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Retorno #11399 290.001.00.003-5 - 4");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Eustaquio Macedo Melo Junior - 1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tiago de Melo Correia - Representante - 1", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Varejo - 6", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.label1 = new System.Windows.Forms.Label();
            this.txtMercadoria = new Apresentação.Mercadoria.TxtMercadoria();
            this.btnFechar = new System.Windows.Forms.Button();
            this.bgRastrear = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstConsignado = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPróximoAcerto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstVendas = new System.Windows.Forms.ListView();
            this.colVendasCódigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendasCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendasQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendasData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(182, 20);
            this.lblTítulo.Text = "Rastro de mercadoria";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(423, 48);
            this.lblDescrição.Text = "Abaixo serão exibidas todas as pessoas que portam a mercadoria. Vendas marcadas c" +
    "omo rastreadas são localizadas na aba Vendas.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.elegant;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mercadoria:";
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMercadoria.Location = new System.Drawing.Point(84, 101);
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Referência = "";
            this.txtMercadoria.Size = new System.Drawing.Size(407, 20);
            this.txtMercadoria.TabIndex = 4;
            this.txtMercadoria.ReferênciaConfirmada += new System.EventHandler(this.txtMercadoria_ReferênciaConfirmada);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFechar.Location = new System.Drawing.Point(424, 409);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // bgRastrear
            // 
            this.bgRastrear.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRastrear_DoWork);
            this.bgRastrear.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRastrear_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 139);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(487, 264);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Controls.Add(this.lstConsignado);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(479, 238);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consignado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstConsignado
            // 
            this.lstConsignado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConsignado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colQuantidade,
            this.colPróximoAcerto});
            this.lstConsignado.FullRowSelect = true;
            this.lstConsignado.Location = new System.Drawing.Point(-3, 0);
            this.lstConsignado.Name = "lstConsignado";
            this.lstConsignado.Size = new System.Drawing.Size(479, 28);
            this.lstConsignado.TabIndex = 7;
            this.lstConsignado.UseCompatibleStateImageBehavior = false;
            this.lstConsignado.View = System.Windows.Forms.View.Details;
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 161;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Text = "Quantidade";
            this.colQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQuantidade.Width = 70;
            // 
            // colPróximoAcerto
            // 
            this.colPróximoAcerto.Text = "Previsão acerto";
            this.colPróximoAcerto.Width = 103;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstVendas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(479, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vendas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstVendas
            // 
            this.lstVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVendas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVendasCódigo,
            this.colVendasCliente,
            this.colVendasQuantidade,
            this.colVendasData});
            this.lstVendas.FullRowSelect = true;
            this.lstVendas.Location = new System.Drawing.Point(-4, 0);
            this.lstVendas.Name = "lstVendas";
            this.lstVendas.Size = new System.Drawing.Size(479, 238);
            this.lstVendas.TabIndex = 8;
            this.lstVendas.UseCompatibleStateImageBehavior = false;
            this.lstVendas.View = System.Windows.Forms.View.Details;
            this.lstVendas.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstVendas_ColumnClick);
            // 
            // colVendasCódigo
            // 
            this.colVendasCódigo.Text = "Código";
            this.colVendasCódigo.Width = 50;
            // 
            // colVendasCliente
            // 
            this.colVendasCliente.Text = "Cliente";
            this.colVendasCliente.Width = 232;
            // 
            // colVendasQuantidade
            // 
            this.colVendasQuantidade.Text = "Quantidade";
            this.colVendasQuantidade.Width = 90;
            // 
            // colVendasData
            // 
            this.colVendasData.Text = "Data";
            this.colVendasData.Width = 98;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Saída #22132 - 290.001.00.002-8 - 5";
            treeNode2.Name = "Node5";
            treeNode2.Text = "Retorno #11399 290.001.00.003-5 - 4";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Eustaquio Macedo Melo Junior - 1";
            treeNode4.Name = "Node6";
            treeNode4.Text = "Node6";
            treeNode5.Name = "Node1";
            treeNode5.Text = "Tiago de Melo Correia - Representante - 1";
            treeNode6.Name = "Node7";
            treeNode6.Text = "Node7";
            treeNode7.Name = "Node2";
            treeNode7.Text = "Varejo - 6";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(473, 232);
            this.treeView1.TabIndex = 8;
            // 
            // RastrearMercadoria
            // 
            this.AcceptButton = this.btnFechar;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(511, 444);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMercadoria);
            this.Name = "RastrearMercadoria";
            this.Text = "Rastrear mercadoria";
            this.Controls.SetChildIndex(this.txtMercadoria, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnFechar, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TxtMercadoria txtMercadoria;
        private System.Windows.Forms.Button btnFechar;
        private System.ComponentModel.BackgroundWorker bgRastrear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lstConsignado;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colQuantidade;
        private System.Windows.Forms.ColumnHeader colPróximoAcerto;
        private System.Windows.Forms.ListView lstVendas;
        private System.Windows.Forms.ColumnHeader colVendasCódigo;
        private System.Windows.Forms.ColumnHeader colVendasCliente;
        private System.Windows.Forms.ColumnHeader colVendasQuantidade;
        private System.Windows.Forms.ColumnHeader colVendasData;
        private System.Windows.Forms.TreeView treeView1;
    }
}
