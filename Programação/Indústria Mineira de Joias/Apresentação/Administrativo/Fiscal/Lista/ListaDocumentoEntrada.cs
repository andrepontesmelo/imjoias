using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoEntrada : ListaDocumentoFiscal
    {
        private ColumnHeader colEmitente;

        public ListaDocumentoEntrada() : base(EntradaFiscalPdf.Cache)
        {
            InitializeComponent();
            colEntradaSaída.Text = "Entrada";

            colEmitente = new ColumnHeader();
            colEmitente.Text = "Emitente";

            lista.Columns.Clear();
            lista.Columns.AddRange(new ColumnHeader[] { 
            colId,
            colEmissão,
            colEmitente,
            colEntradaSaída,
            colSubTotal,
            colDesconto,
            colValorTotal,
            colNúmero,
            colObservações});
        }

        public void Carregar(int? tipoDocumento, DateTime dataInicial, DateTime dataFinal)
        {
            SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(ConstruirItens(EntradaFiscal.Obter(tipoDocumento, dataInicial, dataFinal)));
            AtualizarTamanhoColunas();
            ResumeLayout();
        }

        protected override void AtualizarTamanhoColunas()
        {
            base.AtualizarTamanhoColunas();
            colEmitente.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        protected override ListViewItem ConstruirItem(DocumentoFiscal documentoFiscal)
        {
            ListViewItem item = base.ConstruirItem(documentoFiscal);

            DateTime dataEntrada = ((EntradaFiscal) documentoFiscal).DataEntrada;
            item.SubItems[colEmitente.Index].Text = documentoFiscal.CNPJEmitenteFormatado;
            item.SubItems[colEntradaSaída.Index].Text = string.Format("{0} {1}", dataEntrada.ToShortDateString(), dataEntrada.ToLongTimeString());

            return item;
        }
    }
}
