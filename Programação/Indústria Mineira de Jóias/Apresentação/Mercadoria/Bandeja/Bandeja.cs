using Apresentação.Financeiro;
using Apresentação.Formulários;
using Entidades;
using Entidades.Configuração;
using Entidades.Pessoa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Bandeja
{
    /// <summary>
    /// Um saquinho da bandeja nunca deve ser utilizado fora dela.
    /// A bandeja deve sempre copiar os dados ao envia-los para fora.
    /// </summary>
	public class Bandeja : System.Windows.Forms.UserControl, IEnumerable, IPósCargaSistema
	{
        /// <summary>
        /// Tempo que a sinalização de mudança na bandeja
        /// permanece em exibição.
        /// </summary>
        private const int tempoSinalização = 3000;      // milissegundos

        // Coleção de itens
        protected List<ISaquinho> saquinhos;

        // Localização do item da listview ou do saquinho
        private Dictionary<ISaquinho, ListViewItem>     hashSaquinhoListViewItem;
        protected Dictionary<ListViewItem, ISaquinho>   hashListViewItemSaquinho;

        /// <summary>
        /// Tabela a ser utilizada.
        /// </summary>
        private Tabela tabela = null;

        /// <summary>
        /// Tabelas que podem ser escolhidas pelo usuário.
        /// </summary>
        private List<Tabela> tabelas = null;

        /// <summary>
        /// Nem todos os saquinhos estão nesta hash.
        /// A string é criada pelo método IdentificaçãoAgrupável().
        /// Dois objetos agrupáveis devem ter mesma IdentificaçãoAgrupável.
        /// </summary>
        private Dictionary<string, ISaquinho> hashAgrupamento;

        // Atributos das propriedades
        private		bool	agrupar                         = false;				
		private		bool    permitirExclusão	            = true;
        private     bool    suspendeLeiaute                 = false;
        private     bool    abrirInformaçõesAoDuploClique   = true;
        private     bool    permitirSeleçãoTabela           = true;
       
        // Barra de status
		private     double  totalPeso;
        private     double  totalÍndice;
        private     double  totalÍndicePeso;
        private     double  totalÍndicePeça;
		private     double	totalMercadorias;
        private double totalPreço;

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
        private StatusBarPanel panelÍndiceTotal;
        private StatusBarPanel panelÍndicePeça;
        private StatusBarPanel panelÍndicePeso;
        private ToolStripMenuItem mnuAlterarÍndice;
        private ToolStripButton btnAlterarÍndice;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem mnuInverterSeleçãoToolStripMenuItem;
        private ToolStripMenuItem mnuCopiarToolStripMenuItem;
        private ToolStripMenuItem mnuColarToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem mnuSelecionarTudo;
        private volatile bool statusAtualizado;

		// Delegações
		public delegate void DSaquinho(ISaquinho saquinho);
		public delegate void SaquinhoHandler(Bandeja bandeja, ISaquinho saquinho);
		public delegate void SaquinhosHandler(Bandeja bandeja, ISaquinho [] saquinhos);
        public delegate void TabelaCallback(Bandeja bandeja, Tabela tabela);

		// Eventos Disparados
		public event SaquinhoHandler    SeleçãoMudou;
        public event SaquinhoHandler    DuploClique;
        public event SaquinhosHandler   SaquinhosSelecionados;
		public event SaquinhoHandler    SaquinhoExcluído;
        public event SaquinhoHandler    AlteraçãoÍndiceSolicitada;
        public event EventHandler       ColarSolicitado;

        [Description("Disparado somente quando usuário altera a tabela pela interface gráfica.")]
        public event TabelaCallback     TabelaAlterada;

        // Métodos assíncronos
        private delegate void AsyncSinalizarSaquinhoTardiamente(SinalizaçãoCarga sinalizador, Entidades.Mercadoria.Mercadoria mercadoria);

		#region Propriedades

        public bool MostrarAlterarÍndice
        {
            get { return mnuAlterarÍndice.Visible; }
            set 
            { 
                // alterarÍndiceToolStripMenuItem.Visible = value; 
            }
        }

        [DefaultValue(true)]
        public bool MostrarAgrupar
        {
            get { return btnAgrupar.Visible; }
            set { btnAgrupar.Visible = value; }
        }

        [DefaultValue(true), Browsable(true)]
        public bool MostrarSeleçãoTabela
        {
            get { return cmbTabela.Visible; }
            set
            {
                cmbTabela.Visible = toolStripSeparator2.Visible = value;
            }
        }

        [DefaultValue(true), Browsable(true)]
        public bool PermitirSeleçãoTabela
        {
            get { return cmbTabela.Visible && permitirSeleçãoTabela; }
            set
            {
                permitirSeleçãoTabela = cmbTabela.Enabled = toolStripSeparator2.Visible = value;
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
                        if (cotação == null || cotação.Valor == 0)
                            cotação = Entidades.Financeiro.Cotação.ObterCotaçãoVigente(tabela.Moeda);
                    }
                    catch (Entidades.Financeiro.Cotação.CotaçãoInexistente)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "Não existe cotação cadastrada para a tabela de preços utilizada. Por favor, verifique os dados antes de prosseguir.",
                            "Cotação da tabela de preços",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    RecalcularPreço();

                    cmbTabela.Enabled = tabelas == null && permitirSeleçãoTabela;
                }
            }
        }

        /// <summary>
        /// Tabelas que o usuário pode escolher.
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

                cmbTabela.Enabled = permitirSeleçãoTabela && value.Count > 0;
            }
        }

        [Browsable(false)]
        public ListView ListView { get { return lista; } }

        /// <summary>
        /// Define se deve ser exibido o botão para exclusão de mercadoria.
        /// </summary>
        [DefaultValue(true)]
        public bool MostrarExcluir
        {
            get { return btnExcluir.Visible; }
            set { btnExcluir.Visible = toolStripSeparator1.Visible = value; }
        }

        /// <summary>
        /// Define se deve ser exibido o preço das mercadorias.
        /// </summary>
        [Browsable(true), Description("Define se deve ser exibido o preço das mercadorias.")]
        public bool MostrarPreço
        {
            get { return lista.Columns.Contains(colPreçoUn); }
            set
            {
                if (value && !lista.Columns.Contains(colPreçoUn))
                {
                    lista.Columns.Add(colPreçoUn);
                    lista.Columns.Add(colPreçoTot);
                    status.Panels.Add(panelPreçoTotal);
                }
                else
                {
                    lista.Columns.Remove(colPreçoTot);
                    lista.Columns.Remove(colPreçoUn);
                    status.Panels.Remove(panelPreçoTotal);
                }
            }
        }

        [Browsable(true), DefaultValue(true)]
        [Description("Ao duplo clique, a janela de informações da mercadoria será aberta automaticamente")]
        public bool AbrirInformaçõesAoDuploClique
        {
            get { return abrirInformaçõesAoDuploClique; }
            set { abrirInformaçõesAoDuploClique = value; }
        }

        /// <summary>
        /// Primeiro ISaquinho da seleção. Pode ser null.
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
		/// Para de redesenhar a aparência, incluindo controles
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
		public bool PermitirExclusão
		{
			get
			{ 
				return permitirExclusão; 
			}
			set
			{
				permitirExclusão = value;
                AtualizarEnabledBotõesBarraFerramentas();

                try
                {
                    btnExcluir.ToolTipText = value ? "Exluir os itens selecionados" : "Esta bandeja não permite exclusão dos itens";
                }
                catch { }
			}
		}
		
		[Browsable(true)]
		[Description("Ordenação automática da referência. coloca lista.SortOrder como 'Ascending'")]
		public bool OrdenaçãoReferência
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

                DefinirBotãoAgrupamento(value);
			}
		}

        private delegate void DefinirBotãoAgrupamentoCallback(bool value);

        private void DefinirBotãoAgrupamento(bool value)
        {
            if (InvokeRequired)
            {
                DefinirBotãoAgrupamentoCallback método = new DefinirBotãoAgrupamentoCallback(DefinirBotãoAgrupamento);
                BeginInvoke(método, value);
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
        public bool SepararPeçaPeso
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
                        item.Group = lista.Groups[hashListViewItemSaquinho[item].Mercadoria.DePeso ? "peso" : "peça"];
            }
        }

		#endregion // Propriedades

		/// <summary>
		/// Constrói a bandeja
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

            if (PermitirSeleçãoTabela && Tabelas == null)
                Tabelas = Tabela.ObterTabelas(Funcionário.FuncionárioAtual.Setor);
        }

		#region Tratamento de Eventos de Interface e ISaquinho
		
		/// <summary>
		/// Porque isto não está no set de MostrarStatus ?
		/// Porquê pode ser que alguem dê um bandeja.Visible = false,
		/// e então o status automaticamente tem seu visible falso.
		/// Quando o usuário recupera a visibilidade da bandeja,
		/// é necessário executar o código abaixo, que não seria chamado
		/// se colocado no set de MostrarStatus.
		/// </summary>
		private void status_VisibleChanged(object sender, System.EventArgs e)
		{
			AjustarDimensõesLista();
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
			AjustarDimensõesLista();
		}

		private void lista_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Delete && permitirExclusão && lista.SelectedItems.Count > 0) 
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
		/// Mostar informações de uma referência
		/// </summary>
		private void mnuConsultar_Click(object sender, System.EventArgs e)
		{
            if (lista.SelectedItems.Count > 15)
                return;

            UseWaitCursor = true;

			foreach (ListViewItem item in lista.SelectedItems)
			{
				InformaçõesMercadoriaResumo dlg;
				ISaquinho              ISaquinho;

                ISaquinho = hashListViewItemSaquinho[item];

				dlg = new InformaçõesMercadoriaResumo(ISaquinho.Mercadoria, this.Cotação);
	
				dlg.Owner = this.ParentForm;

				dlg.Show();
			}

            UseWaitCursor = false;
		}
		
		/// <summary>
		/// Ocorre ao selecionar um ou mais itens na ListView
		/// Sempre que é selecionado e ocorre a desseleção de outro,
		/// o evento é disparado com parâmetro null. 
		/// </summary>
		private void lista_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int nISaquinhos;

            UseWaitCursor = true;
			nISaquinhos = lista.SelectedItems.Count;

			if (nISaquinhos == 0)
			{
				// Como não tem ISaquinho selecionado, o parametro null é passado.
				if (SeleçãoMudou != null)
					SeleçãoMudou(this, null);

				if (SaquinhosSelecionados != null)
					SaquinhosSelecionados(this, new ISaquinho[0]);
			}
			if (nISaquinhos == 1 && SeleçãoMudou != null)
			{
                //SeleçãoMudou(this, (ISaquinho) items[lista.SelectedItems[0]]);
                SeleçãoMudou(this, hashListViewItemSaquinho[lista.SelectedItems[0]]);

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

			AtualizarEnabledBotõesBarraFerramentas();
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

            if (abrirInformaçõesAoDuploClique)
			    mnuConsultar_Click(sender, e);
		}

		#endregion // Tratamento de eventos

		#region Métodos - Aparência

		/// <summary>
		/// Ajusta as dimensões da lista.
		/// </summary>
		private void AjustarDimensõesLista()
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
        /// Limpa status para que este não mostre informação antiga
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
                panelÍndiceTotal.Text = "";
                panelÍndicePeso.Text = "";
                panelÍndicePeça.Text = "";
                panelPreçoTotal.Text = "";
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
                        AtualizarStatusCallBack método = new AtualizarStatusCallBack(AtualizarStatus);
                        this.BeginInvoke(método);
                    }
                    else
                    {
                        timerStatus.Enabled = false;

                        statusAtualizado = true;

#if DEBUG
                    if (!MostrarStatus)
                        throw new Exception("foi chamado o AtualizarStatus, mas o mostrarStatus começou igual a false. Faça verificação antes de chamar");
#endif

                        List<ISaquinho> listaEntidades;

                        double totalMercadorias = 0;
                        double totalPeso = 0;
                        double totalÍndice = 0;
                        double totalÍndicePeso = 0;
                        double totalÍndicePeça = 0;
                        double totalPreço = 0;
                        //string    totalPesoStr;
                        bool selecionados = (lista.SelectedItems.Count > 0);

                        if (selecionados)
                        {
                            listaEntidades = new List<ISaquinho>(lista.SelectedItems.Count);

                            foreach (ListViewItem itemLista in lista.SelectedItems)
                                listaEntidades.Add(hashListViewItemSaquinho[itemLista]);

                            try
                            {
                                panelTotalMercadorias.ToolTipText = "Somatória da quantidade de mercadorias de cada item selecionado";
                                panelPesoTotal.ToolTipText = "Peso de todas as mercadorias levando em conta a quantidade de cada referência";
                            }
                            catch { }

#if DEBUG
                        if (listaEntidades == null)
                            throw new Exception("Bandeja.AtualizarStatus() -> listaEntidades é null");
#endif

                            foreach (ISaquinho s in listaEntidades)
                            {
                                totalMercadorias += s.Quantidade;
                                totalPeso += s.Peso * s.Quantidade;
                                totalÍndice += s.Mercadoria.ÍndiceArredondado * s.Quantidade;
                                if (s.Mercadoria.DePeso)
                                    totalÍndicePeso += s.Mercadoria.ÍndiceArredondado * s.Quantidade;
                                else
                                    totalÍndicePeça += s.Mercadoria.ÍndiceArredondado * s.Quantidade;

                                if (cotação != null)
                                    totalPreço += CalcularValor(s);
                            }
                        }
                        else
                        {
                            listaEntidades = saquinhos;
                            totalPeso = this.totalPeso;
                            totalÍndice = this.totalÍndice;
                            totalÍndicePeça = this.totalÍndicePeça;
                            totalÍndicePeso = this.totalÍndicePeso;

                            totalMercadorias = this.totalMercadorias;
                            totalPreço = this.totalPreço;

                            try
                            {
                                panelQuantidade.ToolTipText = "Total de \"linhas\" ou itens da tabela, não necessariamente o número de referências.";
                                panelTotalMercadorias.ToolTipText = "Somatória das quantidades de mercadorias";
                                panelPesoTotal.ToolTipText = "Peso de todas as mercadorias selecionadas levando em conta a quantidade de cada referência";
                                panelÍndiceTotal.ToolTipText = "Índice de todas as mercadorias selecionadas levando em conta a quantidade de cada referência";
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
                                    panelQuantidade.ToolTipText = "Descrição da mercadoria selecionada cuja referência é " + merc.Referência;
                                }
                                catch { }

                                panelQuantidade.Text = merc.Descrição;
                            }
                        else // listaEntidades.ISaquinho.ISaquinhos.Count == 0
                            panelQuantidade.Text = "Nenhum item para exibição";

                        panelPesoTotal.Text = Entidades.Mercadoria.Mercadoria.FormatarPeso(totalPeso);
                        panelÍndiceTotal.Text = "Índice: " + Entidades.Mercadoria.Mercadoria.FormatarÍndice(totalÍndice);
                        panelÍndicePeça.Text = "Índice (Peça): " + Entidades.Mercadoria.Mercadoria.FormatarÍndice(totalÍndicePeça);
                        panelÍndicePeso.Text = "Índice (Peso): " + Entidades.Mercadoria.Mercadoria.FormatarÍndice(totalÍndicePeso);

                        if (totalMercadorias > 0)
                            panelTotalMercadorias.Text = totalMercadorias.ToString() + " mercadoria";
                        else
                            panelTotalMercadorias.Text = "";

                        // Plural
                        if (totalMercadorias > 1) panelTotalMercadorias.Text += "s";

                        if (cotação != null)
                            panelPreçoTotal.Text = totalPreço.ToString("C", DadosGlobais.Instância.Cultura.NumberFormat);
                        else
                            panelPreçoTotal.Text = "";
                    }
                }
            }
