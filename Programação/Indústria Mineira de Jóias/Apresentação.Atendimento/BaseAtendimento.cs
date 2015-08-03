using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;

using Apresentação.Formulários;
using Apresentação.Pessoa.Cadastro;

using Entidades;
using Entidades.Pessoa;

using Apresentação.Financeiro.Venda;
using System.Threading;
using Apresentação.Financeiro.Acerto;
using Entidades.Acerto;
using Entidades.Relacionamento.Venda;
using Apresentação.Atendimento.Clientes.Pedido;
using System.Drawing.Printing;
using Apresentação.Atendimento.Clientes;

namespace Apresentação.Atendimento
{
	/// <summary>
	/// Base inferior para atendimento.
	/// </summary>
	public class BaseAtendimento : Apresentação.Formulários.BaseInferior
	{
        /// <summary>
        /// Entidade da pessoa atual.
        /// </summary>
        /// <remarks>
        /// Pode ser nulo.
        /// </remarks>
        private Entidades.Pessoa.Pessoa pessoa = null;

        // Componentes
        private Apresentação.Formulários.TítuloBaseInferior título;
        private Apresentação.Formulários.Quadro quadroCliente;
        private Apresentação.Formulários.Opção opçãoAbrir;
        private Apresentação.Formulários.Opção opçãoOutro;
        private Apresentação.Formulários.Quadro quadroRelacionar;
        private Apresentação.Formulários.Opção opçãoSaída;
        private Apresentação.Formulários.Quadro quadroPendências;
        private ListView lstPendências;
        private ColumnHeader colItem;
        private ColumnHeader colDescrição;
        private Opção opçãoConsignadoVenda;
        private Opção opçãoVendas;
        private Quadro quadroVendas;
        private Opção opçãoAcerto;
        private Opção opçãoComissão;
        private Opção opçãoPagamentos;
        private TableLayoutPanel tableLayoutPanel1;
        private Quadro quadroClassificador;
        private Classificador classificador;
        private BackgroundWorker bgDescobrirPendência;
        private Opção opçãoRetorno;
        private BackgroundWorker bgConsistência;
        private Opção opçãoOcultar;
        private Quadro quadroModoAtendimento;
        private Opção opçãoEncerrarAtendimento;
        private Quadro quadro1;
        private Opção opçãoPedido;
        private Opção opçãoMalaDireta;
        private Quadro quadroObs;
        private TextBox txtObs;
        private SinalizaçãoPedido sinalizaçãoPedido;
        private Opção opçãoCréditos;
        private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a base de atendimento.
		/// </summary>
		public BaseAtendimento()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            colItem.Width = lstPendências.ClientSize.Width - colDescrição.Width;

//#warning Desligada aqui a mala-direta!
//#if !DEBUG
//            opçãoMalaDireta.Visible = false;
//#endif
        }

