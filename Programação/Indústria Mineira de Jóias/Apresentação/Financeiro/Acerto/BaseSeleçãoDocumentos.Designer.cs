namespace Apresentação.Financeiro.Acerto
{
    partial class BaseSeleçãoDocumentos
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSaída = new System.Windows.Forms.TabPage();
            this.listaSaídas = new Apresentação.Financeiro.Saída.ListaSaídas();
            this.tabVendas = new System.Windows.Forms.TabPage();
            this.listaVendas = new Apresentação.Financeiro.Venda.ListViewVendas();
            this.tabRetornos = new System.Windows.Forms.TabPage();
            this.listaRetornos = new Apresentação.Financeiro.Retorno.ListaRetornos();
            this.quadroImpressão = new Apresentação.Formulários.Quadro();
            this.btnAtribuir = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSaída.SuspendLayout();
            this.tabVendas.SuspendLayout();
            this.tabRetornos.SuspendLayout();
            this.quadroImpressão.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroImpressão);
            this.esquerda.Size = new System.Drawing.Size(187, 442);
            this.esquerda.Controls.SetChildIndex(this.quadroImpressão, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Selecione os documentos de saída, venda e retornos a serem considerados";
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.rodízio;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 13);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(533, 70);
            this.títuloBaseInferior.TabIndex = 7;
            this.títuloBaseInferior.Título = "Acerto de Mercadorias";
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
            this.quadro1.Controls.Add(this.tabControl);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 89);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(533, 337);
            this.quadro1.TabIndex = 6;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Seleção dos documentos";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabSaída);
            this.tabControl.Controls.Add(this.tabVendas);
            this.tabControl.Controls.Add(this.tabRetornos);
            this.tabControl.Location = new System.Drawing.Point(6, 29);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(527, 305);
            this.tabControl.TabIndex = 8;
            // 
            // tabSaída
            // 
            this.tabSaída.Controls.Add(this.listaSaídas);
            this.tabSaída.Location = new System.Drawing.Point(4, 22);
            this.tabSaída.Name = "tabSaída";
            this.tabSaída.Padding = new System.Windows.Forms.Padding(3);
            this.tabSaída.Size = new System.Drawing.Size(519, 279);
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
            this.listaSaídas.Size = new System.Drawing.Size(520, 283);
            this.listaSaídas.TabIndex = 0;
            this.listaSaídas.DoubleClick += new System.EventHandler(this.listaSaídas_DoubleClick);
            // 
            // tabVendas
            // 
            this.tabVendas.Controls.Add(this.listaVendas);
            this.tabVendas.Location = new System.Drawing.Point(4, 22);
            this.tabVendas.Name = "tabVendas";
            this.tabVendas.Size = new System.Drawing.Size(519, 279);
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
            this.listaVendas.Size = new System.Drawing.Size(520, 279);
            this.listaVendas.TabIndex = 0;
            this.listaVendas.AoDuploClique += new Apresentação.Financeiro.Venda.ListViewVendas.DelegaçãoVenda(this.listaVendas_AoDuploClique);
            // 
            // tabRetornos
            // 
            this.tabRetornos.Controls.Add(this.listaRetornos);
            this.tabRetornos.Location = new System.Drawing.Point(4, 22);
            this.tabRetornos.Name = "tabRetornos";
            this.tabRetornos.Size = new System.Drawing.Size(519, 279);
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
            this.listaRetornos.Size = new System.Drawing.Size(520, 279);
            this.listaRetornos.TabIndex = 0;
            this.listaRetornos.DoubleClick += new System.EventHandler(this.listaRetornos_DoubleClick);
            // 
            // quadroImpressão
            // 
            this.quadroImpressão.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpressão.bInfDirArredondada = true;
            this.quadroImpressão.bInfEsqArredondada = true;
            this.quadroImpressão.bSupDirArredondada = true;
            this.quadroImpressão.bSupEsqArredondada = true;
            this.quadroImpressão.Controls.Add(this.btnAtribuir);
            this.quadroImpressão.Cor = System.Drawing.Color.Black;
            this.quadroImpressão.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpressão.LetraTítulo = System.Drawing.Color.White;
            this.quadroImpressão.Location = new System.Drawing.Point(7, 13);
            this.quadroImpressão.MostrarBotãoMinMax = false;
            this.quadroImpressão.Name = "quadroImpressão";
            this.quadroImpressão.Size = new System.Drawing.Size(160, 70);
            this.quadroImpressão.TabIndex = 6;
            this.quadroImpressão.Tamanho = 30;
            this.quadroImpressão.Título = "Próximo passo";
            // 
            // btnAtribuir
            // 
            this.btnAtribuir.BackColor = System.Drawing.Color.Transparent;
            this.btnAtribuir.Descrição = "Atribuir alteração de documentos para acerto";
            this.btnAtribuir.Imagem = global::Apresentação.Resource.ok;
            this.btnAtribuir.Location = new System.Drawing.Point(5, 29);
            this.btnAtribuir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAtribuir.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnAtribuir.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnAtribuir.Name = "btnAtribuir";
            this.btnAtribuir.Size = new System.Drawing.Size(150, 31);
            this.btnAtribuir.TabIndex = 2;
            this.btnAtribuir.Click += new System.EventHandler(this.btnAtribuir_Click);
            // 
            // BaseSeleçãoDocumentos
            // 
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.quadro1);
            this.Name = "BaseSeleçãoDocumentos";
            this.Size = new System.Drawing.Size(744, 442);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSaída.ResumeLayout(false);
            this.tabVendas.ResumeLayout(false);
            this.tabRetornos.ResumeLayout(false);
            this.quadroImpressão.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Opção btnAtribuir;
        protected System.Windows.Forms.TabControl tabControl;
        protected Apresentação.Financeiro.Venda.ListViewVendas listaVendas;
        protected Apresentação.Financeiro.Retorno.ListaRetornos listaRetornos;
        protected Apresentação.Financeiro.Saída.ListaSaídas listaSaídas;
        protected Apresentação.Formulários.Quadro quadroImpressão;
        protected System.Windows.Forms.TabPage tabSaída;
        protected System.Windows.Forms.TabPage tabVendas;
        protected System.Windows.Forms.TabPage tabRetornos;
    }
}
