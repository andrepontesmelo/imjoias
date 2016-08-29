namespace Apresenta��o.Financeiro.Venda
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
            this.t�tulo = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadroOp��esVenda = new Apresenta��o.Formul�rios.Quadro();
            this.op��oMoverAcerto = new Apresenta��o.Formul�rios.Op��o();
            this.op��oExcluirVendas = new Apresenta��o.Formul�rios.Op��o();
            this.op��oRegistrarNovaVenda = new Apresenta��o.Formul�rios.Op��o();
            this.op��oProcurar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oImpress�o = new Apresenta��o.Formul�rios.Op��o();
            this.lista = new Apresenta��o.Financeiro.Venda.ListViewVendas();
            this.quadroLista = new Apresenta��o.Formul�rios.Quadro();
            this.quadroComprasDesteFuncion�rio = new Apresenta��o.Formul�rios.Quadro();
            this.op��oComprasDesteFuncion�rio = new Apresenta��o.Formul�rios.Op��o();
            this.semaforoLegenda1 = new Apresenta��o.Financeiro.Venda.SemaforoLegenda();
            this.esquerda.SuspendLayout();
            this.quadroOp��esVenda.SuspendLayout();
            this.quadroLista.SuspendLayout();
            this.quadroComprasDesteFuncion�rio.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.semaforoLegenda1);
            this.esquerda.Controls.Add(this.quadroComprasDesteFuncion�rio);
            this.esquerda.Controls.Add(this.quadroOp��esVenda);
            this.esquerda.Size = new System.Drawing.Size(187, 419);
            this.esquerda.Controls.SetChildIndex(this.quadroOp��esVenda, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroComprasDesteFuncion�rio, 0);
            this.esquerda.Controls.SetChildIndex(this.semaforoLegenda1, 0);
            // 
            // t�tulo
            // 
            this.t�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tulo.BackColor = System.Drawing.Color.White;
            this.t�tulo.Descri��o = "Nome da pessoa";
            this.t�tulo.�coneArredondado = false;
            this.t�tulo.Imagem = global::Apresenta��o.Resource.moeda;
            this.t�tulo.Location = new System.Drawing.Point(193, 3);
            this.t�tulo.Name = "t�tulo";
            this.t�tulo.Size = new System.Drawing.Size(552, 70);
            this.t�tulo.TabIndex = 6;
            this.t�tulo.T�tulo = "Rela��o de vendas";
            // 
            // quadroOp��esVenda
            // 
            this.quadroOp��esVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroOp��esVenda.bInfDirArredondada = true;
            this.quadroOp��esVenda.bInfEsqArredondada = true;
            this.quadroOp��esVenda.bSupDirArredondada = true;
            this.quadroOp��esVenda.bSupEsqArredondada = true;
            this.quadroOp��esVenda.Controls.Add(this.op��oMoverAcerto);
            this.quadroOp��esVenda.Controls.Add(this.op��oExcluirVendas);
            this.quadroOp��esVenda.Controls.Add(this.op��oRegistrarNovaVenda);
            this.quadroOp��esVenda.Controls.Add(this.op��oProcurar);
            this.quadroOp��esVenda.Controls.Add(this.op��oImpress�o);
            this.quadroOp��esVenda.Cor = System.Drawing.Color.Black;
            this.quadroOp��esVenda.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOp��esVenda.LetraT�tulo = System.Drawing.Color.White;
            this.quadroOp��esVenda.Location = new System.Drawing.Point(7, 13);
            this.quadroOp��esVenda.MostrarBot�oMinMax = false;
            this.quadroOp��esVenda.Name = "quadroOp��esVenda";
            this.quadroOp��esVenda.Size = new System.Drawing.Size(160, 151);
            this.quadroOp��esVenda.TabIndex = 0;
            this.quadroOp��esVenda.Tamanho = 30;
            this.quadroOp��esVenda.T�tulo = "O que quer fazer?";
            // 
            // op��oMoverAcerto
            // 
            this.op��oMoverAcerto.BackColor = System.Drawing.Color.Transparent;
            this.op��oMoverAcerto.Descri��o = "Mover para outro acerto...";
            this.op��oMoverAcerto.Imagem = global::Apresenta��o.Resource.Acerto__Pequeno_;
            this.op��oMoverAcerto.Location = new System.Drawing.Point(5, 106);
            this.op��oMoverAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oMoverAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oMoverAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oMoverAcerto.Name = "op��oMoverAcerto";
            this.op��oMoverAcerto.PermitirLibera��oRecurso = true;
            this.op��oMoverAcerto.Privil�gio = Entidades.Privil�gio.Permiss�o.MoverDocumentoAcerto;
            this.op��oMoverAcerto.Size = new System.Drawing.Size(150, 24);
            this.op��oMoverAcerto.TabIndex = 7;
            this.op��oMoverAcerto.Click += new System.EventHandler(this.op��oMoverAcerto_Click);
            // 
            // op��oExcluirVendas
            // 
            this.op��oExcluirVendas.BackColor = System.Drawing.Color.Transparent;
            this.op��oExcluirVendas.Descri��o = "Excluir vendas...";
            this.op��oExcluirVendas.Imagem = global::Apresenta��o.Resource.Excluir;
            this.op��oExcluirVendas.Location = new System.Drawing.Point(5, 128);
            this.op��oExcluirVendas.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oExcluirVendas.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oExcluirVendas.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oExcluirVendas.Name = "op��oExcluirVendas";
            this.op��oExcluirVendas.Privil�gio = Entidades.Privil�gio.Permiss�o.VendasDestravar;
            this.op��oExcluirVendas.Size = new System.Drawing.Size(150, 24);
            this.op��oExcluirVendas.TabIndex = 9;
            this.op��oExcluirVendas.Click += new System.EventHandler(this.op��oExcluirVendas_Click);
            // 
            // op��oRegistrarNovaVenda
            // 
            this.op��oRegistrarNovaVenda.BackColor = System.Drawing.Color.Transparent;
            this.op��oRegistrarNovaVenda.Descri��o = "Registrar nova venda...";
            this.op��oRegistrarNovaVenda.Imagem = global::Apresenta��o.Resource.NewCardHS;
            this.op��oRegistrarNovaVenda.Location = new System.Drawing.Point(7, 58);
            this.op��oRegistrarNovaVenda.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oRegistrarNovaVenda.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRegistrarNovaVenda.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRegistrarNovaVenda.Name = "op��oRegistrarNovaVenda";
            this.op��oRegistrarNovaVenda.Size = new System.Drawing.Size(150, 24);
            this.op��oRegistrarNovaVenda.TabIndex = 3;
            this.op��oRegistrarNovaVenda.Click += new System.EventHandler(this.op��oRegistrarNovaVenda_Click);
            // 
            // op��oProcurar
            // 
            this.op��oProcurar.BackColor = System.Drawing.Color.Transparent;
            this.op��oProcurar.Descri��o = "Procurar por venda...";
            this.op��oProcurar.Imagem = global::Apresenta��o.Resource.search;
            this.op��oProcurar.Location = new System.Drawing.Point(7, 34);
            this.op��oProcurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oProcurar.Name = "op��oProcurar";
            this.op��oProcurar.Size = new System.Drawing.Size(150, 24);
            this.op��oProcurar.TabIndex = 2;
            this.op��oProcurar.Click += new System.EventHandler(this.op��oProcurar_Click);
            // 
            // op��oImpress�o
            // 
            this.op��oImpress�o.BackColor = System.Drawing.Color.Transparent;
            this.op��oImpress�o.Descri��o = "Imprimir...";
            this.op��oImpress�o.Imagem = global::Apresenta��o.Resource.Impressora_3D;
            this.op��oImpress�o.Location = new System.Drawing.Point(7, 82);
            this.op��oImpress�o.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oImpress�o.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oImpress�o.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oImpress�o.Name = "op��oImpress�o";
            this.op��oImpress�o.Size = new System.Drawing.Size(150, 24);
            this.op��oImpress�o.TabIndex = 4;
            this.op��oImpress�o.Click += new System.EventHandler(this.op��oImpress�o_Click);
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
            this.lista.AoDuploClique += new Apresenta��o.Financeiro.Venda.ListViewVendas.Delega��oVenda(this.lista_AoDuploClique);
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
            this.quadroLista.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroLista.LetraT�tulo = System.Drawing.Color.White;
            this.quadroLista.Location = new System.Drawing.Point(193, 79);
            this.quadroLista.MostrarBot�oMinMax = false;
            this.quadroLista.Name = "quadroLista";
            this.quadroLista.Size = new System.Drawing.Size(594, 328);
            this.quadroLista.TabIndex = 8;
            this.quadroLista.Tamanho = 30;
            this.quadroLista.T�tulo = "Hist�rico de vendas";
            // 
            // quadroComprasDesteFuncion�rio
            // 
            this.quadroComprasDesteFuncion�rio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroComprasDesteFuncion�rio.bInfDirArredondada = true;
            this.quadroComprasDesteFuncion�rio.bInfEsqArredondada = true;
            this.quadroComprasDesteFuncion�rio.bSupDirArredondada = true;
            this.quadroComprasDesteFuncion�rio.bSupEsqArredondada = true;
            this.quadroComprasDesteFuncion�rio.Controls.Add(this.op��oComprasDesteFuncion�rio);
            this.quadroComprasDesteFuncion�rio.Cor = System.Drawing.Color.Black;
            this.quadroComprasDesteFuncion�rio.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroComprasDesteFuncion�rio.LetraT�tulo = System.Drawing.Color.White;
            this.quadroComprasDesteFuncion�rio.Location = new System.Drawing.Point(7, 170);
            this.quadroComprasDesteFuncion�rio.MostrarBot�oMinMax = false;
            this.quadroComprasDesteFuncion�rio.Name = "quadroComprasDesteFuncion�rio";
            this.quadroComprasDesteFuncion�rio.Size = new System.Drawing.Size(160, 52);
            this.quadroComprasDesteFuncion�rio.TabIndex = 1;
            this.quadroComprasDesteFuncion�rio.Tamanho = 30;
            this.quadroComprasDesteFuncion�rio.T�tulo = "Funcion�rio";
            this.quadroComprasDesteFuncion�rio.Visible = false;
            // 
            // op��oComprasDesteFuncion�rio
            // 
            this.op��oComprasDesteFuncion�rio.BackColor = System.Drawing.Color.Transparent;
            this.op��oComprasDesteFuncion�rio.Descri��o = "Visualizar compras";
            this.op��oComprasDesteFuncion�rio.Imagem = global::Apresenta��o.Resource.folderopen1;
            this.op��oComprasDesteFuncion�rio.Location = new System.Drawing.Point(5, 28);
            this.op��oComprasDesteFuncion�rio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oComprasDesteFuncion�rio.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oComprasDesteFuncion�rio.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oComprasDesteFuncion�rio.Name = "op��oComprasDesteFuncion�rio";
            this.op��oComprasDesteFuncion�rio.PermitirLibera��oRecurso = true;
            this.op��oComprasDesteFuncion�rio.Size = new System.Drawing.Size(150, 17);
            this.op��oComprasDesteFuncion�rio.TabIndex = 7;
            this.op��oComprasDesteFuncion�rio.Click += new System.EventHandler(this.op��oComprasDesteFuncion�rio_Click);
            // 
            // semaforoLegenda1
            // 
            this.semaforoLegenda1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.semaforoLegenda1.bInfDirArredondada = true;
            this.semaforoLegenda1.bInfEsqArredondada = true;
            this.semaforoLegenda1.bSupDirArredondada = true;
            this.semaforoLegenda1.bSupEsqArredondada = true;
            this.semaforoLegenda1.Cor = System.Drawing.Color.Black;
            this.semaforoLegenda1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.semaforoLegenda1.LetraT�tulo = System.Drawing.Color.White;
            this.semaforoLegenda1.Location = new System.Drawing.Point(7, 229);
            this.semaforoLegenda1.MostrarBot�oMinMax = false;
            this.semaforoLegenda1.Name = "semaforoLegenda1";
            this.semaforoLegenda1.Size = new System.Drawing.Size(160, 155);
            this.semaforoLegenda1.TabIndex = 2;
            this.semaforoLegenda1.Tamanho = 30;
            this.semaforoLegenda1.T�tulo = "Legenda";
            this.semaforoLegenda1.ClicouNaLegenda += SemaforoLegenda1_aoClicarLegenda;
            // 
            // BaseVendas
            // 
            this.Controls.Add(this.t�tulo);
            this.Controls.Add(this.quadroLista);
            this.Name = "BaseVendas";
            this.Size = new System.Drawing.Size(800, 419);
            this.Controls.SetChildIndex(this.quadroLista, 0);
            this.Controls.SetChildIndex(this.t�tulo, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroOp��esVenda.ResumeLayout(false);
            this.quadroLista.ResumeLayout(false);
            this.quadroComprasDesteFuncion�rio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tulo;
        private Apresenta��o.Formul�rios.Quadro quadroOp��esVenda;
        private Apresenta��o.Formul�rios.Op��o op��oProcurar;
        private Apresenta��o.Formul�rios.Op��o op��oRegistrarNovaVenda;
        private ListViewVendas lista;
        private Apresenta��o.Formul�rios.Quadro quadroLista;
        private Apresenta��o.Formul�rios.Op��o op��oImpress�o;
        private Apresenta��o.Formul�rios.Op��o op��oMoverAcerto;
        private Apresenta��o.Formul�rios.Quadro quadroComprasDesteFuncion�rio;
        private Apresenta��o.Formul�rios.Op��o op��oComprasDesteFuncion�rio;
        private Apresenta��o.Formul�rios.Op��o op��oExcluirVendas;
        private SemaforoLegenda semaforoLegenda1;
    }
}
