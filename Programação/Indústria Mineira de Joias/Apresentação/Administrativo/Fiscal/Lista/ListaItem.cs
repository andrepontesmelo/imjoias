﻿using Apresentação.Formulários;
using Entidades.Fiscal;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaItem : UserControl
    {
        public ListaItem()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
        }

        internal void Carregar(DocumentoFiscal documento)
        {
            ListViewItem[] itens = CriarItens(documento.Itens);
            lista.Items.Clear();
            lista.Items.AddRange(itens);
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

            item.SubItems[colCFOP.Index].Text = entidade.CFOP?.ToString();
            item.SubItems[colDescrição.Index].Text = entidade.Descrição;
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colReferência.Index].Text = entidade.Referência;
            item.SubItems[colTipoUnidade.Index].Text = entidade.TipoUnidade.ToString();
            item.SubItems[colValorTotal.Index].Text = entidade.Valor.ToString("C");
            item.SubItems[colValorUnitário.Index].Text = entidade.ValorUnitário.ToString("C");

            return item;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }
    }
}
