namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseEntradas : BaseDocumentos
    {
        public BaseEntradas()
        {
            InitializeComponent();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            CarregarLista();
        }

        private void quadroTipo_SeleçãoAlterada(object sender, System.EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            lista.Carregar(quadroTipo.Seleção?.Id);
        }
    }
}
