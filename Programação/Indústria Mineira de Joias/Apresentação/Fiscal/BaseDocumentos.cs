using System;

namespace Apresentação.Fiscal
{
    public partial class BaseDocumentos : Apresentação.Formulários.BaseInferior
    {
        public BaseDocumentos()
        {
            InitializeComponent();
        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            cmbTipo.Enabled = chkTipo.Checked;
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            cmbTipo.Carregar();

            base.AoExibirDaPrimeiraVez();
        }
    }
}
