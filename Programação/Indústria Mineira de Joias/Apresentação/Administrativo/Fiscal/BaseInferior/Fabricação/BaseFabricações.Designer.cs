namespace Apresentação.Administrativo.Fiscal.BaseInferior.fabricação
{
    partial class BaseFabricações
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
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoNovaFabricação = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.listaFabricações = new Apresentação.Administrativo.Fiscal.Lista.ListaFabricações();
            this.comboFechamento = new Apresentação.Administrativo.Fiscal.Combo.ComboFechamento();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 296);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoNovaFabricação);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 55);
            this.quadro1.TabIndex = 6;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Criar";
            // 
            // opçãoNovaFabricação
            // 
            this.opçãoNovaFabricação.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovaFabricação.Descrição = "Nova fabricação";
            this.opçãoNovaFabricação.Imagem = global::Apresentação.Resource.document1;
            this.opçãoNovaFabricação.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovaFabricação.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovaFabricação.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovaFabricação.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovaFabricação.Name = "opçãoNovaFabricação";
            this.opçãoNovaFabricação.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovaFabricação.TabIndex = 2;
            this.opçãoNovaFabricação.Click += new System.EventHandler(this.opçãoNovafabricação_Click);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Fabricações de inventário";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.fiscal1;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 13);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(589, 70);
            this.títuloBaseInferior1.TabIndex = 7;
            this.títuloBaseInferior1.Título = "Fabricações";
            // 
            // listaFabricações
            // 
            this.listaFabricações.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaFabricações.Location = new System.Drawing.Point(193, 109);
            this.listaFabricações.Name = "listaFabricações";
            this.listaFabricações.Size = new System.Drawing.Size(604, 184);
            this.listaFabricações.TabIndex = 8;
            this.listaFabricações.AoDuploClique += new System.EventHandler(this.listaFabricações1_AoDuploClique);
            // 
            // comboFechamento
            // 
            this.comboFechamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFechamento.Location = new System.Drawing.Point(510, 81);
            this.comboFechamento.Name = "comboFechamento";
            this.comboFechamento.Size = new System.Drawing.Size(287, 22);
            this.comboFechamento.TabIndex = 9;
            this.comboFechamento.SelectedIndexChanged += new System.EventHandler(this.comboFechamento_SelectedIndexChanged);
            // 
            // BaseFabricações
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboFechamento);
            this.Controls.Add(this.listaFabricações);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseFabricações";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.listaFabricações, 0);
            this.Controls.SetChildIndex(this.comboFechamento, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro1;
        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Opção opçãoNovaFabricação;
        private Lista.ListaFabricações listaFabricações;
        private Combo.ComboFechamento comboFechamento;
    }
}
