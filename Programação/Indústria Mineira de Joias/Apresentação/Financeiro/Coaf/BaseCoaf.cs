using Apresentação.Formulários;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Coaf
{
    public partial class BaseCoaf : BaseInferior
    {
        public BaseCoaf()
        {
            InitializeComponent();
        }

        private void opçãoConfigurar_Click(object sender, System.EventArgs e)
        {
            new JanelaConfiguração().Show();
        }

        private void opçãoImprimir_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this,
                "Favor cadastrar\n\t* Pessoa de CNPJ 2484.0001.001/1000\n\t* Venda de nota 3212@2 de CPF 076.766.316-02" + 
                "\n\t* Preposto de Dalmo Jóias Ltda",
                "Vínculos Incompletos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private void listaPessoa_DuploClique(object sender, System.EventArgs e)
        {
            int? pessoa = listaPessoa.ObterPessoaSelecionada();

            if (pessoa.HasValue)
                SubstituirBase(new Apresentação.Atendimento.BaseAtendimento(
                    Entidades.Pessoa.Pessoa.ObterPessoa((ulong) pessoa.Value)));
        }

        private void listaSaída_DuploClique(object sender, System.EventArgs e)
        {
            var entidade = listaSaída.ObterSaídaSelecionada();

            if (entidade == null)
                return;

            var baseSaída = new Fiscal.BaseInferior.BaseSaída();
            baseSaída.Carregar(entidade);
            SubstituirBase(baseSaída);
        }
    }
}
