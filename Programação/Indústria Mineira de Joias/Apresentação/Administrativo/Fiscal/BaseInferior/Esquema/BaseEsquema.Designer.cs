namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    partial class BaseEsquema
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
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.cmbTipoUnidadeProduzido = new Apresentação.Fiscal.Combobox.ComboTipoUnidade();
            this.txtQuantidadeProduzida = new AMS.TextBox.NumericTextBox();
            this.txtDescriçãoProduzida = new System.Windows.Forms.TextBox();
            this.txtCFOPProduzido = new System.Windows.Forms.TextBox();
            this.txtReferênciaProduzida = new Apresentação.Mercadoria.TxtMercadoria();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.cmbTipoUnidadeSelecionada = new Apresentação.Fiscal.Combobox.ComboTipoUnidade();
            this.txtQuantidadeSelecionada = new AMS.TextBox.NumericTextBox();
            this.txtDescriçãoSelecionado = new System.Windows.Forms.TextBox();
            this.txtCFOPSelecionado = new System.Windows.Forms.TextBox();
            this.txtReferênciaSelecionada = new Apresentação.Mercadoria.TxtMercadoria();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.listaIngredientes = new Apresentação.Administrativo.Fiscal.Lista.ListaIngredienteEsquema();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 715);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Edição de esquema de produção";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.fiscal1;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 15);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(1189, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Esquema de produção";
            // 
            // quadro1
            // 
            this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.cmbTipoUnidadeProduzido);
            this.quadro1.Controls.Add(this.txtQuantidadeProduzida);
            this.quadro1.Controls.Add(this.txtDescriçãoProduzida);
            this.quadro1.Controls.Add(this.txtCFOPProduzido);
            this.quadro1.Controls.Add(this.txtReferênciaProduzida);
            this.quadro1.Controls.Add(this.label5);
            this.quadro1.Controls.Add(this.label4);
            this.quadro1.Controls.Add(this.label3);
            this.quadro1.Controls.Add(this.label2);
            this.quadro1.Controls.Add(this.label1);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 91);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(1189, 120);
            this.quadro1.TabIndex = 8;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Produção de";
            // 
            // cmbTipoUnidadeProduzido
            // 
            this.cmbTipoUnidadeProduzido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoUnidadeProduzido.Enabled = false;
            this.cmbTipoUnidadeProduzido.FormattingEnabled = true;
            this.cmbTipoUnidadeProduzido.Location = new System.Drawing.Point(358, 90);
            this.cmbTipoUnidadeProduzido.Name = "cmbTipoUnidadeProduzido";
            this.cmbTipoUnidadeProduzido.Seleção = null;
            this.cmbTipoUnidadeProduzido.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoUnidadeProduzido.TabIndex = 5;
            // 
            // txtQuantidadeProduzida
            // 
            this.txtQuantidadeProduzida.AllowNegative = true;
            this.txtQuantidadeProduzida.DigitsInGroup = 0;
            this.txtQuantidadeProduzida.Flags = 0;
            this.txtQuantidadeProduzida.Location = new System.Drawing.Point(268, 90);
            this.txtQuantidadeProduzida.MaxDecimalPlaces = 4;
            this.txtQuantidadeProduzida.MaxWholeDigits = 9;
            this.txtQuantidadeProduzida.Name = "txtQuantidadeProduzida";
            this.txtQuantidadeProduzida.Prefix = "";
            this.txtQuantidadeProduzida.RangeMax = 1.7976931348623157E+308D;
            this.txtQuantidadeProduzida.RangeMin = -1.7976931348623157E+308D;
            this.txtQuantidadeProduzida.Size = new System.Drawing.Size(79, 20);
            this.txtQuantidadeProduzida.TabIndex = 3;
            this.txtQuantidadeProduzida.Text = "1";
            // 
            // txtDescriçãoProduzida
            // 
            this.txtDescriçãoProduzida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescriçãoProduzida.Enabled = false;
            this.txtDescriçãoProduzida.Location = new System.Drawing.Point(268, 47);
            this.txtDescriçãoProduzida.Name = "txtDescriçãoProduzida";
            this.txtDescriçãoProduzida.Size = new System.Drawing.Size(895, 20);
            this.txtDescriçãoProduzida.TabIndex = 1;
            // 
            // txtCFOPProduzido
            // 
            this.txtCFOPProduzido.Enabled = false;
            this.txtCFOPProduzido.Location = new System.Drawing.Point(11, 90);
            this.txtCFOPProduzido.Name = "txtCFOPProduzido";
            this.txtCFOPProduzido.Size = new System.Drawing.Size(244, 20);
            this.txtCFOPProduzido.TabIndex = 2;
            // 
            // txtReferênciaProduzida
            // 
            this.txtReferênciaProduzida.Location = new System.Drawing.Point(11, 47);
            this.txtReferênciaProduzida.Name = "txtReferênciaProduzida";
            this.txtReferênciaProduzida.Referência = "";
            this.txtReferênciaProduzida.Size = new System.Drawing.Size(244, 20);
            this.txtReferênciaProduzida.SomenteDeLinha = false;
            this.txtReferênciaProduzida.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(355, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tipo de unidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Quantidade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(265, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrição:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CFOP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Referência:";
            // 
            // quadro2
            // 
            this.quadro2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.btnAdicionar);
            this.quadro2.Controls.Add(this.btnAlterar);
            this.quadro2.Controls.Add(this.btnExcluir);
            this.quadro2.Controls.Add(this.cmbTipoUnidadeSelecionada);
            this.quadro2.Controls.Add(this.txtQuantidadeSelecionada);
            this.quadro2.Controls.Add(this.txtDescriçãoSelecionado);
            this.quadro2.Controls.Add(this.txtCFOPSelecionado);
            this.quadro2.Controls.Add(this.txtReferênciaSelecionada);
            this.quadro2.Controls.Add(this.label6);
            this.quadro2.Controls.Add(this.label7);
            this.quadro2.Controls.Add(this.label8);
            this.quadro2.Controls.Add(this.label9);
            this.quadro2.Controls.Add(this.label10);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(193, 217);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(1189, 122);
            this.quadro2.TabIndex = 9;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Ingrediente Selecionado";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(704, 93);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 19;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(623, 93);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 18;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(542, 93);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 17;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // cmbTipoUnidadeSelecionada
            // 
            this.cmbTipoUnidadeSelecionada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoUnidadeSelecionada.Enabled = false;
            this.cmbTipoUnidadeSelecionada.FormattingEnabled = true;
            this.cmbTipoUnidadeSelecionada.Location = new System.Drawing.Point(358, 90);
            this.cmbTipoUnidadeSelecionada.Name = "cmbTipoUnidadeSelecionada";
            this.cmbTipoUnidadeSelecionada.Seleção = null;
            this.cmbTipoUnidadeSelecionada.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoUnidadeSelecionada.TabIndex = 14;
            // 
            // txtQuantidadeSelecionada
            // 
            this.txtQuantidadeSelecionada.AllowNegative = true;
            this.txtQuantidadeSelecionada.DigitsInGroup = 0;
            this.txtQuantidadeSelecionada.Flags = 0;
            this.txtQuantidadeSelecionada.Location = new System.Drawing.Point(268, 90);
            this.txtQuantidadeSelecionada.MaxDecimalPlaces = 4;
            this.txtQuantidadeSelecionada.MaxWholeDigits = 9;
            this.txtQuantidadeSelecionada.Name = "txtQuantidadeSelecionada";
            this.txtQuantidadeSelecionada.Prefix = "";
            this.txtQuantidadeSelecionada.RangeMax = 1.7976931348623157E+308D;
            this.txtQuantidadeSelecionada.RangeMin = -1.7976931348623157E+308D;
            this.txtQuantidadeSelecionada.Size = new System.Drawing.Size(79, 20);
            this.txtQuantidadeSelecionada.TabIndex = 11;
            this.txtQuantidadeSelecionada.Text = "1";
            // 
            // txtDescriçãoSelecionado
            // 
            this.txtDescriçãoSelecionado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescriçãoSelecionado.Enabled = false;
            this.txtDescriçãoSelecionado.Location = new System.Drawing.Point(268, 47);
            this.txtDescriçãoSelecionado.Name = "txtDescriçãoSelecionado";
            this.txtDescriçãoSelecionado.Size = new System.Drawing.Size(895, 20);
            this.txtDescriçãoSelecionado.TabIndex = 8;
            // 
            // txtCFOPSelecionado
            // 
            this.txtCFOPSelecionado.Enabled = false;
            this.txtCFOPSelecionado.Location = new System.Drawing.Point(11, 90);
            this.txtCFOPSelecionado.Name = "txtCFOPSelecionado";
            this.txtCFOPSelecionado.Size = new System.Drawing.Size(244, 20);
            this.txtCFOPSelecionado.TabIndex = 9;
            // 
            // txtReferênciaSelecionada
            // 
            this.txtReferênciaSelecionada.Location = new System.Drawing.Point(11, 47);
            this.txtReferênciaSelecionada.MostrarBalãoRefNãoEncontrada = false;
            this.txtReferênciaSelecionada.Name = "txtReferênciaSelecionada";
            this.txtReferênciaSelecionada.Referência = "";
            this.txtReferênciaSelecionada.Size = new System.Drawing.Size(244, 20);
            this.txtReferênciaSelecionada.SomenteCadastrado = true;
            this.txtReferênciaSelecionada.SomenteDeLinha = false;
            this.txtReferênciaSelecionada.TabIndex = 7;
            this.txtReferênciaSelecionada.ReferênciaAlterada += new System.EventHandler(this.txtReferênciaSelecionada_ReferênciaAlterada);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(355, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tipo de unidade:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Quantidade:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(265, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Descrição:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(8, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "CFOP:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Referência:";
            // 
            // quadro3
            // 
            this.quadro3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro3.bInfDirArredondada = false;
            this.quadro3.bInfEsqArredondada = false;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.listaIngredientes);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(193, 345);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(1189, 357);
            this.quadro3.TabIndex = 9;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Ingredientes";
            // 
            // listaIngredientes
            // 
            this.listaIngredientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaIngredientes.Location = new System.Drawing.Point(0, 24);
            this.listaIngredientes.Name = "listaIngredientes";
            this.listaIngredientes.Size = new System.Drawing.Size(1189, 333);
            this.listaIngredientes.TabIndex = 2;
            this.listaIngredientes.AoSelecionar += new System.EventHandler(this.listaIngredientes_AoSelecionar);
            this.listaIngredientes.AoExcluir += new System.EventHandler(this.listaIngredientes_AoExcluir);
            // 
            // BaseEsquema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro3);
            this.Controls.Add(this.quadro2);
            this.Controls.Add(this.quadro1);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseEsquema";
            this.Size = new System.Drawing.Size(1402, 715);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.Controls.SetChildIndex(this.quadro3, 0);
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.quadro2.ResumeLayout(false);
            this.quadro2.PerformLayout();
            this.quadro3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Quadro quadro1;
        private Formulários.Quadro quadro2;
        private Formulários.Quadro quadro3;
        private Apresentação.Fiscal.Combobox.ComboTipoUnidade cmbTipoUnidadeProduzido;
        private AMS.TextBox.NumericTextBox txtQuantidadeProduzida;
        private System.Windows.Forms.TextBox txtDescriçãoProduzida;
        private System.Windows.Forms.TextBox txtCFOPProduzido;
        private Mercadoria.TxtMercadoria txtReferênciaProduzida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Lista.ListaIngredienteEsquema listaIngredientes;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private Apresentação.Fiscal.Combobox.ComboTipoUnidade cmbTipoUnidadeSelecionada;
        private AMS.TextBox.NumericTextBox txtQuantidadeSelecionada;
        private System.Windows.Forms.TextBox txtDescriçãoSelecionado;
        private System.Windows.Forms.TextBox txtCFOPSelecionado;
        private Mercadoria.TxtMercadoria txtReferênciaSelecionada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}
