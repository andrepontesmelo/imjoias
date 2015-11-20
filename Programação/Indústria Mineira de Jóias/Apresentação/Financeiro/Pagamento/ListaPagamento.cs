using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Entidades.Pagamentos;
using Acesso.Comum;
using Apresentação.Formulários;
using System.Threading;
using Entidades.Relacionamento.Venda;
using Entidades;
using Entidades.Configuração;
using Apresentação.Impressão.Relatórios.PagamentosCliente;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class ListaPagamento : UserControl
    {
        private Dictionary<ListViewItem, ListaPagamentoItem> hashItemListaPagamento;

        /// <summary>
        /// Os pagamentos só são obtidos em relação a um cliente. 
        /// Caso seja nulo, o controle fica inabilitado (enabled=false).
        /// </summary>
        private Entidades.Pessoa.Pessoa cliente;

        /// <summary>
        /// Venda padrão. Pode ser nulo.
        /// Ao cadastrar novo pagamento, a venda padrão já vem vinculada por padrão.
        /// Caso != nulo, mostra apenas pagamentos vinculados a este.
        /// </summary>
        private Entidades.Relacionamento.Venda.IDadosVenda venda;

        private ListViewColumnSorter ordenador;

        [DefaultValue(false)]
        public bool SomenteLeitura
        {
            get { return !toolStrip.Enabled; }
            set { toolStrip.Enabled = !value; }
        }

        [ReadOnly(true), Browsable(false)]
        public Entidades.Relacionamento.Venda.IDadosVenda Venda
        {
            get { return venda; }
            set 
            {
                IDadosVenda anterior = this.venda;

                venda = value;

                if (value is Entidades.Relacionamento.Venda.Venda)
                    cliente = ((Entidades.Relacionamento.Venda.Venda)value).Cliente;

                // Mesmo que a venda seja a mesma, devemos carregar, pois o cliente pode ter sido alterado. 
                Carregar();
            }
        }

        [ReadOnly(true), Browsable(false)]
        public Entidades.Pessoa.Pessoa Cliente
        {
            get { return cliente; }
            set 
            {
                cliente = value;

                if (venda is Entidades.Relacionamento.Venda.Venda)
                {
                    if (value != ((Entidades.Relacionamento.Venda.Venda)venda).Cliente)
                        throw new ArgumentException("Cliente fornecido é diferente do cliente que está na venda.");
                }
                else if (venda != null && venda.NomeCliente != value.Nome)
                    throw new ArgumentException("Cliente fornecido possui nome diferente do cliente da venda.");

                Carregar();
            }
        }


        public ListaPagamento()
        {
            InitializeComponent();

            if (this.DesignMode) return;

            ordenador = new ListViewColumnSorter();

            hashItemListaPagamento = new Dictionary<ListViewItem, ListaPagamentoItem>();
            lista.ListViewItemSorter = ordenador;

            Image imagemDinheiro = (Image)global::Apresentação.Resource.dinheiro;
            imageList.Images.Add(Entidades.Pagamentos.Pagamento.TipoEnum.Dinheiro.ToString(), (Image) global::Apresentação.Resource.dinheiro);
            imageList.Images.Add(Entidades.Pagamentos.Pagamento.TipoEnum.Cheque.ToString(), (Image)global::Apresentação.Resource.cheque1);
            imageList.Images.Add(Entidades.Pagamentos.Pagamento.TipoEnum.NotaPromissória.ToString(), (Image)global::Apresentação.Resource.np);
            imageList.Images.Add(Entidades.Pagamentos.Pagamento.TipoEnum.Ouro.ToString(), (Image)global::Apresentação.Resource.botão___ouro);
            imageList.Images.Add(Entidades.Pagamentos.Pagamento.TipoEnum.Dolar.ToString(), (Image)global::Apresentação.Resource.pagar_em_dólares__pequeno_1);
            imageList.Images.Add(Entidades.Pagamentos.Pagamento.TipoEnum.Crédito.ToString(), (Image)global::Apresentação.Resource.credito);

            colContador.Name = "colContador";
            colData.Name = "colData";
            colValor.Name = "colValor";
            colDias.Name = "colDias";
            colValorLíquido.Name = "colValorHoje";
            colVencimento.Name = "colVencimento";
            colProrrogação.Name = "colProrrogação";
            colRegistradoPor.Name = "colRegistradoPor";
            colPagoNaVenda.Name = "colPagoNaVenda";
            colPagaVenda.Name = "colPagaVenda";
            colDescrição.Name = "colDescrição";

            ordenador.SortColumn = colData.Index;
            ordenador.OrderOfSort = SortOrder.Descending;
       }

        /// <summary>
        /// É o mesmo que atribuir as propriedades Venda e Cliente e chamar Carregar().
        /// No entanto apresenta melhor desempenho, desta forma a lista 
        /// seria carregada 2 vezes, e neste método apenas uma.
        /// </summary>
        /// <param name="venda"></param>
        /// <param name="cliente"></param>
        public void Carregar(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa cliente)
        {
            this.venda = venda;
            this.cliente = cliente;

            if (venda.NomeCliente != cliente.Nome)
                throw new ArgumentException("Nome do cliente na venda é diferente do nome do cliente fornecido.");

            Carregar();
        }

        private void adicionarNotaPromissóriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro c = new CadastroNotaPromissória();
            AbrirJanelaCadastro(c);

            while (c.DialogResult != DialogResult.Cancel)
            {
                c = new CadastroNotaPromissória();
                AbrirJanelaCadastro(c);
            }
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            Cadastro janela;
            Entidades.Pagamentos.Pagamento pagamento;

            if (lista.SelectedItems.Count != 0)
            {
                UseWaitCursor = true;

                pagamento = hashItemListaPagamento[lista.SelectedItems[0]].Pagamento;

                if (pagamento is Cheque)
                    janela = new CadastroCheque();
                else if (pagamento is Dinheiro)
                    janela = new CadastroDinheiro();
                else if (pagamento is NotaPromissória)
                    janela = new CadastroNotaPromissória();
                else if (pagamento is Ouro)
                    janela = new CadastroOuro();
                else if (pagamento is Dolar)
                    janela = new CadastroDolar();
                else
                    throw new NotSupportedException("Tipo de pagamento não suportado na lista de pagamento.");

                janela.PagamentoAlteradoOuRegistrado += new EventHandler(janela_PagamentoAlteradoOuRegistrado);
                janela.Disposed += new EventHandler(janela_Disposed);
                
                /* É necessário clonar o pagamento, de forma que se o usuário fizer alguma
                 * modificação e depois cancelar, não é pertubado nas entidades da lista. 
                 */
                janela.PrepararParaAlteração((Entidades.Pagamentos.Pagamento) pagamento.Clone());
                janela.ShowDialog(ParentForm);
                
                UseWaitCursor = false;
            }
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenador.OnClick(lista, e);
            
            //RefazerContagemLinhas();
        }

        private void RefazerContagemLinhas()
        {
            int linhaAtual = 0;
            foreach (ListViewItem linha in lista.Items)
            {
                linhaAtual++;
                linha.SubItems[colContador.Index].Text = linhaAtual.ToString();
            }
        }

        private void adicionarDinheiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro c = new CadastroDinheiro();
            AbrirJanelaCadastro(c);

            while (c.DialogResult != DialogResult.Cancel)
            {
                c = new CadastroDinheiro();
                AbrirJanelaCadastro(c);
            }
        }

        private void adicionarChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro c = new CadastroCheque();
            AbrirJanelaCadastro(c);

            while (c.DialogResult != DialogResult.Cancel)
            {
                c = new CadastroCheque();
                AbrirJanelaCadastro(c);
            }
        }

        private void adicionarOuroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro c = new CadastroOuro();
            AbrirJanelaCadastro(c);

            while (c.DialogResult != DialogResult.Cancel)
            {
                c = new CadastroOuro();
                AbrirJanelaCadastro(c);
            }
        }

        private void adicionarDolarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro c = new CadastroDolar();
            AbrirJanelaCadastro(c);

            while (c.DialogResult != DialogResult.Cancel)
            {
                c = new CadastroDolar();
                AbrirJanelaCadastro(c);
            }
        }


        private void AbrirJanelaCadastro(Cadastro janela)
        {
            if (venda != null && venda.Código == 0)
            {
                janela.DialogResult = DialogResult.Cancel;
                MessageBox.Show("Favor preencher mais dados da venda antes de inserir pagamento", "Venda ainda não cadastrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            janela.PagamentoAlteradoOuRegistrado += new EventHandler(janela_PagamentoAlteradoOuRegistrado);
            janela.Disposed += new EventHandler(janela_Disposed);
            janela.PrepararParaCadastro(venda, cliente);
            janela.ShowDialog(ParentForm);
        }

        void janela_Disposed(object sender, EventArgs e)
        {
            Cadastro janela = (Cadastro) sender;
            
            // Desregistra os eventos
            janela.Disposed -= new EventHandler(janela_Disposed);
            janela.PagamentoAlteradoOuRegistrado -= new EventHandler(janela_PagamentoAlteradoOuRegistrado);
        }

        /// <summary>
        /// É o método executado quando as janelas de cadastro disparam evento
        /// </summary>
        private void janela_PagamentoAlteradoOuRegistrado(object sender, EventArgs args)
        {
            Carregar();
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAlterar.Enabled =  btnExcluir.Enabled = lista.SelectedItems.Count > 0;
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
            foreach (ListViewItem item in itens)
            {
                item.UseItemStyleForSubItems = true;
                item.BackColor = Color.LightGreen;
            }
        }

        private void localizador_DesrealçarTudo(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lista.Items)
            {
                item.UseItemStyleForSubItems = true;
                item.BackColor = Color.White;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            List<ListaPagamentoItem> pagamentosRemover = new List<ListaPagamentoItem>();
            string msg;

            foreach (ListViewItem i in lista.SelectedItems)
                pagamentosRemover.Add(hashItemListaPagamento[i]);

            if (pagamentosRemover.Count == 0)
            {
                MessageBox.Show("Selecione o pagamento primeiro", "Nenhum pagamento selecionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (pagamentosRemover.Count == 1)
                msg = "Deseja remover " + pagamentosRemover[0].Pagamento.Tipo.ToString() + " de " + pagamentosRemover[0].Pagamento.Valor.ToString("C") + " ?";
            else
                msg = "Deseja remover estes " + pagamentosRemover.Count.ToString() + " pagamentos selecionados ?";

            if (MessageBox.Show(msg, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                // Remove os pagamentos!
                foreach (ListaPagamentoItem item in pagamentosRemover)
                    item.Pagamento.Descadastrar();
            }

            Carregar();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // Alterar é o mesmo que dar duplo clique no item
            lista_DoubleClick(sender, e);
        }

        private void lista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
                localizador.Abrir();
            
            if (e.KeyCode == Keys.Delete)
                Excluir();
        }

        private struct DadosBgCarregar
        {
            //public Dictionary<Entidades.Pagamentos.Pagamento, string> hashCódPagamentoVinculo;
            public Entidades.Pagamentos.Pagamento[] entidades;

            // Dado o código do pagamento, retorna o código da venda em que o pagamento foi pago.
            public Dictionary<long, long?> hashPagoNaVenda;
        }

        /// <summary>
        /// Pode ser chamado para recarregar.
        /// </summary>
        public void Carregar()
        {
            if (bgCarregar.IsBusy)
                return;

            AtualizarAcessibilidadeGráfica();
            LimparLista();
            ReadicionarStatusStrip();
            ReadicionarColunas();

            if (cliente == null && venda == null)
                return;

            SinalizaçãoCarga.Sinalizar(lista, "Carregando dados", "Aguarde enquanto a lista de pagamento é carregada...");

            bgCarregar.RunWorkerAsync();
        }

        private void ReadicionarColunas()
        {
            lista.Columns.Clear();
            lista.Columns.Add(colContador);
            lista.Columns.Add(colData);
            lista.Columns.Add(colDescrição);
            lista.Columns.Add(colVencimento);
            lista.Columns.Add(colValor);
            lista.Columns.Add(colProrrogação);

            if (venda != null)
            {
                lista.Columns.Add(colDias);
                lista.Columns.Add(colValorLíquido);
            }

            lista.Columns.Add(colRegistradoPor);
            lista.Columns.Add(colPagaVenda);
            lista.Columns.Add(colPagoNaVenda);

        }

        private void ReadicionarStatusStrip()
        {
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(qtdStatusStrip);
            statusStrip1.Items.Add(valorTotalStrip);

            if (venda != null)
                statusStrip1.Items.Add(valorTotalLíquidoStrip);
        }

        private void AtualizarAcessibilidadeGráfica()
        {
            lista.Enabled = cliente != null;
            toolStrip.Enabled = cliente != null;
        }

        private void LimparLista()
        {
            lista.Items.Clear();
            hashItemListaPagamento.Clear();
            localizador.Limpar();
        }


        private void bgCarregar_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DadosBgCarregar dados = new DadosBgCarregar();

                // Reobtem os dados
                if (venda != null)
                    dados.entidades = Entidades.Pagamentos.Pagamento.ObterPagamentos(venda);
                else
                    dados.entidades = Entidades.Pagamentos.Pagamento.ObterPagamentos(cliente);

                dados.hashPagoNaVenda = 
                    Entidades.Relacionamento.Venda.Venda.ObterCódigoVendasQuePagam(dados.entidades);

                e.Result = dados;
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
            }
        }

        protected virtual bool DevoAdicionar(Entidades.Pagamentos.Pagamento p)
        {
            return true;
        }

        private void bgCarregar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
                return;

            DadosBgCarregar dados = (DadosBgCarregar)e.Result;
            DateTime hoje = DadosGlobais.Instância.HoraDataAtual;
            double valorTotal = 0, valorTotalLíquido = 0;

            // Insere os itens
            foreach (Entidades.Pagamentos.Pagamento p in dados.entidades)
            {
                if (!DevoAdicionar(p))
                    continue;

                ListViewItem item = CriarItem(ref dados, hoje, ref valorTotal, ref valorTotalLíquido, p);
                lista.Items.Add(item);

                // Torna buscável
                localizador.InserirListViewItem(item);
            }

            // Deixa des-selecionado
            lista.SelectedItems.Clear();
            btnExcluir.Enabled = btnAlterar.Enabled = false;

            // Espicha a ultima coluna
            colPagoNaVenda.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            AtualizaStatusbar(valorTotal, valorTotalLíquido);

            RefazerContagemLinhas();

            colDescrição.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            SinalizaçãoCarga.Dessinalizar(lista);
        }

        private void AtualizaStatusbar(double valorTotal, double valorTotalLíquido)
        {
            qtdStatusStrip.Text = lista.Items.Count.ToString()
                + (lista.Items.Count == 1 ? " item" : " itens");

            valorTotalStrip.Text = valorTotal.ToString("C");
            valorTotalLíquidoStrip.Text = valorTotalLíquido.ToString("C") + " (líquido)";
        }

        private ListViewItem CriarItem(ref DadosBgCarregar dados, DateTime hoje, ref double valorTotal, ref double valorTotalLíquido, Entidades.Pagamentos.Pagamento p)
        {
            ListViewItem item = new ListViewItem(new string[11] { "", "", "", "", "", "", "", "", "", "", "" });
            ListaPagamentoItem itemPagamento = new ListaPagamentoItem(p);

            valorTotal += p.Valor;
            item.SubItems[colData.Index].Text = p.Data.ToShortDateString();
            item.SubItems[colRegistradoPor.Index].Text = p.RegistradoPor.Nome;
            item.SubItems[colValor.Index].Text = Math.Abs(p.Valor).ToString("C", DadosGlobais.Instância.Cultura);
            item.SubItems[colDescrição.Index].Text = p.DescriçãoCompleta;

            if (p is IProrrogável)
            {
                IProrrogável prorrogável = (IProrrogável)p;
                itemPagamento.ProrrogadoPara = prorrogável.ProrrogadoPara;

                if (prorrogável.ProrrogadoPara.HasValue)
                    item.SubItems[colProrrogação.Index].Text = prorrogável.ProrrogadoPara.Value.ToShortDateString();
                else
                    item.SubItems[colProrrogação.Index].Text = "";
            }
            else
                itemPagamento.ProrrogadoPara = null;

            if (p is Cheque)
                itemPagamento.Vencimento = ((Cheque) p).Vencimento;
            else

                itemPagamento.Vencimento =  p.ÚltimoVencimento;

            if (itemPagamento.Vencimento.HasValue)
            {
                item.SubItems[colVencimento.Index].Text =
                    itemPagamento.Vencimento.Value.ToString("dd/MM/yyyy");
            }

            if (venda != null)
            {
                itemPagamento.Dias = p.ObterDiasJuros(venda);
                item.SubItems[colDias.Index].Text = itemPagamento.Dias.ToString();

                try
                {
                    itemPagamento.ValorLíquido = p.ObterValorLíquido(venda);
                }
                catch
                {
                    itemPagamento.ValorLíquido = 0;
                }

                valorTotalLíquido += itemPagamento.ValorLíquido;
                item.SubItems[colValorLíquido.Index].Text = itemPagamento.ValorLíquido.ToString("C", Entidades.Configuração.DadosGlobais.Instância.Cultura);
            }

            if (p.Venda.HasValue)
                item.SubItems[colPagaVenda.Index].Text = Entidades.Relacionamento.Venda.Venda.FormatarCódigo(p.Venda.Value);


            long? pagoNaVenda = null;
            dados.hashPagoNaVenda.TryGetValue(p.Código, out pagoNaVenda);

            if (pagoNaVenda.HasValue)
                item.SubItems[colPagoNaVenda.Index].Text =  Entidades.Relacionamento.Venda.Venda.FormatarCódigo(pagoNaVenda.Value).ToString();
            else
                item.SubItems[colPagoNaVenda.Index].Text = "";

            item.ImageKey = p.Tipo.ToString();

            if (p.Pendente)
            {
                item.UseItemStyleForSubItems = true;
                item.BackColor = Color.Yellow;

                if (p.ÚltimoVencimento < hoje)
                    item.ForeColor = Color.Red;
            }

            hashItemListaPagamento[item] = itemPagamento;
            return item;
        }

        private void adicionarCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro c = new CadastroCrédito();
            AbrirJanelaCadastro(c);

            while (c.DialogResult != DialogResult.Cancel) {
                c = new CadastroCrédito();
                AbrirJanelaCadastro(c);
            }

        }

        /// <summary>
        /// Retorna os pagamentos que estão mostados na lista.
        /// É util para imprimir a informação na mesma ordem que mostrado na tela.
        /// </summary>
        /// <returns></returns>
        internal List<Entidades.Pagamentos.Pagamento> ObterPagamentosExibidos()
        {
            List<Entidades.Pagamentos.Pagamento> lst = new List<Entidades.Pagamentos.Pagamento>(lista.Items.Count);
            foreach (ListViewItem item in lista.Items)
                lst.Add(hashItemListaPagamento[item].Pagamento);

            return lst;
        }
    }
}