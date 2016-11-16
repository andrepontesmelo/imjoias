using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Venda
{
    public partial class ListaDébitos : UserControl
    {
        private Entidades.Relacionamento.Venda.Venda venda;
        private BaseEditarVenda baseEditarVenda = null;

        private ListViewColumnSorter ordenador;

        public ListaDébitos()
        {
            InitializeComponent();
            ordenador = new ListViewColumnSorter();
            lista.ListViewItemSorter = ordenador;
        }

        public void InformarBaseEditarVenda(BaseEditarVenda controle)
        {
            if (baseEditarVenda != null)
                return;

            baseEditarVenda = controle;
            baseEditarVenda.TravaAlterada += new BaseEditarRelacionamento.TravaAlteradaHandler(baseEditarVenda_TravaAlterada);

        }

        void baseEditarVenda_TravaAlterada(BaseEditarRelacionamento sender, Entidades.Relacionamento.Relacionamento e, bool vendaTravada)
        {
            AtualizarEnables(vendaTravada);
        }
        

        public void Abrir(Entidades.Relacionamento.Venda.Venda venda)
        {
            this.venda = venda;

            venda.ItensDébito.AoAdicionar += new Acesso.Comum.DbComposição<VendaDébito>.EventoComposição(ItensDébito_AoAdicionar);
            venda.ItensDébito.AoRemover += new Acesso.Comum.DbComposição<VendaDébito>.EventoComposição(ItensDébito_AoRemover);

            Carregar();
        }

        private void Carregar()
        {
            if (!bgCarregar.IsBusy)
            {
                lista.Items.Clear();

                SinalizaçãoCarga.Sinalizar(lista, "Carregando dados...", "Aguarde enquanto os débitos são carregados.");

                bgCarregar.RunWorkerAsync();
            }
        }

        void ItensDébito_AoRemover(Acesso.Comum.DbComposição<VendaDébito> composição, VendaDébito entidade)
        {
            foreach (ListViewItem item in lista.Items)
                if (entidade.Equals(item.Tag))
                {
                    lista.Items.Remove(item);

                    return;
                }

            Carregar();
        }

        void ItensDébito_AoAdicionar(Acesso.Comum.DbComposição<VendaDébito> composição, VendaDébito entidade)
        {
            if (entidade.Venda == venda)
                Adicionar(entidade);

            CalcularSumário();
        }

        /// <summary>
        /// Quem chama adicionar deve depois chamar CalcularSumário()
        /// </summary>
        /// <param name="débito"></param>
        private void Adicionar(VendaDébito débito)
        {
            ListViewItem item = new ListViewItem();

            System.Globalization.CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

            item.Text = débito.Data.ToString("dd/MM/yyyy");
            item.SubItems.Add(débito.Descrição);
            item.SubItems.Add(débito.DiasDeJuros.ToString());
            item.SubItems.Add(débito.ValorBruto.ToString("C", cultura));
            item.SubItems.Add(débito.ValorLíquido.ToString("C", cultura));

            item.Tag = débito;

            lista.Items.Add(item);
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarEnables(venda.Travado);
        }

        private void AtualizarEnables(bool vendaTravada)
        {
            if (vendaTravada)
            {
                btnAlterar.Enabled = btnExcluir.Enabled = false;
                btnAdicionar.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = lista.SelectedItems.Count == 1;
                btnExcluir.Enabled = lista.SelectedItems.Count >= 1;

                btnAdicionar.Enabled = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            AtualizarEnables(venda.Travado);

            if (!btnExcluir.Enabled)
                return;

            if (!venda.Travado)
            {
                if (lista.SelectedItems.Count == 0)
                    return;

                if (MessageBox.Show(this,
                    "Confirma exclusão de " + lista.SelectedItems.Count.ToString() +
                    " débito" + (lista.SelectedItems.Count == 1 ? "" : "s") + " ? ",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                List<ListViewItem> itens = new List<ListViewItem>();

                foreach (ListViewItem i in lista.SelectedItems)
                {
                    VendaDébito débito = (VendaDébito)i.Tag;
                    if (débito.Pagamento.HasValue)
                        Entidades.Pagamentos.PagamentoGenérico.MarcarPendência(débito.Pagamento.Value, true);

                    venda.ItensDébito.Remover(débito);
                    itens.Add(i);
                }

                foreach (ListViewItem i in itens)
                    lista.Items.Remove(i);
            }
            else
                MessageBox.Show(
                    ParentForm,
                    "Não é possível remover nenhum débito à venda travada.",
                    "Débitos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CalcularSumário();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!venda.Cadastrado)
            {
               MessageBox.Show(
               ParentForm,
               "Não é possível adicionar nenhum débito à venda não cadastrada.",
               "Débitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return;
            } else if (!venda.Travado)
                using (EditarDébito dlg = new EditarDébito(venda))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        venda.ItensDébito.Adicionar(dlg.Débito);
                }
            else
                MessageBox.Show(
                    ParentForm,
                    "Não é possível adicionar nenhum débito à venda travada.",
                    "Débitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AtualizarEnables(venda.Travado);

            if (!btnAlterar.Enabled)
                return;

            if (!venda.Travado)
            using (EditarDébito dlg = new EditarDébito((VendaDébito)lista.SelectedItems[0].Tag))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    dlg.Débito.Atualizar();
                    Carregar();
                }
            }
            else
                MessageBox.Show(
                    ParentForm,
                    "Não é possível editar nenhum débito à venda travada.",
                    "Débitos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CalcularSumário();
        }

        private void bgCarregar_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = venda.ItensDébito;
        }

        private void bgCarregar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (VendaDébito débito in (IEnumerable<VendaDébito>)e.Result)
                Adicionar(débito);

            CalcularSumário();
            SinalizaçãoCarga.Dessinalizar(lista);
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
                btnAlterar_Click(sender, e);
        }

        /// <summary>
        /// Refaz statusbar
        /// </summary>
        private void CalcularSumário()
        {
            double totalBruto = 0;
            double totalLíquido = 0;
            System.Globalization.CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

            foreach (ListViewItem item in lista.Items)
            {
                VendaDébito débito = (VendaDébito)item.Tag;
                totalBruto += débito.ValorBruto;
                totalLíquido += débito.ValorLíquido;
            }

            statusTxtQtd.Text = lista.Items.Count.ToString() + " " + (lista.Items.Count == 1 ? "Débito" : "Débitos");
            statusTxtBruto.Text = "Bruto: " + totalBruto.ToString("C", cultura);
            statusTxtLíquido.Text = "Líquido: " + totalLíquido.ToString("C", cultura);
        }

        internal void AdicionarCadastrando(Entidades.Pagamentos.Pagamento[] pagamentos)
        {
            List<KeyValuePair<Entidades.Pagamentos.Pagamento, VendaDébito>> lstPagamentoDébitos = new List<KeyValuePair<Entidades.Pagamentos.Pagamento, VendaDébito>>();

            foreach (Entidades.Pagamentos.Pagamento p in pagamentos)
            {
                VendaDébito débito = new VendaDébito(venda);

                débito.ValorBruto = p.Valor;
                débito.Descrição = p.DescriçãoCompleta;
                débito.Data = p.ÚltimoVencimento;
                débito.CobrarJuros = true;
                débito.DiasDeJuros = Entidades.Preço.CalcularDias(débito.Data, venda.Data);
                débito.CalcularValorLíquido();
                débito.Pagamento = p.Código;
                p.Devolvido = false;
                p.Pendente = false;

                lstPagamentoDébitos.Add(new KeyValuePair<Entidades.Pagamentos.Pagamento, VendaDébito>(p, débito));
            }

            venda.TransferirPagamentosParaDébitosEmTransação(lstPagamentoDébitos);

            Carregar();
        }

        internal void DataDaVendaFoiAtualizada(DateTime data)
        {
            foreach (VendaDébito entidade in venda.ItensDébito)
            {
                entidade.DiasDeJuros = Entidades.Preço.CalcularDias(entidade.Data, venda.Data);
                entidade.CalcularValorLíquido();
                entidade.Atualizar();
            }

            Carregar();
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenador.OnClick(lista, e);
        }

        private void lista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Excluir();

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                SelecionarTudo();
        }

        private void SelecionarTudo()
        {
            foreach (ListViewItem item in lista.Items)
                item.Selected = true;
        }
    }
}
