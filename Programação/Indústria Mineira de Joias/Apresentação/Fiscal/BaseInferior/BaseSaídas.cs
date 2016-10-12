using System;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaídas : BaseDocumentos
    {
        public BaseSaídas()
        {
            InitializeComponent();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            CarregarListas();
        }

        private void CarregarListas()
        {
        }

        private void quadroTipo_SeleçãoAlterada(object sender, EventArgs e)
        {
            CarregarListas();
        }
    }
}
