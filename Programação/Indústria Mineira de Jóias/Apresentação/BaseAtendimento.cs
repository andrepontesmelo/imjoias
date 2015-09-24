using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;

using Apresenta��o.Formul�rios;
using Apresenta��o.Pessoa.Cadastro;

using Entidades;
using Entidades.Pessoa;

using Apresenta��o.Financeiro.Venda;
using System.Threading;
using Apresenta��o.Financeiro.Acerto;
using Entidades.Acerto;
using Entidades.Relacionamento.Venda;
using Apresenta��o.Atendimento.Clientes.Pedido;
using System.Drawing.Printing;
using Apresenta��o.Atendimento.Clientes;
using Apresenta��o.Atendimento.Comum;
using System.Text;
using Apresenta��o.Mercadoria;

namespace Apresenta��o.Atendimento
{
	/// <summary>
	/// Base inferior para atendimento.
	/// </summary>
	public class BaseAtendimento : Apresenta��o.Formul�rios.BaseInferior
	{
        /// <summary>
        /// Entidade da pessoa atual.
        /// </summary>
        /// <remarks>
        /// Pode ser nulo.
        /// </remarks>
        private Entidades.Pessoa.Pessoa pessoa = null;

        // Componentes
        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tulo;
        private Apresenta��o.Formul�rios.Quadro quadroCliente;
        private Apresenta��o.Formul�rios.Op��o op��oAbrir;
        private Apresenta��o.Formul�rios.Op��o op��oOutro;
        private Apresenta��o.Formul�rios.Quadro quadroRelacionar;
        private Apresenta��o.Formul�rios.Op��o op��oSa�da;
        private Apresenta��o.Formul�rios.Quadro quadroPend�ncias;
        private ListView lstPend�ncias;
        private ColumnHeader colItem;
        private ColumnHeader colDescri��o;
        private Op��o op��oConsignadoVenda;
        private Op��o op��oVendas;
        private Quadro quadroVendas;
        private Op��o op��oAcerto;
        private Op��o op��oPagamentos;
        private TableLayoutPanel tableLayoutPanel1;
        private Quadro quadroClassificador;
        private Classificador classificador;
        private BackgroundWorker bgDescobrirPend�ncia;
        private Op��o op��oRetorno;
        private Op��o op��oOcultar;
        private Quadro quadroModoAtendimento;
        private Op��o op��oEncerrarAtendimento;
        private Quadro quadro1;
        private Op��o op��oPedido;
        private Op��o op��oMalaDireta;
        private Quadro quadroObs;
        private TextBox txtObs;
        private Sinaliza��oPedido sinaliza��oPedido;
        private Sinaliza��oMercadoriaEmFalta sinaliza��oMercadoriaEmFalta;
        private Op��o op��oCr�ditos;
        private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i a base de atendimento.
		/// </summary>
		public BaseAtendimento()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            t�tulo.�coneArredondado = true;
            colItem.Width = lstPend�ncias.ClientSize.Width - colDescri��o.Width;
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
		/// Constr�i a base inferior, fornecendo os dados do cliente.
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

