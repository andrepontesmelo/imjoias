using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.PedidoConserto;
using Entidades.Mercadoria;
using Apresentação.Formulários;
using Apresentação.Mercadoria;
using Apresentação.Impressão.Relatórios.Pedido.MercadoriaEmFalta;
using Entidades;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class BaseReferênciasEmFalta : Apresentação.Formulários.BaseInferior
    {
        private List<MercadoriaEmFalta> mercadorias;

        public BaseReferênciasEmFalta()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new Apresentação.Formulários.ListViewColumnSorter();

            lista.Visible = false;
            AguardeDB.Mostrar();
            mercadorias = MercadoriaEmFalta.Obter(null, true);

            ListViewItem[] lstItens = new ListViewItem[mercadorias.Count];
            int x = 0;
            foreach (MercadoriaEmFalta m in mercadorias)
            {
                ListViewItem item = CriarItem(m);
                lstItens[x++] = item;
            }

            lista.Items.AddRange(lstItens);

            colReferênciaFornecedor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colReferênciaFornecedor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colPedidos.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colDescrição.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            AguardeDB.Fechar();
            lista.Visible = true;
        }

        private ListViewItem CriarItem(MercadoriaEmFalta m)
        {
            ListViewItem item = new ListViewItem(new string[lista.Columns.Count]);
            item.SubItems[colReferência.Index].Text = m.ReferênciaFormatada;
            Entidades.Fornecedor f = Entidades.Fornecedor.ObterFornecedor(m.Fornecedor);
            if (f != null)
                item.SubItems[colFornecedor.Index].Text = f.Nome;

            item.SubItems[colReferênciaFornecedor.Index].Text = m.ReferênciaFornecedor;
            item.SubItems[colPedidos.Index].Text = m.Pedidos;
            item.SubItems[colSaldoConsignado.Index].Text = m.SaldoConsignado.ToString();
            item.SubItems[colEncomendado.Index].Text = m.Quantidade.ToString();
            item.SubItems[colDescrição.Index].Text = m.Detalhes;
            return item;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((Apresentação.Formulários.ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count == 0)
                return;

            Entidades.Mercadoria.Mercadoria m = Entidades.Mercadoria.Mercadoria.ObterMercadoria(lista.SelectedItems                         [0].Text, Entidades.Tabela.TabelaPadrão);

            if (m == null)
            {
                MessageBox.Show("Esta mercadoria não está cadastrada no banco de dados", "Referência inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RastrearMercadoria janela = new RastrearMercadoria(m);
            janela.Show();
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            Apresentação.Impressão.Relatórios.Pedido.MercadoriaEmFalta.Relatório relatório = new
                Apresentação.Impressão.Relatórios.Pedido.MercadoriaEmFalta.Relatório();

            ControleImpressãoMercadoriaEmFalta.PrepararImpressão(relatório, mercadorias);

            PrintDialog printDialog = new PrintDialog();
            AguardeDB.Fechar();
            DialogResult resultado = printDialog.ShowDialog(this);

            if (resultado == DialogResult.OK)
            {
                relatório.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                relatório.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            } 
        }
    }
}