		/// <summary>
		/// Constrói a base inferior, fornecendo os dados do cliente.
		/// </summary>
		/// <param name="cliente">Entidade do cliente.</param>
		public BaseAtendimento(Entidades.Pessoa.Pessoa cliente) : base()
		{
			Preparar(cliente);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        public new Atendente.ControladorAtendimentoGenérico Controlador
        {
            get { return (Atendente.ControladorAtendimentoGenérico)base.Controlador; }
        }

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseAtendimento));
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroCliente = new Apresentação.Formulários.Quadro();
            this.opçãoOutro = new Apresentação.Formulários.Opção();
            this.opçãoAbrir = new Apresentação.Formulários.Opção();
            this.opçãoOcultar = new Apresentação.Formulários.Opção();
            this.opçãoVendas = new Apresentação.Formulários.Opção();
            this.quadroRelacionar = new Apresentação.Formulários.Quadro();
            this.opçãoSaída = new Apresentação.Formulários.Opção();
            this.opçãoRetorno = new Apresentação.Formulários.Opção();
            this.opçãoAcerto = new Apresentação.Formulários.Opção();
            this.opçãoConsignadoVenda = new Apresentação.Formulários.Opção();
            this.quadroPendências = new Apresentação.Formulários.Quadro();
            this.lstPendências = new System.Windows.Forms.ListView();
            this.colItem = new System.Windows.Forms.ColumnHeader();
            this.colDescrição = new System.Windows.Forms.ColumnHeader();
            this.quadroVendas = new Apresentação.Formulários.Quadro();
            this.opçãoCréditos = new Apresentação.Formulários.Opção();
            this.opçãoComissão = new Apresentação.Formulários.Opção();
            this.opçãoPagamentos = new Apresentação.Formulários.Opção();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sinalizaçãoPedido = new Apresentação.Atendimento.SinalizaçãoPedido();
            this.quadroClassificador = new Apresentação.Formulários.Quadro();
            this.classificador = new Apresentação.Pessoa.Cadastro.Classificador();
            this.quadroObs = new Apresentação.Formulários.Quadro();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.bgDescobrirPendência = new System.ComponentModel.BackgroundWorker();
            this.bgConsistência = new System.ComponentModel.BackgroundWorker();
            this.quadroModoAtendimento = new Apresentação.Formulários.Quadro();
            this.opçãoEncerrarAtendimento = new Apresentação.Formulários.Opção();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoPedido = new Apresentação.Formulários.Opção();
            this.opçãoMalaDireta = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadroCliente.SuspendLayout();
            this.quadroRelacionar.SuspendLayout();
            this.quadroPendências.SuspendLayout();
            this.quadroVendas.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.quadroClassificador.SuspendLayout();
            this.quadroObs.SuspendLayout();
            this.quadroModoAtendimento.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Controls.Add(this.quadroCliente);
            this.esquerda.Controls.Add(this.quadroModoAtendimento);
            this.esquerda.Controls.Add(this.quadroRelacionar);
            this.esquerda.Controls.Add(this.quadroVendas);
            this.esquerda.Size = new System.Drawing.Size(187, 510);
            this.esquerda.Controls.SetChildIndex(this.quadroVendas, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroRelacionar, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroModoAtendimento, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroCliente, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Descrição";
            this.título.Imagem = null;
            this.título.Location = new System.Drawing.Point(200, 8);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(791, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Nome do cliente";
            // 
            // quadroCliente
            // 
            this.quadroCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroCliente.bInfDirArredondada = true;
            this.quadroCliente.bInfEsqArredondada = true;
            this.quadroCliente.bSupDirArredondada = true;
            this.quadroCliente.bSupEsqArredondada = true;
            this.quadroCliente.Controls.Add(this.opçãoOutro);
            this.quadroCliente.Controls.Add(this.opçãoAbrir);
            this.quadroCliente.Controls.Add(this.opçãoOcultar);
            this.quadroCliente.Cor = System.Drawing.Color.Black;
            this.quadroCliente.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroCliente.LetraTítulo = System.Drawing.Color.White;
            this.quadroCliente.Location = new System.Drawing.Point(7, 13);
            this.quadroCliente.MostrarBotãoMinMax = false;
            this.quadroCliente.Name = "quadroCliente";
            this.quadroCliente.Size = new System.Drawing.Size(160, 102);
            this.quadroCliente.TabIndex = 0;
            this.quadroCliente.Tamanho = 30;
            this.quadroCliente.Título = "Ficha da Pessoa";
            // 
            // opçãoOutro
            // 
            this.opçãoOutro.BackColor = System.Drawing.Color.Transparent;
            this.opçãoOutro.Descrição = "Escolher outra pessoa";
            this.opçãoOutro.Imagem = global::Apresentação.Atendimento.Properties.Resources.delete_16x;
            this.opçãoOutro.Location = new System.Drawing.Point(8, 56);
            this.opçãoOutro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoOutro.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoOutro.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoOutro.Name = "opçãoOutro";
            this.opçãoOutro.Size = new System.Drawing.Size(150, 24);
            this.opçãoOutro.TabIndex = 3;
            this.opçãoOutro.Click += new System.EventHandler(this.opçãoOutro_Click);
            // 
            // opçãoAbrir
            // 
            this.opçãoAbrir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrir.Descrição = "Abrir ficha...";
            this.opçãoAbrir.Imagem = global::Apresentação.Atendimento.Properties.Resources.folderopen;
            this.opçãoAbrir.Location = new System.Drawing.Point(8, 32);
            this.opçãoAbrir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoAbrir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.Name = "opçãoAbrir";
            this.opçãoAbrir.Privilégio = Entidades.Privilégio.Permissão.CadastroAcesso;
            this.opçãoAbrir.Size = new System.Drawing.Size(150, 24);
            this.opçãoAbrir.TabIndex = 2;
            this.opçãoAbrir.Click += new System.EventHandler(this.opçãoAbrir_Click);
            // 
            // opçãoOcultar
            // 
            this.opçãoOcultar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoOcultar.Descrição = "Ocultar dados";
            this.opçãoOcultar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoOcultar.Imagem")));
            this.opçãoOcultar.Location = new System.Drawing.Point(6, 78);
            this.opçãoOcultar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoOcultar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoOcultar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoOcultar.Name = "opçãoOcultar";
            this.opçãoOcultar.Size = new System.Drawing.Size(150, 24);
            this.opçãoOcultar.TabIndex = 4;
            this.opçãoOcultar.Click += new System.EventHandler(this.opçãoOcultar_Click);
            // 
            // opçãoVendas
            // 
            this.opçãoVendas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoVendas.Descrição = "Visualizar vendas";
            this.opçãoVendas.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVendas.Imagem")));
            this.opçãoVendas.Location = new System.Drawing.Point(6, 29);
            this.opçãoVendas.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoVendas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVendas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVendas.Name = "opçãoVendas";
            this.opçãoVendas.Privilégio = Entidades.Privilégio.Permissão.VendasLeitura;
            this.opçãoVendas.Size = new System.Drawing.Size(150, 20);
            this.opçãoVendas.TabIndex = 4;
            this.opçãoVendas.Click += new System.EventHandler(this.opçãoVendas_Click);
            // 
            // quadroRelacionar
            // 
            this.quadroRelacionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroRelacionar.bInfDirArredondada = true;
            this.quadroRelacionar.bInfEsqArredondada = true;
            this.quadroRelacionar.bSupDirArredondada = true;
            this.quadroRelacionar.bSupEsqArredondada = true;
            this.quadroRelacionar.Controls.Add(this.opçãoSaída);
            this.quadroRelacionar.Controls.Add(this.opçãoRetorno);
            this.quadroRelacionar.Controls.Add(this.opçãoAcerto);
            this.quadroRelacionar.Cor = System.Drawing.Color.Black;
            this.quadroRelacionar.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRelacionar.LetraTítulo = System.Drawing.Color.White;
            this.quadroRelacionar.Location = new System.Drawing.Point(7, 121);
            this.quadroRelacionar.MostrarBotãoMinMax = false;
            this.quadroRelacionar.Name = "quadroRelacionar";
            this.quadroRelacionar.Privilégio = Entidades.Privilégio.Permissão.Consignado;
            this.quadroRelacionar.Size = new System.Drawing.Size(160, 107);
            this.quadroRelacionar.TabIndex = 2;
            this.quadroRelacionar.Tamanho = 30;
            this.quadroRelacionar.Título = "Consignado";
            // 
            // opçãoSaída
            // 
            this.opçãoSaída.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSaída.Descrição = "Saída da empresa...";
            this.opçãoSaída.Imagem = global::Apresentação.Atendimento.Properties.Resources.Saída__Pequeno_;
            this.opçãoSaída.Location = new System.Drawing.Point(6, 33);
            this.opçãoSaída.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.opçãoSaída.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSaída.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSaída.Name = "opçãoSaída";
            this.opçãoSaída.Privilégio = Entidades.Privilégio.Permissão.ConsignadoSaída;
            this.opçãoSaída.Size = new System.Drawing.Size(150, 24);
            this.opçãoSaída.TabIndex = 2;
            this.opçãoSaída.Click += new System.EventHandler(this.opçãoSaída_Click);
            // 
            // opçãoRetorno
            // 
            this.opçãoRetorno.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRetorno.Descrição = "Retorno para a empresa...";
            this.opçãoRetorno.Imagem = global::Apresentação.Atendimento.Properties.Resources.Retorno__Ícone_;
            this.opçãoRetorno.Location = new System.Drawing.Point(6, 57);
            this.opçãoRetorno.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoRetorno.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRetorno.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRetorno.Name = "opçãoRetorno";
            this.opçãoRetorno.Privilégio = Entidades.Privilégio.Permissão.ConsignadoRetorno;
            this.opçãoRetorno.Size = new System.Drawing.Size(150, 24);
            this.opçãoRetorno.TabIndex = 4;
            this.opçãoRetorno.Click += new System.EventHandler(this.opçãoRetorno_Click);
            // 
            // opçãoAcerto
            // 
            this.opçãoAcerto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAcerto.Descrição = "Acerto de mercadorias...";
            this.opçãoAcerto.Imagem = global::Apresentação.Atendimento.Properties.Resources.Acerto__Pequeno_;
            this.opçãoAcerto.Location = new System.Drawing.Point(6, 81);
            this.opçãoAcerto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAcerto.Name = "opçãoAcerto";
            this.opçãoAcerto.Size = new System.Drawing.Size(150, 27);
            this.opçãoAcerto.TabIndex = 2;
            this.opçãoAcerto.Click += new System.EventHandler(this.opçãoAcerto_Click);
            // 
            // opçãoConsignadoVenda
            // 
            this.opçãoConsignadoVenda.BackColor = System.Drawing.Color.Transparent;
            this.opçãoConsignadoVenda.Descrição = "Registrar venda";
            this.opçãoConsignadoVenda.Imagem = global::Apresentação.Atendimento.Properties.Resources.pagar_em_dólares__pequeno_;
            this.opçãoConsignadoVenda.Location = new System.Drawing.Point(6, 47);
            this.opçãoConsignadoVenda.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoConsignadoVenda.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoConsignadoVenda.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoConsignadoVenda.Name = "opçãoConsignadoVenda";
            this.opçãoConsignadoVenda.Privilégio = Entidades.Privilégio.Permissão.VendasRemoverControle;
            this.opçãoConsignadoVenda.Size = new System.Drawing.Size(150, 21);
            this.opçãoConsignadoVenda.TabIndex = 5;
            this.opçãoConsignadoVenda.Click += new System.EventHandler(this.opçãoConsignadoVenda_Click);
            // 
            // quadroPendências
            // 
            this.quadroPendências.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroPendências.bInfDirArredondada = true;
            this.quadroPendências.bInfEsqArredondada = true;
            this.quadroPendências.bSupDirArredondada = true;
            this.quadroPendências.bSupEsqArredondada = true;
            this.quadroPendências.Controls.Add(this.lstPendências);
            this.quadroPendências.Cor = System.Drawing.Color.Black;
            this.quadroPendências.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadroPendências.FundoTítulo = System.Drawing.Color.Brown;
            this.quadroPendências.LetraTítulo = System.Drawing.Color.White;
            this.quadroPendências.Location = new System.Drawing.Point(3, 3);
            this.quadroPendências.MostrarBotãoMinMax = false;
            this.quadroPendências.Name = "quadroPendências";
            this.quadroPendências.Size = new System.Drawing.Size(184, 150);
            this.quadroPendências.TabIndex = 8;
            this.quadroPendências.Tamanho = 30;
            this.quadroPendências.Título = "Pendências";
            // 
            // lstPendências
            // 
            this.lstPendências.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPendências.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lstPendências.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPendências.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItem,
            this.colDescrição});
            this.lstPendências.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPendências.FullRowSelect = true;
            this.lstPendências.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstPendências.Location = new System.Drawing.Point(3, 27);
            this.lstPendências.MultiSelect = false;
            this.lstPendências.Name = "lstPendências";
            this.lstPendências.Size = new System.Drawing.Size(178, 117);
            this.lstPendências.TabIndex = 2;
            this.lstPendências.UseCompatibleStateImageBehavior = false;
            this.lstPendências.View = System.Windows.Forms.View.Details;
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            this.colItem.Width = 118;
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDescrição.Width = 45;
            // 
            // quadroVendas
            // 
            this.quadroVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroVendas.AutoSize = true;
            this.quadroVendas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quadroVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVendas.bInfDirArredondada = true;
            this.quadroVendas.bInfEsqArredondada = true;
            this.quadroVendas.bSupDirArredondada = true;
            this.quadroVendas.bSupEsqArredondada = true;
            this.quadroVendas.Controls.Add(this.opçãoCréditos);
            this.quadroVendas.Controls.Add(this.opçãoVendas);
            this.quadroVendas.Controls.Add(this.opçãoConsignadoVenda);
            this.quadroVendas.Controls.Add(this.opçãoComissão);
            this.quadroVendas.Controls.Add(this.opçãoPagamentos);
            this.quadroVendas.Cor = System.Drawing.Color.Black;
            this.quadroVendas.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendas.LetraTítulo = System.Drawing.Color.White;
            this.quadroVendas.Location = new System.Drawing.Point(7, 234);
            this.quadroVendas.MostrarBotãoMinMax = false;
            this.quadroVendas.Name = "quadroVendas";
            this.quadroVendas.Privilégio = Entidades.Privilégio.Permissão.Vendas;
            this.quadroVendas.Size = new System.Drawing.Size(162, 129);
            this.quadroVendas.TabIndex = 3;
            this.quadroVendas.Tamanho = 30;
            this.quadroVendas.Título = "Financeiro";
            // 
            // opçãoCréditos
            // 
            this.opçãoCréditos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCréditos.Descrição = "Créditos";
            this.opçãoCréditos.Imagem = global::Apresentação.Atendimento.Properties.Resources.moedaunica;
            this.opçãoCréditos.Location = new System.Drawing.Point(7, 105);
            this.opçãoCréditos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCréditos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCréditos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCréditos.Name = "opçãoCréditos";
            this.opçãoCréditos.Size = new System.Drawing.Size(150, 24);
            this.opçãoCréditos.TabIndex = 8;
            this.opçãoCréditos.Click += new System.EventHandler(this.opçãoCréditos_Click);
            // 
            // opçãoComissão
            // 
            this.opçãoComissão.BackColor = System.Drawing.Color.Transparent;
            this.opçãoComissão.Descrição = "Comissão";
            this.opçãoComissão.Imagem = global::Apresentação.Atendimento.Properties.Resources.moedaunica;
            this.opçãoComissão.Location = new System.Drawing.Point(6, 68);
            this.opçãoComissão.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoComissão.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoComissão.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoComissão.Name = "opçãoComissão";
            this.opçãoComissão.Size = new System.Drawing.Size(150, 16);
            this.opçãoComissão.TabIndex = 6;
            this.opçãoComissão.Click += new System.EventHandler(this.opçãoComissão_Click);
            // 
            // opçãoPagamentos
            // 
            this.opçãoPagamentos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoPagamentos.Descrição = "Pagamentos";
            this.opçãoPagamentos.Imagem = global::Apresentação.Atendimento.Properties.Resources.moedaunica;
            this.opçãoPagamentos.Location = new System.Drawing.Point(6, 87);
            this.opçãoPagamentos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoPagamentos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoPagamentos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoPagamentos.Name = "opçãoPagamentos";
            this.opçãoPagamentos.Size = new System.Drawing.Size(150, 24);
            this.opçãoPagamentos.TabIndex = 7;
            this.opçãoPagamentos.Click += new System.EventHandler(this.opçãoPagamentos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.sinalizaçãoPedido, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.quadroClassificador, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadroPendências, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.quadroObs, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(193, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 414);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // sinalizaçãoPedido
            // 
            this.sinalizaçãoPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sinalizaçãoPedido.Borda = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.sinalizaçãoPedido, 2);
            this.sinalizaçãoPedido.Cor1 = System.Drawing.Color.LightYellow;
            this.sinalizaçãoPedido.Cor2 = System.Drawing.Color.Ivory;
            this.sinalizaçãoPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sinalizaçãoPedido.Location = new System.Drawing.Point(3, 367);
            this.sinalizaçãoPedido.MinimumSize = new System.Drawing.Size(100, 32);
            this.sinalizaçãoPedido.Name = "sinalizaçãoPedido";
            this.sinalizaçãoPedido.Size = new System.Drawing.Size(805, 44);
            this.sinalizaçãoPedido.TabIndex = 12;
            this.sinalizaçãoPedido.Click += new System.EventHandler(this.opçãoPedido_Click);
            // 
            // quadroClassificador
            // 
            this.quadroClassificador.AutoSize = true;
            this.quadroClassificador.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quadroClassificador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroClassificador.bInfDirArredondada = false;
            this.quadroClassificador.bInfEsqArredondada = false;
            this.quadroClassificador.bSupDirArredondada = true;
            this.quadroClassificador.bSupEsqArredondada = true;
            this.quadroClassificador.Controls.Add(this.classificador);
            this.quadroClassificador.Cor = System.Drawing.Color.Black;
            this.quadroClassificador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadroClassificador.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroClassificador.LetraTítulo = System.Drawing.Color.White;
            this.quadroClassificador.Location = new System.Drawing.Point(3, 159);
            this.quadroClassificador.MostrarBotãoMinMax = false;
            this.quadroClassificador.Name = "quadroClassificador";
            this.quadroClassificador.Privilégio = Entidades.Privilégio.Permissão.CadastroAcesso;
            this.quadroClassificador.Size = new System.Drawing.Size(184, 202);
            this.quadroClassificador.TabIndex = 11;
            this.quadroClassificador.Tamanho = 30;
            this.quadroClassificador.Título = "Classificações";
            // 
            // classificador
            // 
            this.classificador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.classificador.AutoAtualizarBD = true;
            this.classificador.BackColor = System.Drawing.Color.White;
            this.classificador.Location = new System.Drawing.Point(3, 25);
            this.classificador.Name = "classificador";
            this.classificador.Pessoa = null;
            this.classificador.Size = new System.Drawing.Size(178, 174);
            this.classificador.TabIndex = 10;
            // 
            // quadroObs
            // 
            this.quadroObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.quadroObs.bInfDirArredondada = true;
            this.quadroObs.bInfEsqArredondada = true;
            this.quadroObs.bSupDirArredondada = true;
            this.quadroObs.bSupEsqArredondada = true;
            this.quadroObs.Controls.Add(this.txtObs);
            this.quadroObs.Cor = System.Drawing.Color.Black;
            this.quadroObs.FundoTítulo = System.Drawing.Color.Olive;
            this.quadroObs.LetraTítulo = System.Drawing.Color.White;
            this.quadroObs.Location = new System.Drawing.Point(193, 3);
            this.quadroObs.MostrarBotãoMinMax = false;
            this.quadroObs.Name = "quadroObs";
            this.tableLayoutPanel1.SetRowSpan(this.quadroObs, 2);
            this.quadroObs.Size = new System.Drawing.Size(615, 358);
            this.quadroObs.TabIndex = 17;
            this.quadroObs.Tamanho = 30;
            this.quadroObs.Título = "Observações";
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.ForeColor = System.Drawing.Color.Black;
            this.txtObs.Location = new System.Drawing.Point(8, 32);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ReadOnly = true;
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObs.Size = new System.Drawing.Size(601, 318);
            this.txtObs.TabIndex = 2;
            this.txtObs.Text = "As observações só serão exibidas caso exista alguma.";
            // 
            // bgDescobrirPendência
            // 
            this.bgDescobrirPendência.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RecuperarPendências);
            this.bgDescobrirPendência.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MostrarPendências);
            // 
            // bgConsistência
            // 
            this.bgConsistência.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgConsistência_DoWork);
            // 
            // quadroModoAtendimento
            // 
            this.quadroModoAtendimento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroModoAtendimento.bInfDirArredondada = true;
            this.quadroModoAtendimento.bInfEsqArredondada = true;
            this.quadroModoAtendimento.bSupDirArredondada = true;
            this.quadroModoAtendimento.bSupEsqArredondada = true;
            this.quadroModoAtendimento.Controls.Add(this.opçãoEncerrarAtendimento);
            this.quadroModoAtendimento.Cor = System.Drawing.Color.Black;
            this.quadroModoAtendimento.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quadroModoAtendimento.LetraTítulo = System.Drawing.Color.White;
            this.quadroModoAtendimento.Location = new System.Drawing.Point(7, 463);
            this.quadroModoAtendimento.MostrarBotãoMinMax = false;
            this.quadroModoAtendimento.Name = "quadroModoAtendimento";
            this.quadroModoAtendimento.Size = new System.Drawing.Size(160, 62);
            this.quadroModoAtendimento.TabIndex = 4;
            this.quadroModoAtendimento.Tamanho = 30;
            this.quadroModoAtendimento.Título = "Atendimento";
            this.quadroModoAtendimento.Visible = false;
            // 
            // opçãoEncerrarAtendimento
            // 
            this.opçãoEncerrarAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEncerrarAtendimento.Descrição = "Encerrar modo de atendimento";
            this.opçãoEncerrarAtendimento.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoEncerrarAtendimento.Imagem")));
            this.opçãoEncerrarAtendimento.Location = new System.Drawing.Point(5, 28);
            this.opçãoEncerrarAtendimento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEncerrarAtendimento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEncerrarAtendimento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEncerrarAtendimento.Name = "opçãoEncerrarAtendimento";
            this.opçãoEncerrarAtendimento.Size = new System.Drawing.Size(150, 27);
            this.opçãoEncerrarAtendimento.TabIndex = 2;
            this.opçãoEncerrarAtendimento.Click += new System.EventHandler(this.opçãoEncerrarAtendimento_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoPedido);
            this.quadro1.Controls.Add(this.opçãoMalaDireta);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 368);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 89);
            this.quadro1.TabIndex = 5;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Serviços";
            // 
            // opçãoPedido
            // 
            this.opçãoPedido.BackColor = System.Drawing.Color.Transparent;
            this.opçãoPedido.Descrição = "Pedidos e consertos";
            this.opçãoPedido.Imagem = global::Apresentação.Atendimento.Properties.Resources.Pedido;
            this.opçãoPedido.Location = new System.Drawing.Point(7, 31);
            this.opçãoPedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoPedido.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoPedido.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoPedido.Name = "opçãoPedido";
            this.opçãoPedido.Size = new System.Drawing.Size(150, 24);
            this.opçãoPedido.TabIndex = 2;
            this.opçãoPedido.Click += new System.EventHandler(this.opçãoPedido_Click);
            // 
            // opçãoMalaDireta
            // 
            this.opçãoMalaDireta.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMalaDireta.Descrição = "Imprimir etiqueta para mala-direta";
            this.opçãoMalaDireta.Imagem = global::Apresentação.Atendimento.Properties.Resources.LABELS;
            this.opçãoMalaDireta.Location = new System.Drawing.Point(7, 55);
            this.opçãoMalaDireta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMalaDireta.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMalaDireta.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMalaDireta.Name = "opçãoMalaDireta";
            this.opçãoMalaDireta.Size = new System.Drawing.Size(150, 33);
            this.opçãoMalaDireta.TabIndex = 3;
            this.opçãoMalaDireta.Click += new System.EventHandler(this.opçãoMalaDireta_Click);
            // 
            // BaseAtendimento
            // 
            this.Controls.Add(this.título);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BaseAtendimento";
            this.Size = new System.Drawing.Size(1007, 510);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.esquerda.PerformLayout();
            this.quadroCliente.ResumeLayout(false);
            this.quadroRelacionar.ResumeLayout(false);
            this.quadroPendências.ResumeLayout(false);
            this.quadroVendas.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.quadroClassificador.ResumeLayout(false);
            this.quadroObs.ResumeLayout(false);
            this.quadroObs.PerformLayout();
            this.quadroModoAtendimento.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        #region Preparar cliente

        /// <summary>
        /// Prepara base inferior para exibição de um cliente.
        /// </summary>
        /// <param name="pessoa">Cadastro do cliente.</param>
        public void Preparar(Entidades.Pessoa.Pessoa cliente)
        {
            AguardeDB.Mostrar();

            sinalizaçãoPedido.Visible = false;
            string descrição = "";

            AdequarModoAtendimento();

            this.pessoa = Entidades.Pessoa.Pessoa.ObterPessoa(cliente.Código);

            título.Título = pessoa.Nome + " (" + pessoa.Código.ToString() + ")";

            //			if (pessoa is PessoaFísica)
            //				título.Descrição = "CPF/RG: " + ((PessoaFísica) pessoa).CPF + "/" + "RG: " + ((PessoaFísica) pessoa).RG + ((PessoaFísica) pessoa).RGEmissor
            //					+ "\nTelefone(s): " + pessoa.TelFixo + "  " + pessoa.TelCelular + "  " + pessoa.TelOutro;
            //			else if (pessoa is PessoaJurídica)
            //				título.Descrição = "CNPJ: " + ((PessoaJurídica) pessoa).CNPJ
            //					+ "\nTelefone(s): " + pessoa.TelFixo + "  " + pessoa.TelCelular + "  " + pessoa.TelOutro;
            //			else

            string strTelefones = "";

            foreach (Telefone telefone in pessoa.Telefones)
            {
                if (strTelefones.Length > 0)
                    strTelefones += "; ";

                strTelefones += telefone.Número;
            }

            if (cliente.Setor != null)
                descrição = "Setor: " + cliente.Setor.Nome.Trim();
            else
            {
                descrição = "Setor: <NÃO DEFINIDO>";

                AguardeDB.Fechar();

                MessageBox.Show(ParentForm,
                    "O setor da pessoa " + pessoa.Nome + " não está definido em sua ficha de cadastro.",
                    "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cliente.Região != null)
                descrição += " - " + cliente.Região.Nome.Trim() + "\n";
            else
                descrição += "\n";
            
            if (strTelefones.Trim() != "")
                descrição += "Telefone(s): " + strTelefones;
            
            List<Entidades.Pessoa.Endereço.Endereço> endereços = cliente.Endereços.ExtrairElementos();

            if (endereços.Count > 0 && endereços[0].Localidade != null)
                descrição += " - " + endereços[0].Localidade.Nome + " - " + endereços[0].Localidade.Estado.Sigla;

            título.Imagem = pessoa.Foto;

            bool éCliente = Entidades.Pessoa.Pessoa.ÉCliente(pessoa);
            if (éCliente)
            {
                // Talvez que seja um funcionário demitido. Vamos testar.
                // éCliente <= false caso seja funcionario demitido.
                éCliente &= !Entidades.Pessoa.Funcionário.ÉFuncionário(pessoa);
            }
            opçãoComissão.Enabled = !éCliente;

            PrepararObservações();

            classificador.Pessoa = pessoa;
            //histórico.Pessoa = pessoa;

            título.Descrição = descrição;

            //listaContaCorrente1.Cliente = pessoa;

            AguardeDB.Fechar();
        }

        private void AdequarModoAtendimento()
        {
            quadroModoAtendimento.Visible = Controlador.ModoAtendimento;
            quadroCliente.Visible = !Controlador.ModoAtendimento;
            //histórico.Visible = !Controlador.ModoAtendimento;
            quadroObs.Visible = !Controlador.ModoAtendimento;
            quadroClassificador.Visible = !Controlador.ModoAtendimento;
        }

        /// <summary>
		/// Prepara ambiente de observações.
		/// </summary>
		private void PrepararObservações()
		{
			txtObs.Text = pessoa.Observações;
			//quadroObs.Visible = pessoa.Observações != null && pessoa.Observações.Length > 0;
		}

		/// <summary>
		/// Ocorre ao clicar em "Escolher outro cliente".
		/// </summary>
		private void opçãoOutro_Click(object sender, System.EventArgs e)
		{
			SubstituirBaseParaAnterior();
		}

		/// <summary>
		/// Ocorre ao clicar em "Abrir ficha".
		/// </summary>
		private void opçãoAbrir_Click(object sender, System.EventArgs e)
		{
			DialogResult            resultado;
			Entidades.Pessoa.Pessoa entidade;

			/* Abaixo será verificado qual o tipo da pessoa. Em caso
			 * de alteração, deve-se tomar o CUIDADO com a ORDEM
			 * de verificação, pois uma classe pai responderá
			 * pelas classes filhas que estiverem após a sua verificação.
			 */

			// Funcionário
			if (Entidades.Pessoa.Funcionário.ÉFuncionário(pessoa))
			{
                AguardeDB.Mostrar();

                try
                {
                    if (!(pessoa is Funcionário))
                        pessoa = Entidades.Pessoa.Funcionário.ObterPessoa(pessoa.Código);
                }
                finally
                {
                    AguardeDB.Fechar();
                }

				using (CadastroFuncionário frm = new CadastroFuncionário((Entidades.Pessoa.Funcionário) pessoa))
				{
					resultado = frm.ShowDialog(this.ParentForm);
					entidade  = frm.Funcionário;
				}
			}
			/* Representante ou Pessoa Física
			 * 
			 * Um representante só possui um único campo inalterável (código)
			 * e, portanto, pode ser encarado como pessoa física.
			 */
			else if (pessoa is Entidades.Pessoa.PessoaFísica)
			{
                using (CadastroCliente frm = new CadastroCliente((PessoaFísica)pessoa))
				{
					resultado = frm.ShowDialog(this.ParentForm);
					entidade = frm.Pessoa;
				}
			}
			// Pessoa jurídica
            else if (pessoa is Entidades.Pessoa.PessoaJurídica)
                using (CadastroCliente frm = new CadastroCliente((PessoaJurídica)pessoa))
                {
                    resultado = frm.ShowDialog(this.ParentForm);
                    entidade = frm.Pessoa;
                }
            else if (pessoa is Entidades.Pessoa.Pessoa)
            {
                Entidades.Pessoa.PessoaJurídica juridica =
                    Entidades.Pessoa.PessoaJurídica.ObterPessoa(pessoa.Código);
                if (juridica != null)
                {
                    using (CadastroCliente frm = new CadastroCliente(juridica))
                    {
                        resultado = frm.ShowDialog(this.ParentForm);
                        entidade = frm.Pessoa;
                    }
                }
                else
                {
                    PessoaFísica fisica = PessoaFísica.ObterPessoa(pessoa.Código);

                    if (fisica != null)
                    {
                        using (CadastroCliente frm = new CadastroCliente(fisica))
                        {
                            resultado = frm.ShowDialog(this.ParentForm);
                            entidade = frm.Pessoa;
                        }
                    }
                    else
                    {
                        throw new Exception("A pessoa é do Tipo Entidades.Pessoa, porém não é física nem jurídica!");
                    }
                }
            }
            else
            {
                
                //MessageBox.Show("Olá. Ocorreu um erro que a equipe de desenvolvimento está tentando solucionar.\nVocê consegue reproduzir esse erro?\nPor favor, se for possivel, nos informe pelo sistema-imj@googlegroups.com como podemos reproduzir esse erro. Observando: \n-Qual cliente foi procurado ?
                throw new NotSupportedException("O tipo de pessoa \"" + pessoa.GetType().Name + "\" não é suportado. Código:" + pessoa.Código.ToString());
            }

			// Atualizar dados.
            if (resultado == DialogResult.OK)
            {
                AtualizarEntidade(entidade);
            }
            else if (resultado == DialogResult.Abort)
            {
                base.SubstituirBaseParaAnterior();
            }
		}

		/// <summary>
		/// Atualiza entidade no banco de dados e na base inferior.
		/// </summary>
		/// <param name="novaEntidade">Entidade a ser atualizada.</param>
		protected virtual void AtualizarEntidade(Entidades.Pessoa.Pessoa novaEntidade)
		{
            AguardeDB.Mostrar();
            UseWaitCursor = true;

			novaEntidade.Atualizar();
			Preparar(novaEntidade);

            UseWaitCursor = false;
            AguardeDB.Fechar();
		}

        ///// <summary>
        ///// Descobre pendências do cliente e exibe na ListView.
        ///// </summary>
        //private void DescobrirPendências()
        //{
        //    LinkedList<ClientePendência> pendências;

        //    lstPendências.UseWaitCursor = true;

        //    pendências = ClientePendência.ObterPendências(pessoa);

        //    MostrarPendências(pendências);

        //    lstPendências.UseWaitCursor = false;
        //}

        private void AoEncontrarVendasNãoQuitadas(Entidades.Pessoa.Pessoa cliente, Entidades.Relacionamento.Venda.Venda[] vendas, double dívida)
        {
            MostrarPendência(new ClientePendência(vendas.Length.ToString() + " Vendas", dívida.ToString("C"), true));
            ReajustarPendências();
        }

        /// <summary>
        /// Mostra as pendências existentes.
        /// </summary>
        private void MostrarPendências(LinkedList<ClientePendência> pendências)
        {
            lstPendências.Items.Clear();

            quadroPendências.Visible = pendências.Count > 0;

            foreach (ClientePendência pendência in pendências)
                MostrarPendência(pendência);

            ReajustarPendências();
        }

        private delegate void ReajustarPendênciasCallback();

        private void ReajustarPendências()
        {
            if (lstPendências.InvokeRequired)
            {
                ReajustarPendênciasCallback método = new ReajustarPendênciasCallback(ReajustarPendências);
                lstPendências.BeginInvoke(método);
            }
            else
            {
                lstPendências.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lstPendências.Columns[0].Width =
                    Math.Min(
                    lstPendências.Columns[0].Width,
                    lstPendências.ClientSize.Width - lstPendências.Columns[1].Width);
                lstPendências.Columns[1].Width =
                    lstPendências.ClientSize.Width - lstPendências.Columns[0].Width;
            }
        }

        private delegate void MostrarPendênciaCallback(ClientePendência pendência);

        private void MostrarPendência(ClientePendência pendência)
        {
            if (lstPendências.InvokeRequired)
            {
                MostrarPendênciaCallback método = new MostrarPendênciaCallback(MostrarPendência);
                lstPendências.BeginInvoke(método, pendência);
            }
            else
            {
                ListViewItem item;

                item = new ListViewItem(pendência.Item + ":");
                item.SubItems.Add(pendência.Descrição);

                if (pendência.Alertar)
                    item.Font = new Font(item.Font, FontStyle.Bold);

                lstPendências.Items.Add(item);

                item.EnsureVisible();

                switch (pendência.Identificação)
                {
                    case ClientePendência.Identificações.PedidoPronto:
                        sinalizaçãoPedido.Visible = true;
                        break;
                }
            }
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Cliente.
        /// </summary>
        [Browsable(false)]
        protected Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
        }

		#endregion

		#region Eventos da base inferior

        /// <summary>
        /// Ocorre ao exibir pela primeira vez.
        /// </summary>
        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            if (this.pessoa == null)
                throw new Exception("Pessoa nem visitante atribuído!");

            bgConsistência.RunWorkerAsync();
        }

        /// <summary>
        /// Ocorre ao exibir a base inferior.
        /// </summary>
        protected override void AoExibir()
        {
            base.AoExibir();

            //listaContaCorrente1.Carregar();
            DescobrirPendênciasSegundoPlano();


        }
		#endregion

        #region Eventos da interface gráfica para mudança de base inferior

        /// <summary>
        /// Ocorre ao escolher saída.
        /// </summary>
        private void opçãoSaída_Click(object sender, EventArgs e)
        {
            Apresentação.Financeiro.Saída.BaseSaídas baseSaídas = new Apresentação.Financeiro.Saída.BaseSaídas(pessoa);
            SubstituirBase(baseSaídas);
        }

        /// <summary>
        /// Ocorre ao escolher retorno.
        /// </summary>
        private void opçãoRetorno_Click(object sender, EventArgs e)
        {
            Apresentação.Financeiro.Retorno.BaseRetornos baseRetornos = new Apresentação.Financeiro.Retorno.BaseRetornos(pessoa);
            SubstituirBase(baseRetornos);
        }

        /// <summary>
        /// Ocorre ao escolher venda.
        /// </summary>
        private void opçãoConsignadoVenda_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Application.DoEvents();

            BaseEditarVenda baseVenda = new BaseEditarVenda();
            try
            {
                baseVenda.PrepararNovaVenda(pessoa);
                SubstituirBase(baseVenda);
            }
            catch (Exception err)
            {
                MessageBox.Show("Operação cancelada", "Operação cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                UseWaitCursor = false;
            }
            
        }

        /// <summary>
        /// Ocorre ao escolhear visualizar vendas.
        /// </summary>
        private void opçãoVendas_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Apresentação.Financeiro.Venda.BaseVendas baseVendas = new Apresentação.Financeiro.Venda.BaseVendas(pessoa);
            SubstituirBase(baseVendas);
            UseWaitCursor = false;
        }

        private void opçãoAcerto_Click(object sender, EventArgs e)
        {
            AcertoConsignado acerto = EscolherAcerto.QuestionarUsuário(ParentForm, pessoa, false);

            if (acerto != null)
            {
                UseWaitCursor = true;

                AguardeDB.Mostrar();

                try
                {
                    //Apresentação.Financeiro.Acerto.SeleçãoDocumentosBaseInferior baseAcerto = new Apresentação.Financeiro.Acerto.SeleçãoDocumentosBaseInferior();
                    BaseDadosAcerto baseAcerto = new BaseDadosAcerto();
                    baseAcerto.AcertoConsignado = acerto;
                    SubstituirBase(baseAcerto);
                }
                finally
                {
                    AguardeDB.Fechar();
                    UseWaitCursor = false;
                }
            }
        }

        private void opçãoComissão_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Apresentação.Financeiro.Comissão.BaseComissão baseComissão = new Apresentação.Financeiro.Comissão.BaseComissão();
            baseComissão.Carregar(pessoa);
            SubstituirBase(baseComissão);
            UseWaitCursor = false;
        }

        private void opçãoPagamentos_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();
            Apresentação.Financeiro.Pagamento.BasePagamentos basePagamentos = new Apresentação.Financeiro.Pagamento.BasePagamentos();
            basePagamentos.Abrir(pessoa);
            SubstituirBase(basePagamentos);
            AguardeDB.Fechar();
            UseWaitCursor = false;
        }

        #endregion

        /// <summary>
        /// Descobre as pendências em segundo plano.
        /// </summary>
        private void DescobrirPendênciasSegundoPlano()
        {
            if (!bgDescobrirPendência.IsBusy)
            {
                SinalizaçãoCarga.Sinalizar(this, "Verificando", "O sistema está procurando pendências...");
                bgDescobrirPendência.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Recupera as pendências em segundo plano, por meio
        /// do componente bgDescobrirPendência.
        /// </summary>
        private void RecuperarPendências(object sender, DoWorkEventArgs e)
        {
            e.Result = ClientePendência.ObterPendências(pessoa);
        }

        /// <summary>
        /// Mostra as pendências como resultado da execução assíncrona
        /// do componente bgDescobrirPendência.
        /// </summary>
        private void MostrarPendências(object sender, RunWorkerCompletedEventArgs e)
        {
            LinkedList<ClientePendência> pendências = (LinkedList<ClientePendência>)e.Result;

            MostrarPendências(pendências);
            SinalizaçãoCarga.Dessinalizar(this);

            //SinalizaçãoCarga.Sinalizar(this, "Calculando dívida", "O sistema está verificando e calculando dívida...");

            //VerificaçãoQuitação verificação = new VerificaçãoQuitação(pessoa);
            //verificação.AoEncontrarVendasNãoQuitadas += new VerificaçãoQuitação.VerificaçãoCallback(AoEncontrarVendasNãoQuitadas);
            //verificação.AoEncontrarPagamentosPendentes += new VerificaçãoQuitação.VerificaçãoPagamentosCallback(verificação_AoEncontrarPagamentosPendentes);
            //verificação.AoTerminarVerificação += new EventHandler(verificação_AoTerminar);
            //verificação.IniciarTrabalho();
        }

        void verificação_AoEncontrarPagamentosPendentes(Entidades.Pessoa.Pessoa cliente, Entidades.Pagamentos.Pagamento[] pagamentosPendentes)
        {
            double valorPendente = 0;

            foreach (Entidades.Pagamentos.Pagamento p in pagamentosPendentes)
                valorPendente += p.Valor;

            MostrarPendência(new ClientePendência(pagamentosPendentes.Length.ToString() + " Pagamentos", valorPendente.ToString("C"), true));
            ReajustarPendências();
        }

        void verificação_AoTerminar(object sender, EventArgs e)
        {
            SinalizaçãoCarga.Dessinalizar(this);
        }

        private void bgConsistência_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (AcertoConsignado.AgruparDocumentosNãoAcertados(pessoa) != null)
                {
                    MessageBox.Show(
                        "Existiam documentos desvinculados de acerto em nome de " + pessoa.Nome + ". Os documentos foram agrupados em um acerto novo.",
                        "Indústria Mineira de Jóias",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Ocorreu um erro verificando documentos desvinculados de acerto de " + pessoa.Nome + ":\n\n" + erro.Message,
                    "Indústria Mineira de Jóias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
            }
        }

        /// <summary>
        /// Oculta dados para que a privacidade seja mantida
        /// na frente do cliente.
        /// </summary>
        private void opçãoOcultar_Click(object sender, EventArgs e)
        {
            Controlador.ModoAtendimento = true;
            AdequarModoAtendimento();
        }

        private void opçãoEncerrarAtendimento_Click(object sender, EventArgs e)
        {
            if (Login.ExigirIdentificação(ParentForm, "Encerrar modo de atendimento",
                "Confirme sua senha para liberar a visualização de dados e encerrar o modo de atendimento."))
            {
                Controlador.ModoAtendimento = false;
                AdequarModoAtendimento();
            }
        }

        private void opçãoPedido_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                SubstituirBase(new BasePedidos(pessoa));
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void opçãoMalaDireta_Click(object sender, EventArgs e)
        {
            JanelaEtiquetaSedex janela = JanelaEtiquetaSedex.Instancia;
            janela.Adicionar(Pessoa);

            janela.Hide();
            janela.ShowDialog(this);
        }

        private void opçãoFinanceiro_Click(object sender, EventArgs e)
        {
            Apresentação.Financeiro.Controle.BaseControleFinanceiroPessoal n = new Apresentação.Financeiro.Controle.BaseControleFinanceiroPessoal(Pessoa);
            SubstituirBase(n);
        }

        private void opçãoCréditos_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();
            Apresentação.Financeiro.Crédito.BaseCréditos baseCréditos = new Apresentação.Financeiro.Crédito.BaseCréditos();
            baseCréditos.Pessoa = pessoa;
            SubstituirBase(baseCréditos);
            AguardeDB.Fechar();
            UseWaitCursor = false;
        }
    }
}