        public new Atendente.ControladorAtendimentoGen�rico Controlador
        {
            get 
            {
                if (base.Controlador is Atendente.ControladorAtendimentoGen�rico)
                    return (Atendente.ControladorAtendimentoGen�rico)base.Controlador;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseAtendimento));
            this.t�tulo = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadroCliente = new Apresenta��o.Formul�rios.Quadro();
            this.op��oAbrir = new Apresenta��o.Formul�rios.Op��o();
            this.op��oOcultar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oOutro = new Apresenta��o.Formul�rios.Op��o();
            this.op��oVendas = new Apresenta��o.Formul�rios.Op��o();
            this.quadroRelacionar = new Apresenta��o.Formul�rios.Quadro();
            this.op��oSa�da = new Apresenta��o.Formul�rios.Op��o();
            this.op��oRetorno = new Apresenta��o.Formul�rios.Op��o();
            this.op��oAcerto = new Apresenta��o.Formul�rios.Op��o();
            this.op��oConsignadoVenda = new Apresenta��o.Formul�rios.Op��o();
            this.quadroPend�ncias = new Apresenta��o.Formul�rios.Quadro();
            this.lstPend�ncias = new System.Windows.Forms.ListView();
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescri��o = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quadroVendas = new Apresenta��o.Formul�rios.Quadro();
            this.op��oCr�ditos = new Apresenta��o.Formul�rios.Op��o();
            this.op��oPagamentos = new Apresenta��o.Formul�rios.Op��o();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quadroClassificador = new Apresenta��o.Formul�rios.Quadro();
            this.classificador = new Apresenta��o.Pessoa.Cadastro.Classificador();
            this.quadroObs = new Apresenta��o.Formul�rios.Quadro();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.sinaliza��oPedido = new Apresenta��o.Atendimento.Sinaliza��oPedido();
            this.sinaliza��oMercadoriaEmFalta = new Apresenta��o.Mercadoria.Sinaliza��oMercadoriaEmFalta();
            this.bgDescobrirPend�ncia = new System.ComponentModel.BackgroundWorker();
            this.quadroModoAtendimento = new Apresenta��o.Formul�rios.Quadro();
            this.op��oEncerrarAtendimento = new Apresenta��o.Formul�rios.Op��o();
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.op��oPedido = new Apresenta��o.Formul�rios.Op��o();
            this.op��oMalaDireta = new Apresenta��o.Formul�rios.Op��o();
            this.esquerda.SuspendLayout();
            this.quadroCliente.SuspendLayout();
            this.quadroRelacionar.SuspendLayout();
            this.quadroPend�ncias.SuspendLayout();
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
            // t�tulo
            // 
            this.t�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tulo.BackColor = System.Drawing.Color.White;
            this.t�tulo.Descri��o = "Descri��o";
            this.t�tulo.�coneArredondado = false;
            this.t�tulo.Imagem = null;
            this.t�tulo.Location = new System.Drawing.Point(200, 8);
            this.t�tulo.Name = "t�tulo";
            this.t�tulo.Size = new System.Drawing.Size(883, 70);
            this.t�tulo.TabIndex = 6;
            this.t�tulo.T�tulo = "Nome do cliente";
            // 
            // quadroCliente
            // 
            this.quadroCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroCliente.bInfDirArredondada = true;
            this.quadroCliente.bInfEsqArredondada = true;
            this.quadroCliente.bSupDirArredondada = true;
            this.quadroCliente.bSupEsqArredondada = true;
            this.quadroCliente.Controls.Add(this.op��oAbrir);
            this.quadroCliente.Controls.Add(this.op��oOcultar);
            this.quadroCliente.Controls.Add(this.op��oOutro);
            this.quadroCliente.Cor = System.Drawing.Color.Black;
            this.quadroCliente.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroCliente.LetraT�tulo = System.Drawing.Color.White;
            this.quadroCliente.Location = new System.Drawing.Point(7, 13);
            this.quadroCliente.MostrarBot�oMinMax = false;
            this.quadroCliente.Name = "quadroCliente";
            this.quadroCliente.Size = new System.Drawing.Size(160, 75);
            this.quadroCliente.TabIndex = 0;
            this.quadroCliente.Tamanho = 30;
            this.quadroCliente.T�tulo = "Ficha";
            // 
            // op��oAbrir
            // 
            this.op��oAbrir.BackColor = System.Drawing.Color.Transparent;
            this.op��oAbrir.Descri��o = "Abrir ficha...";
            this.op��oAbrir.Imagem = global::Apresenta��o.Resource.folderopen1;
            this.op��oAbrir.Location = new System.Drawing.Point(7, 30);
            this.op��oAbrir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oAbrir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oAbrir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oAbrir.Name = "op��oAbrir";
            this.op��oAbrir.Privil�gio = Entidades.Privil�gio.Permiss�o.CadastroAcesso;
            this.op��oAbrir.Size = new System.Drawing.Size(150, 16);
            this.op��oAbrir.TabIndex = 2;
            this.op��oAbrir.Click += new System.EventHandler(this.op��oAbrir_Click);
            // 
            // op��oOcultar
            // 
            this.op��oOcultar.BackColor = System.Drawing.Color.Transparent;
            this.op��oOcultar.Descri��o = "Ocultar dados";
            this.op��oOcultar.Imagem = global::Apresenta��o.Resource.sunglasses_transp1;
            this.op��oOcultar.Location = new System.Drawing.Point(7, 50);
            this.op��oOcultar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oOcultar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oOcultar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oOcultar.Name = "op��oOcultar";
            this.op��oOcultar.Size = new System.Drawing.Size(150, 18);
            this.op��oOcultar.TabIndex = 4;
            this.op��oOcultar.Click += new System.EventHandler(this.op��oOcultar_Click);
            // 
            // op��oOutro
            // 
            this.op��oOutro.BackColor = System.Drawing.Color.Transparent;
            this.op��oOutro.Descri��o = "Escolher outra pessoa";
            this.op��oOutro.Imagem = global::Apresenta��o.Resource.delete;
            this.op��oOutro.Location = new System.Drawing.Point(3, 81);
            this.op��oOutro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oOutro.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oOutro.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oOutro.Name = "op��oOutro";
            this.op��oOutro.Size = new System.Drawing.Size(150, 24);
            this.op��oOutro.TabIndex = 3;
            this.op��oOutro.Visible = false;
            this.op��oOutro.Click += new System.EventHandler(this.op��oOutro_Click);
            // 
            // op��oVendas
            // 
            this.op��oVendas.BackColor = System.Drawing.Color.Transparent;
            this.op��oVendas.Descri��o = "Visualizar vendas";
            this.op��oVendas.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVendas.Imagem")));
            this.op��oVendas.Location = new System.Drawing.Point(7, 30);
            this.op��oVendas.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oVendas.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVendas.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVendas.Name = "op��oVendas";
            this.op��oVendas.Privil�gio = Entidades.Privil�gio.Permiss�o.VendasLeitura;
            this.op��oVendas.Size = new System.Drawing.Size(150, 20);
            this.op��oVendas.TabIndex = 4;
            this.op��oVendas.Click += new System.EventHandler(this.op��oVendas_Click);
            // 
            // quadroRelacionar
            // 
            this.quadroRelacionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroRelacionar.bInfDirArredondada = true;
            this.quadroRelacionar.bInfEsqArredondada = true;
            this.quadroRelacionar.bSupDirArredondada = true;
            this.quadroRelacionar.bSupEsqArredondada = true;
            this.quadroRelacionar.Controls.Add(this.op��oSa�da);
            this.quadroRelacionar.Controls.Add(this.op��oRetorno);
            this.quadroRelacionar.Controls.Add(this.op��oAcerto);
            this.quadroRelacionar.Cor = System.Drawing.Color.Black;
            this.quadroRelacionar.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRelacionar.LetraT�tulo = System.Drawing.Color.White;
            this.quadroRelacionar.Location = new System.Drawing.Point(7, 94);
            this.quadroRelacionar.MostrarBot�oMinMax = false;
            this.quadroRelacionar.Name = "quadroRelacionar";
            this.quadroRelacionar.Privil�gio = Entidades.Privil�gio.Permiss�o.Consignado;
            this.quadroRelacionar.Size = new System.Drawing.Size(160, 96);
            this.quadroRelacionar.TabIndex = 2;
            this.quadroRelacionar.Tamanho = 30;
            this.quadroRelacionar.T�tulo = "Consignado";
            // 
            // op��oSa�da
            // 
            this.op��oSa�da.BackColor = System.Drawing.Color.Transparent;
            this.op��oSa�da.Descri��o = "Sa�das";
            this.op��oSa�da.Imagem = global::Apresenta��o.Resource.Sa�da__Pequeno_1;
            this.op��oSa�da.Location = new System.Drawing.Point(7, 30);
            this.op��oSa�da.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.op��oSa�da.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oSa�da.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oSa�da.Name = "op��oSa�da";
            this.op��oSa�da.Privil�gio = Entidades.Privil�gio.Permiss�o.ConsignadoSa�da;
            this.op��oSa�da.Size = new System.Drawing.Size(150, 16);
            this.op��oSa�da.TabIndex = 2;
            this.op��oSa�da.Click += new System.EventHandler(this.op��oSa�da_Click);
            // 
            // op��oRetorno
            // 
            this.op��oRetorno.BackColor = System.Drawing.Color.Transparent;
            this.op��oRetorno.Descri��o = "Retornos";
            this.op��oRetorno.Imagem = global::Apresenta��o.Resource.Retorno__�cone_;
            this.op��oRetorno.Location = new System.Drawing.Point(7, 50);
            this.op��oRetorno.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oRetorno.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRetorno.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRetorno.Name = "op��oRetorno";
            this.op��oRetorno.Privil�gio = Entidades.Privil�gio.Permiss�o.ConsignadoRetorno;
            this.op��oRetorno.Size = new System.Drawing.Size(150, 16);
            this.op��oRetorno.TabIndex = 4;
            this.op��oRetorno.Click += new System.EventHandler(this.op��oRetorno_Click);
            // 
            // op��oAcerto
            // 
            this.op��oAcerto.BackColor = System.Drawing.Color.Transparent;
            this.op��oAcerto.Descri��o = "Acerto de mercadorias";
            this.op��oAcerto.Imagem = global::Apresenta��o.Resource.Acerto__Pequeno_;
            this.op��oAcerto.Location = new System.Drawing.Point(6, 76);
            this.op��oAcerto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oAcerto.Name = "op��oAcerto";
            this.op��oAcerto.Size = new System.Drawing.Size(150, 27);
            this.op��oAcerto.TabIndex = 2;
            this.op��oAcerto.Click += new System.EventHandler(this.op��oAcerto_Click);
            // 
            // op��oConsignadoVenda
            // 
            this.op��oConsignadoVenda.BackColor = System.Drawing.Color.Transparent;
            this.op��oConsignadoVenda.Descri��o = "Registrar venda";
            this.op��oConsignadoVenda.Imagem = global::Apresenta��o.Resource.pagar_em_d�lares__pequeno_1;
            this.op��oConsignadoVenda.Location = new System.Drawing.Point(7, 50);
            this.op��oConsignadoVenda.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oConsignadoVenda.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oConsignadoVenda.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oConsignadoVenda.Name = "op��oConsignadoVenda";
            this.op��oConsignadoVenda.Privil�gio = Entidades.Privil�gio.Permiss�o.VendasRemoverControle;
            this.op��oConsignadoVenda.Size = new System.Drawing.Size(150, 17);
            this.op��oConsignadoVenda.TabIndex = 5;
            this.op��oConsignadoVenda.Click += new System.EventHandler(this.op��oConsignadoVenda_Click);
            // 
            // quadroPend�ncias
            // 
            this.quadroPend�ncias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroPend�ncias.bInfDirArredondada = true;
            this.quadroPend�ncias.bInfEsqArredondada = true;
            this.quadroPend�ncias.bSupDirArredondada = true;
            this.quadroPend�ncias.bSupEsqArredondada = true;
            this.quadroPend�ncias.Controls.Add(this.lstPend�ncias);
            this.quadroPend�ncias.Cor = System.Drawing.Color.Black;
            this.quadroPend�ncias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quadroPend�ncias.FundoT�tulo = System.Drawing.Color.Brown;
            this.quadroPend�ncias.LetraT�tulo = System.Drawing.Color.White;
            this.quadroPend�ncias.Location = new System.Drawing.Point(3, 3);
            this.quadroPend�ncias.MostrarBot�oMinMax = false;
            this.quadroPend�ncias.Name = "quadroPend�ncias";
            this.quadroPend�ncias.Size = new System.Drawing.Size(194, 150);
            this.quadroPend�ncias.TabIndex = 8;
            this.quadroPend�ncias.Tamanho = 30;
            this.quadroPend�ncias.T�tulo = "Pend�ncias";
            // 
            // lstPend�ncias
            // 
            this.lstPend�ncias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPend�ncias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lstPend�ncias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPend�ncias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItem,
            this.colDescri��o});
            this.lstPend�ncias.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPend�ncias.FullRowSelect = true;
            this.lstPend�ncias.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstPend�ncias.Location = new System.Drawing.Point(3, 27);
            this.lstPend�ncias.MultiSelect = false;
            this.lstPend�ncias.Name = "lstPend�ncias";
            this.lstPend�ncias.Size = new System.Drawing.Size(186, 117);
            this.lstPend�ncias.TabIndex = 2;
            this.lstPend�ncias.UseCompatibleStateImageBehavior = false;
            this.lstPend�ncias.View = System.Windows.Forms.View.Details;
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            this.colItem.Width = 118;
            // 
            // colDescri��o
            // 
            this.colDescri��o.Text = "Descri��o";
            this.colDescri��o.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDescri��o.Width = 45;
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
            this.quadroVendas.Controls.Add(this.op��oVendas);
            this.quadroVendas.Controls.Add(this.op��oCr�ditos);
            this.quadroVendas.Controls.Add(this.op��oPagamentos);
            this.quadroVendas.Controls.Add(this.op��oConsignadoVenda);
            this.quadroVendas.Cor = System.Drawing.Color.Black;
            this.quadroVendas.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendas.LetraT�tulo = System.Drawing.Color.White;
            this.quadroVendas.Location = new System.Drawing.Point(7, 196);
            this.quadroVendas.MostrarBot�oMinMax = false;
            this.quadroVendas.Name = "quadroVendas";
            this.quadroVendas.Privil�gio = Entidades.Privil�gio.Permiss�o.Vendas;
            this.quadroVendas.Size = new System.Drawing.Size(162, 113);
            this.quadroVendas.TabIndex = 3;
            this.quadroVendas.Tamanho = 30;
            this.quadroVendas.T�tulo = "Financeiro";
            // 
            // op��oCr�ditos
            // 
            this.op��oCr�ditos.BackColor = System.Drawing.Color.Transparent;
            this.op��oCr�ditos.Descri��o = "Cr�ditos";
            this.op��oCr�ditos.Imagem = global::Apresenta��o.Resource.credito;
            this.op��oCr�ditos.Location = new System.Drawing.Point(7, 90);
            this.op��oCr�ditos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oCr�ditos.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oCr�ditos.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oCr�ditos.Name = "op��oCr�ditos";
            this.op��oCr�ditos.Size = new System.Drawing.Size(150, 23);
            this.op��oCr�ditos.TabIndex = 8;
            this.op��oCr�ditos.Click += new System.EventHandler(this.op��oCr�ditos_Click);
            // 
            // op��oPagamentos
            // 
            this.op��oPagamentos.BackColor = System.Drawing.Color.Transparent;
            this.op��oPagamentos.Descri��o = "Pagamentos";
            this.op��oPagamentos.Imagem = global::Apresenta��o.Resource.pagamento1;
            this.op��oPagamentos.Location = new System.Drawing.Point(7, 70);
            this.op��oPagamentos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oPagamentos.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oPagamentos.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oPagamentos.Name = "op��oPagamentos";
            this.op��oPagamentos.Size = new System.Drawing.Size(150, 16);
            this.op��oPagamentos.TabIndex = 7;
            this.op��oPagamentos.Click += new System.EventHandler(this.op��oPagamentos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.quadroClassificador, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadroPend�ncias, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.quadroObs, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sinaliza��oPedido, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.sinaliza��oMercadoriaEmFalta, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(184, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.quadroClassificador.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroClassificador.LetraT�tulo = System.Drawing.Color.White;
            this.quadroClassificador.Location = new System.Drawing.Point(3, 159);
            this.quadroClassificador.MostrarBot�oMinMax = false;
            this.quadroClassificador.Name = "quadroClassificador";
            this.quadroClassificador.Privil�gio = Entidades.Privil�gio.Permiss�o.CadastroAcesso;
            this.quadroClassificador.Size = new System.Drawing.Size(194, 137);
            this.quadroClassificador.TabIndex = 11;
            this.quadroClassificador.Tamanho = 30;
            this.quadroClassificador.T�tulo = "Classifica��es";
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
            this.classificador.Size = new System.Drawing.Size(188, 109);
            this.classificador.TabIndex = 10;
            // 
            // quadroObs
            // 
            this.quadroObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.quadroObs.bInfDirArredondada = true;
            this.quadroObs.bInfEsqArredondada = true;
            this.quadroObs.bSupDirArredondada = true;
            this.quadroObs.bSupEsqArredondada = true;
            this.quadroObs.Controls.Add(this.txtObs);
            this.quadroObs.Cor = System.Drawing.Color.Black;
            this.quadroObs.FundoT�tulo = System.Drawing.Color.Olive;
            this.quadroObs.LetraT�tulo = System.Drawing.Color.White;
            this.quadroObs.Location = new System.Drawing.Point(203, 3);
            this.quadroObs.MostrarBot�oMinMax = false;
            this.quadroObs.Name = "quadroObs";
            this.tableLayoutPanel1.SetRowSpan(this.quadroObs, 2);
            this.quadroObs.Size = new System.Drawing.Size(759, 293);
            this.quadroObs.TabIndex = 17;
            this.quadroObs.Tamanho = 30;
            this.quadroObs.T�tulo = "Observa��es";
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
            this.txtObs.Size = new System.Drawing.Size(754, 253);
            this.txtObs.TabIndex = 2;
            this.txtObs.Text = "As observa��es s� ser�o exibidas caso exista alguma.";
            // 
            // sinaliza��oPedido
            // 
            this.sinaliza��oPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sinaliza��oPedido.Borda = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.sinaliza��oPedido, 2);
            this.sinaliza��oPedido.Cor1 = System.Drawing.Color.LightYellow;
            this.sinaliza��oPedido.Cor2 = System.Drawing.Color.Ivory;
            this.sinaliza��oPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sinaliza��oPedido.Location = new System.Drawing.Point(3, 302);
            this.sinaliza��oPedido.MinimumSize = new System.Drawing.Size(100, 32);
            this.sinaliza��oPedido.Name = "sinaliza��oPedido";
            this.sinaliza��oPedido.Size = new System.Drawing.Size(959, 44);
            this.sinaliza��oPedido.TabIndex = 12;
            this.sinaliza��oPedido.Click += new System.EventHandler(this.op��oPedido_Click);
            // 
            // sinaliza��oMercadoriaEmFalta
            // 
            this.sinaliza��oMercadoriaEmFalta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sinaliza��oMercadoriaEmFalta.Borda = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.sinaliza��oMercadoriaEmFalta, 2);
            this.sinaliza��oMercadoriaEmFalta.Cor1 = System.Drawing.Color.LightYellow;
            this.sinaliza��oMercadoriaEmFalta.Cor2 = System.Drawing.Color.Ivory;
            this.sinaliza��oMercadoriaEmFalta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sinaliza��oMercadoriaEmFalta.Location = new System.Drawing.Point(3, 352);
            this.sinaliza��oMercadoriaEmFalta.MinimumSize = new System.Drawing.Size(100, 32);
            this.sinaliza��oMercadoriaEmFalta.Name = "sinaliza��oMercadoriaEmFalta";
            this.sinaliza��oMercadoriaEmFalta.Size = new System.Drawing.Size(959, 44);
            this.sinaliza��oMercadoriaEmFalta.TabIndex = 13;
            this.sinaliza��oMercadoriaEmFalta.Click += new System.EventHandler(this.sinaliza��oMercadoriaEmFalta_Click);
            // 
            // bgDescobrirPend�ncia
            // 
            this.bgDescobrirPend�ncia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RecuperarPend�ncias);
            this.bgDescobrirPend�ncia.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MostrarPend�ncias);
            // 
            // quadroModoAtendimento
            // 
            this.quadroModoAtendimento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroModoAtendimento.bInfDirArredondada = true;
            this.quadroModoAtendimento.bInfEsqArredondada = true;
            this.quadroModoAtendimento.bSupDirArredondada = true;
            this.quadroModoAtendimento.bSupEsqArredondada = true;
            this.quadroModoAtendimento.Controls.Add(this.op��oEncerrarAtendimento);
            this.quadroModoAtendimento.Cor = System.Drawing.Color.Black;
            this.quadroModoAtendimento.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quadroModoAtendimento.LetraT�tulo = System.Drawing.Color.White;
            this.quadroModoAtendimento.Location = new System.Drawing.Point(7, 407);
            this.quadroModoAtendimento.MostrarBot�oMinMax = false;
            this.quadroModoAtendimento.Name = "quadroModoAtendimento";
            this.quadroModoAtendimento.Size = new System.Drawing.Size(160, 62);
            this.quadroModoAtendimento.TabIndex = 4;
            this.quadroModoAtendimento.Tamanho = 30;
            this.quadroModoAtendimento.T�tulo = "Atendimento";
            this.quadroModoAtendimento.Visible = false;
            // 
            // op��oEncerrarAtendimento
            // 
            this.op��oEncerrarAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.op��oEncerrarAtendimento.Descri��o = "Encerrar modo de atendimento";
            this.op��oEncerrarAtendimento.Imagem = global::Apresenta��o.Resource.turnkey1;
            this.op��oEncerrarAtendimento.Location = new System.Drawing.Point(7, 30);
            this.op��oEncerrarAtendimento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oEncerrarAtendimento.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oEncerrarAtendimento.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oEncerrarAtendimento.Name = "op��oEncerrarAtendimento";
            this.op��oEncerrarAtendimento.Size = new System.Drawing.Size(150, 27);
            this.op��oEncerrarAtendimento.TabIndex = 2;
            this.op��oEncerrarAtendimento.Click += new System.EventHandler(this.op��oEncerrarAtendimento_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.op��oPedido);
            this.quadro1.Controls.Add(this.op��oMalaDireta);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 312);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 89);
            this.quadro1.TabIndex = 5;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "Servi�os";
            // 
            // op��oPedido
            // 
            this.op��oPedido.BackColor = System.Drawing.Color.Transparent;
            this.op��oPedido.Descri��o = "Pedidos e consertos";
            this.op��oPedido.Imagem = global::Apresenta��o.Resource.Pedido1;
            this.op��oPedido.Location = new System.Drawing.Point(7, 30);
            this.op��oPedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oPedido.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oPedido.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oPedido.Name = "op��oPedido";
            this.op��oPedido.Size = new System.Drawing.Size(150, 20);
            this.op��oPedido.TabIndex = 2;
            this.op��oPedido.Click += new System.EventHandler(this.op��oPedido_Click);
            // 
            // op��oMalaDireta
            // 
            this.op��oMalaDireta.BackColor = System.Drawing.Color.Transparent;
            this.op��oMalaDireta.Descri��o = "Imprimir etiqueta para mala-direta";
            this.op��oMalaDireta.Imagem = global::Apresenta��o.Resource.LABELS1;
            this.op��oMalaDireta.Location = new System.Drawing.Point(7, 50);
            this.op��oMalaDireta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oMalaDireta.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oMalaDireta.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oMalaDireta.Name = "op��oMalaDireta";
            this.op��oMalaDireta.Size = new System.Drawing.Size(150, 33);
            this.op��oMalaDireta.TabIndex = 3;
            this.op��oMalaDireta.Click += new System.EventHandler(this.op��oMalaDireta_Click);
            // 
            // BaseAtendimento
            // 
            this.Controls.Add(this.t�tulo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BaseAtendimento";
            this.Size = new System.Drawing.Size(1099, 510);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.t�tulo, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.esquerda.PerformLayout();
            this.quadroCliente.ResumeLayout(false);
            this.quadroRelacionar.ResumeLayout(false);
            this.quadroPend�ncias.ResumeLayout(false);
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
        /// Prepara base inferior para exibi��o de um cliente.
        /// </summary>
        /// <param name="pessoa">Cadastro do cliente.</param>
        public void Carregar(Entidades.Pessoa.Pessoa cliente)
        {
            this.pessoa = cliente;
            classificador.Pessoa = pessoa;

            sinaliza��oPedido.Visible = false;
            sinaliza��oMercadoriaEmFalta.Visible = false;

            AdequarModoAtendimento();

            CarregarControlesVisuais(cliente);
            VerificarPessoaSemSetor(cliente);
        }

        private void CarregarControlesVisuais(Entidades.Pessoa.Pessoa cliente)
        {
            t�tulo.T�tulo = ObterT�tulo();
            txtObs.Text = pessoa.Observa��es;
            t�tulo.Descri��o = ObterDescri��o(cliente);
            t�tulo.Imagem = Controlador�conePessoa.Obter�coneComFundoEC�digo(pessoa);
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

        private string ObterT�tulo()
        {
            string t�tuloStr = pessoa.Nome.Replace("&", "&&");

            if ((pessoa is PessoaJur�dica) && (((PessoaJur�dica)pessoa).Fantasia != null))
                t�tuloStr += " - " + ((PessoaJur�dica)pessoa).Fantasia;

            return t�tuloStr;
        }

        private string ObterDescri��o(Entidades.Pessoa.Pessoa cliente)
        {
            StringBuilder descri��o = new StringBuilder();

            if (cliente.Regi�o != null)
                descri��o.Append(cliente.Regi�o.Nome.Trim()).Append(" - ");

            List<Entidades.Pessoa.Endere�o.Endere�o> endere�os = cliente.Endere�os.ExtrairElementos();

            string strTelefones = ObterTelefones(pessoa);
            if (!String.IsNullOrWhiteSpace(strTelefones))
                descri��o.Append(" ").Append(strTelefones);

            if (endere�os.Count > 0 && endere�os[0].Localidade != null)
                descri��o.Append(" ").Append(endere�os[0].Localidade.Nome + " / " + endere�os[0].Localidade.Estado.Sigla);

            return descri��o.ToString();
        }

        private string ObterTelefones(Entidades.Pessoa.Pessoa pessoa)
        {
            StringBuilder strTelefones = new StringBuilder();

            foreach (Telefone telefone in pessoa.Telefones)
            {
                if (strTelefones.Length > 0)
                    strTelefones.Append("; ");

                strTelefones.Append(telefone.N�mero);
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
		private void op��oOutro_Click(object sender, System.EventArgs e)
		{
			SubstituirBaseParaAnterior();
		}

		/// <summary>
		/// Ocorre ao clicar em "Abrir ficha".
		/// </summary>
		private void op��oAbrir_Click(object sender, System.EventArgs e)
		{
			DialogResult            resultado;
			Entidades.Pessoa.Pessoa entidade;

			/* Abaixo ser� verificado qual o tipo da pessoa. Em caso
			 * de altera��o, deve-se tomar o CUIDADO com a ORDEM
			 * de verifica��o, pois uma classe pai responder�
			 * pelas classes filhas que estiverem ap�s a sua verifica��o.
			 */

			// Funcion�rio
			if (Entidades.Pessoa.Funcion�rio.�Funcion�rio(pessoa))
			{
                AguardeDB.Mostrar();

                try
                {
                    if (!(pessoa is Funcion�rio))
                        pessoa = Entidades.Pessoa.Funcion�rio.ObterPessoa(pessoa.C�digo);
                }
                finally
                {
                    AguardeDB.Fechar();
                }

				using (CadastroFuncion�rio frm = new CadastroFuncion�rio((Entidades.Pessoa.Funcion�rio) pessoa))
				{
					resultado = frm.ShowDialog(this.ParentForm);
					entidade  = frm.Funcion�rio;
				}
			}
			/* Representante ou Pessoa F�sica
			 * 
			 * Um representante s� possui um �nico campo inalter�vel (c�digo)
			 * e, portanto, pode ser encarado como pessoa f�sica.
			 */
			else if (pessoa is Entidades.Pessoa.PessoaF�sica)
			{
                using (CadastroCliente frm = new CadastroCliente((PessoaF�sica)pessoa))
				{
					resultado = frm.ShowDialog(this.ParentForm);
					entidade = frm.Pessoa;
				}
			}
			// Pessoa jur�dica
            else if (pessoa is Entidades.Pessoa.PessoaJur�dica)
                using (CadastroCliente frm = new CadastroCliente((PessoaJur�dica)pessoa))
                {
                    resultado = frm.ShowDialog(this.ParentForm);
                    entidade = frm.Pessoa;
                }
            else if (pessoa is Entidades.Pessoa.Pessoa)
            {
                Entidades.Pessoa.PessoaJur�dica juridica =
                    Entidades.Pessoa.PessoaJur�dica.ObterPessoa(pessoa.C�digo);
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
                    PessoaF�sica fisica = PessoaF�sica.ObterPessoa(pessoa.C�digo);

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
                        throw new Exception("A pessoa � do Tipo Entidades.Pessoa, por�m n�o � f�sica nem jur�dica!");
                    }
                }
            }
            else
            {
                throw new NotSupportedException("O tipo de pessoa \"" + pessoa.GetType().Name + "\" n�o � suportado. C�digo:" + pessoa.C�digo.ToString());
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
			Carregar(novaEntidade);

            UseWaitCursor = false;
            AguardeDB.Fechar();
		}

        /// <summary>
        /// Descobre pend�ncias do cliente e exibe na ListView.
        /// </summary>
        private void DescobrirPend�ncias()
        {
            LinkedList<ClientePend�ncia> pend�ncias;

            lstPend�ncias.UseWaitCursor = true;

            pend�ncias = ClientePend�ncia.ObterPend�ncias(pessoa);

            MostrarPend�ncias(pend�ncias);

            lstPend�ncias.UseWaitCursor = false;
        }

        private void AoEncontrarVendasN�oQuitadas(Entidades.Pessoa.Pessoa cliente, Entidades.Relacionamento.Venda.Venda[] vendas, double d�vida)
        {
            MostrarPend�ncia(new ClientePend�ncia(vendas.Length.ToString() + " Vendas", d�vida.ToString("C"), true));
            ReajustarPend�ncias();
        }

        private Dictionary<ListViewItem, ClientePend�ncia> hashPendencias = new Dictionary<ListViewItem,ClientePend�ncia>();
        /// <summary>
        /// Mostra as pend�ncias existentes.
        /// </summary>
        private void MostrarPend�ncias(LinkedList<ClientePend�ncia> pend�ncias)
        {
            hashPendencias.Clear();
            lstPend�ncias.Items.Clear();

            foreach (ClientePend�ncia pend�ncia in pend�ncias)
                MostrarPend�ncia(pend�ncia);

            ReajustarPend�ncias();
        }

        private delegate void ReajustarPend�nciasCallback();

        private void ReajustarPend�ncias()
        {
            if (lstPend�ncias.InvokeRequired)
            {
                ReajustarPend�nciasCallback m�todo = new ReajustarPend�nciasCallback(ReajustarPend�ncias);
                lstPend�ncias.BeginInvoke(m�todo);
            }
            else
            {
                lstPend�ncias.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lstPend�ncias.Columns[0].Width =
                    Math.Min(
                    lstPend�ncias.Columns[0].Width,
                    lstPend�ncias.ClientSize.Width - lstPend�ncias.Columns[1].Width);
                lstPend�ncias.Columns[1].Width =
                    lstPend�ncias.ClientSize.Width - lstPend�ncias.Columns[0].Width;
            }
        }

        private delegate void MostrarPend�nciaCallback(ClientePend�ncia pend�ncia);

        private void MostrarPend�ncia(ClientePend�ncia pend�ncia)
        {
            if (lstPend�ncias.InvokeRequired)
            {
                MostrarPend�nciaCallback m�todo = new MostrarPend�nciaCallback(MostrarPend�ncia);
                lstPend�ncias.BeginInvoke(m�todo, pend�ncia);
            }
            else
            {
                ListViewItem item;

                bool mostrarNaLista = true;
                item = new ListViewItem(pend�ncia.Item + ":");
                item.SubItems.Add(pend�ncia.Descri��o);

                if (pend�ncia.Alertar)
                    item.Font = new Font(item.Font, FontStyle.Bold);


                switch (pend�ncia.Identifica��o)
                {
                    case ClientePend�ncia.Identifica��es.PedidoPronto:
                        sinaliza��oPedido.Visible = true;
                        break;
                    case ClientePend�ncia.Identifica��es.MercadoriaEmFalta:
                        mostrarNaLista = false;
                        sinaliza��oMercadoriaEmFalta.Visible = true;
                        break;
                }

                if (mostrarNaLista)
                {
                    hashPendencias.Add(item, pend�ncia);
                    lstPend�ncias.Items.Add(item);

                    item.EnsureVisible();
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
                throw new Exception("Pessoa nem visitante atribu�do!");
        }

        /// <summary>
        /// Ocorre ao exibir a base inferior.
        /// </summary>
        protected override void AoExibir()
        {
            base.AoExibir();

            DescobrirPend�nciasSegundoPlano();
        }
		#endregion

        #region Eventos da interface gr�fica para mudan�a de base inferior

        /// <summary>
        /// Ocorre ao escolher sa�da.
        /// </summary>
        private void op��oSa�da_Click(object sender, EventArgs e)
        {
            Apresenta��o.Financeiro.Sa�da.BaseSa�das baseSa�das = new Apresenta��o.Financeiro.Sa�da.BaseSa�das(pessoa);
            SubstituirBase(baseSa�das);
        }

        /// <summary>
        /// Ocorre ao escolher retorno.
        /// </summary>
        private void op��oRetorno_Click(object sender, EventArgs e)
        {
            Apresenta��o.Financeiro.Retorno.BaseRetornos baseRetornos = new Apresenta��o.Financeiro.Retorno.BaseRetornos(pessoa);
            SubstituirBase(baseRetornos);
        }

        /// <summary>
        /// Ocorre ao escolher venda.
        /// </summary>
        private void op��oConsignadoVenda_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Application.DoEvents();

            BaseEditarVenda baseVenda = new BaseEditarVenda();
            try
            {
                baseVenda.PrepararNovaVenda(pessoa);
                SubstituirBase(baseVenda);
            }
            catch (OperationCanceledException)
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
        private void op��oVendas_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Apresenta��o.Financeiro.Venda.BaseVendas baseVendas = new Apresenta��o.Financeiro.Venda.BaseVendas(pessoa);
            SubstituirBase(baseVendas);
            UseWaitCursor = false;
        }

        private void op��oAcerto_Click(object sender, EventArgs e)
        {
            Entidades.Pessoa.Pessoa pessoaUtilizar;

            if (pessoa.Setor == Setor.ObterSetor(Setor.SetorSistema.Varejo))
            {
                pessoaUtilizar = Entidades.Pessoa.Pessoa.Varejo;
            }
            else
                pessoaUtilizar = pessoa;

            AcertoConsignado acerto = EscolherAcerto.QuestionarUsu�rio(ParentForm, pessoaUtilizar, false);

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

        private void op��oPagamentos_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();
            Apresenta��o.Financeiro.Pagamento.BasePagamentos basePagamentos = new Apresenta��o.Financeiro.Pagamento.BasePagamentos();
            basePagamentos.Abrir(pessoa);
            SubstituirBase(basePagamentos);
            AguardeDB.Fechar();
            UseWaitCursor = false;
        }

        #endregion

        /// <summary>
        /// Descobre as pend�ncias em segundo plano.
        /// </summary>
        private void DescobrirPend�nciasSegundoPlano()
        {
            if (!bgDescobrirPend�ncia.IsBusy)
            {
                lstPend�ncias.Items.Add("Verificando...");
                bgDescobrirPend�ncia.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Recupera as pend�ncias em segundo plano, por meio
        /// do componente bgDescobrirPend�ncia.
        /// </summary>
        private void RecuperarPend�ncias(object sender, DoWorkEventArgs e)
        {
            e.Result = ClientePend�ncia.ObterPend�ncias(pessoa);
        }

        /// <summary>
        /// Mostra as pend�ncias como resultado da execu��o ass�ncrona
        /// do componente bgDescobrirPend�ncia.
        /// </summary>
        private void MostrarPend�ncias(object sender, RunWorkerCompletedEventArgs e)
        {
            LinkedList<ClientePend�ncia> pend�ncias = (LinkedList<ClientePend�ncia>)e.Result;

            MostrarPend�ncias(pend�ncias);
        }

        void verifica��o_AoEncontrarPagamentosPendentes(Entidades.Pessoa.Pessoa cliente, Entidades.Pagamentos.Pagamento[] pagamentosPendentes)
        {
            double valorPendente = 0;

            foreach (Entidades.Pagamentos.Pagamento p in pagamentosPendentes)
                valorPendente += p.Valor;

            MostrarPend�ncia(new ClientePend�ncia(pagamentosPendentes.Length.ToString() + " Pagamentos", valorPendente.ToString("C"), true));
            ReajustarPend�ncias();
        }

        /// <summary>
        /// Oculta dados para que a privacidade seja mantida
        /// na frente do cliente.
        /// </summary>
        private void op��oOcultar_Click(object sender, EventArgs e)
        {
            ModoAtendimento = true;
            AdequarModoAtendimento();
        }

        private void op��oEncerrarAtendimento_Click(object sender, EventArgs e)
        {
            if (Login.ExigirIdentifica��o(ParentForm, "Encerrar modo de atendimento",
                "Confirme sua senha para liberar a visualiza��o de dados e encerrar o modo de atendimento."))
            {
                ModoAtendimento = false;
                AdequarModoAtendimento();
            }
        }

        private void op��oPedido_Click(object sender, EventArgs e)
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

        private void sinaliza��oMercadoriaEmFalta_Click(object sender, EventArgs e)
        {
            JanelaMercadoriaEmFalta janela = new JanelaMercadoriaEmFalta();
            janela.Carregar(pessoa, this);
        }

        private void op��oMalaDireta_Click(object sender, EventArgs e)
        {
            JanelaEtiquetaSedex janela = JanelaEtiquetaSedex.Instancia;
            janela.Adicionar(Pessoa);

            janela.Hide();
            janela.ShowDialog(this);
        }

        private void op��oCr�ditos_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();
            Apresenta��o.Financeiro.Cr�dito.BaseCr�ditos baseCr�ditos = new Apresenta��o.Financeiro.Cr�dito.BaseCr�ditos();
            baseCr�ditos.Pessoa = pessoa;
            SubstituirBase(baseCr�ditos);
            AguardeDB.Fechar();
            UseWaitCursor = false;
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            quadroObs.Width = tableLayoutPanel1.Width - quadroPend�ncias.Width - 20;
            quadroObs.Height = tableLayoutPanel1.Height;
        }
    }
}
