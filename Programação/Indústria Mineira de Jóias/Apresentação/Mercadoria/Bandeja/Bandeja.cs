using Apresenta��o.Financeiro;
using Apresenta��o.Formul�rios;
using Entidades;
using Entidades.Configura��o;
using Entidades.Pessoa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Bandeja
{
    /// <summary>
    /// Um saquinho da bandeja nunca deve ser utilizado fora dela.
    /// A bandeja deve sempre copiar os dados ao envia-los para fora.
    /// </summary>
	public class Bandeja : System.Windows.Forms.UserControl, IEnumerable, IP�sCargaSistema
	{
        /// <summary>
        /// Tempo que a sinaliza��o de mudan�a na bandeja
        /// permanece em exibi��o.
        /// </summary>
        private const int tempoSinaliza��o = 3000;      // milissegundos

        // Cole��o de itens
        protected List<ISaquinho> saquinhos;

        // Localiza��o do item da listview ou do saquinho
        private Dictionary<ISaquinho, ListViewItem>     hashSaquinhoListViewItem;
        protected Dictionary<ListViewItem, ISaquinho>   hashListViewItemSaquinho;

        /// <summary>
        /// Tabela a ser utilizada.
        /// </summary>
        private Tabela tabela = null;

        /// <summary>
        /// Tabelas que podem ser escolhidas pelo usu�rio.
        /// </summary>
        private List<Tabela> tabelas = null;

        /// <summary>
        /// Nem todos os saquinhos est�o nesta hash.
        /// A string � criada pelo m�todo Identifica��oAgrup�vel().
        /// Dois objetos agrup�veis devem ter mesma Identifica��oAgrup�vel.
        /// </summary>
        private Dictionary<string, ISaquinho> hashAgrupamento;

        // Atributos das propriedades
        private		bool	agrupar                         = false;				
		private		bool    permitirExclus�o	            = true;
        private     bool    suspendeLeiaute                 = false;
        private     bool    abrirInforma��esAoDuploClique   = true;
        private     bool    permitirSele��oTabela           = true;
       
        // Barra de status
		private     double  totalPeso;
        private     double  total�ndice;
        private     double  total�ndicePeso;
        private     double  total�ndicePe�a;
		private     double	totalMercadorias;
        private double totalPre�o;

        [ReadOnly(false)]
        protected ToolStrip barraFerramentas;
        protected ToolStripButton btnExcluir;
        protected ToolStripSeparator toolStripSeparator1;
        protected ToolStripButton btnAgrupar;
        protected ToolStripButton btnSeparar;
        protected ToolStripSeparator toolStripSeparator2;
        protected ToolStripComboBox cmbTabela;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem mnuConsultar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mnuExcluir;
        private StatusBarPanel panel�ndiceTotal;
        private StatusBarPanel panel�ndicePe�a;
        private StatusBarPanel panel�ndicePeso;
        private ToolStripMenuItem mnuAlterar�ndice;
        private ToolStripButton btnAlterar�ndice;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem mnuInverterSele��oToolStripMenuItem;
        private ToolStripMenuItem mnuCopiarToolStripMenuItem;
        private ToolStripMenuItem mnuColarToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem mnuSelecionarTudo;
        private volatile bool statusAtualizado;

		// Delega��es
		public delegate void DSaquinho(ISaquinho saquinho);
		public delegate void SaquinhoHandler(Bandeja bandeja, ISaquinho saquinho);
		public delegate void SaquinhosHandler(Bandeja bandeja, ISaquinho [] saquinhos);
        public delegate void TabelaCallback(Bandeja bandeja, Tabela tabela);

		// Eventos Disparados
		public event SaquinhoHandler    Sele��oMudou;
        public event SaquinhoHandler    DuploClique;
        public event SaquinhosHandler   SaquinhosSelecionados;
		public event SaquinhoHandler    SaquinhoExclu�do;
        public event SaquinhoHandler    Altera��o�ndiceSolicitada;
        public event EventHandler       ColarSolicitado;

        [Description("Disparado somente quando usu�rio altera a tabela pela interface gr�fica.")]
        public event TabelaCallback     TabelaAlterada;

        // M�todos ass�ncronos
        private delegate void AsyncSinalizarSaquinhoTardiamente(Sinaliza��oCarga sinalizador, Entidades.Mercadoria.Mercadoria mercadoria);

		#region Propriedades

        public bool MostrarAlterar�ndice
        {
            get { return mnuAlterar�ndice.Visible; }
            set 
            { 
                // alterar�ndiceToolStripMenuItem.Visible = value; 
            }
        }

        [DefaultValue(true)]
        public bool MostrarAgrupar
        {
            get { return btnAgrupar.Visible; }
            set { btnAgrupar.Visible = value; }
        }

        [DefaultValue(true), Browsable(true)]
        public bool MostrarSele��oTabela
        {
            get { return cmbTabela.Visible; }
            set
            {
                cmbTabela.Visible = toolStripSeparator2.Visible = value;
            }
        }

        [DefaultValue(true), Browsable(true)]
        public bool PermitirSele��oTabela
        {
            get { return cmbTabela.Visible && permitirSele��oTabela; }
            set
            {
                permitirSele��oTabela = cmbTabela.Enabled = toolStripSeparator2.Visible = value;
            }
        }

        [Browsable(false), ReadOnly(true)]
        public Tabela Tabela
        {
            get { return tabela; }
            set
            {
                if (tabela != value)
                {
                    tabela = value;

                    if (cmbTabela.Items.Contains(value))
                        cmbTabela.SelectedIndex = cmbTabela.Items.IndexOf(value);
                    else
                    {
                        cmbTabela.Items.Add(value);
                        cmbTabela.SelectedItem = value;
                    }

                    try
                    {
                        if (cota��o == null || cota��o.Valor == 0)
                            cota��o = Entidades.Financeiro.Cota��o.ObterCota��oVigente(tabela.Moeda);
                    }
                    catch (Entidades.Financeiro.Cota��o.Cota��oInexistente)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "N�o existe cota��o cadastrada para a tabela de pre�os utilizada. Por favor, verifique os dados antes de prosseguir.",
                            "Cota��o da tabela de pre�os",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    RecalcularPre�o();

                    cmbTabela.Enabled = tabelas == null && permitirSele��oTabela;
                }
            }
        }

        /// <summary>
        /// Tabelas que o usu�rio pode escolher.
        /// </summary>
        [Browsable(false), ReadOnly(true)]
        public List<Tabela> Tabelas
        {
            get { return tabelas; }
            set
            {
                tabelas = value;

                cmbTabela.Items.Clear();
                cmbTabela.Items.AddRange(value.ToArray());

                if (!cmbTabela.Items.Contains(tabela))
                    cmbTabela.Items.Add(tabela);

                cmbTabela.SelectedItem = tabela;

                cmbTabela.Enabled = permitirSele��oTabela && value.Count > 0;
            }
        }

        [Browsable(false)]
        public ListView ListView { get { return lista; } }

        /// <summary>
        /// Define se deve ser exibido o bot�o para exclus�o de mercadoria.
        /// </summary>
        [DefaultValue(true)]
        public bool MostrarExcluir
        {
            get { return btnExcluir.Visible; }
            set { btnExcluir.Visible = toolStripSeparator1.Visible = value; }
        }

        /// <summary>
        /// Define se deve ser exibido o pre�o das mercadorias.
        /// </summary>
        [Browsable(true), Description("Define se deve ser exibido o pre�o das mercadorias.")]
        public bool MostrarPre�o
        {
            get { return lista.Columns.Contains(colPre�oUn); }
            set
            {
                if (value && !lista.Columns.Contains(colPre�oUn))
                {
                    lista.Columns.Add(colPre�oUn);
                    lista.Columns.Add(colPre�oTot);
                    status.Panels.Add(panelPre�oTotal);
                }
                else
                {
                    lista.Columns.Remove(colPre�oTot);
                    lista.Columns.Remove(colPre�oUn);
                    status.Panels.Remove(panelPre�oTotal);
                }
            }
        }

        [Browsable(true), DefaultValue(true)]
        [Description("Ao duplo clique, a janela de informa��es da mercadoria ser� aberta automaticamente")]
        public bool AbrirInforma��esAoDuploClique
        {
            get { return abrirInforma��esAoDuploClique; }
            set { abrirInforma��esAoDuploClique = value; }
        }

        /// <summary>
        /// Primeiro ISaquinho da sele��o. Pode ser null.
        /// Cuidado: pode ser que a mercadoria do ISaquinho tenha peso diferente do ISaquinho.
        /// </summary>
        public ISaquinho SaquinhoSelecionado
        {
            get 
            {
                return (lista.SelectedItems.Count == 0) ? null : 
                    hashListViewItemSaquinho[lista.SelectedItems[0]];
            }
        }

		/// <summary>
		/// Para de redesenhar a apar�ncia, incluindo controles
		/// e barra de status.
		/// </summary>
		[DefaultValue(false), Browsable(false)]
		public bool SuspendeLeiaute 
		{ 
			get { return suspendeLeiaute; }
			set 
			{ 
				suspendeLeiaute = value; 

				if (suspendeLeiaute) 
				{
					this.SuspendLayout();
					lista.Scrollable = false;
				}
				else 
				{
					this.ResumeLayout();
					lista.Scrollable = true;
				}
			}
		}
		
		[Browsable(true), DefaultValue(true)]
		public bool PermitirExclus�o
		{
			get
			{ 
				return permitirExclus�o; 
			}
			set
			{
				permitirExclus�o = value;
                AtualizarEnabledBot�esBarraFerramentas();

                try
                {
                    btnExcluir.ToolTipText = value ? "Exluir os itens selecionados" : "Esta bandeja n�o permite exclus�o dos itens";
                }
                catch { }
			}
		}
		
		[Browsable(true)]
		[Description("Ordena��o autom�tica da refer�ncia. coloca lista.SortOrder como 'Ascending'")]
		public bool Ordena��oRefer�ncia
		{
			get	{ return (lista.Sorting == System.Windows.Forms.SortOrder.Ascending); }
			set	
			{
				lista.Sorting = value ? System.Windows.Forms.SortOrder.Ascending :
					System.Windows.Forms.SortOrder.None;
			}
		}

		/// <summary>
		/// Barra de status fala a quantidade de itens.
		/// </summary>
		[Browsable(true)]
		[DefaultValue("true")]
		public bool MostrarStatus
		{
			get { return status.Visible;  }
			set { status.Visible = value; }
		}


		/// <summary>
		/// Mostra barra de ferramentas
		/// </summary>
		[Browsable(true)]
		[DefaultValue("true")]
		public bool MostrarBarraFerramentas
		{
			get { return barraFerramentas.Visible; }
            set { barraFerramentas.Visible = value; }
		}
		
		/// <summary>
		/// Agrupar ISaquinhos semelhantes
		/// </summary>
		[Browsable(true)]
		[Category("Agrupamento"), DefaultValue(false)]
		[Description("Agrupa automaticamente mercadorias de mesma referencia e peso")]
		public bool Agrupar
		{
			get { return agrupar; }
			set
			{
                agrupar = value;

                DefinirBot�oAgrupamento(value);
			}
		}

        private delegate void DefinirBot�oAgrupamentoCallback(bool value);

        private void DefinirBot�oAgrupamento(bool value)
        {
            if (InvokeRequired)
            {
                DefinirBot�oAgrupamentoCallback m�todo = new DefinirBot�oAgrupamentoCallback(DefinirBot�oAgrupamento);
                BeginInvoke(m�todo, value);
            }
            else if (btnAgrupar.Checked != value)
                btnAgrupar.Checked = value;
        }

		/// <summary>
		/// Quantidade de ISaquinhos
		/// </summary>
		public int Quantidade
		{
			get { return saquinhos.Count; }
		}

        [DefaultValue(false)]
        public bool SepararPe�aPeso
        {
            get { return lista.ShowGroups; }
            set
            {
                ListViewItem[] itens = new ListViewItem[lista.Items.Count];

                lista.Items.CopyTo(itens, 0);
                lista.Items.Clear();

                lista.ShowGroups = value;
                btnSeparar.Checked = value;

                lista.Items.AddRange(itens);

                if (value)
                    foreach (ListViewItem item in lista.Items)
                        item.Group = lista.Groups[hashListViewItemSaquinho[item].Mercadoria.DePeso ? "peso" : "pe�a"];
            }
        }

		#endregion // Propriedades

		/// <summary>
		/// Constr�i a bandeja
		/// </summary>
        public Bandeja()
        {
            InitializeComponent();

            saquinhos = new List<ISaquinho>();
            hashListViewItemSaquinho = new Dictionary<ListViewItem, ISaquinho>();
            hashSaquinhoListViewItem = new Dictionary<ISaquinho, ListViewItem>();
            hashAgrupamento = new Dictionary<string, ISaquinho>(StringComparer.Ordinal);

            lista.ListViewItemSorter = new BandejaComparador(hashListViewItemSaquinho, lista);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

            if (designMode)
                return;

            if (PermitirSele��oTabela && Tabelas == null)
                Tabelas = Tabela.ObterTabelas(Funcion�rio.Funcion�rioAtual.Setor);
        }

		#region Tratamento de Eventos de Interface e ISaquinho
		
		/// <summary>
		/// Porque isto n�o est� no set de MostrarStatus ?
		/// Porqu� pode ser que alguem d� um bandeja.Visible = false,
		/// e ent�o o status automaticamente tem seu visible falso.
		/// Quando o usu�rio recupera a visibilidade da bandeja,
		/// � necess�rio executar o c�digo abaixo, que n�o seria chamado
		/// se colocado no set de MostrarStatus.
		/// </summary>
		private void status_VisibleChanged(object sender, System.EventArgs e)
		{
			AjustarDimens�esLista();
		}

		private void timerStatus_Tick(object sender, System.EventArgs e)
		{
			if ((MostrarStatus) && (!SuspendeLeiaute))
				AtualizarStatus();
		}

		/// <summary>
		/// Ocorre ao alterar a visibilidade da barra de ferramentas.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barraFerramentas_VisibleChanged(object sender, System.EventArgs e)
		{
			AjustarDimens�esLista();
		}

		private void lista_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Delete && permitirExclus�o && lista.SelectedItems.Count > 0) 
                ExcluirItensSelecionados(true);

            if (e.KeyCode == Keys.A && e.Control)
                SelecionarTudo();

            if (e.KeyCode == Keys.C && e.Control)
                Copiar();

            if (e.KeyCode == Keys.V && e.Control)
                Colar();
            
		}

		/// <summary>
		/// Ocorre ao clicar no menu excluir
		/// </summary>
		private void mnuExcluir_Click(object sender, System.EventArgs e)
		{
			ExcluirItensSelecionados(true);
		}

		/// <summary>
		/// Mostar informa��es de uma refer�ncia
		/// </summary>
		private void mnuConsultar_Click(object sender, System.EventArgs e)
		{
            if (lista.SelectedItems.Count > 15)
                return;

            UseWaitCursor = true;

			foreach (ListViewItem item in lista.SelectedItems)
			{
				Informa��esMercadoriaResumo dlg;
				ISaquinho              ISaquinho;

                ISaquinho = hashListViewItemSaquinho[item];

				dlg = new Informa��esMercadoriaResumo(ISaquinho.Mercadoria, this.Cota��o);
	
				dlg.Owner = this.ParentForm;

				dlg.Show();
			}

            UseWaitCursor = false;
		}
		
		/// <summary>
		/// Ocorre ao selecionar um ou mais itens na ListView
		/// Sempre que � selecionado e ocorre a dessele��o de outro,
		/// o evento � disparado com par�metro null. 
		/// </summary>
		private void lista_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int nISaquinhos;

            UseWaitCursor = true;
			nISaquinhos = lista.SelectedItems.Count;

			if (nISaquinhos == 0)
			{
				// Como n�o tem ISaquinho selecionado, o parametro null � passado.
				if (Sele��oMudou != null)
					Sele��oMudou(this, null);

				if (SaquinhosSelecionados != null)
					SaquinhosSelecionados(this, new ISaquinho[0]);
			}
			if (nISaquinhos == 1 && Sele��oMudou != null)
			{
                //Sele��oMudou(this, (ISaquinho) items[lista.SelectedItems[0]]);
                Sele��oMudou(this, hashListViewItemSaquinho[lista.SelectedItems[0]]);

                //btnSubir.Enabled = lista.SelectedIndices[0] > 0;
                //btnDescer.Enabled = lista.SelectedIndices[0] < lista.Items.Count - 1;
			}
			else if (nISaquinhos > 1 && SaquinhosSelecionados != null)
			{
				ISaquinho [] ISaquinhos = new ISaquinho[nISaquinhos];

				for (int i = 0; i < nISaquinhos; i++)
                    //ISaquinhos[i] = (ISaquinho) items[lista.SelectedItems[i]];
                    ISaquinhos[i] = hashListViewItemSaquinho[lista.SelectedItems[i]];

				SaquinhosSelecionados(this, ISaquinhos);
			}

			AtualizarEnabledBot�esBarraFerramentas();
            MarcarStatusDesatualizado();

            UseWaitCursor = false;
        }

		/// <summary>
		/// Ocorre ao clicar duas vezes em um item
		/// </summary>
		private void lista_DoubleClick(object sender, System.EventArgs e)
		{
            ISaquinho saquinhoSelecionado = SaquinhoSelecionado;

            if (DuploClique != null && saquinhoSelecionado != null)
                DuploClique(this, saquinhoSelecionado);

            if (abrirInforma��esAoDuploClique)
			    mnuConsultar_Click(sender, e);
		}

		#endregion // Tratamento de eventos

		#region M�todos - Apar�ncia

		/// <summary>
		/// Ajusta as dimens�es da lista.
		/// </summary>
		private void AjustarDimens�esLista()
		{
			SuspendLayout();

			if (status.Visible && barraFerramentas.Visible)
			{
				lista.Height = ClientSize.Height - status.Height - barraFerramentas.Height;
				lista.Top    = barraFerramentas.Height;
			}
			else if (status.Visible)
			{
				lista.Height = ClientSize.Height - status.Height;
				lista.Top    = 0;
			}
			else if (barraFerramentas.Visible)
			{
				lista.Height = ClientSize.Height - barraFerramentas.Height;
				lista.Top    = barraFerramentas.Height;
			}
			else
			{
				lista.Height = ClientSize.Height;
				lista.Top    = 0;
			}

			ResumeLayout();
		}

        private delegate void AtualizarStatusCallBack();

        /// <summary>
        /// Limpa status para que este n�o mostre informa��o antiga
        /// Prepara timer para atualizar o status.
        /// </summary>
        private void MarcarStatusDesatualizado()
        {
            statusAtualizado = false;

            try
            {
                panelQuantidade.Text = "Processando...";
                panelTotalMercadorias.Text = "";
                panelPesoTotal.Text = "";
                panel�ndiceTotal.Text = "";
                panel�ndicePeso.Text = "";
                panel�ndicePe�a.Text = "";
                panelPre�oTotal.Text = "";
            }
            catch
            {
                MostrarStatus = false;
            }

            if (MostrarStatus)
                timerStatus.Enabled = true;
        }

		/// <summary>
		/// Atualiza barra de status da bandeja.
		/// </summary>
		protected void AtualizarStatus()
		{
#if !DEBUG
            try
#endif
            {
                if (!statusAtualizado)
                {
                    if (status.InvokeRequired)
                    {
                        AtualizarStatusCallBack m�todo = new AtualizarStatusCallBack(AtualizarStatus);
                        this.BeginInvoke(m�todo);
                    }
                    else
                    {
                        timerStatus.Enabled = false;

                        statusAtualizado = true;

#if DEBUG
                    if (!MostrarStatus)
                        throw new Exception("foi chamado o AtualizarStatus, mas o mostrarStatus come�ou igual a false. Fa�a verifica��o antes de chamar");
#endif

                        List<ISaquinho> listaEntidades;

                        double totalMercadorias = 0;
                        double totalPeso = 0;
                        double total�ndice = 0;
                        double total�ndicePeso = 0;
                        double total�ndicePe�a = 0;
                        double totalPre�o = 0;
                        //string    totalPesoStr;
                        bool selecionados = (lista.SelectedItems.Count > 0);

                        if (selecionados)
                        {
                            listaEntidades = new List<ISaquinho>(lista.SelectedItems.Count);

                            foreach (ListViewItem itemLista in lista.SelectedItems)
                                listaEntidades.Add(hashListViewItemSaquinho[itemLista]);

                            try
                            {
                                panelTotalMercadorias.ToolTipText = "Somat�ria da quantidade de mercadorias de cada item selecionado";
                                panelPesoTotal.ToolTipText = "Peso de todas as mercadorias levando em conta a quantidade de cada refer�ncia";
                            }
                            catch { }

#if DEBUG
                        if (listaEntidades == null)
                            throw new Exception("Bandeja.AtualizarStatus() -> listaEntidades � null");
#endif

                            foreach (ISaquinho s in listaEntidades)
                            {
                                totalMercadorias += s.Quantidade;
                                totalPeso += s.Peso * s.Quantidade;
                                total�ndice += s.Mercadoria.�ndiceArredondado * s.Quantidade;
                                if (s.Mercadoria.DePeso)
                                    total�ndicePeso += s.Mercadoria.�ndiceArredondado * s.Quantidade;
                                else
                                    total�ndicePe�a += s.Mercadoria.�ndiceArredondado * s.Quantidade;

                                if (cota��o != null)
                                    totalPre�o += CalcularValor(s);
                            }
                        }
                        else
                        {
                            listaEntidades = saquinhos;
                            totalPeso = this.totalPeso;
                            total�ndice = this.total�ndice;
                            total�ndicePe�a = this.total�ndicePe�a;
                            total�ndicePeso = this.total�ndicePeso;

                            totalMercadorias = this.totalMercadorias;
                            totalPre�o = this.totalPre�o;

                            try
                            {
                                panelQuantidade.ToolTipText = "Total de \"linhas\" ou itens da tabela, n�o necessariamente o n�mero de refer�ncias.";
                                panelTotalMercadorias.ToolTipText = "Somat�ria das quantidades de mercadorias";
                                panelPesoTotal.ToolTipText = "Peso de todas as mercadorias selecionadas levando em conta a quantidade de cada refer�ncia";
                                panel�ndiceTotal.ToolTipText = "�ndice de todas as mercadorias selecionadas levando em conta a quantidade de cada refer�ncia";
                            }
                            catch { }
                        }

                        if (listaEntidades.Count > 1)
                        {
                            panelQuantidade.Text = listaEntidades.Count + " itens";
                            if (selecionados)
                            {
                                panelQuantidade.Text += " selecionados";

                                try
                                {
                                    panelQuantidade.ToolTipText = "Total de \"linhas\" ou itens da tabela selecionados";
                                }
                                catch { }
                            }
                        }
                        else if (listaEntidades.Count == 1)
                            if (!selecionados)
                            {
                                panelQuantidade.Text = "1 item";

                                try
                                {
                                    panelQuantidade.ToolTipText = "";
                                }
                                catch { } 
                            }
                            else
                            {
                                Entidades.Mercadoria.Mercadoria merc = ((ISaquinho)
                                    listaEntidades[0]).Mercadoria;

                                try
                                {
                                    panelQuantidade.ToolTipText = "Descri��o da mercadoria selecionada cuja refer�ncia � " + merc.Refer�ncia;
                                }
                                catch { }

                                panelQuantidade.Text = merc.Descri��o;
                            }
                        else // listaEntidades.ISaquinho.ISaquinhos.Count == 0
                            panelQuantidade.Text = "Nenhum item para exibi��o";

                        panelPesoTotal.Text = Entidades.Mercadoria.Mercadoria.FormatarPeso(totalPeso);
                        panel�ndiceTotal.Text = "�ndice: " + Entidades.Mercadoria.Mercadoria.Formatar�ndice(total�ndice);
                        panel�ndicePe�a.Text = "�ndice (Pe�a): " + Entidades.Mercadoria.Mercadoria.Formatar�ndice(total�ndicePe�a);
                        panel�ndicePeso.Text = "�ndice (Peso): " + Entidades.Mercadoria.Mercadoria.Formatar�ndice(total�ndicePeso);

                        if (totalMercadorias > 0)
                            panelTotalMercadorias.Text = totalMercadorias.ToString() + " mercadoria";
                        else
                            panelTotalMercadorias.Text = "";

                        // Plural
                        if (totalMercadorias > 1) panelTotalMercadorias.Text += "s";

                        if (cota��o != null)
                            panelPre�oTotal.Text = totalPre�o.ToString("C", DadosGlobais.Inst�ncia.Cultura.NumberFormat);
                        else
                            panelPre�oTotal.Text = "";
                    }
                }
            }
#if !DEBUG
            catch (Exception e)
            {
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);

                MostrarStatus = false;
            }
