using Entidades.Fiscal.Importação.Resultado;
using Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System;
using Entidades.Fiscal.NotaFiscalEletronica.Pdf;
using Entidades.Fiscal.Pdf;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorSaídaPDFAtacado : Importador
    {
        public static readonly string DESCRIÇÃO = "Importação de PDF's de atacado";
        public static readonly string PADRÂO_ARQUIVO = "*.pdf";

        public ImportadorSaídaPDFAtacado()
        {
        }

        protected override ResultadoImportação ImportarArquivos(string caminho, SearchOption opções, BackgroundWorker thread)
        {
            MapaIdNfe.Instância.Recarregar();

            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);
            List<string> arquivos = ObterArquivos(caminho, PADRÂO_ARQUIVO, opções);
            List<LeitorPdf> pdfs = LeitorPdf.Interpretar(arquivos, resultado, thread);
            SaidaFiscalPdf.CadastrarLimpandoCache(pdfs, thread);

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
