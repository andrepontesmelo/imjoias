using System.Collections.Generic;
using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaída : BaseDocumento
    {
        public BaseSaída()
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(false);
        }

        public override void Carregar(DocumentoFiscal documento)
        {
            base.Carregar(documento);

            dtEntradaSaída.Value = ((SaídaFiscal) documento).DataSaída;
        }

        protected override List<string> ObterIds()
        {
            return SaídaFiscal.ObterIds();
        }
    }
}
