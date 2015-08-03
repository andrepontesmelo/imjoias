namespace Apresentação.Financeiro
{
    partial class BaseOpções
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseOpções));
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opção1 = new Apresentação.Formulários.Opção();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoMercadorias = new Apresentação.Formulários.Opção();
            this.opçãoCCusto = new Apresentação.Formulários.Opção();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.opçãoCotações = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro4 = new Apresentação.Formulários.Quadro();
            this.opçãoSetores = new Apresentação.Formulários.Opção();
            this.opção2 = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.quadro4.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro4);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Size = new System.Drawing.Size(187, 481);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro4, 0);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opção1);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 70);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Balanço";
            // 
            // opção1
            // 
            this.opção1.BackColor = System.Drawing.Color.Transparent;
            this.opção1.Descrição = "Abrir balanço";
            this.opção1.Imagem = global::Apresentação.Financeiro.Properties.Resources.balança_pequena;
            this.opção1.Location = new System.Drawing.Point(10, 35);
            this.opção1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opção1.MaximumSize = new System.Drawing.Size(150, 100);
            this.opção1.MinimumSize = new System.Drawing.Size(150, 16);
            this.opção1.Name = "opção1";
            this.opção1.Size = new System.Drawing.Size(150, 24);
            this.opção1.TabIndex = 2;
            this.opção1.Click += new System.EventHandler(this.opção1_Click);
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoMercadorias);
            this.quadro2.Controls.Add(this.opçãoCCusto);
            this.quadro2.Controls.Add(this.opção2);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 89);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 101);
            this.quadro2.TabIndex = 2;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Mercadorias";
            // 
            // opçãoMercadorias
            // 
            this.opçãoMercadorias.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMercadorias.Descrição = "Mercadorias";
            this.opçãoMercadorias.Imagem = global::Apresentação.Financeiro.Properties.Resources.m;
            this.opçãoMercadorias.Location = new System.Drawing.Point(5, 33);
            this.opçãoMercadorias.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMercadorias.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMercadorias.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMercadorias.Name = "opçãoMercadorias";
            this.opçãoMercadorias.Size = new System.Drawing.Size(150, 24);
            this.opçãoMercadorias.TabIndex = 2;
            this.opçãoMercadorias.Click += new System.EventHandler(this.opçãoMercadorias_Click);
            // 
            // opçãoCCusto
            // 
            this.opçãoCCusto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCCusto.Descrição = "Componentes de Custo";
            this.opçãoCCusto.Imagem = global::Apresentação.Financeiro.Properties.Resources.diamente_sem_fundo;
            this.opçãoCCusto.Location = new System.Drawing.Point(5, 57);
            this.opçãoCCusto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCCusto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCCusto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCCusto.Name = "opçãoCCusto";
            this.opçãoCCusto.Size = new System.Drawing.Size(150, 16);
            this.opçãoCCusto.TabIndex = 2;
            this.opçãoCCusto.Click += new System.EventHandler(this.opçãoCCusto_Click);
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.opçãoCotações);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 196);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 67);
            this.quadro3.TabIndex = 3;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Cotações";
            // 
            // opçãoCotações
            // 
            this.opçãoCotações.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCotações.Descrição = "Abrir cotações";
            this.opçãoCotações.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoCotações.Imagem")));
            this.opçãoCotações.Location = new System.Drawing.Point(5, 37);
            this.opçãoCotações.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCotações.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCotações.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCotações.Name = "opçãoCotações";
            this.opçãoCotações.Size = new System.Drawing.Size(150, 24);
            this.opçãoCotações.TabIndex = 2;
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Aqui é possível visualizar ou editar as mercadorias cadastradas no sistema, os co" +
                "mponentes de custo e fazer o balanço.";
            this.títuloBaseInferior1.Imagem = null;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(204, 13);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(599, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Outras opções";
            // 
            // quadro4
            // 
            this.quadro4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro4.bInfDirArredondada = true;
            this.quadro4.bInfEsqArredondada = true;
            this.quadro4.bSupDirArredondada = true;
            this.quadro4.bSupEsqArredondada = true;
            this.quadro4.Controls.Add(this.opçãoSetores);
            this.quadro4.Cor = System.Drawing.Color.Black;
            this.quadro4.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro4.LetraTítulo = System.Drawing.Color.White;
            this.quadro4.Location = new System.Drawing.Point(7, 269);
            this.quadro4.MostrarBotãoMinMax = false;
            this.quadro4.Name = "quadro4";
            this.quadro4.Size = new System.Drawing.Size(160, 67);
            this.quadro4.TabIndex = 4;
            this.quadro4.Tamanho = 30;
            this.quadro4.Título = "Empresa";
            // 
            // opçãoSetores
            // 
            this.opçãoSetores.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSetores.Descrição = "Editar setores";
            this.opçãoSetores.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoSetores.Imagem")));
            this.opçãoSetores.Location = new System.Drawing.Point(5, 37);
            this.opçãoSetores.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoSetores.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSetores.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSetores.Name = "opçãoSetores";
            this.opçãoSetores.Size = new System.Drawing.Size(150, 24);
            this.opçãoSetores.TabIndex = 2;
            // 
            // opção2
            // 
            this.opção2.BackColor = System.Drawing.Color.Transparent;
            this.opção2.Descrição = "Tabelas de preço";
            this.opção2.Imagem = global::Apresentação.Financeiro.Properties.Resources.textdoc;
            this.opção2.Location = new System.Drawing.Point(5, 80);
            this.opção2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opção2.MaximumSize = new System.Drawing.Size(150, 100);
            this.opção2.MinimumSize = new System.Drawing.Size(150, 16);
            this.opção2.Name = "opção2";
            this.opção2.Size = new System.Drawing.Size(150, 21);
            this.opção2.TabIndex = 3;
            // 
            // BaseOpções
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseOpções";
            this.Size = new System.Drawing.Size(803, 481);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.quadro4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opção1;
        private Apresentação.Formulários.Quadro quadro3;
        private Apresentação.Formulários.Quadro quadro2;
        private Apresentação.Formulários.Opção opçãoCCusto;
        private Apresentação.Formulários.Opção opçãoMercadorias;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Apresentação.Formulários.Opção opçãoCotações;
        private Apresentação.Formulários.Quadro quadro4;
        private Apresentação.Formulários.Opção opçãoSetores;
        private Apresentação.Formulários.Opção opção2;
    }
}
