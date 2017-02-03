using Apresentação.Fiscal.Combobox;

namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseDocumento
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDocumento));
            this.quadroDocumento = new Apresentação.Formulários.Quadro();
            this.opçãoExcluirDocumento = new Apresentação.Formulários.Opção();
            this.quadroPDF = new Apresentação.Formulários.Quadro();
            this.opçãoExcluirPDF = new Apresentação.Formulários.Opção();
            this.opçãoCarregarPDF = new Apresentação.Formulários.Opção();
            this.opçãoAbrirPDF = new Apresentação.Formulários.Opção();
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabDados = new System.Windows.Forms.TabPage();
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.dados = new Apresentação.Administrativo.Fiscal.BaseInferior.DadosDocumento();
            this.tabItens = new System.Windows.Forms.TabPage();
            this.quadroLista = new Apresentação.Formulários.Quadro();
            this.lstItens = new Apresentação.Fiscal.Lista.ListaItem();
            this.quadroItem = new Apresentação.Formulários.Quadro();
            this.txtMercadoria = new Apresentação.Mercadoria.TxtMercadoriaLivre();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.txtValorTotal = new AMS.TextBox.CurrencyTextBox();
            this.txtValorUnitário = new AMS.TextBox.CurrencyTextBox();
            this.cmbTipoUnidade = new Apresentação.Fiscal.Combobox.ComboTipoUnidade();
            this.txtQuantidade = new AMS.TextBox.NumericTextBox();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabObservações = new System.Windows.Forms.TabPage();
            this.txtObservações = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.esquerda.SuspendLayout();
            this.quadroDocumento.SuspendLayout();
            this.quadroPDF.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabDados.SuspendLayout();
            this.grpDados.SuspendLayout();
            this.tabItens.SuspendLayout();
            this.quadroLista.SuspendLayout();
            this.quadroItem.SuspendLayout();
            this.tabObservações.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPDF);
            this.esquerda.Controls.Add(this.quadroDocumento);
            this.esquerda.Size = new System.Drawing.Size(187, 652);
            this.esquerda.Controls.SetChildIndex(this.quadroDocumento, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroPDF, 0);
            // 
            // quadroDocumento
            // 
            this.quadroDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroDocumento.bInfDirArredondada = true;
            this.quadroDocumento.bInfEsqArredondada = true;
            this.quadroDocumento.bSupDirArredondada = true;
            this.quadroDocumento.bSupEsqArredondada = true;
            this.quadroDocumento.Controls.Add(this.opçãoExcluirDocumento);
            this.quadroDocumento.Cor = System.Drawing.Color.Black;
            this.quadroDocumento.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDocumento.LetraTítulo = System.Drawing.Color.White;
            this.quadroDocumento.Location = new System.Drawing.Point(7, 13);
            this.quadroDocumento.MostrarBotãoMinMax = false;
            this.quadroDocumento.Name = "quadroDocumento";
            this.quadroDocumento.Size = new System.Drawing.Size(160, 56);
            this.quadroDocumento.TabIndex = 1;
            this.quadroDocumento.Tamanho = 30;
            this.quadroDocumento.Título = "Documento";
            // 
            // opçãoExcluirDocumento
            // 
            this.opçãoExcluirDocumento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirDocumento.Descrição = "Excluir";
            this.opçãoExcluirDocumento.Imagem = global::Apresentação.Resource.none;
            this.opçãoExcluirDocumento.Location = new System.Drawing.Point(7, 30);
            this.opçãoExcluirDocumento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluirDocumento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirDocumento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirDocumento.Name = "opçãoExcluirDocumento";
            this.opçãoExcluirDocumento.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluirDocumento.TabIndex = 3;
            this.opçãoExcluirDocumento.Click += new System.EventHandler(this.opçãoExcluirDocumento_Click);
            // 
            // quadroPDF
            // 
            this.quadroPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPDF.bInfDirArredondada = true;
            this.quadroPDF.bInfEsqArredondada = true;
            this.quadroPDF.bSupDirArredondada = true;
            this.quadroPDF.bSupEsqArredondada = true;
            this.quadroPDF.Controls.Add(this.opçãoExcluirPDF);
            this.quadroPDF.Controls.Add(this.opçãoCarregarPDF);
            this.quadroPDF.Controls.Add(this.opçãoAbrirPDF);
            this.quadroPDF.Cor = System.Drawing.Color.Black;
            this.quadroPDF.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPDF.LetraTítulo = System.Drawing.Color.White;
            this.quadroPDF.Location = new System.Drawing.Point(7, 75);
            this.quadroPDF.MostrarBotãoMinMax = false;
            this.quadroPDF.Name = "quadroPDF";
            this.quadroPDF.Size = new System.Drawing.Size(160, 94);
            this.quadroPDF.TabIndex = 2;
            this.quadroPDF.Tamanho = 30;
            this.quadroPDF.Título = "PDF";
            // 
            // opçãoExcluirPDF
            // 
            this.opçãoExcluirPDF.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirPDF.Descrição = "Excluir";
            this.opçãoExcluirPDF.Imagem = global::Apresentação.Resource.none;
            this.opçãoExcluirPDF.Location = new System.Drawing.Point(7, 70);
            this.opçãoExcluirPDF.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluirPDF.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirPDF.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirPDF.Name = "opçãoExcluirPDF";
            this.opçãoExcluirPDF.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluirPDF.TabIndex = 6;
            this.opçãoExcluirPDF.Click += new System.EventHandler(this.opçãoExcluirPDF_Click);
            // 
            // opçãoCarregarPDF
            // 
            this.opçãoCarregarPDF.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCarregarPDF.Descrição = "Carregar";
            this.opçãoCarregarPDF.Imagem = global::Apresentação.Resource.opçãoCarregarPDF1;
            this.opçãoCarregarPDF.Location = new System.Drawing.Point(7, 50);
            this.opçãoCarregarPDF.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCarregarPDF.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCarregarPDF.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCarregarPDF.Name = "opçãoCarregarPDF";
            this.opçãoCarregarPDF.Size = new System.Drawing.Size(150, 16);
            this.opçãoCarregarPDF.TabIndex = 5;
            this.opçãoCarregarPDF.Click += new System.EventHandler(this.opçãoCarregarPDF_Click);
            // 
            // opçãoAbrirPDF
            // 
            this.opçãoAbrirPDF.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrirPDF.Descrição = "Abrir";
            this.opçãoAbrirPDF.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAbrirPDF.Imagem")));
            this.opçãoAbrirPDF.Location = new System.Drawing.Point(7, 30);
            this.opçãoAbrirPDF.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAbrirPDF.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrirPDF.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrirPDF.Name = "opçãoAbrirPDF";
            this.opçãoAbrirPDF.Size = new System.Drawing.Size(150, 18);
            this.opçãoAbrirPDF.TabIndex = 4;
            this.opçãoAbrirPDF.Click += new System.EventHandler(this.opçãoAbrirPDF_Click);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Descrição";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.fiscal1;
            this.título.Location = new System.Drawing.Point(197, 13);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(913, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Editar documento fiscal";
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabDados);
            this.tab.Controls.Add(this.tabItens);
            this.tab.Controls.Add(this.tabObservações);
            this.tab.ImageList = this.imageList1;
            this.tab.Location = new System.Drawing.Point(193, 85);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(939, 555);
            this.tab.TabIndex = 7;
            // 
            // tabDados
            // 
            this.tabDados.Controls.Add(this.grpDados);
            this.tabDados.ImageIndex = 2;
            this.tabDados.Location = new System.Drawing.Point(4, 23);
            this.tabDados.Name = "tabDados";
            this.tabDados.Padding = new System.Windows.Forms.Padding(3);
            this.tabDados.Size = new System.Drawing.Size(931, 528);
            this.tabDados.TabIndex = 0;
            this.tabDados.Text = "Dados";
            this.tabDados.UseVisualStyleBackColor = true;
            // 
            // grpDados
            // 
            this.grpDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDados.Controls.Add(this.dados);
            this.grpDados.Location = new System.Drawing.Point(6, 6);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(919, 516);
            this.grpDados.TabIndex = 0;
            this.grpDados.TabStop = false;
            this.grpDados.Text = "Dados do documento";
            // 
            // dados
            // 
            this.dados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dados.Location = new System.Drawing.Point(3, 16);
            this.dados.Name = "dados";
            this.dados.Size = new System.Drawing.Size(913, 497);
            this.dados.TabIndex = 0;
            // 
            // tabItens
            // 
            this.tabItens.Controls.Add(this.quadroLista);
            this.tabItens.Controls.Add(this.quadroItem);
            this.tabItens.ImageKey = "bandeira.png";
            this.tabItens.Location = new System.Drawing.Point(4, 23);
            this.tabItens.Name = "tabItens";
            this.tabItens.Padding = new System.Windows.Forms.Padding(3);
            this.tabItens.Size = new System.Drawing.Size(931, 528);
            this.tabItens.TabIndex = 1;
            this.tabItens.Text = "Itens";
            this.tabItens.UseVisualStyleBackColor = true;
            // 
            // quadroLista
            // 
            this.quadroLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroLista.bInfDirArredondada = false;
            this.quadroLista.bInfEsqArredondada = false;
            this.quadroLista.bSupDirArredondada = true;
            this.quadroLista.bSupEsqArredondada = true;
            this.quadroLista.Controls.Add(this.lstItens);
            this.quadroLista.Cor = System.Drawing.Color.Black;
            this.quadroLista.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroLista.LetraTítulo = System.Drawing.Color.White;
            this.quadroLista.Location = new System.Drawing.Point(6, 156);
            this.quadroLista.MostrarBotãoMinMax = false;
            this.quadroLista.Name = "quadroLista";
            this.quadroLista.Size = new System.Drawing.Size(919, 369);
            this.quadroLista.TabIndex = 2;
            this.quadroLista.Tamanho = 30;
            this.quadroLista.Título = "Mercadorias";
            // 
            // lstItens
            // 
            this.lstItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItens.Location = new System.Drawing.Point(0, 24);
            this.lstItens.Name = "lstItens";
            this.lstItens.Size = new System.Drawing.Size(919, 345);
            this.lstItens.TabIndex = 9;
            this.lstItens.AoSelecionar += new Apresentação.Fiscal.Lista.ListaItem.AoSelecionarDelegate(this.lstItens_AoSelecionar);
            this.lstItens.AoExcluir += new System.EventHandler(this.lstItens_AoExcluir);
            // 
            // quadroItem
            // 
            this.quadroItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroItem.bInfDirArredondada = true;
            this.quadroItem.bInfEsqArredondada = true;
            this.quadroItem.bSupDirArredondada = true;
            this.quadroItem.bSupEsqArredondada = true;
            this.quadroItem.Controls.Add(this.txtMercadoria);
            this.quadroItem.Controls.Add(this.btnIncluir);
            this.quadroItem.Controls.Add(this.txtValorTotal);
            this.quadroItem.Controls.Add(this.txtValorUnitário);
            this.quadroItem.Controls.Add(this.cmbTipoUnidade);
            this.quadroItem.Controls.Add(this.txtQuantidade);
            this.quadroItem.Controls.Add(this.txtCFOP);
            this.quadroItem.Controls.Add(this.label12);
            this.quadroItem.Controls.Add(this.label11);
            this.quadroItem.Controls.Add(this.label10);
            this.quadroItem.Controls.Add(this.label9);
            this.quadroItem.Controls.Add(this.btnExcluir);
            this.quadroItem.Controls.Add(this.btnAlterar);
            this.quadroItem.Controls.Add(this.txtDescrição);
            this.quadroItem.Controls.Add(this.label8);
            this.quadroItem.Controls.Add(this.label7);
            this.quadroItem.Controls.Add(this.label4);
            this.quadroItem.Cor = System.Drawing.Color.Black;
            this.quadroItem.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroItem.LetraTítulo = System.Drawing.Color.White;
            this.quadroItem.Location = new System.Drawing.Point(6, 11);
            this.quadroItem.MostrarBotãoMinMax = false;
            this.quadroItem.Name = "quadroItem";
            this.quadroItem.Size = new System.Drawing.Size(919, 139);
            this.quadroItem.TabIndex = 1;
            this.quadroItem.Tamanho = 30;
            this.quadroItem.Título = "Detalhe do item";
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.Location = new System.Drawing.Point(19, 44);
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Referência = "";
            this.txtMercadoria.Size = new System.Drawing.Size(180, 23);
            this.txtMercadoria.TabIndex = 13;
            this.txtMercadoria.ReferênciaAlterada += new System.EventHandler(this.txtMercadoria_ReferênciaAlterada);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncluir.Location = new System.Drawing.Point(828, 99);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 8;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.AllowNegative = true;
            this.txtValorTotal.Flags = 7680;
            this.txtValorTotal.Location = new System.Drawing.Point(501, 102);
            this.txtValorTotal.MaxWholeDigits = 9;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.RangeMax = 1.7976931348623157E+308D;
            this.txtValorTotal.RangeMin = -1.7976931348623157E+308D;
            this.txtValorTotal.Size = new System.Drawing.Size(94, 20);
            this.txtValorTotal.TabIndex = 6;
            // 
            // txtValorUnitário
            // 
            this.txtValorUnitário.AllowNegative = true;
            this.txtValorUnitário.Flags = 7680;
            this.txtValorUnitário.Location = new System.Drawing.Point(396, 102);
            this.txtValorUnitário.MaxWholeDigits = 9;
            this.txtValorUnitário.Name = "txtValorUnitário";
            this.txtValorUnitário.RangeMax = 1.7976931348623157E+308D;
            this.txtValorUnitário.RangeMin = -1.7976931348623157E+308D;
            this.txtValorUnitário.Size = new System.Drawing.Size(96, 20);
            this.txtValorUnitário.TabIndex = 5;
            // 
            // cmbTipoUnidade
            // 
            this.cmbTipoUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoUnidade.FormattingEnabled = true;
            this.cmbTipoUnidade.Location = new System.Drawing.Point(284, 102);
            this.cmbTipoUnidade.Name = "cmbTipoUnidade";
            this.cmbTipoUnidade.Seleção = null;
            this.cmbTipoUnidade.Size = new System.Drawing.Size(100, 21);
            this.cmbTipoUnidade.TabIndex = 4;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.AllowNegative = true;
            this.txtQuantidade.DigitsInGroup = 0;
            this.txtQuantidade.Flags = 0;
            this.txtQuantidade.Location = new System.Drawing.Point(207, 102);
            this.txtQuantidade.MaxDecimalPlaces = 4;
            this.txtQuantidade.MaxWholeDigits = 9;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Prefix = "";
            this.txtQuantidade.RangeMax = 1.7976931348623157E+308D;
            this.txtQuantidade.RangeMin = -1.7976931348623157E+308D;
            this.txtQuantidade.Size = new System.Drawing.Size(59, 20);
            this.txtQuantidade.TabIndex = 3;
            // 
            // txtCFOP
            // 
            this.txtCFOP.Location = new System.Drawing.Point(19, 102);
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.Size = new System.Drawing.Size(160, 20);
            this.txtCFOP.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(498, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Valor Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(393, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Valor Unitário";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(281, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Tipo de Unidade";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Quantidade";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(747, 99);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 7;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterar.Location = new System.Drawing.Point(828, 99);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 7;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Visible = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Location = new System.Drawing.Point(207, 47);
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(700, 20);
            this.txtDescrição.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Descrição";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "CFOP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Referência";
            // 
            // tabObservações
            // 
            this.tabObservações.Controls.Add(this.txtObservações);
            this.tabObservações.ImageIndex = 1;
            this.tabObservações.Location = new System.Drawing.Point(4, 23);
            this.tabObservações.Name = "tabObservações";
            this.tabObservações.Padding = new System.Windows.Forms.Padding(3);
            this.tabObservações.Size = new System.Drawing.Size(931, 528);
            this.tabObservações.TabIndex = 2;
            this.tabObservações.Text = "Observações";
            this.tabObservações.UseVisualStyleBackColor = true;
            // 
            // txtObservações
            // 
            this.txtObservações.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservações.Location = new System.Drawing.Point(3, 3);
            this.txtObservações.Multiline = true;
            this.txtObservações.Name = "txtObservações";
            this.txtObservações.Size = new System.Drawing.Size(925, 522);
            this.txtObservações.TabIndex = 0;
            this.txtObservações.Validated += new System.EventHandler(this.txtObservações_Validated);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bandeira.png");
            this.imageList1.Images.SetKeyName(1, "caderno.png");
            this.imageList1.Images.SetKeyName(2, "info.png");
            // 
            // BaseDocumento
            // 
            this.Controls.Add(this.tab);
            this.Controls.Add(this.título);
            this.MinimumSize = new System.Drawing.Size(989, 373);
            this.Name = "BaseDocumento";
            this.Size = new System.Drawing.Size(1135, 652);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroDocumento.ResumeLayout(false);
            this.quadroPDF.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabDados.ResumeLayout(false);
            this.grpDados.ResumeLayout(false);
            this.tabItens.ResumeLayout(false);
            this.quadroLista.ResumeLayout(false);
            this.quadroItem.ResumeLayout(false);
            this.quadroItem.PerformLayout();
            this.tabObservações.ResumeLayout(false);
            this.tabObservações.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadroDocumento;
        private Formulários.Quadro quadroPDF;
        private Formulários.Opção opçãoExcluirPDF;
        private Formulários.Opção opçãoCarregarPDF;
        private Formulários.Opção opçãoAbrirPDF;
        private Formulários.Opção opçãoExcluirDocumento;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabDados;
        private System.Windows.Forms.TabPage tabItens;
        private System.Windows.Forms.TabPage tabObservações;
        protected Formulários.TítuloBaseInferior título;
        protected System.Windows.Forms.GroupBox grpDados;
        private Formulários.Quadro quadroLista;
        private Formulários.Quadro quadroItem;
        private Lista.ListaItem lstItens;
        private AMS.TextBox.NumericTextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtCFOP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private AMS.TextBox.CurrencyTextBox txtValorTotal;
        private AMS.TextBox.CurrencyTextBox txtValorUnitário;
        private ComboTipoUnidade cmbTipoUnidade;
        private System.Windows.Forms.TextBox txtObservações;
        private System.Windows.Forms.Button btnIncluir;
        protected Administrativo.Fiscal.BaseInferior.DadosDocumento dados;
        private System.Windows.Forms.ImageList imageList1;
        private Mercadoria.TxtMercadoriaLivre txtMercadoria;
    }
}
