using Apresentação.Formulários;
using Entidades.Fiscal;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoFiscal : UserControl
    {
        public delegate void CliqueDuploDelegate(DocumentoFiscal documento);
        public event CliqueDuploDelegate CliqueDuplo;

        public ListaDocumentoFiscal()
        {
            InitializeComponent();

            lista.ListViewItemSorter = new ListViewColumnSorter();
        }

        internal IEnumerable<string> ObterCódigosSelecionados()
        {
            var idsSelecionados = from item in lista.SelectedItems.Cast<ListViewItem>()
            where item.Selected
            select item.SubItems[colId.Index].Text;

            return idsSelecionados;
        }

        public DocumentoFiscal Seleção
        {
            get
            {
                if (lista.SelectedItems.Count != 1)
                    return null;

                return lista.SelectedItems[0].Tag as DocumentoFiscal;
            }
        }

        protected virtual void AtualizarTamanhoColunas()
        {
            colId.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colValor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colEntradaSaída.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        protected ListViewItem[] ConstruirItens(List<DocumentoFiscal> documentos)
        {
            ListViewItem[] itens = new ListViewItem[documentos.Count];

            for (int x = 0; x < documentos.Count; x++)
                itens[x] = ConstruirItem(documentos[x]);

            return itens;
        }

        protected virtual ListViewItem ConstruirItem(DocumentoFiscal documentoFiscal)
        {
            ListViewItem item = new ListViewItem(new string[lista.Columns.Count]);

            item.SubItems[colId.Index].Text = documentoFiscal.Id;
            item.SubItems[colEmissão.Index].Text = string.Format("{0} {1}", documentoFiscal.DataEmissão.ToShortDateString(),
                documentoFiscal.DataEmissão.ToLongTimeString());
            item.SubItems[colValor.Index].Text = documentoFiscal.ValorTotal.ToString("C",
                Entidades.Configuração.DadosGlobais.Instância.Cultura);
            item.SubItems[colNúmero.Index].Text = documentoFiscal.Número.ToString();
            item.SubItems[colObservações.Index].Text = documentoFiscal.Observações;

            item.Tag = documentoFiscal;

            return item;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        private void lista_DoubleClick(object sender, System.EventArgs e)
        {
            CliqueDuplo?.Invoke(Seleção);
        }
    }
}
