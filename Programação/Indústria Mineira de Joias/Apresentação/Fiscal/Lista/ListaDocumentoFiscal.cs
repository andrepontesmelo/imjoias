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

        public void Carregar(int? tipoDocumento)
        {
            SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(ConstruirItens(Obter(tipoDocumento)));
            colCancelada.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            colId.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colValor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            ResumeLayout();
        }

        protected virtual List<DocumentoFiscal> Obter(int? tipoDocumento)
        {
            throw new NotImplementedException();
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

            item.SubItems[colCancelada.Index].Text = documentoFiscal.Cancelada ? "Cancelada" : "";
            item.SubItems[colEmissão.Index].Text = string.Format("{0} {1}", documentoFiscal.DataEmissão.ToShortDateString(),
                documentoFiscal.DataEmissão.ToLongTimeString());
            item.SubItems[colId.Index].Text = documentoFiscal.Id;
            item.SubItems[colObservações.Index].Text = documentoFiscal.Observações;
            item.SubItems[colValor.Index].Text = documentoFiscal.ValorTotal.ToString("C",
                Entidades.Configuração.DadosGlobais.Instância.Cultura);
            
            return item;
        }

        private void lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }
    }
}
