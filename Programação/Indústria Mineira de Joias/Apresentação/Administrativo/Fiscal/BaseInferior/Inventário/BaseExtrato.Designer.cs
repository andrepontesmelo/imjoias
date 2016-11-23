namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    partial class BaseExtrato
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
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.txtMercadoria = new Apresentação.Mercadoria.TxtMercadoria();
            this.label1 = new System.Windows.Forms.Label();
            this.listaExtrato = new Apresentação.Administrativo.Fiscal.Lista.ListaExtrato();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstoqueAnterior = new System.Windows.Forms.TextBox();
            this.comboFechamento = new Apresentação.Administrativo.Fiscal.Combo.ComboFechamento();
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
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Detalhamento da movimentação fiscal";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.fiscal1;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(604, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Extrato do inventário";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoImprimir);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 60);
            this.quadro1.TabIndex = 2;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Ações";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora___163;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 30);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.TabIndex = 2;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // txtMercadoria
            // 
            this.txtMercadoria.Location = new System.Drawing.Point(260, 79);
            this.txtMercadoria.Name = "txtMercadoria";
            this.txtMercadoria.Referência = "";
            this.txtMercadoria.Size = new System.Drawing.Size(192, 20);
            this.txtMercadoria.TabIndex = 7;
            this.txtMercadoria.ReferênciaConfirmada += new System.EventHandler(this.txtMercadoria_ReferênciaConfirmada);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Referência:";
            // 
            // listaExtrato
            // 
            this.listaExtrato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaExtrato.Location = new System.Drawing.Point(193, 124);
            this.listaExtrato.Name = "listaExtrato";
            this.listaExtrato.Size = new System.Drawing.Size(604, 157);
            this.listaExtrato.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Est. anterior:";
            // 
            // txtEstoqueAnterior
            // 
            this.txtEstoqueAnterior.Enabled = false;
            this.txtEstoqueAnterior.Location = new System.Drawing.Point(260, 101);
            this.txtEstoqueAnterior.Name = "txtEstoqueAnterior";
            this.txtEstoqueAnterior.Size = new System.Drawing.Size(192, 20);
            this.txtEstoqueAnterior.TabIndex = 18;
            // 
            // comboFechamento
            // 
            this.comboFechamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFechamento.Location = new System.Drawing.Point(458, 101);
            this.comboFechamento.Name = "comboFechamento";
            this.comboFechamento.Size = new System.Drawing.Size(339, 22);
            this.comboFechamento.TabIndex = 19;
            this.comboFechamento.SelectedIndexChanged += new System.EventHandler(this.comboFechamento_SelectedIndexChanged);
            // 
            // BaseExtrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboFechamento);
            this.Controls.Add(this.txtEstoqueAnterior);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listaExtrato);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMercadoria);
            this.Controls.Add(this.título);
            this.Name = "BaseExtrato";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.txtMercadoria, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.listaExtrato, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtEstoqueAnterior, 0);
            this.Controls.SetChildIndex(this.comboFechamento, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Formulários.TítuloBaseInferior título;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoImprimir;
        private Mercadoria.TxtMercadoria txtMercadoria;
        private System.Windows.Forms.Label label1;
        private Lista.ListaExtrato listaExtrato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstoqueAnterior;
        private Combo.ComboFechamento comboFechamento;
    }
}
