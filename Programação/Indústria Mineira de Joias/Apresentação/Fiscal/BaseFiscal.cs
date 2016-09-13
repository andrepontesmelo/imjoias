﻿using Apresentação.Formulários;
using Entidades.Fiscal.Importação;
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

        private string ObterDiretório()
        {
            FolderBrowserDialog janela = new FolderBrowserDialog();
            if (janela.ShowDialog() != DialogResult.OK)
                return null;

            return janela.SelectedPath;
        }

        private void opçãoImportaçãoXMLAtacado_Click(object sender, EventArgs e)
        {
            string caminho = ObterDiretório();

            if (caminho != null)
                new ImportadorXMLAtacado().ImportarXmls(caminho);
        }

        private void opçãoImportaçãoPDFAtacado_Click(object sender, EventArgs e)
        {
            string caminho = ObterDiretório();

            string erros = null;

            AguardeDB.Mostrar();

            if (caminho != null)
                erros = new ImportadorPDFAtacado().ImportarPdfs(caminho);

            AguardeDB.Fechar();

            if (!String.IsNullOrEmpty(erros))
                MessageBox.Show(this, erros, "Resultado",  MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
