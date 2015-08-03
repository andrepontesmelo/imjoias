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
using Negócio.Importação.EntidadesAntigas;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Apresentação.Impressão.Relatórios.Pessoa;

namespace Apresentação.Atendimento.Clientes
{
	/// <summary>
	/// Base inferior da janela para seleção de clientes.
	/// </summary>
	public class BaseSeleçãoCliente : Apresentação.Formulários.BaseInferior
	{
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
		private delegate ListaEntidadePessoaItem [] DCriEntPesIte(Entidades.Pessoa.Pessoa [] pessoas);
		private delegate void DSinalizarCarga(string descrição);
		private delegate void DAdicionarItens(ICollection c);
        protected delegate void DAdicionarDataRelevante(DataRelevante[] c);
		protected Apresentação.Atendimento.Comum.ListaPessoas listaPessoas;
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
        //private Apresentação.Formulários.Quadro quadroTransposição;
        //private Apresentação.Formulários.Opção opçãoImportar;
		private System.ComponentModel.IContainer components = null;

		public BaseSeleçãoCliente()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSeleçãoCliente));
            this.listaPessoas = new Apresentação.Atendimento.Comum.ListaPessoas();
            this.quadroClientes = new Apresentação.Formulários.Quadro();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoProcurar = new Apresentação.Formulários.Opção();
            this.opçãoCadastrar = new Apresentação.Formulários.Opção();
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quadroDatasRelevantes = new Apresentação.Formulários.QuadroSimples();
            this.listaDatasRelevantes = new Apresentação.Atendimento.Comum.ListaPessoas();
            this.linha1 = new Apresentação.Formulários.Linha();
            this.label1 = new System.Windows.Forms.Label();
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
            // listaPessoas
            // 
            this.listaPessoas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaPessoas.AutoScroll = true;
            this.listaPessoas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listaPessoas.Location = new System.Drawing.Point(3, 3);
            this.listaPessoas.Name = "listaPessoas";
            this.listaPessoas.Size = new System.Drawing.Size(332, 308);
            this.listaPessoas.TabIndex = 0;
            this.listaPessoas.PessoaSelecionada += new Apresentação.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaPessoas_PessoaSelecionada);
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
            this.quadroClientes.Size = new System.Drawing.Size(160, 101);
            this.quadroClientes.TabIndex = 0;
            this.quadroClientes.Tamanho = 30;
            this.quadroClientes.Título = "Pessoa";
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir cadastros...";
            this.opçãoImprimir.Imagem = global::Apresentação.Atendimento.Properties.Resources.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 80);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Privilégio = Entidades.Privilégio.Permissão.CadastroEditar;
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 4;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoProcurar
            // 
            this.opçãoProcurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoProcurar.Descrição = "Procurar outra pessoa...";
            this.opçãoProcurar.Imagem = global::Apresentação.Atendimento.Properties.Resources.search4people;
            this.opçãoProcurar.Location = new System.Drawing.Point(8, 32);
            this.opçãoProcurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoProcurar.Name = "opçãoProcurar";
            this.opçãoProcurar.Size = new System.Drawing.Size(150, 24);
            this.opçãoProcurar.TabIndex = 2;
            this.opçãoProcurar.Click += new System.EventHandler(this.opçãoProcurar_Click);
            // 
            // opçãoCadastrar
            // 
            this.opçãoCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoCadastrar.Descrição = "Cadastrar nova pessoa...";
            this.opçãoCadastrar.Imagem = global::Apresentação.Atendimento.Properties.Resources.newfolder;
            this.opçãoCadastrar.Location = new System.Drawing.Point(7, 56);
            this.opçãoCadastrar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoCadastrar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoCadastrar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoCadastrar.Name = "opçãoCadastrar";
            this.opçãoCadastrar.Privilégio = Entidades.Privilégio.Permissão.CadastroEditar;
            this.opçãoCadastrar.Size = new System.Drawing.Size(150, 24);
            this.opçãoCadastrar.TabIndex = 3;
            this.opçãoCadastrar.Click += new System.EventHandler(this.opçãoCadastrar_Click);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Escolha a pessoa desejada.";
            this.título.Imagem = ((System.Drawing.Image)(resources.GetObject("título.Imagem")));
            this.título.Location = new System.Drawing.Point(200, 8);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(544, 70);
            this.título.TabIndex = 10;
            this.título.Título = "Seleção de pessoa";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.quadroDatasRelevantes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listaPessoas, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(200, 69);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 311);
            this.tableLayoutPanel1.TabIndex = 11;
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
            this.quadroDatasRelevantes.Location = new System.Drawing.Point(341, 3);
            this.quadroDatasRelevantes.Name = "quadroDatasRelevantes";
            this.quadroDatasRelevantes.Size = new System.Drawing.Size(192, 308);
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
            this.listaDatasRelevantes.Location = new System.Drawing.Point(3, 35);
            this.listaDatasRelevantes.Name = "listaDatasRelevantes";
            this.listaDatasRelevantes.Size = new System.Drawing.Size(186, 270);
            this.listaDatasRelevantes.TabIndex = 2;
            this.listaDatasRelevantes.PessoaSelecionada += new Apresentação.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaDatasRelevantes_PessoaSelecionada);
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
            // BaseSeleçãoCliente
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.título);
            this.Name = "BaseSeleçãoCliente";
            this.Size = new System.Drawing.Size(760, 400);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroClientes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.quadroDatasRelevantes.ResumeLayout(false);
            this.quadroDatasRelevantes.PerformLayout();
            this.ResumeLayout(false);

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

		/// <summary>
		/// Itens exibidos.
		/// </summary>
		public ColeçãoListaPessoasItem ItensExibidos
		{
			get { return listaPessoas.Itens; }
		}

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

        protected override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            //ConfiguraçãoGlobal<bool> liberarImportação = new ConfiguraçãoGlobal<bool>("Liberar importação", false);

            //quadroTransposição.Visible = liberarImportação.Valor;
        }

        
		/// <summary>
		/// Carrega lista de pessoas provenientes de setores específicos.
		/// </summary>
		/// <param name="setores">Lista de setores.</param>
		public void CarregarDeSetores(params Setor [] setores)
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
        private void CarregarDeSetores(Setor [] setores, DateTime início, DateTime final)
		{

			try
			{
				ArrayList      itens          = new ArrayList();
				DCriEntPesIte  métodoCriarEntidadePessoaItem;

				lock (this)
				{
					AlterarCursor(Cursors.AppStarting);

                    listaPessoas.Itens.Clear();
                    listaDatasRelevantes.Itens.Clear();

                    SinalizarCarga();

					métodoCriarEntidadePessoaItem = new DCriEntPesIte(CriarEntidadePessoaItem);

					foreach (Setor setor in setores)
                    {
                        /*
                         * Obter pessoas.
                         */
                        Entidades.Pessoa.Pessoa [] pessoas;

                        if (setor.Código == Setor.ObterSetor(Setor.SetorSistema.Representante).Código)
                            pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(setor);
                        else
                            pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(setor, início, final);

						/* O framework dotNet exige que controles vinculados sejam construídos
						 * em um mesmo contexto. Como este método é chamado de forma
						 * assíncrona, o contexto do método e do controle são diferentes,
						 * exigindo construir os itens no contexto de ListaSaídas.
						 */
						object resultado;
					
						resultado = listaPessoas.Invoke(métodoCriarEntidadePessoaItem, new object [] { pessoas });

						itens.AddRange((ICollection) resultado);

                        /*
                         * Obter datas relevantes.
                         */
                        DAdicionarDataRelevante métodoAdicionarDataRelevante = new DAdicionarDataRelevante(AdicionarDatasRelevantes);
                        DataRelevante[] datas = DataRelevante.ObterPróximasDatasRelevantes(setor);
                        resultado = listaDatasRelevantes.Invoke(métodoAdicionarDataRelevante, new object[] { datas });
					}

					DAdicionarItens método = new DAdicionarItens(AdicionarItens);
					listaPessoas.BeginInvoke(método , new object [] { itens });
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

		/// <summary>
		/// Cria um vetor de ListaEntidadePessoaItem a partir de um
		/// vetor de Pessoa.
		/// </summary>
		/// <param name="pessoas">Vetor da classe Pessoa.</param>
		/// <returns>Vetor da classe ListaEntidadePessoaItem.</returns>
		private ListaEntidadePessoaItem [] CriarEntidadePessoaItem(Entidades.Pessoa.Pessoa [] pessoas)
		{
			ListaEntidadePessoaItem [] itens;

			itens = new ListaEntidadePessoaItem[pessoas.Length];

			for (int i = 0; i < itens.Length; i++)
			{
				itens[i] = new ListaEntidadePessoaItem(pessoas[i]);
				itens[i].Visible = false;
			}

			return itens;
		}

		/// <summary>
		/// Adiciona itens à ListaPessoa.
		/// </summary>
		/// <param name="itens">Itens a serem adicionados.</param>
		private void AdicionarItens(ICollection itens)
		{
			listaPessoas.Dessinalizar();

			lock (listaPessoas.Itens.SyncRoot)
			{
				listaPessoas.Itens.Clear();
				listaPessoas.Itens.AddRange(itens);
			}

			foreach (ListaPessoasItem item in itens)
				item.Visible = true;
		}

        /// <summary>
        /// Adiciona datas relevantes na exibição.
        /// </summary>
        protected void AdicionarDatasRelevantes(DataRelevante[] datas)
        {
            foreach (DataRelevante data in datas)
            {
                ListaPessoaDataImportante item = new ListaPessoaDataImportante(data);
                item.Visible = false;
                listaDatasRelevantes.Itens.Add(item);
            }

            foreach (ListaPessoasItem item in listaDatasRelevantes.Itens)
                item.Visible = true;

            quadroDatasRelevantes.Visible = listaDatasRelevantes.Itens.Count > 0;
        }

        /// <summary>
		/// Sinaliza início de carga de dados.
		/// </summary>
		private void SinalizarCarga()
		{
			DSinalizarCarga método;

			método = new DSinalizarCarga(listaPessoas.SinalizarCarga);
			listaPessoas.BeginInvoke(método, new object [] { strCarregando });
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
            Apresentação.Pessoa.Cadastro.CadastroPessoa.MostrarCadastrar();
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
            

            using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento.Pessoa))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    Apresentação.Formulários.AguardeDB.Mostrar();

                    DadosRelatório dados = new DadosRelatórioPessoa(
                        janelaOpções.Ordem, janelaOpções.Região);

                    dados.Tipo = TipoDocumento.Pessoa;
                    dados.Cópias = dlg.NúmeroCópias;

                    dlg.ControleImpressão.RequisitarImpressão(dlg.Impressora, dados);
                    Apresentação.Formulários.AguardeDB.Fechar();

                }
            }

        }

        //private void opçãoImportar_Click(object sender, EventArgs e)
        //{
        //    using (Importação.EscolherClienteAntigo dlg = new Apresentação.Atendimento.Clientes.Importação.EscolherClienteAntigo())
        //    {
        //        if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
        //        {
        //            Entidades.Pessoa.Pessoa pessoa = Entidades.Pessoa.Pessoa.ObterPessoaSemCache((ulong)dlg.Código);

        //            if (pessoa != null)
        //            {
        //                MessageBox.Show(
        //                    ParentForm,
        //                    "Atenção! Essa pessoa já havia sido importada anteriormente!",
        //                    "Importação de cadastro",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else 
        //            {
        //                CadCli velho = Negócio.Importação.EntidadesAntigas.CadCli.Obter(dlg.Código);

        //                if (velho == null)
        //                {
        //                    MessageBox.Show("Codigo nao encontrado. Caso seja cliente novo, ele deve ser recadastrado. Caso contrario, possivelmente tinha cadastro duplicado. Faca uma procura pelo nome.", "Nao encontrado");
        //                    return;
        //                }

        //                 if (Negócio.Importação.Cliente.Importar(velho, true))
        //                     pessoa = Entidades.Pessoa.Pessoa.ObterPessoaSemCache((ulong)dlg.Código);
        //            }

        //            if (pessoa != null)
        //                Escolhida(pessoa);
        //        }
        //    }
        //}
	}
}

