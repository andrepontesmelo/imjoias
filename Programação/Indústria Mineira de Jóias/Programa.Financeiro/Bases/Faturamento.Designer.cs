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
            this.gr�ficoFaturamentoMercadoria1 = new Apresenta��o.Financeiro.Indicadores.Gr�ficoFaturamentoMercadoria();
            this.SuspendLayout();
            // 
            // gr�ficoFaturamentoMercadoria1
            // 
            this.gr�ficoFaturamentoMercadoria1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gr�ficoFaturamentoMercadoria1.Location = new System.Drawing.Point(226, 29);
            this.gr�ficoFaturamentoMercadoria1.Name = "gr�ficoFaturamentoMercadoria1";
            this.gr�ficoFaturamentoMercadoria1.Size = new System.Drawing.Size(545, 241);
            this.gr�ficoFaturamentoMercadoria1.TabIndex = 6;
            // 
            // Faturamento
            // 
            this.Controls.Add(this.gr�ficoFaturamentoMercadoria1);
            this.Name = "Faturamento";
            this.Controls.SetChildIndex(this.gr�ficoFaturamentoMercadoria1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Financeiro.Indicadores.Gr�ficoFaturamentoMercadoria gr�ficoFaturamentoMercadoria1;
    }
}
