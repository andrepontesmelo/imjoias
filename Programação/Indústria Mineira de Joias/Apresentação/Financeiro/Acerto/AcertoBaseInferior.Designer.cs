namespace Apresentação.Financeiro.Acerto
{
    partial class AcertoBaseInferior
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
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadroImpressão = new Apresentação.Formulários.Quadro();
            this.opçãoZerarAcerto = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroRastro = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.opçãoRastro = new Apresentação.Formulários.Opção();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.dataFinal = new System.Windows.Forms.DateTimePicker();
            this.dataInício = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAcerto = new System.Windows.Forms.TabPage();
            this.bandejaAcerto = new Apresentação.Financeiro.Acerto.BandejaAcerto();
            this.tabSaída = new System.Windows.Forms.TabPage();
            this.listaSaídas = new Apresentação.Financeiro.Saída.ListaSaídas();
            this.tabVendas = new System.Windows.Forms.TabPage();
            this.listaVendas = new Apresentação.Financeiro.Venda.ListViewVendas();
            this.tabRetornos = new System.Windows.Forms.TabPage();
            this.listaRetornos = new Apresentação.Financeiro.Retorno.ListaRetornos();
            this.label4 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroImpressão.SuspendLayout();
            this.quadroRastro.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAcerto.SuspendLayout();
            this.tabSaída.SuspendLayout();
            this.tabVendas.SuspendLayout();
            this.tabRetornos.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroImpressão);
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadroRastro);
            this.esquerda.Size = new System.Drawing.Size(187, 442);
            this.esquerda.Controls.SetChildIndex(this.quadroRastro, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroImpressão, 0);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Visualizar impressão";
            this.opçãoImprimir.Imagem = global::Apresentação.Financeiro.Properties.Resources.impressora___16;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 28);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 0;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // quadroImpressão
            // 
            this.quadroImpressão.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpressão.bInfDirArredondada = true;
            this.quadroImpressão.bInfEsqArredondada = true;
            this.quadroImpressão.bSupDirArredondada = true;
            this.quadroImpressão.bSupEsqArredondada = true;
            this.quadroImpressão.Controls.Add(this.opçãoImprimir);
            this.quadroImpressão.Controls.Add(this.opçãoZerarAcerto);
            this.quadroImpressão.Cor = System.Drawing.Color.Black;
            this.quadroImpressão.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpressão.LetraTítulo = System.Drawing.Color.White;
            this.quadroImpressão.Location = new System.Drawing.Point(7, 13);
            this.quadroImpressão.MostrarBotãoMinMax = false;
            this.quadroImpressão.Name = "quadroImpressão";
            this.quadroImpressão.Size = new System.Drawing.Size(160, 83);
            this.quadroImpressão.TabIndex = 1;
            this.quadroImpressão.Tamanho = 30;
            this.quadroImpressão.Título = "Acerto";
            // 
            // opçãoZerarAcerto
            // 
            this.opçãoZerarAcerto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoZerarAcerto.Descrição = "Zerar acerto";
            this.opçãoZerarAcerto.Imagem = global::Apresentação.Financeiro.Properties.Resources.none;
            this.opçãoZerarAcerto.Location = new System.Drawing.Point(7, 52);
            this.opçãoZerarAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoZerarAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoZerarAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoZerarAcerto.Name = "opçãoZerarAcerto";
            this.opçãoZerarAcerto.Privilégio = Entidades.Privilégio.Permissão.ZerarAcerto;
            this.opçãoZerarAcerto.Size = new System.Drawing.Size(150, 24);
            this.opçãoZerarAcerto.TabIndex = 2;
            this.opçãoZerarAcerto.Click += new System.EventHandler(this.opçãoZerarAcerto_Click);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "será sobrescrito";
            this.títuloBaseInferior.Imagem = global::Apresentação.Financeiro.Properties.Resources.rodízio;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 13);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(533, 70);
            this.títuloBaseInferior.TabIndex = 7;
            this.títuloBaseInferior.Título = "Acerto de Mercadorias de Gilberto";
            // 
            // quadroRastro
            // 
            this.quadroRastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroRastro.bInfDirArredondada = true;
            this.quadroRastro.bInfEsqArredondada = true;
            this.quadroRastro.bSupDirArredondada = true;
            this.quadroRastro.bSupEsqArredondada = true;
            this.quadroRastro.Controls.Add(this.label1);
            this.quadroRastro.Controls.Add(this.opçãoRastro);
            this.quadroRastro.Cor = System.Drawing.Color.Black;
            this.quadroRastro.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRastro.LetraTítulo = System.Drawing.Color.White;
            this.quadroRastro.Location = new System.Drawing.Point(7, 236);
            this.quadroRastro.MostrarBotãoMinMax = false;
            this.quadroRastro.Name = "quadroRastro";
            this.quadroRastro.Size = new System.Drawing.Size(160, 114);
            this.quadroRastro.TabIndex = 2;
            this.quadroRastro.Tamanho = 30;
            this.quadroRastro.Título = "Item selecionado";
            this.quadroRastro.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 61);
            this.label1.TabIndex = 3;
            this.label1.Text = "Você pode rastrear a referência selecionada a fim de solucionar inconsistências d" +
                "o acerto.";
            // 
            // opçãoRastro
            // 
            this.opçãoRastro.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRastro.Descrição = "Rastrear";
            this.opçãoRastro.Imagem = global::Apresentação.Financeiro.Properties.Resources.search;
            this.opçãoRastro.Location = new System.Drawing.Point(5, 91);
            this.opçãoRastro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoRastro.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRastro.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRastro.Name = "opçãoRastro";
            this.opçãoRastro.Size = new System.Drawing.Size(150, 24);
            this.opçãoRastro.TabIndex = 2;
            this.opçãoRastro.Click += new System.EventHandler(this.opçãoRastro_Click);
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.label2);
            this.quadro2.Controls.Add(this.chkFiltro);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 102);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 128);
            this.quadro2.TabIndex = 3;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Filtragem";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 61);
            this.label2.TabIndex = 4;
            this.label2.Text = "Você pode optar por filtrar o acerto, só mostrando os itens cujo acerto é diferen" +
                "te de zero";
            // 
            // chkFiltro
            // 
            this.chkFiltro.AutoSize = true;
            this.chkFiltro.BackColor = System.Drawing.Color.Transparent;
            this.chkFiltro.Checked = true;
            this.chkFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltro.Location = new System.Drawing.Point(38, 108);
            this.chkFiltro.Name = "chkFiltro";
            this.chkFiltro.Size = new System.Drawing.Size(84, 17);
            this.chkFiltro.TabIndex = 2;
            this.chkFiltro.Text = "Filtrar acerto";
            this.chkFiltro.UseVisualStyleBackColor = false;
            this.chkFiltro.CheckedChanged += new System.EventHandler(this.chkFiltro_CheckedChanged);
            // 
            // quadro1
            // 
            this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = false;
            this.quadro1.bInfEsqArredondada = false;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.dataFinal);
            this.quadro1.Controls.Add(this.dataInício);
            this.quadro1.Controls.Add(this.label3);
            this.quadro1.Controls.Add(this.tabControl);
            this.quadro1.Controls.Add(this.label4);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 89);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(533, 337);
            this.quadro1.TabIndex = 6;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Acerto de mercadorias";
            // 
            // dataFinal
            // 
            this.dataFinal.Location = new System.Drawing.Point(302, 29);
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.Size = new System.Drawing.Size(228, 20);
            this.dataFinal.TabIndex = 6;
            this.dataFinal.ValueChanged += new System.EventHandler(this.AoAlterarPeríodo);
            this.dataFinal.DropDown += new System.EventHandler(this.AoIniciarSeleçãoPeríodo);
            this.dataFinal.CloseUp += new System.EventHandler(this.AoFecharSeleçãoPeríodo);
            // 
            // dataInício
            // 
            this.dataInício.Location = new System.Drawing.Point(57, 29);
            this.dataInício.Name = "dataInício";
            this.dataInício.Size = new System.Drawing.Size(228, 20);
            this.dataInício.TabIndex = 4;
            this.dataInício.ValueChanged += new System.EventHandler(this.AoAlterarPeríodo);
            this.dataInício.DropDown += new System.EventHandler(this.AoIniciarSeleçãoPeríodo);
            this.dataInício.CloseUp += new System.EventHandler(this.AoFecharSeleçãoPeríodo);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Período:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabAcerto);
            this.tabControl.Controls.Add(this.tabSaída);
            this.tabControl.Controls.Add(this.tabVendas);
            this.tabControl.Controls.Add(this.tabRetornos);
            this.tabControl.Location = new System.Drawing.Point(3, 55);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(527, 282);
            this.tabControl.TabIndex = 8;
            // 
            // tabAcerto
            // 
            this.tabAcerto.Controls.Add(this.bandejaAcerto);
            this.tabAcerto.Location = new System.Drawing.Point(4, 22);
            this.tabAcerto.Name = "tabAcerto";
            this.tabAcerto.Padding = new System.Windows.Forms.Padding(3);
            this.tabAcerto.Size = new System.Drawing.Size(519, 256);
            this.tabAcerto.TabIndex = 0;
            this.tabAcerto.Text = "Resumo";
            this.tabAcerto.UseVisualStyleBackColor = true;
            // 
            // bandejaAcerto
            // 
            this.bandejaAcerto.AbrirInformaçõesAoDuploClique = false;
            this.bandejaAcerto.Acerto = null;
            this.bandejaAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaAcerto.Cotação = null;
            this.bandejaAcerto.FiltragemAcerto = true;
            this.bandejaAcerto.Location = new System.Drawing.Point(0, 0);
            this.bandejaAcerto.MostrarBarraFerramentas = false;
            this.bandejaAcerto.MostrarExcluir = false;
            this.bandejaAcerto.MostrarPreço = false;
            this.bandejaAcerto.MostrarStatus = false;
            this.bandejaAcerto.Name = "bandejaAcerto";
            this.bandejaAcerto.OrdenaçãoReferência = true;
            this.bandejaAcerto.PermitirExclusão = false;
            this.bandejaAcerto.Size = new System.Drawing.Size(523, 257);
            this.bandejaAcerto.TabIndex = 2;
            this.bandejaAcerto.DuploClique += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAcerto_DuploClique);
            this.bandejaAcerto.SeleçãoMudou += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAcerto_SeleçãoMudou);
            // 
            // tabSaída
            // 
            this.tabSaída.Controls.Add(this.listaSaídas);
            this.tabSaída.Location = new System.Drawing.Point(4, 22);
            this.tabSaída.Name = "tabSaída";
            this.tabSaída.Padding = new System.Windows.Forms.Padding(3);
            this.tabSaída.Size = new System.Drawing.Size(519, 256);
            this.tabSaída.TabIndex = 1;
            this.tabSaída.Text = "Saídas contabilizadas";
            this.tabSaída.UseVisualStyleBackColor = true;
            // 
            // listaSaídas
            // 
            this.listaSaídas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSaídas.Location = new System.Drawing.Point(-1, 0);
            this.listaSaídas.Name = "listaSaídas";
            this.listaSaídas.Size = new System.Drawing.Size(520, 260);
            this.listaSaídas.TabIndex = 0;
            this.listaSaídas.UsarCheckBox = false;
            this.listaSaídas.DoubleClick += new System.EventHandler(this.listaSaídas_DoubleClick);
            // 
            // tabVendas
            // 
            this.tabVendas.Controls.Add(this.listaVendas);
            this.tabVendas.Location = new System.Drawing.Point(4, 22);
            this.tabVendas.Name = "tabVendas";
            this.tabVendas.Size = new System.Drawing.Size(519, 256);
            this.tabVendas.TabIndex = 2;
            this.tabVendas.Text = "Vendas contabilizadas";
            this.tabVendas.UseVisualStyleBackColor = true;
            // 
            // listaVendas
            // 
            this.listaVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaVendas.Location = new System.Drawing.Point(-1, 0);
            this.listaVendas.Name = "listaVendas";
            this.listaVendas.Size = new System.Drawing.Size(520, 256);
            this.listaVendas.TabIndex = 0;
            this.listaVendas.UsarCheckBox = false;
            this.listaVendas.AoDuploClique += new Apresentação.Financeiro.Venda.ListViewVendas.DelegaçãoVenda(this.listaVendas_AoDuploClique);
            // 
            // tabRetornos
            // 
            this.tabRetornos.Controls.Add(this.listaRetornos);
            this.tabRetornos.Location = new System.Drawing.Point(4, 22);
            this.tabRetornos.Name = "tabRetornos";
            this.tabRetornos.Size = new System.Drawing.Size(519, 256);
            this.tabRetornos.TabIndex = 3;
            this.tabRetornos.Text = "Retornos contabilizados";
            this.tabRetornos.UseVisualStyleBackColor = true;
            // 
            // listaRetornos
            // 
            this.listaRetornos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaRetornos.Location = new System.Drawing.Point(-1, 0);
            this.listaRetornos.Name = "listaRetornos";
            this.listaRetornos.Size = new System.Drawing.Size(520, 256);
            this.listaRetornos.TabIndex = 0;
            this.listaRetornos.UsarCheckBox = false;
            this.listaRetornos.DoubleClick += new System.EventHandler(this.listaRetornos_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "a";
            // 
            // AcertoBaseInferior
            // 
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.quadro1);
            this.Name = "AcertoBaseInferior";
            this.Size = new System.Drawing.Size(744, 442);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroImpressão.ResumeLayout(false);
            this.quadroRastro.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro2.PerformLayout();
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabAcerto.ResumeLayout(false);
            this.tabSaída.ResumeLayout(false);
            this.tabVendas.ResumeLayout(false);
            this.tabRetornos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Financeiro.Acerto.BandejaAcerto bandejaAcerto;
        private Apresentação.Formulários.Quadro quadroImpressão;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadroRastro;
        private System.Windows.Forms.Label label1;
        private Apresentação.Formulários.Opção opçãoRastro;
        private Apresentação.Formulários.Quadro quadro2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFiltro;
        private Apresentação.Formulários.Opção opçãoZerarAcerto;
        private System.Windows.Forms.DateTimePicker dataFinal;
        private System.Windows.Forms.DateTimePicker dataInício;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAcerto;
        private System.Windows.Forms.TabPage tabSaída;
        private System.Windows.Forms.TabPage tabVendas;
        private Apresentação.Financeiro.Venda.ListViewVendas listaVendas;
        private System.Windows.Forms.TabPage tabRetornos;
        private Apresentação.Financeiro.Retorno.ListaRetornos listaRetornos;
        private Apresentação.Financeiro.Saída.ListaSaídas listaSaídas;
    }
}
