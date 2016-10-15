using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoEntrada : ListaDocumentoFiscal
    {
        public ListaDocumentoEntrada()
        {
            InitializeComponent();
            colEntradaSaída.Text = "Entrada";
        }

        protected override List<DocumentoFiscal> Obter(int? tipoDocumento)
        {
            return EntradaFiscal.Obter(tipoDocumento);
        }

        protected override ListViewItem ConstruirItem(DocumentoFiscal documentoFiscal)
        {
            ListViewItem item = base.ConstruirItem(documentoFiscal);

            DateTime dataEntrada = ((EntradaFiscal) documentoFiscal).DataEntrada;

            item.SubItems[colEntradaSaída.Index].Text = string.Format("{0} {1}", dataEntrada.ToShortDateString(), dataEntrada.ToLongTimeString());

            return item;
        }
    }
}
