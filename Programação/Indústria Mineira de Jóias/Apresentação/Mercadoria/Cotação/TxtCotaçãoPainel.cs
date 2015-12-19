using System;
using System.Runtime.Remoting.Lifetime;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Entidades.Configuração;


namespace Apresentação.Mercadoria.Cotação
{
	/// <summary>
	/// Painel para exibição de cotações no TxtCotação.
	/// </summary>
	internal class TxtCotaçãoPainel : System.Windows.Forms.UserControl
	{
		// Atributos
		private Dictionary<ListViewItem, Entidades.Financeiro.Cotação>	hashListViewItemCotação;		// Armazena as cotações. chave: item da list view.
		private Dictionary<double, ListViewItem>    hashValorListViewItem;			// chave: valor double da cotação.
        private Entidades.Financeiro.Cotação                   seleção = null;
        private Moeda                               moeda;

		// Controles
		private System.Windows.Forms.Panel          painelBase;
		private System.Windows.Forms.Panel          painelSuperior;
		private System.Windows.Forms.Label          labelData;
		private System.Windows.Forms.Panel          painelInferior;
		private System.Windows.Forms.ListView       lista;
		private System.Windows.Forms.ColumnHeader   colHora;
		private System.Windows.Forms.ColumnHeader   colCotação;
		private System.Windows.Forms.ColumnHeader   colFuncionário;
		private System.Windows.Forms.DateTimePicker data;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// Eventos
		public event EventHandler SelectedIndexChanged;
		public event EventHandler ListaDoubleClick;

		public TxtCotaçãoPainel()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            data.Value = DadosGlobais.Instância.HoraDataAtual;
		}

        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value;

