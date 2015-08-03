namespace Apresentação.Mercadoria.Manutenção.Faixa
{
    partial class BaseEdiçãoFaixas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEdiçãoFaixas));
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoNovaFaixa = new Apresentação.Formulários.Opção();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.faixaItem1 = new Apresentação.Mercadoria.Manutenção.Faixa.FaixaItem();
            this.faixaItem2 = new Apresentação.Mercadoria.Manutenção.Faixa.FaixaItem();
            this.faixaItem3 = new Apresentação.Mercadoria.Manutenção.Faixa.FaixaItem();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.flow.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Descrição";
            this.títuloBaseInferior.Imagem = null;
            this.títuloBaseInferior.Location = new System.Drawing.Point(198, 20);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(295, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Faixas da tabela Atacado ";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoNovaFaixa);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(3, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 150);
            this.quadro1.TabIndex = 1;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Faixa";
            // 
            // opçãoNovaFaixa
            // 
            this.opçãoNovaFaixa.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovaFaixa.Descrição = "Nova Faixa";
            this.opçãoNovaFaixa.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoNovaFaixa.Imagem")));
            this.opçãoNovaFaixa.Location = new System.Drawing.Point(6, 32);
            this.opçãoNovaFaixa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovaFaixa.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovaFaixa.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovaFaixa.Name = "opçãoNovaFaixa";
            this.opçãoNovaFaixa.Size = new System.Drawing.Size(150, 24);
            this.opçãoNovaFaixa.TabIndex = 2;
            // 
            // flow
            // 
            this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flow.Controls.Add(this.faixaItem1);
            this.flow.Controls.Add(this.faixaItem2);
            this.flow.Controls.Add(this.faixaItem3);
            this.flow.Location = new System.Drawing.Point(198, 96);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(282, 183);
            this.flow.TabIndex = 7;
            // 
            // faixaItem1
            // 
            this.faixaItem1.Location = new System.Drawing.Point(3, 3);
            this.faixaItem1.Name = "faixaItem1";
            this.faixaItem1.Size = new System.Drawing.Size(152, 36);
            this.faixaItem1.TabIndex = 0;
            // 
            // faixaItem2
            // 
            this.faixaItem2.Location = new System.Drawing.Point(3, 45);
            this.faixaItem2.Name = "faixaItem2";
            this.faixaItem2.Size = new System.Drawing.Size(152, 36);
            this.faixaItem2.TabIndex = 1;
            // 
            // faixaItem3
            // 
            this.faixaItem3.Location = new System.Drawing.Point(3, 87);
            this.faixaItem3.Name = "faixaItem3";
            this.faixaItem3.Size = new System.Drawing.Size(152, 36);
            this.faixaItem3.TabIndex = 2;
            // 
            // BaseEdiçãoFaixas
            // 
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.flow);
            this.Name = "BaseEdiçãoFaixas";
            this.Size = new System.Drawing.Size(496, 296);
            this.Controls.SetChildIndex(this.flow, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.flow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadro1;
        private Apresentação.Formulários.Opção opçãoNovaFaixa;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private FaixaItem faixaItem1;
        private FaixaItem faixaItem2;
        private FaixaItem faixaItem3;
    }
}
