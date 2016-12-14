using Apresentação.Formulários;
using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.Fiscal.Fabricação;
using System.Drawing;
using Entidades.Fiscal.Esquema;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaInventário : UserControl
    {
        private Dictionary<string, EsquemaFabricação> hashEsquemas;

        public event EventHandler AoDuploClique;

        public ListaInventário()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.ColumnClick += Lista_ColumnClick;
            lista.DoubleClick += Lista_DoubleClick;
        }

        private void Lista_DoubleClick(object sender, EventArgs e)
        {
            AoDuploClique?.Invoke(sender, e);
        }

        private void Lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        public void Carregar(Fechamento fechamento)
        {
            hashEsquemas = EsquemaFabricação.ObterHash(fechamento);
            CarregarItens(CriarItens(Inventário.Obter(fechamento)));
        }

        private ListViewItem[] CriarItens(List<Inventário> entidades)
        {
            ListViewItem[] itens = new ListViewItem[entidades.Count];
            int x = 0;
            foreach (var entidade in entidades)
                itens[x++] = CriarItem(entidade);
            return itens;
        }

        private ListViewItem CriarItem(Inventário entidade)
        {
            ListViewItem item = new ListViewItem(new string[lista.Columns.Count]);

            bool existeEsquemaFabricação = hashEsquemas.ContainsKey(entidade.Referência);

            item.SubItems[colClassificação.Index].Text = entidade.ClassificaçãoFiscal;
            item.SubItems[colDescrição.Index].Text = entidade.Descrição;
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(entidade.Referência, true);
            item.SubItems[colTipoUnidade.Index].Text = entidade.TipoUnidadeComercial?.Nome;
            item.SubItems[colValorUnitário.Index].Text = entidade.ValorFormatado;
            item.SubItems[colValorTotal.Index].Text = entidade.ValorTotalFormatado;
            item.SubItems[colEsquema.Index].Text = existeEsquemaFabricação ? "Sim" : "Não";

            if (entidade.Quantidade < 0 && existeEsquemaFabricação)
                item.BackColor = Color.Yellow;
            else if (entidade.Quantidade < 0 && !existeEsquemaFabricação)
                item.BackColor = Color.FromArgb(0, 255, 255);

            item.Tag = entidade;

            return item;
        }

        internal List<ItemFabricaçãoFiscal> ObterItensChecados(int fechamento)
        {
            var listaEntidades = new List<ItemFabricaçãoFiscal>();

            foreach (ListViewItem item in lista.CheckedItems)
            {
                Inventário i = item.Tag as Inventário;
                listaEntidades.Add(i.ObterItemfabricação(fechamento));
            }

            return listaEntidades;
        }

        public Inventário ObterItemSelecionado()
        {
            var seleção = lista.SelectedItems;

            if (seleção.Count == 0)
                return null;

            return lista.SelectedItems[0].Tag as Inventário;
        }


        private void CarregarItens(ListViewItem[] itens)
        {
            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        internal void LimparSeleção()
        {
            foreach (ListViewItem item in lista.CheckedItems)
                item.Checked = false;
        }

        public void SelecionarNegativos()
        {
            foreach (ListViewItem item in lista.Items)
            {
                Inventário inventário = item.Tag as Inventário;

                if (inventário.Quantidade < 0)
                    item.Checked = true;
            }
        }
    }
}
