﻿using Apresentação.Formulários;
using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.Fiscal.Produção;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaInventário : UserControl
    {
        public ListaInventário()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.ColumnClick += Lista_ColumnClick;
        }

        private void Lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        public void Carregar(DateTime? dataMáxima)
        {
            CarregarItens(CriarItens(Inventário.Obter(dataMáxima)));
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

            item.SubItems[colClassificação.Index].Text = entidade.ClassificaçãoFiscal;
            item.SubItems[colDescrição.Index].Text = entidade.Descrição;
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(entidade.Referência, true);
            item.SubItems[colTipoUnidade.Index].Text = entidade.TipoUnidadeComercial?.Nome;
            item.SubItems[colValorUnitário.Index].Text = entidade.ValorFormatado;
            item.SubItems[colValorTotal.Index].Text = entidade.ValorTotalFormatado;

            item.Tag = entidade;

            return item;
        }

        internal List<ItemProduçãoFiscal> ObterItensChecados()
        {
            var listaEntidades = new List<ItemProduçãoFiscal>();

            foreach (ListViewItem item in lista.CheckedItems)
            {
                Inventário i = item.Tag as Inventário;
                listaEntidades.Add(i.ObterItemProdução());
            }

            return listaEntidades;
        }

        private void CarregarItens(ListViewItem[] itens)
        {
            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }
    }
}
