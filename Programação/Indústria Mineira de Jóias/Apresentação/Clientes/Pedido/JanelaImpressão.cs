using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class JanelaImpressão : JanelaExplicativa
    {
        private static JanelaImpressão instância;

        public static JanelaImpressão Instância
        {
            get
            {
                if (instância == null)
                    instância = new JanelaImpressão();

                return instância;
            }
        }

        private List<ulong> listaCódigosPedidosParaImpressão;


        public JanelaImpressão()
        {
            InitializeComponent();
            listaCódigosPedidosParaImpressão = new List<ulong>();
        }

        public void AdicionarPedidoNaFila(Entidades.PedidoConserto.Pedido entidade)
        {
            if (entidade.Cadastrado && !listaCódigosPedidosParaImpressão.Contains(entidade.Código))
                listaCódigosPedidosParaImpressão.Add(entidade.Código);

            AtualizaLista();
            Show();
            btnImprimir.Focus();
        }

        private void AtualizaLista()
        {
            lstDocumentos.Items.Clear();

            foreach (uint código in listaCódigosPedidosParaImpressão)
            {
                Entidades.PedidoConserto.Pedido pedidoAtual = Entidades.PedidoConserto.Pedido.ObterPedido(código);

                lstDocumentos.Items.Add(pedidoAtual);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void JanelaImpressão_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            Apresentação.Impressão.Relatórios.Pedido.Recibo.Relatório relatório = new Apresentação.Impressão.Relatórios.Pedido.Recibo.Relatório();
            Apresentação.Impressão.Relatórios.Pedido.Recibo.ControleImpressão controle = new Apresentação.Impressão.Relatórios.Pedido.Recibo.ControleImpressão();

            // Recarga de entidades para garatir obtenção de atualizações
            List<Entidades.PedidoConserto.Pedido> entidadesParaImprimir = new List<Entidades.PedidoConserto.Pedido>();
            foreach (uint código in listaCódigosPedidosParaImpressão)
            {
                //for (int cópiaAtual = 1; cópiaAtual <= txtCópias.Value; cópiaAtual++)
                    entidadesParaImprimir.Add(Entidades.PedidoConserto.Pedido.ObterPedido(código));
            }

            controle.PrepararImpressão(relatório, entidadesParaImprimir);
            Apresentação.Formulários.JanelaImpressão janelaVisualizaçãoImpressão = new Apresentação.Formulários.JanelaImpressão();
            janelaVisualizaçãoImpressão.Título = "Impressão de Recibos";
            janelaVisualizaçãoImpressão.Descrição = "";

            janelaVisualizaçãoImpressão.InserirDocumento(relatório, "Recibos");
            AguardeDB.Fechar();
            janelaVisualizaçãoImpressão.Abrir(this);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstDocumentos.SelectedItem != null)
            {
                ulong códigoRemover = 
                    ((Entidades.PedidoConserto.Pedido) lstDocumentos.SelectedItem).Código;

                listaCódigosPedidosParaImpressão.Remove(códigoRemover);
                AtualizaLista();
            }

            if (listaCódigosPedidosParaImpressão.Count == 0)
                Hide();
            else
            {
                lstDocumentos.SelectedIndex = 0;
                lstDocumentos.Select();
                btnRemover.Focus();
            }
        }
    }
}
