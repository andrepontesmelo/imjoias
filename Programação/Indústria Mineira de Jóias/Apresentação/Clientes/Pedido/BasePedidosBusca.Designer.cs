namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class BasePedidosBusca
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
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.listaPedidos = new Apresentação.Atendimento.Clientes.Pedido.ListaPedidosSimples();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.quadroPedido = new Apresentação.Formulários.Quadro();
            this.opçãoLocalizar = new Apresentação.Formulários.Opção();
            this.opçãoNovo = new Apresentação.Formulários.Opção();
            this.opçãoReferênciasEmFalta = new Apresentação.Formulários.Opção();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.esquerda.SuspendLayout();
            this.quadroPedido.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.Add(this.quadroPedido);
            this.esquerda.Size = new System.Drawing.Size(187, 566);
            this.esquerda.Controls.SetChildIndex(this.quadroPedido, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "";
            this.títuloBaseInferior1.ÍconeArredondado = false;
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.Pedido1;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 12);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(584, 70);
            this.títuloBaseInferior1.TabIndex = 6;
            this.títuloBaseInferior1.Título = "Busca de pedidos e consertos";
            // 
            // listaPedidos
            // 
            this.listaPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaPedidos.BackColor = System.Drawing.SystemColors.Control;
            this.listaPedidos.Location = new System.Drawing.Point(186, 88);
            this.listaPedidos.Name = "listaPedidos";
            this.listaPedidos.Size = new System.Drawing.Size(601, 475);
            this.listaPedidos.TabIndex = 7;
            this.listaPedidos.AoDuploClique += new Apresentação.Atendimento.Clientes.Pedido.ListaPedidosSimples.PedidoDelegação(this.listaPedidos_AoDuploClique);
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusca.BackColor = System.Drawing.Color.Linen;
            this.txtBusca.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(271, 37);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(516, 33);
            this.txtBusca.TabIndex = 13;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // quadroPedido
            // 
            this.quadroPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPedido.bInfDirArredondada = true;
            this.quadroPedido.bInfEsqArredondada = true;
            this.quadroPedido.bSupDirArredondada = true;
            this.quadroPedido.bSupEsqArredondada = true;
            this.quadroPedido.Controls.Add(this.opçãoLocalizar);
            this.quadroPedido.Controls.Add(this.opçãoNovo);
            this.quadroPedido.Cor = System.Drawing.Color.Black;
            this.quadroPedido.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPedido.LetraTítulo = System.Drawing.Color.White;
            this.quadroPedido.Location = new System.Drawing.Point(7, 13);
            this.quadroPedido.MostrarBotãoMinMax = false;
            this.quadroPedido.Name = "quadroPedido";
            this.quadroPedido.Size = new System.Drawing.Size(160, 74);
            this.quadroPedido.TabIndex = 3;
            this.quadroPedido.Tamanho = 30;
            this.quadroPedido.Título = "Pedidos e Consertos";
            // 
            // opçãoLocalizar
            // 
            this.opçãoLocalizar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoLocalizar.Descrição = "Busca avançada";
            this.opçãoLocalizar.Imagem = global::Apresentação.Resource.Lupa;
            this.opçãoLocalizar.Location = new System.Drawing.Point(7, 30);
            this.opçãoLocalizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoLocalizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoLocalizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoLocalizar.Name = "opçãoLocalizar";
            this.opçãoLocalizar.Size = new System.Drawing.Size(150, 16);
            this.opçãoLocalizar.TabIndex = 4;
            this.opçãoLocalizar.Click += new System.EventHandler(this.opçãoLocalizar_Click);
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovo.Descrição = "Cadastrar";
            this.opçãoNovo.Imagem = global::Apresentação.Resource.document1;
            this.opçãoNovo.Location = new System.Drawing.Point(7, 50);
            this.opçãoNovo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovo.Name = "opçãoNovo";
            this.opçãoNovo.Size = new System.Drawing.Size(150, 23);
            this.opçãoNovo.TabIndex = 2;
            this.opçãoNovo.Click += new System.EventHandler(this.opçãoNovo_Click);
            // 
            // opçãoReferênciasEmFalta
            // 
            this.opçãoReferênciasEmFalta.BackColor = System.Drawing.Color.Transparent;
            this.opçãoReferênciasEmFalta.Descrição = "Mercadorias em falta";
            this.opçãoReferênciasEmFalta.Imagem = global::Apresentação.Resource.warning;
            this.opçãoReferênciasEmFalta.Location = new System.Drawing.Point(7, 30);
            this.opçãoReferênciasEmFalta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoReferênciasEmFalta.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoReferênciasEmFalta.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoReferênciasEmFalta.Name = "opçãoReferênciasEmFalta";
            this.opçãoReferênciasEmFalta.Size = new System.Drawing.Size(150, 17);
            this.opçãoReferênciasEmFalta.TabIndex = 7;
            this.opçãoReferênciasEmFalta.Click += new System.EventHandler(this.opçãoReferênciasEmFalta_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoReferênciasEmFalta);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 93);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 55);
            this.quadro1.TabIndex = 8;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Mercadorias em falta";
            // 
            // BasePedidosBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.listaPedidos);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Imagem = global::Apresentação.Resource.Pedido1;
            this.Name = "BasePedidosBusca";
            this.Size = new System.Drawing.Size(800, 566);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.listaPedidos, 0);
            this.Controls.SetChildIndex(this.txtBusca, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroPedido.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private ListaPedidosSimples listaPedidos;
        private System.Windows.Forms.TextBox txtBusca;
        private Apresentação.Formulários.Quadro quadroPedido;
        private Apresentação.Formulários.Opção opçãoLocalizar;
        private Apresentação.Formulários.Opção opçãoNovo;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoReferênciasEmFalta;
    }
}