#if !DEBUG
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);

                MostrarStatus = false;
            }
#endif
		}

        private double CalcularValor(ISaquinho s)
        {
            return Math.Round(s.Mercadoria.CalcularPreço(cotação) * s.Quantidade, 2);
        }

		private void AtualizarEnabledBotõesBarraFerramentas()
		{
			if (lista.SelectedItems.Count == 0)
			{
				btnExcluir.Enabled = false;
                mnuExcluir.Enabled = false;
                mnuAlterarÍndice.Enabled = false;
                btnAlterarÍndice.Enabled = false;
                //btnAlterar.Enabled = false;
				mnuConsultar.Enabled = false;
                //btnDescer.Enabled = false;
                //btnSubir.Enabled = false;
			}
			else
			{
				btnExcluir.Enabled = permitirExclusão;
                //btnAlterar.Enabled = true;
                mnuAlterarÍndice.Enabled = permitirExclusão;
                btnAlterarÍndice.Enabled = permitirExclusão;
				mnuExcluir.Enabled = permitirExclusão;
				mnuConsultar.Enabled = true;
				
                ////Subir e descer só quando tem apenas 1 selecionado.
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
			int posição;

			item = lista.SelectedItems[0];
			posição = item.Index;

			item.Remove();

			lista.Items.Insert(posição - 1, item);
		
			item.EnsureVisible();
			item.Selected = true;
		}

		/// <summary>
		/// Desce item selecionado
		/// </summary>
		private void DescerItemSelecionado()
		{
			ListViewItem item;
			int posição;

			item = lista.SelectedItems[0];
			posição = item.Index;

			item.Remove();

			lista.Items.Insert(posição + 1, item);

            AtualizarEnabledBotõesBarraFerramentas();

			item.EnsureVisible();
			item.Selected = true;
		}

		/// <summary>
		/// Apenas adiciona o essencial: Referência e Quantidade.
		/// </summary>
		protected virtual ListViewItem ConstruirListView(Entidades.ISaquinho saquinho)
		{
			ListViewItem novoItemListView;
			
            // Gera o item 
			novoItemListView = new ListViewItem(saquinho.Mercadoria.Referência);

            // Relaciona dos dicionários
            hashListViewItemSaquinho.Add(novoItemListView, saquinho);
            hashSaquinhoListViewItem.Add(saquinho, novoItemListView);

            // Prepara futuro agrupamento com este:
            string identificação = saquinho.IdentificaçãoAgrupável();

            if (!hashAgrupamento.ContainsKey(identificação))
                hashAgrupamento.Add(identificação, saquinho);
						
			// lista.Items.Add(novoItemListView);
			novoItemListView.SubItems.Add(saquinho.Quantidade.ToString());
			novoItemListView.SubItems.AddRange(new string[] {"","","","","","","","","",""});

            // Preenche campos específicos do listviewitem
            AtualizaElementoListView(saquinho, novoItemListView);

			// A tag é necessária para exibição futura da foto.
			novoItemListView.Tag = saquinho.Mercadoria;

            AdicionarFoto(novoItemListView, saquinho.Mercadoria.Ícone);
			return novoItemListView;
		}

		/// <summary>
		/// Atualiza elementos na ListView
		/// </summary>
		/// <param name="ISaquinho">Entidades.ISaquinho.ISaquinho a ser atualizado</param>
		/// <param name="item">Item da ListView</param>
		protected virtual void AtualizaElementoListView(ISaquinho saquinho, ListViewItem item)
		{
            if (colReferência.Index == -1)
                return;

			item.SubItems[colReferência.Index].Text = saquinho.Mercadoria.Referência;
            item.SubItems[colReferência.Index].Name = colReferência.Text;
			item.SubItems[colQuantidade.Index].Text = saquinho.Quantidade.ToString();
            item.SubItems[colQuantidade.Index].Name = colQuantidade.Text;
            item.SubItems[colPeso.Index].Text = saquinho.Peso.ToString("0.00");
            item.SubItems[colPeso.Index].Name = colPeso.Text;
            item.SubItems[colÍndice.Index].Text = Entidades.Mercadoria.Mercadoria.FormatarÍndice(saquinho.Mercadoria.ÍndiceArredondado);
            item.SubItems[colÍndice.Index].Name = colÍndice.Text;
			item.SubItems[colGrupo.Index].Text = saquinho.Mercadoria.Grupo.ToString();
            item.SubItems[colGrupo.Index].Name = colGrupo.Text;
			item.SubItems[colFaixa.Index].Text = (saquinho.Mercadoria.Faixa != null ? saquinho.Mercadoria.Faixa.ToString() : "");
            item.SubItems[colFaixa.Index].Name = colFaixa.Text;

            System.Globalization.CultureInfo cultura = DadosGlobais.Instância.Cultura;

            if (MostrarPreço)
            {
                double valorTotal = CalcularValor(saquinho);
                item.SubItems[colPreçoTot.Index].Text = valorTotal.ToString("C", cultura);
                item.SubItems[colPreçoUn.Index].Text = saquinho.Mercadoria.CalcularPreço(cotação);
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
            totalÍndice = 0;
            totalÍndicePeso = 0;
            totalÍndicePeça = 0;
		}

        /// <summary>
        /// Coloca o foco em um item específico.
        /// Dispara excessão se não acha o item.
        /// </summary>
        /// <param name="s">Pode ser outro saquinho, desde que bandeja tenha outro com mesma referencia e peso.</param>
        public void Selecionar(Entidades.Mercadoria.Mercadoria m)
        {
            ListViewItem itemListView;

            ISaquinho saquinho = null;

            // Tentativa de obter algum ISaquinho parecido para remoção
            if (!hashAgrupamento.TryGetValue(new Saquinho(m, 1).IdentificaçãoAgrupável(), out saquinho))
                throw new Exception("Tentativa selecionar um saquinho que não existia na bandeja");

            itemListView = hashSaquinhoListViewItem[saquinho];

            // Deixa apenas o item encontrado selecionado.
            lista.SelectedItems.Clear();
            itemListView.Selected = true;
            itemListView.EnsureVisible();
        }

        public bool Contém(Entidades.Mercadoria.Mercadoria m)
        {
            return (hashAgrupamento.ContainsKey(new Saquinho(m, 1).IdentificaçãoAgrupável()));
        }

#endregion

        #region Agrupamento

        /// <summary>
        /// Retorna uma lista de saquinhos agrupáveis com o fornecido.
        /// Na lista inclui-se o próprio item de origem.
        /// </summary>
		protected List<Saquinho> ObterAgrupáveis(Entidades.ISaquinho origem)
		{
            List<Saquinho> semelhantes = new List<Saquinho>();

			// Obtem a hash do objeto de origem para comparação
			string identificação = origem.IdentificaçãoAgrupável();

			// Verifica se existe chave de semelhança na hash.
            if (hashAgrupamento.ContainsKey(identificação))
			{
				foreach (Saquinho s in saquinhos)
					if (identificação.Equals(s.IdentificaçãoAgrupável()))
						semelhantes.Add(s);
			}

            return semelhantes;
		}

	
		/// <summary>
		/// Agrupa todos os saquinhos agrupáveis.
        /// Pergunta nada ao usuário.
		/// </summary>
        private void AgruparTudo()
        {
            if (!agrupar)
                throw new Exception("Tentativa de AgruparTudo() quando agrupar=false");

            ArrayList cópiaSaquinhos = new ArrayList(this.saquinhos);

            while (cópiaSaquinhos.Count > 0)
            {
                List<Saquinho> agrupáveisAoSaquinhoAtual;
                Entidades.Saquinho saquinhoAtual;

                saquinhoAtual = (Entidades.Saquinho)cópiaSaquinhos[0];

                //// Garante o fim do while:
                cópiaSaquinhos.Remove(saquinhoAtual);

                agrupáveisAoSaquinhoAtual = AgruparItem(saquinhoAtual);

                // Retira os saquinhos que serão eliminados da cópia
                foreach (Entidades.ISaquinho s in agrupáveisAoSaquinhoAtual)
                    cópiaSaquinhos.Remove(s);
            }
        }

        /// <summary>
        /// Remove vários saquinhos semelhantes ao do parametro e adiciona um que substitui todos.
        /// </summary>
        /// <remarks> O saquinhoAtual já deve estar na bandeja </remarks>
        /// <param name="saquinhoAtual"></param>
        /// <returns>Saquinhos agrupáveis ao atual, incluíndo o do parametro</returns>
        private List<Saquinho> AgruparItem(ISaquinho saquinhoAtual)
        {
            List<Saquinho> agrupáveisAoSaquinhoAtual;
            agrupáveisAoSaquinhoAtual = ObterAgrupáveis(saquinhoAtual);

            // Se for um, tem apenas ele mesmo.
            if (agrupáveisAoSaquinhoAtual.Count > 1)
            {
                double totalQtd = 0;

                // Retira os saquinhos que serão eliminados da cópia
                foreach (Entidades.ISaquinho s in agrupáveisAoSaquinhoAtual)
                {
                    totalQtd += s.Quantidade;
                    RemoverInterno(s);
                }

                // Adiciona novo saquinho que é equivalente ao grupo
                ISaquinho novoSaquinho = saquinhoAtual.Clone(totalQtd);
                Adicionar(novoSaquinho, false);
            }

            return agrupáveisAoSaquinhoAtual;
        }

		#endregion

		#region Métodos - Funcionamento

		///<summary>
		/// Atualiza objetos intrinsecos à bandeja. Vai no Banco de dados e atualiza os objetos dos ISaquinhos
		/// Não atualiza nada da listview, porque as informações atualizadas são internas (instrínsecas, não visíveis).
		/// </summary>
		public void AtualizaObjetosInstrínsecosDosSaquinhos()
		{
			foreach (Saquinho saquinhoAtual in saquinhos)
				saquinhoAtual.AtualizaObjetosIntrínsecos();
		}

		public virtual Saquinho ConstruirSaquinhoVazio()
		{	return new Saquinho(null, 0); 	}

        /// <summary>
        /// Sinaliza adição ou remoção na bandeja, mostrando
        /// controle SinalizaçãoCarga com a mudança.
        /// Caso o ícone não esteja pronto, ele é carregado
        /// em segundo plano.
        /// </summary>
        private void SinalizarSaquinho(ISaquinho saquinho)
        {
            if (saquinho.Mercadoria.Ícone != null)
                SinalizaçãoCarga.Sinalizar(lista, saquinho.Mercadoria.Referência,
                    (saquinho.Mercadoria.DePeso
                    ? String.Format("{0} {1} unidade(s) com peso {2}.", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade), saquinho.Peso)
                    : String.Format("{0} {1} unidade(s).", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade))),
                    saquinho.Mercadoria.Ícone ?? new Bitmap(1, 1)).IniciarTemporizador(tempoSinalização);
            else
            {
                AsyncSinalizarSaquinhoTardiamente método = new AsyncSinalizarSaquinhoTardiamente(SinalizarSaquinhoTardiamente);
                SinalizaçãoCarga sinalização = SinalizaçãoCarga.Sinalizar(lista, saquinho.Mercadoria.Referência,
                    (saquinho.Mercadoria.DePeso
                    ? String.Format("{0} {1} unidade(s) com peso {2}.", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade), saquinho.Peso)
                    : String.Format("{0} {1} unidade(s).", (saquinho.Quantidade > 0 ? "Adicionada(s)" : "Removida(s)"), Math.Abs(saquinho.Quantidade))));

                sinalização.IniciarTemporizador(tempoSinalização);

                método.BeginInvoke(sinalização, saquinho.Mercadoria, new AsyncCallback(CallbackSinalizarSaquinhoTardiamente), método);
            }
        }

        private void CallbackSinalizarSaquinhoTardiamente(IAsyncResult resultado)
        {
            AsyncSinalizarSaquinhoTardiamente método = (AsyncSinalizarSaquinhoTardiamente)resultado.AsyncState;
            método.EndInvoke(resultado);
        }

        /// <summary>
        /// Atribui ícone da mercadoria à sinalização feita pelo método
        /// SinalizarSaquinho. Esta função é chamada por uma nova thread.
        /// </summary>
        /// <param name="obj">Vetor contendo SinalizaçãoCarga e Mercadoria.</param>
        private void SinalizarSaquinhoTardiamente(SinalizaçãoCarga sinalização, Entidades.Mercadoria.Mercadoria mercadoria)
        {
            try
            {
                sinalização.Imagem = mercadoria.Ícone;
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
                /* É concebido que a bandeja já está completamente agrupado.
                 * Portanto, só devemos olhar por um item apenas.
                 */
                string chave = saquinhoOriginal.IdentificaçãoAgrupável();
                ISaquinho agrupável = null;
                if (hashAgrupamento.TryGetValue(chave, out agrupável))
                {
                    // O próprio Remover() irá retirar da hashAgrupamento.
                    //hashAgrupamento.Remove(chave);
                    saquinhoOriginal = saquinhoOriginal.Clone(saquinhoOriginal.Quantidade + agrupável.Quantidade);
                    RemoverInterno(agrupável);
                    hashAgrupamento[chave] = saquinhoOriginal;
                }
            }
            
            saquinhos.Add(saquinhoOriginal);
            
            item = ConstruirListView(saquinhoOriginal);

            lista.Items.Add(item);
            item.EnsureVisible();

            item.Group = lista.Groups[saquinhoOriginal.Mercadoria.DePeso ? "peso" : "peça"];

            // Atualiza contagem para status
            totalMercadorias += saquinhoOriginal.Quantidade;
            totalPeso += saquinhoOriginal.Quantidade * saquinhoOriginal.Peso;
            totalÍndice += saquinhoOriginal.Quantidade * saquinhoOriginal.Mercadoria.ÍndiceArredondado;

            if (saquinhoOriginal.Mercadoria.DePeso)
                totalÍndicePeso += saquinhoOriginal.Quantidade * saquinhoOriginal.Mercadoria.ÍndiceArredondado;
            else
                totalÍndicePeça += saquinhoOriginal.Quantidade * saquinhoOriginal.Mercadoria.ÍndiceArredondado;

            if (cotação != null)
                totalPreço += CalcularValor(saquinhoOriginal);

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

            AdicionarVários(lista, agrupar);
        }

        public void AdicionarVários(ArrayList listaSaquinhos, bool agrupar)
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
                    string chave = s.IdentificaçãoAgrupável();
                    ISaquinho agrupável = null;
                    if (hashAgrupamento.TryGetValue(chave, out agrupável))
                    {
                        sOuNovo = SubstituirSaquinho(s, sOuNovo, chave, agrupável);
                    }
                }

                saquinhos.Add(sOuNovo);

                item = ConstruirListView(sOuNovo);
                item.Group = lista.Groups[sOuNovo.Mercadoria.DePeso ? "peso" : "peça"];

                itens[x++] = item;

                AtualizaContagemStatus(sOuNovo);
            }
            
            lista.Items.AddRange(itens);
            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        private ISaquinho SubstituirSaquinho(ISaquinho s, ISaquinho sOuNovo, string chave, ISaquinho agrupável)
        {
            hashAgrupamento.Remove(chave);
            sOuNovo = s.Clone(s.Quantidade + agrupável.Quantidade);
            hashAgrupamento[chave] = sOuNovo;

            RemoverInterno(agrupável);
            return sOuNovo;
        }

        private void AtualizaContagemStatus(ISaquinho sOuNovo)
        {
            totalMercadorias += sOuNovo.Quantidade;
            totalPeso += sOuNovo.Quantidade * sOuNovo.Peso;
            totalÍndice += sOuNovo.Quantidade * sOuNovo.Mercadoria.ÍndiceArredondado;
            if (sOuNovo.Mercadoria.DePeso)
                totalÍndicePeso += sOuNovo.Quantidade * sOuNovo.Mercadoria.ÍndiceArredondado;
            else
                totalÍndicePeça += sOuNovo.Quantidade * sOuNovo.Mercadoria.ÍndiceArredondado;

            if (cotação != null)
                totalPreço += CalcularValor(sOuNovo);
        }

        /// <summary>
        /// É o mesmo efeito que chamar várias vezes Adicionar, porém é um método
        /// mais rápido
        /// </summary>
        /// <param name="ISaquinhos"></param>
        public void AdicionarVários(ArrayList listaSaquinhos)
        {
            AdicionarVários(listaSaquinhos, agrupar);
        }
    
        /// <summary>
		/// Remove um saquinho da bandeja.
        /// O Saquinho pode ou não estar na bandeja. Caso não esteja, um agrupável é parcialmente removido.
		/// </summary>
        public void Remover(ISaquinho s)
        {
            RemoverInterno(s);

            if (SaquinhoExcluído != null)
                SaquinhoExcluído(this, s);
        }

		private void RemoverInterno(ISaquinho s)
		{
            double quantidadeRemanescente = 0;
            ListViewItem itemListView;

            if (!saquinhos.Contains(s))
            {
                ISaquinho saquinhoAlternativo = null;

                // Tentativa de obter algum ISaquinho parecido para remoção
                hashAgrupamento.TryGetValue(s.IdentificaçãoAgrupável(), out saquinhoAlternativo);

                if ((saquinhoAlternativo == null) || (quantidadeRemanescente < 0))
                    throw new Exception("Tentativa de remover um saquinho que não existia na bandeja");
                else
                {
                    quantidadeRemanescente = saquinhoAlternativo.Quantidade - s.Quantidade;
                    s = saquinhoAlternativo;
                }
            }

            itemListView = hashSaquinhoListViewItem[s];

			// Atualiza hash items
			hashAgrupamento.Remove(s.IdentificaçãoAgrupável());
            hashListViewItemSaquinho.Remove(itemListView);
            hashSaquinhoListViewItem.Remove(s);

            #if DEBUG
                if (SuspendeLeiaute)
                    throw new Exception("Tentativa de remover um item de listView com o leiatue suspenso. Devido à bug do VS isto causa um dead lock. Bug verificado tambem no VS2005");
            #endif

            itemListView.Remove();
			
			/* Podem existir vários sáquinhos agrupáveis
			 * Vários outros agrupaveis a este talvés não foram adicionados na hash
			 * uma vez que este já estava referenciado nela.
			 * Portanto, deve-se procurar por outro agrupável para ser referenciado.
             */

            saquinhos.Remove(s);

            string identificação = s.IdentificaçãoAgrupável();

			foreach (ISaquinho saquinho in saquinhos)
			{
				if (saquinho.IdentificaçãoAgrupável() == identificação)
				{
					hashAgrupamento.Add(identificação, (Saquinho) saquinho);
					break;
				}
			}

            // Atualiza dados da barra de status.
			totalMercadorias -= s.Quantidade;
			totalPeso        -= s.Quantidade * s.Peso;
            totalÍndice      -= s.Quantidade * s.Mercadoria.ÍndiceArredondado;

            if (s.Mercadoria.DePeso)
                totalÍndicePeso -= s.Quantidade * s.Mercadoria.ÍndiceArredondado;
            else
                totalÍndicePeça -= s.Quantidade * s.Mercadoria.ÍndiceArredondado;


            if (cotação != null)
                totalPreço -= CalcularValor(s);

            if (quantidadeRemanescente > 0)
            {
                ISaquinho novoSaquinho = s.Clone(quantidadeRemanescente);

                Adicionar(novoSaquinho);
            }

            AtualizarEnabledBotõesBarraFerramentas();
		}

		/// <summary>
		/// Exclui itens selecionados
		/// </summary>
		public void ExcluirItensSelecionados(bool pedirConfirmação)
		{
			String mensagem;

			switch (lista.SelectedItems.Count)
			{
				case 0:
					throw new Exception("Não é possível remover 0 itens");

				case 1:
					mensagem = "Deseja retirar a mercadoria " + lista.SelectedItems[0].Text + " da bandeja?";
					break;
				default:
					mensagem = "Deseja retirar os " + lista.SelectedItems.Count + " itens selecionados?";
					break;
			}

			if (MessageBox.Show(this.ParentForm, mensagem, "Exclusão", MessageBoxButtons.YesNo,  MessageBoxIcon.Question) == DialogResult.No)
				return;
			else
				ExcluirSelecionados();
		}

        public delegate void AntesExclusãoDelegate(ref bool cancelado);

        /// <summary>
        /// Evento disparado antes que bandeja retira itens,
        /// quando usuário clica em excluir. Evento não é disparado
        /// quando exclusão é solicitada externamente.
        /// 
        /// Normalmente se proibe exclusão na bandeja pela propriedade
        /// PermitirExclusão,
        /// 
        /// Porém o mundo externo à bandeja pode decidir que a bandeja
        /// não se altere assim que alguem tenta alterá-lo.
        /// 
        /// Caso torno muito frequente o uso deste evento pelo programa,
        /// criar uma delegação na bandeja, um método que a bandeja irá
        /// chamar para descobrir se o usuário está livre para fazer o que quiser.
        /// </summary>
        public event AntesExclusãoDelegate AntesExclusão;
            
		/// <summary>
		/// Exclui sem perguntar ao usuário
		/// </summary>
		protected virtual void ExcluirSelecionados()
		{
            bool cancelado = false;

            if (AntesExclusão != null) AntesExclusão(ref cancelado);
            if (cancelado) return;

			ArrayList exclusão = new ArrayList(lista.SelectedItems.Count);
            ArrayList listaExcluídos = new ArrayList();

			foreach (ListViewItem item in lista.SelectedItems)
				exclusão.Add(item);

            // A remoção trava o VS com leiaute suspenso. (até no VS2005)
			//SuspendeLeiaute = true;

			foreach (ListViewItem item in exclusão)
			{
				ISaquinho s = hashListViewItemSaquinho[item];

                if (item.Selected)
                {
                    Remover((Saquinho) s);
                    listaExcluídos.Add(s);
                }
			}
		}

		#endregion // Métodos funcionamento

		/// <summary>
		/// Acesso aos ISaquinhos
		/// </summary>
		public Entidades.ISaquinho this[int i]
		{
			get { return (ISaquinho) saquinhos[i]; }
		}

		/// <summary>
		/// Adiciona foto na ListView de forma segura em relação à thread.
		/// </summary>
		/// <param name="item">Item da ListView cuja foto será adicionada.</param>
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
	
        #region Cotação

        private Entidades.Financeiro.Cotação cotação;
        
        /// <summary>
        /// É atribuído automaticamente pelo controle de cotação, que conhece a bandeja.
        /// Sua alteração atualiza imediatamente a exibição dos preços na bandeja.
        /// </summary>
        [ReadOnly(true), Browsable(false)]
        public Entidades.Financeiro.Cotação Cotação
        {
            get { return cotação; }
            set 
            { 
                cotação = value; 
                RecalcularPreço();
            }
        }

