namespace Apresentação.Financeiro.Pagamento
{
    partial class ListaPagamento
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
            this.lista = new System.Windows.Forms.ListView();
            this.colContador = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorLíquido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProrrogação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegistradoPor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPagaVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPagoNaVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnLocalizar = new System.Windows.Forms.ToolStripButton();
            this.btnAdicionar = new System.Windows.Forms.ToolStripDropDownButton();
            this.adicionarDinheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarChequeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarNotaPromissóriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarOuroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarDolarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.localizador = new Apresentação.Formulários.Localizador();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.qtdStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.valorTotalStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.valorTotalLíquidoStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgCarregar = new System.ComponentModel.BackgroundWorker();
            this.valorPendente = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colContador,
            this.colData,
            this.colDias,
            this.colValor,
            this.colValorLíquido,
            this.colVencimento,
            this.colProrrogação,
            this.colDescrição,
            this.colRegistradoPor,
            this.colPagaVenda,
            this.colPagoNaVenda});
            this.lista.FullRowSelect = true;
            this.lista.HideSelection = false;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(737, 235);
            this.lista.SmallImageList = this.imageList;
            this.lista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lista_KeyDown);
            // 
            // colContador
            // 
            this.colContador.Text = "#";
            this.colContador.Width = 40;
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 85;
            // 
            // colDias
            // 
            this.colDias.Text = "Dias";
            // 
            // colValor
            // 
            this.colValor.Text = "Bruto";
            this.colValor.Width = 80;
            // 
            // colValorLíquido
            // 
            this.colValorLíquido.Text = "Líquido";
            this.colValorLíquido.Width = 80;
            // 
            // colVencimento
            // 
            this.colVencimento.Text = "Vencimento";
            this.colVencimento.Width = 87;
            // 
            // colProrrogação
            // 
            this.colProrrogação.Text = "Prorrogado";
            this.colProrrogação.Width = 100;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 150;
            // 
            // colRegistradoPor
            // 
            this.colRegistradoPor.Text = "Recebido por";
            this.colRegistradoPor.Width = 124;
            // 
            // colPagaVenda
            // 
            this.colPagaVenda.Text = "Paga a venda";
            this.colPagaVenda.Width = 80;
            // 
            // colPagoNaVenda
            // 
            this.colPagoNaVenda.Text = "Pago na venda";
            this.colPagoNaVenda.Width = 128;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLocalizar,
            this.btnAdicionar,
            this.btnExcluir,
            this.btnAlterar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(737, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Image = global::Apresentação.Resource.search;
            this.btnLocalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(73, 22);
            this.btnLocalizar.Text = "Localizar";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarDinheiroToolStripMenuItem,
            this.adicionarChequeToolStripMenuItem,
            this.adicionarNotaPromissóriaToolStripMenuItem,
            this.adicionarOuroToolStripMenuItem,
            this.adicionarDolarToolStripMenuItem});
            this.btnAdicionar.Image = global::Apresentação.Resource.adicionar_pagamento;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(96, 22);
            this.btnAdicionar.Text = "Adicionar...";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // adicionarDinheiroToolStripMenuItem
            // 
            this.adicionarDinheiroToolStripMenuItem.Image = global::Apresentação.Resource.dinheiro;
            this.adicionarDinheiroToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.adicionarDinheiroToolStripMenuItem.Name = "adicionarDinheiroToolStripMenuItem";
            this.adicionarDinheiroToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.adicionarDinheiroToolStripMenuItem.Text = "Dinheiro";
            this.adicionarDinheiroToolStripMenuItem.Click += new System.EventHandler(this.adicionarDinheiroToolStripMenuItem_Click);
            // 
            // adicionarChequeToolStripMenuItem
            // 
            this.adicionarChequeToolStripMenuItem.Image = global::Apresentação.Resource.cheque1;
            this.adicionarChequeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.adicionarChequeToolStripMenuItem.Name = "adicionarChequeToolStripMenuItem";
            this.adicionarChequeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.adicionarChequeToolStripMenuItem.Text = "Cheque";
            this.adicionarChequeToolStripMenuItem.Click += new System.EventHandler(this.adicionarChequeToolStripMenuItem_Click);
            // 
            // adicionarNotaPromissóriaToolStripMenuItem
            // 
            this.adicionarNotaPromissóriaToolStripMenuItem.Image = global::Apresentação.Resource.np;
            this.adicionarNotaPromissóriaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.adicionarNotaPromissóriaToolStripMenuItem.Name = "adicionarNotaPromissóriaToolStripMenuItem";
            this.adicionarNotaPromissóriaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.adicionarNotaPromissóriaToolStripMenuItem.Text = "Nota promissória";
            this.adicionarNotaPromissóriaToolStripMenuItem.Click += new System.EventHandler(this.adicionarNotaPromissóriaToolStripMenuItem_Click);
            // 
            // adicionarOuroToolStripMenuItem
            // 
            this.adicionarOuroToolStripMenuItem.Image = global::Apresentação.Resource.botão___ouro;
            this.adicionarOuroToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.adicionarOuroToolStripMenuItem.Name = "adicionarOuroToolStripMenuItem";
            this.adicionarOuroToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.adicionarOuroToolStripMenuItem.Text = "Ouro";
            this.adicionarOuroToolStripMenuItem.Click += new System.EventHandler(this.adicionarOuroToolStripMenuItem_Click);
            // 
            // adicionarDolarToolStripMenuItem
            // 
            this.adicionarDolarToolStripMenuItem.Image = global::Apresentação.Resource.pagar_em_dólares__pequeno_1;
            this.adicionarDolarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.adicionarDolarToolStripMenuItem.Name = "adicionarDolarToolStripMenuItem";
            this.adicionarDolarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.adicionarDolarToolStripMenuItem.Text = "Dólar";
            this.adicionarDolarToolStripMenuItem.Click += new System.EventHandler(this.adicionarDolarToolStripMenuItem_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::Apresentação.Resource.remover_pagamento;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(61, 22);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.ToolTipText = "Exclui o pagamento selecionado.";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = global::Apresentação.Resource.cash_stack_share;
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(62, 22);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.ToolTipText = "Altera o pagamento selecionado.";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // localizador
            // 
            this.localizador.BotãoPesquisar = this.btnLocalizar;
            this.localizador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.localizador.Location = new System.Drawing.Point(0, 256);
            this.localizador.Name = "localizador";
            this.localizador.Size = new System.Drawing.Size(737, 30);
            this.localizador.TabIndex = 2;
            this.localizador.Visible = false;
            this.localizador.RealçarItens += new Apresentação.Formulários.Localizador.RealçarDelegate(this.localizador_RealçarItens);
            this.localizador.DesrealçarTudo += new System.EventHandler(this.localizador_DesrealçarTudo);
            this.localizador.EncontrarItem += new Apresentação.Formulários.Localizador.EncontrarDelegate(this.localizador_EncontrarItem);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.localizador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 286);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.lista);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(737, 256);
            this.panel2.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qtdStatusStrip,
            this.valorTotalStrip,
            this.valorTotalLíquidoStrip,
            this.valorPendente});
            this.statusStrip1.Location = new System.Drawing.Point(0, 234);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(737, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // qtdStatusStrip
            // 
            this.qtdStatusStrip.Name = "qtdStatusStrip";
            this.qtdStatusStrip.Size = new System.Drawing.Size(41, 17);
            this.qtdStatusStrip.Text = "0 Itens";
            // 
            // valorTotalStrip
            // 
            this.valorTotalStrip.Name = "valorTotalStrip";
            this.valorTotalStrip.Size = new System.Drawing.Size(44, 17);
            this.valorTotalStrip.Text = "R$ 0,00";
            // 
            // valorTotalLíquidoStrip
            // 
            this.valorTotalLíquidoStrip.Name = "valorTotalLíquidoStrip";
            this.valorTotalLíquidoStrip.Size = new System.Drawing.Size(44, 17);
            this.valorTotalLíquidoStrip.Text = "liquido";
            // 
            // bgCarregar
            // 
            this.bgCarregar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCarregar_DoWork);
            this.bgCarregar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCarregar_RunWorkerCompleted);
            // 
            // valorPendente
            // 
            this.valorPendente.Name = "valorPendente";
            this.valorPendente.Size = new System.Drawing.Size(83, 17);
            this.valorPendente.Text = "valorPendente";
            // 
            // ListaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip);
            this.Name = "ListaPagamento";
            this.Size = new System.Drawing.Size(737, 311);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colRegistradoPor;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton btnAdicionar;
        private System.Windows.Forms.ToolStripMenuItem adicionarDinheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarChequeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarOuroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarDolarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarNotaPromissóriaToolStripMenuItem;
        protected System.Windows.Forms.ColumnHeader colVencimento;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader colPagoNaVenda;
        private System.Windows.Forms.ColumnHeader colPagaVenda;
        private Apresentação.Formulários.Localizador localizador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnLocalizar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripButton btnAlterar;
        private System.ComponentModel.BackgroundWorker bgCarregar;
        private System.Windows.Forms.ColumnHeader colDias;
        private System.Windows.Forms.ColumnHeader colValorLíquido;
        private System.Windows.Forms.ColumnHeader colProrrogação;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel qtdStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel valorTotalStrip;
        private System.Windows.Forms.ToolStripStatusLabel valorTotalLíquidoStrip;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colContador;
        private System.Windows.Forms.ToolStripStatusLabel valorPendente;
    }
}
