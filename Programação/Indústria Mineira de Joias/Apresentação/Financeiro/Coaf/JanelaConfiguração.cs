using Apresentação.Formulários;

namespace Apresentação.Financeiro.Coaf
{
    public partial class JanelaConfiguração : JanelaExplicativa
    {
        public JanelaConfiguração()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtMeses_ValueChanged(object sender, System.EventArgs e)
        {
            grupoPeríodo.Text = string.Format("Período: últimos {0} meses", txtMeses.Value);
        }
    }
}
