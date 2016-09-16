using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Fiscal.Importação;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
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

        private void opçãoImportaçãoXMLAtacado_Click(object sender, EventArgs e)
        {
            ConfiguraçãoUsuário<string> diretórioInicial = new ConfiguraçãoUsuário<string>("diretórioInicialXmlAtacado", "");
            string caminho = ObterDiretório(diretórioInicial, "Selecione a pasta para importação de XML's de NF-e de atacado");

            if (caminho == null)
                return;

            diretórioInicial.Valor = caminho;

            MostrarJanelaAguarde("Importação de XML's de atacado");

            BackgroundWorker thread = new BackgroundWorker();
            thread.WorkerReportsProgress = true;
            thread.ProgressChanged += Thread_ProgressChanged;
            thread.RunWorkerCompleted += Thread_RunWorkerCompleted;
            thread.DoWork += Thread_ImportarXMLAtacado;
            thread.RunWorkerAsync(caminho);
        }

        private void Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            janelaAguarde.Close();

            ResultadoImportação resultado = (ResultadoImportação)e.Result;
            Process.Start("notepad", resultado.GravarArquivoTxt());
        }

        private void MostrarJanelaAguarde(string ação)
        {
            janelaAguarde = new Aguarde(ação, 100);
            janelaAguarde.Show(this);
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            janelaAguarde.Passos(e.ProgressPercentage);
        }

        private void Thread_ImportarXMLAtacado(object sender, DoWorkEventArgs e)
        {
            e.Result = new ImportadorXMLAtacado().ImportarXmls(e.Argument as string, sender as BackgroundWorker);
        }

        private void opçãoImportaçãoPDFAtacado_Click(object sender, EventArgs e)
        {
            ConfiguraçãoUsuário<string> diretórioInicial = new ConfiguraçãoUsuário<string>("diretórioInicialPdfAtacado", "");
            string caminho = ObterDiretório(diretórioInicial, "Selecione a pasta para importação de PDF's das notas fiscais de atacado");

            if (caminho == null)
                return;

            diretórioInicial.Valor = caminho;

            string erros = null;

            AguardeDB.Mostrar();
            erros = new ImportadorPDFAtacado().ImportarPdfs(caminho);
            AguardeDB.Fechar();

            if (!String.IsNullOrEmpty(erros))
                MessageBox.Show(this, erros, "Resultado",  MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
