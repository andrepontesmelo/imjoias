using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Fiscal.Importação;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class BaseFiscal : BaseInferior
    {
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
            new ImportadorXMLAtacado().ImportarXmls(caminho);
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
