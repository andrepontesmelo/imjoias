using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Pedido.MercadoriaEmFaltaCliente;
using Entidades.Mercadoria;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    public partial class JanelaMercadoriaEmFalta : JanelaExplicativa
    {
        private List<MercadoriaEmFaltaCliente> mercadorias;
        private Entidades.Pessoa.Pessoa emPosseDe;

        public JanelaMercadoriaEmFalta()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.ColumnClick += Lista_ColumnClick;
        }

        private void Lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var ordenador = (ListViewColumnSorter)lista.ListViewItemSorter;
            ordenador.OnClick(lista, e);
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
            mercadorias = MercadoriaEmFaltaCliente.Obter(pessoa.Código);
            UseWaitCursor = false;
            AguardeDB.Fechar();

            foreach (MercadoriaEmFaltaCliente mercdoria in mercadorias)
            {
                if (mercdoria.QuantidadeConsignado > 0)
                    lista.Items.Add(CriarItem(mercdoria));
            }

            colCliente.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Focus();

            ShowDialog(janelaBase);
        }

        private static ListViewItem CriarItem(MercadoriaEmFaltaCliente m)
        {
            ListViewItem item = new ListViewItem();
            item.Text = m.DiasEspera.ToString();
            item.SubItems.Add(m.QuantidadePedido.ToString());
            item.SubItems.Add(m.QuantidadeConsignado.ToString());
            item.SubItems.Add(Entidades.Mercadoria.Mercadoria.MascararReferência(m.ReferênciaRastreável));
            item.SubItems.Add(m.Pedido.ToString());
            item.SubItems.Add(m.ClienteNome);
            item.SubItems.Add(m.Descricao);
            item.Tag = m.Pedido;
            return item;
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
            {
                AguardeDB.Mostrar();
                Cursor.Current = Cursors.WaitCursor;

                ListViewItem item = lista.SelectedItems[0];
                Entidades.PedidoConserto.Pedido p = Entidades.PedidoConserto.Pedido.ObterPedido((long) item.Tag);

                Impressão.Relatórios.Pedido.Recibo.Relatório relatório = new Impressão.Relatórios.Pedido.Recibo.Relatório();
                Impressão.Relatórios.Pedido.Recibo.ControleImpressão controle = new Impressão.Relatórios.Pedido.Recibo.ControleImpressão();
                controle.PrepararImpressão(relatório, new List<Entidades.PedidoConserto.Pedido>() { p });
                JanelaImpressão janelaVisualizaçãoImpressão = new JanelaImpressão();
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

            ControleImpressão.PrepararImpressão(relatório, mercadorias, emPosseDe);

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
