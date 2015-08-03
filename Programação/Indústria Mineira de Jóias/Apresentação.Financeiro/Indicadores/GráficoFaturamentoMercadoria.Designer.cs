namespace Apresentação.Financeiro.Indicadores
{
    partial class GráficoFaturamentoMercadoria
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
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gráfico = new Apresentação.Estatística.Windows.GráficoBarras();
            this.lst = new System.Windows.Forms.ListView();
            this.colReferência = new System.Windows.Forms.ColumnHeader();
            this.colPeso = new System.Windows.Forms.ColumnHeader();
            this.colFaturamento = new System.Windows.Forms.ColumnHeader();
            this.colQuantidade = new System.Windows.Forms.ColumnHeader();
            this.colPos = new System.Windows.Forms.ColumnHeader();
            this.quadro1.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRecuperação_DoWork);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRecuperação_RunWorkerCompleted);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.splitContainer);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(0, 0);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(442, 195);
            this.quadro1.TabIndex = 0;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Faturamento por Mercadorias";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(3, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gráfico);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lst);
            this.splitContainer.Size = new System.Drawing.Size(436, 167);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.TabIndex = 2;
            // 
            // gráfico
            // 
            this.gráfico.BackColor = System.Drawing.Color.Transparent;
            this.gráfico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gráfico.EixoX = "Mercadoria";
            this.gráfico.EixoY = "% Faturamento";
            this.gráfico.FundoCor = System.Drawing.Color.Transparent;
            this.gráfico.GapHorizontal = 0;
            this.gráfico.InteiroY = false;
            this.gráfico.Legendas = null;
            this.gráfico.Location = new System.Drawing.Point(0, 0);
            this.gráfico.MinY = 0;
            this.gráfico.Name = "gráfico";
            this.gráfico.Size = new System.Drawing.Size(250, 167);
            this.gráfico.TabIndex = 3;
            this.gráfico.Visible = false;
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPos,
            this.colReferência,
            this.colPeso,
            this.colFaturamento,
            this.colQuantidade});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(182, 167);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.Visible = false;
            // 
            // colReferência
            // 
            this.colReferência.DisplayIndex = 1;
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 104;
            // 
            // colPeso
            // 
            this.colPeso.DisplayIndex = 2;
            this.colPeso.Text = "Peso";
            this.colPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPeso.Width = 48;
            // 
            // colFaturamento
            // 
            this.colFaturamento.DisplayIndex = 3;
            this.colFaturamento.Text = "Faturamento";
            this.colFaturamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colQuantidade
            // 
            this.colQuantidade.DisplayIndex = 4;
            this.colQuantidade.Text = "Qtd";
            this.colQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colPos
            // 
            this.colPos.DisplayIndex = 0;
            this.colPos.Text = "#";
            // 
            // GráficoFaturamentoMercadoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quadro1);
            this.Name = "GráficoFaturamentoMercadoria";
            this.Size = new System.Drawing.Size(442, 195);
            this.Load += new System.EventHandler(this.GráficoFaturamentoMercadoria_Load);
            this.quadro1.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadro1;
        private System.ComponentModel.BackgroundWorker bgRecuperação;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Apresentação.Estatística.Windows.GráficoBarras gráfico;
        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colPeso;
        private System.Windows.Forms.ColumnHeader colFaturamento;
        private System.Windows.Forms.ColumnHeader colQuantidade;
        private System.Windows.Forms.ColumnHeader colPos;
    }
}
