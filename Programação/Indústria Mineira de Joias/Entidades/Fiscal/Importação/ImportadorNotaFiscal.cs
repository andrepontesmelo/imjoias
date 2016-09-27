using Entidades.Fiscal.Importação.Resultado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public abstract class ImportadorNotaFiscal : Importador
    {
        private string descrição;
        private string padrãoArquivo;
        private SortedSet<string> idsCadastrados;

        public ImportadorNotaFiscal(string descrição, string padrãoArquivo)
        {
            this.descrição = descrição;
            this.padrãoArquivo = padrãoArquivo;

            idsCadastrados = new SortedSet<string>(ObterIdsCadastrados());
        }

        protected abstract List<string> ObterIdsCadastrados();
        protected abstract DocumentoFiscal Interpretar(string arquivo);
        protected abstract bool IgnorarDocumentoCNPJEmissor(ResultadoImportação resultado, string arquivo, DocumentoFiscal documento);

        protected override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(descrição);
            List<string> arquivos = ObterArquivos(pasta, padrãoArquivo, opções);

            foreach (string arquivo in arquivos)
            {
                AtualizarPorcentagem(thread, resultado, arquivos);
                ImportarArquivo(arquivo, resultado);
            }

            return resultado;
        }

        private void ImportarArquivo(string arquivo, ResultadoImportação resultado)
        {
            try
            {
                DocumentoFiscal documento = Interpretar(arquivo);

                if (IgnorarDocumento(resultado, arquivo, documento))
                    return;

                CadastrarDocumento(documento, resultado, arquivo);
            }
            catch (Exception erro)
            {
                resultado.AdicionarFalha(arquivo, erro);
            }
        }

        private void CadastrarDocumento(DocumentoFiscal documento, ResultadoImportação resultado, string arquivo)
        {
            documento.Cadastrar();
            idsCadastrados.Add(documento.Id);
            resultado.ArquivosSucesso.Adicionar(new Arquivo(arquivo, documento.Id));
        }

        private bool IgnorarDocumento(ResultadoImportação resultado, string arquivo, DocumentoFiscal documento)
        {
            if (idsCadastrados.Contains(documento.Id))
            {
                resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.ChaveJáImportada, documento.Id));
                return true;
            }

            if (IgnorarDocumentoCNPJEmissor(resultado, arquivo, documento))
                return true;

            return false;
        }
    }
}
