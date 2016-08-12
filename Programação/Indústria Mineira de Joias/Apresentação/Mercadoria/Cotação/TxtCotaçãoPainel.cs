using Entidades.Configuração;
using Entidades.Moedas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;


namespace Apresentação.Mercadoria.Cotação
{
    internal class TxtCotaçãoPainel : UserControl
	{
		private Dictionary<ListViewItem, Entidades.Financeiro.Cotação> hashListViewItemCotação;
		private Dictionary<double, ListViewItem> hashValorListViewItem; // chave: valor double da cotação.
        private Entidades.Financeiro.Cotação seleção = null;
        private Moeda moeda;

		private Panel painelBase;
		private Panel painelSuperior;
		private Panel painelInferior;
		private ListView lista;
		private ColumnHeader colHora;
		private ColumnHeader colCotação;
		private ColumnHeader colFuncionário;
		private DateTimePicker data;
        private IContainer components;

        public event EventHandler SelectedIndexChanged;
		public event EventHandler ListaDoubleClick;

        private bool emPréCarga = true;

        public void CargaInicial()
        {
            emPréCarga = false;
            Recarregar();
        }

		public TxtCotaçãoPainel()
		{
			InitializeComponent();

            data.Value = DadosGlobais.Instância.HoraDataAtual;
		}
        
        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value;

                Recarregar();
                SelecionarPrimeiro();
            }
        }

        private void Recarregar()
        {
            CarregarItens(data.Value);
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
            this.painelBase.Size = new System.Drawing.Size(216, 146);
            this.painelBase.TabIndex = 0;
            // 
            // painelInferior
            // 
            this.painelInferior.Controls.Add(this.lista);
            this.painelInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelInferior.Location = new System.Drawing.Point(0, 24);
            this.painelInferior.Name = "painelInferior";
            this.painelInferior.Size = new System.Drawing.Size(214, 120);
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
            this.lista.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista.FullRowSelect = true;
            this.lista.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(214, 120);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colHora
            // 
            this.colHora.Text = "D/H";
            this.colHora.Width = 45;
            // 
            // colCotação
            // 
            this.colCotação.Text = "Cotação";
            this.colCotação.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCotação.Width = 61;
            // 
            // colFuncionário
            // 
            this.colFuncionário.Text = "Responsável";
            this.colFuncionário.Width = 65;
            // 
            // painelSuperior
            // 
            this.painelSuperior.BackColor = System.Drawing.SystemColors.ControlDark;
            this.painelSuperior.Controls.Add(this.data);
            this.painelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.painelSuperior.Location = new System.Drawing.Point(0, 0);
            this.painelSuperior.Name = "painelSuperior";
            this.painelSuperior.Size = new System.Drawing.Size(214, 24);
            this.painelSuperior.TabIndex = 3;
            // 
            // data
            // 
            this.data.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.data.CustomFormat = "dd/MM/yy";
            this.data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.data.Location = new System.Drawing.Point(67, 2);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(86, 20);
            this.data.TabIndex = 0;
            this.data.ValueChanged += new System.EventHandler(this.data_ValueChanged);
            // 
            // TxtCotaçãoPainel
            // 
            this.Controls.Add(this.painelBase);
            this.Name = "TxtCotaçãoPainel";
            this.Size = new System.Drawing.Size(216, 146);
            this.painelBase.ResumeLayout(false);
            this.painelInferior.ResumeLayout(false);
            this.painelSuperior.ResumeLayout(false);
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

		[Browsable(false)]
		public DateTime? Data
		{
			get 
			{ 
				return data?.Value; 
			}
			set
			{
                DefinirData(value.Value);
			}
        }

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

                Recarregar();
            }
        }

        private void DefinirDataSomente(DateTime data)
        {
            this.data.Value = data.Date;
        }

        /// <summary>
        /// Verifica se o painel possui foco.
        /// </summary>
        public override bool Focused
        {
            get
            {
                bool focado = base.Focused;
                Queue fila = new Queue();

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

		private bool CarregarItens(DateTime dia)
		{
            if (emPréCarga)
                return false;

            Console.WriteLine(" Obtendo cotações até dia " + dia.ToString());
            Entidades.Financeiro.Cotação[] cotações = null;

            UseWaitCursor = true;

            try
            {
                if (moeda != null)
                    cotações = Entidades.Financeiro.Cotação.ObterListaCotaçõesAtéDia(moeda, dia);
                else
                    cotações = new Entidades.Financeiro.Cotação[0];

                seleção = null;
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
                RenovaTabelasHash();
                LimpaListView();

                bool nenhumaCotaçãoCadastrada = (cotações == null || cotações.Length == 0);

                if (nenhumaCotaçãoCadastrada)
                    return;

                foreach (Entidades.Financeiro.Cotação cotação in cotações)
                {
                    ListViewItem item = CriarItem(cotação);
                    lista.Items.Add(item);
                    RegistraHashes(cotação, item);
                }
            }
        }

        private void RenovaTabelasHash()
        {
            if (hashListViewItemCotação == null)
                hashListViewItemCotação = new Dictionary<ListViewItem, Entidades.Financeiro.Cotação>();

            hashListViewItemCotação.Clear();

            if (hashValorListViewItem == null)
                hashValorListViewItem = new Dictionary<double, ListViewItem>();

            hashValorListViewItem.Clear();
        }

        private void LimpaListView()
        {
            lista.Items.Clear();
            seleção = null;
        }

        private ListViewItem CriarItem(Entidades.Financeiro.Cotação cotação)
        {
            ListViewItem item;

            if (Data.HasValue && cotação.Data.Value.Date != Data.Value.Date)
                item = new ListViewItem(cotação.Data.Value.ToString("dd/MM"));
            else
                item = new ListViewItem(cotação.Data.Value.ToShortTimeString());

            item.SubItems.Add(cotação.Valor.ToString("C", DadosGlobais.Instância.Cultura));
            item.SubItems.Add(Entidades.Pessoa.Pessoa.AbreviarNome(cotação.Funcionário.Nome));
            return item;
        }

        private void RegistraHashes(Entidades.Financeiro.Cotação cotação, ListViewItem novoItem)
        {
            ListViewItem itemJáExistente;
            if (hashValorListViewItem.TryGetValue(cotação.Valor, out itemJáExistente))
            {
                if (hashListViewItemCotação[itemJáExistente].Data
                    < cotação.Data)
                {
                    hashValorListViewItem.Remove(cotação.Valor);
                    hashValorListViewItem.Add(cotação.Valor, novoItem);
                }
            }
            else
                hashValorListViewItem.Add(cotação.Valor, novoItem);

            hashListViewItemCotação[novoItem] = cotação;
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
                if (emPréCarga)
                    return;

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

        private delegate void SelecionarPrimeiroCallback();

        public void SelecionarPrimeiro()
        {
            if (InvokeRequired)
            {
                SelecionarPrimeiroCallback método = new SelecionarPrimeiroCallback(SelecionarPrimeiro);
                BeginInvoke(método);
            }
            else
            {
                lista.SelectedItems.Clear();

                if (lista.Items.Count != 0)
                {
                    lista.Items[0].Selected = true;
                    seleção = hashListViewItemCotação[lista.Items[0]];
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
            if (emPréCarga)
                return;

            UseWaitCursor = true;

            try
            {
                ListViewItem itemEncontrado;

                if (hashValorListViewItem == null)
                    CarregarItens(DadosGlobais.Instância.HoraDataAtual);

                if (hashValorListViewItem.TryGetValue(valor, out itemEncontrado))
                {
                    itemEncontrado.Selected = true;
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
