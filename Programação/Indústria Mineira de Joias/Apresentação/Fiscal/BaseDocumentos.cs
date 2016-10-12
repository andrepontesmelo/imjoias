using System;

namespace Apresentação.Fiscal
{
    public partial class BaseDocumentos : Formulários.BaseInferior
    {
        public BaseDocumentos()
        {
            InitializeComponent();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            quadroTipo.Carregar();

            base.AoExibirDaPrimeiraVez();
        }
    }
}
