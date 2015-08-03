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
            this.optTodos = new System.Windows.Forms.RadioButton();
            this.optPrevisão = new System.Windows.Forms.RadioButton();
            this.optRecepção = new System.Windows.Forms.RadioButton();
            this.opçãoEscolherPeríodo = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadroPedido = new Apresentação.Formulários.Quadro();
            this.opçãoImprimirResumo = new Apresentação.Formulários.Opção();
            this.opçãoNovo = new Apresentação.Formulários.Opção();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.quadroOcultar = new Apresentação.Formulários.Quadro();
            this.opçãoMostraPedidosJaEntregues = new Apresentação.Formulários.Opção();
            this.opçãoOcutarPedidosJaEntregues = new Apresentação.Formulários.Opção();
            this.quadroPedidosConsertos = new Apresentação.Formulários.Quadro();
            this.optPedidos = new System.Windows.Forms.RadioButton();
            this.optConsertos = new System.Windows.Forms.RadioButton();
            this.esquerda.SuspendLayout();
            this.quadroVisualização.SuspendLayout();
            this.quadroPedido.SuspendLayout();
            this.quadroOcultar.SuspendLayout();
            this.quadroPedidosConsertos.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPedido);
            this.esquerda.Controls.Add(this.quadroOcultar);
            this.esquerda.Controls.Add(this.quadroVisualização);
            this.esquerda.Controls.Add(this.quadroPedidosConsertos);
            this.esquerda.Controls.Add(this.opçãoEscolherPeríodo);
            this.esquerda.Size = new System.Drawing.Size(187, 566);
            this.esquerda.Controls.SetChildIndex(this.opçãoEscolherPeríodo, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroPedidosConsertos, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroVisualização, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroOcultar, 0);
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
            this.listaPedidos.Location = new System.Drawing.Point(186, 111);
            this.listaPedidos.Name = "listaPedidos";
            this.listaPedidos.Size = new System.Drawing.Size(604, 452);
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
            this.quadroVisualização.Controls.Add(this.optTodos);
            this.quadroVisualização.Controls.Add(this.optPrevisão);
            this.quadroVisualização.Controls.Add(this.optRecepção);
            this.quadroVisualização.Cor = System.Drawing.Color.Black;
            this.quadroVisualização.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVisualização.LetraTítulo = System.Drawing.Color.White;
            this.quadroVisualização.Location = new System.Drawing.Point(7, 221);
            this.quadroVisualização.MostrarBotãoMinMax = false;
            this.quadroVisualização.Name = "quadroVisualização";
            this.quadroVisualização.Size = new System.Drawing.Size(160, 88);
            this.quadroVisualização.TabIndex = 1;
            this.quadroVisualização.Tamanho = 30;
            this.quadroVisualização.Título = "Período";
            // 
            // optTodos
            // 
            this.optTodos.BackColor = System.Drawing.Color.Transparent;
            this.optTodos.Location = new System.Drawing.Point(5, 30);
            this.optTodos.Name = "optTodos";
            this.optTodos.Size = new System.Drawing.Size(145, 20);
            this.optTodos.TabIndex = 5;
            this.optTodos.Text = "Todo";
            this.optTodos.UseVisualStyleBackColor = false;
            this.optTodos.CheckedChanged += new System.EventHandler(this.optTodos_CheckedChanged);
            // 
            // optPrevisão
            // 
            this.optPrevisão.BackColor = System.Drawing.Color.Transparent;
            this.optPrevisão.Location = new System.Drawing.Point(5, 47);
            this.optPrevisão.Name = "optPrevisão";
            this.optPrevisão.Size = new System.Drawing.Size(145, 19);
            this.optPrevisão.TabIndex = 3;
            this.optPrevisão.Text = "Previstos para...";
            this.optPrevisão.UseVisualStyleBackColor = false;
            this.optPrevisão.CheckedChanged += new System.EventHandler(this.optPrevisão_CheckedChanged);
            this.optPrevisão.Click += new System.EventHandler(this.optPrevisão_Click);
            // 
            // optRecepção
            // 
            this.optRecepção.BackColor = System.Drawing.Color.Transparent;
            this.optRecepção.Checked = true;
            this.optRecepção.Location = new System.Drawing.Point(5, 62);
            this.optRecepção.Name = "optRecepção";
            this.optRecepção.Size = new System.Drawing.Size(145, 23);
            this.optRecepção.TabIndex = 4;
            this.optRecepção.TabStop = true;
            this.optRecepção.Text = "Registrados em...";
            this.optRecepção.UseVisualStyleBackColor = false;
            this.optRecepção.CheckedChanged += new System.EventHandler(this.optRecepção_CheckedChanged);
            this.optRecepção.Click += new System.EventHandler(this.optRecepção_Click);
            // 
            // opçãoEscolherPeríodo
            // 
            this.opçãoEscolherPeríodo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEscolherPeríodo.Descrição = "Escolher período...";
            this.opçãoEscolherPeríodo.Imagem = global::Apresentação.Resource.calendário___inclinado;
            this.opçãoEscolherPeríodo.Location = new System.Drawing.Point(7, 410);
            this.opçãoEscolherPeríodo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEscolherPeríodo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEscolherPeríodo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEscolherPeríodo.Name = "opçãoEscolherPeríodo";
            this.opçãoEscolherPeríodo.Size = new System.Drawing.Size(150, 24);
            this.opçãoEscolherPeríodo.TabIndex = 2;
            this.opçãoEscolherPeríodo.Visible = false;
            this.opçãoEscolherPeríodo.Click += new System.EventHandler(this.opçãoEscolherPeríodo_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir listagem";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 50);
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
            this.quadroPedido.Size = new System.Drawing.Size(160, 123);
            this.quadroPedido.TabIndex = 2;
            this.quadroPedido.Tamanho = 30;
            this.quadroPedido.Título = "Pedidos e Consertos";
            // 
            // opçãoImprimirResumo
            // 
            this.opçãoImprimirResumo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimirResumo.Descrição = "Imprimir resumo";
            this.opçãoImprimirResumo.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimirResumo.Location = new System.Drawing.Point(5, 69);
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
            this.opçãoNovo.Descrição = "Cadastrar";
            this.opçãoNovo.Imagem = global::Apresentação.Resource.document1;
            this.opçãoNovo.Location = new System.Drawing.Point(5, 29);
            this.opçãoNovo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovo.Name = "opçãoNovo";
            this.opçãoNovo.Size = new System.Drawing.Size(150, 23);
            this.opçãoNovo.TabIndex = 2;
            this.opçãoNovo.Click += new System.EventHandler(this.opçãoNovo_Click);
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.delete;
            this.opçãoExcluir.Location = new System.Drawing.Point(5, 104);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 17);
            this.opçãoExcluir.TabIndex = 4;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // quadroOcultar
            // 
            this.quadroOcultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroOcultar.bInfDirArredondada = true;
            this.quadroOcultar.bInfEsqArredondada = true;
            this.quadroOcultar.bSupDirArredondada = true;
            this.quadroOcultar.bSupEsqArredondada = true;
            this.quadroOcultar.Controls.Add(this.opçãoMostraPedidosJaEntregues);
            this.quadroOcultar.Controls.Add(this.opçãoOcutarPedidosJaEntregues);
            this.quadroOcultar.Cor = System.Drawing.Color.Black;
            this.quadroOcultar.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOcultar.LetraTítulo = System.Drawing.Color.White;
            this.quadroOcultar.Location = new System.Drawing.Point(7, 315);
            this.quadroOcultar.MostrarBotãoMinMax = false;
            this.quadroOcultar.Name = "quadroOcultar";
            this.quadroOcultar.Size = new System.Drawing.Size(160, 76);
            this.quadroOcultar.TabIndex = 3;
            this.quadroOcultar.Tamanho = 30;
            this.quadroOcultar.Título = "Visualização";
            this.quadroOcultar.Visible = false;
            // 
            // opçãoMostraPedidosJaEntregues
            // 
            this.opçãoMostraPedidosJaEntregues.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMostraPedidosJaEntregues.Descrição = "Mostrar serviços já entregues";
            this.opçãoMostraPedidosJaEntregues.Imagem = global::Apresentação.Resource.Filter2HS;
            this.opçãoMostraPedidosJaEntregues.Location = new System.Drawing.Point(5, 34);
            this.opçãoMostraPedidosJaEntregues.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMostraPedidosJaEntregues.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMostraPedidosJaEntregues.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMostraPedidosJaEntregues.Name = "opçãoMostraPedidosJaEntregues";
            this.opçãoMostraPedidosJaEntregues.Size = new System.Drawing.Size(150, 36);
            this.opçãoMostraPedidosJaEntregues.TabIndex = 3;
            this.opçãoMostraPedidosJaEntregues.Click += new System.EventHandler(this.opçãoMostraPedidosJaEntregues_Click);
            // 
            // opçãoOcutarPedidosJaEntregues
            // 
            this.opçãoOcutarPedidosJaEntregues.BackColor = System.Drawing.Color.Transparent;
            this.opçãoOcutarPedidosJaEntregues.Descrição = "Ocultar serviços já entregues";
            this.opçãoOcutarPedidosJaEntregues.Imagem = global::Apresentação.Resource.Filter2HS;
            this.opçãoOcutarPedidosJaEntregues.Location = new System.Drawing.Point(5, 34);
            this.opçãoOcutarPedidosJaEntregues.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoOcutarPedidosJaEntregues.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoOcutarPedidosJaEntregues.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoOcutarPedidosJaEntregues.Name = "opçãoOcutarPedidosJaEntregues";
            this.opçãoOcutarPedidosJaEntregues.Size = new System.Drawing.Size(150, 36);
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
            this.quadroPedidosConsertos.Controls.Add(this.optPedidos);
            this.quadroPedidosConsertos.Controls.Add(this.optConsertos);
            this.quadroPedidosConsertos.Cor = System.Drawing.Color.Black;
            this.quadroPedidosConsertos.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPedidosConsertos.LetraTítulo = System.Drawing.Color.White;
            this.quadroPedidosConsertos.Location = new System.Drawing.Point(7, 142);
            this.quadroPedidosConsertos.MostrarBotãoMinMax = false;
            this.quadroPedidosConsertos.Name = "quadroPedidosConsertos";
            this.quadroPedidosConsertos.Size = new System.Drawing.Size(160, 73);
            this.quadroPedidosConsertos.TabIndex = 4;
            this.quadroPedidosConsertos.Tamanho = 30;
            this.quadroPedidosConsertos.Título = "Tipo de exibição";
            // 
            // optPedidos
            // 
            this.optPedidos.BackColor = System.Drawing.Color.Transparent;
            this.optPedidos.Checked = true;
            this.optPedidos.Location = new System.Drawing.Point(7, 26);
            this.optPedidos.Name = "optPedidos";
            this.optPedidos.Size = new System.Drawing.Size(160, 25);
            this.optPedidos.TabIndex = 3;
            this.optPedidos.TabStop = true;
            this.optPedidos.Text = "Pedidos";
            this.optPedidos.UseVisualStyleBackColor = false;
            this.optPedidos.CheckedChanged += new System.EventHandler(this.optPedidos_CheckedChanged);
            // 
            // optConsertos
            // 
            this.optConsertos.BackColor = System.Drawing.Color.Transparent;
            this.optConsertos.Location = new System.Drawing.Point(7, 50);
            this.optConsertos.Name = "optConsertos";
            this.optConsertos.Size = new System.Drawing.Size(160, 18);
            this.optConsertos.TabIndex = 4;
            this.optConsertos.Text = "Consertos";
            this.optConsertos.UseVisualStyleBackColor = false;
            this.optConsertos.CheckedChanged += new System.EventHandler(this.optConsertos_CheckedChanged);
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
            this.quadroPedido.ResumeLayout(false);
            this.quadroOcultar.ResumeLayout(false);
            this.quadroPedidosConsertos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private ListaPedidosSimples listaPedidos;
        private Apresentação.Formulários.Quadro quadroVisualização;
        private Apresentação.Formulários.Opção opçãoEscolherPeríodo;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Quadro quadroPedido;
        private Apresentação.Formulários.Opção opçãoNovo;
        private System.Windows.Forms.RadioButton optRecepção;
        private System.Windows.Forms.RadioButton optPrevisão;
        private Apresentação.Formulários.Quadro quadroOcultar;
        private Apresentação.Formulários.Opção opçãoOcutarPedidosJaEntregues;
        private Apresentação.Formulários.Opção opçãoMostraPedidosJaEntregues;
        private Apresentação.Formulários.Quadro quadroPedidosConsertos;
        private System.Windows.Forms.RadioButton optPedidos;
        private System.Windows.Forms.RadioButton optConsertos;
        private Apresentação.Formulários.Opção opçãoExcluir;
        private System.Windows.Forms.RadioButton optTodos;
        private Formulários.Opção opçãoImprimirResumo;
    }
}
