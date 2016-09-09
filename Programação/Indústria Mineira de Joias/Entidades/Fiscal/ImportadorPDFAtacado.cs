using System;
using System.Collections.Generic;


namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ImportadorPDFAtacado : Importador
    {
        public void ImportarPdfs(string caminho)
        {
            List<string> arquivos = ObterArquivos(caminho, "*.pdf", System.IO.SearchOption.AllDirectories);
            List<ExcessãoNãoPodeExtrairNfeNomeArquivo> erros;
            List<Pdf> pdfs = Pdf.Interpretar(arquivos, out erros);

            VerificarCódigoDuplicado(pdfs);

            NfePdf.LimparCache();

            List<Pdf> pdfsFiltrados = FiltrarCadastrados(pdfs, NfePdf.ObterNfes());
            NfePdf.Cadastrar(pdfsFiltrados);
        }

        private List<Pdf> FiltrarCadastrados(List<Pdf> pdfs, List<long> pdfsCadastrados)
        {
            List<Pdf> lstFiltrada = new List<Pdf>();

            foreach (Pdf pdf in pdfs)
            {
                pdf.AssegurarCódigoExistente();

                if (pdfsCadastrados.Contains(pdf.Nfe.Value))
                    continue;

                lstFiltrada.Add(pdf);
            }

            return lstFiltrada;
        }

        private static void VerificarCódigoDuplicado(List<Pdf> pdfs)
        {
            Dictionary<int, Pdf> hash = new Dictionary<int, Pdf>();

            foreach (Pdf pdf in pdfs)
            {
                if (!pdf.Nfe.HasValue)
                    continue;

                if (hash.ContainsKey(pdf.Nfe.Value))
                    throw new ExcessãoCódigoDuplicado(pdf.Nfe.Value);

                hash[pdf.Nfe.Value] = pdf;
            }

            hash.Clear();
        }
    }
}
