namespace Apresenta��o.Financeiro.Indicadores
{
    partial class Gr�ficoCota��o
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
            this.gr�fico = new Apresenta��o.Estat�stica.Windows.Gr�ficoLinhas();
            this.SuspendLayout();
            // 
            // gr�fico
            // 
            this.gr�fico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gr�fico.BackColor = System.Drawing.Color.White;
            this.gr�fico.EixoX = "Dia";
            this.gr�fico.EixoY = "Valor";
            this.gr�fico.FundoCor = System.Drawing.Color.White;
            this.gr�fico.GapHorizontal = 0;
            this.gr�fico.InteiroY = false;
            this.gr�fico.Legendas = null;
            this.gr�fico.Location = new System.Drawing.Point(5, 27);
            this.gr�fico.Name = "gr�fico";
            this.gr�fico.Size = new System.Drawing.Size(276, 197);
            this.gr�fico.TabIndex = 2;
            // 
            // Gr�ficoCota��oOuro
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gr�fico);
            this.Name = "Gr�ficoCota��oOuro";
            this.Size = new System.Drawing.Size(286, 228);
            this.T�tulo = "Cota��o do Ouro";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Gr�ficoCota��oOuro_Paint);
            this.Controls.SetChildIndex(this.gr�fico, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Estat�stica.Windows.Gr�ficoLinhas gr�fico;
    }
}
