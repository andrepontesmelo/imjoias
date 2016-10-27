using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoSaída : ListaDocumentoFiscal
    {
        private uint setor;

        public ListaDocumentoSaída() : base(SaidaFiscalPdf.Cache)
        {
            InitializeComponent();
            colEntradaSaída.Text = "Saída";
        }

        public uint Setor => setor;

        public void Carregar(int? tipoDocumento, uint setor)
        {
            this.setor = setor;

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

            return item;
        }
    }
}