#endif
		}

        private double CalcularValor(ISaquinho s)
        {
            return Math.Round(s.Mercadoria.CalcularPre�o(cota��o) * s.Quantidade, 2);
        }

		private void AtualizarEnabledBot�esBarraFerramentas()
		{
			if (lista.SelectedItems.Count == 0)
			{
				btnExcluir.Enabled = false;
                mnuExcluir.Enabled = false;
                mnuAlterar�ndice.Enabled = false;
                btnAlterar�ndice.Enabled = false;
                //btnAlterar.Enabled = false;
				mnuConsultar.Enabled = false;
                //btnDescer.Enabled = false;
                //btnSubir.Enabled = false;
			}
			else
			{
				btnExcluir.Enabled = permitirExclus�o;
                //btnAlterar.Enabled = true;
                mnuAlterar�ndice.Enabled = permitirExclus�o;
                btnAlterar�ndice.Enabled = permitirExclus�o;
				mnuExcluir.Enabled = permitirExclus�o;
				mnuConsultar.Enabled = true;
				
                ////Subir e descer s� quando tem apenas 1 selecionado.
                //if (lista.SelectedItems.Count == 1) 
                //{
                //    btnDescer.Enabled = (lista.SelectedItems[0].Index != lista.Items.Count - 1);
                //    btnSubir.Enabled = (lista.SelectedItems[0].Index != 0);
                //} 
                //else
                //{
                //    btnDescer.Enabled = false;
                //    btnSubir.Enabled = false;
                //}
			}
		}

		/// <summary>
		/// Sobe item selecionado
		/// </summary>
		private void SubirItemSelecionado()
		{
			ListViewItem item;
			int posi��o;

			item = lista.SelectedItems[0];
			posi��o = item.Index;

			item.Remove();

			lista.Items.Insert(posi��o - 1, item);
		
			item.EnsureVisible();
			item.Selected = true;
		}

		/// <summary>
		/// Desce item selecionado
		/// </summary>
		private void DescerItemSelecionado()
		{
			ListViewItem item;
			int posi��o;

			item = lista.SelectedItems[0];
			posi��o = item.Index;

			item.Remove();

			lista.Items.Insert(posi��o + 1, item);

            AtualizarEnabledBot�esBarraFerramentas();

			item.EnsureVisible();
			item.Selected = true;
		}

		/// <summary>
		/// Apenas adiciona o essencial: Refer�ncia e Quantidade.
		/// </summary>
		protected virtual ListViewItem ConstruirListView(Entidades.ISaquinho saquinho)
		{
			ListViewItem novoItemListView;
			
            // Gera o item 
			novoItemListView = new ListViewItem(saquinho.Mercadoria.Refer�ncia);

            // Relaciona dos dicion�rios
            hashListViewItemSaquinho.Add(novoItemListView, saquinho);
            hashSaquinhoListViewItem.Add(saquinho, novoItemListView);

            // Prepara futuro agrupamento com este:
            string identifica��o = saquinho.Identifica��oAgrup�vel();

            if (!hashAgrupamento.ContainsKey(identifica��o))
                hashAgrupamento.Add(identifica��o, saquinho);
						
			// lista.Items.Add(novoItemListView);
			novoItemListView.SubItems.Add(saquinho.Quantidade.ToString());
			novoItemListView.SubItems.AddRange(new string[] {"","","","","","","","","",""});

            // Preenche campos espec�ficos do listviewitem
            AtualizaElementoListView(saquinho, novoItemListView);

			// A tag � necess�ria para exibi��o futura da foto.
			novoItemListView.Tag = saquinho.Mercadoria;

            AdicionarFoto(novoItemListView, saquinho.Mercadoria.�cone);
			return novoItemListView;
		}

		/// <summary>
		/// Atualiza elementos na ListView
		/// </summary>
		/// <param name="ISaquinho">Entidades.ISaquinho.ISaquinho a ser atualizado</param>
		/// <param name="item">Item da ListView</param>
		protected virtual void AtualizaElementoListView(ISaquinho saquinho, ListViewItem item)
		{
            if (colRefer�ncia.Index == -1)
                return;

			item.SubItems[colRefer�ncia.Index].Text = saquinho.Mercadoria.Refer�ncia;
            item.SubItems[colRefer�ncia.Index].Name = colRefer�ncia.Text;
			item.SubItems[colQuantidade.Index].Text = saquinho.Quantidade.ToString();
            item.SubItems[colQuantidade.Index].Name = colQuantidade.Text;
            item.SubItems[colPeso.Index].Text = saquinho.Peso.ToString("0.00");
            item.SubItems[colPeso.Index].Name = colPeso.Text;
            item.SubItems[col�ndice.Index].Text = Entidades.Mercadoria.Mercadoria.Formatar�ndice(saquinho.Mercadoria.�ndiceArredondado);
            item.SubItems[col�ndice.Index].Name = col�ndice.Text;
			item.SubItems[colGrupo.Index].Text = saquinho.Mercadoria.Grupo.ToString();
            item.SubItems[colGrupo.Index].Name = colGrupo.Text;
			item.SubItems[colFaixa.Index].Text = (saquinho.Mercadoria.Faixa != null ? saquinho.Mercadoria.Faixa.ToString() : "");
            item.SubItems[colFaixa.Index].Name = colFaixa.Text;

            System.Globalization.CultureInfo cultura = DadosGlobais.Inst�ncia.Cultura;

            if (MostrarPre�o)
            {
                double valorTotal = CalcularValor(saquinho);
                item.SubItems[colPre�oTot.Index].Text = valorTotal.ToString("C", cultura);
                item.SubItems[colPre�oUn.Index].Text = saquinho.Mercadoria.CalcularPre�o(cota��o);
            }
        }
		
		/// <summary>
		/// Limpa os elementos da listView e dos saquinhos.
		/// Limpa as imagens armazenadas
		/// </summary>
		public void LimparLista()
		{
			lista.Items.Clear();
            
            // Limpa as tabela-hash
            hashAgrupamento.Clear();
            hashListViewItemSaquinho.Clear();
            hashSaquinhoListViewItem.Clear();

			imagensGrandes.Images.Clear();
			imagensPequenas.Images.Clear();
            saquinhos.Clear();

			// Atualiza a barra de status
			totalMercadorias = 0;
			totalPeso = 0;
            total�ndice = 0;
            total�ndicePeso = 0;
            total�ndicePe�a = 0;
		}

        /// <summary>
        /// Coloca o foco em um item espec�fico.
        /// Dispara excess�o se n�o acha o item.
        /// </summary>
        /// <param name="s">Pode ser outro saquinho, desde que bandeja tenha outro com mesma referencia e peso.</param>
        public void Selecionar(Entidades.Mercadoria.Mercadoria m)
        {
            ListViewItem itemListView;

            ISaquinho saquinho = null;

            // Tentativa de obter algum ISaquinho parecido para remo��o
            if (!hashAgrupamento.TryGetValue(new Saquinho(m, 1).Identifica��oAgrup�vel(), out saquinho))
                throw new Exception("Tentativa selecionar um saquinho que n�o existia na bandeja");

            itemListView = hashSaquinhoListViewItem[saquinho];

            // Deixa apenas o item encontrado selecionado.
            lista.SelectedItems.Clear();
            itemListView.Selected = true;
            itemListView.EnsureVisible();
        }

        public bool Cont�m(Entidades.Mercadoria.Mercadoria m)
        {
            return (hashAgrupamento.ContainsKey(new Saquinho(m, 1).Identifica��oAgrup�vel()));
        }

