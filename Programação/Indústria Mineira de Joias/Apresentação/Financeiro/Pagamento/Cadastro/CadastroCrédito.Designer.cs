namespace Apresenta��o.Financeiro.Pagamento
{
    partial class CadastroCr�dito
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
            this.chkPagamentoPendente.Location = new System.Drawing.Point(6, 274);
            this.chkPagamentoPendente.Size = new System.Drawing.Size(130, 17);
            this.chkPagamentoPendente.Text = "Cr�dito est� pendente";
            // 
            // txtValor
            // 
            this.txtValor.Size = new System.Drawing.Size(251, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(264, 297);
            this.groupBox1.Text = "Informa��es do cr�dito";
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
            // txtDescri��o
            // 
            this.txtDescri��o.Size = new System.Drawing.Size(248, 91);
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(112, 20);
            this.lblT�tulo.Text = "Novo Cr�dito";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(190, 48);
            // 
            // CadastroCr�dito
            // 
            this.ClientSize = new System.Drawing.Size(278, 402);
            this.Name = "CadastroCr�dito";
            this.Text = "Cr�dito";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
