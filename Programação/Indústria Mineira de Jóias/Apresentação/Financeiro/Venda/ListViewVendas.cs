using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Venda
{
    /// <summary>
    /// Lista de exibição de vendas.
    /// </summary>
    public partial class ListViewVendas : UserControl
    {
        public event EventHandler AoSalvarNfe;

        /// <summary>
        /// Código das vendas na lista
        /// </summary>
        private Dictionary<ListViewItem, IDadosVenda> hashListViewItemVenda = null;
        private Dictionary<long, ListViewItem> hashCódigoItem = null;

        /// <summary>
        /// Tipo de exibição de venda (para cliente ou de vendedor).
        /// Controla exibição gráfica (colunas)
        /// </summary>
        private VínculoVendaPessoa tipoExibição = VínculoVendaPessoa.Cliente;

        /// <summary>
        /// Determina se serão exibidas somente vendas não acertadas.
        /// </summary>
        private bool apenasNãoAcertadas = true;

        private bool handleCriado = false;

        #region Propriedades

        /// <summary>
        /// Determina se serão exibidas somente vendas não acertadas.
        /// </summary>
        [DefaultValue(true), Description("Determina se serão exibidas somente vendas não acertadas.")]
        public bool ApenasNãoAcertado
        {
            get { return apenasNãoAcertadas; }
            set
            {
                apenasNãoAcertadas = value;
                btnAcertado.Checked = !value;

                if (recarregar != null)
                    recarregar.DynamicInvoke(recarregarParâmetros);
            }
        }

        private Delegate recarregar;
        private object[] recarregarParâmetros;

        /// <summary>
        /// Tipo de exibição das vendas.
        /// Cliente = Vendas para um cliente.
        /// Vendedor = Vendas de um vendedor.
        /// </summary>
        [DefaultValue(VínculoVendaPessoa.Cliente),
        Description("Tipo de exibição da venda.")]
        public VínculoVendaPessoa TipoExibição
        {
            get { return tipoExibição; }
            set
            {
                SetarTipoExibição(value);
            }
        }

        private delegate void SetarTipoExibiçãoDelegate(VínculoVendaPessoa tipoExibição);

        private void SetarTipoExibição(VínculoVendaPessoa novoTipo)
        {
            if (lista.InvokeRequired)
            {
                SetarTipoExibiçãoDelegate método = new SetarTipoExibiçãoDelegate(SetarTipoExibição);
                lista.BeginInvoke(método, novoTipo);
            }
            else
            {

                this.tipoExibição = novoTipo;

                switch (novoTipo)
                {
                    case VínculoVendaPessoa.Cliente:

                        if (lista.Columns.Contains(colCliente))
                            lista.Columns.Remove(colCliente);

                        if (!lista.Columns.Contains(colVendedor))
                            lista.Columns.Insert(3, colVendedor);
                        //                        colCliente.Text = "Vendedor";
                        break;

                    case VínculoVendaPessoa.Vendedor:

                        if (lista.Columns.Contains(colVendedor))
                            lista.Columns.Remove(colVendedor);

                        if (!lista.Columns.Contains(colCliente))
                            lista.Columns.Insert(3, colCliente);

                        //                        colCliente.Text = "Cliente";
                        break;
                    case VínculoVendaPessoa.Indefinido:
                        if (!lista.Columns.Contains(colCliente))
                            lista.Columns.Insert(3, colCliente);

                        if (!lista.Columns.Contains(colVendedor))
                            lista.Columns.Insert(3, colVendedor);
                        break;
                    default:

                        throw new NotSupportedException("Tipo de exibição não suportado.");
                }
            }
        }

        /// <summary>
        /// Código da venda selecionada.
        /// </summary>
        public long? ItemSelecionado
        {
            get
            {
                IDadosVenda venda;

                if (lista.SelectedIndices.Count != 1)
                    return null;

                if (hashListViewItemVenda.TryGetValue(lista.SelectedItems[0], out venda))
                    return venda.Código;
                else
                    return null;
            } set
            {
                lista.SelectedItems.Clear();

                if (value.HasValue)
                {
                    ListViewItem item;

                    if (hashCódigoItem.TryGetValue(value.Value, out item))
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                    }
                }
            }
        }

        /// <summary>
        /// Código da venda selecionada.
        /// </summary>
        public List<IDadosVenda> ItensSelecionados
        {
            get
            {
                List<IDadosVenda> vendasSelecionadas = new List<IDadosVenda>();
                IDadosVenda v;

                foreach (ListViewItem itemSelecionado in lista.SelectedItems)
                {
                    if (hashListViewItemVenda.TryGetValue(itemSelecionado, out v))
                    {
                        vendasSelecionadas.Add(v);
                    }
                }

                return vendasSelecionadas;
            } set
            {
                lista.SuspendLayout();

                foreach (ListViewItem i in lista.Items)
                    i.Selected = false;

                foreach (IDadosVenda v in value)
                {
                    ListViewItem item;

                    if (hashCódigoItem.TryGetValue(v.Código, out item))
                        item.Selected = true;
                }

                lista.ResumeLayout();
            }
        }

        public Dictionary<ListViewItem,IDadosVenda>.ValueCollection Itens
        {
            get { return hashListViewItemVenda.Values; }
        }

        #endregion

        public delegate void DelegaçãoVenda(long? códigoVenda);

        public event DelegaçãoVenda AoSelecionar;
        public event DelegaçãoVenda AoDuploClique;

        // Janela de aguarde

        public ListViewVendas()
        {
            InitializeComponent();

            hashListViewItemVenda = new Dictionary<ListViewItem, IDadosVenda>();
            hashCódigoItem = new Dictionary<long, ListViewItem>();
            lista.ListViewItemSorter = new ListViewVendasOrdenador(hashListViewItemVenda);

            /* Por algum motivo obscuro, o VS não atribui
             * a propriedade "Name" para as colunas.
             */
            colData.Name = "colData";
            colCódigo.Name = "colCódigo";
            colControle.Name = "colControle";
            colCliente.Name = "colCliente";
            colVendedor.Name = "colVendedor";
            colValor.Name = "colValor";

            this.HandleCreated += new EventHandler(ListViewVendas_HandleCreated);
            ((ListViewVendasOrdenador)lista.ListViewItemSorter).DefinirColuna(colData);
            lista.Sorting = SortOrder.Descending;
            lista.Sort();

            btnGerarNfe.Visible = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.Técnico);
        }

        void ListViewVendas_HandleCreated(object sender, EventArgs e)
        {
            handleCriado = true;
            ((ListViewVendasOrdenador) lista.ListViewItemSorter).Lista = lista;
            AtualizarStatus();
        }

        /// <summary>
        /// Ocorre ao mudar as dimensões da lista.
        /// </summary>
        private void lista_Resize(object sender, EventArgs e)
        {
            AtualizarTamanhoColunas();
        }

        private void AtualizarTamanhoColunas()
        {
            colValor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colCódigo.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            colControle.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (lista.Columns.Contains(colCliente) && lista.Columns.Contains(colVendedor))
            {
                // As duas colunas estão presentes
                colCliente.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                colVendedor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
            {
                // Apenas uma coluna para pessoa
                ColumnHeader únicaColunaAtiva =
                    lista.Columns.Contains(colCliente) ? colCliente : colVendedor;

                únicaColunaAtiva.Width = lista.ClientSize.Width - colData.Width -
                    colCódigo.Width - colControle.Width - colValor.Width;

                //únicaColunaAtiva.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private delegate void AbrirVendasCallBack(Entidades.Relacionamento.Venda.VendaSintetizada[] vendas);
        /// <summary>
        /// Abre vendas sintetizadas para exibição.
        /// </summary>
        /// <remarks>
        /// ATENÇÃO: O valor da propriedade SomenteNãoAcertadas é ignorado.
        /// </remarks>
        public void Carregar(IDadosVenda[] vendas)
        {
            SuspendLayout();
            lista.SuspendLayout();
            Visible = false;

            lista.Items.Clear();
            hashCódigoItem.Clear();
            hashListViewItemVenda.Clear();

            if (vendas == null)
                return;
            
            double somatorioValor = AdicionarVendas(vendas);


            InformaçõesStatus.Instância.QtdVendas = lista.Items.Count;
            InformaçõesStatus.Instância.ValorTotal = somatorioValor;

            AtualizarStatus();
            AtualizarTamanhoColunas();
            lista.Sort();
            lista.ResumeLayout();

            Visible = true;
            ResumeLayout();
        }

        private double AdicionarVendas(IDadosVenda[] vendas)
        {
            ListViewItem[] novosItens = new ListViewItem[vendas.Length];
            int x = 0;
            double valorTotalGlobal = 0;

            foreach (IDadosVenda venda in vendas)
            {
                double valorTotal;
                ListViewItem item = CriarItem(venda, out valorTotal);

                hashListViewItemVenda.Add(item, venda);
                hashCódigoItem.Add(venda.Código, item);

                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    localizador.InserirFraseBuscável(subitem.Text, item);

                novosItens[x++] = item;
                valorTotalGlobal += valorTotal;
            }

            lista.Items.AddRange(novosItens);

            return valorTotalGlobal;
        }

        private ListViewItem CriarItem(IDadosVenda venda, out double valorTotal)
        {
            ListViewItem item = new ListViewItem(venda.Data.ToString("dd/MM/yyyy", Entidades.Configuração.DadosGlobais.Instância.Cultura));
            item.ImageIndex = (int) venda.Semáforo;

            item.SubItems.AddRange(new string[] { "", "", "", "", "", "", "", "" });
            item.SubItems[colCódigo.Index].Text = venda.Código.ToString();
            item.SubItems[colControle.Index].Text = venda.Controle.HasValue ? venda.Controle.ToString() : "";

            if (lista.Columns.Contains(colVendedor) && (venda.NomeVendedor != null))
                item.SubItems[colVendedor.Index].Text = venda.NomeVendedor;

            if (lista.Columns.Contains(colCliente) && (venda.NomeCliente != null))
                item.SubItems[colCliente.Index].Text = venda.NomeCliente;

            valorTotal = venda.Valor;

            item.SubItems[colValor.Index].Text = valorTotal.ToString("C", Entidades.Configuração.DadosGlobais.Instância.Cultura);
            item.UseItemStyleForSubItems = true;

            return item;
        }

        private void AtualizarStatus()
        {
            if (handleCriado)
            {
                System.Globalization.CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;
                painelQuantidade.Text = InformaçõesStatus.Instância.QtdVendas.ToString() + " venda(s)";
                painelValor.Text = InformaçõesStatus.Instância.ValorTotal.ToString("c", cultura);
            }
        }

        /// <summary>
        /// É aberto as vendas da pessoa OU as compras da pessoa,
        /// determinado automaticamente dependendo se ela é cliente ou não.
        /// </summary>
        public void Carregar(Entidades.Pessoa.Pessoa pessoa, bool forçarTrataloCliente)
        {
            if (forçarTrataloCliente)
            {
                Carregar(false, pessoa);
                return;
            }

            bool éFuncionário = Entidades.Pessoa.Funcionário.ÉFuncionário(pessoa);
            bool éRepresentate = Entidades.Pessoa.Representante.ÉRepresentante(pessoa);

            if (éFuncionário || éRepresentate)
            {
                // Quero as vendas deste vendedor/representante
                Carregar(true, pessoa);
            }
            else
            {
                // Quero as compras deste cliente                
                Carregar(false, pessoa);
            }
        }

        private delegate void CarregarCompleto(bool éVendedor, Entidades.Pessoa.Pessoa Pessoa);

        /// <summary>
        /// Caso pessoaÉVendedor, são carregadas todas as vendas em que pessoa é vendedor.
        /// Caso contrário, são carregadas todas as vendas em que pessoa é cliente.
        /// </summary>
        public void Carregar(bool pessoaÉVendedor, Entidades.Pessoa.Pessoa pessoa)
        {
            DateTime início, fim;

            recarregar = new CarregarCompleto(Carregar);
            recarregarParâmetros = new object[] { pessoaÉVendedor, pessoa };

            Entidades.Relacionamento.Venda.VendaSintetizada[] vendasCarregadas = null;

            if (pessoaÉVendedor)
                TipoExibição = VínculoVendaPessoa.Vendedor;
            else
                TipoExibição = VínculoVendaPessoa.Cliente;

            início = DateTime.MinValue;
            fim = DateTime.MaxValue;

            vendasCarregadas = Entidades.Relacionamento.Venda.VendaSintetizada.ObterVendas(pessoaÉVendedor, pessoa, início, fim, apenasNãoAcertadas, null);

            Carregar(vendasCarregadas);
        }

        private delegate void CarregarSimples(bool? sedex);

        /// <summary>
        /// Abre todas as vendas, de todas as pessoas.
        /// </summary>
        public void Carregar(bool? sedex)
        {
            recarregar = new CarregarSimples(Carregar);
            recarregarParâmetros = new object[1] { sedex };

            // Antes de tudo: atualiza a comissao
            // Entidades.Relacionamento.Venda.Venda.CalcularComissão();

            Entidades.Relacionamento.Venda.VendaSintetizada[] vendasCarregadas = null;

            TipoExibição = VínculoVendaPessoa.Indefinido;

            vendasCarregadas = Entidades.Relacionamento.Venda.VendaSintetizada.ObterVendas(DateTime.MinValue, DateTime.MaxValue, apenasNãoAcertadas, sedex);

            Carregar(vendasCarregadas);

        }

        public List<IDadosVenda> ObterVendasSelecionadas()
        {
            List<IDadosVenda> listaMarcadas = new List<IDadosVenda>(lista.SelectedItems.Count);

            foreach (ListViewItem item in lista.SelectedItems)
                listaMarcadas.Add(hashListViewItemVenda[item]);

            return listaMarcadas;
        }

        public List<long> ObterCódigosSelecionados()
        {
            List<long> listaMarcadas = new List<long>(lista.SelectedItems.Count);

            foreach (ListViewItem item in lista.SelectedItems)
                listaMarcadas.Add(hashListViewItemVenda[item].Código);

            return listaMarcadas;
        }

        public void Selecionar(List<IDadosVenda> vendas)
        {
            // Descheca os já marcados
            foreach (ListViewItem item in lista.Items)
                item.Selected = false;

            // Checas os solicitados
            foreach (IDadosVenda v in vendas)
            {
                ListViewItem item = null;

                if (!hashCódigoItem.TryGetValue(v.Código, out item))
                    throw new Exception("i) Erro ao selecionar uma venda: código " + v.Código.ToString() + " não estava na hash");

                item.Selected = true;
            }
        }

        public void Selecionar(List<long> vendas)
        {
            // Descheca os já marcados
            foreach (ListViewItem item in lista.Items)
                item.Selected = false;

            // Marca os solicitados
            foreach (long códigoVenda in vendas)
            {
                ListViewItem item = null;

                if (hashCódigoItem.TryGetValue(códigoVenda, out item))
                {
                    item.Selected = true;
                }
            }
        }

        /// <summary>
        /// Ocorre ao selecionar algum item da lista.
        /// </summary>
        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AoSelecionar != null)
                AoSelecionar(ItemSelecionado);
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (AoDuploClique != null)
                AoDuploClique(ItemSelecionado);
        }

        /// <summary>
        /// Altera ordenação da lista, quando o usuário
        /// clica na coluna.
        /// </summary>
        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListViewVendasOrdenador)lista.ListViewItemSorter).DefinirColuna(lista.Columns[e.Column]))
                lista.Sorting = SortOrder.Ascending;
            else
                lista.Sorting = lista.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                
            lista.Sort();
        }

        private void lista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                lista_DoubleClick(sender, e);

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
                localizador.Abrir();

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                MarcarTudo();
        }

        private void localizador_DesrealçarTudo(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lista.Items)
                item.BackColor = Color.White;
        }

        private void localizador_RealçarItens(System.Collections.ArrayList itens)
        {
            foreach (ListViewItem item in itens)
                item.BackColor = Color.LightGreen;
        }

        private void localizador_EncontrarItem(object item, object itemAnterior)
        {
            ListViewItem i = (ListViewItem) item;
            ListViewItem iAnterior = item as ListViewItem;

            if (iAnterior != null)
                iAnterior.Selected = false;
            
            i.Selected = true;
            i.EnsureVisible();
        }

        private void btnSelecionarTudo_Click(object sender, EventArgs e)
        {
            if (lista.Items.Count > 0)
            {
                foreach (ListViewItem item in lista.Items)
                    item.Selected = true;
            }
        }

        private void btnSelecionarNada_Click(object sender, EventArgs e)
        {
            if (lista.SelectedIndices.Count > 0)
            {
                ListViewItem primeiroItemMarcado = lista.SelectedItems[0];

                foreach (ListViewItem item in lista.SelectedItems)
                    item.Selected = false;
            }
        }

        public void MarcarTudo()
        {
            foreach (ListViewItem item in lista.Items)
                item.Selected = true;
        }

        private void btnAcertado_CheckedChanged(object sender, EventArgs e)
        {
            if (ApenasNãoAcertado != !btnAcertado.Checked)
                ApenasNãoAcertado = !btnAcertado.Checked;
        }

        private void ListViewVendas_Paint(object sender, PaintEventArgs e)
        {
            lista.Focus();
        }

        private void btnGerarNfe_Click(object sender, EventArgs e)
        {
            if (ItemSelecionado.HasValue)
            {
                Apresentação.Financeiro.Fiscal.JanelaNFe janela = new Fiscal.JanelaNFe();
                janela.AoSalvarNfe += janela_AoSalvarNfe;
                janela.CarregarVenda(ItemSelecionado.Value);
                janela.ShowDialog(this);
            }
        }

        void janela_AoSalvarNfe(object sender, EventArgs e)
        {
            if (AoSalvarNfe != null)
                AoSalvarNfe(sender, e);
        }
    }

    public class InformaçõesStatus
    {
        private int qtdVendas;
        //private double comissão;
        private double valorTotal;

        private static InformaçõesStatus instância;

        public int QtdVendas
        {
            get { return qtdVendas; }
            set { qtdVendas = value; }
        }

        public double ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }

        public InformaçõesStatus(int qtdVendas, double valorTotal)
        {
            this.qtdVendas = qtdVendas;
            this.valorTotal = valorTotal;
        }

        public static InformaçõesStatus Instância
        {
            get
            {
                if (instância == null)
                    instância = new InformaçõesStatus(0, 0);

                return instância;
            }
        }
    }
}
