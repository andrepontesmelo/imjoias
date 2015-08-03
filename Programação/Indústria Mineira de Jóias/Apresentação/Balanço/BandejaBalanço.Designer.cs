namespace Apresentação.Balanço
{
    partial class BandejaBalanço
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
            this.colSaída = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetorno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSaldo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSedex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSaída,
            this.colRetorno,
            this.colVenda,
            this.colSedex,
            this.colSaldo});
            this.lista.Location = new System.Drawing.Point(0, 25);
            this.lista.ShowGroups = true;
            this.lista.Size = new System.Drawing.Size(717, 430);
            // 
            // colReferência
            // 
            this.colReferência.Width = 130;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Width = 0;
            // 
            // colÍndice
            // 
            this.colÍndice.Width = 0;
            // 
            // colGrupo
            // 
            this.colGrupo.DisplayIndex = 5;
            this.colGrupo.Width = 0;
            // 
            // colFaixa
            // 
            this.colFaixa.DisplayIndex = 4;
            this.colFaixa.Width = 0;
            // 
            // colSaída
            // 
            this.colSaída.Text = "Saída (+)";
            this.colSaída.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colRetorno
            // 
            this.colRetorno.Text = "Retorno(-)";
            this.colRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colVenda
            // 
            this.colVenda.Text = "Venda(-)";
            this.colVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colSaldo
            // 
            this.colSaldo.Text = "Saldo(=)";
            this.colSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colSedex
            // 
            this.colSedex.Text = "Sedex(+)";
            this.colSedex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSedex.Width = 75;
            // 
            // BandejaBalanço
            // 
            this.MostrarAgrupar = false;
            this.MostrarExcluir = false;
            this.MostrarPreço = false;
            this.MostrarSeleçãoTabela = false;
            this.MostrarStatus = false;
            this.Name = "BandejaBalanço";
            this.PermitirExclusão = false;
            this.PermitirSeleçãoTabela = false;
            this.SepararPeçaPeso = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colSaída;
        private System.Windows.Forms.ColumnHeader colRetorno;
        private System.Windows.Forms.ColumnHeader colVenda;
        private System.Windows.Forms.ColumnHeader colSaldo;
        private System.Windows.Forms.ColumnHeader colSedex;
    }
}
