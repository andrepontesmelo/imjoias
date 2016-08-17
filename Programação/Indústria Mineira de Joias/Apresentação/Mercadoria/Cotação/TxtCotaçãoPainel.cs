using Entidades.Configura��o;
using Entidades.Moedas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;


namespace Apresenta��o.Mercadoria.Cota��o
{
    internal class TxtCota��oPainel : UserControl
	{
		private Dictionary<ListViewItem, Entidades.Financeiro.Cota��o> hashListViewItemCota��o;
		private Dictionary<double, ListViewItem> hashValorListViewItem; // chave: valor double da cota��o.
        private Entidades.Financeiro.Cota��o sele��o = null;
        private Moeda moeda;

		private Panel painelBase;
		private Panel painelSuperior;
		private Panel painelInferior;
		private ListView lista;
		private ColumnHeader colHora;
		private ColumnHeader colCota��o;
		private ColumnHeader colFuncion�rio;
		private DateTimePicker data;
        private IContainer components;

        public event EventHandler SelectedIndexChanged;
		public event EventHandler ListaDoubleClick;

        private bool emPr�Carga = true;

        public void CargaInicial()
        {
            emPr�Carga = false;
            Recarregar();
        }

		public TxtCota��oPainel()
		{
			InitializeComponent();

            data.Value = DadosGlobais.Inst�ncia.HoraDataAtual;
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
            this.colCota��o = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncion�rio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.colCota��o,
            this.colFuncion�rio});
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
            // colCota��o
            // 
            this.colCota��o.Text = "Cota��o";
            this.colCota��o.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCota��o.Width = 61;
            // 
            // colFuncion�rio
            // 
            this.colFuncion�rio.Text = "Respons�vel";
            this.colFuncion�rio.Width = 65;
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
            // TxtCota��oPainel
            // 
            this.Controls.Add(this.painelBase);
            this.Name = "TxtCota��oPainel";
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
		/// Determina se mostra cabe�alhos da lista.
		/// </summary>
		[DefaultValue(true)]
		public bool MostrarCabe�alho
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
                DefinirDataCallback m�todo = new DefinirDataCallback(DefinirDataSomente);
                BeginInvoke(m�todo, data);
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
            if (emPr�Carga)
                return false;

            Console.WriteLine(" Obtendo cota��es at� dia " + dia.ToString());
            Entidades.Financeiro.Cota��o[] cota��es = null;

            UseWaitCursor = true;

            try
            {
                if (moeda != null)
                    cota��es = Entidades.Financeiro.Cota��o.ObterListaCota��esAt�Dia(moeda, dia);
                else
                    cota��es = new Entidades.Financeiro.Cota��o[0];

                sele��o = null;
                PreencherListView(cota��es);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    ParentForm,
                    "N�o foi poss�vel carregar lista de cota��es. O seguinte erro ocorreu:\n\n" + e.ToString(),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                try
                {
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                }
                catch { }
            }
            finally
            {
                UseWaitCursor = false;
            }

