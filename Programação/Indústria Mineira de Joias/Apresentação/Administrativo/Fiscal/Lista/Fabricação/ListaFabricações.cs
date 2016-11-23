using Entidades.Fiscal.Fabricação;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaFabricações : UserControl
    {
        public event EventHandler AoDuploClique;

        private DateTime inicio;
        private DateTime fim;

        public ListaFabricações()
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
                string.Format("Confirma exclusão de {0} fabricações ? ",
                lista.SelectedItems.Count),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            FabricaçãoFiscal.Remover(ObterSeleção());
            Carregar();
        }

        public List<FabricaçãoFiscal> ObterSeleção()
        {
            List<FabricaçãoFiscal> lstFabricações = new List<FabricaçãoFiscal>();
            foreach (ListViewItem itemSelecionado in lista.SelectedItems)
                lstFabricações.Add(itemSelecionado.Tag as FabricaçãoFiscal);
            return lstFabricações;
        }

        public void Carregar(DateTime inicio, DateTime fim)
        {
            this.inicio = inicio;
            this.fim = fim;

            Carregar();
        }

        public void Carregar()
        {
            TrocarItens(CriarItens());
        }

        private ListViewItem[] CriarItens()
        {
            var fabricações = FabricaçãoFiscal.Obter(inicio, fim);
            ListViewItem[] itens = new ListViewItem[fabricações.Count];

            int x = 0;
            foreach (FabricaçãoFiscal p in fabricações)
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

        private ListViewItem CriarItem(FabricaçãoFiscal p)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.Tag = p;
            item.SubItems[colCódigo.Index].Text = p.Código.ToString();
            item.SubItems[colData.Index].Text = p.DataFormatada;
            return item;
        }
    }
}