                CarregarItens(data.Value);
            }
        }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.painelBase = new System.Windows.Forms.Panel();
            this.painelInferior = new System.Windows.Forms.Panel();
            this.lista = new System.Windows.Forms.ListView();
            this.colHora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCotação = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncionário = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.painelSuperior = new System.Windows.Forms.Panel();
            this.labelData = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.painelBase.SuspendLayout();
            this.painelInferior.SuspendLayout();
            this.painelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // painelBase
            // 
            this.painelBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.painelBase.Controls.Add(this.painelInferior);
            this.painelBase.Controls.Add(this.painelSuperior);
            this.painelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelBase.Location = new System.Drawing.Point(0, 0);
            this.painelBase.Name = "painelBase";
            this.painelBase.Size = new System.Drawing.Size(216, 96);
            this.painelBase.TabIndex = 0;
            // 
            // painelInferior
            // 
            this.painelInferior.Controls.Add(this.lista);
            this.painelInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelInferior.Location = new System.Drawing.Point(0, 24);
            this.painelInferior.Name = "painelInferior";
            this.painelInferior.Size = new System.Drawing.Size(214, 70);
            this.painelInferior.TabIndex = 5;
            // 
            // lista
            // 
            this.lista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHora,
            this.colCotação,
            this.colFuncionário});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(214, 70);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colHora
            // 
            this.colHora.Text = "Hora";
            this.colHora.Width = 36;
            // 
            // colCotação
            // 
            this.colCotação.Text = "Cotação";
            this.colCotação.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCotação.Width = 70;
            // 
            // colFuncionário
            // 
            this.colFuncionário.Text = "Responsável";
            this.colFuncionário.Width = 105;
            // 
            // painelSuperior
            // 
            this.painelSuperior.BackColor = System.Drawing.SystemColors.ControlDark;
            this.painelSuperior.Controls.Add(this.labelData);
            this.painelSuperior.Controls.Add(this.data);
            this.painelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.painelSuperior.Location = new System.Drawing.Point(0, 0);
            this.painelSuperior.Name = "painelSuperior";
            this.painelSuperior.Size = new System.Drawing.Size(214, 24);
            this.painelSuperior.TabIndex = 3;
            // 
            // labelData
            // 
            this.labelData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(56, 6);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(33, 13);
            this.labelData.TabIndex = 1;
            this.labelData.Text = "Data:";
            // 
            // data
            // 
            this.data.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.data.CustomFormat = "dd/MM/yy";
            this.data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.data.Location = new System.Drawing.Point(88, 2);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(72, 20);
            this.data.TabIndex = 0;
            this.data.ValueChanged += new System.EventHandler(this.data_ValueChanged);
            // 
            // TxtCotaçãoPainel
            // 
            this.Controls.Add(this.painelBase);
            this.Name = "TxtCotaçãoPainel";
            this.Size = new System.Drawing.Size(216, 96);
            this.painelBase.ResumeLayout(false);
            this.painelInferior.ResumeLayout(false);
            this.painelSuperior.ResumeLayout(false);
            this.painelSuperior.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao carregar o controle.
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}

        #region Propriedades

        /// <summary>
		/// Determina se mostra cabeçalhos da lista.
		/// </summary>
		[DefaultValue(true)]
		public bool MostrarCabeçalho
		{
			get 
			{
				return lista.HeaderStyle == ColumnHeaderStyle.Nonclickable;
			}
			set
			{
				lista.HeaderStyle = value ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
			}
		}

		/// <summary>
		/// Pegue ou escolha a data para exibição das cotações.
		/// chame Carregar() antes de escolher o valor da data.
		/// veja comentário de Carregar() para saber o porquê.
		/// </summary>
		[Browsable(false)]
		public DateTime Data
		{
			get 
			{ 
				return data.Value; 
			}
			set
			{
                DefinirData(value);
			}
        }

        #region Definição de data sincronizado

        public delegate void DefinirDataCallback(DateTime data);

        public void DefinirData(DateTime data)
        {
            if (InvokeRequired)
            {
                DefinirDataCallback método = new DefinirDataCallback(DefinirDataSomente);
                BeginInvoke(método, data);
            }
            else
            {
                this.data.Value = data.Date;

                if (!DesignMode)
                    CarregarItens(data);
            }
        }

        private void DefinirDataSomente(DateTime data)
        {
            this.data.Value = data.Date;
        }

        #endregion

        /// <summary>
        /// Verifica se o painel possui foco.
        /// </summary>
        public override bool Focused
        {
            get
            {
                bool focado = base.Focused;
                Queue fila = new Queue(); ;

                fila.Enqueue(Controls);

                while (!focado && fila.Count > 0)
                {
                    ICollection controles = (ICollection)fila.Dequeue();

                    foreach (Control controle in controles)
                    {
                        focado |= controle.Focused;
                        fila.Enqueue(controle.Controls);
                    }
                }

                return focado;
            }
        }

        #endregion

        /// <summary>
		/// Obtem dados do contexto, e carrega itens no list view.
		/// </summary>
		/// <param name="dia">Dia para obtenção das cotações</param>
		/// <returns>Se foram carregadas cotações.</returns>
		private bool CarregarItens(DateTime dia)
		{
            Entidades.Financeiro.Cotação[] cotações = null;

            UseWaitCursor = true;

            try
            {
                if (moeda != null)
                    cotações = Entidades.Financeiro.Cotação.ObterListaCotaçõesAtéDia(moeda, dia);
                else
                    cotações = new Entidades.Financeiro.Cotação[0];

                seleção = null;

                // Preenche a lista
                PreencherListView(cotações);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    ParentForm,
                    "Não foi possível carregar lista de cotações. O seguinte erro ocorreu:\n\n" + e.ToString(),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                try
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                }
                catch { }
            }
            finally
            {
                UseWaitCursor = false;
            }

            return (cotações != null && cotações.Length > 0);
		}

        private delegate void PreencherListViewCallback(Entidades.Financeiro.Cotação[] cotações);

		/// <summary>
		/// Preenche o listView com uma lista de ICotação
		/// </summary>
		/// <param name="listaCotações">Lista de cotações</param>
		private void PreencherListView(Entidades.Financeiro.Cotação[] cotações)
		{
            if (InvokeRequired)
            {
                PreencherListViewCallback método = new PreencherListViewCallback(PreencherListView);
                BeginInvoke(método, cotações);
            }
            else
            {
                // Renova tabelas hash do controle
                hashListViewItemCotação = new Dictionary<ListViewItem, Entidades.Financeiro.Cotação>();
                hashValorListViewItem = new Dictionary<double, ListViewItem>();

                // Limpa a list view
                lista.Items.Clear();
                seleção = null;

                // Nenhuma cotação cadastrada
                if (cotações == null || cotações.Length == 0)
                    return;

                // Insere cotações na lista
                //listaCotações.ForEach(new Action<ICotação>(AdicionarNaListView));

                foreach (Entidades.Financeiro.Cotação cotação in cotações)
                {
                    ListViewItem novoItem;

                    if (cotação.Data.Value.Date != Data.Date)
                        novoItem = new ListViewItem("Anterior");
                    else
                        novoItem = new ListViewItem(cotação.Data.Value.ToShortTimeString());

                    novoItem.SubItems.Add(cotação.Valor.ToString("C", DadosGlobais.Instância.Cultura));
                    novoItem.SubItems.Add(Entidades.Pessoa.Pessoa.ReduzirNome(cotação.Funcionário.Nome));

                    lista.Items.Add(novoItem);

                    // Registra nas tabelas hash
                    ListViewItem itemJáExistente;
                    if (hashValorListViewItem.TryGetValue(cotação.Valor, out itemJáExistente))
                    {
                        // Ok, já tem. Mas a hash deve ter a cotação mais recente

                        if (hashListViewItemCotação[itemJáExistente].Data
                            < cotação.Data)
                        {
                            // Troca a hash
                            hashValorListViewItem.Remove(cotação.Valor);
                            hashValorListViewItem.Add(cotação.Valor, novoItem);
                        }
                    } else
                        hashValorListViewItem.Add(cotação.Valor, novoItem);

                    hashListViewItemCotação[novoItem] = cotação;
                }
            }
		}

		/// <summary>
		/// Cotação selecionada.
		/// </summary>
		public Entidades.Financeiro.Cotação CotaçãoSelecionada
		{
			get
			{
                return seleção;
			}
			set
			{
                if (value.Data.HasValue)
                {
                    // Altera a data do controle
                    data.Value = value.Data.Value;

                    // Verifica se é necessário carregar do banco de dados
                    if (hashListViewItemCotação == null || !hashListViewItemCotação.ContainsValue(value))
                        CarregarItens(value.Data.Value);
                }
                else
                    data = null;

                // Seleciona cotação escolhida
                IDictionaryEnumerator enumerador = hashListViewItemCotação.GetEnumerator();
                
                while (enumerador.MoveNext())
				{
					if (enumerador.Value == (object)value)
					{
						lista.SelectedItems.Clear();
						((ListViewItem) enumerador.Key).Selected = true;
					}
				}

                seleção = value;

                if (SelectedIndexChanged != null)
                    this.SelectedIndexChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Desce a seleção
		/// </summary>
		public void DescerSeleção()
		{
			if (lista.Items.Count != 0)
			{
				lista.Focus();

                if (lista.SelectedIndices.Count == 0)
                    lista.TopItem.Selected = true;
                else if (lista.SelectedItems[0] != lista.Items[lista.Items.Count - 1])
                {
                    int indiceSelecionado = lista.SelectedIndices[0];
                    lista.Items[indiceSelecionado].Selected = false;
                    lista.Items[indiceSelecionado + 1].Selected = true;
                    /* as vezes, ficam 2 itens selecionados, mesmo com o multiselect = false.
                    * bug do .net ?
                    */
                }
			}
		}

		/// <summary>
		/// Sobe a seleção
		/// </summary>
		public void SubirSeleção()
		{
			if (lista.Items.Count != 0)
			{
                lista.Focus();

				if (lista.SelectedIndices.Count == 0) 
					lista.Items[lista.Items.Count - 1].Selected = true;
				else if (lista.SelectedItems[0] != lista.TopItem)
					lista.Items[lista.SelectedIndices[0] - 1].Selected = true;
			}
		}

        private delegate void SelecionarÚltimoCallback();

        /// <summary>
        /// Seleciona o último elemento da lista.
        /// </summary>
        public void SelecionarÚltimo()
        {
            if (InvokeRequired)
            {
                SelecionarÚltimoCallback método = new SelecionarÚltimoCallback(SelecionarÚltimo);
                BeginInvoke(método);
            }
            else
            {
                lista.SelectedItems.Clear();

                if (lista.Items.Count != 0)
                {
                    lista.Items[lista.Items.Count - 1].Selected = true;

                    seleção = hashListViewItemCotação[lista.Items[lista.Items.Count - 1]];
                }
                else
                    seleção = null;

                if (SelectedIndexChanged != null)
                    this.SelectedIndexChanged(this, new EventArgs());

                if (ListaDoubleClick != null)
                    ListaDoubleClick(this, new EventArgs());
            }
        }

		/// <summary>
		/// Seleciona um valor específico, se existir.
		/// </summary>
		/// <param name="valor">Valor a ser selecionado.</param>
		public void Selecionar(double valor)
		{
            UseWaitCursor = true;

            try
            {
                ListViewItem itemEncontrado;

                if (hashValorListViewItem == null)
                    CarregarItens(DadosGlobais.Instância.HoraDataAtual);

                if (hashValorListViewItem.TryGetValue(valor, out itemEncontrado))
                {
                    itemEncontrado.Selected = true;
                    
                    if (this.Visible)
                        itemEncontrado.EnsureVisible();

                    seleção =  hashListViewItemCotação[itemEncontrado];
                }
                else
                {
                    lista.SelectedItems.Clear();
                    seleção = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    ParentForm,
                    "Ocorreu o seguinte erro enquanto selecionava-se um valor:\n\n" + e.ToString(),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                try
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                }
                catch { }

                seleção = null;
            }
            finally
            {
                UseWaitCursor = false;
            }

            if (SelectedIndexChanged != null)
                this.SelectedIndexChanged(this, new EventArgs());
		}
        
        /// <summary>
        /// Ocorre ao mudar a seleção.
        /// </summary>
        private void lista_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lista.SelectedItems.Count == 1)
                seleção = hashListViewItemCotação[lista.SelectedItems[0]];
            else
                seleção = null;

            if (SelectedIndexChanged != null)
                this.SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// Ocorre ao dar duplo clique na lista.
        /// </summary>
        private void lista_DoubleClick(object sender, System.EventArgs e)
        {
            this.ListaDoubleClick(sender, e);
        }

        private void data_ValueChanged(object sender, EventArgs e)
        {
            CarregarItens(data.Value);
        }
    }
}
