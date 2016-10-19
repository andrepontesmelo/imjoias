using Entidades.Fiscal.Tipo;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{

    public partial class QuadroTipo : UserControl
    {
        public event EventHandler SeleçãoAlterada;

        private TipoDocumento últimaSeleção = null;
       
        public QuadroTipo()
        {
            InitializeComponent();
            cmbTipo.SelectedIndexChanged += CmbTipo_SelectedIndexChanged;
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotificarAlteraçãoSeleçãoSeNecessário();
        }

        private void NotificarAlteraçãoSeleçãoSeNecessário()
        {
            if (Seleção == últimaSeleção)
                return;

            últimaSeleção = Seleção;
            SeleçãoAlterada?.Invoke(cmbTipo, EventArgs.Empty);
        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            cmbTipo.Enabled = chkTipo.Checked;
            if (!chkTipo.Checked)
                cmbTipo.SelectedItem = null;

            NotificarAlteraçãoSeleçãoSeNecessário();
        }

        public void Carregar(bool entrada)
        {
            cmbTipo.Carregar(entrada);
        }

        public TipoDocumento Seleção => cmbTipo.SelectedItem as TipoDocumento;
    }
}
