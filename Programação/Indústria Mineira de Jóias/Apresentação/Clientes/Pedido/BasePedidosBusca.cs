using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Pedido;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Entidades.Configuração;
using Entidades.Privilégio;

[assembly: ExporBotão(Permissão.Nenhuma, 6, "Pedidos e Consertos",
    true, typeof(Apresentação.Atendimento.Clientes.Pedido.BasePedidosBusca))]

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class BasePedidosBusca : BaseInferior
    {
        private ColetorPedidos coletor;
        //private Entidades.PedidoConserto.Pedido últimoPedidoClicado = null;

        public BasePedidosBusca()
        {
             InitializeComponent();
             coletor = new ColetorPedidos(new ColetorPedidos.RecuperaçãoPedidosDelegate(Recuperação));
             coletor.InícioDeBusca += new Apresentação.Formulários.Consultas.Coletor.InícioDeBuscaDelegate(coletor_InícioDeBusca);
             coletor.FinalDeBusca += new Apresentação.Formulários.Consultas.Coletor.FinalDeBuscaDelegate(coletor_FinalDeBusca);
             txtBusca.Focus();
        }

        void coletor_FinalDeBusca()
        {
            UseWaitCursor = false;
        }

        void coletor_InícioDeBusca()
        {
            UseWaitCursor = true;
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaPedidos.Limpar();

            //últimoPedidoClicado = null;
            //Recarregar();

            //if (últimoPedidoClicado != null)
            //    listaPedidos.FocarSePossível(últimoPedidoClicado);


            coletor.Reinicializar(); 
            txtBusca.Text = "";
            txtBusca.Focus();
        }

                void listaPedidos_AoDuploClique(Entidades.PedidoConserto.Pedido pedido)
        {
            VisualizarPedido(pedido);
        }



        /// <summary>
        /// Vai para tela de visualização/edição de pedido
        /// </summary>
        /// <param name="pedido"></param>
        private void VisualizarPedido(Entidades.PedidoConserto.Pedido pedido)
        {
            //últimoPedidoClicado = pedido;
            SubstituirBase(new BaseEditarPedido(pedido));
        }

        /// <summary>
        /// Ocorre quando o coletor recupera nomes
        /// </summary>
        /// <param name="nomes">Nomes recuperados da camada de acesso</param>
        private void Recuperação(Entidades.PedidoConserto.Pedido[] pedidos)
        {
            try
            {
                if (listaPedidos.InvokeRequired)
                {
                    RecuperaçãoCallback método = new RecuperaçãoCallback(Recuperação);
                    listaPedidos.BeginInvoke(método, new object[] { pedidos });
                }
                else
                {
                    listaPedidos.Adicionar(pedidos);

                    if (ultimaTeclaNaTxtBuscaÉEnter && pedidos.Length > 0)
                        VisualizarPedido(pedidos[0]);
                    else
                        txtBusca.Focus();
                }
            }
            catch (ObjectDisposedException)
            { /* Ignorar */ }
        }

        /// Se a última tecla for enter,
        /// assim que a lista for carregada, o primeiro item será entrado automaticamente.
        /// </summary>
        private bool ultimaTeclaNaTxtBuscaÉEnter = false;
        
        private delegate void RecuperaçãoCallback(Entidades.PedidoConserto.Pedido[] pedidos);

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                listaPedidos.SelecionarPeloTeclado();
                listaPedidos.Select();
            }

            ultimaTeclaNaTxtBuscaÉEnter = (e.KeyCode == Keys.Enter);

            if (!coletor.Pesquisando && ultimaTeclaNaTxtBuscaÉEnter && listaPedidos.Primeiro != null)
            {
                VisualizarPedido(listaPedidos.Primeiro);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text.Trim().Length == 0)
                listaPedidos.Limpar();
            else
                coletor.Pesquisar(txtBusca.Text);

            txtBusca.Focus();
        }

        private void opçãoLocalizar_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BasePedidos());
        }

        private void opçãoNovo_Click(object sender, EventArgs e)
        {
            BaseEditarPedido novaBase = new BaseEditarPedido();
            SubstituirBase(novaBase);
        }

        private void opçãoReferênciasEmFalta_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseReferênciasEmFalta());
        }
    }
}
