namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public partial class BaseEsquemas : Apresentação.Formulários.BaseInferior
    {
        public BaseEsquemas()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            lista.Carregar();
        }
    }
}
