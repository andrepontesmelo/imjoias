using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Apresentação.Formulários;
using Entidades.Acerto;

namespace Apresentação.Financeiro
{
    public partial class ListaConsignado : UserControl
    {
        // Atributos
        protected Entidades.Pessoa.Pessoa pessoa;	// pode ser o cliente
        private ArrayList listaRelacionamentos; // Não pode ser List<>
        private bool evitarEventoChecked = false;
        private bool apenasNãoAcertados = true;

        // Encontra um Item de list view pelo objeto de contexto e vice-versa
        private Dictionary<ListViewItem, Entidades.Relacionamento.RelacionamentoAcerto> hashListViewItemConsignado;   // Chave: item da list view
        private Dictionary<long, ListViewItem> hashConsignadoListViewItem;   // Chave: Relacionamento (objeto de contexto)
        private Dictionary<AcertoConsignado, ListViewGroup> hashGrupo;

        // Eventos
        public event EventHandler AoMarcar;
        public EventHandler SelectedIndexChanged;
        public new KeyEventHandler KeyDown;
        public new EventHandler DoubleClick;

        private ListViewColumnSorter ordenador;

        public ListaConsignado()
        {
            InitializeComponent();

            hashListViewItemConsignado = new Dictionary<ListViewItem, Entidades.Relacionamento.RelacionamentoAcerto>();
            hashConsignadoListViewItem = new Dictionary<long, ListViewItem>();
            hashGrupo = new Dictionary<AcertoConsignado, ListViewGroup>();

            ordenador = new ListViewColumnSorter();
            lista.ListViewItemSorter = ordenador;

            // Resolve BUG do Visual Studio
            colCódigo.Name = "colCódigo";
            colAcerto.Name = "colAcerto";
            colData.Name = "colData";
            colFuncionário.Name = "colFuncionário";
            colPessoa.Name = "colPessoa";
            colStatus.Name = "colStatus";
            colObservações.Name = "colObservações";

            // Agrupamento só é possível a partir do Windows XP.
            btnAgrupar.Visible = System.Environment.OSVersion.Version.Major >= 5;
        }

        public ListView.SelectedListViewItemCollection SelectedItems
        {
            get { return lista.SelectedItems; }
        }

