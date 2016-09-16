using Entidades.Fiscal.NotaFiscalEletronica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorXMLAtacado : Importador
    {
        public static readonly string PADRÂO_ARQUIVO = "*.xml";

        public ImportadorXMLAtacado()
        {
        }

        public ResultadoImportação ImportarXmls(string pasta, BackgroundWorker thread)
        {
            return ImportarXmls(pasta, SearchOption.AllDirectories, thread);
        }

        public ResultadoImportação ImportarXmls(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação("Importação de XML's fiscais de atacado");

            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);
            
            SortedSet<string> idsCadastrados = new SortedSet<string>(VendaFiscal.ObterIdsCadastrados());

            foreach (string arquivo in arquivos)
            {
                try
                {
                    AtualizarPorcentagem(thread, resultado, arquivos);

                    VendaFiscal venda = new AdaptadorAtacado(new ParserXmlAtacado(arquivo)).Transformar();

                    if (idsCadastrados.Contains(venda.Id))
                    {
                        resultado.ArquivosIgnorados.Add(arquivo);
                        continue;
                    }

                    venda.Cadastrar();
                    idsCadastrados.Add(venda.Id);
                    resultado.ArquivosSucesso.Add(arquivo);
                }
                catch (Exception erro)
                {
                    resultado.ArquivosFalhados.Add(String.Format("{0} - {1}", arquivo, erro.Message));
                }
            }

            return resultado;
        }

        private static void AtualizarPorcentagem(BackgroundWorker thread, ResultadoImportação resultado, List<string> arquivos)
        {
            if (arquivos.Count < 100 || resultado.TotalArquivos % 10 == 0)
                thread.ReportProgress(100 * resultado.TotalArquivos / arquivos.Count);
        }
    }
}
