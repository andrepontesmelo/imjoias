namespace Apresenta��o.Financeiro.Pagamento
{
    partial class CadastroDinheiro
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // chkPagamentoPendente
            // 
            this.chkPagamentoPendente.Location = new System.Drawing.Point(6, 235);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(229, 258);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(73, 352);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(154, 352);
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(76, 20);
            this.lblT�tulo.Text = "Dinheiro";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(151, 48);
            this.lblDescri��o.Text = "As informa��es gerais est�o � esquerda.  � direita voc� pode incluir vendas que e" +
                "stejam relacionas com esta quantia.\r\n\r\n";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Financeiro.Properties.Resources.dinheiro1;
            // 
            // CadastroDinheiro
            // 
            this.ClientSize = new System.Drawing.Size(239, 385);
            this.Name = "CadastroDinheiro";
            this.Text = "Dinheiro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
