using Apresentação.Formulários;
using Entidades.Fiscal.Esquema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaIngredienteEsquema : UserControl
    {
        public event EventHandler AoSelecionar;
        public event EventHandler AoExcluir;

        public ListaIngredienteEsquema()
        {
            InitializeComponent();

            lista.SelectedIndexChanged += Lista_SelectedIndexChanged;
            lista.AoExcluir += Lista_AoExcluir;
            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.ColumnClick += Lista_ColumnClick;
        }

        private void Lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        private void Lista_AoExcluir(object sender, EventArgs e)
        {
            AoExcluir?.Invoke(sender, e);
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            AoSelecionar?.Invoke(sender, e);
        }

        internal void Carregar(EsquemaProdução esquema)
        {
            List<ListViewItem> itens = CriarItens(esquema);

            lista.Items.Clear();
            lista.Items.AddRange(itens.ToArray());
        }

        private List<ListViewItem> CriarItens(EsquemaProdução esquema)
        {
            List<ListViewItem> itens = new List<ListViewItem>();
            var ingredientes = MateriaPrima.Obter(esquema.Referência);

            foreach (MateriaPrima i in ingredientes)
                itens.Add(CriarItem(i));

            return itens;
        }

        private ListViewItem CriarItem(MateriaPrima i)
        {
            ListViewItem item = new ListViewItem(new string[lista.Columns.Count]);
            item.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(i.Referência);
            item.SubItems[colTipoUnidade.Index].Text = i.TipoUnidadeComercial.Nome;
            item.SubItems[colQuantidade.Index].Text = i.Quantidade.ToString();
            item.SubItems[colDescrição.Index].Text = i.Descrição;
            item.Tag = i;

            return item;
        }

        public List<MateriaPrima> Seleção
        {
            get
            {
                List<MateriaPrima> lst = new List<MateriaPrima>();

                var seleção = lista.SelectedItems;

                foreach (ListViewItem i in seleção)
                    lst.Add(i.Tag as MateriaPrima);

                return lst;
            }
        }
    }
}
