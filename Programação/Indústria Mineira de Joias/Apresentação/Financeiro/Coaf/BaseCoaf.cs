using Apresentação.Formulários;
using System.ComponentModel;
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

        protected override void AoExibir()
        {
            base.AoExibir();
            listaPessoa.Carregar();
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
            uint? pessoa = listaPessoa.ObterPessoaSelecionada();

            if (pessoa.HasValue)
                SubstituirBase(new Apresentação.Atendimento.BaseAtendimento(
                    Entidades.Pessoa.Pessoa.ObterPessoa(pessoa.Value)));
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

        private void opçãoImportar_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog janela = new OpenFileDialog();
            janela.Title = "Escolha do CSV";
            janela.DefaultExt = "csv";

            if (janela.ShowDialog() != DialogResult.OK)
                return;

            AguardeDB.Mostrar();
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += Bg_DoWork;
            bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
            bg.RunWorkerAsync(janela.FileName);
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            string arquivo = e.Argument as string;
            e.Result = new Entidades.Coaf.ImportadorPep().Importar(arquivo);
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int? qtdPessoasImportadas = e.Result as int?;
            AguardeDB.Fechar();
            MessageBox.Show(string.Format("Fim da importação. {0} CPF's importados", qtdPessoasImportadas));
        }
    }
}
