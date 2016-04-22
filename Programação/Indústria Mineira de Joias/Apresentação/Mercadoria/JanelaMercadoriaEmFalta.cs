using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;
using Apresentação.Atendimento.Clientes.Pedido;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Pedido.MercadoriaEmFaltaCliente;

namespace Apresentação.Mercadoria
{
    public partial class JanelaMercadoriaEmFalta : Apresentação.Formulários.JanelaExplicativa
    {
        private List<MercadoriaEmFaltaCliente> itens;
        private Entidades.Pessoa.Pessoa emPosseDe;

        public JanelaMercadoriaEmFalta()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Carregar(Entidades.Pessoa.Pessoa pessoa, IWin32Window janelaBase)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();

            emPosseDe = pessoa;
            itens = MercadoriaEmFaltaCliente.Obter(pessoa.Código);
            UseWaitCursor = false;
            AguardeDB.Fechar();

            foreach (MercadoriaEmFaltaCliente m in itens)
            {
                // Só faz sentido cobrar do cliente quando ele possue as mercadorias em mãos, ou seja, ainda não vendeu nem retornou.
                if (m.QuantidadeConsignado > 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = m.DiasEspera.ToString();
                    item.SubItems.Add(m.QuantidadePedido.ToString());
                    item.SubItems.Add(m.QuantidadeConsignado.ToString());
                    item.SubItems.Add(Entidades.Mercadoria.Mercadoria.MascararReferência(m.ReferênciaNumérica));
                    item.SubItems.Add(m.Pedido.ToString());
                    item.SubItems.Add(m.ClienteNome);
                    item.SubItems.Add(m.Descricao);
                    item.Tag = m.Pedido;
                    this.lista.Items.Add(item);
                }
            }

            colCliente.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Focus();

            ShowDialog(janelaBase);
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
            {
                AguardeDB.Mostrar();
                Cursor.Current = Cursors.WaitCursor;

                ListViewItem item = lista.SelectedItems[0];
                Entidades.PedidoConserto.Pedido p = Entidades.PedidoConserto.Pedido.ObterPedido((long) item.Tag);

                Apresentação.Impressão.Relatórios.Pedido.Recibo.Relatório relatório = new Apresentação.Impressão.Relatórios.Pedido.Recibo.Relatório();
                Apresentação.Impressão.Relatórios.Pedido.Recibo.ControleImpressão controle = new Apresentação.Impressão.Relatórios.Pedido.Recibo.ControleImpressão();
                controle.PrepararImpressão(relatório, new List<Entidades.PedidoConserto.Pedido>() { p });
                Apresentação.Formulários.JanelaImpressão janelaVisualizaçãoImpressão = new Apresentação.Formulários.JanelaImpressão();
                janelaVisualizaçãoImpressão.Título = "Impressão de Recibos";
                janelaVisualizaçãoImpressão.Descrição = "";
                janelaVisualizaçãoImpressão.InserirDocumento(relatório, "Recibos");

                AguardeDB.Fechar();
                Cursor.Current = Cursors.Default;

                janelaVisualizaçãoImpressão.Abrir(this);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            Relatório relatório = new Relatório();

            ControleImpressão.PrepararImpressão(relatório, itens, emPosseDe);

            PrintDialog printDialog = new PrintDialog();
            AguardeDB.Fechar();
            DialogResult resultado = printDialog.ShowDialog(this);

            if (resultado == DialogResult.OK)
            {
                relatório.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                relatório.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            } 

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
