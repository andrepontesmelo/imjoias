using Entidades.Fiscal.Esquema;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaIngredienteEsquema : UserControl
    {
        public ListaIngredienteEsquema()
        {
            InitializeComponent();
        }

        internal void Carregar(EsquemaProdução esquema)
        {
            List<ListViewItem> itens = CriarItens(esquema);

            lista.Items.Clear();
            lista.Items.AddRange(itens.ToArray());
        }

        private List<ListViewItem> CriarItens(EsquemaProdução esquema)
        {
            List<ListViewItem> itens = new List<ListViewItem>();
            var ingredientes = Ingrediente.Obter(esquema.Referência);

            foreach (Ingrediente i in ingredientes)
                itens.Add(CriarItem(i));

            return itens;
        }

        private ListViewItem CriarItem(Ingrediente i)
        {
            ListViewItem item = new ListViewItem(new string[lista.Columns.Count]);
            item.SubItems[colReferência.Index].Text = Entidades.Mercadoria.Mercadoria.MascararReferência(i.Referência);
            item.SubItems[colTipoUnidade.Index].Text = i.TipoUnidadeComercial.Nome;
            item.SubItems[colQuantidade.Index].Text = i.Quantidade.ToString();
            item.SubItems[colDescrição.Index].Text = i.Descrição;

            return item;
        }
    }
}
