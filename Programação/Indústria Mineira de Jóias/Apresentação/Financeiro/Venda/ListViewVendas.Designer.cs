namespace Apresentação.Financeiro.Venda
{
    partial class ListViewVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewVendas));
            this.lista = new System.Windows.Forms.ListView();
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCódigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colControle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListSemaforos = new System.Windows.Forms.ImageList(this.components);
            this.status = new System.Windows.Forms.StatusBar();
            this.painelQuantidade = new System.Windows.Forms.StatusBarPanel();
            this.painelValor = new System.Windows.Forms.StatusBarPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPesquisa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelecionarTudo = new System.Windows.Forms.ToolStripButton();
            this.btnSelecionarNada = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAcertado = new System.Windows.Forms.ToolStripButton();
            this.lblDesde = new System.Windows.Forms.ToolStripLabel();
            this.btnGerarNfe = new System.Windows.Forms.ToolStripButton();
            this.panelInterno = new System.Windows.Forms.Panel();
            this.localizador = new Apresentação.Formulários.Localizador();
            ((System.ComponentModel.ISupportInitialize)(this.painelQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.painelValor)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.panelInterno.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.CheckBoxes = true;
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colData,
            this.colCódigo,
            this.colControle,
            this.colCliente,
            this.colVendedor,
            this.colValor});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.HideSelection = false;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(804, 155);
            this.lista.SmallImageList = this.imageListSemaforos;
            this.lista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            this.lista.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lista_ItemChecked);
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lista_KeyDown);
            this.lista.Resize += new System.EventHandler(this.lista_Resize);
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 117;
            // 
            // colCódigo
            // 
            this.colCódigo.Text = "Código";
            this.colCódigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCódigo.Width = 54;
            // 
            // colControle
            // 
            this.colControle.Text = "Controle";
            this.colControle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colControle.Width = 53;
            // 
            // colCliente
            // 
            this.colCliente.Text = "Cliente";
            this.colCliente.Width = 144;
            // 
            // colVendedor
            // 
            this.colVendedor.Text = "Vendedor";
            this.colVendedor.Width = 144;
            // 
            // colValor
            // 
            this.colValor.Text = "Valor";
            this.colValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValor.Width = 81;
            // 
            // imageListSemaforos
            // 
            this.imageListSemaforos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSemaforos.ImageStream")));
            this.imageListSemaforos.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSemaforos.Images.SetKeyName(0, "semaforo_vermelho.png");
            this.imageListSemaforos.Images.SetKeyName(1, "semaforo_marron.png");
            this.imageListSemaforos.Images.SetKeyName(2, "semaforo_amarelo.png");
            this.imageListSemaforos.Images.SetKeyName(3, "semaforo_verde.png");
            this.imageListSemaforos.Images.SetKeyName(4, "semaforo_branco.png");
            this.imageListSemaforos.Images.SetKeyName(5, "semaforo_azul.png");
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 213);
            this.status.Name = "status";
            this.status.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.painelQuantidade,
            this.painelValor});
            this.status.ShowPanels = true;
            this.status.Size = new System.Drawing.Size(807, 21);
            this.status.SizingGrip = false;
            this.status.TabIndex = 6;
            // 
            // painelQuantidade
            // 
            this.painelQuantidade.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.painelQuantidade.Name = "painelQuantidade";
            this.painelQuantidade.ToolTipText = "Quantidade de \'linhas\' da tabela. Não necessariamente a quantidade de referências" +
    ".";
            this.painelQuantidade.Width = 766;
            // 
            // painelValor
            // 
            this.painelValor.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.painelValor.Name = "painelValor";
            this.painelValor.Text = "Valor";
            this.painelValor.Width = 41;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPesquisa,
            this.toolStripSeparator,
            this.btnSelecionarTudo,
            this.btnSelecionarNada,
            this.toolStripSeparator1,
            this.btnAcertado,
            this.lblDesde,
            this.btnGerarNfe});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(807, 25);
            this.toolStrip.TabIndex = 11;
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
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSelecionarTudo
            // 
            this.btnSelecionarTudo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSelecionarTudo.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarTudo.Image")));
            this.btnSelecionarTudo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelecionarTudo.Name = "btnSelecionarTudo";
            this.btnSelecionarTudo.Size = new System.Drawing.Size(93, 22);
            this.btnSelecionarTudo.Text = "Selecionar tudo";
            this.btnSelecionarTudo.Click += new System.EventHandler(this.btnSelecionarTudo_Click);
            // 
            // btnSelecionarNada
            // 
            this.btnSelecionarNada.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSelecionarNada.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarNada.Image")));
            this.btnSelecionarNada.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelecionarNada.Name = "btnSelecionarNada";
            this.btnSelecionarNada.Size = new System.Drawing.Size(94, 22);
            this.btnSelecionarNada.Text = "Selecionar nada";
            this.btnSelecionarNada.Click += new System.EventHandler(this.btnSelecionarNada_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAcertado
            // 
            this.btnAcertado.CheckOnClick = true;
            this.btnAcertado.Image = global::Apresentação.Resource.Acerto__Pequeno_;
            this.btnAcertado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcertado.Name = "btnAcertado";
            this.btnAcertado.Size = new System.Drawing.Size(161, 22);
            this.btnAcertado.Text = "Mostrar vendas acertadas";
            this.btnAcertado.CheckedChanged += new System.EventHandler(this.btnAcertado_CheckedChanged);
            // 
            // lblDesde
            // 
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(55, 22);
            this.lblDesde.Text = "(desde...)";
            this.lblDesde.Visible = false;
            // 
            // btnGerarNfe
            // 
            this.btnGerarNfe.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarNfe.Image")));
            this.btnGerarNfe.ImageTransparentColor = System.Drawing.Color.White;
            this.btnGerarNfe.Name = "btnGerarNfe";
            this.btnGerarNfe.Size = new System.Drawing.Size(84, 22);
            this.btnGerarNfe.Text = "Gerar NF-e";
            this.btnGerarNfe.Click += new System.EventHandler(this.btnGerarNfe_Click);
            // 
            // panelInterno
            // 
            this.panelInterno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInterno.Controls.Add(this.lista);
            this.panelInterno.Controls.Add(this.localizador);
            this.panelInterno.Location = new System.Drawing.Point(0, 28);
            this.panelInterno.Name = "panelInterno";
            this.panelInterno.Size = new System.Drawing.Size(804, 185);
            this.panelInterno.TabIndex = 13;
            // 
            // localizador
            // 
            this.localizador.BotãoPesquisar = this.btnPesquisa;
            this.localizador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.localizador.Location = new System.Drawing.Point(0, 155);
            this.localizador.Name = "localizador";
            this.localizador.Size = new System.Drawing.Size(804, 30);
            this.localizador.TabIndex = 1;
            this.localizador.Visible = false;
            this.localizador.RealçarItens += new Apresentação.Formulários.Localizador.RealçarDelegate(this.localizador_RealçarItens);
            this.localizador.DesrealçarTudo += new System.EventHandler(this.localizador_DesrealçarTudo);
            this.localizador.EncontrarItem += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItem);
            // 
            // ListViewVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInterno);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.status);
            this.Name = "ListViewVendas";
            this.Size = new System.Drawing.Size(807, 234);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ListViewVendas_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.painelQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.painelValor)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelInterno.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colCódigo;
        private System.Windows.Forms.ColumnHeader colCliente;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colVendedor;
        private System.Windows.Forms.StatusBar status;
        private System.Windows.Forms.StatusBarPanel painelQuantidade;
        private System.Windows.Forms.StatusBarPanel painelValor;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPesquisa;
        private System.Windows.Forms.Panel panelInterno;
        private Apresentação.Formulários.Localizador localizador;
        private System.Windows.Forms.ToolStripButton btnSelecionarTudo;
        private System.Windows.Forms.ToolStripButton btnSelecionarNada;
        private System.Windows.Forms.ColumnHeader colControle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAcertado;
        private System.Windows.Forms.ToolStripLabel lblDesde;
        private System.Windows.Forms.ToolStripButton btnGerarNfe;
        private System.Windows.Forms.ImageList imageListSemaforos;
    }
}
