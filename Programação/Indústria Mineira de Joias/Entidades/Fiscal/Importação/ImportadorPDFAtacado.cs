using Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf;
using Entidades.Fiscal.NotaFiscalEletronica.Excessões;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorPDFAtacado : Importador
    {
        public string ImportarPdfs(string caminho)
        {
            List<string> arquivos = ObterArquivos(caminho, "*.pdf", System.IO.SearchOption.AllDirectories);
            List<ExcessãoNãoPodeExtrairNfeNomeArquivo> erros;
            List<LeitorPdf> pdfs = LeitorPdf.Interpretar(arquivos, out erros);

            VerificarCódigoDuplicado(pdfs);

            NfePdf.LimparCache();

            List<LeitorPdf> pdfsFiltrados = FiltrarCadastrados(pdfs, NfePdf.ObterNfes());
            NfePdf.Cadastrar(pdfsFiltrados);

            CacheVendaPdf.Instância.Recarregar();

            return ObterErros(erros);
        }

        private string ObterErros(List<ExcessãoNãoPodeExtrairNfeNomeArquivo> erros)
        {
            StringBuilder saida = new StringBuilder();
            foreach (ExcessãoNãoPodeExtrairNfeNomeArquivo erro in erros)
                saida.AppendLine(erro.Message);

            return saida.ToString();
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

        private static void VerificarCódigoDuplicado(List<LeitorPdf> pdfs)
        {
            Dictionary<int, LeitorPdf> hash = new Dictionary<int, LeitorPdf>();

            foreach (LeitorPdf pdf in pdfs)
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
