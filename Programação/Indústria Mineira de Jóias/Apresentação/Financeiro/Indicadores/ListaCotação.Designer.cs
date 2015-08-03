namespace Apresentação.Financeiro.Indicadores
{
    partial class ListaCotação
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
            this.lst = new System.Windows.Forms.ListView();
            this.colData = new System.Windows.Forms.ColumnHeader();
            this.colValor = new System.Windows.Forms.ColumnHeader();
            this.colFuncionário = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colData,
            this.colValor,
            this.colFuncionário});
            this.lst.FullRowSelect = true;
            this.lst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst.Location = new System.Drawing.Point(5, 27);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(341, 174);
            this.lst.TabIndex = 2;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 129;
            // 
            // colValor
            // 
            this.colValor.Text = "Valor";
            this.colValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValor.Width = 80;
            // 
            // colFuncionário
            // 
            this.colFuncionário.Text = "Funcionário";
            this.colFuncionário.Width = 128;
            // 
            // ListaCotaçãoOuro
            // 
            this.Controls.Add(this.lst);
            this.Name = "ListaCotaçãoOuro";
            this.Size = new System.Drawing.Size(351, 206);
            this.Título = "Lista de Cotação do Ouro";
            this.Controls.SetChildIndex(this.lst, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colFuncionário;
    }
}
