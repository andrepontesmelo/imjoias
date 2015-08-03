namespace Apresentação.Financeiro.Comissão
{
    partial class BaseComissão
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
            this.lista = new Apresentação.Financeiro.Venda.ListViewVendas();
            this.quadroTotal = new Apresentação.Formulários.Quadro();
            this.opçãoCalcular = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoEscolherPeríodo = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro.SuspendLayout();
            this.quadroTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroTotal);
            this.esquerda.Controls.Add(this.opçãoEscolherPeríodo);
            this.esquerda.Controls.Add(this.opçãoImprimir);
            this.esquerda.Size = new System.Drawing.Size(187, 439);
            this.esquerda.Controls.SetChildIndex(this.opçãoImprimir, 0);
            this.esquerda.Controls.SetChildIndex(this.opçãoEscolherPeríodo, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroTotal, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Calcule a comissão de um determinado vendedor";
            this.títuloBaseInferior.Imagem = global::Apresentação.Financeiro.Properties.Resources.moeda;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(604, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Comissão";
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
            this.quadro.Size = new System.Drawing.Size(604, 357);
            this.quadro.TabIndex = 8;
            this.quadro.Tamanho = 30;
            this.quadro.Título = "Vendas";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.ApenasNãoAcertado = false;
            this.lista.Location = new System.Drawing.Point(0, 25);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(604, 332);
            this.lista.TabIndex = 8;
            // 
            // quadroTotal
            // 
            this.quadroTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroTotal.bInfDirArredondada = true;
            this.quadroTotal.bInfEsqArredondada = true;
            this.quadroTotal.bSupDirArredondada = true;
            this.quadroTotal.bSupEsqArredondada = true;
            this.quadroTotal.Controls.Add(this.opçãoCalcular);
            this.quadroTotal.Cor = System.Drawing.Color.Black;
            this.quadroTotal.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroTotal.LetraTítulo = System.Drawing.Color.White;
            this.quadroTotal.Location = new System.Drawing.Point(7, 13);
            this.quadroTotal.MostrarBotãoMinMax = false;
            this.quadroTotal.Name = "quadroTotal";
            this.quadroTotal.Size = new System.Drawing.Size(160, 49);
            this.quadroTotal.TabIndex = 1;
            this.quadroTotal.Tamanho = 30;
            this.quadroTotal.Título = "Opções";
            // 
            // opçãoCalcular
            // 
            this.opçãoCalcular.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCalcular.Descrição = "Calcular";
            this.opçãoCalcular.Imagem = global::Apresentação.Financeiro.Properties.Resources.ok;
            this.opçãoCalcular.Location = new System.Drawing.Point(10, 25);
            this.opçãoCalcular.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCalcular.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCalcular.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCalcular.Name = "opçãoCalcular";
            this.opçãoCalcular.Size = new System.Drawing.Size(150, 24);
            this.opçãoCalcular.TabIndex = 5;
            this.opçãoCalcular.Click += new System.EventHandler(this.opçãoCalcular_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Financeiro.Properties.Resources.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(12, 163);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 4;
            this.opçãoImprimir.Visible = false;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoEscolherPeríodo
            // 
            this.opçãoEscolherPeríodo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEscolherPeríodo.Descrição = "Escolher o período";
            this.opçãoEscolherPeríodo.Imagem = global::Apresentação.Financeiro.Properties.Resources.ok;
            this.opçãoEscolherPeríodo.Location = new System.Drawing.Point(12, 139);
            this.opçãoEscolherPeríodo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEscolherPeríodo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEscolherPeríodo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEscolherPeríodo.Name = "opçãoEscolherPeríodo";
            this.opçãoEscolherPeríodo.Size = new System.Drawing.Size(150, 24);
            this.opçãoEscolherPeríodo.TabIndex = 3;
            this.opçãoEscolherPeríodo.Visible = false;
            this.opçãoEscolherPeríodo.Click += new System.EventHandler(this.opçãoEscolherPeríodo_Click);
            // 
            // BaseComissão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.quadro);
            this.Name = "BaseComissão";
            this.Size = new System.Drawing.Size(800, 439);
            this.Controls.SetChildIndex(this.quadro, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro.ResumeLayout(false);
            this.quadroTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadro;
        private Apresentação.Financeiro.Venda.ListViewVendas lista;
        private Apresentação.Formulários.Quadro quadroTotal;
        private Apresentação.Formulários.Opção opçãoEscolherPeríodo;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Opção opçãoCalcular;
    }
}
