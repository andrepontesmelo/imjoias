using Apresentação.Formulários;
using Entidades.Mercadoria;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Manutenção.Lista
{
    public partial class ListaMercadorias : UserControl
    {
        public event EventHandler DuploClique;

        public ListaMercadorias()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.ColumnClick += Lista_ColumnClick;
        }

        private void Lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        private void lista_DoubleClick(object sender, System.EventArgs e)
        {
            DuploClique?.Invoke(sender, e);
        }

        public void Carregar()
        {
            var entidades = MercadoriaManutenção.Obter();
            List<ListViewItem> itens = CriarItens(entidades);

            lista.Items.Clear();
            lista.Items.AddRange(itens.ToArray());
        }

        private List<ListViewItem> CriarItens(List<MercadoriaManutenção> entidades)
        {
            List<ListViewItem> resultado = new List<ListViewItem>();

            foreach (var entidade in entidades)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.AddRange(new string[] { "", "", "", "", "", "", "", "", ""});
                item.SubItems[colDePeso.Index].Text = entidade.DePeso ? "Sim" : "Não";
                item.SubItems[colPeso.Index].Text = entidade.Peso.ToString();
                item.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(entidade.Referência, true);
                item.SubItems[colDescrição.Index].Text = entidade.Nome;
                item.SubItems[colFornecedor.Index].Text = entidade.Fornecedor.ToString();
                item.SubItems[colPreçoCusto.Index].Text = entidade.PreçoCusto.ToString("C");
                item.SubItems[colForaDeLinha.Index].Text = entidade.ForaDeLinha ? "Sim" : "Não";

                resultado.Add(item);
            }

            return resultado;
        }
    }
}
