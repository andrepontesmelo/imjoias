namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseEntrada : BaseDocumento
    {
        public BaseEntrada()
        {
            InitializeComponent();

            cmbTipoDocumento.Carregar(true);
        }
    }
}
