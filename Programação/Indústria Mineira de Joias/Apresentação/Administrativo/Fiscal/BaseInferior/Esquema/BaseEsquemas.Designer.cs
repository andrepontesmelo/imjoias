namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    partial class BaseEsquemas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEsquemas));
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroEsquemas = new Apresentação.Formulários.Quadro();
            this.lista = new Apresentação.Administrativo.Fiscal.Lista.ListaEsquemafabricação();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.opçãoNovo = new Apresentação.Formulários.Opção();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoImportarEsquemas = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadroEsquemas.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Size = new System.Drawing.Size(187, 296);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = resources.GetString("títuloBaseInferior1.Descrição");
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.fiscal1;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 13);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(588, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Esquemas de fabricação";
            // 
            // quadroEsquemas
            // 
            this.quadroEsquemas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroEsquemas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroEsquemas.bInfDirArredondada = false;
            this.quadroEsquemas.bInfEsqArredondada = false;
            this.quadroEsquemas.bSupDirArredondada = true;
            this.quadroEsquemas.bSupEsqArredondada = true;
            this.quadroEsquemas.Controls.Add(this.lista);
            this.quadroEsquemas.Cor = System.Drawing.Color.Black;
            this.quadroEsquemas.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroEsquemas.LetraTítulo = System.Drawing.Color.White;
            this.quadroEsquemas.Location = new System.Drawing.Point(193, 92);
            this.quadroEsquemas.MostrarBotãoMinMax = false;
            this.quadroEsquemas.Name = "quadroEsquemas";
            this.quadroEsquemas.Size = new System.Drawing.Size(588, 201);
            this.quadroEsquemas.TabIndex = 7;
            this.quadroEsquemas.Tamanho = 30;
            this.quadroEsquemas.Título = "Esquemas";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(0, 24);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(588, 177);
            this.lista.TabIndex = 2;
            this.lista.AoExcluir += new System.EventHandler(this.lista_AoExcluir);
            this.lista.AoDuploClique += new System.EventHandler(this.lista_AoDuploClique);
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoExcluir);
            this.quadro2.Controls.Add(this.opçãoNovo);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 13);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 70);
            this.quadro2.TabIndex = 8;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Esquema";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.delete;
            this.opçãoExcluir.Location = new System.Drawing.Point(7, 50);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.TabIndex = 3;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovo.Descrição = "Novo";
            this.opçãoNovo.Imagem = global::Apresentação.Resource.document1;
            this.opçãoNovo.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovo.Name = "opçãoNovo";
            this.opçãoNovo.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovo.TabIndex = 2;
            this.opçãoNovo.Click += new System.EventHandler(this.opçãoNovo_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoImportarEsquemas);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.Blue;
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 92);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 54);
            this.quadro1.TabIndex = 9;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Importação";
            // 
            // opçãoImportarEsquemas
            // 
            this.opçãoImportarEsquemas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportarEsquemas.Descrição = "Importar esquemas";
            this.opçãoImportarEsquemas.Imagem = global::Apresentação.Resource.Edit_RedoHS;
            this.opçãoImportarEsquemas.Location = new System.Drawing.Point(7, 30);
            this.opçãoImportarEsquemas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportarEsquemas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportarEsquemas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportarEsquemas.Name = "opçãoImportarEsquemas";
            this.opçãoImportarEsquemas.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportarEsquemas.TabIndex = 2;
            this.opçãoImportarEsquemas.Click += new System.EventHandler(this.opçãoImportarEsquemas_Click);
            // 
            // BaseEsquemas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadroEsquemas);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseEsquemas";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadroEsquemas, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroEsquemas.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Quadro quadro2;
        private Formulários.Opção opçãoExcluir;
        private Formulários.Opção opçãoNovo;
        private Formulários.Quadro quadroEsquemas;
        private Lista.ListaEsquemafabricação lista;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoImportarEsquemas;
    }
}
