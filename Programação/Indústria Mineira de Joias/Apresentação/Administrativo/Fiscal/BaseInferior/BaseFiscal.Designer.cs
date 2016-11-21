namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFiscal));
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.opçãoImportação = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoSaídas = new Apresentação.Formulários.Opção();
            this.opçãoFabricações = new Apresentação.Formulários.Opção();
            this.opçãoEntradas = new Apresentação.Formulários.Opção();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.opçãoMáquinasECF = new Apresentação.Formulários.Opção();
            this.opçãoEsquemas = new Apresentação.Formulários.Opção();
            this.opçãoImportarTransição = new Apresentação.Formulários.Opção();
            this.quadro4 = new Apresentação.Formulários.Quadro();
            this.opçãoInventário = new Apresentação.Formulários.Opção();
            this.quadro5 = new Apresentação.Formulários.Quadro();
            this.opçãoImportarEstoqueAnteriorSistemaLegado = new Apresentação.Formulários.Opção();
            this.opçãoImportarPreçosMatériasPrimas = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.quadro4.SuspendLayout();
            this.quadro5.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro5);
            this.esquerda.Controls.Add(this.quadro4);
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 520);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro4, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro5, 0);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.label1);
            this.quadro1.Controls.Add(this.opçãoImportação);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 14);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 96);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Importação";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Importação de arquivos fiscais.";
            // 
            // opçãoImportação
            // 
            this.opçãoImportação.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportação.Descrição = "Importar";
            this.opçãoImportação.Imagem = global::Apresentação.Resource.importar21;
            this.opçãoImportação.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.opçãoImportação.Location = new System.Drawing.Point(7, 70);
            this.opçãoImportação.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportação.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportação.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportação.Name = "opçãoImportação";
            this.opçãoImportação.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportação.TabIndex = 5;
            this.opçãoImportação.Click += new System.EventHandler(this.opçãoImportação_Click);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Acesso aos documentos fiscais da empresa.";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = ((System.Drawing.Image)(resources.GetObject("títuloBaseInferior1.Imagem")));
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 14);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(592, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Fiscal";
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoSaídas);
            this.quadro2.Controls.Add(this.opçãoFabricações);
            this.quadro2.Controls.Add(this.opçãoEntradas);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 116);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 94);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Processos";
            // 
            // opçãoSaídas
            // 
            this.opçãoSaídas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSaídas.Descrição = "Saídas";
            this.opçãoSaídas.Imagem = global::Apresentação.Resource.ARW04LT;
            this.opçãoSaídas.Location = new System.Drawing.Point(7, 70);
            this.opçãoSaídas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoSaídas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSaídas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSaídas.Name = "opçãoSaídas";
            this.opçãoSaídas.Size = new System.Drawing.Size(150, 16);
            this.opçãoSaídas.TabIndex = 4;
            this.opçãoSaídas.Click += new System.EventHandler(this.opçãoSaídas_Click);
            // 
            // opçãoFabricações
            // 
            this.opçãoFabricações.BackColor = System.Drawing.Color.Transparent;
            this.opçãoFabricações.Descrição = "Fabricações";
            this.opçãoFabricações.Imagem = global::Apresentação.Resource.Deep_Refresh;
            this.opçãoFabricações.Location = new System.Drawing.Point(7, 50);
            this.opçãoFabricações.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoFabricações.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoFabricações.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoFabricações.Name = "opçãoFabricações";
            this.opçãoFabricações.Size = new System.Drawing.Size(150, 16);
            this.opçãoFabricações.TabIndex = 3;
            this.opçãoFabricações.Click += new System.EventHandler(this.opçãoFabricações_Click);
            // 
            // opçãoEntradas
            // 
            this.opçãoEntradas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEntradas.Descrição = "Entradas";
            this.opçãoEntradas.Imagem = global::Apresentação.Resource.ARW04RT;
            this.opçãoEntradas.Location = new System.Drawing.Point(7, 30);
            this.opçãoEntradas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEntradas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEntradas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEntradas.Name = "opçãoEntradas";
            this.opçãoEntradas.Size = new System.Drawing.Size(150, 16);
            this.opçãoEntradas.TabIndex = 2;
            this.opçãoEntradas.Click += new System.EventHandler(this.opçãoEntradas_Click);
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.opçãoMáquinasECF);
            this.quadro3.Controls.Add(this.opçãoEsquemas);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 277);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 94);
            this.quadro3.TabIndex = 8;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Manutenção";
            // 
            // opçãoMáquinasECF
            // 
            this.opçãoMáquinasECF.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMáquinasECF.Descrição = "Máquinas ECF";
            this.opçãoMáquinasECF.Imagem = global::Apresentação.Resource.fiscal;
            this.opçãoMáquinasECF.Location = new System.Drawing.Point(7, 70);
            this.opçãoMáquinasECF.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMáquinasECF.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMáquinasECF.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMáquinasECF.Name = "opçãoMáquinasECF";
            this.opçãoMáquinasECF.Size = new System.Drawing.Size(150, 16);
            this.opçãoMáquinasECF.TabIndex = 4;
            this.opçãoMáquinasECF.Click += new System.EventHandler(this.opçãoMáquinasECF_Click);
            // 
            // opçãoEsquemas
            // 
            this.opçãoEsquemas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEsquemas.Descrição = "Esquemas";
            this.opçãoEsquemas.Imagem = global::Apresentação.Resource.repair;
            this.opçãoEsquemas.Location = new System.Drawing.Point(7, 30);
            this.opçãoEsquemas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEsquemas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEsquemas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEsquemas.Name = "opçãoEsquemas";
            this.opçãoEsquemas.Size = new System.Drawing.Size(150, 16);
            this.opçãoEsquemas.TabIndex = 2;
            this.opçãoEsquemas.Click += new System.EventHandler(this.opçãoEsquemas_Click);
            // 
            // opçãoImportarTransição
            // 
            this.opçãoImportarTransição.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportarTransição.Descrição = "Preencher entrada de transição";
            this.opçãoImportarTransição.Imagem = global::Apresentação.Resource.repair;
            this.opçãoImportarTransição.Location = new System.Drawing.Point(7, 80);
            this.opçãoImportarTransição.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportarTransição.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportarTransição.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportarTransição.Name = "opçãoImportarTransição";
            this.opçãoImportarTransição.Size = new System.Drawing.Size(150, 26);
            this.opçãoImportarTransição.TabIndex = 5;
            this.opçãoImportarTransição.Click += new System.EventHandler(this.opçãoImportar_Click);
            // 
            // quadro4
            // 
            this.quadro4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro4.bInfDirArredondada = true;
            this.quadro4.bInfEsqArredondada = true;
            this.quadro4.bSupDirArredondada = true;
            this.quadro4.bSupEsqArredondada = true;
            this.quadro4.Controls.Add(this.opçãoInventário);
            this.quadro4.Cor = System.Drawing.Color.Black;
            this.quadro4.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro4.LetraTítulo = System.Drawing.Color.White;
            this.quadro4.Location = new System.Drawing.Point(7, 214);
            this.quadro4.MostrarBotãoMinMax = false;
            this.quadro4.Name = "quadro4";
            this.quadro4.Size = new System.Drawing.Size(160, 57);
            this.quadro4.TabIndex = 9;
            this.quadro4.Tamanho = 30;
            this.quadro4.Título = "Inventário";
            // 
            // opçãoInventário
            // 
            this.opçãoInventário.BackColor = System.Drawing.Color.Transparent;
            this.opçãoInventário.Descrição = "Inventário";
            this.opçãoInventário.Imagem = global::Apresentação.Resource.fiscal1;
            this.opçãoInventário.Location = new System.Drawing.Point(7, 30);
            this.opçãoInventário.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoInventário.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoInventário.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoInventário.Name = "opçãoInventário";
            this.opçãoInventário.Size = new System.Drawing.Size(150, 16);
            this.opçãoInventário.TabIndex = 2;
            this.opçãoInventário.Click += new System.EventHandler(this.opçãoInventário_Click);
            // 
            // quadro5
            // 
            this.quadro5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro5.bInfDirArredondada = true;
            this.quadro5.bInfEsqArredondada = true;
            this.quadro5.bSupDirArredondada = true;
            this.quadro5.bSupEsqArredondada = true;
            this.quadro5.Controls.Add(this.opçãoImportarPreçosMatériasPrimas);
            this.quadro5.Controls.Add(this.opçãoImportarTransição);
            this.quadro5.Controls.Add(this.opçãoImportarEstoqueAnteriorSistemaLegado);
            this.quadro5.Cor = System.Drawing.Color.Black;
            this.quadro5.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro5.LetraTítulo = System.Drawing.Color.White;
            this.quadro5.Location = new System.Drawing.Point(7, 377);
            this.quadro5.MostrarBotãoMinMax = false;
            this.quadro5.Name = "quadro5";
            this.quadro5.Size = new System.Drawing.Size(160, 117);
            this.quadro5.TabIndex = 10;
            this.quadro5.Tamanho = 30;
            this.quadro5.Título = "Sistema Legado";
            // 
            // opçãoImportarEstoqueAnteriorSistemaLegado
            // 
            this.opçãoImportarEstoqueAnteriorSistemaLegado.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportarEstoqueAnteriorSistemaLegado.Descrição = "Importar Est. Ant. Cadmer";
            this.opçãoImportarEstoqueAnteriorSistemaLegado.Imagem = global::Apresentação.Resource.repair;
            this.opçãoImportarEstoqueAnteriorSistemaLegado.Location = new System.Drawing.Point(7, 60);
            this.opçãoImportarEstoqueAnteriorSistemaLegado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportarEstoqueAnteriorSistemaLegado.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportarEstoqueAnteriorSistemaLegado.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportarEstoqueAnteriorSistemaLegado.Name = "opçãoImportarEstoqueAnteriorSistemaLegado";
            this.opçãoImportarEstoqueAnteriorSistemaLegado.Size = new System.Drawing.Size(150, 16);
            this.opçãoImportarEstoqueAnteriorSistemaLegado.TabIndex = 2;
            this.opçãoImportarEstoqueAnteriorSistemaLegado.Click += new System.EventHandler(this.opçãoImportarEstoqueAnteriorSistemaLegado_Click);
            // 
            // opçãoImportarPreçosMatériasPrimas
            // 
            this.opçãoImportarPreçosMatériasPrimas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportarPreçosMatériasPrimas.Descrição = "Importar Preços Matérias Primas";
            this.opçãoImportarPreçosMatériasPrimas.Imagem = global::Apresentação.Resource.repair;
            this.opçãoImportarPreçosMatériasPrimas.Location = new System.Drawing.Point(7, 30);
            this.opçãoImportarPreçosMatériasPrimas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportarPreçosMatériasPrimas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportarPreçosMatériasPrimas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportarPreçosMatériasPrimas.Name = "opçãoImportarPreçosMatériasPrimas";
            this.opçãoImportarPreçosMatériasPrimas.Size = new System.Drawing.Size(150, 31);
            this.opçãoImportarPreçosMatériasPrimas.TabIndex = 6;
            this.opçãoImportarPreçosMatériasPrimas.Click += new System.EventHandler(this.opçãoImportarPreçosMatériasPrimas_Click);
            // 
            // BaseFiscal
            // 
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseFiscal";
            this.Size = new System.Drawing.Size(801, 520);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.quadro4.ResumeLayout(false);
            this.quadro5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro1;
        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private System.Windows.Forms.Label label1;
        private Formulários.Opção opçãoImportação;
        private Formulários.Quadro quadro2;
        private Formulários.Opção opçãoSaídas;
        private Formulários.Opção opçãoFabricações;
        private Formulários.Opção opçãoEntradas;
        private Formulários.Quadro quadro3;
        private Formulários.Opção opçãoMáquinasECF;
        private Formulários.Opção opçãoEsquemas;
        private Formulários.Quadro quadro4;
        private Formulários.Opção opçãoInventário;
        private Formulários.Opção opçãoImportarTransição;
        private Formulários.Quadro quadro5;
        private Formulários.Opção opçãoImportarEstoqueAnteriorSistemaLegado;
        private Formulários.Opção opçãoImportarPreçosMatériasPrimas;
    }
}
