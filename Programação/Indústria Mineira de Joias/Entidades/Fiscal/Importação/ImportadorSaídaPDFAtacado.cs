using Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorSaídaPDFAtacado : Importador
    {
        public static readonly string DESCRIÇÃO = "Importação de PDF's de atacado";

        public override ResultadoImportação ImportarArquivos(string caminho, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);

            List<string> arquivos = ObterArquivos(caminho, "*.pdf", opções);
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
