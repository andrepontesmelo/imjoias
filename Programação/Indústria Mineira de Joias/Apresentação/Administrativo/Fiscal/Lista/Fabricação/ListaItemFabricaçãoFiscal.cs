using Entidades.Fiscal.Fabricação;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaItemFabricaçãoFiscal : UserControl
    {
        public event EventHandler AoExcluir;

        public ListaItemFabricaçãoFiscal()
        {
            InitializeComponent();
            lista.AoExcluir += Lista_AoExcluir;
        }

        private void Lista_AoExcluir(object sender, EventArgs e)
        {
            AoExcluir?.Invoke(sender, e);
        }

        protected void Carregar(List<ItemFabricaçãoFiscal> entidades)
        {
            AdicionarItens(CriarItens(entidades));
        }

        private ListViewItem[] CriarItens(List<ItemFabricaçãoFiscal> entidades)
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

        private ListViewItem CriarItem(ItemFabricaçãoFiscal entidade)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.SubItems[colCódigo.Index].Text = entidade.Código.ToString();
            item.SubItems[colReferência.Index].Text = entidade.Mercadoria.Referência;
            item.SubItems[colQuantidade.Index].Text = entidade.Quantidade.ToString();
            item.SubItems[colDescrição.Index].Text = entidade.Mercadoria.Descrição;
            item.SubItems[colTipo.Index].Text = entidade.Mercadoria.TipoUnidadeComercial.Nome;
            item.SubItems[colValor.Index].Text = entidade.Valor.ToString("C");

            item.Tag = entidade;

            return item;
        }

        public List<ItemFabricaçãoFiscal> ObterSeleção()
        {
            List<ItemFabricaçãoFiscal> resultado = new List<ItemFabricaçãoFiscal>();

            foreach (ListViewItem item in lista.SelectedItems)
                resultado.Add(item.Tag as ItemFabricaçãoFiscal);

            return resultado;
        }
    }
}
