namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaída : BaseDocumento
    {
        public BaseSaída()
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(false);
        }
    }
}
