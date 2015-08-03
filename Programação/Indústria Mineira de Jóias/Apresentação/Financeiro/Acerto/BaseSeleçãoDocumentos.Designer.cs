namespace Apresenta��o.Financeiro.Acerto
{
    partial class BaseSele��oDocumentos
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
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSa�da = new System.Windows.Forms.TabPage();
            this.listaSa�das = new Apresenta��o.Financeiro.Sa�da.ListaSa�das();
            this.tabVendas = new System.Windows.Forms.TabPage();
            this.listaVendas = new Apresenta��o.Financeiro.Venda.ListViewVendas();
            this.tabRetornos = new System.Windows.Forms.TabPage();
            this.listaRetornos = new Apresenta��o.Financeiro.Retorno.ListaRetornos();
            this.quadroImpress�o = new Apresenta��o.Formul�rios.Quadro();
            this.btnAtribuir = new Apresenta��o.Formul�rios.Op��o();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSa�da.SuspendLayout();
            this.tabVendas.SuspendLayout();
            this.tabRetornos.SuspendLayout();
            this.quadroImpress�o.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroImpress�o);
            this.esquerda.Size = new System.Drawing.Size(187, 442);
            this.esquerda.Controls.SetChildIndex(this.quadroImpress�o, 0);
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Selecione os documentos de sa�da, venda e retornos a serem considerados";
            this.t�tuloBaseInferior.Imagem = global::Apresenta��o.Resource.rod�zio;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(193, 13);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(533, 70);
            this.t�tuloBaseInferior.TabIndex = 7;
            this.t�tuloBaseInferior.T�tulo = "Acerto de Mercadorias";
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
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 89);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(533, 337);
            this.quadro1.TabIndex = 6;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "Sele��o dos documentos";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabSa�da);
            this.tabControl.Controls.Add(this.tabVendas);
            this.tabControl.Controls.Add(this.tabRetornos);
            this.tabControl.Location = new System.Drawing.Point(6, 29);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(527, 305);
            this.tabControl.TabIndex = 8;
            // 
            // tabSa�da
            // 
            this.tabSa�da.Controls.Add(this.listaSa�das);
            this.tabSa�da.Location = new System.Drawing.Point(4, 22);
            this.tabSa�da.Name = "tabSa�da";
            this.tabSa�da.Padding = new System.Windows.Forms.Padding(3);
            this.tabSa�da.Size = new System.Drawing.Size(519, 279);
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
            this.listaSa�das.Size = new System.Drawing.Size(520, 283);
            this.listaSa�das.TabIndex = 0;
            this.listaSa�das.DoubleClick += new System.EventHandler(this.listaSa�das_DoubleClick);
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
            this.listaVendas.AoDuploClique += new Apresenta��o.Financeiro.Venda.ListViewVendas.Delega��oVenda(this.listaVendas_AoDuploClique);
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
            // quadroImpress�o
            // 
            this.quadroImpress�o.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpress�o.bInfDirArredondada = true;
            this.quadroImpress�o.bInfEsqArredondada = true;
            this.quadroImpress�o.bSupDirArredondada = true;
            this.quadroImpress�o.bSupEsqArredondada = true;
            this.quadroImpress�o.Controls.Add(this.btnAtribuir);
            this.quadroImpress�o.Cor = System.Drawing.Color.Black;
            this.quadroImpress�o.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpress�o.LetraT�tulo = System.Drawing.Color.White;
            this.quadroImpress�o.Location = new System.Drawing.Point(7, 13);
            this.quadroImpress�o.MostrarBot�oMinMax = false;
            this.quadroImpress�o.Name = "quadroImpress�o";
            this.quadroImpress�o.Size = new System.Drawing.Size(160, 70);
            this.quadroImpress�o.TabIndex = 6;
            this.quadroImpress�o.Tamanho = 30;
            this.quadroImpress�o.T�tulo = "Pr�ximo passo";
            // 
            // btnAtribuir
            // 
            this.btnAtribuir.BackColor = System.Drawing.Color.Transparent;
            this.btnAtribuir.Descri��o = "Atribuir altera��o de documentos para acerto";
            this.btnAtribuir.Imagem = global::Apresenta��o.Resource.ok;
            this.btnAtribuir.Location = new System.Drawing.Point(5, 29);
            this.btnAtribuir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAtribuir.MaximumSize = new System.Drawing.Size(150, 100);
            this.btnAtribuir.MinimumSize = new System.Drawing.Size(150, 16);
            this.btnAtribuir.Name = "btnAtribuir";
            this.btnAtribuir.Size = new System.Drawing.Size(150, 31);
            this.btnAtribuir.TabIndex = 2;
            this.btnAtribuir.Click += new System.EventHandler(this.btnAtribuir_Click);
            // 
            // BaseSele��oDocumentos
            // 
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Controls.Add(this.quadro1);
            this.Name = "BaseSele��oDocumentos";
            this.Size = new System.Drawing.Size(744, 442);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSa�da.ResumeLayout(false);
            this.tabVendas.ResumeLayout(false);
            this.tabRetornos.ResumeLayout(false);
            this.quadroImpress�o.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.Quadro quadro1;
        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private Apresenta��o.Formul�rios.Op��o btnAtribuir;
        protected System.Windows.Forms.TabControl tabControl;
        protected Apresenta��o.Financeiro.Venda.ListViewVendas listaVendas;
        protected Apresenta��o.Financeiro.Retorno.ListaRetornos listaRetornos;
        protected Apresenta��o.Financeiro.Sa�da.ListaSa�das listaSa�das;
        protected Apresenta��o.Formul�rios.Quadro quadroImpress�o;
        protected System.Windows.Forms.TabPage tabSa�da;
        protected System.Windows.Forms.TabPage tabVendas;
        protected System.Windows.Forms.TabPage tabRetornos;
    }
}
