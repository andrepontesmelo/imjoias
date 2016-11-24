using Apresentação.Formulários;
using Entidades.Fiscal;

namespace Apresentação.Administrativo.Fiscal.Janela
{
    public partial class JanelaImportaçãoEsquema : JanelaExplicativa
    {
        private Fechamento destino;

        public JanelaImportaçãoEsquema()
        {
            InitializeComponent();
        }

        public void Carregar(Fechamento destino)
        {
            this.destino = destino;
            txtFechamentoDestino.Text = destino.ToString();

            cmbFechamentoOrigem.Carregar();
            CorrigirEnabledBotãoOk();
        }

        private void CorrigirEnabledBotãoOk()
        {
            btnOk.Enabled = cmbFechamentoOrigem.Seleção != null;
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void cmbFechamentoOrigem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CorrigirEnabledBotãoOk();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            var origem = cmbFechamentoOrigem.Seleção;

            if (origem == null)
                return;

            destino.CopiarEsquemasDe(origem);

            Close();
        }
    }
}
