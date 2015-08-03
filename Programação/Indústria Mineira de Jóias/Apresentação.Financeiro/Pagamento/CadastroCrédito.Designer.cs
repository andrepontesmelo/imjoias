namespace Apresentação.Financeiro.Pagamento
{
    partial class CadastroCrédito
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
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // chkPagamentoPendente
            // 
            this.chkPagamentoPendente.Size = new System.Drawing.Size(130, 17);
            this.chkPagamentoPendente.Text = "Crédito está pendente";
            // 
            // groupBox1
            // 
            this.groupBox1.Text = "Informações do crédito";
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(112, 20);
            this.lblTítulo.Text = "Novo Crédito";
            // 
            // CadastroCrédito
            // 
            this.ClientSize = new System.Drawing.Size(412, 345);
            this.Name = "CadastroCrédito";
            this.Text = "Crédito";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
