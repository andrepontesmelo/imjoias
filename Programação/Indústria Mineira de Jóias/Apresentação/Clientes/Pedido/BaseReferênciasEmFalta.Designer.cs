namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class BaseReferênciasEmFalta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.lista = new System.Windows.Forms.ListView();
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEncomendado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSaldoConsignado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReferênciaFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPedidos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quadroPedidosConsertos = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroPedidosConsertos.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPedidosConsertos);
            this.esquerda.Controls.SetChildIndex(this.quadroPedidosConsertos, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "São listadas todas as referências em falta na empresa, por constar em encomendas " +
                "em aberto.";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.exclamacao;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(595, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Mercadorias em Falta";
            // 
            // quadro1
            // 
            this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = false;
            this.quadro1.bInfEsqArredondada = false;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.lista);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(187, 79);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(596, 201);
            this.quadro1.TabIndex = 7;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Mercadorias encomendadas";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência,
            this.colEncomendado,
            this.colSaldoConsignado,
            this.colFornecedor,
            this.colReferênciaFornecedor,
            this.colPedidos,
            this.colDescrição});
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 24);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(596, 177);
            this.lista.TabIndex = 2;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lista_ColumnClick);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lista_MouseMove);
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 120;
            // 
            // colEncomendado
            // 
            this.colEncomendado.Text = "Encomendado";
            this.colEncomendado.Width = 100;
            // 
            // colSaldoConsignado
            // 
            this.colSaldoConsignado.Text = "Saldo em consignado";
            this.colSaldoConsignado.Width = 120;
            // 
            // colFornecedor
            // 
            this.colFornecedor.Text = "Fornecedor";
            this.colFornecedor.Width = 80;
            // 
            // colReferênciaFornecedor
            // 
            this.colReferênciaFornecedor.Text = "Ref. Fornecedor";
            this.colReferênciaFornecedor.Width = 90;
            // 
            // colPedidos
            // 
            this.colPedidos.Text = "Pedidos";
            this.colPedidos.Width = 90;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            // 
            // quadroPedidosConsertos
            // 
            this.quadroPedidosConsertos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPedidosConsertos.bInfDirArredondada = true;
            this.quadroPedidosConsertos.bInfEsqArredondada = true;
            this.quadroPedidosConsertos.bSupDirArredondada = true;
            this.quadroPedidosConsertos.bSupEsqArredondada = true;
            this.quadroPedidosConsertos.Controls.Add(this.opçãoImprimir);
            this.quadroPedidosConsertos.Cor = System.Drawing.Color.Black;
            this.quadroPedidosConsertos.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPedidosConsertos.LetraTítulo = System.Drawing.Color.White;
            this.quadroPedidosConsertos.Location = new System.Drawing.Point(7, 13);
            this.quadroPedidosConsertos.MostrarBotãoMinMax = false;
            this.quadroPedidosConsertos.Name = "quadroPedidosConsertos";
            this.quadroPedidosConsertos.Size = new System.Drawing.Size(160, 73);
            this.quadroPedidosConsertos.TabIndex = 5;
            this.quadroPedidosConsertos.Tamanho = 30;
            this.quadroPedidosConsertos.Título = "Impressão";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir listagem";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 52);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 19);
            this.opçãoImprimir.TabIndex = 4;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // BaseReferênciasEmFalta
            // 
            this.Controls.Add(this.títuloBaseInferior1);
            this.Controls.Add(this.quadro1);
            this.Name = "BaseReferênciasEmFalta";
            this.Size = new System.Drawing.Size(801, 296);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroPedidosConsertos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior1;
        private Formulários.Quadro quadro1;
        private System.Windows.Forms.ListView lista;
        private System.Windows.Forms.ColumnHeader colReferência;
        private System.Windows.Forms.ColumnHeader colEncomendado;
        private System.Windows.Forms.ColumnHeader colSaldoConsignado;
        private System.Windows.Forms.ColumnHeader colFornecedor;
        private System.Windows.Forms.ColumnHeader colReferênciaFornecedor;
        private System.Windows.Forms.ColumnHeader colPedidos;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private Formulários.Quadro quadroPedidosConsertos;
        private Formulários.Opção opçãoImprimir;
    }
}
