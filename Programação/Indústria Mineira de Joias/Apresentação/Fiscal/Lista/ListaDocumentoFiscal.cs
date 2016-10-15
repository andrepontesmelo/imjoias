using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apresentação.Formulários;


namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoFiscal : UserControl
    {
        public ListaDocumentoFiscal()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
        }

        protected virtual void AtualizarTamanhoColunas()
        {
            colId.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colValor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colEntradaSaída.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private ListViewItem[] ConstruirItens(List<DocumentoFiscal> documentos)
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

            return item;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }
    }
}
