namespace Apresentação.Atendimento.Clientes.Pedido
{
    partial class BasePedidos
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
            this.quadroVisualização = new Apresentação.Formulários.Quadro();
            this.optPeríodoTodo = new System.Windows.Forms.RadioButton();
            this.optPeríodoPrevisto = new System.Windows.Forms.RadioButton();
            this.optPeríodoRegistrado = new System.Windows.Forms.RadioButton();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadroPedido = new Apresentação.Formulários.Quadro();
            this.opçãoImprimirResumo = new Apresentação.Formulários.Opção();
            this.opçãoNovo = new Apresentação.Formulários.Opção();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.opçãoMostraPedidosJaEntregues = new Apresentação.Formulários.Opção();
            this.opçãoOcutarPedidosJaEntregues = new Apresentação.Formulários.Opção();
            this.quadroPedidosConsertos = new Apresentação.Formulários.Quadro();
            this.optExibePedidos = new System.Windows.Forms.RadioButton();
            this.optExibeConsertos = new System.Windows.Forms.RadioButton();
            this.esquerda.SuspendLayout();
            this.quadroVisualização.SuspendLayout();
            this.quadroPedido.SuspendLayout();
            this.quadroPedidosConsertos.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPedido);
            this.esquerda.Controls.Add(this.quadroVisualização);
            this.esquerda.Controls.Add(this.quadroPedidosConsertos);
            this.esquerda.Size = new System.Drawing.Size(187, 566);
            this.esquerda.Controls.SetChildIndex(this.quadroPedidosConsertos, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroVisualização, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroPedido, 0);
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
            this.títuloBaseInferior1.Título = "Pedidos e consertos";
            // 
            // listaPedidos
            // 
            this.listaPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaPedidos.BackColor = System.Drawing.SystemColors.Control;
            this.listaPedidos.Location = new System.Drawing.Point(196, 114);
            this.listaPedidos.Name = "listaPedidos";
            this.listaPedidos.Size = new System.Drawing.Size(601, 452);
            this.listaPedidos.TabIndex = 7;
            this.listaPedidos.AoDuploClique += new Apresentação.Atendimento.Clientes.Pedido.ListaPedidosSimples.PedidoDelegação(this.listaPedidos_AoDuploClique);
            // 
            // quadroVisualização
            // 
            this.quadroVisualização.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVisualização.bInfDirArredondada = true;
            this.quadroVisualização.bInfEsqArredondada = true;
            this.quadroVisualização.bSupDirArredondada = true;
            this.quadroVisualização.bSupEsqArredondada = true;
            this.quadroVisualização.Controls.Add(this.optPeríodoTodo);
            this.quadroVisualização.Controls.Add(this.optPeríodoPrevisto);
            this.quadroVisualização.Controls.Add(this.optPeríodoRegistrado);
            this.quadroVisualização.Cor = System.Drawing.Color.Black;
            this.quadroVisualização.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVisualização.LetraTítulo = System.Drawing.Color.White;
            this.quadroVisualização.Location = new System.Drawing.Point(7, 231);
            this.quadroVisualização.MostrarBotãoMinMax = false;
            this.quadroVisualização.Name = "quadroVisualização";
            this.quadroVisualização.Size = new System.Drawing.Size(160, 95);
            this.quadroVisualização.TabIndex = 1;
            this.quadroVisualização.Tamanho = 30;
            this.quadroVisualização.Título = "Período";
            // 
            // optPeríodoTodo
            // 
            this.optPeríodoTodo.AutoSize = true;
            this.optPeríodoTodo.BackColor = System.Drawing.Color.Transparent;
            this.optPeríodoTodo.Location = new System.Drawing.Point(7, 30);
            this.optPeríodoTodo.Name = "optPeríodoTodo";
            this.optPeríodoTodo.Size = new System.Drawing.Size(50, 17);
            this.optPeríodoTodo.TabIndex = 5;
            this.optPeríodoTodo.Text = "Todo";
            this.optPeríodoTodo.UseVisualStyleBackColor = false;
            this.optPeríodoTodo.CheckedChanged += new System.EventHandler(this.optTodos_CheckedChanged);
            // 
            // optPeríodoPrevisto
            // 
            this.optPeríodoPrevisto.AutoSize = true;
            this.optPeríodoPrevisto.BackColor = System.Drawing.Color.Transparent;
            this.optPeríodoPrevisto.Location = new System.Drawing.Point(7, 50);
            this.optPeríodoPrevisto.Name = "optPeríodoPrevisto";
            this.optPeríodoPrevisto.Size = new System.Drawing.Size(92, 17);
            this.optPeríodoPrevisto.TabIndex = 3;
            this.optPeríodoPrevisto.Text = "Previstos para";
            this.optPeríodoPrevisto.UseVisualStyleBackColor = false;
            this.optPeríodoPrevisto.CheckedChanged += new System.EventHandler(this.optPrevisão_CheckedChanged);
            this.optPeríodoPrevisto.Click += new System.EventHandler(this.optPrevisão_Click);
            // 
            // optPeríodoRegistrado
            // 
            this.optPeríodoRegistrado.AutoSize = true;
            this.optPeríodoRegistrado.BackColor = System.Drawing.Color.Transparent;
            this.optPeríodoRegistrado.Checked = true;
            this.optPeríodoRegistrado.Location = new System.Drawing.Point(7, 70);
            this.optPeríodoRegistrado.Name = "optPeríodoRegistrado";
            this.optPeríodoRegistrado.Size = new System.Drawing.Size(98, 17);
            this.optPeríodoRegistrado.TabIndex = 4;
            this.optPeríodoRegistrado.TabStop = true;
            this.optPeríodoRegistrado.Text = "Registrados em";
            this.optPeríodoRegistrado.UseVisualStyleBackColor = false;
            this.optPeríodoRegistrado.CheckedChanged += new System.EventHandler(this.optRecepção_CheckedChanged);
            this.optPeríodoRegistrado.Click += new System.EventHandler(this.optRecepção_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Listagem";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 50);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 19);
            this.opçãoImprimir.TabIndex = 3;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // quadroPedido
            // 
            this.quadroPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPedido.bInfDirArredondada = true;
            this.quadroPedido.bInfEsqArredondada = true;
            this.quadroPedido.bSupDirArredondada = true;
            this.quadroPedido.bSupEsqArredondada = true;
            this.quadroPedido.Controls.Add(this.opçãoImprimirResumo);
            this.quadroPedido.Controls.Add(this.opçãoNovo);
            this.quadroPedido.Controls.Add(this.opçãoImprimir);
            this.quadroPedido.Controls.Add(this.opçãoExcluir);
            this.quadroPedido.Cor = System.Drawing.Color.Black;
            this.quadroPedido.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPedido.LetraTítulo = System.Drawing.Color.White;
            this.quadroPedido.Location = new System.Drawing.Point(7, 13);
            this.quadroPedido.MostrarBotãoMinMax = false;
            this.quadroPedido.Name = "quadroPedido";
            this.quadroPedido.Size = new System.Drawing.Size(160, 112);
            this.quadroPedido.TabIndex = 2;
            this.quadroPedido.Tamanho = 30;
            this.quadroPedido.Título = "Pedidos e Consertos";
            // 
            // opçãoImprimirResumo
            // 
            this.opçãoImprimirResumo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimirResumo.Descrição = "Resumo";
            this.opçãoImprimirResumo.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimirResumo.Location = new System.Drawing.Point(7, 70);
            this.opçãoImprimirResumo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimirResumo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimirResumo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimirResumo.Name = "opçãoImprimirResumo";
            this.opçãoImprimirResumo.Size = new System.Drawing.Size(150, 19);
            this.opçãoImprimirResumo.TabIndex = 5;
            this.opçãoImprimirResumo.Click += new System.EventHandler(this.opçãoImprimirResumo_Click);
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovo.Descrição = "Novo";
            this.opçãoNovo.Imagem = global::Apresentação.Resource.document1;
            this.opçãoNovo.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovo.Name = "opçãoNovo";
            this.opçãoNovo.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovo.TabIndex = 2;
            this.opçãoNovo.Click += new System.EventHandler(this.opçãoNovo_Click);
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.delete;
            this.opçãoExcluir.Location = new System.Drawing.Point(7, 90);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 17);
            this.opçãoExcluir.TabIndex = 4;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // opçãoMostraPedidosJaEntregues
            // 
            this.opçãoMostraPedidosJaEntregues.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMostraPedidosJaEntregues.Descrição = "Mostrar entregues";
            this.opçãoMostraPedidosJaEntregues.Imagem = global::Apresentação.Resource.Filter2HS;
            this.opçãoMostraPedidosJaEntregues.Location = new System.Drawing.Point(5, 70);
            this.opçãoMostraPedidosJaEntregues.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMostraPedidosJaEntregues.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMostraPedidosJaEntregues.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMostraPedidosJaEntregues.Name = "opçãoMostraPedidosJaEntregues";
            this.opçãoMostraPedidosJaEntregues.Size = new System.Drawing.Size(150, 16);
            this.opçãoMostraPedidosJaEntregues.TabIndex = 3;
            this.opçãoMostraPedidosJaEntregues.Click += new System.EventHandler(this.opçãoMostraPedidosJaEntregues_Click);
            // 
            // opçãoOcutarPedidosJaEntregues
            // 
            this.opçãoOcutarPedidosJaEntregues.BackColor = System.Drawing.Color.Transparent;
            this.opçãoOcutarPedidosJaEntregues.Descrição = "Ocultar entregues";
            this.opçãoOcutarPedidosJaEntregues.Imagem = global::Apresentação.Resource.Filter2HS;
            this.opçãoOcutarPedidosJaEntregues.Location = new System.Drawing.Point(7, 70);
            this.opçãoOcutarPedidosJaEntregues.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoOcutarPedidosJaEntregues.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoOcutarPedidosJaEntregues.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoOcutarPedidosJaEntregues.Name = "opçãoOcutarPedidosJaEntregues";
            this.opçãoOcutarPedidosJaEntregues.Size = new System.Drawing.Size(150, 22);
            this.opçãoOcutarPedidosJaEntregues.TabIndex = 2;
            this.opçãoOcutarPedidosJaEntregues.Visible = false;
            this.opçãoOcutarPedidosJaEntregues.Click += new System.EventHandler(this.opçãoOcutarPedidosJaEntregues_Click);
            // 
            // quadroPedidosConsertos
            // 
            this.quadroPedidosConsertos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPedidosConsertos.bInfDirArredondada = true;
            this.quadroPedidosConsertos.bInfEsqArredondada = true;
            this.quadroPedidosConsertos.bSupDirArredondada = true;
            this.quadroPedidosConsertos.bSupEsqArredondada = true;
            this.quadroPedidosConsertos.Controls.Add(this.opçãoOcutarPedidosJaEntregues);
            this.quadroPedidosConsertos.Controls.Add(this.opçãoMostraPedidosJaEntregues);
            this.quadroPedidosConsertos.Controls.Add(this.optExibePedidos);
            this.quadroPedidosConsertos.Controls.Add(this.optExibeConsertos);
            this.quadroPedidosConsertos.Cor = System.Drawing.Color.Black;
            this.quadroPedidosConsertos.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPedidosConsertos.LetraTítulo = System.Drawing.Color.White;
            this.quadroPedidosConsertos.Location = new System.Drawing.Point(7, 131);
            this.quadroPedidosConsertos.MostrarBotãoMinMax = false;
            this.quadroPedidosConsertos.Name = "quadroPedidosConsertos";
            this.quadroPedidosConsertos.Size = new System.Drawing.Size(160, 94);
            this.quadroPedidosConsertos.TabIndex = 4;
            this.quadroPedidosConsertos.Tamanho = 30;
            this.quadroPedidosConsertos.Título = "Exibição";
            // 
            // optExibePedidos
            // 
            this.optExibePedidos.AutoSize = true;
            this.optExibePedidos.BackColor = System.Drawing.Color.Transparent;
            this.optExibePedidos.Checked = true;
            this.optExibePedidos.Location = new System.Drawing.Point(7, 30);
            this.optExibePedidos.Name = "optExibePedidos";
            this.optExibePedidos.Size = new System.Drawing.Size(63, 17);
            this.optExibePedidos.TabIndex = 3;
            this.optExibePedidos.TabStop = true;
            this.optExibePedidos.Text = "Pedidos";
            this.optExibePedidos.UseVisualStyleBackColor = false;
            this.optExibePedidos.CheckedChanged += new System.EventHandler(this.optPedidos_CheckedChanged);
            // 
            // optExibeConsertos
            // 
            this.optExibeConsertos.AutoSize = true;
            this.optExibeConsertos.BackColor = System.Drawing.Color.Transparent;
            this.optExibeConsertos.Location = new System.Drawing.Point(7, 50);
            this.optExibeConsertos.Name = "optExibeConsertos";
            this.optExibeConsertos.Size = new System.Drawing.Size(72, 17);
            this.optExibeConsertos.TabIndex = 4;
            this.optExibeConsertos.Text = "Consertos";
            this.optExibeConsertos.UseVisualStyleBackColor = false;
            this.optExibeConsertos.CheckedChanged += new System.EventHandler(this.optConsertos_CheckedChanged);
            // 
            // BasePedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listaPedidos);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Imagem = global::Apresentação.Resource.Pedido1;
            this.Name = "BasePedidos";
            this.Size = new System.Drawing.Size(800, 566);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.listaPedidos, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroVisualização.ResumeLayout(false);
            this.quadroVisualização.PerformLayout();
            this.quadroPedido.ResumeLayout(false);
            this.quadroPedidosConsertos.ResumeLayout(false);
            this.quadroPedidosConsertos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private ListaPedidosSimples listaPedidos;
        private Apresentação.Formulários.Quadro quadroVisualização;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Quadro quadroPedido;
        private Apresentação.Formulários.Opção opçãoNovo;
        private System.Windows.Forms.RadioButton optPeríodoRegistrado;
        private System.Windows.Forms.RadioButton optPeríodoPrevisto;
        private Apresentação.Formulários.Opção opçãoOcutarPedidosJaEntregues;
        private Apresentação.Formulários.Opção opçãoMostraPedidosJaEntregues;
        private Apresentação.Formulários.Quadro quadroPedidosConsertos;
        private System.Windows.Forms.RadioButton optExibePedidos;
        private System.Windows.Forms.RadioButton optExibeConsertos;
        private Apresentação.Formulários.Opção opçãoExcluir;
        private System.Windows.Forms.RadioButton optPeríodoTodo;
        private Formulários.Opção opçãoImprimirResumo;
    }
}
