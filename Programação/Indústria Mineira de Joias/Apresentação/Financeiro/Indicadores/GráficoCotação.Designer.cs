namespace Apresentação.Financeiro.Indicadores
{
    partial class GráficoCotação
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
            this.gráfico = new Apresentação.Estatística.Windows.GráficoLinhas();
            this.SuspendLayout();
            // 
            // gráfico
            // 
            this.gráfico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gráfico.BackColor = System.Drawing.Color.White;
            this.gráfico.EixoX = "Dia";
            this.gráfico.EixoY = "Valor";
            this.gráfico.FundoCor = System.Drawing.Color.White;
            this.gráfico.GapHorizontal = 0;
            this.gráfico.InteiroY = false;
            this.gráfico.Legendas = null;
            this.gráfico.Location = new System.Drawing.Point(5, 27);
            this.gráfico.Name = "gráfico";
            this.gráfico.Size = new System.Drawing.Size(276, 197);
            this.gráfico.TabIndex = 2;
            // 
            // GráficoCotaçãoOuro
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gráfico);
            this.Name = "GráficoCotaçãoOuro";
            this.Size = new System.Drawing.Size(286, 228);
            this.Título = "Cotação do Ouro";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GráficoCotaçãoOuro_Paint);
            this.Controls.SetChildIndex(this.gráfico, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Estatística.Windows.GráficoLinhas gráfico;
    }
}
