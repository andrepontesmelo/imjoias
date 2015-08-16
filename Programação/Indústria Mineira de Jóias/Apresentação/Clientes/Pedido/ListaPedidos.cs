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
    public partial class ListaPedidos : UserControl
    {
        /// <summary>
        /// Dado o código do pedido, retorna o item gráfico
        /// </summary>
        private Dictionary<ulong, ItemPedido> hashPedidos = new Dictionary<ulong, ItemPedido>();

        public event ItemPedido.PedidoDelegate AoClicar;

        public ListaPedidos()
        {
            InitializeComponent();

            this.flowLayoutPanel.MouseEnter += new EventHandler(ListaPedidos_MouseEnter);
        }

        public Entidades.PedidoConserto.Pedido Primeiro
        {
            get
            {
                if (flowLayoutPanel.Controls.Count == 0)
                    return null;
                return ((ItemPedido) flowLayoutPanel.Controls[0]).Pedido;
            }
        }
        void ListaPedidos_MouseEnter(object sender, EventArgs e)
        {
            flowLayoutPanel.Focus();
        }

        public void Adicionar(Entidades.PedidoConserto.Pedido pedido)
        {
            ItemPedido item = new ItemPedido(pedido);
            hashPedidos[pedido.Código] = item;

            //item.Width = flowLayoutPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            flowLayoutPanel.Controls.Add(item);
            item.AoClicar += new ItemPedido.PedidoDelegate(item_AoClicar);
        }

        void item_AoClicar(ItemPedido sender, Entidades.PedidoConserto.Pedido pedido)
        {
            AoClicar(sender, pedido);
        }

        public void Adicionar(IEnumerable<Entidades.PedidoConserto.Pedido> pedidos)
        {
            SuspendLayout();
            Visible = false;

            Limpar();

            foreach (Entidades.PedidoConserto.Pedido pedido in pedidos)
                Adicionar(pedido);

            if (pedidoParaFocarSePossível != null)
            {
                ItemPedido item;
                if (hashPedidos.TryGetValue(pedidoParaFocarSePossível.Código, out item)
                    && flowLayoutPanel.Contains(item))
                {
                    flowLayoutPanel.ScrollControlIntoView(item);
                }
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

            //períodoInicial = início;
            //períodoFinal = fim;

            //try
            //{
            //    Entidades.PedidoConserto.Pedido[] pedidos;

            //    if (cliente != null)
            //        pedidos = Entidades.PedidoConserto.Pedido.ObterPedidosRecebidos(cliente, início, fim, períodoPrevisão, ocultarJáEntregues, apenasPedidos);
            //    else
            //        pedidos = Entidades.PedidoConserto.Pedido.ObterPedidosRecebidos(início, fim, períodoPrevisão, ocultarJáEntregues, apenasPedidos);

            //    // Obtem endereço dos pedidos obtidos
            //    List<Entidades.Pessoa.Pessoa> clientes = new List<Entidades.Pessoa.Pessoa>();
            //    foreach (Entidades.PedidoConserto.Pedido pedido in pedidos)
            //        clientes.Add(pedido.Cliente);
            //    Entidades.Pessoa.Pessoa.CarregarEndereços(clientes.ToArray());

            //    flowLayoutPanel.Controls.Clear();
            //    Adicionar(pedidos);
            //}
            //finally
            //{
            //    AguardeDB.Fechar();
            //}
        }

        /// <summary>
        /// Carrega os dados em segundo plano.
        /// </summary>
        private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            hashPedidos.Clear();

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
            pedidoParaFocarSePossível = últimoPedidoClicado;

            ItemPedido item;
            if (hashPedidos.TryGetValue(últimoPedidoClicado.Código, out item)
                && flowLayoutPanel.Contains(item))
            {
                flowLayoutPanel.ScrollControlIntoView(item);
            }
        }

        private Entidades.PedidoConserto.Pedido pedidoParaFocarSePossível;

        internal void SelecionarPeloTeclado()
        {
            flowLayoutPanel.Select();

            if (flowLayoutPanel.Controls.Count > 0)
                ((ItemPedido) flowLayoutPanel.Controls[0]).SelecionarViaTeclado();
        }

        internal void Limpar()
        {
            hashPedidos.Clear();
            flowLayoutPanel.Controls.Clear();
        }
    }
}
