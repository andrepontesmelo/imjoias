using Apresentação.Formulários;
using Entidades.Fiscal.Fabricação;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Janela
{
    public partial class JanelaEdiçãoFabricação : JanelaExplicativa
    {
        FabricaçãoFiscal fabricação;

        public JanelaEdiçãoFabricação()
        {
            InitializeComponent();
        }

        public JanelaEdiçãoFabricação(FabricaçãoFiscal fabricação) : this()
        {
            this.fabricação = fabricação;
        }

        public DialogResult Mostrar(IWin32Window dono)
        {
            Carregar(fabricação);
            ShowDialog(dono);

            return DialogResult;
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            AtribuirResultado(DialogResult.Cancel);
        }

        public void Carregar(FabricaçãoFiscal fabricação)
        {
            this.fabricação = fabricação;
            dateTimePicker.Value = fabricação.Data;

            lblTítulo.Text = string.Format("Fabricação # {0}", fabricação.Código);
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
            AtribuirResultado(DialogResult.OK);
        }

        private void AtribuirResultado(DialogResult resultado)
        {
            this.DialogResult = resultado;
        }
    }
}
