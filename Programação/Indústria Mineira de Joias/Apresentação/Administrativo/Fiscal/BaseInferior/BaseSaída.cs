using System.Collections.Generic;
using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaída : BaseDocumento
    {
        public BaseSaída() : base(Entidades.Fiscal.Pdf.SaidaFiscalPdf.Cache)
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(false);
            cmbSetor.Carregar(true);
        }

        private SaídaFiscal Documento => documento as SaídaFiscal;

        public override void Carregar(DocumentoFiscal documento)
        {
            base.Carregar(documento);

            var saída = (SaídaFiscal) documento;

            dtEntradaSaída.Value = saída.DataSaída;
            cmbSetor.Seleção = Entidades.Setor.ObterSetor(saída.Setor);
            chkCancelada.Checked = saída.Cancelada;
        }

        protected override List<string> ObterIds()
        {
            return SaídaFiscal.ObterIds();
        }

        private void chkCancelada_Validated(object sender, System.EventArgs e)
        {
            Documento.Cancelada = chkCancelada.Checked;
            Gravar();
        }

        private void cmbSetor_Validated(object sender, System.EventArgs e)
        {
            Documento.Setor = cmbSetor.Seleção.Código;
            Gravar();
        }

        protected override void Excluir()
        {
            SaídaFiscal.Excluir(new string[] { documento.Id });
        }
    }
}
