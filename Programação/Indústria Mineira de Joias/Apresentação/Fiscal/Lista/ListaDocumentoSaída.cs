using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoSaída : ListaDocumentoFiscal
    {
        public ListaDocumentoSaída()
        {
            InitializeComponent();
            colEntradaSaída.Text = "Saída";
        }

        public void Carregar(int? tipoDocumento, int setor)
        {
            SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(ConstruirItens(SaídaFiscal.Obter(tipoDocumento, setor)));
            AtualizarTamanhoColunas();
            ResumeLayout();
        }

        protected override void AtualizarTamanhoColunas()
        {
            base.AtualizarTamanhoColunas();
            colEntradaSaída.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        protected override ListViewItem ConstruirItem(DocumentoFiscal documentoFiscal)
        {
            ListViewItem item = base.ConstruirItem(documentoFiscal);
            DateTime dataSaída = ((SaídaFiscal)documentoFiscal).DataSaída;
            item.SubItems[colEntradaSaída.Index].Text = string.Format("{0} {1}", dataSaída.ToShortDateString(), dataSaída.ToLongTimeString());
            item.SubItems[colCancelada.Index].Text = documentoFiscal.Cancelada ? "Cancelada" : "";

            return item;
        }
    }
}