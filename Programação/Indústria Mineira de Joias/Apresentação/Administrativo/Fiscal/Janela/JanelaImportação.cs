using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Fiscal.Importação;
using Entidades.Fiscal.Importação.Resultado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Janela
{
    public partial class JanelaImportação : JanelaExplicativa
    {
        private const string MENSAGEM_ESCOLHA_DIRETÓRIO = "Escolha o diretório para a importação em lote.";

        private Dictionary<BackgroundWorker, Aguarde> hashAguarde = new Dictionary<BackgroundWorker, Aguarde>();
        ConfiguraçãoUsuário<string> diretórioInicial = new ConfiguraçãoUsuário<string>("diretórioInicialImportação", "");
        ConfiguraçãoUsuário<bool> importarXMLAtacadoEntrada = new ConfiguraçãoUsuário<bool>("importarXMLAtacadoEntrada", true);
        ConfiguraçãoUsuário<bool> importarXMLAtacadoSaída = new ConfiguraçãoUsuário<bool>("importarXMLAtacadoSaída", true);
        ConfiguraçãoUsuário<bool> importarTDMVarejoSaída = new ConfiguraçãoUsuário<bool>("importarTDMVarejoSaída", true);
        ConfiguraçãoUsuário<bool> importarPDFAtacadoSaída = new ConfiguraçãoUsuário<bool>("importarPDFAtacadoSaída", true);

        public JanelaImportação()
        {
            InitializeComponent();

            CarregarOpções();
        }

        private void CarregarOpções()
        {
            chkEntradaXMLAtacado.Checked = importarXMLAtacadoEntrada.Valor;
            chkSaídaXMLAtacado.Checked = importarXMLAtacadoSaída.Valor;
            chkSaídaTDMVarejo.Checked = importarTDMVarejoSaída.Valor;
            chkSaídaPDFAtacado.Checked = importarPDFAtacadoSaída.Valor;

            txtDiretório.Text = diretórioInicial.Valor;
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnIniciar_Click(object sender, System.EventArgs e)
        {
            PersistirOpções();
            Importar();
            Hide();
        }

        private void Importar()
        {
            if (chkSaídaXMLAtacado.Checked)
                IniciarImportação(ImportadorSaídaXMLAtacado.DESCRIÇÃO, Thread_ImportarXMLAtacadoSaída);

            if (chkSaídaPDFAtacado.Checked)
                IniciarImportação(ImportadorSaídaPDFAtacado.DESCRIÇÃO, Thread_ImportarPDFAtacadoSaída);

            if (chkSaídaTDMVarejo.Checked)
                IniciarImportação(ImportadorSaídaTDMVarejo.DESCRIÇÃO, Thread_ImportarTDMVarejoSaída);

            if (chkEntradaXMLAtacado.Checked)
                IniciarImportação(ImportadorEntradaXMLAtacado.DESCRIÇÃO, Thread_ImportarXMLAtacadoEntrada);
        }

        private void PersistirOpções()
        {
            importarXMLAtacadoEntrada.Valor = chkEntradaXMLAtacado.Checked;
            importarXMLAtacadoSaída.Valor = chkSaídaXMLAtacado.Checked;
            importarTDMVarejoSaída.Valor = chkSaídaTDMVarejo.Checked;
            importarPDFAtacadoSaída.Valor = chkSaídaPDFAtacado.Checked;
        }


        private string ObterDiretório(string diretórioInicial, string mensagem)
        {
            FolderBrowserDialog janela = new FolderBrowserDialog();

            if (!String.IsNullOrEmpty(diretórioInicial))
                janela.SelectedPath = diretórioInicial;

            janela.Description = mensagem;

            if (janela.ShowDialog() != DialogResult.OK)
                return null;

            return janela.SelectedPath;
        }

        private void IniciarImportação(string título, DoWorkEventHandler métodoExecução)
        {
            IniciarThreadJanelaAguarde(txtDiretório.Text, título, métodoExecução);
        }

        private void IniciarThreadJanelaAguarde(string caminho, string ação, DoWorkEventHandler métodoExecução)
        {
            Aguarde aguarde = CriarJanelaAguarde(ação);

            BackgroundWorker thread = new BackgroundWorker();
            thread.WorkerReportsProgress = true;
            thread.ProgressChanged += Thread_ProgressChanged;
            thread.RunWorkerCompleted += Thread_RunWorkerCompleted;
            thread.DoWork += métodoExecução;
            thread.RunWorkerAsync(caminho);

            hashAguarde[thread] = aguarde;
        }

        private Aguarde CriarJanelaAguarde(string ação)
        {
            Aguarde janelaAguarde = new Aguarde(ação, 100);
            janelaAguarde.TopMost = false;
            janelaAguarde.Show(this);
            return janelaAguarde;
        }

        private void Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ObterJanelaAguarde((BackgroundWorker)sender).Close();

            if (e.Error != null)
            {
                MessageBox.Show("Verifique se possui permissão de leitura na pasta.\n\n" + 
                    e.Error.Message, "Erro na importação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ResultadoImportação resultado = (ResultadoImportação)e.Result;
            Process.Start("notepad", resultado.GravarArquivoTxt(Versão.Descrição));
        }

        private Aguarde ObterJanelaAguarde(BackgroundWorker thread)
        {
            return hashAguarde[thread];
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Aguarde aguarde = ObterJanelaAguarde((BackgroundWorker)sender);
            aguarde.Passos(e.ProgressPercentage, e.UserState as string);
        }

        private void Thread_ImportarXMLAtacadoSaída(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorSaídaXMLAtacado().ImportarArquivos(e.Argument as string, sender as BackgroundWorker);
        }

        private void Thread_ImportarCancelamentosAtacado(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorCancelamentosAtacado().ImportarArquivos(e.Argument as string, sender as BackgroundWorker);
        }

        private void Thread_ImportarXMLAtacadoEntrada(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorEntradaXMLAtacado().ImportarArquivos(e.Argument as string, sender as BackgroundWorker);
        }

        private void Thread_ImportarTDMVarejoSaída(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorSaídaTDMVarejo().ImportarArquivos(e.Argument as string, sender as BackgroundWorker);
        }

        private void Thread_ImportarPDFAtacadoSaída(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorSaídaPDFAtacado().ImportarArquivos(e.Argument as string, sender as BackgroundWorker);
        }

        private void btnPasta_Click(object sender, EventArgs e)
        {
            string diretório = ObterDiretório(diretórioInicial.Valor, MENSAGEM_ESCOLHA_DIRETÓRIO);

            if (diretório == null)
                return;

            txtDiretório.Text = diretório;
            diretórioInicial.Valor = diretório;
        }

        private void txtDiretório_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !DiretórioVazio && !DiretórioVálido;
        }

        private bool DiretórioVálido => Directory.Exists(txtDiretório.Text);
        private bool DiretórioVazio => String.IsNullOrWhiteSpace(txtDiretório.Text);

        public bool AlgumaOpçãoSelecionada
        {
            get
            {
                return chkEntradaXMLAtacado.Checked ||
                    chkSaídaPDFAtacado.Checked ||
                    chkSaídaTDMVarejo.Checked ||
                    chkSaídaXMLAtacado.Checked;
            }
        }

        private void controlesOpções_Validação(object sender, EventArgs e)
        {
            AtualizarBotãoIniciar();
        }

        private void AtualizarBotãoIniciar()
        {
            btnIniciar.Enabled = DiretórioVálido && AlgumaOpçãoSelecionada;
        }

        private void txtDiretório_TextChanged(object sender, EventArgs e)
        {
            AtualizarBotãoIniciar();
        }
    }
}
