namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    partial class BaseInventário
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
            this.opçãoProduzir = new Apresentação.Formulários.Opção();
            this.opçãoExtrato = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.listaInventário = new Apresentação.Administrativo.Fiscal.Lista.ListaInventário();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoSelecionarNegativos = new Apresentação.Formulários.Opção();
            this.opçãoLimparSeleção = new Apresentação.Formulários.Opção();
            this.cmbFechamento = new Apresentação.Administrativo.Fiscal.Combo.ComboFechamento();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 597);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Acesso aos documentos fiscais da empresa";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.fiscal1;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 13);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(862, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Inventário";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoProduzir);
            this.quadro1.Controls.Add(this.opçãoExtrato);
            this.quadro1.Controls.Add(this.opçãoImprimir);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 101);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Ações";
            // 
            // opçãoProduzir
            // 
            this.opçãoProduzir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoProduzir.Descrição = "Produzir";
            this.opçãoProduzir.Imagem = global::Apresentação.Resource.AddTableHS;
            this.opçãoProduzir.Location = new System.Drawing.Point(7, 70);
            this.opçãoProduzir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoProduzir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoProduzir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoProduzir.Name = "opçãoProduzir";
            this.opçãoProduzir.Size = new System.Drawing.Size(150, 16);
            this.opçãoProduzir.TabIndex = 4;
            this.opçãoProduzir.Click += new System.EventHandler(this.opçãoProduzir_Click);
            // 
            // opçãoExtrato
            // 
            this.opçãoExtrato.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExtrato.Descrição = "Abrir extrato";
            this.opçãoExtrato.Imagem = global::Apresentação.Resource.LABELS1;
            this.opçãoExtrato.Location = new System.Drawing.Point(7, 50);
            this.opçãoExtrato.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExtrato.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExtrato.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExtrato.Name = "opçãoExtrato";
            this.opçãoExtrato.Size = new System.Drawing.Size(150, 16);
            this.opçãoExtrato.TabIndex = 3;
            this.opçãoExtrato.Click += new System.EventHandler(this.opçãoExtrato_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora___163;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 30);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.TabIndex = 2;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // listaInventário
            // 
            this.listaInventário.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaInventário.Location = new System.Drawing.Point(193, 100);
            this.listaInventário.Name = "listaInventário";
            this.listaInventário.Size = new System.Drawing.Size(851, 481);
            this.listaInventário.TabIndex = 7;
            this.listaInventário.AoDuploClique += new System.EventHandler(this.listaInventário_AoDuploClique);
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoSelecionarNegativos);
            this.quadro2.Controls.Add(this.opçãoLimparSeleção);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 120);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 73);
            this.quadro2.TabIndex = 2;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Seleção";
            // 
            // opçãoSelecionarNegativos
            // 
            this.opçãoSelecionarNegativos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSelecionarNegativos.Descrição = "Negativos";
            this.opçãoSelecionarNegativos.Imagem = global::Apresentação.Resource.Filter2HS;
            this.opçãoSelecionarNegativos.Location = new System.Drawing.Point(7, 50);
            this.opçãoSelecionarNegativos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoSelecionarNegativos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSelecionarNegativos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSelecionarNegativos.Name = "opçãoSelecionarNegativos";
            this.opçãoSelecionarNegativos.Size = new System.Drawing.Size(150, 16);
            this.opçãoSelecionarNegativos.TabIndex = 4;
            this.opçãoSelecionarNegativos.Click += new System.EventHandler(this.opçãoSelecionarNegativos_Click);
            // 
            // opçãoLimparSeleção
            // 
            this.opçãoLimparSeleção.BackColor = System.Drawing.Color.Transparent;
            this.opçãoLimparSeleção.Descrição = "Limpar";
            this.opçãoLimparSeleção.Imagem = global::Apresentação.Resource.Filter2HS;
            this.opçãoLimparSeleção.Location = new System.Drawing.Point(7, 30);
            this.opçãoLimparSeleção.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoLimparSeleção.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoLimparSeleção.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoLimparSeleção.Name = "opçãoLimparSeleção";
            this.opçãoLimparSeleção.Size = new System.Drawing.Size(150, 16);
            this.opçãoLimparSeleção.TabIndex = 3;
            this.opçãoLimparSeleção.Click += new System.EventHandler(this.opçãoLimparSeleção_Click);
            // 
            // cmbFechamento
            // 
            this.cmbFechamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFechamento.Location = new System.Drawing.Point(792, 71);
            this.cmbFechamento.Name = "cmbFechamento";
            this.cmbFechamento.Size = new System.Drawing.Size(252, 23);
            this.cmbFechamento.TabIndex = 8;
            this.cmbFechamento.SelectedIndexChanged += new System.EventHandler(this.cmbFechamento_SelectedIndexChanged);
            // 
            // BaseInventário
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbFechamento);
            this.Controls.Add(this.listaInventário);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseInventário";
            this.Size = new System.Drawing.Size(1058, 597);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.listaInventário, 0);
            this.Controls.SetChildIndex(this.cmbFechamento, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoProduzir;
        private Formulários.Opção opçãoExtrato;
        private Formulários.Opção opçãoImprimir;
        private Lista.ListaInventário listaInventário;
        private Formulários.Quadro quadro2;
        private Formulários.Opção opçãoSelecionarNegativos;
        private Formulários.Opção opçãoLimparSeleção;
        private Combo.ComboFechamento cmbFechamento;
    }
}
