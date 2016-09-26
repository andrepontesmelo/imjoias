using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Fiscal.Importação;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class BaseFiscal : BaseInferior
    {
        private Dictionary<BackgroundWorker, Aguarde> hashAguarde = new Dictionary<BackgroundWorker, Aguarde>();

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
            IniciarImportação(ImportadorSaídaPDFAtacado.DESCRIÇÃO, "diretórioInicialPdfAtacadoSaída", Thread_ImportarPDFAtacadoSaída);
        }

        private void IniciarImportação(string título, string configuraçãoDiretórioInicial, DoWorkEventHandler métodoExecução)
        {
            ConfiguraçãoUsuário<string> diretórioInicial = new ConfiguraçãoUsuário<string>(configuraçãoDiretórioInicial, "");
            string caminho = ObterDiretório(diretórioInicial, string.Format("Selecione a pasta para {0}", título));

            if (caminho == null)
                return;

            diretórioInicial.Valor = caminho;

            IniciarThreadJanelaAguarde(caminho, título, métodoExecução);
        }

        private void opçãoImportaçãoXMLAtacado_Click(object sender, EventArgs e)
        {
            IniciarImportação(ImportadorSaídaXMLAtacado.DESCRIÇÃO, "diretórioInicialXmlAtacadoSaída", Thread_ImportarXMLAtacadoSaída);
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
            ObterJanelaAguarde((BackgroundWorker) sender).Close();

            ResultadoImportação resultado = (ResultadoImportação)e.Result;
            Process.Start("notepad", resultado.GravarArquivoTxt(Versão.NomeVersãoAplicação));
        }

        private Aguarde ObterJanelaAguarde(BackgroundWorker thread)
        {
            return hashAguarde[thread];
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Aguarde aguarde = ObterJanelaAguarde((BackgroundWorker) sender);
            aguarde.Passos(e.ProgressPercentage, e.UserState as string);
        }

        private void Thread_ImportarXMLAtacadoSaída(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorSaídaXMLAtacado().ImportarArquivos(e.Argument as string, sender as BackgroundWorker);
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

        private void opçãoImportaçãoTDMVarejoSaída_Click(object sender, EventArgs e)
        {
            IniciarImportação(ImportadorSaídaTDMVarejo.DESCRIÇÃO, "diretórioInicialTDMVarejoSaída", Thread_ImportarTDMVarejoSaída);
        }

        private void opçãoImportaçãoXMLAtacadoEntrada_Click(object sender, EventArgs e)
        {
            IniciarImportação(ImportadorEntradaXMLAtacado.DESCRIÇÃO, "diretórioInicialXmlAtacadoEntrada", Thread_ImportarXMLAtacadoEntrada);
        }
    }
}
