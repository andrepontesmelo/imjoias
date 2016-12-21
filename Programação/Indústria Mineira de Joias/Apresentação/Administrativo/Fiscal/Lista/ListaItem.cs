using Apresentação.Formulários;
using Entidades.Fiscal;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaItem : UserControl
    {
        public delegate void AoSelecionarDelegate(ItemFiscal entidade);
        public event AoSelecionarDelegate AoSelecionar;
        public event EventHandler AoExcluir;

        public ListaItem()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.AoExcluir += Lista_AoExcluir;
        }

        private void Lista_AoExcluir(object sender, EventArgs e)
        {
            AoExcluir?.Invoke(sender, e);
        }

        internal void Carregar(DocumentoFiscal documento)
        {
            ListViewItem[] itens = CriarItens(documento.Itens);
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            AtualizarStatus();
        }

        private void AtualizarStatus()
        {
            decimal somaQuantidade = 0;
            decimal somaValor = 0;

            foreach (ListViewItem itemGráfico in lista.Items)
            {
                var item = itemGráfico.Tag as ItemFiscal;
                somaQuantidade += item.Quantidade;
                somaValor += item.Valor;
            }

            statusLinhas.Text = string.Format("Linhas: {0}", lista.Items.Count);
            statusQtd.Text = string.Format("Qtd: {0}", somaQuantidade);
            statusValorTotal.Text = string.Format("{0}", somaValor.ToString("C"));
        }

        private ListViewItem[] CriarItens(List<ItemFiscal> lstItens)
        {
            ListViewItem[] itens = new ListViewItem[lstItens.Count];

            for (int x = 0; x < lstItens.Count; x++)
                itens[x] = CriarItem(lstItens[x]);

            return itens;
        }

        private ListViewItem CriarItem(ItemFiscal entidade)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.Name = entidade.Código.ToString();
            CarregarItemGráfico(item, entidade);
            item.Tag = entidade;

            return item;
        }

        private void CarregarItemGráfico(ListViewItem itemGráfico, ItemFiscal item)
        {
            itemGráfico.SubItems[colCFOP.Index].Text = item.Cfop?.ToString();
            itemGráfico.SubItems[colDescrição.Index].Text = item.Descrição;
            itemGráfico.SubItems[colQuantidade.Index].Text = item.Quantidade.ToString("0.00");
            itemGráfico.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(item.Referência, true);

            if (item.TipoUnidade.HasValue)
                itemGráfico.SubItems[colTipoUnidade.Index].Text = TipoUnidade.Obter(item.TipoUnidade.Value).Nome;

            itemGráfico.SubItems[colValorTotal.Index].Text = item.Valor.ToString("C");
            itemGráfico.SubItems[colValorUnitário.Index].Text = item.ValorUnitário.ToString("C");
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            AoSelecionar?.Invoke(Seleção);
        }

        internal void Recarregar(ItemFiscal item)
        {
            ListViewItem itemGráfico = lista.Items[lista.Items.IndexOfKey(item.Código.ToString())];
            CarregarItemGráfico(itemGráfico, item);
        }

        internal void Adicionar(ItemFiscal item)
        {
            lista.Items.Add(CriarItem(item));
            AtualizarStatus();
        }

        public ItemFiscal Seleção => lista.SelectedItems.Count == 0 ? null : lista.SelectedItems[0].Tag as ItemFiscal;

        public List<ItemFiscal> ItensSelecionados
        {
            get
            {
                List<ItemFiscal> itens = new List<ItemFiscal>();

                foreach (ListViewItem item in lista.SelectedItems)
                    itens.Add(item.Tag as ItemFiscal);

                return itens;
            }
        }
    }
}