#endregion

		#region Ordenação flexível - ainda não impementado
	
		/*
		 * veja evento (lista clique na coluna)
			public class ListViewItemOrdenação : IComparer
			{	
				private int coluna;
		
				public ListViewItemOrdenação(int coluna)
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

        private void RecalcularPreço()
        {
            // Atualiza a lista
            SuspendeLeiaute = true;

            foreach (ISaquinho s in saquinhos)
                AtualizaElementoListView(s, hashSaquinhoListViewItem[s]);

            totalPreço = 0;

            if (cotação != null)
            {
                foreach (ISaquinho s in saquinhos)
                    totalPreço += CalcularValor(s);
            }

            if (MostrarStatus)
                AtualizarStatus();

            SuspendeLeiaute = false;
        }

        private void lista_Resize(object sender, EventArgs e)
        {
                AjustarDimensõesLista();
        }

        #region IPósCargaSistema Members

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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Mercadoria de peça", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Mercadoria de peso", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bandeja));
            this.lista = new System.Windows.Forms.ListView();
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPeso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colÍndice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFaixa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrupo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPreçoUn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPreçoTot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuConsultar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlterarÍndice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInverterSeleçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panelÍndicePeça = new System.Windows.Forms.StatusBarPanel();
            this.panelÍndicePeso = new System.Windows.Forms.StatusBarPanel();
            this.panelÍndiceTotal = new System.Windows.Forms.StatusBarPanel();
            this.panelPreçoTotal = new System.Windows.Forms.StatusBarPanel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.barraFerramentas = new System.Windows.Forms.ToolStrip();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.cmbTabela = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgrupar = new System.Windows.Forms.ToolStripButton();
            this.btnSeparar = new System.Windows.Forms.ToolStripButton();
            this.btnAlterarÍndice = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTotalMercadorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPesoTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelÍndicePeça)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelÍndicePeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelÍndiceTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPreçoTotal)).BeginInit();
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
            this.colReferência,
            this.colQuantidade,
            this.colPeso,
            this.colÍndice,
            this.colFaixa,
            this.colGrupo,
            this.colPreçoUn,
            this.colPreçoTot});
            this.lista.ContextMenuStrip = this.contextMenuStrip;
            this.lista.FullRowSelect = true;
            listViewGroup1.Header = "Mercadoria de peça";
            listViewGroup1.Name = "peça";
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
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            this.colReferência.Width = 119;
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
            // colÍndice
            // 
            this.colÍndice.Text = "Índice";
            this.colÍndice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // colPreçoUn
            // 
            this.colPreçoUn.Text = "Preço Un.";
            this.colPreçoUn.Width = 80;
            // 
            // colPreçoTot
            // 
            this.colPreçoTot.Text = "Preço Tot.";
            this.colPreçoTot.Width = 100;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConsultar,
            this.toolStripSeparator3,
            this.mnuExcluir,
            this.mnuAlterarÍndice,
            this.toolStripSeparator4,
            this.mnuInverterSeleçãoToolStripMenuItem,
            this.mnuCopiarToolStripMenuItem,
            this.mnuColarToolStripMenuItem,
            this.toolStripSeparator5,
            this.mnuSelecionarTudo});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(198, 176);
            // 
            // mnuConsultar
            // 
            this.mnuConsultar.Image = global::Apresentação.Resource.propriedades;
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
            this.mnuExcluir.Image = global::Apresentação.Resource.Excluir;
            this.mnuExcluir.Name = "mnuExcluir";
            this.mnuExcluir.Size = new System.Drawing.Size(197, 22);
            this.mnuExcluir.Text = "Excluir";
            this.mnuExcluir.Click += new System.EventHandler(this.mnuExcluir_Click);
            // 
            // mnuAlterarÍndice
            // 
            this.mnuAlterarÍndice.Image = global::Apresentação.Resource.EditTableHS;
            this.mnuAlterarÍndice.Name = "mnuAlterarÍndice";
            this.mnuAlterarÍndice.Size = new System.Drawing.Size(197, 22);
            this.mnuAlterarÍndice.Text = "Alterar índice";
            this.mnuAlterarÍndice.Click += new System.EventHandler(this.alterarÍndiceToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(194, 6);
            // 
            // mnuInverterSeleçãoToolStripMenuItem
            // 
            this.mnuInverterSeleçãoToolStripMenuItem.Image = global::Apresentação.Resource.arrow_switch;
            this.mnuInverterSeleçãoToolStripMenuItem.Name = "mnuInverterSeleçãoToolStripMenuItem";
            this.mnuInverterSeleçãoToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.mnuInverterSeleçãoToolStripMenuItem.Text = "Inverter seleção";
            this.mnuInverterSeleçãoToolStripMenuItem.Click += new System.EventHandler(this.mnuInverterSeleçãoToolStripMenuItem_Click);
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
            this.panelÍndicePeça,
            this.panelÍndicePeso,
            this.panelÍndiceTotal,
            this.panelPreçoTotal});
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
            this.panelQuantidade.ToolTipText = "Quantidade de \'linhas\' da tabela. Não necessariamente a quantidade de referências" +
    ".";
            this.panelQuantidade.Width = 195;
            // 
            // panelTotalMercadorias
            // 
            this.panelTotalMercadorias.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelTotalMercadorias.Name = "panelTotalMercadorias";
            this.panelTotalMercadorias.ToolTipText = "Somatória das quantidades de todos os itens";
            this.panelTotalMercadorias.Width = 10;
            // 
            // panelPesoTotal
            // 
            this.panelPesoTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelPesoTotal.Icon = ((System.Drawing.Icon)(resources.GetObject("panelPesoTotal.Icon")));
            this.panelPesoTotal.MinWidth = 100;
            this.panelPesoTotal.Name = "panelPesoTotal";
            this.panelPesoTotal.ToolTipText = "Somatória do peso levando em conta as quantidades";
            // 
            // panelÍndicePeça
            // 
            this.panelÍndicePeça.Name = "panelÍndicePeça";
            this.panelÍndicePeça.Text = "Índice peça: 0";
            this.panelÍndicePeça.Width = 120;
            // 
            // panelÍndicePeso
            // 
            this.panelÍndicePeso.Name = "panelÍndicePeso";
            this.panelÍndicePeso.Text = "Índice peso:";
            this.panelÍndicePeso.Width = 120;
            // 
            // panelÍndiceTotal
            // 
            this.panelÍndiceTotal.Name = "panelÍndiceTotal";
            this.panelÍndiceTotal.Text = "índice: 0";
            this.panelÍndiceTotal.ToolTipText = "Somatória do índice";
            // 
            // panelPreçoTotal
            // 
            this.panelPreçoTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.panelPreçoTotal.Name = "panelPreçoTotal";
            this.panelPreçoTotal.Text = "Preço Total";
            this.panelPreçoTotal.Width = 72;
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
            this.btnAlterarÍndice});
            this.barraFerramentas.Location = new System.Drawing.Point(0, 0);
            this.barraFerramentas.Name = "barraFerramentas";
            this.barraFerramentas.Size = new System.Drawing.Size(717, 25);
            this.barraFerramentas.TabIndex = 6;
            this.barraFerramentas.Text = "Barra de ferramentas da bandeja";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::Apresentação.Resource.Excluir;
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
            this.cmbTabela.ToolTipText = "Tabela de preços a ser utilizada.";
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
            this.btnAgrupar.Image = global::Apresentação.Resource.Icone___Janela_explicativa___ConfirmaçãoAgrupamento;
            this.btnAgrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Size = new System.Drawing.Size(70, 22);
            this.btnAgrupar.Text = "Agrupar";
            this.btnAgrupar.Click += new System.EventHandler(this.btnAgrupar_Click);
            // 
            // btnSeparar
            // 
            this.btnSeparar.CheckOnClick = true;
            this.btnSeparar.Image = global::Apresentação.Resource.balança_pequena;
            this.btnSeparar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(138, 22);
            this.btnSeparar.Text = "Separar peça de peso";
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // btnAlterarÍndice
            // 
            this.btnAlterarÍndice.Image = global::Apresentação.Resource.EditTableHS;
            this.btnAlterarÍndice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterarÍndice.Name = "btnAlterarÍndice";
            this.btnAlterarÍndice.Size = new System.Drawing.Size(97, 22);
            this.btnAlterarÍndice.Text = "Alterar Índice";
            this.btnAlterarÍndice.Click += new System.EventHandler(this.btnAlterarÍndice_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.panelÍndicePeça)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelÍndicePeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelÍndiceTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPreçoTotal)).EndInit();
            this.barraFerramentas.ResumeLayout(false);
            this.barraFerramentas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion // Component Designer

        #region IEnumerable Members

        /// <summary>
        /// Obtém iterador de ISaquinhos
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
        protected System.Windows.Forms.ColumnHeader colReferência;
        protected System.Windows.Forms.ColumnHeader colQuantidade;
        protected System.Windows.Forms.ColumnHeader colPeso;
        protected System.Windows.Forms.ColumnHeader colÍndice;
        protected System.Windows.Forms.ColumnHeader colGrupo;
        protected System.Windows.Forms.ColumnHeader colFaixa;
        private System.Windows.Forms.StatusBarPanel panelQuantidade;
        private System.Windows.Forms.StatusBarPanel panelTotalMercadorias;
        private System.Windows.Forms.StatusBarPanel panelPesoTotal;
        private System.Windows.Forms.StatusBar status;
        private System.Windows.Forms.Timer timerStatus;
        private ColumnHeader colPreçoTot;
        private StatusBarPanel panelPreçoTotal;
        private ColumnHeader colPreçoUn;

        #endregion

        /// <summary>
        /// Obtém a linha da ListView para uma mercadoria específica.
        /// </summary>
        /// <param name="mercadoria">Mercadoria a ser procurada.</param>
        /// <returns>Linha da ListView que contém a Mercadoria.</returns>
        public ListViewItem ObterLinha(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            ISaquinho saquinho = null;

            if (!hashAgrupamento.TryGetValue(new Saquinho(mercadoria, 1).IdentificaçãoAgrupável(), out saquinho))
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
            SepararPeçaPeso = !SepararPeçaPeso;
        }

        private void cmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabela = cmbTabela.SelectedItem as Tabela;

            if (TabelaAlterada != null)
                TabelaAlterada(this, Tabela);
        }

        private void alterarÍndiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count == 1)
            {
                ISaquinho selecionado = hashListViewItemSaquinho[lista.SelectedItems[0]];
                if (AlteraçãoÍndiceSolicitada != null)
                    AlteraçãoÍndiceSolicitada(this, selecionado);
            }
        }

        private void btnAlterarÍndice_Click(object sender, EventArgs e)
        {
            alterarÍndiceToolStripMenuItem_Click(sender, e);
        }

        private void mnuInverterSeleçãoToolStripMenuItem_Click(object sender, EventArgs e)
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

            ÁreaDeTransferência.Instância.Copiar(listaCopia);
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

