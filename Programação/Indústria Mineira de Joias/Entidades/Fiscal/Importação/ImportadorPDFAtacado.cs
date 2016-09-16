using Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf;
using Entidades.Fiscal.NotaFiscalEletronica.Excessões;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorPDFAtacado : Importador
    {
        public static readonly string DESCRIÇÃO = "Importação de PDF's de atacado";

        public ResultadoImportação ImportarPdfs(string caminho, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);

            List<string> arquivos = ObterArquivos(caminho, "*.pdf", System.IO.SearchOption.AllDirectories);
            List<LeitorPdf> pdfs = LeitorPdf.Interpretar(arquivos, resultado, thread);

            NfePdf.CadastrarLimpandoCache(pdfs, thread);

            return resultado;
        }


        private List<LeitorPdf> FiltrarCadastrados(List<LeitorPdf> pdfs, List<long> pdfsCadastrados)
        {
            List<LeitorPdf> lstFiltrada = new List<LeitorPdf>();

            foreach (LeitorPdf pdf in pdfs)
            {
                pdf.AssegurarCódigoExistente();

                if (pdfsCadastrados.Contains(pdf.Nfe.Value))
                    continue;

                lstFiltrada.Add(pdf);
            }

            return lstFiltrada;
        }
    }
}
