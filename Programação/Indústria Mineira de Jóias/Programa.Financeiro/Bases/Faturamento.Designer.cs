namespace Programa.Financeiro.Bases
{
    partial class Faturamento
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
            this.gráficoFaturamentoMercadoria1 = new Apresentação.Financeiro.Indicadores.GráficoFaturamentoMercadoria();
            this.SuspendLayout();
            // 
            // gráficoFaturamentoMercadoria1
            // 
            this.gráficoFaturamentoMercadoria1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gráficoFaturamentoMercadoria1.Location = new System.Drawing.Point(226, 29);
            this.gráficoFaturamentoMercadoria1.Name = "gráficoFaturamentoMercadoria1";
            this.gráficoFaturamentoMercadoria1.Size = new System.Drawing.Size(545, 241);
            this.gráficoFaturamentoMercadoria1.TabIndex = 6;
            // 
            // Faturamento
            // 
            this.Controls.Add(this.gráficoFaturamentoMercadoria1);
            this.Name = "Faturamento";
            this.Controls.SetChildIndex(this.gráficoFaturamentoMercadoria1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Financeiro.Indicadores.GráficoFaturamentoMercadoria gráficoFaturamentoMercadoria1;
    }
}
