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
            this.chkPagamentoPendente.Location = new System.Drawing.Point(6, 274);
            this.chkPagamentoPendente.Size = new System.Drawing.Size(130, 17);
            this.chkPagamentoPendente.Text = "Crédito está pendente";
            // 
            // txtValor
            // 
            this.txtValor.Size = new System.Drawing.Size(251, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(264, 297);
            this.groupBox1.Text = "Informações do crédito";
            // 
            // chkCobrarJuros
            // 
            this.chkCobrarJuros.Location = new System.Drawing.Point(6, 251);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(-30, 408);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(51, 408);
            // 
            // data
            // 
            this.data.Size = new System.Drawing.Size(251, 20);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Size = new System.Drawing.Size(248, 91);
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(112, 20);
            this.lblTítulo.Text = "Novo Crédito";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(190, 48);
            // 
            // CadastroCrédito
            // 
            this.ClientSize = new System.Drawing.Size(278, 402);
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
