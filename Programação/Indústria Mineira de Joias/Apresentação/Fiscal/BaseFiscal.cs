using Entidades.Fiscal;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class BaseFiscal : Formulários.BaseInferior
    {
        public BaseFiscal()
        {
            InitializeComponent();
        }

        private void opçãoImportaçãoXMLAtacado_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog janela = new FolderBrowserDialog();
            if (janela.ShowDialog() != DialogResult.OK)
                return;

            new ImportadorXMLAtacado().ImportarXmls(janela.SelectedPath);
        }
    }
}
