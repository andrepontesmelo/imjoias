namespace Apresenta��o.Financeiro.Acerto
{
    partial class BandejaAcerto
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
            this.colSa�da = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetorno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAcerto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDevolu��o = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSa�da,
            this.colRetorno,
            this.colVenda,
            this.colDevolu��o,
            this.colAcerto});
            this.lista.Location = new System.Drawing.Point(0, 25);
            this.lista.ShowGroups = true;
            this.lista.Size = new System.Drawing.Size(717, 430);
            // 
            // colRefer�ncia
            // 
            this.colRefer�ncia.Width = 130;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Width = 0;
            // 
            // col�ndice
            // 
            this.col�ndice.Width = 0;
            // 
            // colGrupo
            // 
            this.colGrupo.Width = 0;
            // 
            // colFaixa
            // 
            this.colFaixa.Width = 0;
            // 
            // colSa�da
            // 
            this.colSa�da.Text = "Sa�da";
            this.colSa�da.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colRetorno
            // 
            this.colRetorno.Text = "Retorno";
            this.colRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colVenda
            // 
            this.colVenda.Text = "Venda";
            this.colVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colAcerto
            // 
            this.colAcerto.Text = "Acerto";
            this.colAcerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colDevolu��o
            // 
            this.colDevolu��o.Text = "Devolu��o";
            this.colDevolu��o.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDevolu��o.Width = 75;
            // 
            // BandejaAcerto
            // 
            this.MostrarAgrupar = false;
            this.MostrarExcluir = false;
            this.MostrarPre�o = false;
            this.MostrarSele��oTabela = false;
            this.MostrarStatus = false;
            this.Name = "BandejaAcerto";
            this.PermitirExclus�o = false;
            this.PermitirSele��oTabela = false;
            this.SepararPe�aPeso = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colSa�da;
        private System.Windows.Forms.ColumnHeader colRetorno;
        private System.Windows.Forms.ColumnHeader colVenda;
        private System.Windows.Forms.ColumnHeader colAcerto;
        private System.Windows.Forms.ColumnHeader colDevolu��o;
    }
}
