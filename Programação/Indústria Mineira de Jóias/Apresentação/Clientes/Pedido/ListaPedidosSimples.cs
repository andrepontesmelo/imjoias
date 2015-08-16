using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using System.Threading;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class ListaPedidosSimples : UserControl
    {
        public delegate void PedidoDelegação(Entidades.PedidoConserto.Pedido pedido);
        public event PedidoDelegação AoDuploClique;

        /// <summary>
        /// Dado o código do pedido, retorna o item gráfico
        /// </summary>
        private Dictionary<ulong, ListViewItem> hashPedidos = new Dictionary<ulong, ListViewItem>();
        private Dictionary<ListViewItem, Entidades.PedidoConserto.Pedido> hashPedidosInverso = new Dictionary<ListViewItem, Entidades.PedidoConserto.Pedido>();

        public ListaPedidosSimples()
        {
            InitializeComponent();

            lista.ListViewItemSorter = new ListaPedidosOrdenador(hashPedidosInverso);
            lista.Columns.Clear();
            lista.Columns.AddRange(new ColumnHeader[7] { colCódigo, colDataRegistro, colPrevisão, colEntrega, colRepresentante, colCliente, colDescrição });

            colCódigo.Name = "colCódigo";
            colDataRegistro.Name = "colDataRegistro";
            colPrevisão.Name = "colPrevisão";
            colRepresentante.Name = "colRepresentante";
            colCliente.Name = "colCliente";
            colDescrição.Name = "colDescrição";
            colEntrega.Name = "colEntrega";
        }

        public Entidades.PedidoConserto.Pedido Primeiro
        {
            get
            {
                if (lista.Items.Count > 0)
                    return hashPedidosInverso[lista.Items[0]];
                else
                    return null;
            }
        }

        public List<Entidades.PedidoConserto.Pedido> ItensSelecionados
        {
            get
            {
                List<Entidades.PedidoConserto.Pedido> listaSelecionados = new List<Entidades.PedidoConserto.Pedido>(lista.SelectedItems.Count);
                foreach (ListViewItem item in lista.SelectedItems)
                {
                    listaSelecionados.Add(hashPedidosInverso[item]);
                }

                return listaSelecionados;
            }
        }

        public void Adicionar(Entidades.PedidoConserto.Pedido pedido)
        {
            ListViewItem item = CriarItem(pedido);

            lista.Items.Add(item);
        }

        public void Adicionar(IEnumerable<Entidades.PedidoConserto.Pedido> pedidos)
        {
            SuspendLayout();
            Visible = false;

            Limpar();

            List<ListViewItem> lstItens = new List<ListViewItem>();

            foreach (Entidades.PedidoConserto.Pedido pedido in pedidos)
                lstItens.Add(CriarItem(pedido));

            lista.Items.AddRange(lstItens.ToArray());

            if (pedidoParaFocarSePossível != null)
                FocarSePossível(pedidoParaFocarSePossível);

            if (lista.Items.Count > 0)
            {
                foreach (ColumnHeader coluna in lista.Columns)
                    coluna.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            Visible = true;
            ResumeLayout();
        }


        /// <summary>
        /// Carrega e exibe todos os pedidos de um período específico.
        /// </summary>
        /// <param name="períodoPrevisão">O período inicio, fim é o de previsão.. Falso pega o período de registro.</param>
        public void Mostrar(Entidades.Pessoa.Pessoa cliente, DateTime início, DateTime fim, bool períodoPrevisão, bool ocultarJáEntregues, bool apenasPedidos)
        {
            if (bgRecuperação.IsBusy)
                return;

            Parâmetros parâmetros = new Parâmetros();
            parâmetros.Cliente = cliente;
            parâmetros.Início = início;
            parâmetros.Fim = fim;
            parâmetros.PeríodoPrevisão = períodoPrevisão;
            parâmetros.OcultarJáEntregues = ocultarJáEntregues;
            parâmetros.ApenasPedidos = apenasPedidos;

            SinalizaçãoCarga.Sinalizar(this,
                    "Carregando ...",
                    "");

            bgRecuperação.RunWorkerAsync(parâmetros);
        }

        /// <summary>
        /// Carrega os dados em segundo plano.
        /// </summary>
        private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            hashPedidos.Clear();
            hashPedidosInverso.Clear();

            Parâmetros parâmetros = e.Argument as Parâmetros;
            Entidades.PedidoConserto.Pedido[] pedidos;

            if (parâmetros.Cliente != null)

                pedidos = Entidades.PedidoConserto.Pedido.ObterPedidosRecebidos(parâmetros.Cliente, parâmetros.Início, parâmetros.Fim, parâmetros.PeríodoPrevisão,
                    parâmetros.OcultarJáEntregues, parâmetros.ApenasPedidos);
            else
                pedidos = Entidades.PedidoConserto.Pedido.ObterPedidosRecebidos(parâmetros.Início, parâmetros.Fim, parâmetros.PeríodoPrevisão,
                    parâmetros.OcultarJáEntregues, parâmetros.ApenasPedidos);

            // Obtem endereço dos pedidos obtidos
            List<Entidades.Pessoa.Pessoa> clientes = new List<Entidades.Pessoa.Pessoa>();
            foreach (Entidades.PedidoConserto.Pedido pedido in pedidos)
            {
                if (pedido.Cliente != null)
                    clientes.Add(pedido.Cliente);
            }

            Entidades.Pessoa.Pessoa.CarregarEndereços(clientes);

            e.Result = pedidos;
        }

        /// <summary>
        /// Ocorre ao carregar os itens.
        /// </summary>
        private void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Entidades.PedidoConserto.Pedido[] pedidos = (Entidades.PedidoConserto.Pedido[])e.Result;

            Adicionar(pedidos);

            SinalizaçãoCarga.Dessinalizar(this);
        }

        internal void FocarSePossível(Entidades.PedidoConserto.Pedido últimoPedidoClicado)
        {
            lista.SelectedItems.Clear();
            pedidoParaFocarSePossível = últimoPedidoClicado;

            ListViewItem item;
            if (hashPedidos.TryGetValue(pedidoParaFocarSePossível.Código, out item)
                && lista.Items.Contains(item))
            {
                //lista.Focus();
                lista.EnsureVisible(item.Index);
                item.Selected = true;
                item.Focused = true;
                //item.EnsureVisible();
                lista.Select();
            }
        }

        private Entidades.PedidoConserto.Pedido pedidoParaFocarSePossível;

        internal void SelecionarPeloTeclado()
        {
            lista.Select();
        }

        internal void Limpar()
        {
            hashPedidos.Clear();
            hashPedidosInverso.Clear();
            lista.Items.Clear();
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0
                && AoDuploClique != null)
            {
                Entidades.PedidoConserto.Pedido item;
                if (hashPedidosInverso.TryGetValue(lista.SelectedItems[0], out item))
                    AoDuploClique(item);
            }
        }

        private void lista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                lista_DoubleClick(sender, new EventArgs());
        }

        private void lista_MouseEnter(object sender, EventArgs e)
        {
            lista.Focus();
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListaPedidosOrdenador)lista.ListViewItemSorter).DefinirColuna(lista.Columns[e.Column]))
                lista.Sorting = SortOrder.Ascending;
            else
                lista.Sorting = SortOrder.Descending;

            lista.Sort();
        }

        /// <summary>
        /// Pode ser novo pedido, ou alterado.
        /// </summary>
        internal void AtualizarExibição(Entidades.PedidoConserto.Pedido últimoPedidoClicado)
        {
            ListViewItem item = null;

            if (!hashPedidos.TryGetValue(últimoPedidoClicado.Código, out item))
                item = CriarItem(últimoPedidoClicado);
        }

        private ListViewItem CriarItem(Entidades.PedidoConserto.Pedido pedido)
        {
            ListViewItem item = new ListViewItem(new String[lista.Columns.Count]);
            hashPedidos[pedido.Código] = item;
            hashPedidosInverso[item] = pedido;

            item.Text = pedido.Código.ToString();

            if (pedido.Cliente != null)
                item.SubItems[colCliente.Index].Text = pedido.Cliente.Nome;
            else
                item.SubItems[colCliente.Index].Text = pedido.NomeDoCliente;

            item.SubItems[colDescrição.Index].Text = (String.IsNullOrEmpty(pedido.Observações) ? "" : pedido.Observações.Replace("\r\n", "   ")) + " " +
                (String.IsNullOrEmpty(pedido.DescriçãoItens) ? "" : pedido.DescriçãoItens.Replace("\r\n", "   "));

            if (pedido.Representante != null && pedido.Representante.Região != null)
                item.SubItems[colRepresentante.Index].Text = pedido.Representante.PrimeiroNome;

            item.SubItems[colDataRegistro.Index].Text = pedido.DataRecepção.ToShortDateString();
            item.SubItems[colPrevisão.Index].Text = pedido.DataPrevisão.ToShortDateString();
            item.SubItems[colEntrega.Index].Text = pedido.DataEntrega.HasValue ? pedido.DataEntrega.Value.ToShortDateString() : "";

            if (!pedido.DataConclusão.HasValue && pedido.DataPrevisão < Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Date)
            {
                //item.BackColor = Color.Red;
                item.ImageIndex = 0;
            }
            else if (!pedido.DataConclusão.HasValue && pedido.DataPrevisão.Date == Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Date)
            {
                //item.BackColor = Color.Yellow;
                item.ImageIndex = 1;
            }
            else if (pedido.DataConclusão.HasValue && !pedido.DataEntrega.HasValue)
            {
                item.ImageIndex = 2;
            }

            if (pedido.DataEntrega.HasValue)
                item.Group = lista.Groups["grupoEntregues"];
            else if (pedido.DataConclusão.HasValue)
                item.Group = lista.Groups["grupoConcluídos"];
            else if (pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Conserto && pedido.DataOficina.HasValue)
                item.Group = lista.Groups["grupoNaOficina"];
            else
                item.Group = lista.Groups["grupoCadastradoRecentemente"];

            return item;
        }

        /// <summary>
        /// Retorna as entidades, na ordem de exibição
        /// </summary>
        /// <returns></returns>
        internal List<Entidades.PedidoConserto.Pedido> ObterPedidos()
        {
            List<Entidades.PedidoConserto.Pedido> listaPedidos = new List<Entidades.PedidoConserto.Pedido>(lista.Items.Count);

            foreach (ListViewGroup grupo in lista.Groups)
            {
                foreach (ListViewItem itemGráfico in grupo.Items)
                {
                    // Quando itens são excluidos, os grupos continuam apontando para eles
                    // Então, para evitar a impressão de itens que não existem mais na hash,
                    // os itens de index "-1" são ignorados.
                    if (itemGráfico.Index >= 0 && hashPedidosInverso.ContainsKey(itemGráfico))
                    {
                        listaPedidos.Add(hashPedidosInverso[itemGráfico]);
                    }
                }

            }

            return listaPedidos;
        }
    }
}