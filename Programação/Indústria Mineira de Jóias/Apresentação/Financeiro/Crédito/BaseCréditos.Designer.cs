namespace Apresentação.Financeiro.Crédito
{
    partial class BaseCréditos
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
            if (disposing && (components != null)) {
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
            this.opçãoNovoCrédito = new Apresentação.Formulários.Opção();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.lstCréditos = new System.Windows.Forms.ListView();
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 380);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Esta tela mostra todos os créditos. Itens em negrito são créditos ativos, ainda n" +
    "ão gastos.";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.credito;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(600, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Créditos";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoNovoCrédito);
            this.quadro1.Controls.Add(this.opçãoExcluir);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 73);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Opções";
            // 
            // opçãoNovoCrédito
            // 
            this.opçãoNovoCrédito.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovoCrédito.Descrição = "Novo";
            this.opçãoNovoCrédito.ForeColor = System.Drawing.Color.Transparent;
            this.opçãoNovoCrédito.Imagem = global::Apresentação.Resource.Dardo;
            this.opçãoNovoCrédito.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovoCrédito.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovoCrédito.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovoCrédito.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovoCrédito.Name = "opçãoNovoCrédito";
            this.opçãoNovoCrédito.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovoCrédito.TabIndex = 2;
            this.opçãoNovoCrédito.Click += new System.EventHandler(this.opçãoNovoCrédito_Click);
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoExcluir.Location = new System.Drawing.Point(7, 50);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.TabIndex = 3;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // quadro2
            // 
            this.quadro2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = false;
            this.quadro2.bInfEsqArredondada = false;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.lstCréditos);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(202, 92);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(577, 285);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Créditos";
            // 
            // lstCréditos
            // 
            this.lstCréditos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCréditos.BackColor = System.Drawing.Color.White;
            this.lstCréditos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colData,
            this.colValor,
            this.colDescrição});
            this.lstCréditos.FullRowSelect = true;
            this.lstCréditos.Location = new System.Drawing.Point(0, 26);
            this.lstCréditos.Name = "lstCréditos";
            this.lstCréditos.Size = new System.Drawing.Size(577, 259);
            this.lstCréditos.TabIndex = 2;
            this.lstCréditos.UseCompatibleStateImageBehavior = false;
            this.lstCréditos.View = System.Windows.Forms.View.Details;
            this.lstCréditos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstCréditos_ColumnClick);
            this.lstCréditos.DoubleClick += new System.EventHandler(this.lstCréditos_DoubleClick);
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 120;
            // 
            // colValor
            // 
            this.colValor.Text = "Valor";
            this.colValor.Width = 100;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 500;
            // 
            // BaseCréditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.quadro2);
            this.Name = "BaseCréditos";
            this.Size = new System.Drawing.Size(793, 380);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opçãoNovoCrédito;
        private Apresentação.Formulários.Opção opçãoExcluir;
        private Apresentação.Formulários.Quadro quadro2;
        private System.Windows.Forms.ListView lstCréditos;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colDescrição;
    }
}
