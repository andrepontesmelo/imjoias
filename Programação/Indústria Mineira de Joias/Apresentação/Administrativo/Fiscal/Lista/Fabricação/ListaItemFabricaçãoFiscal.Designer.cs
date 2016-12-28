using Apresentação.Formulários;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    partial class ListaItemFabricaçãoFiscal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lista = new Apresentação.Formulários.ListViewUsabilidade();
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCFOP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSaldoAnterior = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPeso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPesoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSaldoPosterior = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorUnitário = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colQuantidade,
            this.colReferência,
            this.colCFOP,
            this.colSaldoAnterior,
            this.colPeso,
            this.colPesoTotal,
            this.colSaldoPosterior,
            this.colTipo,
            this.colValorUnitário,
            this.colValorTotal,
            this.colDescrição});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(985, 471);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 128;
            // 
            // colCFOP
            // 
            this.colCFOP.Text = "CFOP";
            // 
            // colSaldoAnterior
            // 
            this.colSaldoAnterior.Text = "Saldo Ant.";
            this.colSaldoAnterior.Width = 84;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Text = "Quantidade";
            this.colQuantidade.Width = 77;
            // 
            // colPeso
            // 
            this.colPeso.Text = "Peso";
            // 
            // colPesoTotal
            // 
            this.colPesoTotal.Text = "Peso T";
            // 
            // colSaldoPosterior
            // 
            this.colSaldoPosterior.Text = "Saldo Pos.";
            this.colSaldoPosterior.Width = 98;
            // 
            // colTipo
            // 
            this.colTipo.Text = "Tipo de unidade";
            this.colTipo.Width = 123;
            // 
            // colValorUnitário
            // 
            this.colValorUnitário.Text = "Valor Unit.";
            this.colValorUnitário.Width = 107;
            // 
            // colValorTotal
            // 
            this.colValorTotal.Text = "Valor Total";
            this.colValorTotal.Width = 89;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 569;
            // 
            // ListaItemFabricaçãoFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lista);
            this.Name = "ListaItemFabricaçãoFiscal";
            this.Size = new System.Drawing.Size(985, 471);
            this.ResumeLayout(false);

        }

        #endregion

        protected ListViewUsabilidade lista;
        protected System.Windows.Forms.ColumnHeader colQuantidade;
        protected System.Windows.Forms.ColumnHeader colTipo;
        protected System.Windows.Forms.ColumnHeader colReferência;
        protected System.Windows.Forms.ColumnHeader colDescrição;
        protected System.Windows.Forms.ColumnHeader colValorUnitário;
        protected System.Windows.Forms.ColumnHeader colSaldoAnterior;
        protected System.Windows.Forms.ColumnHeader colSaldoPosterior;
        protected System.Windows.Forms.ColumnHeader colCFOP;
        protected System.Windows.Forms.ColumnHeader colPeso;
        protected System.Windows.Forms.ColumnHeader colValorTotal;
        protected System.Windows.Forms.ColumnHeader colPesoTotal;
    }
}
