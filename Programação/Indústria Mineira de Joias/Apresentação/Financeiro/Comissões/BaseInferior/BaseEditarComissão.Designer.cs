namespace Apresentação.Financeiro.Comissões.BaseInferior
{
    partial class BaseEditarComissão
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEditarComissão));
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabVendedores = new System.Windows.Forms.TabPage();
            this.lstComissionados = new Apresentação.Financeiro.Comissões.ListViewComissionados();
            this.tabVendas = new System.Windows.Forms.TabPage();
            this.aberturaVenda = new Apresentação.Financeiro.Comissões.ControleAberturaVenda();
            this.tabEstornos = new System.Windows.Forms.TabPage();
            this.aberturaEstorno = new Apresentação.Financeiro.Comissões.ControleAberturaVenda();
            this.tabAjuda = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.imagens = new System.Windows.Forms.ImageList(this.components);
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoSetor = new Apresentação.Formulários.Opção();
            this.opçãoVendaItem = new Apresentação.Formulários.Opção();
            this.opçãoRelatórioCompartilhada = new Apresentação.Formulários.Opção();
            this.opçãoRelatórioRegraPessoa = new Apresentação.Formulários.Opção();
            this.opçãoImprimirTodos = new Apresentação.Formulários.Opção();
            this.opçãoRelatórioResumo = new Apresentação.Formulários.Opção();
            this.opçãoRelatórioPorVenda = new Apresentação.Formulários.Opção();
            this.quadroFiltrarExibição = new Apresentação.Formulários.Quadro();
            this.iconeDataFinal = new System.Windows.Forms.Panel();
            this.iconeDataInicial = new System.Windows.Forms.Panel();
            this.iconeFiltroPessoa = new System.Windows.Forms.Panel();
            this.dataFinal = new System.Windows.Forms.DateTimePicker();
            this.opçãoCancelarFiltros = new Apresentação.Formulários.Opção();
            this.opçãoAplicarFiltros = new Apresentação.Formulários.Opção();
            this.dataInicial = new System.Windows.Forms.DateTimePicker();
            this.comboboxFuncionário = new Apresentação.Pessoa.ComboboxFuncionário();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.opçãoRecarregar = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabVendedores.SuspendLayout();
            this.tabVendas.SuspendLayout();
            this.tabEstornos.SuspendLayout();
            this.tabAjuda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroFiltrarExibição.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Controls.Add(this.quadroFiltrarExibição);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 644);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroFiltrarExibição, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Comissão de teste";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.giveMoney;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(607, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Edição de comissão No. 25 - Fevereiro / 2014";
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabVendedores);
            this.tabs.Controls.Add(this.tabVendas);
            this.tabs.Controls.Add(this.tabEstornos);
            this.tabs.Controls.Add(this.tabAjuda);
            this.tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabs.ImageList = this.imagens;
            this.tabs.Location = new System.Drawing.Point(196, 82);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(604, 562);
            this.tabs.TabIndex = 7;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabVendedores
            // 
            this.tabVendedores.Controls.Add(this.lstComissionados);
            this.tabVendedores.ImageIndex = 5;
            this.tabVendedores.Location = new System.Drawing.Point(4, 23);
            this.tabVendedores.Name = "tabVendedores";
            this.tabVendedores.Padding = new System.Windows.Forms.Padding(3);
            this.tabVendedores.Size = new System.Drawing.Size(596, 535);
            this.tabVendedores.TabIndex = 0;
            this.tabVendedores.Text = "Vendedores";
            this.tabVendedores.UseVisualStyleBackColor = true;
            // 
            // lstComissionados
            // 
            this.lstComissionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstComissionados.Location = new System.Drawing.Point(3, 3);
            this.lstComissionados.Name = "lstComissionados";
            this.lstComissionados.Size = new System.Drawing.Size(590, 529);
            this.lstComissionados.TabIndex = 0;
            // 
            // tabVendas
            // 
            this.tabVendas.Controls.Add(this.aberturaVenda);
            this.tabVendas.ImageIndex = 3;
            this.tabVendas.Location = new System.Drawing.Point(4, 23);
            this.tabVendas.Name = "tabVendas";
            this.tabVendas.Padding = new System.Windows.Forms.Padding(3);
            this.tabVendas.Size = new System.Drawing.Size(596, 535);
            this.tabVendas.TabIndex = 1;
            this.tabVendas.Text = "Vendas";
            this.tabVendas.UseVisualStyleBackColor = true;
            // 
            // aberturaVenda
            // 
            this.aberturaVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aberturaVenda.Location = new System.Drawing.Point(3, 3);
            this.aberturaVenda.Name = "aberturaVenda";
            this.aberturaVenda.Size = new System.Drawing.Size(590, 529);
            this.aberturaVenda.TabIndex = 0;
            this.aberturaVenda.AoSolicitarAbrirVenda += new Apresentação.Financeiro.Comissões.Delegate.VendaDelegate(this.aberturaVenda_AoSolicitarAbrirVenda);
            this.aberturaVenda.AoSolicitarAbrirAtendimentoPessoa += new Apresentação.Financeiro.Comissões.Delegate.PessoaDelegate(this.aberturaVenda_AoSolicitarAbrirAtendimentoPessoa);
            // 
            // tabEstornos
            // 
            this.tabEstornos.Controls.Add(this.aberturaEstorno);
            this.tabEstornos.ImageKey = "relatório.gif";
            this.tabEstornos.Location = new System.Drawing.Point(4, 23);
            this.tabEstornos.Name = "tabEstornos";
            this.tabEstornos.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstornos.Size = new System.Drawing.Size(596, 535);
            this.tabEstornos.TabIndex = 2;
            this.tabEstornos.Text = "Estornos";
            this.tabEstornos.UseVisualStyleBackColor = true;
            // 
            // aberturaEstorno
            // 
            this.aberturaEstorno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aberturaEstorno.Location = new System.Drawing.Point(3, 3);
            this.aberturaEstorno.Name = "aberturaEstorno";
            this.aberturaEstorno.Size = new System.Drawing.Size(590, 529);
            this.aberturaEstorno.TabIndex = 0;
            this.aberturaEstorno.AoSolicitarAbrirVenda += new Apresentação.Financeiro.Comissões.Delegate.VendaDelegate(this.aberturaVenda_AoSolicitarAbrirVenda);
            this.aberturaEstorno.AoSolicitarAbrirAtendimentoPessoa += new Apresentação.Financeiro.Comissões.Delegate.PessoaDelegate(this.aberturaVenda_AoSolicitarAbrirAtendimentoPessoa);
            // 
            // tabAjuda
            // 
            this.tabAjuda.Controls.Add(this.richTextBox1);
            this.tabAjuda.ImageIndex = 6;
            this.tabAjuda.Location = new System.Drawing.Point(4, 23);
            this.tabAjuda.Name = "tabAjuda";
            this.tabAjuda.Padding = new System.Windows.Forms.Padding(3);
            this.tabAjuda.Size = new System.Drawing.Size(596, 535);
            this.tabAjuda.TabIndex = 3;
            this.tabAjuda.Text = "Ajuda";
            this.tabAjuda.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(590, 529);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // imagens
            // 
            this.imagens.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagens.ImageStream")));
            this.imagens.TransparentColor = System.Drawing.Color.Transparent;
            this.imagens.Images.SetKeyName(0, "fasten.gif");
            this.imagens.Images.SetKeyName(1, "Aperto de mão 2 (transparente).png");
            this.imagens.Images.SetKeyName(2, "botão - pessoas.png");
            this.imagens.Images.SetKeyName(3, "relatório.gif");
            this.imagens.Images.SetKeyName(4, "img_ama.png");
            this.imagens.Images.SetKeyName(5, "grupos.gif");
            this.imagens.Images.SetKeyName(6, "info_blue.png");
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoSetor);
            this.quadro1.Controls.Add(this.opçãoVendaItem);
            this.quadro1.Controls.Add(this.opçãoRelatórioCompartilhada);
            this.quadro1.Controls.Add(this.opçãoRelatórioRegraPessoa);
            this.quadro1.Controls.Add(this.opçãoImprimirTodos);
            this.quadro1.Controls.Add(this.opçãoRelatórioResumo);
            this.quadro1.Controls.Add(this.opçãoRelatórioPorVenda);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 223);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 178);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Relatórios";
            // 
            // opçãoSetor
            // 
            this.opçãoSetor.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSetor.Descrição = "Setor";
            this.opçãoSetor.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoSetor.Location = new System.Drawing.Point(7, 50);
            this.opçãoSetor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoSetor.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSetor.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSetor.Name = "opçãoSetor";
            this.opçãoSetor.Size = new System.Drawing.Size(150, 16);
            this.opçãoSetor.TabIndex = 10;
            this.opçãoSetor.Click += new System.EventHandler(this.opçãoSetor_Click);
            // 
            // opçãoVendaItem
            // 
            this.opçãoVendaItem.BackColor = System.Drawing.Color.Transparent;
            this.opçãoVendaItem.Descrição = "Item";
            this.opçãoVendaItem.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVendaItem.Imagem")));
            this.opçãoVendaItem.Location = new System.Drawing.Point(7, 110);
            this.opçãoVendaItem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVendaItem.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVendaItem.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVendaItem.Name = "opçãoVendaItem";
            this.opçãoVendaItem.Size = new System.Drawing.Size(150, 16);
            this.opçãoVendaItem.TabIndex = 9;
            this.opçãoVendaItem.Click += new System.EventHandler(this.opçãoVendaItem_Click);
            // 
            // opçãoRelatórioCompartilhada
            // 
            this.opçãoRelatórioCompartilhada.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRelatórioCompartilhada.Descrição = "Compartilhada";
            this.opçãoRelatórioCompartilhada.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoRelatórioCompartilhada.Imagem")));
            this.opçãoRelatórioCompartilhada.Location = new System.Drawing.Point(7, 130);
            this.opçãoRelatórioCompartilhada.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRelatórioCompartilhada.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRelatórioCompartilhada.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRelatórioCompartilhada.Name = "opçãoRelatórioCompartilhada";
            this.opçãoRelatórioCompartilhada.Size = new System.Drawing.Size(150, 16);
            this.opçãoRelatórioCompartilhada.TabIndex = 8;
            this.opçãoRelatórioCompartilhada.Click += new System.EventHandler(this.opçãoRelatórioCompartilhada_Click);
            // 
            // opçãoRelatórioRegraPessoa
            // 
            this.opçãoRelatórioRegraPessoa.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRelatórioRegraPessoa.Descrição = "Regra";
            this.opçãoRelatórioRegraPessoa.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoRelatórioRegraPessoa.Imagem")));
            this.opçãoRelatórioRegraPessoa.Location = new System.Drawing.Point(7, 70);
            this.opçãoRelatórioRegraPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRelatórioRegraPessoa.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRelatórioRegraPessoa.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRelatórioRegraPessoa.Name = "opçãoRelatórioRegraPessoa";
            this.opçãoRelatórioRegraPessoa.Size = new System.Drawing.Size(150, 17);
            this.opçãoRelatórioRegraPessoa.TabIndex = 7;
            this.opçãoRelatórioRegraPessoa.Click += new System.EventHandler(this.opçãoRelatórioRegraPessoa_Click);
            // 
            // opçãoImprimirTodos
            // 
            this.opçãoImprimirTodos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimirTodos.Descrição = "Mostrar Todos";
            this.opçãoImprimirTodos.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImprimirTodos.Imagem")));
            this.opçãoImprimirTodos.Location = new System.Drawing.Point(7, 150);
            this.opçãoImprimirTodos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimirTodos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimirTodos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimirTodos.Name = "opçãoImprimirTodos";
            this.opçãoImprimirTodos.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimirTodos.TabIndex = 6;
            this.opçãoImprimirTodos.Click += new System.EventHandler(this.opçãoImprimirTodos_Click);
            // 
            // opçãoRelatórioResumo
            // 
            this.opçãoRelatórioResumo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRelatórioResumo.Descrição = "Resumo";
            this.opçãoRelatórioResumo.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoRelatórioResumo.Location = new System.Drawing.Point(7, 30);
            this.opçãoRelatórioResumo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRelatórioResumo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRelatórioResumo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRelatórioResumo.Name = "opçãoRelatórioResumo";
            this.opçãoRelatórioResumo.Size = new System.Drawing.Size(150, 16);
            this.opçãoRelatórioResumo.TabIndex = 5;
            this.opçãoRelatórioResumo.Click += new System.EventHandler(this.opçãoRelatórioResumo_Click);
            // 
            // opçãoRelatórioPorVenda
            // 
            this.opçãoRelatórioPorVenda.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRelatórioPorVenda.Descrição = "Venda";
            this.opçãoRelatórioPorVenda.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoRelatórioPorVenda.Imagem")));
            this.opçãoRelatórioPorVenda.Location = new System.Drawing.Point(7, 90);
            this.opçãoRelatórioPorVenda.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRelatórioPorVenda.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRelatórioPorVenda.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRelatórioPorVenda.Name = "opçãoRelatórioPorVenda";
            this.opçãoRelatórioPorVenda.Size = new System.Drawing.Size(150, 16);
            this.opçãoRelatórioPorVenda.TabIndex = 4;
            this.opçãoRelatórioPorVenda.Click += new System.EventHandler(this.opçãoRelatórioPorVenda_Click);
            // 
            // quadroFiltrarExibição
            // 
            this.quadroFiltrarExibição.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroFiltrarExibição.bInfDirArredondada = true;
            this.quadroFiltrarExibição.bInfEsqArredondada = true;
            this.quadroFiltrarExibição.bSupDirArredondada = true;
            this.quadroFiltrarExibição.bSupEsqArredondada = true;
            this.quadroFiltrarExibição.Controls.Add(this.iconeDataFinal);
            this.quadroFiltrarExibição.Controls.Add(this.iconeDataInicial);
            this.quadroFiltrarExibição.Controls.Add(this.iconeFiltroPessoa);
            this.quadroFiltrarExibição.Controls.Add(this.dataFinal);
            this.quadroFiltrarExibição.Controls.Add(this.opçãoCancelarFiltros);
            this.quadroFiltrarExibição.Controls.Add(this.opçãoAplicarFiltros);
            this.quadroFiltrarExibição.Controls.Add(this.dataInicial);
            this.quadroFiltrarExibição.Controls.Add(this.comboboxFuncionário);
            this.quadroFiltrarExibição.Cor = System.Drawing.Color.Black;
            this.quadroFiltrarExibição.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFiltrarExibição.LetraTítulo = System.Drawing.Color.White;
            this.quadroFiltrarExibição.Location = new System.Drawing.Point(7, 79);
            this.quadroFiltrarExibição.MostrarBotãoMinMax = false;
            this.quadroFiltrarExibição.Name = "quadroFiltrarExibição";
            this.quadroFiltrarExibição.Size = new System.Drawing.Size(160, 138);
            this.quadroFiltrarExibição.TabIndex = 4;
            this.quadroFiltrarExibição.Tamanho = 30;
            this.quadroFiltrarExibição.Título = "Filtro";
            // 
            // iconeDataFinal
            // 
            this.iconeDataFinal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconeDataFinal.BackColor = System.Drawing.Color.Transparent;
            this.iconeDataFinal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeDataFinal.BackgroundImage")));
            this.iconeDataFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconeDataFinal.Location = new System.Drawing.Point(7, 72);
            this.iconeDataFinal.Name = "iconeDataFinal";
            this.iconeDataFinal.Size = new System.Drawing.Size(18, 16);
            this.iconeDataFinal.TabIndex = 11;
            this.iconeDataFinal.Click += new System.EventHandler(this.iconeDataFinal_Click);
            this.iconeDataFinal.MouseLeave += new System.EventHandler(this.iconeDataFinal_MouseLeave);
            this.iconeDataFinal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iconeFiltroPessoa_MouseMove);
            // 
            // iconeDataInicial
            // 
            this.iconeDataInicial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconeDataInicial.BackColor = System.Drawing.Color.Transparent;
            this.iconeDataInicial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeDataInicial.BackgroundImage")));
            this.iconeDataInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconeDataInicial.Location = new System.Drawing.Point(7, 52);
            this.iconeDataInicial.Name = "iconeDataInicial";
            this.iconeDataInicial.Size = new System.Drawing.Size(18, 16);
            this.iconeDataInicial.TabIndex = 10;
            this.iconeDataInicial.Click += new System.EventHandler(this.iconeDataInicial_Click);
            this.iconeDataInicial.MouseLeave += new System.EventHandler(this.iconeDataFinal_MouseLeave);
            this.iconeDataInicial.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iconeFiltroPessoa_MouseMove);
            // 
            // iconeFiltroPessoa
            // 
            this.iconeFiltroPessoa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconeFiltroPessoa.BackColor = System.Drawing.Color.Transparent;
            this.iconeFiltroPessoa.BackgroundImage = global::Apresentação.Resource.search4people;
            this.iconeFiltroPessoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconeFiltroPessoa.Location = new System.Drawing.Point(7, 30);
            this.iconeFiltroPessoa.Name = "iconeFiltroPessoa";
            this.iconeFiltroPessoa.Size = new System.Drawing.Size(18, 16);
            this.iconeFiltroPessoa.TabIndex = 9;
            this.iconeFiltroPessoa.Click += new System.EventHandler(this.iconeFiltroPessoa_Click);
            this.iconeFiltroPessoa.MouseLeave += new System.EventHandler(this.iconeDataFinal_MouseLeave);
            this.iconeFiltroPessoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iconeFiltroPessoa_MouseMove);
            // 
            // dataFinal
            // 
            this.dataFinal.Checked = false;
            this.dataFinal.Enabled = false;
            this.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFinal.Location = new System.Drawing.Point(40, 72);
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.Size = new System.Drawing.Size(110, 20);
            this.dataFinal.TabIndex = 8;
            this.dataFinal.ValueChanged += new System.EventHandler(this.dataFinal_ValueChanged);
            this.dataFinal.Validating += new System.ComponentModel.CancelEventHandler(this.dataFinal_Validating);
            // 
            // opçãoCancelarFiltros
            // 
            this.opçãoCancelarFiltros.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCancelarFiltros.Descrição = "Cancelar";
            this.opçãoCancelarFiltros.Imagem = global::Apresentação.Resource.Edit_UndoHS;
            this.opçãoCancelarFiltros.Location = new System.Drawing.Point(7, 117);
            this.opçãoCancelarFiltros.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCancelarFiltros.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCancelarFiltros.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCancelarFiltros.Name = "opçãoCancelarFiltros";
            this.opçãoCancelarFiltros.Size = new System.Drawing.Size(150, 18);
            this.opçãoCancelarFiltros.TabIndex = 7;
            this.opçãoCancelarFiltros.Visible = false;
            this.opçãoCancelarFiltros.Click += new System.EventHandler(this.opçãoCancelar_Click);
            // 
            // opçãoAplicarFiltros
            // 
            this.opçãoAplicarFiltros.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAplicarFiltros.Descrição = "Aplicar";
            this.opçãoAplicarFiltros.Imagem = global::Apresentação.Resource.Flag_greenHS;
            this.opçãoAplicarFiltros.Location = new System.Drawing.Point(7, 97);
            this.opçãoAplicarFiltros.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAplicarFiltros.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAplicarFiltros.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAplicarFiltros.Name = "opçãoAplicarFiltros";
            this.opçãoAplicarFiltros.Size = new System.Drawing.Size(150, 16);
            this.opçãoAplicarFiltros.TabIndex = 6;
            this.opçãoAplicarFiltros.Visible = false;
            this.opçãoAplicarFiltros.Click += new System.EventHandler(this.opçãoAplicarFiltros_Click);
            // 
            // dataInicial
            // 
            this.dataInicial.Checked = false;
            this.dataInicial.Enabled = false;
            this.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInicial.Location = new System.Drawing.Point(40, 52);
            this.dataInicial.Name = "dataInicial";
            this.dataInicial.Size = new System.Drawing.Size(110, 20);
            this.dataInicial.TabIndex = 2;
            this.dataInicial.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dataInicial.Validating += new System.ComponentModel.CancelEventHandler(this.dataInicial_Validating);
            // 
            // comboboxFuncionário
            // 
            this.comboboxFuncionário.Enabled = false;
            this.comboboxFuncionário.Funcionário = null;
            this.comboboxFuncionário.Location = new System.Drawing.Point(40, 30);
            this.comboboxFuncionário.Name = "comboboxFuncionário";
            this.comboboxFuncionário.Size = new System.Drawing.Size(110, 21);
            this.comboboxFuncionário.TabIndex = 4;
            this.comboboxFuncionário.FuncionárioAlterado += new System.EventHandler(this.comboboxFuncionário_FuncionárioAlterado);
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.opçãoRecarregar);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 13);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 60);
            this.quadro3.TabIndex = 5;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Recarregar";
            this.quadro3.Visible = false;
            // 
            // opçãoRecarregar
            // 
            this.opçãoRecarregar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRecarregar.Descrição = "Recarregar";
            this.opçãoRecarregar.Imagem = global::Apresentação.Resource.Arrow;
            this.opçãoRecarregar.Location = new System.Drawing.Point(7, 30);
            this.opçãoRecarregar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRecarregar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRecarregar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRecarregar.Name = "opçãoRecarregar";
            this.opçãoRecarregar.Size = new System.Drawing.Size(150, 24);
            this.opçãoRecarregar.TabIndex = 2;
            this.opçãoRecarregar.Click += new System.EventHandler(this.opçãoRecarregar_Click);
            // 
            // BaseEditarComissão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.tabs);
            this.Name = "BaseEditarComissão";
            this.Size = new System.Drawing.Size(800, 644);
            this.Controls.SetChildIndex(this.tabs, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabVendedores.ResumeLayout(false);
            this.tabVendas.ResumeLayout(false);
            this.tabEstornos.ResumeLayout(false);
            this.tabAjuda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroFiltrarExibição.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabVendedores;
        private System.Windows.Forms.TabPage tabVendas;
        private System.Windows.Forms.ImageList imagens;
        private Formulários.Quadro quadroFiltrarExibição;
        private Formulários.Quadro quadro1;
        private Pessoa.ComboboxFuncionário comboboxFuncionário;
        private Formulários.Opção opçãoImprimirTodos;
        private Formulários.Opção opçãoRelatórioResumo;
        private Formulários.Opção opçãoRelatórioPorVenda;
        private System.Windows.Forms.DateTimePicker dataInicial;
        private Formulários.Opção opçãoAplicarFiltros;
        private Formulários.Opção opçãoCancelarFiltros;
        private Formulários.Quadro quadro3;
        private Formulários.Opção opçãoRecarregar;
        private ListViewComissionados lstComissionados;
        private System.Windows.Forms.DateTimePicker dataFinal;
        private ControleAberturaVenda aberturaVenda;
        private System.Windows.Forms.TabPage tabEstornos;
        private System.Windows.Forms.Panel iconeDataFinal;
        private System.Windows.Forms.Panel iconeDataInicial;
        private System.Windows.Forms.Panel iconeFiltroPessoa;
        private ControleAberturaVenda aberturaEstorno;
        private Formulários.Opção opçãoRelatórioRegraPessoa;
        private Formulários.Opção opçãoRelatórioCompartilhada;
        private System.Windows.Forms.TabPage tabAjuda;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Formulários.Opção opçãoVendaItem;
        private Formulários.Opção opçãoSetor;
    }
}
