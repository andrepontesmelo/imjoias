using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Fiscal.Importação;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class BaseFiscal : BaseInferior
    {
        private Aguarde janelaAguarde;

        public BaseFiscal()
        {
            InitializeComponent();
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

        private void opçãoImportaçãoPDFAtacado_Click(object sender, EventArgs e)
        {
            IniciarImportação(ImportadorPDFAtacado.DESCRIÇÃO, "diretórioInicialPdfAtacado", Thread_ImportarPDFAtacado);
        }

        private void IniciarImportação(string título, string configuraçãoDiretórioInicial, DoWorkEventHandler métodoExecução)
        {
            ConfiguraçãoUsuário<string> diretórioInicial = new ConfiguraçãoUsuário<string>(configuraçãoDiretórioInicial, "");
            string caminho = ObterDiretório(diretórioInicial, string.Format("Selecione a pasta para {0}", título));

            if (caminho == null)
                return;

            diretórioInicial.Valor = caminho;

            IniciarThread(caminho, título, métodoExecução);
        }

        private void opçãoImportaçãoXMLAtacado_Click(object sender, EventArgs e)
        {
            IniciarImportação(ImportadorXMLAtacado.DESCRIÇÃO, "diretórioInicialXmlAtacado", Thread_ImportarXMLAtacado);
        }

        private void IniciarImportação(object dESCRIÇÃO, string v, Action<object, DoWorkEventArgs> thread_ImportarXMLAtacado)
        {
            throw new NotImplementedException();
        }

        private void IniciarThread(string caminho, string título, DoWorkEventHandler métodoExecução)
        {
            MostrarJanelaAguarde(título);
            BackgroundWorker thread = new BackgroundWorker();
            thread.WorkerReportsProgress = true;
            thread.ProgressChanged += Thread_ProgressChanged;
            thread.RunWorkerCompleted += Thread_RunWorkerCompleted;
            thread.DoWork += métodoExecução;
            thread.RunWorkerAsync(caminho);
        }

        private void Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            janelaAguarde.Close();

            ResultadoImportação resultado = (ResultadoImportação)e.Result;
            Process.Start("notepad", resultado.GravarArquivoTxt(Versão.NomeVersãoAplicação));
        }

        private void MostrarJanelaAguarde(string ação)
        {
            janelaAguarde = new Aguarde(ação, 100);
            janelaAguarde.Show(this);
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            janelaAguarde.Passos(e.ProgressPercentage, e.UserState as string);
        }

        private void Thread_ImportarXMLAtacado(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorXMLAtacado().ImportarXmls(e.Argument as string, sender as BackgroundWorker);
        }

        private void Thread_ImportarPDFAtacado(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorPDFAtacado().ImportarPdfs(e.Argument as string, sender as BackgroundWorker);
        }
    }
}
