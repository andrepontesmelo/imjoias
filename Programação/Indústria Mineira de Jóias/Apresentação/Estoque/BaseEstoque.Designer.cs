namespace Apresentação.Estoque
{
    partial class BaseEstoque
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
            this.btnRelatórioReferência = new Apresentação.Formulários.Opção();
            this.btnRelatórioFornecedor = new Apresentação.Formulários.Opção();
            this.btnRelatórioResumo = new Apresentação.Formulários.Opção();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoZerarEstoque = new Apresentação.Formulários.Opção();
            this.btnEntradas = new Apresentação.Formulários.Opção();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.btnExtrato = new Apresentação.Formulários.Opção();
            this.quadro4 = new Apresentação.Formulários.Quadro();
            this.listaSaldo = new Apresentação.Estoque.ListaSaldo();
            this.opçãoConfigurações = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.quadro4.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = null;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(604, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Controle de Estoque";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.btnRelatórioReferência);
            this.quadro1.Controls.Add(this.btnRelatórioFornecedor);
            this.quadro1.Controls.Add(this.btnRelatórioResumo);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 83);
            this.quadro1.TabIndex = 7;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Relatórios";
            // 
            // btnRelatórioReferência
            // 
            this.btnRelatórioReferência.BackColor = System.Drawing.Color.Transparent;
            this.btnRelatórioReferência.Descrição = "Referência";
            this.btnRelatórioReferência.Imagem = global::Apresentação.Resource.relatório;
            this.btnRelatórioReferência.Location = new System.Drawing.Point(10, 60);
            this.btnRelatórioReferência.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRelatórioReferência.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnRelatórioReferência.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnRelatórioReferência.Name = "btnRelatórioReferência";
            this.btnRelatórioReferência.Size = new System.Drawing.Size(150, 16);
            this.btnRelatórioReferência.TabIndex = 7;
            this.btnRelatórioReferência.Click += new System.EventHandler(this.btnRelatórioReferência_Click);
            // 
            // btnRelatórioFornecedor
            // 
            this.btnRelatórioFornecedor.BackColor = System.Drawing.Color.Transparent;
            this.btnRelatórioFornecedor.Descrição = "Fornecedor";
            this.btnRelatórioFornecedor.Imagem = global::Apresentação.Resource.relatório;
            this.btnRelatórioFornecedor.Location = new System.Drawing.Point(10, 45);
            this.btnRelatórioFornecedor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRelatórioFornecedor.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnRelatórioFornecedor.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnRelatórioFornecedor.Name = "btnRelatórioFornecedor";
            this.btnRelatórioFornecedor.Size = new System.Drawing.Size(150, 16);
            this.btnRelatórioFornecedor.TabIndex = 7;
            this.btnRelatórioFornecedor.Click += new System.EventHandler(this.btnRelatórioFornecedor_Click);
            // 
            // btnRelatórioResumo
            // 
            this.btnRelatórioResumo.BackColor = System.Drawing.Color.Transparent;
            this.btnRelatórioResumo.Descrição = "Resumo";
            this.btnRelatórioResumo.Imagem = global::Apresentação.Resource.relatório;
            this.btnRelatórioResumo.Location = new System.Drawing.Point(10, 30);
            this.btnRelatórioResumo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRelatórioResumo.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnRelatórioResumo.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnRelatórioResumo.Name = "btnRelatórioResumo";
            this.btnRelatórioResumo.Size = new System.Drawing.Size(150, 16);
            this.btnRelatórioResumo.TabIndex = 7;
            this.btnRelatórioResumo.Click += new System.EventHandler(this.btnRelatórioResumo_Click);
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoConfigurações);
            this.quadro2.Controls.Add(this.opçãoZerarEstoque);
            this.quadro2.Controls.Add(this.btnEntradas);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 102);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 93);
            this.quadro2.TabIndex = 8;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Ações";
            // 
            // opçãoZerarEstoque
            // 
            this.opçãoZerarEstoque.BackColor = System.Drawing.Color.Transparent;
            this.opçãoZerarEstoque.Descrição = "Zerar Estoque";
            this.opçãoZerarEstoque.Imagem = global::Apresentação.Resource.none;
            this.opçãoZerarEstoque.Location = new System.Drawing.Point(10, 50);
            this.opçãoZerarEstoque.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoZerarEstoque.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoZerarEstoque.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoZerarEstoque.Name = "opçãoZerarEstoque";
            this.opçãoZerarEstoque.Size = new System.Drawing.Size(150, 16);
            this.opçãoZerarEstoque.TabIndex = 8;
            this.opçãoZerarEstoque.Click += new System.EventHandler(this.opçãoZerarEstoque_Click);
            // 
            // btnEntradas
            // 
            this.btnEntradas.BackColor = System.Drawing.Color.Transparent;
            this.btnEntradas.Descrição = "Abrir Entradas";
            this.btnEntradas.Imagem = global::Apresentação.Resource.VariaçãoPositiva;
            this.btnEntradas.Location = new System.Drawing.Point(10, 30);
            this.btnEntradas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnEntradas.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnEntradas.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(150, 16);
            this.btnEntradas.TabIndex = 7;
            this.btnEntradas.Click += new System.EventHandler(this.btnEntradas_Click);
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.btnExtrato);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 201);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 58);
            this.quadro3.TabIndex = 9;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Seleção";
            // 
            // btnExtrato
            // 
            this.btnExtrato.BackColor = System.Drawing.Color.Transparent;
            this.btnExtrato.Descrição = "Extrato";
            this.btnExtrato.Imagem = global::Apresentação.Resource.propriedades__altura_58_1;
            this.btnExtrato.Location = new System.Drawing.Point(10, 30);
            this.btnExtrato.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExtrato.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnExtrato.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnExtrato.Name = "btnExtrato";
            this.btnExtrato.Size = new System.Drawing.Size(150, 16);
            this.btnExtrato.TabIndex = 7;
            this.btnExtrato.Click += new System.EventHandler(this.btnExtrato_Click);
            // 
            // quadro4
            // 
            this.quadro4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro4.bInfDirArredondada = false;
            this.quadro4.bInfEsqArredondada = false;
            this.quadro4.bSupDirArredondada = true;
            this.quadro4.bSupEsqArredondada = true;
            this.quadro4.Controls.Add(this.listaSaldo);
            this.quadro4.Cor = System.Drawing.Color.Black;
            this.quadro4.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro4.LetraTítulo = System.Drawing.Color.White;
            this.quadro4.Location = new System.Drawing.Point(193, 79);
            this.quadro4.MostrarBotãoMinMax = false;
            this.quadro4.Name = "quadro4";
            this.quadro4.Size = new System.Drawing.Size(596, 198);
            this.quadro4.TabIndex = 7;
            this.quadro4.Tamanho = 30;
            this.quadro4.Título = "Saldo";
            // 
            // listaSaldo
            // 
            this.listaSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSaldo.Location = new System.Drawing.Point(3, 23);
            this.listaSaldo.Name = "listaSaldo";
            this.listaSaldo.Size = new System.Drawing.Size(590, 172);
            this.listaSaldo.TabIndex = 2;
            this.listaSaldo.AoDuploClique += new System.EventHandler(this.listaSaldo_AoDuploClique);
            // 
            // opçãoConfigurações
            // 
            this.opçãoConfigurações.BackColor = System.Drawing.Color.Transparent;
            this.opçãoConfigurações.Descrição = "Configurações...";
            this.opçãoConfigurações.Imagem = global::Apresentação.Resource.repair;
            this.opçãoConfigurações.Location = new System.Drawing.Point(10, 70);
            this.opçãoConfigurações.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoConfigurações.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoConfigurações.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoConfigurações.Name = "opçãoConfigurações";
            this.opçãoConfigurações.Size = new System.Drawing.Size(150, 16);
            this.opçãoConfigurações.TabIndex = 9;
            this.opçãoConfigurações.Click += new System.EventHandler(this.opçãoConfigurações_Click);
            // 
            // BaseEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro4);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseEstoque";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadro4, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.quadro4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Quadro quadro1;
        private Formulários.Quadro quadro3;
        private Formulários.Opção btnExtrato;
        private Formulários.Quadro quadro2;
        private Formulários.Opção opçãoZerarEstoque;
        private Formulários.Opção btnEntradas;
        private Formulários.Opção btnRelatórioResumo;
        private Formulários.Quadro quadro4;
        private ListaSaldo listaSaldo;
        private Formulários.Opção btnRelatórioFornecedor;
        private Formulários.Opção btnRelatórioReferência;
        private Formulários.Opção opçãoConfigurações;
    }
}