#endregion

        #region Agrupamento

        /// <summary>
        /// Retorna uma lista de saquinhos agrup�veis com o fornecido.
        /// Na lista inclui-se o pr�prio item de origem.
        /// </summary>
		protected List<Saquinho> ObterAgrup�veis(Entidades.ISaquinho origem)
		{
            List<Saquinho> semelhantes = new List<Saquinho>();

			// Obtem a hash do objeto de origem para compara��o
			string identifica��o = origem.Identifica��oAgrup�vel();

			// Verifica se existe chave de semelhan�a na hash.
            if (hashAgrupamento.ContainsKey(identifica��o))
			{
				foreach (Saquinho s in saquinhos)
					if (identifica��o.Equals(s.Identifica��oAgrup�vel()))
						semelhantes.Add(s);
			}

            return semelhantes;
		}

	
		/// <summary>
		/// Agrupa todos os saquinhos agrup�veis.
        /// Pergunta nada ao usu�rio.
		/// </summary>
        private void AgruparTudo()
        {
            if (!agrupar)
                throw new Exception("Tentativa de AgruparTudo() quando agrupar=false");

            ArrayList c�piaSaquinhos = new ArrayList(this.saquinhos);

            while (c�piaSaquinhos.Count > 0)
            {
                List<Saquinho> agrup�veisAoSaquinhoAtual;
                Entidades.Saquinho saquinhoAtual;

                saquinhoAtual = (Entidades.Saquinho)c�piaSaquinhos[0];

                //// Garante o fim do while:
                c�piaSaquinhos.Remove(saquinhoAtual);

                agrup�veisAoSaquinhoAtual = AgruparItem(saquinhoAtual);

                // Retira os saquinhos que ser�o eliminados da c�pia
                foreach (Entidades.ISaquinho s in agrup�veisAoSaquinhoAtual)
                    c�piaSaquinhos.Remove(s);
            }
        }

        /// <summary>
        /// Remove v�rios saquinhos semelhantes ao do parametro e adiciona um que substitui todos.
        /// </summary>
        /// <remarks> O saquinhoAtual j� deve estar na bandeja </remarks>
        /// <param name="saquinhoAtual"></param>
        /// <returns>Saquinhos agrup�veis ao atual, inclu�ndo o do parametro</returns>
        private List<Saquinho> AgruparItem(ISaquinho saquinhoAtual)
        {
            List<Saquinho> agrup�veisAoSaquinhoAtual;
            agrup�veisAoSaquinhoAtual = ObterAgrup�veis(saquinhoAtual);

            // Se for um, tem apenas ele mesmo.
            if (agrup�veisAoSaquinhoAtual.Count > 1)
            {
                double totalQtd = 0;

                // Retira os saquinhos que ser�o eliminados da c�pia
                foreach (Entidades.ISaquinho s in agrup�veisAoSaquinhoAtual)
                {
                    totalQtd += s.Quantidade;
                    RemoverInterno(s);
                }

                // Adiciona novo saquinho que � equivalente ao grupo
                ISaquinho novoSaquinho = saquinhoAtual.Clone(totalQtd);
                Adicionar(novoSaquinho, false);
            }

            return agrup�veisAoSaquinhoAtual;
        }

		#endregion

		#region M�todos - Funcionamento

		///<summary>
		/// Atualiza objetos intrinsecos � bandeja. Vai no Banco de dados e atualiza os objetos dos ISaquinhos
		/// N�o atualiza nada da listview, porque as informa��es atualizadas s�o internas (instr�nsecas, n�o vis�veis).
		/// </summary>
		public void AtualizaObjetosInstr�nsecosDosSaquinhos()
		{
			foreach (Saquinho saquinhoAtual in saquinhos)
				saquinhoAtual.AtualizaObjetosIntr�nsecos();
		}

		public virtual Saquinho ConstruirSaquinhoVazio()
		{	return new Saquinho(null, 0); 	}

        /// <summary>
        /// Sinaliza adi��o ou remo��o na bandeja, mostrando
        /// controle Sinaliza��oCarga com a mudan�a.
        /// Caso o �cone n�o esteja pronto, ele � carregado
        /// em segundo plano.
        /// </summary>
        private void SinalizarSaquinho(ISaquinho saquinho)
        {
            if (saquinho.Mercadoria.�cone != null)
                Sinaliza��oCarga.Sinalizar(lista, saquinho.Mercadoria.Refer�ncia,
                    (saquinho.Mercadoria.DePeso
                    ? String.Format("{0} {1} unidade(s) com peso {2}.", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade), saquinho.Peso)
                    : String.Format("{0} {1} unidade(s).", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade))),
                    saquinho.Mercadoria.�cone ?? new Bitmap(1, 1)).IniciarTemporizador(tempoSinaliza��o);
            else
            {
                AsyncSinalizarSaquinhoTardiamente m�todo = new AsyncSinalizarSaquinhoTardiamente(SinalizarSaquinhoTardiamente);
                Sinaliza��oCarga sinaliza��o = Sinaliza��oCarga.Sinalizar(lista, saquinho.Mercadoria.Refer�ncia,
                    (saquinho.Mercadoria.DePeso
                    ? String.Format("{0} {1} unidade(s) com peso {2}.", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade), saquinho.Peso)
                    : String.Format("{0} {1} unidade(s).", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade))));

                sinaliza��o.IniciarTemporizador(tempoSinaliza��o);

                m�todo.BeginInvoke(sinaliza��o, saquinho.Mercadoria, new AsyncCallback(CallbackSinalizarSaquinhoTardiamente), m�todo);
            }
        }

        private void CallbackSinalizarSaquinhoTardiamente(IAsyncResult resultado)
        {
            AsyncSinalizarSaquinhoTardiamente m�todo = (AsyncSinalizarSaquinhoTardiamente)resultado.AsyncState;
            m�todo.EndInvoke(resultado);
        }

        /// <summary>
        /// Atribui �cone da mercadoria � sinaliza��o feita pelo m�todo
        /// SinalizarSaquinho. Esta fun��o � chamada por uma nova thread.
        /// </summary>
        /// <param name="obj">Vetor contendo Sinaliza��oCarga e Mercadoria.</param>
        private void SinalizarSaquinhoTardiamente(Sinaliza��oCarga sinaliza��o, Entidades.Mercadoria.Mercadoria mercadoria)
        {
            try
            {
                sinaliza��o.Imagem = mercadoria.�cone;
            }
            catch { /* Ignorar */ }
        }

        /// <summary>
		/// Adiciona Saquinho na bandeja
		/// </summary>
		/// <param name="ISaquinho">Entidades.ISaquinho.ISaquinho a ser adicionado</param>
        public void Adicionar(Entidades.ISaquinho saquinhoOriginal)
        {
            ListViewItem item;

            UseWaitCursor = true;

            SinalizarSaquinho(saquinhoOriginal);

            if (agrupar)
            {
                /* � concebido que a bandeja j� est� completamente agrupado.
                 * Portanto, s� devemos olhar por um item apenas.
                 */
                string chave = saquinhoOriginal.Identifica��oAgrup�vel();
                ISaquinho agrup�vel = null;
                if (hashAgrupamento.TryGetValue(chave, out agrup�vel))
                {
                    // O pr�prio Remover() ir� retirar da hashAgrupamento.
                    //hashAgrupamento.Remove(chave);
                    saquinhoOriginal = saquinhoOriginal.Clone(saquinhoOriginal.Quantidade + agrup�vel.Quantidade);
                    RemoverInterno(agrup�vel);
                    hashAgrupamento[chave] = saquinhoOriginal;
                }
            }
            
            saquinhos.Add(saquinhoOriginal);
            
            item = ConstruirListView(saquinhoOriginal);

            lista.Items.Add(item);
            item.EnsureVisible();

            item.Group = lista.Groups[saquinhoOriginal.Mercadoria.DePeso ? "peso" : "pe�a"];

            // Atualiza contagem para status
            totalMercadorias += saquinhoOriginal.Quantidade;
            totalPeso += saquinhoOriginal.Quantidade * saquinhoOriginal.Peso;
            total�ndice += saquinhoOriginal.Quantidade * saquinhoOriginal.Mercadoria.�ndiceArredondado;

            if (saquinhoOriginal.Mercadoria.DePeso)
                total�ndicePeso += saquinhoOriginal.Quantidade * saquinhoOriginal.Mercadoria.�ndiceArredondado;
            else
                total�ndicePe�a += saquinhoOriginal.Quantidade * saquinhoOriginal.Mercadoria.�ndiceArredondado;

            if (cota��o != null)
                totalPre�o += CalcularValor(saquinhoOriginal);

            try
            {
                MarcarStatusDesatualizado();
            }
            catch { }

            UseWaitCursor = false;
        }

        private void Adicionar(Entidades.ISaquinho saquinhoOriginal, bool agrupar)
        {
            ArrayList lista = new ArrayList();
            lista.Add(saquinhoOriginal);

            AdicionarV�rios(lista, agrupar);
        }

        public void AdicionarV�rios(ArrayList listaSaquinhos, bool agrupar)
        {
            UseWaitCursor = true;
            ListViewItem[] itens = new ListViewItem[listaSaquinhos.Count];
            int x = 0;

            AguardeDB.Mostrar();

            foreach (ISaquinho s in listaSaquinhos)
            {
                ISaquinho sOuNovo = s;
                ListViewItem item;

                if (agrupar)
                {
                    string chave = s.Identifica��oAgrup�vel();
                    ISaquinho agrup�vel = null;
                    if (hashAgrupamento.TryGetValue(chave, out agrup�vel))
                    {
                        sOuNovo = SubstituirSaquinho(s, sOuNovo, chave, agrup�vel);
                    }
                }

                saquinhos.Add(sOuNovo);

                item = ConstruirListView(sOuNovo);
                item.Group = lista.Groups[sOuNovo.Mercadoria.DePeso ? "peso" : "pe�a"];

                itens[x++] = item;

                AtualizaContagemStatus(sOuNovo);
            }
            
            lista.Items.AddRange(itens);
            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        private ISaquinho SubstituirSaquinho(ISaquinho s, ISaquinho sOuNovo, string chave, ISaquinho agrup�vel)
        {
            hashAgrupamento.Remove(chave);
            sOuNovo = s.Clone(s.Quantidade + agrup�vel.Quantidade);
            hashAgrupamento[chave] = sOuNovo;

            RemoverInterno(agrup�vel);
            return sOuNovo;
        }

        private void AtualizaContagemStatus(ISaquinho sOuNovo)
        {
            totalMercadorias += sOuNovo.Quantidade;
            totalPeso += sOuNovo.Quantidade * sOuNovo.Peso;
            total�ndice += sOuNovo.Quantidade * sOuNovo.Mercadoria.�ndiceArredondado;
            if (sOuNovo.Mercadoria.DePeso)
                total�ndicePeso += sOuNovo.Quantidade * sOuNovo.Mercadoria.�ndiceArredondado;
            else
                total�ndicePe�a += sOuNovo.Quantidade * sOuNovo.Mercadoria.�ndiceArredondado;

            if (cota��o != null)
                totalPre�o += CalcularValor(sOuNovo);
        }

        /// <summary>
        /// � o mesmo efeito que chamar v�rias vezes Adicionar, por�m � um m�todo
        /// mais r�pido
        /// </summary>
        /// <param name="ISaquinhos"></param>
        public void AdicionarV�rios(ArrayList listaSaquinhos)
        {
            AdicionarV�rios(listaSaquinhos, agrupar);
        }
    
        /// <summary>
		/// Remove um saquinho da bandeja.
        /// O Saquinho pode ou n�o estar na bandeja. Caso n�o esteja, um agrup�vel � parcialmente removido.
		/// </summary>
        public void Remover(ISaquinho s)
        {
            RemoverInterno(s);

            if (SaquinhoExclu�do != null)
                SaquinhoExclu�do(this, s);
        }

		private void RemoverInterno(ISaquinho s)
		{
            double quantidadeRemanescente = 0;
            ListViewItem itemListView;

            if (!saquinhos.Contains(s))
            {
                ISaquinho saquinhoAlternativo = null;

                // Tentativa de obter algum ISaquinho parecido para remo��o
                hashAgrupamento.TryGetValue(s.Identifica��oAgrup�vel(), out saquinhoAlternativo);

                if ((saquinhoAlternativo == null) || (quantidadeRemanescente < 0))
                    throw new Exception("Tentativa de remover um saquinho que n�o existia na bandeja");
                else
                {
                    quantidadeRemanescente = saquinhoAlternativo.Quantidade - s.Quantidade;
                    s = saquinhoAlternativo;
                }
            }

            itemListView = hashSaquinhoListViewItem[s];

			// Atualiza hash items
			hashAgrupamento.Remove(s.Identifica��oAgrup�vel());
            hashListViewItemSaquinho.Remove(itemListView);
            hashSaquinhoListViewItem.Remove(s);

            #if DEBUG
                if (SuspendeLeiaute)
                    throw new Exception("Tentativa de remover um item de listView com o leiatue suspenso. Devido � bug do VS isto causa um dead lock. Bug verificado tambem no VS2005");
            #endif

            itemListView.Remove();
			
			/* Podem existir v�rios s�quinhos agrup�veis
			 * V�rios outros agrupaveis a este talv�s n�o foram adicionados na hash
			 * uma vez que este j� estava referenciado nela.
			 * Portanto, deve-se procurar por outro agrup�vel para ser referenciado.
             */

            saquinhos.Remove(s);

            string identifica��o = s.Identifica��oAgrup�vel();

			foreach (ISaquinho saquinho in saquinhos)
			{
				if (saquinho.Identifica��oAgrup�vel() == identifica��o)
				{
					hashAgrupamento.Add(identifica��o, (Saquinho) saquinho);
					break;
				}
			}

            // Atualiza dados da barra de status.
			totalMercadorias -= s.Quantidade;
			totalPeso        -= s.Quantidade * s.Peso;
            total�ndice      -= s.Quantidade * s.Mercadoria.�ndiceArredondado;

            if (s.Mercadoria.DePeso)
                total�ndicePeso -= s.Quantidade * s.Mercadoria.�ndiceArredondado;
            else
                total�ndicePe�a -= s.Quantidade * s.Mercadoria.�ndiceArredondado;


            if (cota��o != null)
                totalPre�o -= CalcularValor(s);

            if (quantidadeRemanescente > 0)
            {
                ISaquinho novoSaquinho = s.Clone(quantidadeRemanescente);

                Adicionar(novoSaquinho);
            }

            AtualizarEnabledBot�esBarraFerramentas();
		}

		/// <summary>
		/// Exclui itens selecionados
		/// </summary>
		public void ExcluirItensSelecionados(bool pedirConfirma��o)
		{
			String mensagem;

			switch (lista.SelectedItems.Count)
			{
				case 0:
					throw new Exception("N�o � poss�vel remover 0 itens");

				case 1:
					mensagem = "Deseja retirar a mercadoria " + lista.SelectedItems[0].Text + " da bandeja?";
					break;
				default:
					mensagem = "Deseja retirar os " + lista.SelectedItems.Count + " itens selecionados?";
					break;
			}

			if (MessageBox.Show(this.ParentForm, mensagem, "Exclus�o", MessageBoxButtons.YesNo,  MessageBoxIcon.Question) == DialogResult.No)
				return;
			else
				ExcluirSelecionados();
		}

        public delegate void AntesExclus�oDelegate(ref bool cancelado);

        /// <summary>
        /// Evento disparado antes que bandeja retira itens,
        /// quando usu�rio clica em excluir. Evento n�o � disparado
        /// quando exclus�o � solicitada externamente.
        /// 
        /// Normalmente se proibe exclus�o na bandeja pela propriedade
        /// PermitirExclus�o,
        /// 
        /// Por�m o mundo externo � bandeja pode decidir que a bandeja
        /// n�o se altere assim que alguem tenta alter�-lo.
        /// 
        /// Caso torno muito frequente o uso deste evento pelo programa,
        /// criar uma delega��o na bandeja, um m�todo que a bandeja ir�
        /// chamar para descobrir se o usu�rio est� livre para fazer o que quiser.
        /// </summary>
        public event AntesExclus�oDelegate AntesExclus�o;
            
		/// <summary>
		/// Exclui sem perguntar ao usu�rio
		/// </summary>
		protected virtual void ExcluirSelecionados()
		{
            bool cancelado = false;

            if (AntesExclus�o != null) AntesExclus�o(ref cancelado);
            if (cancelado) return;

			ArrayList exclus�o = new ArrayList(lista.SelectedItems.Count);
            ArrayList listaExclu�dos = new ArrayList();

			foreach (ListViewItem item in lista.SelectedItems)
				exclus�o.Add(item);

            // A remo��o trava o VS com leiaute suspenso. (at� no VS2005)
			//SuspendeLeiaute = true;

			foreach (ListViewItem item in exclus�o)
			{
				ISaquinho s = hashListViewItemSaquinho[item];

                if (item.Selected)
                {
                    Remover((Saquinho) s);
                    listaExclu�dos.Add(s);
                }
			}
		}

		#endregion // M�todos funcionamento

		/// <summary>
		/// Acesso aos ISaquinhos
		/// </summary>
		public Entidades.ISaquinho this[int i]
		{
			get { return (ISaquinho) saquinhos[i]; }
		}

		/// <summary>
		/// Adiciona foto na ListView de forma segura em rela��o � thread.
		/// </summary>
		/// <param name="item">Item da ListView cuja foto ser� adicionada.</param>
		/// <param name="foto">Foto da mercadoria.</param>
		private void AdicionarFoto(ListViewItem item, Image foto)
		{
            if (foto != null)
            {
                imagensGrandes.Images.Add(foto);
                imagensPequenas.Images.Add(foto);

                item.ImageIndex = imagensGrandes.Images.Count - 1;
            }
		}
	
        #region Cota��o

        private Entidades.Financeiro.Cota��o cota��o;
        
        /// <summary>
        /// � atribu�do automaticamente pelo controle de cota��o, que conhece a bandeja.
        /// Sua altera��o atualiza imediatamente a exibi��o dos pre�os na bandeja.
        /// </summary>
        [ReadOnly(true), Browsable(false)]
        public Entidades.Financeiro.Cota��o Cota��o
        {
            get { return cota��o; }
            set 
            { 
                cota��o = value; 
                RecalcularPre�o();
            }
        }

#endregion

		#region Ordena��o flex�vel - ainda n�o impementado
	
		/*
		 * veja evento (lista clique na coluna)
			public class ListViewItemOrdena��o : IComparer
			{	
				private int coluna;
		
				public ListViewItemOrdena��o(int coluna)
				{ 
					this.coluna = coluna;
				}

				public int Compare(object x, object y)
				{
					return string.Compare(((ListViewItem) x).SubItems[coluna].Text,((ListViewItem) y).SubItems[coluna].Text);
				}
			}
			*/
		#endregion

        private void RecalcularPre�o()
        {
            // Atualiza a lista
            SuspendeLeiaute = true;

            foreach (ISaquinho s in saquinhos)
                AtualizaElementoListView(s, hashSaquinhoListViewItem[s]);

            totalPre�o = 0;

            if (cota��o != null)
            {
                foreach (ISaquinho s in saquinhos)
                    totalPre�o += CalcularValor(s);
            }

            if (MostrarStatus)
                AtualizarStatus();

            SuspendeLeiaute = false;
        }

        private void lista_Resize(object sender, EventArgs e)
        {
                AjustarDimens�esLista();
        }

        #region IP�sCargaSistema Members

        public void AoCarregarCompletamente(Splash splash)
        {
            //if (splash != null)
            //    splash.Mensagem = "Carregando bandeja...";

            timerStatus.Enabled = true;
        }

        #endregion



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Mercadoria de pe�a", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Mercadoria de peso", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bandeja));
            this.lista = new System.Windows.Forms.ListView();
            this.colRefer�ncia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPeso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col�ndice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFaixa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrupo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPre�oUn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPre�oTot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuConsultar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlterar�ndice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInverterSele��oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelecionarTudo = new System.Windows.Forms.ToolStripMenuItem();
            this.imagensGrandes = new System.Windows.Forms.ImageList(this.components);
            this.imagensPequenas = new System.Windows.Forms.ImageList(this.components);
            this.imagensBarraFerramentas = new System.Windows.Forms.ImageList(this.components);
            this.status = new System.Windows.Forms.StatusBar();
            this.panelQuantidade = new System.Windows.Forms.StatusBarPanel();
            this.panelTotalMercadorias = new System.Windows.Forms.StatusBarPanel();
            this.panelPesoTotal = new System.Windows.Forms.StatusBarPanel();
            this.panel�ndicePe�a = new System.Windows.Forms.StatusBarPanel();
            this.panel�ndicePeso = new System.Windows.Forms.StatusBarPanel();
            this.panel�ndiceTotal = new System.Windows.Forms.StatusBarPanel();
            this.panelPre�oTotal = new System.Windows.Forms.StatusBarPanel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.barraFerramentas = new System.Windows.Forms.ToolStrip();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.cmbTabela = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgrupar = new System.Windows.Forms.ToolStripButton();
            this.btnSeparar = new System.Windows.Forms.ToolStripButton();
            this.btnAlterar�ndice = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTotalMercadorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPesoTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel�ndicePe�a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel�ndicePeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel�ndiceTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPre�oTotal)).BeginInit();
            this.barraFerramentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.BackColor = System.Drawing.Color.White;
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRefer�ncia,
            this.colQuantidade,
            this.colPeso,
            this.col�ndice,
            this.colFaixa,
            this.colGrupo,
            this.colPre�oUn,
            this.colPre�oTot});
            this.lista.ContextMenuStrip = this.contextMenuStrip;
            this.lista.FullRowSelect = true;
            listViewGroup1.Header = "Mercadoria de pe�a";
            listViewGroup1.Name = "pe�a";
            listViewGroup2.Header = "Mercadoria de peso";
            listViewGroup2.Name = "peso";
            this.lista.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lista.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lista.HideSelection = false;
            this.lista.LabelWrap = false;
            this.lista.LargeImageList = this.imagensGrandes;
            this.lista.Location = new System.Drawing.Point(0, 24);
            this.lista.Margin = new System.Windows.Forms.Padding(0);
            this.lista.Name = "lista";
            this.lista.ShowGroups = false;
            this.lista.Size = new System.Drawing.Size(717, 410);
            this.lista.SmallImageList = this.imagensPequenas;
            this.lista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lista.TabIndex = 1;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.ItemActivate += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            this.lista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lista_KeyDown);
            this.lista.Resize += new System.EventHandler(this.lista_Resize);
            // 
            // colRefer�ncia
            // 
            this.colRefer�ncia.Text = "Refer�ncia";
            this.colRefer�ncia.Width = 119;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Text = "Quantidade";
            this.colQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQuantidade.Width = 70;
            // 
            // colPeso
            // 
            this.colPeso.Text = "Peso";
            this.colPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col�ndice
            // 
            this.col�ndice.Text = "�ndice";
            this.col�ndice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colFaixa
            // 
            this.colFaixa.DisplayIndex = 5;
            this.colFaixa.Text = "Faixa";
            this.colFaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colGrupo
            // 
            this.colGrupo.DisplayIndex = 4;
            this.colGrupo.Text = "Grupo";
            this.colGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colPre�oUn
            // 
            this.colPre�oUn.Text = "Pre�o Un.";
            this.colPre�oUn.Width = 80;
            // 
            // colPre�oTot
            // 
            this.colPre�oTot.Text = "Pre�o Tot.";
            this.colPre�oTot.Width = 100;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConsultar,
            this.toolStripSeparator3,
            this.mnuExcluir,
            this.mnuAlterar�ndice,
            this.toolStripSeparator4,
            this.mnuInverterSele��oToolStripMenuItem,
            this.mnuCopiarToolStripMenuItem,
            this.mnuColarToolStripMenuItem,
            this.toolStripSeparator5,
            this.mnuSelecionarTudo});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(198, 176);
            // 
            // mnuConsultar
            // 
            this.mnuConsultar.Image = global::Apresenta��o.Resource.propriedades;
            this.mnuConsultar.Name = "mnuConsultar";
            this.mnuConsultar.Size = new System.Drawing.Size(197, 22);
            this.mnuConsultar.Text = "Consultar mercadoria...";
            this.mnuConsultar.Click += new System.EventHandler(this.mnuConsultar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(194, 6);
            // 
            // mnuExcluir
            // 
            this.mnuExcluir.Image = global::Apresenta��o.Resource.Excluir;
            this.mnuExcluir.Name = "mnuExcluir";
            this.mnuExcluir.Size = new System.Drawing.Size(197, 22);
            this.mnuExcluir.Text = "Excluir";
            this.mnuExcluir.Click += new System.EventHandler(this.mnuExcluir_Click);
            // 
            // mnuAlterar�ndice
            // 
            this.mnuAlterar�ndice.Image = global::Apresenta��o.Resource.EditTableHS;
            this.mnuAlterar�ndice.Name = "mnuAlterar�ndice";
            this.mnuAlterar�ndice.Size = new System.Drawing.Size(197, 22);
            this.mnuAlterar�ndice.Text = "Alterar �ndice";
            this.mnuAlterar�ndice.Click += new System.EventHandler(this.alterar�ndiceToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(194, 6);
            // 
            // mnuInverterSele��oToolStripMenuItem
            // 
            this.mnuInverterSele��oToolStripMenuItem.Image = global::Apresenta��o.Resource.arrow_switch;
            this.mnuInverterSele��oToolStripMenuItem.Name = "mnuInverterSele��oToolStripMenuItem";
            this.mnuInverterSele��oToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.mnuInverterSele��oToolStripMenuItem.Text = "Inverter sele��o";
            this.mnuInverterSele��oToolStripMenuItem.Click += new System.EventHandler(this.mnuInverterSele��oToolStripMenuItem_Click);
            // 
            // mnuCopiarToolStripMenuItem
            // 
            this.mnuCopiarToolStripMenuItem.AccessibleDescription = "";
            this.mnuCopiarToolStripMenuItem.Name = "mnuCopiarToolStripMenuItem";
            this.mnuCopiarToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.mnuCopiarToolStripMenuItem.Text = "Copiar";
            this.mnuCopiarToolStripMenuItem.Click += new System.EventHandler(this.mnuCopiarToolStripMenuItem_Click);
            // 
            // mnuColarToolStripMenuItem
            // 
            this.mnuColarToolStripMenuItem.Name = "mnuColarToolStripMenuItem";
            this.mnuColarToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.mnuColarToolStripMenuItem.Text = "Colar";
            this.mnuColarToolStripMenuItem.Click += new System.EventHandler(this.mnuColarToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(194, 6);
            // 
            // mnuSelecionarTudo
            // 
            this.mnuSelecionarTudo.Name = "mnuSelecionarTudo";
            this.mnuSelecionarTudo.Size = new System.Drawing.Size(197, 22);
            this.mnuSelecionarTudo.Text = "Selecionar tudo";
            this.mnuSelecionarTudo.Click += new System.EventHandler(this.mnuSelecionarTudo_Click);
            // 
            // imagensGrandes
            // 
            this.imagensGrandes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagensGrandes.ImageSize = new System.Drawing.Size(32, 32);
            this.imagensGrandes.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imagensPequenas
            // 
            this.imagensPequenas.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagensPequenas.ImageSize = new System.Drawing.Size(20, 20);
            this.imagensPequenas.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imagensBarraFerramentas
            // 
            this.imagensBarraFerramentas.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagensBarraFerramentas.ImageStream")));
            this.imagensBarraFerramentas.TransparentColor = System.Drawing.Color.Transparent;
            this.imagensBarraFerramentas.Images.SetKeyName(0, "");
            this.imagensBarraFerramentas.Images.SetKeyName(1, "");
            this.imagensBarraFerramentas.Images.SetKeyName(2, "");
            this.imagensBarraFerramentas.Images.SetKeyName(3, "");
            this.imagensBarraFerramentas.Images.SetKeyName(4, "");
            this.imagensBarraFerramentas.Images.SetKeyName(5, "");
            this.imagensBarraFerramentas.Images.SetKeyName(6, "");
            this.imagensBarraFerramentas.Images.SetKeyName(7, "");
            this.imagensBarraFerramentas.Images.SetKeyName(8, "");
            this.imagensBarraFerramentas.Images.SetKeyName(9, "");
            this.imagensBarraFerramentas.Images.SetKeyName(10, "Separar");
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 434);
            this.status.Margin = new System.Windows.Forms.Padding(0);
            this.status.Name = "status";
            this.status.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.panelQuantidade,
            this.panelTotalMercadorias,
            this.panelPesoTotal,
            this.panel�ndicePe�a,
            this.panel�ndicePeso,
            this.panel�ndiceTotal,
            this.panelPre�oTotal});
            this.status.ShowPanels = true;
            this.status.Size = new System.Drawing.Size(717, 21);
            this.status.SizingGrip = false;
            this.status.TabIndex = 5;
            this.status.VisibleChanged += new System.EventHandler(this.status_VisibleChanged);
            // 
            // panelQuantidade
            // 
            this.panelQuantidade.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.panelQuantidade.Name = "panelQuantidade";
            this.panelQuantidade.ToolTipText = "Quantidade de \'linhas\' da tabela. N�o necessariamente a quantidade de refer�ncias" +
    ".";
            this.panelQuantidade.Width = 195;
            // 
            // panelTotalMercadorias
            // 
            this.panelTotalMercadorias.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelTotalMercadorias.Name = "panelTotalMercadorias";
            this.panelTotalMercadorias.ToolTipText = "Somat�ria das quantidades de todos os itens";
            this.panelTotalMercadorias.Width = 10;
            // 
            // panelPesoTotal
            // 
            this.panelPesoTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelPesoTotal.Icon = ((System.Drawing.Icon)(resources.GetObject("panelPesoTotal.Icon")));
            this.panelPesoTotal.MinWidth = 100;
            this.panelPesoTotal.Name = "panelPesoTotal";
            this.panelPesoTotal.ToolTipText = "Somat�ria do peso levando em conta as quantidades";
            // 
            // panel�ndicePe�a
            // 
            this.panel�ndicePe�a.Name = "panel�ndicePe�a";
            this.panel�ndicePe�a.Text = "�ndice pe�a: 0";
            this.panel�ndicePe�a.Width = 120;
            // 
            // panel�ndicePeso
            // 
            this.panel�ndicePeso.Name = "panel�ndicePeso";
            this.panel�ndicePeso.Text = "�ndice peso:";
            this.panel�ndicePeso.Width = 120;
            // 
            // panel�ndiceTotal
            // 
            this.panel�ndiceTotal.Name = "panel�ndiceTotal";
            this.panel�ndiceTotal.Text = "�ndice: 0";
            this.panel�ndiceTotal.ToolTipText = "Somat�ria do �ndice";
            // 
            // panelPre�oTotal
            // 
            this.panelPre�oTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelPre�oTotal.Name = "panelPre�oTotal";
            this.panelPre�oTotal.Text = "Pre�o Total";
            this.panelPre�oTotal.Width = 72;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 3000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // barraFerramentas
            // 
            this.barraFerramentas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.barraFerramentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExcluir,
            this.cmbTabela,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.btnAgrupar,
            this.btnSeparar,
            this.btnAlterar�ndice});
            this.barraFerramentas.Location = new System.Drawing.Point(0, 0);
            this.barraFerramentas.Name = "barraFerramentas";
            this.barraFerramentas.Size = new System.Drawing.Size(717, 25);
            this.barraFerramentas.TabIndex = 6;
            this.barraFerramentas.Text = "Barra de ferramentas da bandeja";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::Apresenta��o.Resource.Excluir;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(61, 22);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // cmbTabela
            // 
            this.cmbTabela.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbTabela.AutoToolTip = true;
            this.cmbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(121, 25);
            this.cmbTabela.Sorted = true;
            this.cmbTabela.ToolTipText = "Tabela de pre�os a ser utilizada.";
            this.cmbTabela.SelectedIndexChanged += new System.EventHandler(this.cmbTabela_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.CheckOnClick = true;
            this.btnAgrupar.Image = global::Apresenta��o.Resource.Icone___Janela_explicativa___Confirma��oAgrupamento;
            this.btnAgrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Size = new System.Drawing.Size(70, 22);
            this.btnAgrupar.Text = "Agrupar";
            this.btnAgrupar.Click += new System.EventHandler(this.btnAgrupar_Click);
            // 
            // btnSeparar
            // 
            this.btnSeparar.CheckOnClick = true;
            this.btnSeparar.Image = global::Apresenta��o.Resource.balan�a_pequena;
            this.btnSeparar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(138, 22);
            this.btnSeparar.Text = "Separar pe�a de peso";
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // btnAlterar�ndice
            // 
            this.btnAlterar�ndice.Image = global::Apresenta��o.Resource.EditTableHS;
            this.btnAlterar�ndice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar�ndice.Name = "btnAlterar�ndice";
            this.btnAlterar�ndice.Size = new System.Drawing.Size(97, 22);
            this.btnAlterar�ndice.Text = "Alterar �ndice";
            this.btnAlterar�ndice.Click += new System.EventHandler(this.btnAlterar�ndice_Click);
            // 
            // Bandeja
            // 
            this.Controls.Add(this.barraFerramentas);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lista);
            this.Name = "Bandeja";
            this.Size = new System.Drawing.Size(717, 455);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTotalMercadorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPesoTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel�ndicePe�a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel�ndicePeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel�ndiceTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPre�oTotal)).EndInit();
            this.barraFerramentas.ResumeLayout(false);
            this.barraFerramentas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion // Component Designer

        #region IEnumerable Members

        /// <summary>
        /// Obt�m iterador de ISaquinhos
        /// </summary>
        /// <returns>Iterador de ISaquinhos</returns>
        public IEnumerator GetEnumerator()
        {
            return saquinhos.GetEnumerator();
        }

        public int Count
        {
            get { return saquinhos.Count; }
        }
        
        #endregion // IEnumerable Members

        #region Controles

        protected System.Windows.Forms.ListView lista;
        private System.ComponentModel.IContainer components;
        private volatile System.Windows.Forms.ImageList imagensPequenas;
        private volatile System.Windows.Forms.ImageList imagensGrandes;
        private System.Windows.Forms.ImageList imagensBarraFerramentas;
        protected System.Windows.Forms.ColumnHeader colRefer�ncia;
        protected System.Windows.Forms.ColumnHeader colQuantidade;
        protected System.Windows.Forms.ColumnHeader colPeso;
        protected System.Windows.Forms.ColumnHeader col�ndice;
        protected System.Windows.Forms.ColumnHeader colGrupo;
        protected System.Windows.Forms.ColumnHeader colFaixa;
        private System.Windows.Forms.StatusBarPanel panelQuantidade;
        private System.Windows.Forms.StatusBarPanel panelTotalMercadorias;
        private System.Windows.Forms.StatusBarPanel panelPesoTotal;
        private System.Windows.Forms.StatusBar status;
        private System.Windows.Forms.Timer timerStatus;
        private ColumnHeader colPre�oTot;
        private StatusBarPanel panelPre�oTotal;
        private ColumnHeader colPre�oUn;

        #endregion

        /// <summary>
        /// Obt�m a linha da ListView para uma mercadoria espec�fica.
        /// </summary>
        /// <param name="mercadoria">Mercadoria a ser procurada.</param>
        /// <returns>Linha da ListView que cont�m a Mercadoria.</returns>
        public ListViewItem ObterLinha(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            ISaquinho saquinho = null;

            if (!hashAgrupamento.TryGetValue(new Saquinho(mercadoria, 1).Identifica��oAgrup�vel(), out saquinho))
                return null;

            return hashSaquinhoListViewItem[saquinho];
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirItensSelecionados(true);
        }

        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            Agrupar = btnAgrupar.Checked;

            if (Agrupar)
                AgruparTudo();
        }

        private void btnSeparar_Click(object sender, EventArgs e)
        {
            SepararPe�aPeso = !SepararPe�aPeso;
        }

        private void cmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabela = cmbTabela.SelectedItem as Tabela;

            if (TabelaAlterada != null)
                TabelaAlterada(this, Tabela);
        }

        private void alterar�ndiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count == 1)
            {
                ISaquinho selecionado = hashListViewItemSaquinho[lista.SelectedItems[0]];
                if (Altera��o�ndiceSolicitada != null)
                    Altera��o�ndiceSolicitada(this, selecionado);
            }
        }

        private void btnAlterar�ndice_Click(object sender, EventArgs e)
        {
            alterar�ndiceToolStripMenuItem_Click(sender, e);
        }

        private void mnuInverterSele��oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lista.Items)
                i.Selected = !i.Selected;
        }

        private void mnuCopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void Copiar()
        {
            List<ISaquinho> listaCopia = new List<ISaquinho>(lista.SelectedItems.Count);

            foreach (ListViewItem item in lista.SelectedItems)
                listaCopia.Add(hashListViewItemSaquinho[item]);

            �reaDeTransfer�ncia.Inst�ncia.Copiar(listaCopia);
        }


        private void mnuColarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Colar()
        {
            if (ColarSolicitado != null)
                ColarSolicitado(null, null);
        }

        private void SelecionarTudo()
        {
            foreach (ListViewItem i in lista.Items)
                i.Selected = true;
        }

        private void mnuSelecionarTudo_Click(object sender, EventArgs e)
        {
            SelecionarTudo();
        }
    }
}

