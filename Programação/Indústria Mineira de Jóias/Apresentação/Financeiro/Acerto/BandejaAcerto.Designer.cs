namespace Apresentação.Financeiro.Acerto
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
            this.colSaída = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetorno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAcerto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDevolução = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSaída,
            this.colRetorno,
            this.colVenda,
            this.colDevolução,
            this.colAcerto});
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
            this.colGrupo.Width = 0;
            // 
            // colFaixa
            // 
            this.colFaixa.Width = 0;
            // 
            // colSaída
            // 
            this.colSaída.Text = "Saída";
            this.colSaída.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // colDevolução
            // 
            this.colDevolução.Text = "Devolução";
            this.colDevolução.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDevolução.Width = 75;
            // 
            // BandejaAcerto
            // 
            this.MostrarAgrupar = false;
            this.MostrarExcluir = false;
            this.MostrarPreço = false;
            this.MostrarSeleçãoTabela = false;
            this.MostrarStatus = false;
            this.Name = "BandejaAcerto";
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
        private System.Windows.Forms.ColumnHeader colAcerto;
        private System.Windows.Forms.ColumnHeader colDevolução;
    }
}
