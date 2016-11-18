namespace Apresentação.Financeiro.Comissões.BaseInferior
{
    partial class BaseVendaSemComissão
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
            this.listViewVendas = new Apresentação.Financeiro.Venda.ListViewVendas();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.semaforoLegenda1 = new Apresentação.Financeiro.Venda.SemaforoLegenda();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.semaforoLegenda1);
            this.esquerda.Size = new System.Drawing.Size(187, 342);
            this.esquerda.Controls.SetChildIndex(this.semaforoLegenda1, 0);
            // 
            // listViewVendas
            // 
            this.listViewVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewVendas.ItemSelecionado = null;
            this.listViewVendas.Location = new System.Drawing.Point(193, 90);
            this.listViewVendas.Name = "listViewVendas";
            this.listViewVendas.Size = new System.Drawing.Size(592, 238);
            this.listViewVendas.TabIndex = 6;
            this.listViewVendas.AoDuploClique += new Apresentação.Financeiro.Venda.ListViewVendas.DelegaçãoVenda(this.listViewVendas_AoDuploClique);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Todas as vendas sem comissão.";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = null;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 19);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(592, 70);
            this.títuloBaseInferior1.TabIndex = 7;
            this.títuloBaseInferior1.Título = "Vendas sem comissão";
            // 
            // semaforoLegenda1
            // 
            this.semaforoLegenda1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.semaforoLegenda1.bInfDirArredondada = true;
            this.semaforoLegenda1.bInfEsqArredondada = true;
            this.semaforoLegenda1.bSupDirArredondada = true;
            this.semaforoLegenda1.bSupEsqArredondada = true;
            this.semaforoLegenda1.Cor = System.Drawing.Color.Black;
            this.semaforoLegenda1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.semaforoLegenda1.LetraTítulo = System.Drawing.Color.White;
            this.semaforoLegenda1.Location = new System.Drawing.Point(7, 13);
            this.semaforoLegenda1.MostrarBotãoMinMax = false;
            this.semaforoLegenda1.Name = "semaforoLegenda1";
            this.semaforoLegenda1.Size = new System.Drawing.Size(160, 152);
            this.semaforoLegenda1.TabIndex = 1;
            this.semaforoLegenda1.Tamanho = 30;
            this.semaforoLegenda1.Título = "Legenda";
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // BaseVendaSemComissão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.listViewVendas);
            this.Name = "BaseVendaSemComissão";
            this.Size = new System.Drawing.Size(800, 342);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.listViewVendas, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private Venda.ListViewVendas listViewVendas;
        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Venda.SemaforoLegenda semaforoLegenda1;
        private System.ComponentModel.BackgroundWorker bg;
    }
}
