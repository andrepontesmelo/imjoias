namespace Apresentação.Financeiro.Pagamento
{
    partial class BasePagamentos
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
            this.quadro = new Apresentação.Formulários.Quadro();
            this.lista = new Apresentação.Financeiro.Pagamento.ListaPagamento();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "São listados todos os pagamentos deste cliente. São mostrados tanto pagamentos re" +
                "lacionados à vendas quanto os sem vinculo direto.";
            this.títuloBaseInferior.Imagem = global::Apresentação.Financeiro.Properties.Resources.moeda;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(590, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Pagamentos de <pessoa>";
            // 
            // quadro
            // 
            this.quadro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro.bInfDirArredondada = false;
            this.quadro.bInfEsqArredondada = false;
            this.quadro.bSupDirArredondada = true;
            this.quadro.bSupEsqArredondada = true;
            this.quadro.Controls.Add(this.lista);
            this.quadro.Cor = System.Drawing.Color.Black;
            this.quadro.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro.LetraTítulo = System.Drawing.Color.White;
            this.quadro.Location = new System.Drawing.Point(193, 79);
            this.quadro.MostrarBotãoMinMax = false;
            this.quadro.Name = "quadro";
            this.quadro.Size = new System.Drawing.Size(590, 217);
            this.quadro.TabIndex = 7;
            this.quadro.Tamanho = 30;
            this.quadro.Título = "Pagamentos";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(0, 26);
            this.lista.MostrarToolStrip = true;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(587, 191);
            this.lista.TabIndex = 2;
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.label4);
            this.quadro1.Controls.Add(this.label3);
            this.quadro1.Controls.Add(this.label2);
            this.quadro1.Controls.Add(this.label1);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 79);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 150);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Legenda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Com fundo amarelo:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pagamentos pendentes ainda não vencidos.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Escrito em vermelho:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(17, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pagamentos pendentes já vencidos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoImprimir);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 13);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 60);
            this.quadro2.TabIndex = 2;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Impressão";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Financeiro.Properties.Resources.impressora___16;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 36);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 2;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // BasePagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro);
            this.Controls.Add(this.títuloBaseInferior);
            this.Name = "BasePagamentos";
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.quadro, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro1.PerformLayout();
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadro;
        private ListaPagamento lista;
        private Apresentação.Formulários.Quadro quadro2;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Quadro quadro1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
