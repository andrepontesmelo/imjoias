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
    }
}
