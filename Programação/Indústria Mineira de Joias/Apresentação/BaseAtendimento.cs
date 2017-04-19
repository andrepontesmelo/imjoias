using Acesso.Comum.Exceções;
using Apresentação.Atendente;
using Apresentação.Atendimento.Clientes;
using Apresentação.Atendimento.Clientes.Pedido;
using Apresentação.Atendimento.Comum;
using Apresentação.Financeiro.Acerto;
using Apresentação.Financeiro.Venda;
using Apresentação.Formulários;
using Apresentação.Mercadoria;
using Apresentação.Pessoa.Cadastro;
using Entidades;
using Entidades.Acerto;
using Entidades.Coaf;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Atendimento
{
    public class BaseAtendimento : Apresentação.Formulários.BaseInferior
	{
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
        private Opção opçãoPagamentos;
        private TableLayoutPanel tableLayoutPanel1;
        private Quadro quadroClassificador;
        private Classificador classificador;
        private BackgroundWorker bgDescobrirPendência;
        private Opção opçãoRetorno;
        private Opção opçãoOcultar;
        private Quadro quadroModoAtendimento;
        private Opção opçãoEncerrarAtendimento;
        private Quadro quadro1;
        private Opção opçãoPedido;
        private Opção opçãoMalaDireta;
        private Quadro quadroObs;
        private TextBox txtObs;
        private SinalizaçãoPedido sinalizaçãoPedido;
        private SinalizaçãoMercadoriaEmFalta sinalizaçãoMercadoriaEmFalta;
        private Opção opçãoCréditos;
        private SumárioAcerto sumárioAcerto1;
        private Opção opçãoCompras;
        private Opção opçãoHistóricoAtendimentos;
        private Label lblPEP;
        private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a base de atendimento.
		/// </summary>
		public BaseAtendimento()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            título.ÍconeArredondado = true;
            colItem.Width = lstPendências.ClientSize.Width - colDescrição.Width;
        }

        private bool modoAtendimento;
        private bool ModoAtendimento
        {
            get {
                if (Controlador != null)
                    return Controlador.ModoAtendimento;
                else
                    return modoAtendimento;
            }

            set
            {
                if (Controlador != null)
                    Controlador.ModoAtendimento = value;
                else
                    modoAtendimento = value;
            }
        }

		/// <summary>
		/// Constrói a base inferior, fornecendo os dados do cliente.
		/// </summary>
		/// <param name="cliente">Entidade do cliente.</param>
		public BaseAtendimento(Entidades.Pessoa.Pessoa cliente) : base()
		{
            InitializeComponent();
			Carregar(cliente);
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
            get 
            {
                if (base.Controlador is Atendente.ControladorAtendimentoGenérico)
                    return (Atendente.ControladorAtendimentoGenérico)base.Controlador;
                else
                    return null;
            }
        }

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroCliente = new Apresentação.Formulários.Quadro();
            this.opçãoHistóricoAtendimentos = new Apresentação.Formulários.Opção();
            this.opçãoOcultar = new Apresentação.Formulários.Opção();
            this.opçãoAbrir = new Apresentação.Formulários.Opção();
            this.opçãoOutro = new Apresentação.Formulários.Opção();
            this.opçãoVendas = new Apresentação.Formulários.Opção();
            this.quadroRelacionar = new Apresentação.Formulários.Quadro();
            this.opçãoSaída = new Apresentação.Formulários.Opção();
            this.opçãoRetorno = new Apresentação.Formulários.Opção();
            this.opçãoAcerto = new Apresentação.Formulários.Opção();
            this.opçãoConsignadoVenda = new Apresentação.Formulários.Opção();
            this.quadroPendências = new Apresentação.Formulários.Quadro();
            this.lstPendências = new System.Windows.Forms.ListView();
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quadroVendas = new Apresentação.Formulários.Quadro();
            this.opçãoCompras = new Apresentação.Formulários.Opção();
            this.opçãoCréditos = new Apresentação.Formulários.Opção();
            this.opçãoPagamentos = new Apresentação.Formulários.Opção();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quadroClassificador = new Apresentação.Formulários.Quadro();
            this.classificador = new Apresentação.Pessoa.Cadastro.Classificador();
            this.quadroObs = new Apresentação.Formulários.Quadro();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.sinalizaçãoPedido = new Apresentação.Atendimento.SinalizaçãoPedido();
            this.sinalizaçãoMercadoriaEmFalta = new Apresentação.Mercadoria.SinalizaçãoMercadoriaEmFalta();
            this.sumárioAcerto1 = new Apresentação.Financeiro.Acerto.SumárioAcerto();
            this.bgDescobrirPendência = new System.ComponentModel.BackgroundWorker();
            this.quadroModoAtendimento = new Apresentação.Formulários.Quadro();
            this.opçãoEncerrarAtendimento = new Apresentação.Formulários.Opção();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoPedido = new Apresentação.Formulários.Opção();
            this.opçãoMalaDireta = new Apresentação.Formulários.Opção();
            this.lblPEP = new System.Windows.Forms.Label();
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
            this.título.BackColor = System.Drawing.Color.Transparent;
            this.título.Descrição = "Descrição";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = null;
            this.título.Location = new System.Drawing.Point(200, 12);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(893, 70);
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
            this.quadroCliente.Controls.Add(this.opçãoHistóricoAtendimentos);
            this.quadroCliente.Controls.Add(this.opçãoOcultar);
            this.quadroCliente.Controls.Add(this.opçãoAbrir);
            this.quadroCliente.Controls.Add(this.opçãoOutro);
            this.quadroCliente.Cor = System.Drawing.Color.Black;
            this.quadroCliente.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroCliente.LetraTítulo = System.Drawing.Color.White;
            this.quadroCliente.Location = new System.Drawing.Point(7, 13);
            this.quadroCliente.MostrarBotãoMinMax = false;
            this.quadroCliente.Name = "quadroCliente";
            this.quadroCliente.Size = new System.Drawing.Size(160, 75);
            this.quadroCliente.TabIndex = 0;
            this.quadroCliente.Tamanho = 30;
            this.quadroCliente.Título = "Relacionamento";
            // 
            // opçãoHistóricoAtendimentos
            // 
            this.opçãoHistóricoAtendimentos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoHistóricoAtendimentos.Descrição = "Atendimentos";
            this.opçãoHistóricoAtendimentos.Imagem = global::Apresentação.Resource.Pedido1;
            this.opçãoHistóricoAtendimentos.Location = new System.Drawing.Point(7, 50);
            this.opçãoHistóricoAtendimentos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoHistóricoAtendimentos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoHistóricoAtendimentos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoHistóricoAtendimentos.Name = "opçãoHistóricoAtendimentos";
            this.opçãoHistóricoAtendimentos.Size = new System.Drawing.Size(150, 16);
            this.opçãoHistóricoAtendimentos.TabIndex = 5;
            this.opçãoHistóricoAtendimentos.Click += new System.EventHandler(this.opçãoHistóricoAtendimentos_Click);
            // 
            // opçãoOcultar
            // 
            this.opçãoOcultar.AutoSize = true;
            this.opçãoOcultar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoOcultar.Descrição = "";
            this.opçãoOcultar.Imagem = global::Apresentação.Resource.sunglasses_transp1;
            this.opçãoOcultar.Location = new System.Drawing.Point(130, 30);
            this.opçãoOcultar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoOcultar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoOcultar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoOcultar.Name = "opçãoOcultar";
            this.opçãoOcultar.Size = new System.Drawing.Size(150, 19);
            this.opçãoOcultar.TabIndex = 4;
            this.opçãoOcultar.Click += new System.EventHandler(this.opçãoOcultar_Click);
            // 
            // opçãoAbrir
            // 
            this.opçãoAbrir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrir.Descrição = "Ficha";
            this.opçãoAbrir.Imagem = global::Apresentação.Resource.folderopen1;
            this.opçãoAbrir.Location = new System.Drawing.Point(7, 30);
            this.opçãoAbrir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoAbrir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.Name = "opçãoAbrir";
            this.opçãoAbrir.Privilégio = Entidades.Privilégio.Permissão.CadastroAcesso;
            this.opçãoAbrir.Size = new System.Drawing.Size(150, 16);
            this.opçãoAbrir.TabIndex = 2;
            this.opçãoAbrir.Click += new System.EventHandler(this.opçãoAbrir_Click);
            // 
            // opçãoOutro
            // 
            this.opçãoOutro.BackColor = System.Drawing.Color.Transparent;
            this.opçãoOutro.Descrição = "Escolher outra pessoa";
            this.opçãoOutro.Imagem = global::Apresentação.Resource.delete;
            this.opçãoOutro.Location = new System.Drawing.Point(3, 81);
            this.opçãoOutro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoOutro.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoOutro.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoOutro.Name = "opçãoOutro";
            this.opçãoOutro.Size = new System.Drawing.Size(150, 24);
            this.opçãoOutro.TabIndex = 3;
            this.opçãoOutro.Visible = false;
            this.opçãoOutro.Click += new System.EventHandler(this.opçãoOutro_Click);
            // 
            // opçãoVendas
            // 
            this.opçãoVendas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoVendas.Descrição = "Visualizar vendas";
            this.opçãoVendas.Imagem = global::Apresentação.Resource.folderopen1;
            this.opçãoVendas.Location = new System.Drawing.Point(7, 30);
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
            this.quadroRelacionar.Location = new System.Drawing.Point(7, 94);
            this.quadroRelacionar.MostrarBotãoMinMax = false;
            this.quadroRelacionar.Name = "quadroRelacionar";
            this.quadroRelacionar.Privilégio = Entidades.Privilégio.Permissão.Consignado;
            this.quadroRelacionar.Size = new System.Drawing.Size(160, 96);
            this.quadroRelacionar.TabIndex = 2;
            this.quadroRelacionar.Tamanho = 30;
            this.quadroRelacionar.Título = "Consignado";
            // 
            // opçãoSaída
            // 
            this.opçãoSaída.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSaída.Descrição = "Saídas";
            this.opçãoSaída.Imagem = global::Apresentação.Resource.Saída__Pequeno_1;
            this.opçãoSaída.Location = new System.Drawing.Point(7, 30);
            this.opçãoSaída.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.opçãoSaída.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSaída.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSaída.Name = "opçãoSaída";
            this.opçãoSaída.Privilégio = Entidades.Privilégio.Permissão.ConsignadoSaída;
            this.opçãoSaída.Size = new System.Drawing.Size(150, 16);
            this.opçãoSaída.TabIndex = 2;
            this.opçãoSaída.Click += new System.EventHandler(this.opçãoSaída_Click);
            // 
            // opçãoRetorno
            // 
            this.opçãoRetorno.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRetorno.Descrição = "Retornos";
            this.opçãoRetorno.Imagem = global::Apresentação.Resource.Retorno__Ícone_;
            this.opçãoRetorno.Location = new System.Drawing.Point(7, 50);
            this.opçãoRetorno.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoRetorno.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRetorno.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRetorno.Name = "opçãoRetorno";
            this.opçãoRetorno.Privilégio = Entidades.Privilégio.Permissão.ConsignadoRetorno;
            this.opçãoRetorno.Size = new System.Drawing.Size(150, 16);
            this.opçãoRetorno.TabIndex = 4;
            this.opçãoRetorno.Click += new System.EventHandler(this.opçãoRetorno_Click);
            // 
            // opçãoAcerto
            // 
            this.opçãoAcerto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAcerto.Descrição = "Acerto de mercadorias";
            this.opçãoAcerto.Imagem = global::Apresentação.Resource.Acerto__Pequeno_;
            this.opçãoAcerto.Location = new System.Drawing.Point(6, 76);
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
            this.opçãoConsignadoVenda.Imagem = global::Apresentação.Resource.NewCardHS;
            this.opçãoConsignadoVenda.Location = new System.Drawing.Point(7, 70);
            this.opçãoConsignadoVenda.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoConsignadoVenda.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoConsignadoVenda.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoConsignadoVenda.Name = "opçãoConsignadoVenda";
            this.opçãoConsignadoVenda.Privilégio = Entidades.Privilégio.Permissão.VendasEditar;
            this.opçãoConsignadoVenda.Size = new System.Drawing.Size(150, 17);
            this.opçãoConsignadoVenda.TabIndex = 5;
            this.opçãoConsignadoVenda.Click += new System.EventHandler(this.opçãoConsignadoVenda_Click);
            // 
            // quadroPendências
            // 
            this.quadroPendências.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
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
            this.quadroPendências.Size = new System.Drawing.Size(194, 194);
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
            this.lstPendências.Scrollable = false;
            this.lstPendências.Size = new System.Drawing.Size(188, 161);
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
            this.quadroVendas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quadroVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVendas.bInfDirArredondada = true;
            this.quadroVendas.bInfEsqArredondada = true;
            this.quadroVendas.bSupDirArredondada = true;
            this.quadroVendas.bSupEsqArredondada = true;
            this.quadroVendas.Controls.Add(this.opçãoCompras);
            this.quadroVendas.Controls.Add(this.opçãoVendas);
            this.quadroVendas.Controls.Add(this.opçãoCréditos);
            this.quadroVendas.Controls.Add(this.opçãoPagamentos);
            this.quadroVendas.Controls.Add(this.opçãoConsignadoVenda);
            this.quadroVendas.Cor = System.Drawing.Color.Black;
            this.quadroVendas.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendas.LetraTítulo = System.Drawing.Color.White;
            this.quadroVendas.Location = new System.Drawing.Point(7, 196);
            this.quadroVendas.MostrarBotãoMinMax = false;
            this.quadroVendas.Name = "quadroVendas";
            this.quadroVendas.Privilégio = Entidades.Privilégio.Permissão.Vendas;
            this.quadroVendas.Size = new System.Drawing.Size(160, 133);
            this.quadroVendas.TabIndex = 3;
            this.quadroVendas.Tamanho = 30;
            this.quadroVendas.Título = "Financeiro";
            // 
            // opçãoCompras
            // 
            this.opçãoCompras.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCompras.Descrição = "Visualizar compras";
            this.opçãoCompras.Imagem = global::Apresentação.Resource.folderopen1;
            this.opçãoCompras.Location = new System.Drawing.Point(7, 50);
            this.opçãoCompras.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCompras.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCompras.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCompras.Name = "opçãoCompras";
            this.opçãoCompras.PermitirLiberaçãoRecurso = true;
            this.opçãoCompras.Size = new System.Drawing.Size(150, 16);
            this.opçãoCompras.TabIndex = 9;
            this.opçãoCompras.Click += new System.EventHandler(this.opçãoComprasDesteFuncionário_Click);
            // 
            // opçãoCréditos
            // 
            this.opçãoCréditos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCréditos.Descrição = "Créditos";
            this.opçãoCréditos.Imagem = global::Apresentação.Resource.credito;
            this.opçãoCréditos.Location = new System.Drawing.Point(7, 110);
            this.opçãoCréditos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoCréditos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCréditos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCréditos.Name = "opçãoCréditos";
            this.opçãoCréditos.Size = new System.Drawing.Size(150, 23);
            this.opçãoCréditos.TabIndex = 8;
            this.opçãoCréditos.Click += new System.EventHandler(this.opçãoCréditos_Click);
            // 
            // opçãoPagamentos
            // 
            this.opçãoPagamentos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoPagamentos.Descrição = "Pagamentos";
            this.opçãoPagamentos.Imagem = global::Apresentação.Resource.pagamento1;
            this.opçãoPagamentos.Location = new System.Drawing.Point(7, 90);
            this.opçãoPagamentos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoPagamentos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoPagamentos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoPagamentos.Name = "opçãoPagamentos";
            this.opçãoPagamentos.Size = new System.Drawing.Size(150, 16);
            this.opçãoPagamentos.TabIndex = 7;
            this.opçãoPagamentos.Click += new System.EventHandler(this.opçãoPagamentos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.quadroClassificador, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadroPendências, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.quadroObs, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.sinalizaçãoPedido, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.sinalizaçãoMercadoriaEmFalta, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.sumárioAcerto1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(184, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 399);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Resize += new System.EventHandler(this.tableLayoutPanel1_Resize);
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
            this.quadroClassificador.Location = new System.Drawing.Point(3, 203);
            this.quadroClassificador.MostrarBotãoMinMax = false;
            this.quadroClassificador.Name = "quadroClassificador";
            this.quadroClassificador.Privilégio = Entidades.Privilégio.Permissão.CadastroAcesso;
            this.quadroClassificador.Size = new System.Drawing.Size(194, 93);
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
            this.classificador.Size = new System.Drawing.Size(188, 65);
            this.classificador.TabIndex = 10;
            // 
            // quadroObs
            // 
            this.quadroObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.quadroObs.bInfDirArredondada = false;
            this.quadroObs.bInfEsqArredondada = false;
            this.quadroObs.bSupDirArredondada = true;
            this.quadroObs.bSupEsqArredondada = true;
            this.quadroObs.Controls.Add(this.txtObs);
            this.quadroObs.Cor = System.Drawing.Color.Black;
            this.quadroObs.FundoTítulo = System.Drawing.Color.Olive;
            this.quadroObs.LetraTítulo = System.Drawing.Color.White;
            this.quadroObs.Location = new System.Drawing.Point(373, 3);
            this.quadroObs.MostrarBotãoMinMax = false;
            this.quadroObs.Name = "quadroObs";
            this.tableLayoutPanel1.SetRowSpan(this.quadroObs, 2);
            this.quadroObs.Size = new System.Drawing.Size(539, 293);
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
            this.txtObs.Location = new System.Drawing.Point(2, 27);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ReadOnly = true;
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObs.Size = new System.Drawing.Size(534, 263);
            this.txtObs.TabIndex = 2;
            this.txtObs.Text = "As observações só serão exibidas caso exista alguma.";
            // 
            // sinalizaçãoPedido
            // 
            this.sinalizaçãoPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sinalizaçãoPedido.Borda = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.sinalizaçãoPedido, 3);
            this.sinalizaçãoPedido.Cor1 = System.Drawing.Color.LightYellow;
            this.sinalizaçãoPedido.Cor2 = System.Drawing.Color.Ivory;
            this.sinalizaçãoPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sinalizaçãoPedido.Location = new System.Drawing.Point(3, 302);
            this.sinalizaçãoPedido.MinimumSize = new System.Drawing.Size(100, 32);
            this.sinalizaçãoPedido.Name = "sinalizaçãoPedido";
            this.sinalizaçãoPedido.Size = new System.Drawing.Size(909, 44);
            this.sinalizaçãoPedido.TabIndex = 12;
            this.sinalizaçãoPedido.Click += new System.EventHandler(this.opçãoPedido_Click);
            // 
            // sinalizaçãoMercadoriaEmFalta
            // 
            this.sinalizaçãoMercadoriaEmFalta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sinalizaçãoMercadoriaEmFalta.Borda = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.sinalizaçãoMercadoriaEmFalta, 3);
            this.sinalizaçãoMercadoriaEmFalta.Cor1 = System.Drawing.Color.LightYellow;
            this.sinalizaçãoMercadoriaEmFalta.Cor2 = System.Drawing.Color.Ivory;
            this.sinalizaçãoMercadoriaEmFalta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sinalizaçãoMercadoriaEmFalta.Location = new System.Drawing.Point(3, 352);
            this.sinalizaçãoMercadoriaEmFalta.MinimumSize = new System.Drawing.Size(100, 32);
            this.sinalizaçãoMercadoriaEmFalta.Name = "sinalizaçãoMercadoriaEmFalta";
            this.sinalizaçãoMercadoriaEmFalta.Size = new System.Drawing.Size(909, 44);
            this.sinalizaçãoMercadoriaEmFalta.TabIndex = 13;
            this.sinalizaçãoMercadoriaEmFalta.Click += new System.EventHandler(this.sinalizaçãoMercadoriaEmFalta_Click);
            // 
            // sumárioAcerto1
            // 
            this.sumárioAcerto1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sumárioAcerto1.BackColor = System.Drawing.Color.White;
            this.sumárioAcerto1.bInfDirArredondada = false;
            this.sumárioAcerto1.bInfEsqArredondada = false;
            this.sumárioAcerto1.bSupDirArredondada = true;
            this.sumárioAcerto1.bSupEsqArredondada = true;
            this.sumárioAcerto1.Cor = System.Drawing.Color.Black;
            this.sumárioAcerto1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.sumárioAcerto1.LetraTítulo = System.Drawing.Color.White;
            this.sumárioAcerto1.Location = new System.Drawing.Point(203, 3);
            this.sumárioAcerto1.MostrarBotãoMinMax = false;
            this.sumárioAcerto1.Name = "sumárioAcerto1";
            this.tableLayoutPanel1.SetRowSpan(this.sumárioAcerto1, 2);
            this.sumárioAcerto1.Size = new System.Drawing.Size(164, 293);
            this.sumárioAcerto1.TabIndex = 18;
            this.sumárioAcerto1.Tamanho = 30;
            this.sumárioAcerto1.Título = "Sumário";
            // 
            // bgDescobrirPendência
            // 
            this.bgDescobrirPendência.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RecuperarPendências);
            this.bgDescobrirPendência.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MostrarPendências);
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
            this.quadroModoAtendimento.Location = new System.Drawing.Point(7, 423);
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
            this.opçãoEncerrarAtendimento.Imagem = global::Apresentação.Resource.turnkey1;
            this.opçãoEncerrarAtendimento.Location = new System.Drawing.Point(7, 30);
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
            this.quadro1.Location = new System.Drawing.Point(7, 338);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 79);
            this.quadro1.TabIndex = 5;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Serviços";
            // 
            // opçãoPedido
            // 
            this.opçãoPedido.BackColor = System.Drawing.Color.Transparent;
            this.opçãoPedido.Descrição = "Pedidos e consertos";
            this.opçãoPedido.Imagem = global::Apresentação.Resource.Pedido1;
            this.opçãoPedido.Location = new System.Drawing.Point(7, 30);
            this.opçãoPedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoPedido.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoPedido.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoPedido.Name = "opçãoPedido";
            this.opçãoPedido.Size = new System.Drawing.Size(150, 20);
            this.opçãoPedido.TabIndex = 2;
            this.opçãoPedido.Click += new System.EventHandler(this.opçãoPedido_Click);
            // 
            // opçãoMalaDireta
            // 
            this.opçãoMalaDireta.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMalaDireta.Descrição = "Imprimir mala-direta";
            this.opçãoMalaDireta.Imagem = global::Apresentação.Resource.LABELS1;
            this.opçãoMalaDireta.Location = new System.Drawing.Point(7, 50);
            this.opçãoMalaDireta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMalaDireta.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMalaDireta.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMalaDireta.Name = "opçãoMalaDireta";
            this.opçãoMalaDireta.Size = new System.Drawing.Size(150, 19);
            this.opçãoMalaDireta.TabIndex = 3;
            this.opçãoMalaDireta.Click += new System.EventHandler(this.opçãoMalaDireta_Click);
            // 
            // lblPEP
            // 
            this.lblPEP.BackColor = System.Drawing.Color.Transparent;
            this.lblPEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPEP.ForeColor = System.Drawing.Color.Gray;
            this.lblPEP.Location = new System.Drawing.Point(268, 0);
            this.lblPEP.Name = "lblPEP";
            this.lblPEP.Size = new System.Drawing.Size(831, 14);
            this.lblPEP.TabIndex = 10;
            this.lblPEP.Text = "PEP";
            // 
            // BaseAtendimento
            // 
            this.Controls.Add(this.lblPEP);
            this.Controls.Add(this.título);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BaseAtendimento";
            this.Size = new System.Drawing.Size(1099, 510);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.lblPEP, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroCliente.ResumeLayout(false);
            this.quadroCliente.PerformLayout();
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
        public void Carregar(Entidades.Pessoa.Pessoa cliente)
        {
            this.pessoa = cliente;
            classificador.Pessoa = pessoa;

            sinalizaçãoPedido.Visible = false;
            sinalizaçãoMercadoriaEmFalta.Visible = false;

            AdequarModoAtendimento();

            CarregarControlesVisuais(cliente);
            VerificarPessoaSemSetor(cliente);

            sumárioAcerto1.Carregar(cliente);
        }

        private void CarregarControlesVisuais(Entidades.Pessoa.Pessoa cliente)
        {
            título.Título = ObterTítulo();
            lblPEP.Text = ObterTextoPep();
            txtObs.Text = pessoa.Observações;
            título.Descrição = ObterDescrição(cliente);
            título.Imagem = ControladorÍconePessoa.ObterÍconeComFundoECódigo(pessoa);

            opçãoVendas.Enabled = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.Faturamento)
                || !Entidades.Pessoa.Funcionário.ÉFuncionárioOuRepresentante(pessoa)
                || pessoa.Código == Funcionário.FuncionárioAtual.Código;

            if (Entidades.Pessoa.Pessoa.ÉCliente(cliente))
            {
                opçãoVendas.Descrição = "Visualizar compras";
                opçãoCompras.Visible = false;
            } else
            {
                opçãoVendas.Descrição = "Visualizar vendas";
                opçãoCompras.Visible = true;
            }

        }

        private string ObterTextoPep()
        {
            PessoaExpostaPoliticamente pep = pessoa.PessoaExpostaPoliticamente;

            return (pep == null ? "" : pep.Descrição);
        }

        private void VerificarPessoaSemSetor(Entidades.Pessoa.Pessoa cliente)
        {
            if (cliente.Setor == null)
            {
                AguardeDB.Fechar();

                MessageBox.Show(ParentForm,
                    "Favor definir definir o setor na ficha de " + pessoa.Nome,
                    "Pessoa sem setor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string ObterTítulo()
        {
            string títuloStr = pessoa.Nome.Replace("&", "&&");

            if ((pessoa is PessoaJurídica) && (((PessoaJurídica)pessoa).Fantasia != null))
                títuloStr += " - " + ((PessoaJurídica)pessoa).Fantasia;

            return títuloStr;
        }

        private string ObterDescrição(Entidades.Pessoa.Pessoa cliente)
        {
            StringBuilder descrição = new StringBuilder();

            if (cliente.Região != null)
                descrição.Append(cliente.Região.Nome.Trim()).Append(" - ");

            List<Entidades.Pessoa.Endereço.Endereço> endereços = cliente.Endereços.ExtrairElementos();

            string strTelefones = ObterTelefones(pessoa);
            if (!String.IsNullOrWhiteSpace(strTelefones))
                descrição.Append(" ").Append(strTelefones);

            if (endereços.Count > 0 && endereços[0].Localidade != null)
                descrição.Append(" ").Append(endereços[0].Localidade.Nome + " / " + endereços[0].Localidade.Estado.Sigla);

            return descrição.ToString();
        }

        private string ObterTelefones(Entidades.Pessoa.Pessoa pessoa)
        {
            StringBuilder strTelefones = new StringBuilder();

            foreach (Telefone telefone in pessoa.Telefones)
            {
                if (strTelefones.Length > 0)
                    strTelefones.Append("; ");

                strTelefones.Append(telefone.Número);
            }

            return strTelefones.ToString();
        }

        private void AdequarModoAtendimento()
        {
            quadroModoAtendimento.Visible = ModoAtendimento;
            quadroCliente.Visible = !ModoAtendimento;
            quadroObs.Visible = !ModoAtendimento;
            quadroClassificador.Visible = !ModoAtendimento;
        }


		/// <summary>
		/// Ocorre ao clicar em "Escolher outro cliente".
		/// </summary>
		private void opçãoOutro_Click(object sender, System.EventArgs e)
		{
			SubstituirBaseParaAnterior();
		}

		private void opçãoAbrir_Click(object sender, System.EventArgs e)
        {
            Entidades.Pessoa.Pessoa pessoaAtualizada;

            var resultado = CadastroPessoa.Abrir(pessoa, this.ParentForm, out pessoaAtualizada);

            if (resultado == DialogResult.OK)
                Carregar(pessoaAtualizada);
            if (resultado == DialogResult.Abort)
                SubstituirBaseParaAnterior();
        }

        /// <summary>
        /// Descobre pendências do cliente e exibe na ListView.
        /// </summary>
        private void DescobrirPendências()
        {
            lstPendências.UseWaitCursor = true;
            MostrarPendências(ClientePendência.ObterPendências(pessoa));
            lstPendências.UseWaitCursor = false;
        }

        private void ReajustarPendências()
        {
            lstPendências.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstPendências.Columns[0].Width =
                Math.Min(
                lstPendências.Columns[0].Width,
                lstPendências.ClientSize.Width - lstPendências.Columns[1].Width);
            lstPendências.Columns[1].Width =
                lstPendências.ClientSize.Width - lstPendências.Columns[0].Width;
        }

        private delegate void MostrarPendênciasCallback(LinkedList<ClientePendência> pendências);

        private void MostrarPendências(LinkedList<ClientePendência> pendências)
        {
            if (lstPendências.InvokeRequired)
            {
                MostrarPendênciasCallback método = new MostrarPendênciasCallback(MostrarPendências);
                lstPendências.BeginInvoke(método, pendências);
            }
            else
            {
                lstPendências.Items.Clear();

                foreach (var pendência in pendências)
                    AdicionarPendência(pendência);

                ReajustarPendências();
            }
        }

        private void AdicionarPendência(ClientePendência pendência)
        {
            bool adicionarPendênciaLista = true;
            var item = new ListViewItem(pendência.Item);
            item.SubItems.Add(pendência.Descrição);

            if (pendência.Alertar)
                item.Font = new Font(item.Font, FontStyle.Bold);


            switch (pendência.Identificação)
            {
                case ClientePendência.Identificações.PedidoPronto:
                    sinalizaçãoPedido.Visible = true;
                    break;
                case ClientePendência.Identificações.MercadoriaEmFalta:
                    adicionarPendênciaLista = false;
                    sinalizaçãoMercadoriaEmFalta.Visible = true;
                    break;
            }

            if (adicionarPendênciaLista)
                lstPendências.Items.Add(item);
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
        }

        /// <summary>
        /// Ocorre ao exibir a base inferior.
        /// </summary>
        protected override void AoExibir()
        {
            base.AoExibir();

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
            catch (OperaçãoCancelada)
            {
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
            Entidades.Pessoa.Pessoa pessoaUtilizar;

            if (pessoa.Setor == Setor.ObterSetor(SetorSistema.Varejo))
            {
                pessoaUtilizar = Entidades.Pessoa.Pessoa.Varejo;
            }
            else
                pessoaUtilizar = pessoa;

            AcertoConsignado acerto = JanelaEscolhaAcerto.QuestionarUsuário(ParentForm, pessoaUtilizar, false);

            if (acerto != null)
            {
                UseWaitCursor = true;

                AguardeDB.Mostrar();

                try
                {
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
                bgDescobrirPendência.RunWorkerAsync();
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
        }

        /// <summary>
        /// Oculta dados para que a privacidade seja mantida
        /// na frente do cliente.
        /// </summary>
        private void opçãoOcultar_Click(object sender, EventArgs e)
        {
            ModoAtendimento = true;
            AdequarModoAtendimento();
        }

        private void opçãoEncerrarAtendimento_Click(object sender, EventArgs e)
        {
            if (Login.ExigirIdentificação(ParentForm, "Encerrar modo de atendimento",
                "Confirme sua senha para liberar a visualização de dados e encerrar o modo de atendimento."))
            {
                ModoAtendimento = false;
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

        private void sinalizaçãoMercadoriaEmFalta_Click(object sender, EventArgs e)
        {
            JanelaMercadoriaEmFalta janela = new JanelaMercadoriaEmFalta();
            janela.Carregar(pessoa, this);
        }

        private void opçãoMalaDireta_Click(object sender, EventArgs e)
        {
            JanelaEtiquetaSedex janela = JanelaEtiquetaSedex.Instancia;
            janela.Adicionar(Pessoa);

            janela.Hide();
            janela.ShowDialog(this);
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

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            quadroObs.Width = tableLayoutPanel1.Width - quadroPendências.Width - 20;
            quadroObs.Height = tableLayoutPanel1.Height;
        }

        private void opçãoComprasDesteFuncionário_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Apresentação.Financeiro.Venda.BaseVendas baseVendas = new Apresentação.Financeiro.Venda.BaseVendas(pessoa, true);
            SubstituirBase(baseVendas);
            UseWaitCursor = false;
        }

        private void opçãoHistóricoAtendimentos_Click(object sender, EventArgs e)
        {
            BaseInfoAtendimentosCliente novaBase = new BaseInfoAtendimentosCliente(Pessoa);
            SubstituirBase(novaBase);
        }
    }
}
