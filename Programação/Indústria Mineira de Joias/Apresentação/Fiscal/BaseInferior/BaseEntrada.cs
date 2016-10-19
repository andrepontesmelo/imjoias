namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseEntrada : Apresentação.Fiscal.BaseInferior.BaseDocumento
    {
        public BaseEntrada()
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(true);
        }
    }
}
