namespace Apresentação.Formulários.Impressão
{
    partial class BaseFormatarEtiqueta
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
            Report.Layout.MetricCentimeter metricCentimeter1 = new Report.Layout.MetricCentimeter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFormatarEtiqueta));
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.txtAlturaFolha = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.txtLarguraFolha = new System.Windows.Forms.TextBox();
            this.grpMargens = new System.Windows.Forms.GroupBox();
            this.txtMargemDireita = new System.Windows.Forms.TextBox();
            this.lblMargemDireita = new System.Windows.Forms.Label();
            this.txtMargemInferior = new System.Windows.Forms.TextBox();
            this.lblMargemInferior = new System.Windows.Forms.Label();
            this.txtMargemEsquerda = new System.Windows.Forms.TextBox();
            this.lblMargemEsquerda = new System.Windows.Forms.Label();
            this.txtMargemSuperior = new System.Windows.Forms.TextBox();
            this.lblMargemSuperior = new System.Windows.Forms.Label();
            this.txtEspaçamentoVertical = new System.Windows.Forms.TextBox();
            this.lblEspaçamentoVertical = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.lblAltura = new System.Windows.Forms.Label();
            this.txtLargura = new System.Windows.Forms.TextBox();
            this.lblLargura = new System.Windows.Forms.Label();
            this.txtEspaçamentoHorizontal = new System.Windows.Forms.TextBox();
            this.lblEspaçamentoHorizontal = new System.Windows.Forms.Label();
            this.lblTamanho = new System.Windows.Forms.Label();
            this.quadroEtiqueta = new Apresentação.Formulários.Quadro();
            this.layoutDesign = new Report.Designer.LayoutDesign();
            this.layoutEtiqueta = new Report.Layout.Complex.ItemLayout(this.components);
            this.quadroPropriedades = new Apresentação.Formulários.Quadro();
            this.propriedades = new System.Windows.Forms.PropertyGrid();
            this.quadroConfiguração = new Apresentação.Formulários.Quadro();
            this.opçãoCancelar = new Apresentação.Formulários.Opção();
            this.opçãoSalvar = new Apresentação.Formulários.Opção();
            this.quadroElementos = new Apresentação.Formulários.Quadro();
            this.painelElementos = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLayout = new Report.Layout.LabelLayout(this.components);
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.grpMargens.SuspendLayout();
            this.quadroEtiqueta.SuspendLayout();
            this.quadroPropriedades.SuspendLayout();
            this.quadroConfiguração.SuspendLayout();
            this.quadroElementos.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroElementos);
            this.esquerda.Controls.Add(this.quadroConfiguração);
            this.esquerda.Size = new System.Drawing.Size(187, 476);
            this.esquerda.Controls.SetChildIndex(this.quadroConfiguração, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroElementos, 0);
            // 
            // quadro1
            // 
            this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.txtAlturaFolha);
            this.quadro1.Controls.Add(this.lblX);
            this.quadro1.Controls.Add(this.txtLarguraFolha);
            this.quadro1.Controls.Add(this.grpMargens);
            this.quadro1.Controls.Add(this.txtEspaçamentoVertical);
            this.quadro1.Controls.Add(this.lblEspaçamentoVertical);
            this.quadro1.Controls.Add(this.txtAltura);
            this.quadro1.Controls.Add(this.lblAltura);
            this.quadro1.Controls.Add(this.txtLargura);
            this.quadro1.Controls.Add(this.lblLargura);
            this.quadro1.Controls.Add(this.txtEspaçamentoHorizontal);
            this.quadro1.Controls.Add(this.lblEspaçamentoHorizontal);
            this.quadro1.Controls.Add(this.lblTamanho);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 197);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(392, 256);
            this.quadro1.TabIndex = 12;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Propriedades da Folha";
            // 
            // txtAlturaFolha
            // 
            this.txtAlturaFolha.Location = new System.Drawing.Point(232, 32);
            this.txtAlturaFolha.Name = "txtAlturaFolha";
            this.txtAlturaFolha.Size = new System.Drawing.Size(88, 20);
            this.txtAlturaFolha.TabIndex = 14;
            this.txtAlturaFolha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtAlturaFolha.Validated += new System.EventHandler(this.txtAlturaFolha_Validated);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(216, 34);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(12, 13);
            this.lblX.TabIndex = 13;
            this.lblX.Text = "x";
            // 
            // txtLarguraFolha
            // 
            this.txtLarguraFolha.Location = new System.Drawing.Point(112, 32);
            this.txtLarguraFolha.Name = "txtLarguraFolha";
            this.txtLarguraFolha.Size = new System.Drawing.Size(96, 20);
            this.txtLarguraFolha.TabIndex = 12;
            this.txtLarguraFolha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtLarguraFolha.Validated += new System.EventHandler(this.txtLarguraFolha_Validated);
            // 
            // grpMargens
            // 
            this.grpMargens.Controls.Add(this.txtMargemDireita);
            this.grpMargens.Controls.Add(this.lblMargemDireita);
            this.grpMargens.Controls.Add(this.txtMargemInferior);
            this.grpMargens.Controls.Add(this.lblMargemInferior);
            this.grpMargens.Controls.Add(this.txtMargemEsquerda);
            this.grpMargens.Controls.Add(this.lblMargemEsquerda);
            this.grpMargens.Controls.Add(this.txtMargemSuperior);
            this.grpMargens.Controls.Add(this.lblMargemSuperior);
            this.grpMargens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpMargens.Location = new System.Drawing.Point(8, 184);
            this.grpMargens.Name = "grpMargens";
            this.grpMargens.Size = new System.Drawing.Size(376, 64);
            this.grpMargens.TabIndex = 11;
            this.grpMargens.TabStop = false;
            this.grpMargens.Text = "Margens";
            // 
            // txtMargemDireita
            // 
            this.txtMargemDireita.Location = new System.Drawing.Point(272, 40);
            this.txtMargemDireita.Name = "txtMargemDireita";
            this.txtMargemDireita.Size = new System.Drawing.Size(96, 20);
            this.txtMargemDireita.TabIndex = 20;
            this.txtMargemDireita.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtMargemDireita.Validated += new System.EventHandler(this.txtMargemDireita_Validated);
            // 
            // lblMargemDireita
            // 
            this.lblMargemDireita.AutoSize = true;
            this.lblMargemDireita.Location = new System.Drawing.Point(208, 42);
            this.lblMargemDireita.Name = "lblMargemDireita";
            this.lblMargemDireita.Size = new System.Drawing.Size(40, 13);
            this.lblMargemDireita.TabIndex = 19;
            this.lblMargemDireita.Text = "Direita:";
            // 
            // txtMargemInferior
            // 
            this.txtMargemInferior.Location = new System.Drawing.Point(104, 40);
            this.txtMargemInferior.Name = "txtMargemInferior";
            this.txtMargemInferior.Size = new System.Drawing.Size(96, 20);
            this.txtMargemInferior.TabIndex = 18;
            this.txtMargemInferior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtMargemInferior.Validated += new System.EventHandler(this.txtMargemInferior_Validated);
            // 
            // lblMargemInferior
            // 
            this.lblMargemInferior.AutoSize = true;
            this.lblMargemInferior.Location = new System.Drawing.Point(8, 42);
            this.lblMargemInferior.Name = "lblMargemInferior";
            this.lblMargemInferior.Size = new System.Drawing.Size(42, 13);
            this.lblMargemInferior.TabIndex = 17;
            this.lblMargemInferior.Text = "Inferior:";
            // 
            // txtMargemEsquerda
            // 
            this.txtMargemEsquerda.Location = new System.Drawing.Point(272, 16);
            this.txtMargemEsquerda.Name = "txtMargemEsquerda";
            this.txtMargemEsquerda.Size = new System.Drawing.Size(96, 20);
            this.txtMargemEsquerda.TabIndex = 16;
            this.txtMargemEsquerda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtMargemEsquerda.Validated += new System.EventHandler(this.txtMargemEsquerda_Validated);
            // 
            // lblMargemEsquerda
            // 
            this.lblMargemEsquerda.AutoSize = true;
            this.lblMargemEsquerda.Location = new System.Drawing.Point(208, 18);
            this.lblMargemEsquerda.Name = "lblMargemEsquerda";
            this.lblMargemEsquerda.Size = new System.Drawing.Size(55, 13);
            this.lblMargemEsquerda.TabIndex = 15;
            this.lblMargemEsquerda.Text = "Esquerda:";
            // 
            // txtMargemSuperior
            // 
            this.txtMargemSuperior.Location = new System.Drawing.Point(104, 16);
            this.txtMargemSuperior.Name = "txtMargemSuperior";
            this.txtMargemSuperior.Size = new System.Drawing.Size(96, 20);
            this.txtMargemSuperior.TabIndex = 14;
            this.txtMargemSuperior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtMargemSuperior.Validated += new System.EventHandler(this.txtMargemSuperior_Validated);
            // 
            // lblMargemSuperior
            // 
            this.lblMargemSuperior.Location = new System.Drawing.Point(8, 18);
            this.lblMargemSuperior.Name = "lblMargemSuperior";
            this.lblMargemSuperior.Size = new System.Drawing.Size(56, 16);
            this.lblMargemSuperior.TabIndex = 13;
            this.lblMargemSuperior.Text = "Superior:";
            // 
            // txtEspaçamentoVertical
            // 
            this.txtEspaçamentoVertical.Location = new System.Drawing.Point(112, 160);
            this.txtEspaçamentoVertical.Name = "txtEspaçamentoVertical";
            this.txtEspaçamentoVertical.Size = new System.Drawing.Size(96, 20);
            this.txtEspaçamentoVertical.TabIndex = 10;
            this.txtEspaçamentoVertical.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtEspaçamentoVertical.Validated += new System.EventHandler(this.txtEspaçamentoVertical_Validated);
            // 
            // lblEspaçamentoVertical
            // 
            this.lblEspaçamentoVertical.BackColor = System.Drawing.Color.Transparent;
            this.lblEspaçamentoVertical.Location = new System.Drawing.Point(8, 154);
            this.lblEspaçamentoVertical.Name = "lblEspaçamentoVertical";
            this.lblEspaçamentoVertical.Size = new System.Drawing.Size(100, 32);
            this.lblEspaçamentoVertical.TabIndex = 9;
            this.lblEspaçamentoVertical.Text = "Espaçamento vertical (cm):";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(112, 96);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(96, 20);
            this.txtAltura.TabIndex = 6;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtAltura.Validating += new System.ComponentModel.CancelEventHandler(this.Tamanho_Validating);
            // 
            // lblAltura
            // 
            this.lblAltura.Location = new System.Drawing.Point(8, 90);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(100, 32);
            this.lblAltura.TabIndex = 5;
            this.lblAltura.Text = "Altura da etiqueta (cm):";
            // 
            // txtLargura
            // 
            this.txtLargura.Location = new System.Drawing.Point(112, 64);
            this.txtLargura.Name = "txtLargura";
            this.txtLargura.Size = new System.Drawing.Size(96, 20);
            this.txtLargura.TabIndex = 4;
            this.txtLargura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtLargura.Validating += new System.ComponentModel.CancelEventHandler(this.Tamanho_Validating);
            // 
            // lblLargura
            // 
            this.lblLargura.Location = new System.Drawing.Point(8, 58);
            this.lblLargura.Name = "lblLargura";
            this.lblLargura.Size = new System.Drawing.Size(100, 32);
            this.lblLargura.TabIndex = 3;
            this.lblLargura.Text = "Largura da etiqueta (cm):";
            // 
            // txtEspaçamentoHorizontal
            // 
            this.txtEspaçamentoHorizontal.Location = new System.Drawing.Point(112, 128);
            this.txtEspaçamentoHorizontal.Name = "txtEspaçamentoHorizontal";
            this.txtEspaçamentoHorizontal.Size = new System.Drawing.Size(96, 20);
            this.txtEspaçamentoHorizontal.TabIndex = 8;
            this.txtEspaçamentoHorizontal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AoDigitarNúmeros);
            this.txtEspaçamentoHorizontal.Validated += new System.EventHandler(this.txtEspaçamentoHorizontal_Validated);
            // 
            // lblEspaçamentoHorizontal
            // 
            this.lblEspaçamentoHorizontal.BackColor = System.Drawing.Color.Transparent;
            this.lblEspaçamentoHorizontal.Location = new System.Drawing.Point(8, 122);
            this.lblEspaçamentoHorizontal.Name = "lblEspaçamentoHorizontal";
            this.lblEspaçamentoHorizontal.Size = new System.Drawing.Size(100, 32);
            this.lblEspaçamentoHorizontal.TabIndex = 7;
            this.lblEspaçamentoHorizontal.Text = "Espaçamento horizontal (cm):";
            // 
            // lblTamanho
            // 
            this.lblTamanho.BackColor = System.Drawing.Color.Transparent;
            this.lblTamanho.Location = new System.Drawing.Point(8, 26);
            this.lblTamanho.Name = "lblTamanho";
            this.lblTamanho.Size = new System.Drawing.Size(104, 32);
            this.lblTamanho.TabIndex = 1;
            this.lblTamanho.Text = "Tamanho da folha (cm):";
            // 
            // quadroEtiqueta
            // 
            this.quadroEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroEtiqueta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroEtiqueta.bInfDirArredondada = false;
            this.quadroEtiqueta.bInfEsqArredondada = false;
            this.quadroEtiqueta.bSupDirArredondada = true;
            this.quadroEtiqueta.bSupEsqArredondada = true;
            this.quadroEtiqueta.Controls.Add(this.layoutDesign);
            this.quadroEtiqueta.Cor = System.Drawing.Color.Black;
            this.quadroEtiqueta.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroEtiqueta.LetraTítulo = System.Drawing.Color.White;
            this.quadroEtiqueta.Location = new System.Drawing.Point(193, 23);
            this.quadroEtiqueta.MostrarBotãoMinMax = false;
            this.quadroEtiqueta.Name = "quadroEtiqueta";
            this.quadroEtiqueta.Size = new System.Drawing.Size(392, 158);
            this.quadroEtiqueta.TabIndex = 10;
            this.quadroEtiqueta.Tamanho = 30;
            this.quadroEtiqueta.Título = "Leiaute da Etiqueta";
            // 
            // layoutDesign
            // 
            this.layoutDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutDesign.AutoScroll = true;
            this.layoutDesign.BackColor = System.Drawing.Color.Gray;
            this.layoutDesign.Grid = new System.Drawing.SizeF(1F, 1F);
            this.layoutDesign.InsertItemHeight = 9F;
            this.layoutDesign.InsertItemWidth = 50F;
            this.layoutDesign.Layout = this.layoutEtiqueta;
            this.layoutDesign.Location = new System.Drawing.Point(1, 24);
            this.layoutDesign.Name = "layoutDesign";
            this.layoutDesign.Size = new System.Drawing.Size(390, 133);
            this.layoutDesign.TabIndex = 7;
            // 
            // layoutEtiqueta
            // 
            this.layoutEtiqueta.DefaultAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutEtiqueta.DefaultMetric = metricCentimeter1;
            this.layoutEtiqueta.DefaultTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.layoutEtiqueta.Height = 2.54F;
            this.layoutEtiqueta.Width = 2.54F;
            // 
            // quadroPropriedades
            // 
            this.quadroPropriedades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroPropriedades.BackColor = System.Drawing.Color.Linen;
            this.quadroPropriedades.bInfDirArredondada = true;
            this.quadroPropriedades.bInfEsqArredondada = true;
            this.quadroPropriedades.bSupDirArredondada = true;
            this.quadroPropriedades.bSupEsqArredondada = true;
            this.quadroPropriedades.Controls.Add(this.propriedades);
            this.quadroPropriedades.Cor = System.Drawing.Color.Black;
            this.quadroPropriedades.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPropriedades.LetraTítulo = System.Drawing.Color.White;
            this.quadroPropriedades.Location = new System.Drawing.Point(601, 23);
            this.quadroPropriedades.MostrarBotãoMinMax = false;
            this.quadroPropriedades.Name = "quadroPropriedades";
            this.quadroPropriedades.Size = new System.Drawing.Size(184, 430);
            this.quadroPropriedades.TabIndex = 11;
            this.quadroPropriedades.Tamanho = 30;
            this.quadroPropriedades.Título = "Propriedades da Seleção";
            // 
            // propriedades
            // 
            this.propriedades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propriedades.CommandsBackColor = System.Drawing.Color.White;
            this.propriedades.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propriedades.Location = new System.Drawing.Point(8, 32);
            this.propriedades.Name = "propriedades";
            this.propriedades.Size = new System.Drawing.Size(168, 390);
            this.propriedades.TabIndex = 9;
            this.propriedades.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propriedades_PropertyValueChanged);
            // 
            // quadroConfiguração
            // 
            this.quadroConfiguração.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroConfiguração.bInfDirArredondada = true;
            this.quadroConfiguração.bInfEsqArredondada = true;
            this.quadroConfiguração.bSupDirArredondada = true;
            this.quadroConfiguração.bSupEsqArredondada = true;
            this.quadroConfiguração.Controls.Add(this.opçãoCancelar);
            this.quadroConfiguração.Controls.Add(this.opçãoSalvar);
            this.quadroConfiguração.Cor = System.Drawing.Color.Black;
            this.quadroConfiguração.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroConfiguração.LetraTítulo = System.Drawing.Color.White;
            this.quadroConfiguração.Location = new System.Drawing.Point(7, 13);
            this.quadroConfiguração.MostrarBotãoMinMax = false;
            this.quadroConfiguração.Name = "quadroConfiguração";
            this.quadroConfiguração.Size = new System.Drawing.Size(160, 80);
            this.quadroConfiguração.TabIndex = 2;
            this.quadroConfiguração.Tamanho = 30;
            this.quadroConfiguração.Título = "Configuração";
            // 
            // opçãoCancelar
            // 
            this.opçãoCancelar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCancelar.Descrição = "Cancelar";
            this.opçãoCancelar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoCancelar.Imagem")));
            this.opçãoCancelar.Location = new System.Drawing.Point(7, 50);
            this.opçãoCancelar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCancelar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCancelar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCancelar.Name = "opçãoCancelar";
            this.opçãoCancelar.Size = new System.Drawing.Size(150, 24);
            this.opçãoCancelar.TabIndex = 3;
            // 
            // opçãoSalvar
            // 
            this.opçãoSalvar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSalvar.Descrição = "Salvar configuração";
            this.opçãoSalvar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoSalvar.Imagem")));
            this.opçãoSalvar.Location = new System.Drawing.Point(7, 30);
            this.opçãoSalvar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoSalvar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSalvar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSalvar.Name = "opçãoSalvar";
            this.opçãoSalvar.Size = new System.Drawing.Size(150, 24);
            this.opçãoSalvar.TabIndex = 1;
            // 
            // quadroElementos
            // 
            this.quadroElementos.AutoSize = true;
            this.quadroElementos.BackColor = System.Drawing.SystemColors.Control;
            this.quadroElementos.bInfDirArredondada = true;
            this.quadroElementos.bInfEsqArredondada = true;
            this.quadroElementos.bSupDirArredondada = true;
            this.quadroElementos.bSupEsqArredondada = true;
            this.quadroElementos.Controls.Add(this.painelElementos);
            this.quadroElementos.Controls.Add(this.label1);
            this.quadroElementos.Cor = System.Drawing.SystemColors.ControlDarkDark;
            this.quadroElementos.FundoTítulo = System.Drawing.SystemColors.ControlDark;
            this.quadroElementos.LetraTítulo = System.Drawing.SystemColors.ControlLightLight;
            this.quadroElementos.Location = new System.Drawing.Point(7, 99);
            this.quadroElementos.MostrarBotãoMinMax = false;
            this.quadroElementos.Name = "quadroElementos";
            this.quadroElementos.Size = new System.Drawing.Size(160, 188);
            this.quadroElementos.TabIndex = 3;
            this.quadroElementos.Tamanho = 30;
            this.quadroElementos.Título = "Elementos da etiqueta";
            // 
            // painelElementos
            // 
            this.painelElementos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.painelElementos.AutoSize = true;
            this.painelElementos.BackColor = System.Drawing.Color.Transparent;
            this.painelElementos.Location = new System.Drawing.Point(8, 80);
            this.painelElementos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.painelElementos.Name = "painelElementos";
            this.painelElementos.Size = new System.Drawing.Size(144, 102);
            this.painelElementos.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clique nas opções abaixo para inserir o elemento no leiaute da etiqueta:";
            // 
            // labelLayout
            // 
            this.labelLayout.Document = null;
            this.labelLayout.GapHorizontal = 0F;
            this.labelLayout.GapVertical = 0F;
            this.labelLayout.MarginBottom = 0F;
            this.labelLayout.MarginLeft = 0F;
            this.labelLayout.MarginRight = 0F;
            this.labelLayout.MarginTop = 0F;
            this.labelLayout.Objects = null;
            this.labelLayout.PaperSize = ((System.Drawing.Printing.PaperSize)(resources.GetObject("labelLayout.PaperSize")));
            this.labelLayout.XmlFileName = null;
            // 
            // BaseFormatarEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro1);
            this.Controls.Add(this.quadroEtiqueta);
            this.Controls.Add(this.quadroPropriedades);
            this.Name = "BaseFormatarEtiqueta";
            this.Size = new System.Drawing.Size(800, 476);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroPropriedades, 0);
            this.Controls.SetChildIndex(this.quadroEtiqueta, 0);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.ResumeLayout(false);
            this.esquerda.PerformLayout();
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.grpMargens.ResumeLayout(false);
            this.grpMargens.PerformLayout();
            this.quadroEtiqueta.ResumeLayout(false);
            this.quadroPropriedades.ResumeLayout(false);
            this.quadroConfiguração.ResumeLayout(false);
            this.quadroElementos.ResumeLayout(false);
            this.quadroElementos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadro1;
        private System.Windows.Forms.TextBox txtAlturaFolha;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox txtLarguraFolha;
        private System.Windows.Forms.GroupBox grpMargens;
        private System.Windows.Forms.TextBox txtMargemDireita;
        private System.Windows.Forms.Label lblMargemDireita;
        private System.Windows.Forms.TextBox txtMargemInferior;
        private System.Windows.Forms.Label lblMargemInferior;
        private System.Windows.Forms.TextBox txtMargemEsquerda;
        private System.Windows.Forms.Label lblMargemEsquerda;
        private System.Windows.Forms.TextBox txtMargemSuperior;
        private System.Windows.Forms.Label lblMargemSuperior;
        private System.Windows.Forms.TextBox txtEspaçamentoVertical;
        private System.Windows.Forms.Label lblEspaçamentoVertical;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.TextBox txtLargura;
        private System.Windows.Forms.Label lblLargura;
        private System.Windows.Forms.TextBox txtEspaçamentoHorizontal;
        private System.Windows.Forms.Label lblEspaçamentoHorizontal;
        private System.Windows.Forms.Label lblTamanho;
        private Apresentação.Formulários.Quadro quadroEtiqueta;
        private Apresentação.Formulários.Quadro quadroPropriedades;
        private System.Windows.Forms.PropertyGrid propriedades;
        private Apresentação.Formulários.Quadro quadroConfiguração;
        private Apresentação.Formulários.Opção opçãoCancelar;
        private Apresentação.Formulários.Opção opçãoSalvar;
        private System.Windows.Forms.Label label1;
        protected Report.Layout.LabelLayout labelLayout;
        protected Report.Layout.Complex.ItemLayout layoutEtiqueta;
        protected System.Windows.Forms.Panel painelElementos;
        protected Quadro quadroElementos;
        protected Report.Designer.LayoutDesign layoutDesign;
    }
}
