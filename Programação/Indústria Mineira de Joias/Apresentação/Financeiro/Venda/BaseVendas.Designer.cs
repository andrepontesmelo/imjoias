namespace Apresentação.Financeiro.Venda
{
    partial class BaseVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseVendas));
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroOpçõesVenda = new Apresentação.Formulários.Quadro();
            this.opçãoMoverAcerto = new Apresentação.Formulários.Opção();
            this.opçãoExcluirVendas = new Apresentação.Formulários.Opção();
            this.opçãoRegistrarNovaVenda = new Apresentação.Formulários.Opção();
            this.opçãoProcurar = new Apresentação.Formulários.Opção();
            this.opçãoImpressão = new Apresentação.Formulários.Opção();
            this.lista = new Apresentação.Financeiro.Venda.ListViewVendas();
            this.quadroLista = new Apresentação.Formulários.Quadro();
            this.quadroComprasDesteFuncionário = new Apresentação.Formulários.Quadro();
            this.opçãoComprasDesteFuncionário = new Apresentação.Formulários.Opção();
            this.semaforoLegenda1 = new Apresentação.Financeiro.Venda.SemaforoLegenda();
            this.esquerda.SuspendLayout();
            this.quadroOpçõesVenda.SuspendLayout();
            this.quadroLista.SuspendLayout();
            this.quadroComprasDesteFuncionário.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.semaforoLegenda1);
            this.esquerda.Controls.Add(this.quadroComprasDesteFuncionário);
            this.esquerda.Controls.Add(this.quadroOpçõesVenda);
            this.esquerda.Size = new System.Drawing.Size(187, 419);
            this.esquerda.Controls.SetChildIndex(this.quadroOpçõesVenda, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroComprasDesteFuncionário, 0);
            this.esquerda.Controls.SetChildIndex(this.semaforoLegenda1, 0);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Nome da pessoa";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.moeda;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(552, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Relação de vendas";
            // 
            // quadroOpçõesVenda
            // 
            this.quadroOpçõesVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroOpçõesVenda.bInfDirArredondada = true;
            this.quadroOpçõesVenda.bInfEsqArredondada = true;
            this.quadroOpçõesVenda.bSupDirArredondada = true;
            this.quadroOpçõesVenda.bSupEsqArredondada = true;
            this.quadroOpçõesVenda.Controls.Add(this.opçãoMoverAcerto);
            this.quadroOpçõesVenda.Controls.Add(this.opçãoExcluirVendas);
            this.quadroOpçõesVenda.Controls.Add(this.opçãoRegistrarNovaVenda);
            this.quadroOpçõesVenda.Controls.Add(this.opçãoProcurar);
            this.quadroOpçõesVenda.Controls.Add(this.opçãoImpressão);
            this.quadroOpçõesVenda.Cor = System.Drawing.Color.Black;
            this.quadroOpçõesVenda.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOpçõesVenda.LetraTítulo = System.Drawing.Color.White;
            this.quadroOpçõesVenda.Location = new System.Drawing.Point(7, 13);
            this.quadroOpçõesVenda.MostrarBotãoMinMax = false;
            this.quadroOpçõesVenda.Name = "quadroOpçõesVenda";
            this.quadroOpçõesVenda.Size = new System.Drawing.Size(160, 151);
            this.quadroOpçõesVenda.TabIndex = 0;
            this.quadroOpçõesVenda.Tamanho = 30;
            this.quadroOpçõesVenda.Título = "O que quer fazer?";
            // 
            // opçãoMoverAcerto
            // 
            this.opçãoMoverAcerto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMoverAcerto.Descrição = "Mover para outro acerto...";
            this.opçãoMoverAcerto.Imagem = global::Apresentação.Resource.Acerto__Pequeno_;
            this.opçãoMoverAcerto.Location = new System.Drawing.Point(5, 106);
            this.opçãoMoverAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMoverAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMoverAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMoverAcerto.Name = "opçãoMoverAcerto";
            this.opçãoMoverAcerto.PermitirLiberaçãoRecurso = true;
            this.opçãoMoverAcerto.Privilégio = Entidades.Privilégio.Permissão.MoverDocumentoAcerto;
            this.opçãoMoverAcerto.Size = new System.Drawing.Size(150, 24);
            this.opçãoMoverAcerto.TabIndex = 7;
            this.opçãoMoverAcerto.Click += new System.EventHandler(this.opçãoMoverAcerto_Click);
            // 
            // opçãoExcluirVendas
            // 
            this.opçãoExcluirVendas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirVendas.Descrição = "Excluir vendas...";
            this.opçãoExcluirVendas.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoExcluirVendas.Location = new System.Drawing.Point(5, 128);
            this.opçãoExcluirVendas.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoExcluirVendas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirVendas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirVendas.Name = "opçãoExcluirVendas";
            this.opçãoExcluirVendas.Privilégio = Entidades.Privilégio.Permissão.VendasDestravar;
            this.opçãoExcluirVendas.Size = new System.Drawing.Size(150, 24);
            this.opçãoExcluirVendas.TabIndex = 9;
            this.opçãoExcluirVendas.Click += new System.EventHandler(this.opçãoExcluirVendas_Click);
            // 
            // opçãoRegistrarNovaVenda
            // 
            this.opçãoRegistrarNovaVenda.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRegistrarNovaVenda.Descrição = "Registrar nova venda...";
            this.opçãoRegistrarNovaVenda.Imagem = global::Apresentação.Resource.NewCardHS;
            this.opçãoRegistrarNovaVenda.Location = new System.Drawing.Point(7, 58);
            this.opçãoRegistrarNovaVenda.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoRegistrarNovaVenda.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRegistrarNovaVenda.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRegistrarNovaVenda.Name = "opçãoRegistrarNovaVenda";
            this.opçãoRegistrarNovaVenda.Size = new System.Drawing.Size(150, 24);
            this.opçãoRegistrarNovaVenda.TabIndex = 3;
            this.opçãoRegistrarNovaVenda.Click += new System.EventHandler(this.opçãoRegistrarNovaVenda_Click);
            // 
            // opçãoProcurar
            // 
            this.opçãoProcurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoProcurar.Descrição = "Procurar por venda...";
            this.opçãoProcurar.Imagem = global::Apresentação.Resource.search;
            this.opçãoProcurar.Location = new System.Drawing.Point(7, 34);
            this.opçãoProcurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoProcurar.Name = "opçãoProcurar";
            this.opçãoProcurar.Size = new System.Drawing.Size(150, 24);
            this.opçãoProcurar.TabIndex = 2;
            this.opçãoProcurar.Click += new System.EventHandler(this.opçãoProcurar_Click);
            // 
            // opçãoImpressão
            // 
            this.opçãoImpressão.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImpressão.Descrição = "Imprimir...";
            this.opçãoImpressão.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImpressão.Location = new System.Drawing.Point(7, 82);
            this.opçãoImpressão.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImpressão.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImpressão.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImpressão.Name = "opçãoImpressão";
            this.opçãoImpressão.Size = new System.Drawing.Size(150, 24);
            this.opçãoImpressão.TabIndex = 4;
            this.opçãoImpressão.Click += new System.EventHandler(this.opçãoImpressão_Click);
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.ItemSelecionado = null;
            this.lista.ItensSelecionados = ((System.Collections.Generic.List<Entidades.Relacionamento.Venda.IDadosVenda>)(resources.GetObject("lista.ItensSelecionados")));
            this.lista.Location = new System.Drawing.Point(3, 29);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(588, 296);
            this.lista.TabIndex = 7;
            this.lista.AoDuploClique += new Apresentação.Financeiro.Venda.ListViewVendas.DelegaçãoVenda(this.lista_AoDuploClique);
            this.lista.LegendasContabilizadas += Lista_LegendasContabilizadas;
            // 
            // quadroLista
            // 
            this.quadroLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroLista.bInfDirArredondada = false;
            this.quadroLista.bInfEsqArredondada = false;
            this.quadroLista.bSupDirArredondada = true;
            this.quadroLista.bSupEsqArredondada = true;
            this.quadroLista.Controls.Add(this.lista);
            this.quadroLista.Cor = System.Drawing.Color.Black;
            this.quadroLista.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroLista.LetraTítulo = System.Drawing.Color.White;
            this.quadroLista.Location = new System.Drawing.Point(193, 79);
            this.quadroLista.MostrarBotãoMinMax = false;
            this.quadroLista.Name = "quadroLista";
            this.quadroLista.Size = new System.Drawing.Size(594, 328);
            this.quadroLista.TabIndex = 8;
            this.quadroLista.Tamanho = 30;
            this.quadroLista.Título = "Histórico de vendas";
            // 
            // quadroComprasDesteFuncionário
            // 
            this.quadroComprasDesteFuncionário.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroComprasDesteFuncionário.bInfDirArredondada = true;
            this.quadroComprasDesteFuncionário.bInfEsqArredondada = true;
            this.quadroComprasDesteFuncionário.bSupDirArredondada = true;
            this.quadroComprasDesteFuncionário.bSupEsqArredondada = true;
            this.quadroComprasDesteFuncionário.Controls.Add(this.opçãoComprasDesteFuncionário);
            this.quadroComprasDesteFuncionário.Cor = System.Drawing.Color.Black;
            this.quadroComprasDesteFuncionário.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroComprasDesteFuncionário.LetraTítulo = System.Drawing.Color.White;
            this.quadroComprasDesteFuncionário.Location = new System.Drawing.Point(7, 170);
            this.quadroComprasDesteFuncionário.MostrarBotãoMinMax = false;
            this.quadroComprasDesteFuncionário.Name = "quadroComprasDesteFuncionário";
            this.quadroComprasDesteFuncionário.Size = new System.Drawing.Size(160, 52);
            this.quadroComprasDesteFuncionário.TabIndex = 1;
            this.quadroComprasDesteFuncionário.Tamanho = 30;
            this.quadroComprasDesteFuncionário.Título = "Funcionário";
            this.quadroComprasDesteFuncionário.Visible = false;
            // 
            // opçãoComprasDesteFuncionário
            // 
            this.opçãoComprasDesteFuncionário.BackColor = System.Drawing.Color.Transparent;
            this.opçãoComprasDesteFuncionário.Descrição = "Visualizar compras";
            this.opçãoComprasDesteFuncionário.Imagem = global::Apresentação.Resource.folderopen1;
            this.opçãoComprasDesteFuncionário.Location = new System.Drawing.Point(5, 28);
            this.opçãoComprasDesteFuncionário.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoComprasDesteFuncionário.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoComprasDesteFuncionário.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoComprasDesteFuncionário.Name = "opçãoComprasDesteFuncionário";
            this.opçãoComprasDesteFuncionário.PermitirLiberaçãoRecurso = true;
            this.opçãoComprasDesteFuncionário.Size = new System.Drawing.Size(150, 17);
            this.opçãoComprasDesteFuncionário.TabIndex = 7;
            this.opçãoComprasDesteFuncionário.Click += new System.EventHandler(this.opçãoComprasDesteFuncionário_Click);
            // 
            // semaforoLegenda1
            // 
            this.semaforoLegenda1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.semaforoLegenda1.bInfDirArredondada = true;
            this.semaforoLegenda1.bInfEsqArredondada = true;
            this.semaforoLegenda1.bSupDirArredondada = true;
            this.semaforoLegenda1.bSupEsqArredondada = true;
            this.semaforoLegenda1.Cor = System.Drawing.Color.Black;
            this.semaforoLegenda1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.semaforoLegenda1.LetraTítulo = System.Drawing.Color.White;
            this.semaforoLegenda1.Location = new System.Drawing.Point(7, 229);
            this.semaforoLegenda1.MostrarBotãoMinMax = false;
            this.semaforoLegenda1.Name = "semaforoLegenda1";
            this.semaforoLegenda1.Size = new System.Drawing.Size(160, 155);
            this.semaforoLegenda1.TabIndex = 2;
            this.semaforoLegenda1.Tamanho = 30;
            this.semaforoLegenda1.Título = "Legenda";
            this.semaforoLegenda1.ClicouNaLegenda += SemaforoLegenda1_aoClicarLegenda;
            // 
            // BaseVendas
            // 
            this.Controls.Add(this.título);
            this.Controls.Add(this.quadroLista);
            this.Name = "BaseVendas";
            this.Size = new System.Drawing.Size(800, 419);
            this.Controls.SetChildIndex(this.quadroLista, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroOpçõesVenda.ResumeLayout(false);
            this.quadroLista.ResumeLayout(false);
            this.quadroComprasDesteFuncionário.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior título;
        private Apresentação.Formulários.Quadro quadroOpçõesVenda;
        private Apresentação.Formulários.Opção opçãoProcurar;
        private Apresentação.Formulários.Opção opçãoRegistrarNovaVenda;
        private ListViewVendas lista;
        private Apresentação.Formulários.Quadro quadroLista;
        private Apresentação.Formulários.Opção opçãoImpressão;
        private Apresentação.Formulários.Opção opçãoMoverAcerto;
        private Apresentação.Formulários.Quadro quadroComprasDesteFuncionário;
        private Apresentação.Formulários.Opção opçãoComprasDesteFuncionário;
        private Apresentação.Formulários.Opção opçãoExcluirVendas;
        private SemaforoLegenda semaforoLegenda1;
    }
}
