using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresenta��o.Atendimento.Comum;
using Apresenta��o.Pessoa.Consultas;
using Entidades.Pessoa;
using Entidades;
using Apresenta��o.Atendimento.Atendente;
using Entidades.Configura��o;
using Apresenta��o.Formul�rios.Impress�o;
using Apresenta��o.Impress�o;
using Apresenta��o.Impress�o.Relat�rios.Pessoa;
using System.Collections.Generic;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Atendimento.Clientes
{
	/// <summary>
	/// Base inferior da janela para sele��o de clientes.
	/// </summary>
	public class BaseSele��oCliente : Apresenta��o.Formul�rios.BaseInferior
	{
        private ColetorPessoas coletor;
        public static int QuantidadeDeDiasParaObten��oDeDatasRelevantes = 1;
        private static int? QtdM�ximaDatasInicialmenteMostradas = null;

		/// <summary>
		/// Mensagem exibida enquanto se carrega os dados.
		/// </summary>
		private const string strCarregando = "A lista de clientes est� sendo carregada, mas voc� pode continuar"
			+ " utilizando o sistema normalmente at� que o processo termine.";

		/// <summary>
		/// Determina prazo em dias para que uma pessoa seja exibida
		/// desde sua �ltima visita.
		/// </summary>
		private int dias = 90;

		/// <summary>
		/// Delega��o para escolha de pessoa.
		/// </summary>
		public delegate void EscolhaPessoa(Entidades.Pessoa.Pessoa pessoa);

		/// <summary>
		/// Evento que ocorre quando uma pessoa � escolhida.
		/// </summary>
		public event EscolhaPessoa Escolhida;

		/// <summary>
		/// Delega��o para carga ass�ncrona de dados.
		/// </summary>
		private delegate void DCarSetAss�nc(Setor [] setores, DateTime in�cio, DateTime final);

		/// <summary>
		/// Delega��o para carga ass�ncrona de dados, por�m no contexto
		/// da ListaPessoas.
		/// </summary>
		private delegate ListaEntidadePessoaItemBusca [] DCriEntPesIte(List<Entidades.Pessoa.Pessoa> pessoas);
		private delegate void DSinalizarCarga(string descri��o);
		private delegate void DAdicionarItens(ICollection c);
        protected delegate void DAdicionarDataRelevante(DataRelevante[] c);
		private Apresenta��o.Formul�rios.Quadro quadroClientes;
		private Apresenta��o.Formul�rios.Op��o op��oProcurar;
		private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tulo;
        private Apresenta��o.Formul�rios.Op��o op��oCadastrar;
        private TableLayoutPanel tableLayoutPanel1;
        private Apresenta��o.Formul�rios.QuadroSimples quadroDatasRelevantes;
        private Apresenta��o.Formul�rios.Linha linha1;
        private Label label1;
        protected ListaPessoas listaDatasRelevantes;
        private Apresenta��o.Formul�rios.Op��o op��oImprimir;
        private ListaPessoasBusca listaPessoasBusca;
        private TextBox txtBusca;
		private System.ComponentModel.IContainer components = null;

		public BaseSele��oCliente()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            coletor = new ColetorPessoas(new ColetorPessoas.Recupera��oPessoasDelegate(Recupera��o));
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

        protected override void AoExibir()
        {
            base.AoExibir();
            txtBusca.Text = "";
            txtBusca.Focus();
            ultimaTeclaNaTxtBusca�Enter = false;
        }

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSele��oCliente));
            this.quadroClientes = new Apresenta��o.Formul�rios.Quadro();
            this.op��oProcurar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oCadastrar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oImprimir = new Apresenta��o.Formul�rios.Op��o();
            this.t�tulo = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listaPessoasBusca = new Apresenta��o.Atendimento.Comum.ListaPessoasBusca();
            this.quadroDatasRelevantes = new Apresenta��o.Formul�rios.QuadroSimples();
            this.listaDatasRelevantes = new Apresenta��o.Atendimento.Comum.ListaPessoas();
            this.linha1 = new Apresenta��o.Formul�rios.Linha();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.esquerda.SuspendLayout();
            this.quadroClientes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.quadroDatasRelevantes.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroClientes);
            this.esquerda.Size = new System.Drawing.Size(187, 400);
            this.esquerda.Controls.SetChildIndex(this.quadroClientes, 0);
            // 
            // quadroClientes
            // 
            this.quadroClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroClientes.bInfDirArredondada = true;
            this.quadroClientes.bInfEsqArredondada = true;
            this.quadroClientes.bSupDirArredondada = true;
            this.quadroClientes.bSupEsqArredondada = true;
            this.quadroClientes.Controls.Add(this.op��oProcurar);
            this.quadroClientes.Controls.Add(this.op��oCadastrar);
            this.quadroClientes.Controls.Add(this.op��oImprimir);
            this.quadroClientes.Cor = System.Drawing.Color.Black;
            this.quadroClientes.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroClientes.LetraT�tulo = System.Drawing.Color.White;
            this.quadroClientes.Location = new System.Drawing.Point(7, 13);
            this.quadroClientes.MostrarBot�oMinMax = false;
            this.quadroClientes.Name = "quadroClientes";
            this.quadroClientes.Size = new System.Drawing.Size(160, 96);
            this.quadroClientes.TabIndex = 0;
            this.quadroClientes.Tamanho = 30;
            this.quadroClientes.T�tulo = "Clientes e Funcion�rios";
            // 
            // op��oProcurar
            // 
            this.op��oProcurar.BackColor = System.Drawing.Color.Transparent;
            this.op��oProcurar.Descri��o = "Busca avan�ada";
            this.op��oProcurar.Imagem = global::Apresenta��o.Resource.search4people;
            this.op��oProcurar.Location = new System.Drawing.Point(7, 30);
            this.op��oProcurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oProcurar.Name = "op��oProcurar";
            this.op��oProcurar.Size = new System.Drawing.Size(150, 16);
            this.op��oProcurar.TabIndex = 2;
            this.op��oProcurar.Click += new System.EventHandler(this.op��oProcurar_Click);
            // 
            // op��oCadastrar
            // 
            this.op��oCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.op��oCadastrar.Descri��o = "Cadastrar";
            this.op��oCadastrar.Imagem = global::Apresenta��o.Resource.newfolder1;
            this.op��oCadastrar.Location = new System.Drawing.Point(7, 50);
            this.op��oCadastrar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oCadastrar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oCadastrar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oCadastrar.Name = "op��oCadastrar";
            this.op��oCadastrar.Privil�gio = Entidades.Privil�gio.Permiss�o.CadastroEditar;
            this.op��oCadastrar.Size = new System.Drawing.Size(150, 16);
            this.op��oCadastrar.TabIndex = 3;
            this.op��oCadastrar.Click += new System.EventHandler(this.op��oCadastrar_Click);
            // 
            // op��oImprimir
            // 
            this.op��oImprimir.BackColor = System.Drawing.Color.Transparent;
            this.op��oImprimir.Descri��o = "Imprimir cadastros...";
            this.op��oImprimir.Imagem = global::Apresenta��o.Resource.Impressora_3D;
            this.op��oImprimir.Location = new System.Drawing.Point(7, 70);
            this.op��oImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oImprimir.Name = "op��oImprimir";
            this.op��oImprimir.Privil�gio = Entidades.Privil�gio.Permiss�o.CadastroEditar;
            this.op��oImprimir.Size = new System.Drawing.Size(150, 24);
            this.op��oImprimir.TabIndex = 4;
            this.op��oImprimir.Click += new System.EventHandler(this.op��oImprimir_Click);
            // 
            // t�tulo
            // 
            this.t�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tulo.BackColor = System.Drawing.Color.White;
            this.t�tulo.Descri��o = "";
            this.t�tulo.�coneArredondado = false;
            this.t�tulo.Imagem = ((System.Drawing.Image)(resources.GetObject("t�tulo.Imagem")));
            this.t�tulo.Location = new System.Drawing.Point(200, 8);
            this.t�tulo.Name = "t�tulo";
            this.t�tulo.Size = new System.Drawing.Size(544, 70);
            this.t�tulo.TabIndex = 10;
            this.t�tulo.T�tulo = "Busca de clientes ou funcion�rios";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.listaPessoasBusca, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.quadroDatasRelevantes, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(178, 69);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 311);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // listaPessoasBusca
            // 
            this.listaPessoasBusca.AutoScroll = true;
            this.listaPessoasBusca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaPessoasBusca.Location = new System.Drawing.Point(3, 3);
            this.listaPessoasBusca.Name = "listaPessoasBusca";
            this.listaPessoasBusca.Size = new System.Drawing.Size(388, 308);
            this.listaPessoasBusca.TabIndex = 12;
            // 
            // quadroDatasRelevantes
            // 
            this.quadroDatasRelevantes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.quadroDatasRelevantes.Borda = System.Drawing.Color.OliveDrab;
            this.quadroDatasRelevantes.Controls.Add(this.listaDatasRelevantes);
            this.quadroDatasRelevantes.Controls.Add(this.linha1);
            this.quadroDatasRelevantes.Controls.Add(this.label1);
            this.quadroDatasRelevantes.Cor1 = System.Drawing.Color.Honeydew;
            this.quadroDatasRelevantes.Cor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.quadroDatasRelevantes.Location = new System.Drawing.Point(397, 3);
            this.quadroDatasRelevantes.Name = "quadroDatasRelevantes";
            this.quadroDatasRelevantes.Size = new System.Drawing.Size(176, 308);
            this.quadroDatasRelevantes.TabIndex = 2;
            this.quadroDatasRelevantes.Visible = false;
            // 
            // listaDatasRelevantes
            // 
            this.listaDatasRelevantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaDatasRelevantes.AutoColunas = false;
            this.listaDatasRelevantes.AutoScroll = true;
            this.listaDatasRelevantes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listaDatasRelevantes.BackColor = System.Drawing.Color.Transparent;
            this.listaDatasRelevantes.Colunas = 1;
            this.listaDatasRelevantes.Location = new System.Drawing.Point(8, 35);
            this.listaDatasRelevantes.Name = "listaDatasRelevantes";
            this.listaDatasRelevantes.Size = new System.Drawing.Size(165, 270);
            this.listaDatasRelevantes.TabIndex = 2;
            this.listaDatasRelevantes.PessoaSelecionada += new Apresenta��o.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaDatasRelevantes_PessoaSelecionada);
            this.listaDatasRelevantes.Scroll += new System.Windows.Forms.ScrollEventHandler(this.listaDatasRelevantes_Scroll);
            // 
            // linha1
            // 
            this.linha1.Location = new System.Drawing.Point(8, 27);
            this.linha1.Name = "linha1";
            this.linha1.Size = new System.Drawing.Size(164, 2);
            this.linha1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datas importantes";
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusca.BackColor = System.Drawing.Color.Linen;
            this.txtBusca.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(270, 33);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(481, 33);
            this.txtBusca.TabIndex = 12;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // BaseSele��oCliente
            // 
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.t�tulo);
            this.Name = "BaseSele��oCliente";
            this.Size = new System.Drawing.Size(760, 400);
            this.Controls.SetChildIndex(this.t�tulo, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.txtBusca, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroClientes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.quadroDatasRelevantes.ResumeLayout(false);
            this.quadroDatasRelevantes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// T�tulo da base inferior.
		/// </summary>
		[DefaultValue("Sele��o de cliente")]
		public string T�tulo
		{
			get { return t�tulo.T�tulo; }
			set { t�tulo.T�tulo = value; }
		}

		/// <summary>
		/// Descri��o da base inferior.
		/// </summary>
		[DefaultValue("Escolha o cliente desejado.")]
		public string Descri��o
		{
			get { return t�tulo.Descri��o; }
			set { t�tulo.Descri��o = value; }
		}

        ///// <summary>
        ///// Itens exibidos.
        ///// </summary>
        //public Cole��oListaPessoasItem ItensExibidos
        //{
        //    get { return listaPessoas.Itens; }
        //}

		/// <summary>
		/// Prazo em dias para que uma pessoa seja exibida
		/// desde sua �ltima visita.
		/// </summary>
		[DefaultValue(90), Description("Prazo em dias para que uma pessoa seja exibida desde sua �ltima visita.")]
		public int Prazo
		{
			get { return dias; }
			set
			{
				if (value <= 0)
					throw new ArgumentException("O valor para o prazo n�o pode ser negativo.");

				dias = value;
			}
		}

		/// <summary>
		/// Per�odo inicial.
		/// </summary>
		public DateTime Per�odoInicial
		{
			get { return DateTime.Now.Subtract(TimeSpan.FromDays(dias)); }
		}

		#endregion
		
		#region Tratamento de eventos

		/// <summary>
		/// Ocorre ao selecionar uma pessoa.
		/// </summary>
		/// <param name="item">Item selecionado.</param>
		protected virtual void listaPessoas_PessoaSelecionada(Apresenta��o.Atendimento.Comum.ListaPessoasItem item)
		{
			Entidades.Pessoa.Pessoa pessoa;

		    pessoa = ((ListaEntidadePessoaItem) item).Pessoa;

			Escolhida(pessoa);
		}

		#endregion

        public override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            base.AoCarregarCompletamente(splash);
            HandleCreated += new EventHandler(BaseSele��oCliente_HandleCreated);
        }

        void BaseSele��oCliente_HandleCreated(object sender, EventArgs e)
        {
            coletor.Pesquisar("");
        }


        /// <summary>
        /// Carrega lista de pessoas provenientes de setores espec�ficos.
        /// </summary>
        /// <param name="setores">Lista de setores.</param>
        public void CarregarDeSetores(params Setor[] setores)
        {
            if (setores == null)
                throw new ArgumentNullException("setores");

            DCarSetAss�nc m�todo;

            m�todo = new DCarSetAss�nc(CarregarDeSetores);
            m�todo.BeginInvoke(setores, Per�odoInicial, DateTime.MaxValue, new AsyncCallback(CargaCallback), m�todo);
        }

		/// <summary>
		/// Finaliza carga ass�ncrona.
		/// </summary>
		private void CargaCallback(IAsyncResult resultado)
		{
			DCarSetAss�nc m�todo = (DCarSetAss�nc) resultado.AsyncState;

			m�todo.EndInvoke(resultado);
		}

		private delegate void AlterarCursorCallback(Cursor cursor);

		/// <summary>
		/// Altera o cursor de forma segura em rela��o � thread.
		/// </summary>
		protected void AlterarCursor(Cursor cursor)
		{
			if (this.InvokeRequired)
			{
				AlterarCursorCallback m�todo = new AlterarCursorCallback(AlterarCursor);
				this.BeginInvoke(m�todo, new object[] { cursor });
			}
			else
				this.Cursor = cursor;
		}

        /// <summary>
        /// Carrega lista de pessoas provenientes de setores espec�ficos
        /// em um per�odo espec�fico.
        /// </summary>
        /// <param name="setores">Lista de setores.</param>
        /// <param name="in�cio">Per�odo inicial.</param>
        /// <param name="final">Per�ofo final.</param>
        /// <exception>Quando setores � nulo</exception>
        private void CarregarDeSetores(Setor[] setores, DateTime in�cio, DateTime final)
        {
            try
            {
                ArrayList itens = new ArrayList();
                DCriEntPesIte m�todoCriarEntidadePessoaItem;

                lock (this)
                {
                    AlterarCursor(Cursors.AppStarting);

                    listaDatasRelevantes.Itens.Clear();
                    m�todoCriarEntidadePessoaItem = new DCriEntPesIte(CriarEntidadePessoaItem);

                    DAdicionarDataRelevante m�todoAdicionarDataRelevante = new DAdicionarDataRelevante(AdicionarDatasRelevantes);
                    DataRelevante[] datas = DataRelevante.ObterPr�ximasDatasRelevantes(null, QuantidadeDeDiasParaObten��oDeDatasRelevantes);

                    CarregaTelefones(datas);

                    object resultado = listaDatasRelevantes.Invoke(m�todoAdicionarDataRelevante, new object[] { datas });
                }

                AlterarCursor(Cursors.Default);
            }
            catch (Exception e)
            {
                AlterarCursor(Cursors.No);

                /* Como esta chamada � ass�ncrona, n�o h� como tratar
                 * erro fora dela.
                 */
                MessageBox.Show("Ocorreu um erro enquanto carregava clientes provenientes de setores espec�ficos."
                    + "\n\n" + e.ToString(), "Erro carregando dados", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
            }
        }

        private static void CarregaTelefones(DataRelevante[] datas)
        {
            List<Entidades.Pessoa.Pessoa> lstPessoas = new List<Entidades.Pessoa.Pessoa>(datas.Length);
            for (int x = 0; x < datas.Length; x++)
                lstPessoas.Add(datas[x].Pessoa);

            Entidades.Pessoa.Telefone.PreencherTelefonesUsandoCache(lstPessoas);
        }

		/// <summary>
		/// Cria um vetor de ListaEntidadePessoaItem a partir de um
		/// vetor de Pessoa.
		/// </summary>
		/// <param name="pessoas">Vetor da classe Pessoa.</param>
		/// <returns>Vetor da classe ListaEntidadePessoaItem.</returns>
		private ListaEntidadePessoaItemBusca [] CriarEntidadePessoaItem(List<Entidades.Pessoa.Pessoa> pessoas)
		{
			ListaEntidadePessoaItemBusca [] itens;

			itens = new ListaEntidadePessoaItemBusca[pessoas.Count];

			for (int i = 0; i < itens.Length; i++)
			{
				itens[i] = new ListaEntidadePessoaItemBusca(pessoas[i]);
				itens[i].Visible = false;
                itens[i].Click += new EventHandler(BaseSele��oCliente_Click);
			}

			return itens;
		}

        void BaseSele��oCliente_Click(object sender, EventArgs e)
        {
            Escolhida(((ListaEntidadePessoaItemBusca) (sender)).Pessoa);
        }

        private void listaDatasRelevantes_Scroll(object sender, ScrollEventArgs e)
        {
            if (listaDatasRelevantes.Itens.Count < datas.Length)
            {
                AguardeDB.Mostrar();
                
                int jaTinham = listaDatasRelevantes.Itens.Count;

                DataRelevante[] restantes = new DataRelevante[datas.Length - jaTinham];
                for (int x = 0; x < restantes.Length; x++)
                {
                    restantes[x] = datas[jaTinham + x];
                }

                // Carrega a lista toda
                AdicionarDatasRelevantes(restantes, null);

                AguardeDB.Fechar();
            }
        }
        
        private DataRelevante[] datas;

        protected void AdicionarDatasRelevantes(DataRelevante[] datas)
        {
            AdicionarDatasRelevantes(datas, QtdM�ximaDatasInicialmenteMostradas);
        }
        /// <summary>
        /// Adiciona datas relevantes na exibi��o.
        /// </summary>
        protected void AdicionarDatasRelevantes(DataRelevante[] datas, int? limite)
        {
            this.datas = datas;

            quadroDatasRelevantes.Visible = false;

            ListaPessoaDataImportante[] itens = new ListaPessoaDataImportante[datas.Length];
            int x = 0;
            
            foreach (DataRelevante data in datas)
                itens[x++] = new ListaPessoaDataImportante(data);

            listaDatasRelevantes.Itens.AddRange(itens);
            
            quadroDatasRelevantes.Visible = listaDatasRelevantes.Itens.Count > 0;
        }

		/// <summary>
		/// Ocorre ao clicar em procurar.
		/// </summary>
		protected void op��oProcurar_Click(object sender, System.EventArgs e)
		{
			Entidades.Pessoa.Pessoa pessoa;
			
			pessoa = ProcurarPessoa.Procurar(this.ParentForm);

			if (pessoa != null)
				Escolhida(pessoa);
		}

        /// <summary>
        /// Ocorre ao clicar em cadastrar.
        /// </summary>
        private void op��oCadastrar_Click(object sender, EventArgs e)
        {
            Entidades.Pessoa.Pessoa novaPessoa = 
            Apresenta��o.Pessoa.Cadastro.CadastroPessoa.MostrarCadastrar();

            if (novaPessoa != null && Escolhida != null)
            {
                Escolhida(novaPessoa);
            }
        }

        protected void DispararEscolha(Entidades.Pessoa.Pessoa pessoa)
        {
            if (Escolhida != null)
                Escolhida(pessoa);
        }

        private void listaDatasRelevantes_PessoaSelecionada(ListaPessoasItem item)
        {
            DispararEscolha(((ListaPessoaDataImportante)item).Data.Pessoa);
        }


        private void op��oImprimir_Click(object sender, EventArgs e)
        {
            Impress�o.JanelaOp��esImpress�o janelaOp��es = new Apresenta��o.Atendimento.Clientes.Impress�o.JanelaOp��esImpress�o();

            if (janelaOp��es.ShowDialog() != DialogResult.OK)
                return;

            // TODO Implementar!
            throw new NotImplementedException();

            //using (RequisitarImpress�o dlg = new RequisitarImpress�o(TipoDocumento.Pessoa))
            //{
            //    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
            //    {
            //        Apresenta��o.Formul�rios.AguardeDB.Mostrar();

            //        DadosRelat�rio dados = new DadosRelat�rioPessoa(
            //            janelaOp��es.Ordem, janelaOp��es.Regi�o);

            //        dados.Tipo = TipoDocumento.Pessoa;
            //        dados.C�pias = dlg.N�meroC�pias;

            //        dlg.ControleImpress�o.RequisitarImpress�o(dlg.Impressora, dados);
            //        Apresenta��o.Formul�rios.AguardeDB.Fechar();

            //    }
            //}

        }

        /// <summary>
        /// Adiciona itens � ListaPessoa.
        /// </summary>
        /// <param name="itens">Itens a serem adicionados.</param>
        private void AdicionarItens(ListaEntidadePessoaItemBusca[] itens)
        {
            listaPessoasBusca.SuspendLayout();
            listaPessoasBusca.Visible = false;
            listaPessoasBusca.Limpar();
            listaPessoasBusca.Adicionar(itens);
            listaPessoasBusca.Visible = true;
            listaPessoasBusca.ResumeLayout();
        }


        /// <summary>
        /// Ocorre quando o coletor recupera nomes
        /// </summary>
        /// <param name="nomes">Nomes recuperados da camada de acesso</param>
        private void Recupera��o(List<Entidades.Pessoa.Pessoa> pessoas)
        {
            try
            {
                if (listaPessoasBusca.InvokeRequired)
                {
                    Recupera��oCallback m�todo = new Recupera��oCallback(Recupera��o);
                    listaPessoasBusca.BeginInvoke(m�todo, new object[] { pessoas });
                }
                else
                {
                    AdicionarItens(CriarEntidadePessoaItem(pessoas));

                    if (ultimaTeclaNaTxtBusca�Enter && Escolhida != null && pessoas.Count > 0)
                        Escolhida(pessoas[0]);
                }
            }
            catch (ObjectDisposedException)
            { /* Ignorar */ }
        }

        private delegate void Recupera��oCallback(List<Entidades.Pessoa.Pessoa> pessoas);

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            coletor.Pesquisar(txtBusca.Text);
        }

        /// Se a �ltima tecla for enter,
        /// assim que a lista for carregada, o primeiro item ser� entrado automaticamente.
        /// </summary>
        private bool ultimaTeclaNaTxtBusca�Enter = false;
        
        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                listaPessoasBusca.SelecionarPeloTeclado();
                listaPessoasBusca.Select();
            }

            ultimaTeclaNaTxtBusca�Enter = (e.KeyCode == Keys.Enter);

            if (!coletor.Pesquisando && ultimaTeclaNaTxtBusca�Enter
                && Escolhida != null && listaPessoasBusca.PrimeiraPessoa != null)
            {
                Escolhida(listaPessoasBusca.PrimeiraPessoa.Pessoa);
            }
        }
	}
}

