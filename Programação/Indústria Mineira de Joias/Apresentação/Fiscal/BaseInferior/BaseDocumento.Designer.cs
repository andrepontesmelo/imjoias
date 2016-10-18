namespace Apresentação.Fiscal.BaseInferior
{
    partial class BaseDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDocumento));
            this.quadroDocumento = new Apresentação.Formulários.Quadro();
            this.opçãoExcluirDocumento = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadroPDF = new Apresentação.Formulários.Quadro();
            this.opçãoExcluirPDF = new Apresentação.Formulários.Opção();
            this.opçãoCarregar = new Apresentação.Formulários.Opção();
            this.opçãoAbrir = new Apresentação.Formulários.Opção();
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabDados = new System.Windows.Forms.TabPage();
            this.tabItens = new System.Windows.Forms.TabPage();
            this.tabObservações = new System.Windows.Forms.TabPage();
            this.esquerda.SuspendLayout();
            this.quadroDocumento.SuspendLayout();
            this.quadroPDF.SuspendLayout();
            this.tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPDF);
            this.esquerda.Controls.Add(this.quadroDocumento);
            this.esquerda.Controls.SetChildIndex(this.quadroDocumento, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroPDF, 0);
            // 
            // quadroDocumento
            // 
            this.quadroDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroDocumento.bInfDirArredondada = true;
            this.quadroDocumento.bInfEsqArredondada = true;
            this.quadroDocumento.bSupDirArredondada = true;
            this.quadroDocumento.bSupEsqArredondada = true;
            this.quadroDocumento.Controls.Add(this.opçãoExcluirDocumento);
            this.quadroDocumento.Controls.Add(this.opçãoImprimir);
            this.quadroDocumento.Cor = System.Drawing.Color.Black;
            this.quadroDocumento.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDocumento.LetraTítulo = System.Drawing.Color.White;
            this.quadroDocumento.Location = new System.Drawing.Point(7, 13);
            this.quadroDocumento.MostrarBotãoMinMax = false;
            this.quadroDocumento.Name = "quadroDocumento";
            this.quadroDocumento.Size = new System.Drawing.Size(160, 80);
            this.quadroDocumento.TabIndex = 1;
            this.quadroDocumento.Tamanho = 30;
            this.quadroDocumento.Título = "Documento";
            // 
            // opçãoExcluirDocumento
            // 
            this.opçãoExcluirDocumento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirDocumento.Descrição = "Excluir";
            this.opçãoExcluirDocumento.Imagem = global::Apresentação.Resource.none;
            this.opçãoExcluirDocumento.Location = new System.Drawing.Point(7, 50);
            this.opçãoExcluirDocumento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluirDocumento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirDocumento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirDocumento.Name = "opçãoExcluirDocumento";
            this.opçãoExcluirDocumento.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluirDocumento.TabIndex = 3;
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
            // 
            // quadroPDF
            // 
            this.quadroPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPDF.bInfDirArredondada = true;
            this.quadroPDF.bInfEsqArredondada = true;
            this.quadroPDF.bSupDirArredondada = true;
            this.quadroPDF.bSupEsqArredondada = true;
            this.quadroPDF.Controls.Add(this.opçãoExcluirPDF);
            this.quadroPDF.Controls.Add(this.opçãoCarregar);
            this.quadroPDF.Controls.Add(this.opçãoAbrir);
            this.quadroPDF.Cor = System.Drawing.Color.Black;
            this.quadroPDF.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPDF.LetraTítulo = System.Drawing.Color.White;
            this.quadroPDF.Location = new System.Drawing.Point(7, 99);
            this.quadroPDF.MostrarBotãoMinMax = false;
            this.quadroPDF.Name = "quadroPDF";
            this.quadroPDF.Size = new System.Drawing.Size(160, 94);
            this.quadroPDF.TabIndex = 2;
            this.quadroPDF.Tamanho = 30;
            this.quadroPDF.Título = "PDF";
            // 
            // opçãoExcluirPDF
            // 
            this.opçãoExcluirPDF.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluirPDF.Descrição = "Excluir";
            this.opçãoExcluirPDF.Imagem = global::Apresentação.Resource.none;
            this.opçãoExcluirPDF.Location = new System.Drawing.Point(7, 70);
            this.opçãoExcluirPDF.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluirPDF.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluirPDF.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluirPDF.Name = "opçãoExcluirPDF";
            this.opçãoExcluirPDF.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluirPDF.TabIndex = 6;
            // 
            // opçãoCarregar
            // 
            this.opçãoCarregar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCarregar.Descrição = "Carregar";
            this.opçãoCarregar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoCarregar.Imagem")));
            this.opçãoCarregar.Location = new System.Drawing.Point(7, 50);
            this.opçãoCarregar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCarregar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCarregar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCarregar.Name = "opçãoCarregar";
            this.opçãoCarregar.Size = new System.Drawing.Size(150, 16);
            this.opçãoCarregar.TabIndex = 5;
            // 
            // opçãoAbrir
            // 
            this.opçãoAbrir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrir.Descrição = "Abrir";
            this.opçãoAbrir.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAbrir.Imagem")));
            this.opçãoAbrir.Location = new System.Drawing.Point(7, 30);
            this.opçãoAbrir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAbrir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.Name = "opçãoAbrir";
            this.opçãoAbrir.Size = new System.Drawing.Size(150, 18);
            this.opçãoAbrir.TabIndex = 4;
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Descrição";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.fiscal1;
            this.título.Location = new System.Drawing.Point(197, 13);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(578, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Editar documento fiscal";
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabDados);
            this.tab.Controls.Add(this.tabItens);
            this.tab.Controls.Add(this.tabObservações);
            this.tab.Location = new System.Drawing.Point(193, 85);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(586, 199);
            this.tab.TabIndex = 7;
            // 
            // tabDados
            // 
            this.tabDados.Location = new System.Drawing.Point(4, 22);
            this.tabDados.Name = "tabDados";
            this.tabDados.Padding = new System.Windows.Forms.Padding(3);
            this.tabDados.Size = new System.Drawing.Size(578, 165);
            this.tabDados.TabIndex = 0;
            this.tabDados.Text = "Dados";
            this.tabDados.UseVisualStyleBackColor = true;
            // 
            // tabItens
            // 
            this.tabItens.Location = new System.Drawing.Point(4, 22);
            this.tabItens.Name = "tabItens";
            this.tabItens.Padding = new System.Windows.Forms.Padding(3);
            this.tabItens.Size = new System.Drawing.Size(578, 165);
            this.tabItens.TabIndex = 1;
            this.tabItens.Text = "Itens";
            this.tabItens.UseVisualStyleBackColor = true;
            // 
            // tabObservações
            // 
            this.tabObservações.Location = new System.Drawing.Point(4, 22);
            this.tabObservações.Name = "tabObservações";
            this.tabObservações.Padding = new System.Windows.Forms.Padding(3);
            this.tabObservações.Size = new System.Drawing.Size(578, 173);
            this.tabObservações.TabIndex = 2;
            this.tabObservações.Text = "Observações";
            this.tabObservações.UseVisualStyleBackColor = true;
            // 
            // BaseDocumento
            // 
            this.Controls.Add(this.tab);
            this.Controls.Add(this.título);
            this.Name = "BaseDocumento";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroDocumento.ResumeLayout(false);
            this.quadroPDF.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadroDocumento;
        private Formulários.Quadro quadroPDF;
        private Formulários.Opção opçãoImprimir;
        private Formulários.Opção opçãoExcluirPDF;
        private Formulários.Opção opçãoCarregar;
        private Formulários.Opção opçãoAbrir;
        private Formulários.Opção opçãoExcluirDocumento;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabDados;
        private System.Windows.Forms.TabPage tabItens;
        private System.Windows.Forms.TabPage tabObservações;
        protected Formulários.TítuloBaseInferior título;
    }
}
