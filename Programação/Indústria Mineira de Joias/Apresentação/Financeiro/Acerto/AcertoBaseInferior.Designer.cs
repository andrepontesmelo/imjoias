namespace Apresenta��o.Financeiro.Acerto
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
            this.op��oImprimir = new Apresenta��o.Formul�rios.Op��o();
            this.quadroImpress�o = new Apresenta��o.Formul�rios.Quadro();
            this.op��oZerarAcerto = new Apresenta��o.Formul�rios.Op��o();
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadroRastro = new Apresenta��o.Formul�rios.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.op��oRastro = new Apresenta��o.Formul�rios.Op��o();
            this.quadro2 = new Apresenta��o.Formul�rios.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.dataFinal = new System.Windows.Forms.DateTimePicker();
            this.dataIn�cio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAcerto = new System.Windows.Forms.TabPage();
            this.bandejaAcerto = new Apresenta��o.Financeiro.Acerto.BandejaAcerto();
            this.tabSa�da = new System.Windows.Forms.TabPage();
            this.listaSa�das = new Apresenta��o.Financeiro.Sa�da.ListaSa�das();
            this.tabVendas = new System.Windows.Forms.TabPage();
            this.listaVendas = new Apresenta��o.Financeiro.Venda.ListViewVendas();
            this.tabRetornos = new System.Windows.Forms.TabPage();
            this.listaRetornos = new Apresenta��o.Financeiro.Retorno.ListaRetornos();
            this.label4 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroImpress�o.SuspendLayout();
            this.quadroRastro.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAcerto.SuspendLayout();
            this.tabSa�da.SuspendLayout();
            this.tabVendas.SuspendLayout();
            this.tabRetornos.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroImpress�o);
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadroRastro);
            this.esquerda.Size = new System.Drawing.Size(187, 442);
            this.esquerda.Controls.SetChildIndex(this.quadroRastro, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroImpress�o, 0);
            // 
            // op��oImprimir
            // 
            this.op��oImprimir.BackColor = System.Drawing.Color.Transparent;
            this.op��oImprimir.Descri��o = "Visualizar impress�o";
            this.op��oImprimir.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.impressora___16;
            this.op��oImprimir.Location = new System.Drawing.Point(5, 28);
            this.op��oImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oImprimir.Name = "op��oImprimir";
            this.op��oImprimir.Size = new System.Drawing.Size(150, 24);
            this.op��oImprimir.TabIndex = 0;
            this.op��oImprimir.Click += new System.EventHandler(this.op��oImprimir_Click);
            // 
            // quadroImpress�o
            // 
            this.quadroImpress�o.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpress�o.bInfDirArredondada = true;
            this.quadroImpress�o.bInfEsqArredondada = true;
            this.quadroImpress�o.bSupDirArredondada = true;
            this.quadroImpress�o.bSupEsqArredondada = true;
            this.quadroImpress�o.Controls.Add(this.op��oImprimir);
            this.quadroImpress�o.Controls.Add(this.op��oZerarAcerto);
            this.quadroImpress�o.Cor = System.Drawing.Color.Black;
            this.quadroImpress�o.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpress�o.LetraT�tulo = System.Drawing.Color.White;
            this.quadroImpress�o.Location = new System.Drawing.Point(7, 13);
            this.quadroImpress�o.MostrarBot�oMinMax = false;
            this.quadroImpress�o.Name = "quadroImpress�o";
            this.quadroImpress�o.Size = new System.Drawing.Size(160, 83);
            this.quadroImpress�o.TabIndex = 1;
            this.quadroImpress�o.Tamanho = 30;
            this.quadroImpress�o.T�tulo = "Acerto";
            // 
            // op��oZerarAcerto
            // 
            this.op��oZerarAcerto.BackColor = System.Drawing.Color.Transparent;
            this.op��oZerarAcerto.Descri��o = "Zerar acerto";
            this.op��oZerarAcerto.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.none;
            this.op��oZerarAcerto.Location = new System.Drawing.Point(7, 52);
            this.op��oZerarAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oZerarAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oZerarAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oZerarAcerto.Name = "op��oZerarAcerto";
            this.op��oZerarAcerto.Privil�gio = Entidades.Privil�gio.Permiss�o.ZerarAcerto;
            this.op��oZerarAcerto.Size = new System.Drawing.Size(150, 24);
            this.op��oZerarAcerto.TabIndex = 2;
            this.op��oZerarAcerto.Click += new System.EventHandler(this.op��oZerarAcerto_Click);
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "ser� sobrescrito";
            this.t�tuloBaseInferior.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.rod�zio;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(193, 13);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(533, 70);
            this.t�tuloBaseInferior.TabIndex = 7;
            this.t�tuloBaseInferior.T�tulo = "Acerto de Mercadorias de Gilberto";
            // 
            // quadroRastro
            // 
            this.quadroRastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroRastro.bInfDirArredondada = true;
            this.quadroRastro.bInfEsqArredondada = true;
            this.quadroRastro.bSupDirArredondada = true;
            this.quadroRastro.bSupEsqArredondada = true;
            this.quadroRastro.Controls.Add(this.label1);
            this.quadroRastro.Controls.Add(this.op��oRastro);
            this.quadroRastro.Cor = System.Drawing.Color.Black;
            this.quadroRastro.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRastro.LetraT�tulo = System.Drawing.Color.White;
            this.quadroRastro.Location = new System.Drawing.Point(7, 236);
            this.quadroRastro.MostrarBot�oMinMax = false;
            this.quadroRastro.Name = "quadroRastro";
            this.quadroRastro.Size = new System.Drawing.Size(160, 114);
            this.quadroRastro.TabIndex = 2;
            this.quadroRastro.Tamanho = 30;
            this.quadroRastro.T�tulo = "Item selecionado";
            this.quadroRastro.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 61);
            this.label1.TabIndex = 3;
            this.label1.Text = "Voc� pode rastrear a refer�ncia selecionada a fim de solucionar inconsist�ncias d" +
                "o acerto.";
            // 
            // op��oRastro
            // 
            this.op��oRastro.BackColor = System.Drawing.Color.Transparent;
            this.op��oRastro.Descri��o = "Rastrear";
            this.op��oRastro.Imagem = global::Apresenta��o.Financeiro.Properties.Resources.search;
            this.op��oRastro.Location = new System.Drawing.Point(5, 91);
            this.op��oRastro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oRastro.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRastro.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRastro.Name = "op��oRastro";
            this.op��oRastro.Size = new System.Drawing.Size(150, 24);
            this.op��oRastro.TabIndex = 2;
            this.op��oRastro.Click += new System.EventHandler(this.op��oRastro_Click);
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
            this.quadro2.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraT�tulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 102);
            this.quadro2.MostrarBot�oMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 128);
            this.quadro2.TabIndex = 3;
            this.quadro2.Tamanho = 30;
            this.quadro2.T�tulo = "Filtragem";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 61);
            this.label2.TabIndex = 4;
            this.label2.Text = "Voc� pode optar por filtrar o acerto, s� mostrando os itens cujo acerto � diferen" +
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
            this.quadro1.Controls.Add(this.dataIn�cio);
            this.quadro1.Controls.Add(this.label3);
            this.quadro1.Controls.Add(this.tabControl);
            this.quadro1.Controls.Add(this.label4);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 89);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(533, 337);
            this.quadro1.TabIndex = 6;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "Acerto de mercadorias";
            // 
            // dataFinal
            // 
            this.dataFinal.Location = new System.Drawing.Point(302, 29);
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.Size = new System.Drawing.Size(228, 20);
            this.dataFinal.TabIndex = 6;
            this.dataFinal.ValueChanged += new System.EventHandler(this.AoAlterarPer�odo);
            this.dataFinal.DropDown += new System.EventHandler(this.AoIniciarSele��oPer�odo);
            this.dataFinal.CloseUp += new System.EventHandler(this.AoFecharSele��oPer�odo);
            // 
            // dataIn�cio
            // 
            this.dataIn�cio.Location = new System.Drawing.Point(57, 29);
            this.dataIn�cio.Name = "dataIn�cio";
            this.dataIn�cio.Size = new System.Drawing.Size(228, 20);
            this.dataIn�cio.TabIndex = 4;
            this.dataIn�cio.ValueChanged += new System.EventHandler(this.AoAlterarPer�odo);
            this.dataIn�cio.DropDown += new System.EventHandler(this.AoIniciarSele��oPer�odo);
            this.dataIn�cio.CloseUp += new System.EventHandler(this.AoFecharSele��oPer�odo);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Per�odo:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabAcerto);
            this.tabControl.Controls.Add(this.tabSa�da);
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
            this.bandejaAcerto.AbrirInforma��esAoDuploClique = false;
            this.bandejaAcerto.Acerto = null;
            this.bandejaAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaAcerto.Cota��o = null;
            this.bandejaAcerto.FiltragemAcerto = true;
            this.bandejaAcerto.Location = new System.Drawing.Point(0, 0);
            this.bandejaAcerto.MostrarBarraFerramentas = false;
            this.bandejaAcerto.MostrarExcluir = false;
            this.bandejaAcerto.MostrarPre�o = false;
            this.bandejaAcerto.MostrarStatus = false;
            this.bandejaAcerto.Name = "bandejaAcerto";
            this.bandejaAcerto.Ordena��oRefer�ncia = true;
            this.bandejaAcerto.PermitirExclus�o = false;
            this.bandejaAcerto.Size = new System.Drawing.Size(523, 257);
            this.bandejaAcerto.TabIndex = 2;
            this.bandejaAcerto.DuploClique += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAcerto_DuploClique);
            this.bandejaAcerto.Sele��oMudou += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAcerto_Sele��oMudou);
            // 
            // tabSa�da
            // 
            this.tabSa�da.Controls.Add(this.listaSa�das);
            this.tabSa�da.Location = new System.Drawing.Point(4, 22);
            this.tabSa�da.Name = "tabSa�da";
            this.tabSa�da.Padding = new System.Windows.Forms.Padding(3);
            this.tabSa�da.Size = new System.Drawing.Size(519, 256);
            this.tabSa�da.TabIndex = 1;
            this.tabSa�da.Text = "Sa�das contabilizadas";
            this.tabSa�da.UseVisualStyleBackColor = true;
            // 
            // listaSa�das
            // 
            this.listaSa�das.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSa�das.Location = new System.Drawing.Point(-1, 0);
            this.listaSa�das.Name = "listaSa�das";
            this.listaSa�das.Size = new System.Drawing.Size(520, 260);
            this.listaSa�das.TabIndex = 0;
            this.listaSa�das.UsarCheckBox = false;
            this.listaSa�das.DoubleClick += new System.EventHandler(this.listaSa�das_DoubleClick);
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
            this.listaVendas.AoDuploClique += new Apresenta��o.Financeiro.Venda.ListViewVendas.Delega��oVenda(this.listaVendas_AoDuploClique);
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
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Controls.Add(this.quadro1);
            this.Name = "AcertoBaseInferior";
            this.Size = new System.Drawing.Size(744, 442);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroImpress�o.ResumeLayout(false);
            this.quadroRastro.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro2.PerformLayout();
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabAcerto.ResumeLayout(false);
            this.tabSa�da.ResumeLayout(false);
            this.tabVendas.ResumeLayout(false);
            this.tabRetornos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.Quadro quadro1;
        private Apresenta��o.Financeiro.Acerto.BandejaAcerto bandejaAcerto;
        private Apresenta��o.Formul�rios.Quadro quadroImpress�o;
        private Apresenta��o.Formul�rios.Op��o op��oImprimir;
        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private Apresenta��o.Formul�rios.Quadro quadroRastro;
        private System.Windows.Forms.Label label1;
        private Apresenta��o.Formul�rios.Op��o op��oRastro;
        private Apresenta��o.Formul�rios.Quadro quadro2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFiltro;
        private Apresenta��o.Formul�rios.Op��o op��oZerarAcerto;
        private System.Windows.Forms.DateTimePicker dataFinal;
        private System.Windows.Forms.DateTimePicker dataIn�cio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAcerto;
        private System.Windows.Forms.TabPage tabSa�da;
        private System.Windows.Forms.TabPage tabVendas;
        private Apresenta��o.Financeiro.Venda.ListViewVendas listaVendas;
        private System.Windows.Forms.TabPage tabRetornos;
        private Apresenta��o.Financeiro.Retorno.ListaRetornos listaRetornos;
        private Apresenta��o.Financeiro.Sa�da.ListaSa�das listaSa�das;
    }
}
