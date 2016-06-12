using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresentação.Atendimento.Comum;
using Apresentação.Pessoa.Consultas;
using Entidades.Pessoa;
using Entidades;
using Apresentação.Atendimento.Atendente;
using Entidades.Configuração;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Apresentação.Impressão.Relatórios.Pessoa;
using System.Collections.Generic;
using Apresentação.Formulários;

namespace Apresentação.Atendimento.Clientes
{
	/// <summary>
	/// Base inferior da janela para seleção de clientes.
	/// </summary>
	public class BaseSeleçãoCliente : Apresentação.Formulários.BaseInferior
	{
        private ColetorPessoas coletor;
        public static int QuantidadeDeDiasParaObtençãoDeDatasRelevantes = 1;
        private static int? QtdMáximaDatasInicialmenteMostradas = null;

		/// <summary>
		/// Mensagem exibida enquanto se carrega os dados.
		/// </summary>
		private const string strCarregando = "A lista de clientes está sendo carregada, mas você pode continuar"
			+ " utilizando o sistema normalmente até que o processo termine.";

		/// <summary>
		/// Determina prazo em dias para que uma pessoa seja exibida
		/// desde sua última visita.
		/// </summary>
		private int dias = 90;

		/// <summary>
		/// Delegação para escolha de pessoa.
		/// </summary>
		public delegate void EscolhaPessoa(Entidades.Pessoa.Pessoa pessoa);

		/// <summary>
		/// Evento que ocorre quando uma pessoa é escolhida.
		/// </summary>
		public event EscolhaPessoa Escolhida;

		/// <summary>
		/// Delegação para carga assíncrona de dados.
		/// </summary>
		private delegate void DCarSetAssínc(Setor [] setores, DateTime início, DateTime final);

		/// <summary>
		/// Delegação para carga assíncrona de dados, porém no contexto
		/// da ListaPessoas.
		/// </summary>
		private delegate ListaEntidadePessoaItemBusca [] DCriEntPesIte(List<Entidades.Pessoa.Pessoa> pessoas);
		private delegate void DSinalizarCarga(string descrição);
		private delegate void DAdicionarItens(ICollection c);
        protected delegate void DAdicionarDataRelevante(DataRelevante[] c);
		private Apresentação.Formulários.Quadro quadroClientes;
		private Apresentação.Formulários.Opção opçãoProcurar;
		private Apresentação.Formulários.TítuloBaseInferior título;
        private Apresentação.Formulários.Opção opçãoCadastrar;
        private TableLayoutPanel tableLayoutPanel1;
        private Apresentação.Formulários.QuadroSimples quadroDatasRelevantes;
        private Apresentação.Formulários.Linha linha1;
        private Label label1;
        protected ListaPessoas listaDatasRelevantes;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private ListaPessoasBusca listaPessoasBusca;
        private TextBox txtBusca;
		private System.ComponentModel.IContainer components = null;

