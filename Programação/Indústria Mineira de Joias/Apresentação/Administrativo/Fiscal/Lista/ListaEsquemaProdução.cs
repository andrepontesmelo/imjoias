using Apresentação.Formulários;
using Entidades.Fiscal;
using Entidades.Fiscal.Esquema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaEsquemafabricação : UserControl
    {
        public event EventHandler AoExcluir;
        public event EventHandler AoDuploClique;

        public ListaEsquemafabricação()
        {
            InitializeComponent();

            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.AoExcluir += Lista_AoExcluir;
            lista.DoubleClick += Lista_DoubleClick;
        }

        private void Lista_DoubleClick(object sender, EventArgs e)
        {
            AoDuploClique?.Invoke(sender, e);
        }

        private void Lista_AoExcluir(object sender, EventArgs e)
        {
            AoExcluir?.Invoke(sender, e);
        }

        public void Carregar(Fechamento fechamento)
        {
            ListViewItem[] itens = CriarItens(fechamento);

            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        private ListViewItem[] CriarItens(Fechamento fechamento)
        {
            var esquemas = EsquemaFabricação.Obter(fechamento);

            ListViewItem[] itens = new ListViewItem[esquemas.Count];
            int x = 0;
            foreach (var esquema in esquemas)
            {
                ListViewItem item = CriarItem(esquema);
                itens[x++] = item;
            }

            return itens;
        }

        private ListViewItem CriarItem(EsquemaFabricação esquema)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);

            item.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(esquema.Referência, true);
            item.SubItems[colDescrição.Index].Text = esquema.Descrição;
            item.SubItems[colQuantidade.Index].Text = esquema.Quantidade.ToString();
            item.SubItems[colTipoUnidadeFiscal.Index].Text = esquema.TipoUnidadeFiscal.Nome;
            item.Tag = esquema;

            return item;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        public List<EsquemaFabricação> Seleção
        {
            get
            {
                var seleção = lista.SelectedItems;
                if (seleção.Count == 0)
                    return null;

                List<EsquemaFabricação> resultado = new List<EsquemaFabricação>();
                foreach (ListViewItem item in seleção)
                    resultado.Add(item.Tag as EsquemaFabricação);

                return resultado;
            }
        }
    }
}
