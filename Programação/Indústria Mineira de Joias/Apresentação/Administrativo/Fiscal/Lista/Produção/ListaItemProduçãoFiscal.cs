using Entidades.Fiscal.Produção;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaItemProduçãoFiscal : UserControl
    {
        public event EventHandler AoExcluir;

        public ListaItemProduçãoFiscal()
        {
            InitializeComponent();
            lista.AoExcluir += Lista_AoExcluir;
        }

        private void Lista_AoExcluir(object sender, EventArgs e)
        {
            AoExcluir?.Invoke(sender, e);
        }

        protected void Carregar(List<ItemProduçãoFiscal> entidades)
        {
            AdicionarItens(CriarItens(entidades));
        }

        private ListViewItem[] CriarItens(List<ItemProduçãoFiscal> entidades)
        {
            ListViewItem[] itens = new ListViewItem[entidades.Count];
            int x = 0;

            foreach (var entidade in entidades)
                itens[x++] = CriarItem(entidade);

            return itens;
        }

        private void AdicionarItens(ListViewItem[] itens)
        {
            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        private ListViewItem CriarItem(ItemProduçãoFiscal entidade)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.SubItems[colReferência.Index].Text = entidade.Mercadoria.Referência;
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colDescrição.Index].Text = entidade.Mercadoria.Descrição;
            item.SubItems[colTipo.Index].Text = entidade.Mercadoria.TipoUnidadeComercial.Nome;
            item.Tag = entidade;

            return item;
        }

        public List<ItemProduçãoFiscal> ObterSeleção()
        {
            List<ItemProduçãoFiscal> resultado = new List<ItemProduçãoFiscal>();

            foreach (ListViewItem item in lista.SelectedItems)
                resultado.Add(item.Tag as ItemProduçãoFiscal);

            return resultado;
        }
    }
}