		public BaseSeleçãoCliente()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            coletor = new ColetorPessoas(new ColetorPessoas.RecuperaçãoPessoasDelegate(Recuperação));
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
            ultimaTeclaNaTxtBuscaÉEnter = false;
        }

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSeleçãoCliente));
            this.quadroClientes = new Apresentação.Formulários.Quadro();
            this.opçãoProcurar = new Apresentação.Formulários.Opção();
            this.opçãoCadastrar = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listaPessoasBusca = new Apresentação.Atendimento.Comum.ListaPessoasBusca();
            this.quadroDatasRelevantes = new Apresentação.Formulários.QuadroSimples();
            this.listaDatasRelevantes = new Apresentação.Atendimento.Comum.ListaPessoas();
            this.linha1 = new Apresentação.Formulários.Linha();
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
            this.quadroClientes.Controls.Add(this.opçãoProcurar);
            this.quadroClientes.Controls.Add(this.opçãoCadastrar);
            this.quadroClientes.Controls.Add(this.opçãoImprimir);
            this.quadroClientes.Cor = System.Drawing.Color.Black;
            this.quadroClientes.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroClientes.LetraTítulo = System.Drawing.Color.White;
            this.quadroClientes.Location = new System.Drawing.Point(7, 13);
            this.quadroClientes.MostrarBotãoMinMax = false;
            this.quadroClientes.Name = "quadroClientes";
            this.quadroClientes.Size = new System.Drawing.Size(160, 96);
            this.quadroClientes.TabIndex = 0;
            this.quadroClientes.Tamanho = 30;
            this.quadroClientes.Título = "Clientes e Funcionários";
            // 
            // opçãoProcurar
            // 
            this.opçãoProcurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoProcurar.Descrição = "Busca avançada";
            this.opçãoProcurar.Imagem = global::Apresentação.Resource.search4people;
            this.opçãoProcurar.Location = new System.Drawing.Point(7, 30);
            this.opçãoProcurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoProcurar.Name = "opçãoProcurar";
            this.opçãoProcurar.Size = new System.Drawing.Size(150, 16);
            this.opçãoProcurar.TabIndex = 2;
            this.opçãoProcurar.Click += new System.EventHandler(this.opçãoProcurar_Click);
            // 
            // opçãoCadastrar
            // 
            this.opçãoCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCadastrar.Descrição = "Cadastrar";
            this.opçãoCadastrar.Imagem = global::Apresentação.Resource.newfolder1;
            this.opçãoCadastrar.Location = new System.Drawing.Point(7, 50);
            this.opçãoCadastrar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoCadastrar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCadastrar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCadastrar.Name = "opçãoCadastrar";
            this.opçãoCadastrar.Privilégio = Entidades.Privilégio.Permissão.CadastroEditar;
            this.opçãoCadastrar.Size = new System.Drawing.Size(150, 16);
            this.opçãoCadastrar.TabIndex = 3;
            this.opçãoCadastrar.Click += new System.EventHandler(this.opçãoCadastrar_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir cadastros...";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 70);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Privilégio = Entidades.Privilégio.Permissão.CadastroEditar;
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 4;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = ((System.Drawing.Image)(resources.GetObject("título.Imagem")));
            this.título.Location = new System.Drawing.Point(200, 8);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(544, 70);
            this.título.TabIndex = 10;
            this.título.Título = "Busca de clientes ou funcionários";
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
            this.listaDatasRelevantes.PessoaSelecionada += new Apresentação.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaDatasRelevantes_PessoaSelecionada);
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
            // BaseSeleçãoCliente
            // 
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.título);
            this.Name = "BaseSeleçãoCliente";
            this.Size = new System.Drawing.Size(760, 400);
            this.Controls.SetChildIndex(this.título, 0);
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
		/// Título da base inferior.
		/// </summary>
		[DefaultValue("Seleção de cliente")]
		public string Título
		{
			get { return título.Título; }
			set { título.Título = value; }
		}

		/// <summary>
		/// Descrição da base inferior.
		/// </summary>
		[DefaultValue("Escolha o cliente desejado.")]
		public string Descrição
		{
			get { return título.Descrição; }
			set { título.Descrição = value; }
		}

        ///// <summary>
        ///// Itens exibidos.
        ///// </summary>
        //public ColeçãoListaPessoasItem ItensExibidos
        //{
        //    get { return listaPessoas.Itens; }
        //}

		/// <summary>
		/// Prazo em dias para que uma pessoa seja exibida
		/// desde sua última visita.
		/// </summary>
		[DefaultValue(90), Description("Prazo em dias para que uma pessoa seja exibida desde sua última visita.")]
		public int Prazo
		{
			get { return dias; }
			set
			{
				if (value <= 0)
					throw new ArgumentException("O valor para o prazo não pode ser negativo.");

				dias = value;
			}
		}

		/// <summary>
		/// Período inicial.
		/// </summary>
		public DateTime PeríodoInicial
		{
			get { return DateTime.Now.Subtract(TimeSpan.FromDays(dias)); }
		}

		#endregion
		
		#region Tratamento de eventos

		/// <summary>
		/// Ocorre ao selecionar uma pessoa.
		/// </summary>
		/// <param name="item">Item selecionado.</param>
		protected virtual void listaPessoas_PessoaSelecionada(Apresentação.Atendimento.Comum.ListaPessoasItem item)
		{
			Entidades.Pessoa.Pessoa pessoa;

		    pessoa = ((ListaEntidadePessoaItem) item).Pessoa;

			Escolhida(pessoa);
		}

		#endregion

        public override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            base.AoCarregarCompletamente(splash);
            HandleCreated += new EventHandler(BaseSeleçãoCliente_HandleCreated);
        }

        void BaseSeleçãoCliente_HandleCreated(object sender, EventArgs e)
        {
            coletor.Pesquisar("");
        }


        /// <summary>
        /// Carrega lista de pessoas provenientes de setores específicos.
        /// </summary>
        /// <param name="setores">Lista de setores.</param>
        public void CarregarDeSetores(params Setor[] setores)
        {
            if (setores == null)
                throw new ArgumentNullException("setores");

            DCarSetAssínc método;

            método = new DCarSetAssínc(CarregarDeSetores);
            método.BeginInvoke(setores, PeríodoInicial, DateTime.MaxValue, new AsyncCallback(CargaCallback), método);
        }

		/// <summary>
		/// Finaliza carga assíncrona.
		/// </summary>
		private void CargaCallback(IAsyncResult resultado)
		{
			DCarSetAssínc método = (DCarSetAssínc) resultado.AsyncState;

			método.EndInvoke(resultado);
		}

		private delegate void AlterarCursorCallback(Cursor cursor);

		/// <summary>
		/// Altera o cursor de forma segura em relação à thread.
		/// </summary>
		protected void AlterarCursor(Cursor cursor)
		{
			if (this.InvokeRequired)
			{
				AlterarCursorCallback método = new AlterarCursorCallback(AlterarCursor);
				this.BeginInvoke(método, new object[] { cursor });
			}
			else
				this.Cursor = cursor;
		}

        /// <summary>
        /// Carrega lista de pessoas provenientes de setores específicos
        /// em um período específico.
        /// </summary>
        /// <param name="setores">Lista de setores.</param>
        /// <param name="início">Período inicial.</param>
        /// <param name="final">Períofo final.</param>
        /// <exception>Quando setores é nulo</exception>
        private void CarregarDeSetores(Setor[] setores, DateTime início, DateTime final)
        {
            try
            {
                ArrayList itens = new ArrayList();
                DCriEntPesIte métodoCriarEntidadePessoaItem;

                lock (this)
                {
                    AlterarCursor(Cursors.AppStarting);

                    listaDatasRelevantes.Itens.Clear();
                    métodoCriarEntidadePessoaItem = new DCriEntPesIte(CriarEntidadePessoaItem);

                    DAdicionarDataRelevante métodoAdicionarDataRelevante = new DAdicionarDataRelevante(AdicionarDatasRelevantes);
                    DataRelevante[] datas = DataRelevante.ObterPróximasDatasRelevantes(null, QuantidadeDeDiasParaObtençãoDeDatasRelevantes);

                    CarregaTelefones(datas);

                    object resultado = listaDatasRelevantes.Invoke(métodoAdicionarDataRelevante, new object[] { datas });
                }

                AlterarCursor(Cursors.Default);
            }
            catch (Exception e)
            {
                AlterarCursor(Cursors.No);

                /* Como esta chamada é assíncrona, não há como tratar
                 * erro fora dela.
                 */
                MessageBox.Show("Ocorreu um erro enquanto carregava clientes provenientes de setores específicos."
                    + "\n\n" + e.ToString(), "Erro carregando dados", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
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
                itens[i].Click += new EventHandler(BaseSeleçãoCliente_Click);
			}

			return itens;
		}

        void BaseSeleçãoCliente_Click(object sender, EventArgs e)
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
            AdicionarDatasRelevantes(datas, QtdMáximaDatasInicialmenteMostradas);
        }
        /// <summary>
        /// Adiciona datas relevantes na exibição.
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
		protected void opçãoProcurar_Click(object sender, System.EventArgs e)
		{
			Entidades.Pessoa.Pessoa pessoa;
			
			pessoa = ProcurarPessoa.Procurar(this.ParentForm);

			if (pessoa != null)
				Escolhida(pessoa);
		}

        /// <summary>
        /// Ocorre ao clicar em cadastrar.
        /// </summary>
        private void opçãoCadastrar_Click(object sender, EventArgs e)
        {
            Entidades.Pessoa.Pessoa novaPessoa = 
            Apresentação.Pessoa.Cadastro.CadastroPessoa.MostrarCadastrar();

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


        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            Impressão.JanelaOpçõesImpressão janelaOpções = new Apresentação.Atendimento.Clientes.Impressão.JanelaOpçõesImpressão();

            if (janelaOpções.ShowDialog() != DialogResult.OK)
                return;

            // TODO Implementar!
            throw new NotImplementedException();

            //using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento.Pessoa))
            //{
            //    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
            //    {
            //        Apresentação.Formulários.AguardeDB.Mostrar();

            //        DadosRelatório dados = new DadosRelatórioPessoa(
            //            janelaOpções.Ordem, janelaOpções.Região);

            //        dados.Tipo = TipoDocumento.Pessoa;
            //        dados.Cópias = dlg.NúmeroCópias;

            //        dlg.ControleImpressão.RequisitarImpressão(dlg.Impressora, dados);
            //        Apresentação.Formulários.AguardeDB.Fechar();

            //    }
            //}

        }

        /// <summary>
        /// Adiciona itens à ListaPessoa.
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
        private void Recuperação(List<Entidades.Pessoa.Pessoa> pessoas)
        {
            try
            {
                if (listaPessoasBusca.InvokeRequired)
                {
                    RecuperaçãoCallback método = new RecuperaçãoCallback(Recuperação);
                    listaPessoasBusca.BeginInvoke(método, new object[] { pessoas });
                }
                else
                {
                    AdicionarItens(CriarEntidadePessoaItem(pessoas));

                    if (ultimaTeclaNaTxtBuscaÉEnter && Escolhida != null && pessoas.Count > 0)
                        Escolhida(pessoas[0]);
                }
            }
            catch (ObjectDisposedException)
            { /* Ignorar */ }
        }

        private delegate void RecuperaçãoCallback(List<Entidades.Pessoa.Pessoa> pessoas);

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            coletor.Pesquisar(txtBusca.Text);
        }

        /// Se a última tecla for enter,
        /// assim que a lista for carregada, o primeiro item será entrado automaticamente.
        /// </summary>
        private bool ultimaTeclaNaTxtBuscaÉEnter = false;
        
        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                listaPessoasBusca.SelecionarPeloTeclado();
                listaPessoasBusca.Select();
            }

            ultimaTeclaNaTxtBuscaÉEnter = (e.KeyCode == Keys.Enter);

            if (!coletor.Pesquisando && ultimaTeclaNaTxtBuscaÉEnter
                && Escolhida != null && listaPessoasBusca.PrimeiraPessoa != null)
            {
                Escolhida(listaPessoasBusca.PrimeiraPessoa.Pessoa);
            }
        }
	}
}

