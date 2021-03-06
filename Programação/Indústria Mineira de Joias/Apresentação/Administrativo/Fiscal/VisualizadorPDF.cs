﻿using Entidades.Fiscal.Pdf;
using Entidades.Relacionamento.Venda;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class VisualizadorPDF : Form
    {
        public VisualizadorPDF()
        {
            InitializeComponent();
        }

        public void Carregar(IDadosVenda venda)
        {
            Text = string.Format("Nota fiscal eletrônica da venda {0}", venda.CódigoFormatado);
            SaidaFiscalPdf nfe = SaidaFiscalPdf.Obter(venda.Código);
            Carregar(nfe.Pdf);
        }

        public void Carregar(FiscalPdf pdf)
        {
            Carregar(pdf.Pdf);
        }

        public void Carregar(byte[] pdf)
        {
            string arquivoTemporário = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            System.IO.File.WriteAllBytes(arquivoTemporário, pdf);
            ((AcroPDFLib.IAcroAXDocShim)axAcroPDF.GetOcx()).LoadFile(arquivoTemporário);
            System.IO.File.Delete(arquivoTemporário);
        }
    }
}
