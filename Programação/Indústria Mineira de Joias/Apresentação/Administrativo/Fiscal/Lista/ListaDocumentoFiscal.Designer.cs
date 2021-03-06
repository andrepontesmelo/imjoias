﻿namespace Apresentação.Fiscal.Lista
{
    partial class ListaDocumentoFiscal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaDocumentoFiscal));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lista = new Apresentação.Formulários.ListViewUsabilidade();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmissão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEntradaSaída = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNúmero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObservações = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesconto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pdf-file-icon-15.png");
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colEmissão,
            this.colEntradaSaída,
            this.colSubTotal,
            this.colDesconto,
            this.colValorTotal,
            this.colNúmero,
            this.colObservações});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(927, 399);
            this.lista.TabIndex = 1;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.AoExcluir += new System.EventHandler(this.lista_AoExcluir);
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colId
            // 
            this.colId.Text = "Id";
            this.colId.Width = 192;
            // 
            // colEmissão
            // 
            this.colEmissão.Text = "Emissão";
            this.colEmissão.Width = 120;
            // 
            // colEntradaSaída
            // 
            this.colEntradaSaída.Text = "Entrada Ou Saída";
            this.colEntradaSaída.Width = 172;
            // 
            // colValorTotal
            // 
            this.colValorTotal.DisplayIndex = 3;
            this.colValorTotal.Text = "Total";
            // 
            // colNúmero
            // 
            this.colNúmero.Text = "Número";
            // 
            // colObservações
            // 
            this.colObservações.Text = "Observações";
            this.colObservações.Width = 500;
            // 
            // colDesconto
            // 
            this.colDesconto.Text = "Desconto";
            // 
            // colSubTotal
            // 
            this.colSubTotal.Text = "Subtotal";
            this.colSubTotal.Width = 74;
            // 
            // ListaDocumentoFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lista);
            this.Name = "ListaDocumentoFiscal";
            this.Size = new System.Drawing.Size(927, 399);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.ColumnHeader colEntradaSaída;
        protected Apresentação.Formulários.ListViewUsabilidade lista;
        protected System.Windows.Forms.ColumnHeader colId;
        protected System.Windows.Forms.ColumnHeader colValorTotal;
        protected System.Windows.Forms.ColumnHeader colEmissão;
        protected System.Windows.Forms.ColumnHeader colObservações;
        protected System.Windows.Forms.ColumnHeader colNúmero;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.ColumnHeader colSubTotal;
        protected System.Windows.Forms.ColumnHeader colDesconto;
    }
}
