namespace Apresentação.Estoque
{
    partial class BaseZerarEstoque
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
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.opçãoZerarEstoqueAgora = new Apresentação.Formulários.Opção();
            this.txtObservações = new System.Windows.Forms.TextBox();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.listaZeragemEstoque1 = new Entidades.Estoque.ListaZeragemEstoque();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 378);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "A contabilização de entradas e vendas para o controle de estoque só leva em consi" +
    "deração a última data desta lista. ";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.none;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(204, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(580, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Zerar Estoque";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.label1);
            this.quadro1.Controls.Add(this.opçãoZerarEstoqueAgora);
            this.quadro1.Controls.Add(this.txtObservações);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 79);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 224);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Zerar Estoque";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descrição:";
            // 
            // opçãoZerarEstoqueAgora
            // 
            this.opçãoZerarEstoqueAgora.BackColor = System.Drawing.Color.Transparent;
            this.opçãoZerarEstoqueAgora.Descrição = "Zerar estoque agora";
            this.opçãoZerarEstoqueAgora.Imagem = global::Apresentação.Resource.none;
            this.opçãoZerarEstoqueAgora.Location = new System.Drawing.Point(7, 200);
            this.opçãoZerarEstoqueAgora.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoZerarEstoqueAgora.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoZerarEstoqueAgora.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoZerarEstoqueAgora.Name = "opçãoZerarEstoqueAgora";
            this.opçãoZerarEstoqueAgora.Size = new System.Drawing.Size(150, 18);
            this.opçãoZerarEstoqueAgora.TabIndex = 3;
            this.opçãoZerarEstoqueAgora.Click += new System.EventHandler(this.opçãoZerarEstoqueAgora_Click);
            // 
            // txtObservações
            // 
            this.txtObservações.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtObservações.Location = new System.Drawing.Point(10, 46);
            this.txtObservações.MaxLength = 255;
            this.txtObservações.Multiline = true;
            this.txtObservações.Name = "txtObservações";
            this.txtObservações.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservações.Size = new System.Drawing.Size(140, 143);
            this.txtObservações.TabIndex = 2;
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
            this.quadro2.Controls.Add(this.listaZeragemEstoque1);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(193, 76);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(591, 292);
            this.quadro2.TabIndex = 7;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Histórico de estoque zerado";
            // 
            // listaZeragemEstoque1
            // 
            this.listaZeragemEstoque1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaZeragemEstoque1.Location = new System.Drawing.Point(0, 22);
            this.listaZeragemEstoque1.Name = "listaZeragemEstoque1";
            this.listaZeragemEstoque1.Size = new System.Drawing.Size(591, 270);
            this.listaZeragemEstoque1.TabIndex = 2;
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.opçãoExcluir);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 13);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 60);
            this.quadro3.TabIndex = 2;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Seleção";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir registro(s)";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoExcluir.Location = new System.Drawing.Point(7, 30);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 18);
            this.opçãoExcluir.TabIndex = 4;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // BaseZerarEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro2);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Name = "BaseZerarEstoque";
            this.Size = new System.Drawing.Size(800, 378);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.quadro2, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.quadro2.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoZerarEstoqueAgora;
        private System.Windows.Forms.TextBox txtObservações;
        private System.Windows.Forms.Label label1;
        private Formulários.Quadro quadro2;
        private Entidades.Estoque.ListaZeragemEstoque listaZeragemEstoque1;
        private Formulários.Quadro quadro3;
        private Formulários.Opção opçãoExcluir;
    }
}