        /// <summary>
        /// Carrega todos os documentos de uma pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        public void Carregar(Entidades.Pessoa.Pessoa pessoa)
        {
            Carregar(pessoa, DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// Carrega todos os documentos de qualquer pessoa em qualquer data.
        /// </summary>
        public void Carregar()
        {
            Carregar(null, DateTime.MinValue, DateTime.MaxValue);
        }

        public Entidades.Relacionamento.RelacionamentoAcerto ItemSelecionado
        {
            get
            {
                if (lista.SelectedItems.Count == 0)
                    throw new Exception("Nenhum item selecionado");

                return hashListViewItemConsignado[lista.SelectedItems[0]];
            }
        }

        public ArrayList Itens
        {
            get { return (ArrayList)listaRelacionamentos.Clone(); }
        }

        [DefaultValue(true)]
        public bool UsarCheckBox
        {
            get { return lista.CheckBoxes; }
            set { lista.CheckBoxes = value; }
        }

        [DefaultValue(true)]
        [Description("Exibe apenas documentos não acertados.")]
        public bool ApenasNãoAcertados
        {
            get { return apenasNãoAcertados; }
            set
            {
                apenasNãoAcertados = value;
            }
        }

        /// <summary>
        /// Obtém do servidor os relacionamentos de uma pessoa,
        /// registra no sponsor
        /// </summary>
        /// <param name="pessoa">Pessoa.</param>
        public virtual void Carregar(Entidades.Pessoa.Pessoa pessoa, DateTime início, DateTime fim)
        {
            AguardeDB.Mostrar();
            evitarEventoChecked = true;

            try
            {
                lock (this)
                {
                    if (this.pessoa != null)
                        Limpar();

                    this.pessoa = pessoa;

                    listaRelacionamentos = ObterRelacionamentos(pessoa, início, fim, apenasNãoAcertados);
                }

                foreach (Entidades.Relacionamento.RelacionamentoAcerto relacionamento in listaRelacionamentos)
                    AdicionarItem(relacionamento);

                // Simula resize para atualizar tamanho das colunas
                OnResize(EventArgs.Empty);
            }
            finally
            {
                AguardeDB.Fechar();
                evitarEventoChecked = false;
            }
        }

        protected virtual ArrayList ObterRelacionamentos(Entidades.Pessoa.Pessoa pessoa, DateTime início, DateTime fim, bool apenasNãoAcertados)
        {
            throw new Exception("Método abstrato");
        }

        /// <summary>
        /// Adiciona um item ao ListView.
        /// </summary>
        /// <param name="relacionamento">Saída ou retorno a ser adicionado.</param>
        protected virtual ListViewItem AdicionarItem(Entidades.Relacionamento.RelacionamentoAcerto relacionamento)
        {
            ListViewItem item;
            
            item = new ListViewItem(new string[lista.Columns.Count]);

            // Vincula nas tabelas-hash
            hashConsignadoListViewItem.Add(relacionamento.Código, item);
            hashListViewItemConsignado.Add(item, relacionamento);

            // Prepara o item da list-view
            item.Text = relacionamento.Código.ToString();
            PrepararListViewItem(item, relacionamento);

            item.Group = ObterGrupo(relacionamento);

            // Adiciona na listview 
            lista.Items.Add(item);
            localizador.InserirListViewItem(item);
            return item;
        }

        private ListViewGroup ObterGrupo(Entidades.Relacionamento.RelacionamentoAcerto relacionamento)
        {
            ListViewGroup grupo;

            if (relacionamento.AcertoConsignado == null)
                return null;

            if (!hashGrupo.TryGetValue(relacionamento.AcertoConsignado, out grupo))
            {
                if (relacionamento.AcertoConsignado.DataEfetiva.HasValue)
                    grupo = new ListViewGroup("Acertado em " + relacionamento.AcertoConsignado.DataEfetiva.Value.ToLongDateString());

                else if (relacionamento.AcertoConsignado.Previsão.HasValue)
                    grupo = new ListViewGroup("Acerto com previsão para " + relacionamento.AcertoConsignado.Previsão.Value.ToLongDateString());

                else
                    grupo = new ListViewGroup(string.Format("Acerto {0} sem previsão", relacionamento.AcertoConsignado.Código));

                lista.Groups.Add(grupo);

                hashGrupo[relacionamento.AcertoConsignado] = grupo;
            }

            return grupo;
        }

        /// <summary>
        /// Desassocia o item das hashs e retira do controle.
        /// </summary>
        protected virtual void RemoverItem(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (!hashConsignadoListViewItem.ContainsKey(relacionamento.Código))
                throw new Exception("Não foi possível encontrar list-view-item relacionado com entidade relacionamento na hash");

            ListViewItem item = hashConsignadoListViewItem[relacionamento.Código];

            // Remove das tabelas-hash
            hashConsignadoListViewItem.Remove(relacionamento.Código);
            hashListViewItemConsignado.Remove(item);

            // Retira o item da listview
            lista.Items.Remove(item);
        }

        /// <summary>
        /// Prepara os parâmetros específicos de um relacionamento em um item
        /// </summary>
        /// <example>
        /// item.SubItems[colFuncionário.Index].Text 
        /// </example>
        protected virtual void PrepararListViewItem(ListViewItem item, Entidades.Relacionamento.RelacionamentoAcerto relacionamento)
        {
            if (relacionamento.AcertoConsignado != null)
                item.SubItems[colAcerto.Index].Text = relacionamento.AcertoConsignado.Código.ToString();

            item.SubItems[colFuncionário.Index].Text = relacionamento.DigitadoPor.Nome;
            item.SubItems[colStatus.Index].Text = relacionamento.TravadoEmCache ? "Travado" : "Destravado";
            item.SubItems[colData.Index].Text = relacionamento.Data.ToString();
            item.SubItems[colPessoa.Index].Text = relacionamento.Pessoa.Nome;

            if (relacionamento.Observações != null)
            {
                item.SubItems[colObservações.Index].Text =
                    relacionamento.Observações.Length < 60 ? relacionamento.Observações :
                    relacionamento.Observações.Substring(0, 59) + "...";

                item.ToolTipText = relacionamento.Observações;
            }

            //if (relacionamento.Acertado)
            //{
            //    item.ForeColor = Color.Gray;
            //    item.UseItemStyleForSubItems = true;
            //}
        }

        ///// <summary>
        ///// Gera uma janela de aguarde personalizada.
        ///// Chamada pelo CarregarRelacionamentos()
        ///// </summary>
        ///// <returns></returns>
        //protected virtual Aguarde FazerAguardeCarregar(ArrayList lst)
        //{
        //    return new Aguarde("Preenchendo lista", lst.Count, "Abrindo lista de relacionamentos", "Esta mensagem deverá ocorrer apenas em fases de desenvolvimento, enquanto os controles listview mais específicos não tivem sido implementados");
        //}

        /// <summary>
        /// Limpa o conteúdo da ListView.
        /// </summary>
        private void Limpar()
        {
            lock (this)
            {
                this.pessoa = null;

                localizador.Limpar();
                lista.Items.Clear();

                if (listaRelacionamentos != null)
                    listaRelacionamentos.Clear();

                if (hashConsignadoListViewItem != null)
                    hashListViewItemConsignado.Clear();

                if (hashConsignadoListViewItem != null)
                    hashConsignadoListViewItem.Clear();
            }
        }

        public void MarcarTudo()
        {
            foreach (ListViewItem item in lista.Items)
                item.Checked = true;
        }

        public void Marcar(List<long> códigos)
        {
            foreach (long código in códigos)
            {
                if (hashConsignadoListViewItem.ContainsKey(código))
                {
                    hashConsignadoListViewItem[código].Checked = true;
                }
            }
        }

        public List<Entidades.Relacionamento.Relacionamento> ObterDocumentosMarcados()
        {
            if (lista.CheckedItems.Count > 0)
            {
                List<Entidades.Relacionamento.Relacionamento> listaMarcadas = new List<Entidades.Relacionamento.Relacionamento>(lista.CheckedItems.Count);

                foreach (ListViewItem item in lista.CheckedItems)
                    listaMarcadas.Add(hashListViewItemConsignado[item]);

                return listaMarcadas;
            }
            else
            {
                /* Se não houver nenhuma marca, pega a seleção.
                 */
                List<Entidades.Relacionamento.Relacionamento> listaSeleção = new List<Entidades.Relacionamento.Relacionamento>(lista.SelectedItems.Count);

                foreach (ListViewItem item in lista.SelectedItems)
                    listaSeleção.Add(hashListViewItemConsignado[item]);

                return listaSeleção;
            }
        }

        public List<long> ObterCódigosMarcados()
        {
            List<long> listaMarcadas = new List<long>(lista.CheckedItems.Count);

            foreach (ListViewItem item in lista.CheckedItems)
                listaMarcadas.Add(hashListViewItemConsignado[item].Código);

            return listaMarcadas;
        }

        /// <summary>
        /// Ocorre ao redimensionar o ListView.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (lista.Items.Count != 0)
            {
                colCódigo.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                colAcerto.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                colFuncionário.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                colStatus.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                colData.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                colPessoa.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        /// <summary>
        /// Ocorre ao travar um documento de consignado.
        /// </summary>
        /// <param name="pedido">Pedido fechado.</param>
        internal void AoMudarTrava(Entidades.Relacionamento.RelacionamentoAcerto consignado)
        {
            foreach (ListViewItem item in lista.Items)
                if (item.Text == consignado.Código.ToString())
                {
                    item.SubItems[colStatus.Index].Text = consignado.Travado ? "Impresso" : "Destravado";
                    break;
                }
        }


        private void lista_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
                if (!evitarEventoChecked && AoMarcar != null)
                AoMarcar(sender, e);
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
        }

        private void lista_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyDown != null)
                KeyDown(sender, e);
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClick != null)
                DoubleClick(sender, e);
        }

