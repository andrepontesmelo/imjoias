namespace Apresentação.Administrativo.Fiscal.BaseInferior.Fabricação
{
    partial class BaseFabricação
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoConfigurar = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.cmbTipoUnidade = new Apresentação.Fiscal.Combobox.ComboTipoUnidade();
            this.txtQuantidade = new AMS.TextBox.NumericTextBox();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.quadroItem = new Apresentação.Formulários.Quadro();
            this.txtValorPorGrama = new AMS.TextBox.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPeso = new AMS.TextBox.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValor = new AMS.TextBox.NumericTextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtMercadoria = new Apresentação.Mercadoria.TxtMercadoriaLivre();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listaSaídas = new Apresentação.Administrativo.Fiscal.Lista.Fabricação.ListaSaídaFabricaçãoFiscal();
            this.listaEntradas = new Apresentação.Administrativo.Fiscal.Lista.Fabricação.ListaEntradaFabricaçãoFiscal();
            this.label2 = new System.Windows.Forms.Label();
            this.opçãoRecalcularMatériasPrimas = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 483);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Fabricação de um item de inventário.";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.fiscal1;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(952, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Editar fabricação fiscal";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoRecalcularMatériasPrimas);
            this.quadro1.Controls.Add(this.opçãoConfigurar);
            this.quadro1.Controls.Add(this.opçãoImprimir);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 95);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Documento";
            // 
            // opçãoConfigurar
            // 
            this.opçãoConfigurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoConfigurar.Descrição = "Configurar";
            this.opçãoConfigurar.Imagem = global::Apresentação.Resource.repair;
            this.opçãoConfigurar.Location = new System.Drawing.Point(7, 50);
            this.opçãoConfigurar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoConfigurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoConfigurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoConfigurar.Name = "opçãoConfigurar";
            this.opçãoConfigurar.Size = new System.Drawing.Size(150, 16);
            this.opçãoConfigurar.TabIndex = 3;
            this.opçãoConfigurar.Click += new System.EventHandler(this.opçãoConfigurar_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora___162;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 30);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.TabIndex = 2;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncluir.Location = new System.Drawing.Point(851, 100);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 3;
            this.btnIncluir.Text = "Incluir TO";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // cmbTipoUnidade
            // 
            this.cmbTipoUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoUnidade.Enabled = false;
            this.cmbTipoUnidade.FormattingEnabled = true;
            this.cmbTipoUnidade.Location = new System.Drawing.Point(483, 102);
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
            this.txtQuantidade.Location = new System.Drawing.Point(207, 103);
            this.txtQuantidade.MaxDecimalPlaces = 4;
            this.txtQuantidade.MaxWholeDigits = 9;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Prefix = "";
            this.txtQuantidade.RangeMax = 1.7976931348623157E+308D;
            this.txtQuantidade.RangeMin = -1.7976931348623157E+308D;
            this.txtQuantidade.Size = new System.Drawing.Size(59, 20);
            this.txtQuantidade.TabIndex = 1;
            // 
            // txtCFOP
            // 
            this.txtCFOP.Enabled = false;
            this.txtCFOP.Location = new System.Drawing.Point(19, 102);
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.Size = new System.Drawing.Size(155, 20);
            this.txtCFOP.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(480, 86);
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
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Enabled = false;
            this.txtDescrição.Location = new System.Drawing.Point(207, 47);
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(720, 20);
            this.txtDescrição.TabIndex = 2;
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
            // quadroItem
            // 
            this.quadroItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroItem.bInfDirArredondada = true;
            this.quadroItem.bInfEsqArredondada = true;
            this.quadroItem.bSupDirArredondada = true;
            this.quadroItem.bSupEsqArredondada = true;
            this.quadroItem.Controls.Add(this.txtValorPorGrama);
            this.quadroItem.Controls.Add(this.label5);
            this.quadroItem.Controls.Add(this.txtPeso);
            this.quadroItem.Controls.Add(this.label3);
            this.quadroItem.Controls.Add(this.txtValor);
            this.quadroItem.Controls.Add(this.lblValor);
            this.quadroItem.Controls.Add(this.btnExcluir);
            this.quadroItem.Controls.Add(this.txtMercadoria);
            this.quadroItem.Controls.Add(this.btnIncluir);
            this.quadroItem.Controls.Add(this.cmbTipoUnidade);
            this.quadroItem.Controls.Add(this.txtQuantidade);
            this.quadroItem.Controls.Add(this.txtCFOP);
            this.quadroItem.Controls.Add(this.label10);
            this.quadroItem.Controls.Add(this.label9);
            this.quadroItem.Controls.Add(this.btnAlterar);
            this.quadroItem.Controls.Add(this.txtDescrição);
            this.quadroItem.Controls.Add(this.label8);
            this.quadroItem.Controls.Add(this.label7);
            this.quadroItem.Controls.Add(this.label4);
            this.quadroItem.Cor = System.Drawing.Color.Black;
            this.quadroItem.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroItem.LetraTítulo = System.Drawing.Color.White;
            this.quadroItem.Location = new System.Drawing.Point(191, 77);
            this.quadroItem.MostrarBotãoMinMax = false;
            this.quadroItem.Name = "quadroItem";
            this.quadroItem.Size = new System.Drawing.Size(939, 139);
            this.quadroItem.TabIndex = 7;
            this.quadroItem.Tamanho = 30;
            this.quadroItem.Título = "Detalhe do item";
            // 
            // txtValorPorGrama
            // 
            this.txtValorPorGrama.AllowNegative = true;
            this.txtValorPorGrama.DigitsInGroup = 0;
            this.txtValorPorGrama.Enabled = false;
            this.txtValorPorGrama.Flags = 0;
            this.txtValorPorGrama.Location = new System.Drawing.Point(343, 102);
            this.txtValorPorGrama.MaxDecimalPlaces = 4;
            this.txtValorPorGrama.MaxWholeDigits = 9;
            this.txtValorPorGrama.Name = "txtValorPorGrama";
            this.txtValorPorGrama.Prefix = "";
            this.txtValorPorGrama.RangeMax = 1.7976931348623157E+308D;
            this.txtValorPorGrama.RangeMin = -1.7976931348623157E+308D;
            this.txtValorPorGrama.Size = new System.Drawing.Size(58, 20);
            this.txtValorPorGrama.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Valor/g";
            // 
            // txtPeso
            // 
            this.txtPeso.AllowNegative = true;
            this.txtPeso.DigitsInGroup = 0;
            this.txtPeso.Flags = 0;
            this.txtPeso.Location = new System.Drawing.Point(275, 103);
            this.txtPeso.MaxDecimalPlaces = 4;
            this.txtPeso.MaxWholeDigits = 9;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Prefix = "";
            this.txtPeso.RangeMax = 1.7976931348623157E+308D;
            this.txtPeso.RangeMin = -1.7976931348623157E+308D;
            this.txtPeso.Size = new System.Drawing.Size(59, 20);
            this.txtPeso.TabIndex = 2;
            this.txtPeso.Validated += new System.EventHandler(this.txtPeso_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Peso";
            // 
            // txtValor
            // 
            this.txtValor.AllowNegative = true;
            this.txtValor.DigitsInGroup = 0;
            this.txtValor.Flags = 0;
            this.txtValor.Location = new System.Drawing.Point(410, 102);
            this.txtValor.MaxDecimalPlaces = 4;
            this.txtValor.MaxWholeDigits = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.Prefix = "";
            this.txtValor.RangeMax = 1.7976931348623157E+308D;
            this.txtValor.RangeMin = -1.7976931348623157E+308D;
            this.txtValor.Size = new System.Drawing.Size(58, 20);
            this.txtValor.TabIndex = 2;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(407, 86);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 15;
            this.lblValor.Text = "Valor";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(689, 100);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Visible = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.Location = new System.Drawing.Point(19, 44);
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Referência = "";
            this.txtMercadoria.Size = new System.Drawing.Size(177, 23);
            this.txtMercadoria.TabIndex = 0;
            this.txtMercadoria.ReferênciaAlterada += new System.EventHandler(this.txtMercadoria_ReferênciaAlterada);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterar.Location = new System.Drawing.Point(770, 100);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 7;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Visible = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "TO: Transferência da fabricação para o inventário";
            // 
            // listaSaídas
            // 
            this.listaSaídas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSaídas.Location = new System.Drawing.Point(196, 248);
            this.listaSaídas.Name = "listaSaídas";
            this.listaSaídas.Size = new System.Drawing.Size(934, 86);
            this.listaSaídas.TabIndex = 9;
            this.listaSaídas.AoSelecionar += new System.EventHandler(this.listaSaídas_AoSelecionar);
            // 
            // listaEntradas
            // 
            this.listaEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaEntradas.Location = new System.Drawing.Point(196, 363);
            this.listaEntradas.Name = "listaEntradas";
            this.listaEntradas.Size = new System.Drawing.Size(934, 106);
            this.listaEntradas.TabIndex = 11;
            this.listaEntradas.AoSelecionar += new System.EventHandler(this.listaEntradas_AoSelecionar);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(193, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "OT: Transferência do inventário para a fabricação";
            // 
            // opçãoRecalcularMatériasPrimas
            // 
            this.opçãoRecalcularMatériasPrimas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRecalcularMatériasPrimas.Descrição = "Recalcular M. Primas";
            this.opçãoRecalcularMatériasPrimas.Imagem = global::Apresentação.Resource.repair;
            this.opçãoRecalcularMatériasPrimas.Location = new System.Drawing.Point(7, 70);
            this.opçãoRecalcularMatériasPrimas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRecalcularMatériasPrimas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRecalcularMatériasPrimas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRecalcularMatériasPrimas.Name = "opçãoRecalcularMatériasPrimas";
            this.opçãoRecalcularMatériasPrimas.Size = new System.Drawing.Size(150, 25);
            this.opçãoRecalcularMatériasPrimas.TabIndex = 4;
            this.opçãoRecalcularMatériasPrimas.Click += new System.EventHandler(this.opçãoRecalcularMatériasPrimas_Click);
            // 
            // BaseFabricação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listaEntradas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listaSaídas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quadroItem);
            this.Controls.Add(this.títuloBaseInferior);
            this.Name = "BaseFabricação";
            this.Size = new System.Drawing.Size(1148, 483);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.quadroItem, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.listaSaídas, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.listaEntradas, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroItem.ResumeLayout(false);
            this.quadroItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoImprimir;
        private System.Windows.Forms.Button btnIncluir;
        private Apresentação.Fiscal.Combobox.ComboTipoUnidade cmbTipoUnidade;
        private AMS.TextBox.NumericTextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtCFOP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Formulários.Quadro quadroItem;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private Lista.Fabricação.ListaSaídaFabricaçãoFiscal listaSaídas;
        private Lista.Fabricação.ListaEntradaFabricaçãoFiscal listaEntradas;
        private System.Windows.Forms.Label label2;
        private Mercadoria.TxtMercadoriaLivre txtMercadoria;
        private Formulários.Opção opçãoConfigurar;
        private System.Windows.Forms.Button btnExcluir;
        private AMS.TextBox.NumericTextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private AMS.TextBox.NumericTextBox txtPeso;
        private System.Windows.Forms.Label label3;
        private AMS.TextBox.NumericTextBox txtValorPorGrama;
        private System.Windows.Forms.Label label5;
        private Formulários.Opção opçãoRecalcularMatériasPrimas;
    }
}
