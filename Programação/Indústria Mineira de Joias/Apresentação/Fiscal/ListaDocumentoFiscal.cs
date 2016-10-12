using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public abstract partial class ListaDocumentoFiscal : UserControl
    {
        public ListaDocumentoFiscal()
        {
            InitializeComponent();
        }

        public void Carregar(int? tipoDocumento)
        {
            SuspendLayout();
            lista.Items.AddRange(ConstruirItens(Obter(tipoDocumento)));
            colCancelada.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            colId.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colValor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            ResumeLayout();
        }

        protected abstract List<DocumentoFiscal> Obter(int? tipoDocumento);

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
    }
}
