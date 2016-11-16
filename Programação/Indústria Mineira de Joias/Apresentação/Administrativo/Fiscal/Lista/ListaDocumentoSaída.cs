using Entidades.Fiscal;
using Entidades.Fiscal.Pdf;
using System;
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

            OrganizarColunas();
        }

        private void OrganizarColunas()
        {
            lista.SuspendLayout();

            lista.Columns.Clear();

            lista.Columns.AddRange(new ColumnHeader[] {
            colId,
            colEmissão,
            colEntradaSaída,
            colValor,
            colNúmero,
            colMáquina});

            lista.Columns.Add(colObservações);

            lista.ResumeLayout();
        }

        public uint Setor => setor;

        public void Carregar(int? tipoDocumento, uint setor, DateTime dataInicial, DateTime dataFinal)
        {
            this.setor = setor;

            SuspendLayout();
            lista.Items.Clear();
            lista.Items.AddRange(ConstruirItens(SaídaFiscal.Obter(tipoDocumento, setor, dataInicial, dataFinal)));
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
            var item = base.ConstruirItem(documentoFiscal);
            var saída = (SaídaFiscal) documentoFiscal;
            var dataSaída = saída.DataSaída;

            item.SubItems[colEntradaSaída.Index].Text = string.Format("{0} {1}", dataSaída.ToShortDateString(), dataSaída.ToLongTimeString());
            item.SubItems[colMáquina.Index].Text = saída.Máquina?.ToString();

            return item;
        }
    }
}