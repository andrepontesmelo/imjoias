using Apresentação.Formulários;
using Entidades.Fiscal;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.Fiscal.Tipo;
using System;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaItem : UserControl
    {
        public delegate void AoSelecionarDelegate(ItemFiscal entidade);
        public event AoSelecionarDelegate AoSelecionar;

        public ListaItem()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
        }

        public ItemFiscal Seleção => lista.SelectedItems.Count == 0 ? null : lista.SelectedItems[0].Tag as ItemFiscal;

        internal void Carregar(DocumentoFiscal documento)
        {
            ListViewItem[] itens = CriarItens(documento.Itens);
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            AtualizarStatus(documento.Itens);
        }

        private void AtualizarStatus(List<ItemFiscal> itens)
        {
            decimal somaQuantidade = 0;
            decimal somaValor = 0;

            foreach (ItemFiscal item in itens)
            {
                somaQuantidade += item.Quantidade;
                somaValor += item.Valor;
            }

            statusLinhas.Text = string.Format("Linhas: {0}", itens.Count);
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

            item.SubItems[colCFOP.Index].Text = entidade.Cfop?.ToString();
            item.SubItems[colDescrição.Index].Text = entidade.Descrição;
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colReferência.Index].Text = entidade.Referência;
            item.SubItems[colTipoUnidade.Index].Text = ObterDescrição(entidade.TipoUnidade);
            item.SubItems[colValorTotal.Index].Text = entidade.Valor.ToString("C");
            item.SubItems[colValorUnitário.Index].Text = entidade.ValorUnitário.ToString("C");
            item.Tag = entidade;

            return item;
        }

        private string ObterDescrição(TipoUnidade tipoUnidade)
        {
            switch (tipoUnidade)
            {
                case TipoUnidade.Grs:
                    return "Gramas";
                case TipoUnidade.Par:
                    return "Par";
                case TipoUnidade.Pca:
                    return "Peça";
                case TipoUnidade.Un:
                    return "Unidade";
                default:
                    throw new NotImplementedException();
            }
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
        }
    }
}
