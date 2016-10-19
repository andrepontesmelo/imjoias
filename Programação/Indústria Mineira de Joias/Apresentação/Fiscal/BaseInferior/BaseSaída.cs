namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaída : Apresentação.Fiscal.BaseInferior.BaseDocumento
    {
        public BaseSaída()
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(false);
        }
    }
}
