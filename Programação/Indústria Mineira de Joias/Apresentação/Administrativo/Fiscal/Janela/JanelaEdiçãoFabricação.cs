using Apresentação.Formulários;
using Entidades.Fiscal.Fabricação;

namespace Apresentação.Administrativo.Fiscal.Janela
{
    public partial class JanelaEdiçãoFabricação : JanelaExplicativa
    {
        FabricaçãoFiscal fabricação;

        public JanelaEdiçãoFabricação()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public void Carregar(FabricaçãoFiscal fabricação)
        {
            this.fabricação = fabricação;
            dateTimePicker.Value = fabricação.Data;

            lblTítulo.Text = string.Format("Edição de fabricação # {0}", fabricação.Código);
            comboFechamento.Carregar();
            CarregarFechamento();
        }

        private void dateTimePicker_ValueChanged(object sender, System.EventArgs e)
        {
            CarregarFechamento();
        }

        private void CarregarFechamento()
        {
            comboFechamento.Seleção = Entidades.Fiscal.Fechamento.Obter(dateTimePicker.Value);
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            fabricação.Data = dateTimePicker.Value;
            fabricação.Atualizar();

            Close();
        }
    }
}
