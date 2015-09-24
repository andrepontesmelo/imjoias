namespace Apresentação.Álbum.Edição.Álbuns
{
    partial class BaseSeleçãoÁlbum
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
            this.quadroInformativo = new Apresentação.Formulários.Quadro();
            this.opçãoTodasFotos = new Apresentação.Formulários.Opção();
            this.opçãoImportarFoto = new Apresentação.Formulários.Opção();
            this.opçãoNovo = new Apresentação.Formulários.Opção();
            this.quadroÁlbum = new Apresentação.Formulários.Quadro();
            this.opçãoExtrairFotos = new Apresentação.Formulários.Opção();
            this.opçãoEditar = new Apresentação.Formulários.Opção();
            this.opçãoRemover = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.lst = new Apresentação.Álbum.ListViewÁlbuns();
            this.esquerda.SuspendLayout();
            this.quadroInformativo.SuspendLayout();
            this.quadroÁlbum.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroInformativo);
            this.esquerda.Controls.Add(this.quadroÁlbum);
            this.esquerda.Controls.SetChildIndex(this.quadroÁlbum, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroInformativo, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Escolha o álbum com que deseja trabalhar.";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.botão___agenda;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 14);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(595, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Seleção de álbum";
            // 
            // quadroInformativo
            // 
            this.quadroInformativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroInformativo.bInfDirArredondada = true;
            this.quadroInformativo.bInfEsqArredondada = true;
            this.quadroInformativo.bSupDirArredondada = true;
            this.quadroInformativo.bSupEsqArredondada = true;
            this.quadroInformativo.Controls.Add(this.opçãoTodasFotos);
            this.quadroInformativo.Controls.Add(this.opçãoImportarFoto);
            this.quadroInformativo.Controls.Add(this.opçãoNovo);
            this.quadroInformativo.Cor = System.Drawing.Color.Black;
            this.quadroInformativo.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroInformativo.LetraTítulo = System.Drawing.Color.White;
            this.quadroInformativo.Location = new System.Drawing.Point(7, 13);
            this.quadroInformativo.MostrarBotãoMinMax = false;
            this.quadroInformativo.Name = "quadroInformativo";
            this.quadroInformativo.Size = new System.Drawing.Size(160, 101);
            this.quadroInformativo.TabIndex = 1;
            this.quadroInformativo.Tamanho = 30;
            this.quadroInformativo.Título = "Fotografias";
            // 
            // opçãoTodasFotos
            // 
            this.opçãoTodasFotos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoTodasFotos.Descrição = "Visualizar todas as fotos";
            this.opçãoTodasFotos.Imagem = global::Apresentação.Resource.botão___agenda;
            this.opçãoTodasFotos.Location = new System.Drawing.Point(7, 70);
            this.opçãoTodasFotos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoTodasFotos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoTodasFotos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoTodasFotos.Name = "opçãoTodasFotos";
            this.opçãoTodasFotos.Size = new System.Drawing.Size(150, 16);
            this.opçãoTodasFotos.TabIndex = 4;
            this.opçãoTodasFotos.Click += new System.EventHandler(this.opçãoTodasFotos_Click);
            // 
            // opçãoImportarFoto
            // 
            this.opçãoImportarFoto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportarFoto.Descrição = "Importar foto...";
            this.opçãoImportarFoto.Imagem = global::Apresentação.Resource.camera;
            this.opçãoImportarFoto.Location = new System.Drawing.Point(7, 50);
            this.opçãoImportarFoto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportarFoto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportarFoto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportarFoto.Name = "opçãoImportarFoto";
            this.opçãoImportarFoto.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportarFoto.TabIndex = 3;
            this.opçãoImportarFoto.Click += new System.EventHandler(this.opçãoImportarFoto_Click);
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovo.Descrição = "Novo álbum";
            this.opçãoNovo.Imagem = global::Apresentação.Resource._3228_icon;
            this.opçãoNovo.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovo.Name = "opçãoNovo";
            this.opçãoNovo.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovo.TabIndex = 2;
            this.opçãoNovo.Click += new System.EventHandler(this.opçãoNovo_Click);
            // 
            // quadroÁlbum
            // 
            this.quadroÁlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroÁlbum.bInfDirArredondada = true;
            this.quadroÁlbum.bInfEsqArredondada = true;
            this.quadroÁlbum.bSupDirArredondada = true;
            this.quadroÁlbum.bSupEsqArredondada = true;
            this.quadroÁlbum.Controls.Add(this.opçãoExtrairFotos);
            this.quadroÁlbum.Controls.Add(this.opçãoEditar);
            this.quadroÁlbum.Controls.Add(this.opçãoRemover);
            this.quadroÁlbum.Controls.Add(this.opçãoImprimir);
            this.quadroÁlbum.Cor = System.Drawing.Color.Black;
            this.quadroÁlbum.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroÁlbum.LetraTítulo = System.Drawing.Color.White;
            this.quadroÁlbum.Location = new System.Drawing.Point(7, 120);
            this.quadroÁlbum.MostrarBotãoMinMax = false;
            this.quadroÁlbum.Name = "quadroÁlbum";
            this.quadroÁlbum.Size = new System.Drawing.Size(160, 117);
            this.quadroÁlbum.TabIndex = 2;
            this.quadroÁlbum.Tamanho = 30;
            this.quadroÁlbum.Título = "Álbum selecionado";
            this.quadroÁlbum.Visible = false;
            // 
            // opçãoExtrairFotos
            // 
            this.opçãoExtrairFotos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExtrairFotos.Descrição = "Exportar";
            this.opçãoExtrairFotos.Imagem = global::Apresentação.Resource.saveHS;
            this.opçãoExtrairFotos.Location = new System.Drawing.Point(7, 90);
            this.opçãoExtrairFotos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExtrairFotos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExtrairFotos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExtrairFotos.Name = "opçãoExtrairFotos";
            this.opçãoExtrairFotos.Size = new System.Drawing.Size(150, 24);
            this.opçãoExtrairFotos.TabIndex = 5;
            this.opçãoExtrairFotos.Click += new System.EventHandler(this.opçãoExtrairFotos_Click);
            // 
            // opçãoEditar
            // 
            this.opçãoEditar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEditar.Descrição = "Editar...";
            this.opçãoEditar.Imagem = global::Apresentação.Resource.propriedades;
            this.opçãoEditar.Location = new System.Drawing.Point(7, 30);
            this.opçãoEditar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEditar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEditar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEditar.Name = "opçãoEditar";
            this.opçãoEditar.Size = new System.Drawing.Size(150, 16);
            this.opçãoEditar.TabIndex = 2;
            this.opçãoEditar.Click += new System.EventHandler(this.opçãoEditar_Click);
            // 
            // opçãoRemover
            // 
            this.opçãoRemover.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRemover.Descrição = "Excluir";
            this.opçãoRemover.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoRemover.Location = new System.Drawing.Point(7, 50);
            this.opçãoRemover.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRemover.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRemover.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRemover.Name = "opçãoRemover";
            this.opçãoRemover.Size = new System.Drawing.Size(150, 16);
            this.opçãoRemover.TabIndex = 3;
            this.opçãoRemover.Click += new System.EventHandler(this.opçãoRemover_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir...";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 70);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 4;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
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
            this.quadro1.Controls.Add(this.lst);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 90);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(684, 191);
            this.quadro1.TabIndex = 9;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Álbum";
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.Location = new System.Drawing.Point(0, 24);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(684, 167);
            this.lst.TabIndex = 8;
            this.lst.AoSelecionarÁlbum += new System.EventHandler(this.lst_AoSelecionarÁlbum);
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            // 
            // BaseSeleçãoÁlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.quadro1);
            this.Imagem = global::Apresentação.Resource.botão___agenda;
            this.Name = "BaseSeleçãoÁlbum";
            this.Privilégio = Entidades.Privilégio.Permissão.Álbum;
            this.Size = new System.Drawing.Size(920, 296);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroInformativo.ResumeLayout(false);
            this.quadroÁlbum.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadroInformativo;
        private Apresentação.Formulários.Quadro quadroÁlbum;
        private Apresentação.Formulários.Opção opçãoEditar;
        private Apresentação.Formulários.Opção opçãoRemover;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Opção opçãoNovo;
        private Apresentação.Formulários.Opção opçãoExtrairFotos;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private Apresentação.Formulários.Opção opçãoTodasFotos;
        private Apresentação.Formulários.Opção opçãoImportarFoto;
        private Apresentação.Formulários.Quadro quadro1;
        private ListViewÁlbuns lst;
    }
}
