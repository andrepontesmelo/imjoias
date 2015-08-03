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
using Neg�cio.Importa��o.EntidadesAntigas;
using Apresenta��o.Formul�rios.Impress�o;
using Apresenta��o.Impress�o;
using Apresenta��o.Impress�o.Relat�rios.Pessoa;

namespace Apresenta��o.Atendimento.Clientes
{
	/// <summary>
	/// Base inferior da janela para sele��o de clientes.
	/// </summary>
	public class BaseSele��oCliente : Apresenta��o.Formul�rios.BaseInferior
	{
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
		private delegate ListaEntidadePessoaItem [] DCriEntPesIte(Entidades.Pessoa.Pessoa [] pessoas);
		private delegate void DSinalizarCarga(string descri��o);
		private delegate void DAdicionarItens(ICollection c);
        protected delegate void DAdicionarDataRelevante(DataRelevante[] c);
		protected Apresenta��o.Atendimento.Comum.ListaPessoas listaPessoas;
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
        //private Apresenta��o.Formul�rios.Quadro quadroTransposi��o;
        //private Apresenta��o.Formul�rios.Op��o op��oImportar;
		private System.ComponentModel.IContainer components = null;

		public BaseSele��oCliente()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSele��oCliente));
            this.listaPessoas = new Apresenta��o.Atendimento.Comum.ListaPessoas();
            this.quadroClientes = new Apresenta��o.Formul�rios.Quadro();
            this.op��oImprimir = new Apresenta��o.Formul�rios.Op��o();
            this.op��oProcurar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oCadastrar = new Apresenta��o.Formul�rios.Op��o();
            this.t�tulo = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quadroDatasRelevantes = new Apresenta��o.Formul�rios.QuadroSimples();
            this.listaDatasRelevantes = new Apresenta��o.Atendimento.Comum.ListaPessoas();
            this.linha1 = new Apresenta��o.Formul�rios.Linha();
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
            this.listaPessoas.PessoaSelecionada += new Apresenta��o.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaPessoas_PessoaSelecionada);
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
            this.quadroClientes.Size = new System.Drawing.Size(160, 101);
            this.quadroClientes.TabIndex = 0;
            this.quadroClientes.Tamanho = 30;
            this.quadroClientes.T�tulo = "Pessoa";
            // 
            // op��oImprimir
            // 
            this.op��oImprimir.BackColor = System.Drawing.Color.Transparent;
            this.op��oImprimir.Descri��o = "Imprimir cadastros...";
            this.op��oImprimir.Imagem = global::Apresenta��o.Atendimento.Properties.Resources.Impressora_3D;
            this.op��oImprimir.Location = new System.Drawing.Point(7, 80);
            this.op��oImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oImprimir.Name = "op��oImprimir";
            this.op��oImprimir.Privil�gio = Entidades.Privil�gio.Permiss�o.CadastroEditar;
            this.op��oImprimir.Size = new System.Drawing.Size(150, 24);
            this.op��oImprimir.TabIndex = 4;
            this.op��oImprimir.Click += new System.EventHandler(this.op��oImprimir_Click);
            // 
            // op��oProcurar
            // 
            this.op��oProcurar.BackColor = System.Drawing.Color.Transparent;
            this.op��oProcurar.Descri��o = "Procurar outra pessoa...";
            this.op��oProcurar.Imagem = global::Apresenta��o.Atendimento.Properties.Resources.search4people;
            this.op��oProcurar.Location = new System.Drawing.Point(8, 32);
            this.op��oProcurar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oProcurar.Name = "op��oProcurar";
            this.op��oProcurar.Size = new System.Drawing.Size(150, 24);
            this.op��oProcurar.TabIndex = 2;
            this.op��oProcurar.Click += new System.EventHandler(this.op��oProcurar_Click);
            // 
            // op��oCadastrar
            // 
            this.op��oCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.op��oCadastrar.Descri��o = "Cadastrar nova pessoa...";
            this.op��oCadastrar.Imagem = global::Apresenta��o.Atendimento.Properties.Resources.newfolder;
            this.op��oCadastrar.Location = new System.Drawing.Point(7, 56);
            this.op��oCadastrar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oCadastrar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oCadastrar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oCadastrar.Name = "op��oCadastrar";
            this.op��oCadastrar.Privil�gio = Entidades.Privil�gio.Permiss�o.CadastroEditar;
            this.op��oCadastrar.Size = new System.Drawing.Size(150, 24);
            this.op��oCadastrar.TabIndex = 3;
            this.op��oCadastrar.Click += new System.EventHandler(this.op��oCadastrar_Click);
            // 
            // t�tulo
            // 
            this.t�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tulo.BackColor = System.Drawing.Color.White;
            this.t�tulo.Descri��o = "Escolha a pessoa desejada.";
            this.t�tulo.Imagem = ((System.Drawing.Image)(resources.GetObject("t�tulo.Imagem")));
            this.t�tulo.Location = new System.Drawing.Point(200, 8);
            this.t�tulo.Name = "t�tulo";
            this.t�tulo.Size = new System.Drawing.Size(544, 70);
            this.t�tulo.TabIndex = 10;
            this.t�tulo.T�tulo = "Sele��o de pessoa";
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
            this.listaDatasRelevantes.PessoaSelecionada += new Apresenta��o.Atendimento.Comum.ListaPessoas.PessoaSelecionadaDelegate(this.listaDatasRelevantes_PessoaSelecionada);
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
            // BaseSele��oCliente
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.t�tulo);
            this.Name = "BaseSele��oCliente";
            this.Size = new System.Drawing.Size(760, 400);
            this.Controls.SetChildIndex(this.t�tulo, 0);
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

		/// <summary>
		/// Itens exibidos.
		/// </summary>
		public Cole��oListaPessoasItem ItensExibidos
		{
			get { return listaPessoas.Itens; }
		}

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

        protected override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            //Configura��oGlobal<bool> liberarImporta��o = new Configura��oGlobal<bool>("Liberar importa��o", false);

            //quadroTransposi��o.Visible = liberarImporta��o.Valor;
        }

        
		/// <summary>
		/// Carrega lista de pessoas provenientes de setores espec�ficos.
		/// </summary>
		/// <param name="setores">Lista de setores.</param>
		public void CarregarDeSetores(params Setor [] setores)
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
        private void CarregarDeSetores(Setor [] setores, DateTime in�cio, DateTime final)
		{

			try
			{
				ArrayList      itens          = new ArrayList();
				DCriEntPesIte  m�todoCriarEntidadePessoaItem;

				lock (this)
				{
					AlterarCursor(Cursors.AppStarting);

                    listaPessoas.Itens.Clear();
                    listaDatasRelevantes.Itens.Clear();

                    SinalizarCarga();

					m�todoCriarEntidadePessoaItem = new DCriEntPesIte(CriarEntidadePessoaItem);

					foreach (Setor setor in setores)
                    {
                        /*
                         * Obter pessoas.
                         */
                        Entidades.Pessoa.Pessoa [] pessoas;

                        if (setor.C�digo == Setor.ObterSetor(Setor.SetorSistema.Representante).C�digo)
                            pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(setor);
                        else
                            pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(setor, in�cio, final);

						/* O framework dotNet exige que controles vinculados sejam constru�dos
						 * em um mesmo contexto. Como este m�todo � chamado de forma
						 * ass�ncrona, o contexto do m�todo e do controle s�o diferentes,
						 * exigindo construir os itens no contexto de ListaSa�das.
						 */
						object resultado;
					
						resultado = listaPessoas.Invoke(m�todoCriarEntidadePessoaItem, new object [] { pessoas });

						itens.AddRange((ICollection) resultado);

                        /*
                         * Obter datas relevantes.
                         */
                        DAdicionarDataRelevante m�todoAdicionarDataRelevante = new DAdicionarDataRelevante(AdicionarDatasRelevantes);
                        DataRelevante[] datas = DataRelevante.ObterPr�ximasDatasRelevantes(setor);
                        resultado = listaDatasRelevantes.Invoke(m�todoAdicionarDataRelevante, new object[] { datas });
					}

					DAdicionarItens m�todo = new DAdicionarItens(AdicionarItens);
					listaPessoas.BeginInvoke(m�todo , new object [] { itens });
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
		/// Adiciona itens � ListaPessoa.
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
        /// Adiciona datas relevantes na exibi��o.
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
		/// Sinaliza in�cio de carga de dados.
		/// </summary>
		private void SinalizarCarga()
		{
			DSinalizarCarga m�todo;

			m�todo = new DSinalizarCarga(listaPessoas.SinalizarCarga);
			listaPessoas.BeginInvoke(m�todo, new object [] { strCarregando });
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
            Apresenta��o.Pessoa.Cadastro.CadastroPessoa.MostrarCadastrar();
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
            

            using (RequisitarImpress�o dlg = new RequisitarImpress�o(TipoDocumento.Pessoa))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    Apresenta��o.Formul�rios.AguardeDB.Mostrar();

                    DadosRelat�rio dados = new DadosRelat�rioPessoa(
                        janelaOp��es.Ordem, janelaOp��es.Regi�o);

                    dados.Tipo = TipoDocumento.Pessoa;
                    dados.C�pias = dlg.N�meroC�pias;

                    dlg.ControleImpress�o.RequisitarImpress�o(dlg.Impressora, dados);
                    Apresenta��o.Formul�rios.AguardeDB.Fechar();

                }
            }

        }

        //private void op��oImportar_Click(object sender, EventArgs e)
        //{
        //    using (Importa��o.EscolherClienteAntigo dlg = new Apresenta��o.Atendimento.Clientes.Importa��o.EscolherClienteAntigo())
        //    {
        //        if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
        //        {
        //            Entidades.Pessoa.Pessoa pessoa = Entidades.Pessoa.Pessoa.ObterPessoaSemCache((ulong)dlg.C�digo);

        //            if (pessoa != null)
        //            {
        //                MessageBox.Show(
        //                    ParentForm,
        //                    "Aten��o! Essa pessoa j� havia sido importada anteriormente!",
        //                    "Importa��o de cadastro",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else 
        //            {
        //                CadCli velho = Neg�cio.Importa��o.EntidadesAntigas.CadCli.Obter(dlg.C�digo);

        //                if (velho == null)
        //                {
        //                    MessageBox.Show("Codigo nao encontrado. Caso seja cliente novo, ele deve ser recadastrado. Caso contrario, possivelmente tinha cadastro duplicado. Faca uma procura pelo nome.", "Nao encontrado");
        //                    return;
        //                }

        //                 if (Neg�cio.Importa��o.Cliente.Importar(velho, true))
        //                     pessoa = Entidades.Pessoa.Pessoa.ObterPessoaSemCache((ulong)dlg.C�digo);
        //            }

        //            if (pessoa != null)
        //                Escolhida(pessoa);
        //        }
        //    }
        //}
	}
}

