using Entidades.Fiscal.Cupom;
using Entidades.Fiscal.Importação.Resultado;
using InterpretadorTDM;
using InterpretadorTDM.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorSaídaTDMVarejo : Importador
    {
        public static readonly string DESCRIÇÃO = "Importação de TDM's de varejo";
        public static readonly string PADRÂO_ARQUIVO = "*.tdm";

        private SortedSet<string> idsCadastrados;

        public ImportadorSaídaTDMVarejo(Fechamento fechamento) : base(fechamento)
        {
            idsCadastrados = new SortedSet<string>(SaídaFiscal.ObterIds());
        }

        protected override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);
            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);

            int arquivosProcessados = 0;
            foreach (string arquivo in arquivos)
            {
                thread.ReportProgress(100 * arquivosProcessados++ / arquivos.Count);
                ImportarArquivo(arquivo, resultado);
            }

            return resultado;
        }

        private void ImportarArquivo(string arquivo, ResultadoImportação resultado)
        {
            try
            {
                foreach (CupomFiscal cupom in Interpretador.InterpretaArquivo(arquivo).CuponsFiscais)
                {
                    DocumentoFiscal saída = new AdaptadorVarejo(cupom).Transformar();

                    if (IgnorarArquivo(arquivo, resultado, saída))
                        continue;

                    Cadastrar(arquivo, resultado, saída);
                }
            }
            catch (Exception erro)
            {
                resultado.AdicionarFalha(arquivo, erro);
            }
        }

        private void Cadastrar(string arquivo, ResultadoImportação resultado, DocumentoFiscal saída)
        {
            saída.Cadastrar();
            idsCadastrados.Add(saída.Id);
            resultado.ArquivosSucesso.Adicionar(new Arquivo(arquivo, saída.Id));
        }

        private bool IgnorarArquivo(string arquivo, ResultadoImportação resultado, DocumentoFiscal saída)
        {
            var saídaFiscal = saída as SaídaFiscal;

            if (saída != null && fechamento.Fora(saídaFiscal.DataSaída))
            {
                resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.ForaFechamento, saída.Id));
                return true;
            }

            if (idsCadastrados.Contains(saída.Id.ToLower()))
            {
                resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.ChaveJáImportada, saída.Id));
                return true;
            }

            return false;
        }
    }
}
