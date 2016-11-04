using Apresentação.Formulários;
using Entidades.Fiscal;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaEsquemaProdução : UserControl
    {
        public ListaEsquemaProdução()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
        }

        public void Carregar()
        {
            ListViewItem[] itens = CriarItens();

            lista.SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(itens);
            lista.ResumeLayout();
        }

        private ListViewItem[] CriarItens()
        {
            var esquemas = EsquemaProdução.Esquemas;

            ListViewItem[] itens = new ListViewItem[esquemas.Count];
            int x = 0;
            foreach (var esquema in EsquemaProdução.Esquemas)
            {
                ListViewItem item = CriarItem(esquema);
                itens[x++] = item;
            }

            return itens;
        }

        private ListViewItem CriarItem(EsquemaProdução esquema)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);

            item.SubItems[colReferência.Index].Text = esquema.Referência;
            item.SubItems[colDescrição.Index].Text = esquema.Descrição;
            item.SubItems[colQuantidade.Index].Text = esquema.Quantidade.ToString();
            item.SubItems[colTipoUnidadeFiscal.Index].Text = esquema.TipoUnidadeFiscal.Nome;
            return item;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }
    }
}
