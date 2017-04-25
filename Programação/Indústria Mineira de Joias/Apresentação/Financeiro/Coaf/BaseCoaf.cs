using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Coaf.Sumário;
using Entidades.Coaf;
using System;
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
            new JanelaConfiguração().ShowDialog(this);
            Recarregar();
        }

        private void MostrarDescrição()
        {
            título.Descrição = string.Format("Operações de saídas fiscais acumuladas de {0} até {1}.\n" +
                "PEP: Pessoa exposta políticamente.",
                ConfiguraçõesCoaf.Instância.DataInício.Valor.ToShortDateString(),
                ConfiguraçõesCoaf.Instância.DataFim.Valor.ToShortDateString());
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();
        }

        private void Recarregar()
        {
            listaPessoa.Carregar();
            MostrarDescrição();
            listaSaída.Limpar();
        }

        private void opçãoImprimir_Click(object sender, System.EventArgs e)
        {
            JanelaImpressão janelaImpressão = new Formulários.JanelaImpressão();
            janelaImpressão.InserirDocumento(
                new ControladorImpressãoSumárioCoaf().CriarRelatório(), "Sumário");
            janelaImpressão.Abrir(this);
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
            janela.Title = "Escolha do CSV de pessoas politicamente expostas fornecido pela COAF";
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
            try
            {
                e.Result = new Entidades.Coaf.ImportadorPep().Importar(arquivo);
            } catch (Exception erro)
            {
                AguardeDB.Fechar();
                MessageBox.Show(erro.Message,
                "Erro ao importar arquivo de pessoas politicamente expostas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int? qtdPessoasImportadas = e.Result as int?;
            AguardeDB.Fechar();

            if (qtdPessoasImportadas.HasValue)
            {
                MessageBox.Show(string.Format("Fim da importação. {0} CPF's importados", qtdPessoasImportadas));
            } 
        }

        private void listaPessoa_SeleçãoAlterada(object sender, System.EventArgs e)
        {
            string pessoa = listaPessoa.ObterCpfCnpjPessoaSelecionada();
            var configuração = ConfiguraçõesCoaf.Instância;

            if (pessoa != null)
                listaSaída.Carregar(pessoa, configuração.DataInício.Valor, configuração.DataFim.Valor);
        }
    }
}
