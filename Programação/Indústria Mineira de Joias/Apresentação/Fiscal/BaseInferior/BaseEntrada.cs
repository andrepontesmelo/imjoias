using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseEntrada : BaseDocumento
    {
        public BaseEntrada()
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(true);
        }

        public override void Carregar(DocumentoFiscal documento)
        {
            base.Carregar(documento);

            dtEntradaSaída.Value = ((EntradaFiscal)documento).DataEntrada;
        }
    }
}