            return (cota��es != null && cota��es.Length > 0);
		}

        private delegate void PreencherListViewCallback(Entidades.Financeiro.Cota��o[] cota��es);

		/// <summary>
		/// Preenche o listView com uma lista de ICota��o
		/// </summary>
		/// <param name="listaCota��es">Lista de cota��es</param>
		private void PreencherListView(Entidades.Financeiro.Cota��o[] cota��es)
		{
            if (InvokeRequired)
            {
                PreencherListViewCallback m�todo = new PreencherListViewCallback(PreencherListView);
                BeginInvoke(m�todo, cota��es);
            }
            else
            {
                RenovaTabelasHash();
                LimpaListView();

                bool nenhumaCota��oCadastrada = (cota��es == null || cota��es.Length == 0);

                if (nenhumaCota��oCadastrada)
                    return;

                foreach (Entidades.Financeiro.Cota��o cota��o in cota��es)
                {
                    ListViewItem item = CriarItem(cota��o);
                    lista.Items.Add(item);
                    RegistraHashes(cota��o, item);
                }
            }
        }

        private void RenovaTabelasHash()
        {
            if (hashListViewItemCota��o == null)
                hashListViewItemCota��o = new Dictionary<ListViewItem, Entidades.Financeiro.Cota��o>();

            hashListViewItemCota��o.Clear();

            if (hashValorListViewItem == null)
                hashValorListViewItem = new Dictionary<double, ListViewItem>();

            hashValorListViewItem.Clear();
        }

        private void LimpaListView()
        {
            lista.Items.Clear();
            sele��o = null;
        }

        private ListViewItem CriarItem(Entidades.Financeiro.Cota��o cota��o)
        {
            ListViewItem item;

            if (Data.HasValue && cota��o.Data.Value.Date != Data.Value.Date)
                item = new ListViewItem(cota��o.Data.Value.ToString("dd/MM"));
            else
                item = new ListViewItem(cota��o.Data.Value.ToShortTimeString());

            item.SubItems.Add(cota��o.Valor.ToString("C", DadosGlobais.Inst�ncia.Cultura));
            item.SubItems.Add(Entidades.Pessoa.Pessoa.AbreviarNome(cota��o.Funcion�rio.Nome));
            return item;
        }

        private void RegistraHashes(Entidades.Financeiro.Cota��o cota��o, ListViewItem novoItem)
        {
            ListViewItem itemJ�Existente;
            if (hashValorListViewItem.TryGetValue(cota��o.Valor, out itemJ�Existente))
            {
                if (hashListViewItemCota��o[itemJ�Existente].Data
                    < cota��o.Data)
                {
                    hashValorListViewItem.Remove(cota��o.Valor);
                    hashValorListViewItem.Add(cota��o.Valor, novoItem);
                }
            }
            else
                hashValorListViewItem.Add(cota��o.Valor, novoItem);

            hashListViewItemCota��o[novoItem] = cota��o;
        }

        /// <summary>
        /// Cota��o selecionada.
        /// </summary>
        public Entidades.Financeiro.Cota��o Cota��oSelecionada
		{
			get
			{
                return sele��o;
			}
			set
			{
                if (emPr�Carga)
                    return;

                IDictionaryEnumerator enumerador = hashListViewItemCota��o.GetEnumerator();
                
                while (enumerador.MoveNext())
				{
					if (enumerador.Value == (object)value)
					{
						lista.SelectedItems.Clear();
						((ListViewItem) enumerador.Key).Selected = true;
					}
				}

                sele��o = value;

                if (SelectedIndexChanged != null)
                    this.SelectedIndexChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Desce a sele��o
		/// </summary>
		public void DescerSele��o()
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
		/// Sobe a sele��o
		/// </summary>
		public void SubirSele��o()
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
                SelecionarPrimeiroCallback m�todo = new SelecionarPrimeiroCallback(SelecionarPrimeiro);
                BeginInvoke(m�todo);
            }
            else
            {
                lista.SelectedItems.Clear();

                if (lista.Items.Count != 0)
                {
                    lista.Items[0].Selected = true;
                    sele��o = hashListViewItemCota��o[lista.Items[0]];
                }
                else
                    sele��o = null;

                if (SelectedIndexChanged != null)
                    this.SelectedIndexChanged(this, new EventArgs());

                if (ListaDoubleClick != null)
                    ListaDoubleClick(this, new EventArgs());
            }
        }

		/// <summary>
		/// Seleciona um valor espec�fico, se existir.
		/// </summary>
		/// <param name="valor">Valor a ser selecionado.</param>
		public void Selecionar(double valor)
		{
            if (emPr�Carga)
                return;

            UseWaitCursor = true;

            try
            {
                ListViewItem itemEncontrado;

                if (hashValorListViewItem == null)
                    CarregarItens(DadosGlobais.Inst�ncia.HoraDataAtual);

                if (hashValorListViewItem.TryGetValue(valor, out itemEncontrado))
                {
                    itemEncontrado.Selected = true;
                    itemEncontrado.EnsureVisible();
                    sele��o =  hashListViewItemCota��o[itemEncontrado];
                }
                else
                {
                    lista.SelectedItems.Clear();
                    sele��o = null;
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
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                }
                catch { }

                sele��o = null;
            }
            finally
            {
                UseWaitCursor = false;
            }

            if (SelectedIndexChanged != null)
                this.SelectedIndexChanged(this, new EventArgs());
		}
        
        /// <summary>
        /// Ocorre ao mudar a sele��o.
        /// </summary>
        private void lista_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lista.SelectedItems.Count == 1)
                sele��o = hashListViewItemCota��o[lista.SelectedItems[0]];
            else
                sele��o = null;

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
