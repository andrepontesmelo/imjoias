namespace Apresentação.Mercadoria
{
    partial class JanelaMercadoriaEmFalta
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
            this.grpEncomendas = new System.Windows.Forms.GroupBox();
            this.lista = new System.Windows.Forms.ListView();
            this.colDias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidadePedido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidadeConsignado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPedido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.grpEncomendas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(177, 20);
            this.lblTítulo.Text = "Mercadorias em falta";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(624, 48);
            this.lblDescrição.Text = "Abaixo estão mercadorias em encomendas que estão em consignação com esta pessoa.";
            // 
            // picÍcone
            // 
            this.picÍcone.ErrorImage = null;
            this.picÍcone.Image = global::Apresentação.Resource.lupa_papéis;
            // 
            // grpEncomendas
            // 
            this.grpEncomendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEncomendas.Controls.Add(this.lista);
            this.grpEncomendas.Location = new System.Drawing.Point(12, 96);
            this.grpEncomendas.Name = "grpEncomendas";
            this.grpEncomendas.Size = new System.Drawing.Size(688, 408);
            this.grpEncomendas.TabIndex = 3;
            this.grpEncomendas.TabStop = false;
            this.grpEncomendas.Text = "Encomendas";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDias,
            this.colQuantidadePedido,
            this.colQuantidadeConsignado,
            this.colReferência,
            this.colPedido,
            this.colCliente,
            this.colDescricao});
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(6, 19);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(676, 383);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colDias
            // 
            this.colDias.Text = "Dias de espera";
            this.colDias.Width = 89;
            // 
            // colQuantidadePedido
            // 
            this.colQuantidadePedido.Text = "Encomendado";
            this.colQuantidadePedido.Width = 90;
            // 
            // colQuantidadeConsignado
            // 
            this.colQuantidadeConsignado.Text = "Consignação";
            this.colQuantidadeConsignado.Width = 90;
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 100;
            // 
            // colPedido
            // 
            this.colPedido.Text = "Pedido";
            this.colPedido.Width = 45;
            // 
            // colCliente
            // 
            this.colCliente.Text = "Cliente";
            this.colCliente.Width = 113;
            // 
            // colDescricao
            // 
            this.colDescricao.Text = "Descricao";
            this.colDescricao.Width = 773;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(623, 516);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(543, 516);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 23);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // JanelaMercadoriaEmFalta
            // 
            this.ClientSize = new System.Drawing.Size(712, 549);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grpEncomendas);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.Name = "JanelaMercadoriaEmFalta";
            this.Text = "Mercadorias em falta";
            this.Controls.SetChildIndex(this.btnFechar, 0);
            this.Controls.SetChildIndex(this.grpEncomendas, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.grpEncomendas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEncomendas;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colDias;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colPedido;
        private System.Windows.Forms.ColumnHeader colQuantidadePedido;
        private System.Windows.Forms.ColumnHeader colCliente;
        private System.Windows.Forms.ColumnHeader colQuantidadeConsignado;
        private System.Windows.Forms.ColumnHeader colDescricao;
        private System.Windows.Forms.Button btnImprimir;
    }
}