        private void btnSelecionarTudo_Click(object sender, EventArgs e)
        {
            if (lista.Items.Count > 0)
            {
                evitarEventoChecked = true;

                foreach (ListViewItem item in lista.Items)
                    item.Checked = true;

                evitarEventoChecked = false;

                // Chama o evento pelo menos uma vez:
                lista_ItemChecked(this, new ItemCheckedEventArgs(lista.Items[0]));
            }
        }

        private void btnDesselecionar_Click(object sender, EventArgs e)
        {
            if (lista.CheckedIndices.Count > 0)
            {
                ListViewItem primeiroItemMarcado = lista.CheckedItems[0];

                evitarEventoChecked = true;

                foreach (ListViewItem item in lista.CheckedItems)
                    item.Checked = false;

                evitarEventoChecked = false;

                // Chama o evento pelo menos uma vez:
                lista_ItemChecked(this, new ItemCheckedEventArgs(primeiroItemMarcado));
            }

        }

        private void localizador_DesrealçarTudo(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lista.Items)
                i.BackColor = Color.White;
        }

        private void localizador_EncontrarItem(object item, object itemAnterior)
        {
            ListViewItem i = (ListViewItem) item;
            ListViewItem iAnterior = itemAnterior as ListViewItem;

            if (iAnterior != null)
                iAnterior.Selected = false;

            i.Selected = true;
            i.EnsureVisible();
        }

        private void localizador_RealçarItens(ArrayList itens)
        {
            foreach (ListViewItem i in itens)
            {
                i.UseItemStyleForSubItems = true;
                i.BackColor = Color.LightGreen;
            }
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenador.OnClick(lista, e);
        }

        private void btnAgrupar_CheckedChanged(object sender, EventArgs e)
        {
            lista.ShowGroups = btnAgrupar.Checked;
        }
    }
}
