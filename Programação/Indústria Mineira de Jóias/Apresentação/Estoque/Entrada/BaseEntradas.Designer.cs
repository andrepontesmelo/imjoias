namespace Apresentação.Estoque.Entrada
{
    partial class BaseEntradas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEntradas));
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.opçãoNova = new Apresentação.Formulários.Opção();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.listaEntradas = new Apresentação.Estoque.Entrada.ListaEntradas();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("títuloBaseInferior1.BackgroundImage")));
            this.títuloBaseInferior1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.títuloBaseInferior1.Descrição = "Documentos de entrada relacionam a contagem do estoque.";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.VariaçãoPositiva;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 12);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(588, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Controle de Estoque - Entradas";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoExcluir);
            this.quadro1.Controls.Add(this.opçãoNova);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 82);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Ações";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoExcluir.Location = new System.Drawing.Point(10, 57);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.TabIndex = 3;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // opçãoNova
            // 
            this.opçãoNova.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNova.Descrição = "Nova";
            this.opçãoNova.Imagem = global::Apresentação.Resource._3228_icon;
            this.opçãoNova.Location = new System.Drawing.Point(10, 36);
            this.opçãoNova.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNova.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNova.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNova.Name = "opçãoNova";
            this.opçãoNova.Size = new System.Drawing.Size(150, 16);
            this.opçãoNova.TabIndex = 2;
            this.opçãoNova.Click += new System.EventHandler(this.opçãoNova_Click);
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
            this.quadro2.Controls.Add(this.listaEntradas);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(193, 70);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(588, 214);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Entradas";
            // 
            // listaEntradas
            // 
            this.listaEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaEntradas.Location = new System.Drawing.Point(0, 23);
            this.listaEntradas.Name = "listaEntradas";
            this.listaEntradas.Size = new System.Drawing.Size(588, 196);
            this.listaEntradas.TabIndex = 2;
            this.listaEntradas.AoDuploClique += new System.EventHandler(this.listaEntradas_AoDuploClique);
            // 
            // BaseEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro2);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseEntradas";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoExcluir;
        private Formulários.Opção opçãoNova;
        private Formulários.Quadro quadro2;
        private ListaEntradas listaEntradas;
    }
}
