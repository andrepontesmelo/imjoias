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
        public event ItemPedido.PedidoDelegate AoClicar;
        private DateTime? períodoInicial, períodoFinal;
        private bool ocultarJáEntregues;

        public DateTime? PeríodoInicial { get { return períodoInicial; } }
        public DateTime? PeríodoFinal { get { return períodoFinal; } }

        public ListaPedidos()
        {
            InitializeComponent();
        }

        public void Adicionar(Entidades.Pedido pedido)
        {
            ItemPedido item = new ItemPedido(pedido);
            //item.Width = flowLayoutPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            flowLayoutPanel.Controls.Add(item);
            item.AoClicar += new ItemPedido.PedidoDelegate(item_AoClicar);
        }

        void item_AoClicar(ItemPedido sender, Entidades.Pedido pedido)
        {
            AoClicar(sender, pedido);
        }

        public void Adicionar(IEnumerable<Entidades.Pedido> pedidos)
        {
            SuspendLayout();
            Visible = false;

            foreach (Entidades.Pedido pedido in pedidos)
                Adicionar(pedido);

            Visible = true;
            ResumeLayout();
        }

        ///// <summary>
        ///// Carrega e exibe todos os pedidos pendentes de um cliente.
        ///// </summary>
        ///// <param name="cliente">Cliente a ser exibido. (Pode ser nulo)</param>
        //public void Mostrar(Entidades.Pessoa.Pessoa cliente, bool ocultarJáEntregues)
        //{
        //    if (bgRecuperação.IsBusy)
        //        return;

        //    flowLayoutPanel.Controls.Clear();

        //    períodoInicial = null;
        //    períodoFinal = null;

        //    this.ocultarJáEntregues = ocultarJáEntregues;

        //    SinalizaçãoCarga.Sinalizar(this,
        //        "Carregando pedidos...",
        //        "Aguarde enquanto o sistema carrega os pedidos.");

        //    bgRecuperação.RunWorkerAsync(cliente);
        //}

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
                    "Carregando pedidos e concertos...",
                    "Aguarde enquanto o sistema carrega os pedidos.");

                bgRecuperação.RunWorkerAsync(parâmetros);

            //períodoInicial = início;
            //períodoFinal = fim;

            //try
            //{
            //    Entidades.Pedido[] pedidos;

            //    if (cliente != null)
            //        pedidos = Entidades.Pedido.ObterPedidosRecebidos(cliente, início, fim, períodoPrevisão, ocultarJáEntregues, apenasPedidos);
            //    else
            //        pedidos = Entidades.Pedido.ObterPedidosRecebidos(início, fim, períodoPrevisão, ocultarJáEntregues, apenasPedidos);

            //    // Obtem endereço dos pedidos obtidos
            //    List<Entidades.Pessoa.Pessoa> clientes = new List<Entidades.Pessoa.Pessoa>();
            //    foreach (Entidades.Pedido pedido in pedidos)
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
            Parâmetros parâmetros = e.Argument as Parâmetros;
            Entidades.Pedido[] pedidos;

            if (parâmetros.Cliente != null)

                pedidos = Entidades.Pedido.ObterPedidosRecebidos(parâmetros.Cliente, parâmetros.Início, parâmetros.Fim, parâmetros.PeríodoPrevisão, 
                    parâmetros.OcultarJáEntregues, parâmetros.ApenasPedidos);
            else
                pedidos = Entidades.Pedido.ObterPedidosRecebidos(parâmetros.Início, parâmetros.Fim, parâmetros.PeríodoPrevisão,
                    parâmetros.OcultarJáEntregues, parâmetros.ApenasPedidos);

            // Obtem endereço dos pedidos obtidos
            List<Entidades.Pessoa.Pessoa> clientes = new List<Entidades.Pessoa.Pessoa>();
            foreach (Entidades.Pedido pedido in pedidos)
                clientes.Add(pedido.Cliente);
            Entidades.Pessoa.Pessoa.CarregarEndereços(clientes.ToArray());

            e.Result = pedidos;
        }

        /// <summary>
        /// Ocorre ao carregar os itens.
        /// </summary>
        private void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Entidades.Pedido[] pedidos = (Entidades.Pedido[])e.Result;

            flowLayoutPanel.Controls.Clear();
            Adicionar(pedidos);

            SinalizaçãoCarga.Dessinalizar(this);
        }
    }
}
