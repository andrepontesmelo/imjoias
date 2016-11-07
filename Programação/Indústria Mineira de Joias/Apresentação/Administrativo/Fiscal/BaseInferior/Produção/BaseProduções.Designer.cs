namespace Apresentação.Administrativo.Fiscal.BaseInferior.Produção
{
    partial class BaseProduções
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
            this.opçãoNovaProdução = new Apresentação.Formulários.Opção();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.listaProduções1 = new Apresentação.Administrativo.Fiscal.Lista.ListaProduções();
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
            this.quadro1.Controls.Add(this.opçãoNovaProdução);
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
            // opçãoNovaProdução
            // 
            this.opçãoNovaProdução.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovaProdução.Descrição = "Nova produção";
            this.opçãoNovaProdução.Imagem = global::Apresentação.Resource.document1;
            this.opçãoNovaProdução.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovaProdução.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovaProdução.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovaProdução.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovaProdução.Name = "opçãoNovaProdução";
            this.opçãoNovaProdução.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovaProdução.TabIndex = 2;
            this.opçãoNovaProdução.Click += new System.EventHandler(this.opçãoNovaProdução_Click);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Produção é um documento indica a fabricação ou produção de um item de inventário." +
    "";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.fiscal1;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 13);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(589, 70);
            this.títuloBaseInferior1.TabIndex = 7;
            this.títuloBaseInferior1.Título = "Produções";
            // 
            // listaProduções1
            // 
            this.listaProduções1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaProduções1.Location = new System.Drawing.Point(193, 89);
            this.listaProduções1.Name = "listaProduções1";
            this.listaProduções1.Size = new System.Drawing.Size(604, 204);
            this.listaProduções1.TabIndex = 8;
            // 
            // BaseProduções
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listaProduções1);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseProduções";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.listaProduções1, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro1;
        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Opção opçãoNovaProdução;
        private Lista.ListaProduções listaProduções1;
    }
}
