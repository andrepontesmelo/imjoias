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
            this.listaPedidos = new Apresentação.Atendimento.Clientes.Pedido.ListaPedidos();
            this.quadroVisualização = new Apresentação.Formulários.Quadro();
            this.optPrevisão = new System.Windows.Forms.RadioButton();
            this.optRecepção = new System.Windows.Forms.RadioButton();
            this.opçãoEscolherPeríodo = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadroPedido = new Apresentação.Formulários.Quadro();
            this.opçãoNovo = new Apresentação.Formulários.Opção();
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
            this.esquerda.Controls.Add(this.quadroOcultar);
            this.esquerda.Controls.Add(this.quadroVisualização);
            this.esquerda.Controls.Add(this.quadroPedidosConsertos);
            this.esquerda.Controls.Add(this.quadroPedido);
            this.esquerda.Size = new System.Drawing.Size(187, 566);
            this.esquerda.Controls.SetChildIndex(this.quadroPedido, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroPedidosConsertos, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroVisualização, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroOcultar, 0);
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Listagem de pedidos e consertos pendentes.";
            this.títuloBaseInferior1.Imagem = global::Apresentação.Atendimento.Properties.Resources.Pedido;
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
            this.listaPedidos.BackColor = System.Drawing.Color.Olive;
            this.listaPedidos.Location = new System.Drawing.Point(186, 111);
            this.listaPedidos.Name = "listaPedidos";
            this.listaPedidos.Size = new System.Drawing.Size(611, 424);
            this.listaPedidos.TabIndex = 7;
            this.listaPedidos.AoClicar += new Apresentação.Atendimento.Clientes.Pedido.ItemPedido.PedidoDelegate(this.listaPedidos_AoClicar);
            // 
            // quadroVisualização
            // 
            this.quadroVisualização.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVisualização.bInfDirArredondada = true;
            this.quadroVisualização.bInfEsqArredondada = true;
            this.quadroVisualização.bSupDirArredondada = true;
            this.quadroVisualização.bSupEsqArredondada = true;
            this.quadroVisualização.Controls.Add(this.optPrevisão);
            this.quadroVisualização.Controls.Add(this.optRecepção);
            this.quadroVisualização.Controls.Add(this.opçãoEscolherPeríodo);
            this.quadroVisualização.Cor = System.Drawing.Color.Black;
            this.quadroVisualização.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVisualização.LetraTítulo = System.Drawing.Color.White;
            this.quadroVisualização.Location = new System.Drawing.Point(7, 101);
            this.quadroVisualização.MostrarBotãoMinMax = false;
            this.quadroVisualização.Name = "quadroVisualização";
            this.quadroVisualização.Size = new System.Drawing.Size(160, 130);
            this.quadroVisualização.TabIndex = 1;
            this.quadroVisualização.Tamanho = 30;
            this.quadroVisualização.Título = "Período";
            // 
            // optPrevisão
            // 
            this.optPrevisão.BackColor = System.Drawing.Color.Transparent;
            this.optPrevisão.Location = new System.Drawing.Point(5, 29);
            this.optPrevisão.Name = "optPrevisão";
            this.optPrevisão.Size = new System.Drawing.Size(145, 34);
            this.optPrevisão.TabIndex = 3;
            this.optPrevisão.Text = "Mostrar os previstos para o período";
            this.optPrevisão.UseVisualStyleBackColor = false;
            this.optPrevisão.CheckedChanged += new System.EventHandler(this.optPrevisão_CheckedChanged);
            // 
            // optRecepção
            // 
            this.optRecepção.BackColor = System.Drawing.Color.Transparent;
            this.optRecepção.Checked = true;
            this.optRecepção.Location = new System.Drawing.Point(5, 60);
            this.optRecepção.Name = "optRecepção";
            this.optRecepção.Size = new System.Drawing.Size(145, 35);
            this.optRecepção.TabIndex = 4;
            this.optRecepção.TabStop = true;
            this.optRecepção.Text = "Mostrar os recebidos/registrados no período";
            this.optRecepção.UseVisualStyleBackColor = false;
            this.optRecepção.CheckedChanged += new System.EventHandler(this.optRecepção_CheckedChanged);
            // 
            // opçãoEscolherPeríodo
            // 
            this.opçãoEscolherPeríodo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEscolherPeríodo.Descrição = "Escolher período...";
            this.opçãoEscolherPeríodo.Imagem = global::Apresentação.Atendimento.Properties.Resources.calendário___inclinado;
            this.opçãoEscolherPeríodo.Location = new System.Drawing.Point(2, 98);
            this.opçãoEscolherPeríodo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEscolherPeríodo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEscolherPeríodo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEscolherPeríodo.Name = "opçãoEscolherPeríodo";
            this.opçãoEscolherPeríodo.Size = new System.Drawing.Size(150, 24);
            this.opçãoEscolherPeríodo.TabIndex = 2;
            this.opçãoEscolherPeríodo.Click += new System.EventHandler(this.opçãoEscolherPeríodo_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir listagem...";
            this.opçãoImprimir.Imagem = global::Apresentação.Atendimento.Properties.Resources.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 52);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
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
            this.quadroPedido.Controls.Add(this.opçãoNovo);
            this.quadroPedido.Controls.Add(this.opçãoImprimir);
            this.quadroPedido.Cor = System.Drawing.Color.Black;
            this.quadroPedido.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPedido.LetraTítulo = System.Drawing.Color.White;
            this.quadroPedido.Location = new System.Drawing.Point(7, 13);
            this.quadroPedido.MostrarBotãoMinMax = false;
            this.quadroPedido.Name = "quadroPedido";
            this.quadroPedido.Size = new System.Drawing.Size(160, 82);
            this.quadroPedido.TabIndex = 2;
            this.quadroPedido.Tamanho = 30;
            this.quadroPedido.Título = "Pedidos e Consertos";
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovo.Descrição = "Cadastrar novo";
            this.opçãoNovo.Imagem = global::Apresentação.Atendimento.Properties.Resources.document;
            this.opçãoNovo.Location = new System.Drawing.Point(5, 29);
            this.opçãoNovo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovo.Name = "opçãoNovo";
            this.opçãoNovo.Size = new System.Drawing.Size(150, 23);
            this.opçãoNovo.TabIndex = 2;
            this.opçãoNovo.Click += new System.EventHandler(this.opçãoNovo_Click);
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
            this.quadroOcultar.Location = new System.Drawing.Point(7, 342);
            this.quadroOcultar.MostrarBotãoMinMax = false;
            this.quadroOcultar.Name = "quadroOcultar";
            this.quadroOcultar.Size = new System.Drawing.Size(160, 76);
            this.quadroOcultar.TabIndex = 3;
            this.quadroOcultar.Tamanho = 30;
            this.quadroOcultar.Título = "Visualização";
            // 
            // opçãoMostraPedidosJaEntregues
            // 
            this.opçãoMostraPedidosJaEntregues.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMostraPedidosJaEntregues.Descrição = "Mostrar serviços já entregues";
            this.opçãoMostraPedidosJaEntregues.Imagem = global::Apresentação.Atendimento.Properties.Resources.Filter2HS;
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
            this.opçãoOcutarPedidosJaEntregues.Imagem = global::Apresentação.Atendimento.Properties.Resources.Filter2HS;
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
            this.quadroPedidosConsertos.Location = new System.Drawing.Point(7, 237);
            this.quadroPedidosConsertos.MostrarBotãoMinMax = false;
            this.quadroPedidosConsertos.Name = "quadroPedidosConsertos";
            this.quadroPedidosConsertos.Size = new System.Drawing.Size(160, 99);
            this.quadroPedidosConsertos.TabIndex = 4;
            this.quadroPedidosConsertos.Tamanho = 30;
            this.quadroPedidosConsertos.Título = "Tipo do serviço";
            // 
            // optPedidos
            // 
            this.optPedidos.BackColor = System.Drawing.Color.Transparent;
            this.optPedidos.Checked = true;
            this.optPedidos.Location = new System.Drawing.Point(5, 29);
            this.optPedidos.Name = "optPedidos";
            this.optPedidos.Size = new System.Drawing.Size(145, 34);
            this.optPedidos.TabIndex = 3;
            this.optPedidos.TabStop = true;
            this.optPedidos.Text = "Mostrar pedidos";
            this.optPedidos.UseVisualStyleBackColor = false;
            this.optPedidos.CheckedChanged += new System.EventHandler(this.optPedidos_CheckedChanged);
            // 
            // optConsertos
            // 
            this.optConsertos.BackColor = System.Drawing.Color.Transparent;
            this.optConsertos.Location = new System.Drawing.Point(5, 60);
            this.optConsertos.Name = "optConsertos";
            this.optConsertos.Size = new System.Drawing.Size(145, 35);
            this.optConsertos.TabIndex = 4;
            this.optConsertos.Text = "Mostrar consertos";
            this.optConsertos.UseVisualStyleBackColor = false;
            this.optConsertos.CheckedChanged += new System.EventHandler(this.optConsertos_CheckedChanged);
            // 
            // BasePedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listaPedidos);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Imagem = global::Apresentação.Atendimento.Properties.Resources.Pedido;
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
        private ListaPedidos listaPedidos;
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
    }
}
