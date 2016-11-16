using Entidades.Fiscal.Produção;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaProduções : UserControl
    {
        public event EventHandler AoDuploClique;

        public ListaProduções()
        {
            InitializeComponent();
            lista.AoExcluir += Lista_AoExcluir;
            lista.DoubleClick += Lista_DoubleClick;
        }

        private void Lista_DoubleClick(object sender, System.EventArgs e)
        {
            AoDuploClique?.Invoke(sender, e);
        }

        private void Lista_AoExcluir(object sender, System.EventArgs e)
        {
            if (lista.SelectedItems.Count == 0)
                return;

            if (MessageBox.Show(this,
                string.Format("Confirma exclusão de {0} produções ? ",
                lista.SelectedItems.Count),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            ProduçãoFiscal.Remover(ObterSeleção());
            Carregar();
        }

        public List<ProduçãoFiscal> ObterSeleção()
        {
            List<ProduçãoFiscal> lstProduções = new List<ProduçãoFiscal>();
            foreach (ListViewItem itemSelecionado in lista.SelectedItems)
                lstProduções.Add(itemSelecionado.Tag as ProduçãoFiscal);
            return lstProduções;
        }

        public void Carregar()
        {
            TrocarItens(CriarItens());
        }

        private ListViewItem[] CriarItens()
        {
            var produções = ProduçãoFiscal.Obter();
            ListViewItem[] itens = new ListViewItem[produções.Count];

            int x = 0;
            foreach (ProduçãoFiscal p in produções)
                itens[x++] = CriarItem(p);

            return itens;
        }

        private void TrocarItens(ListViewItem[] itens)
        {
            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        private ListViewItem CriarItem(ProduçãoFiscal p)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.Tag = p;
            item.SubItems[colCódigo.Index].Text = p.Código.ToString();
            item.SubItems[colData.Index].Text = p.DataFormatada;
            return item;
        }
    }
}
