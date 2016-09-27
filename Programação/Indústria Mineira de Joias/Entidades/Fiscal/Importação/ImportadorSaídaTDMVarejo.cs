using Entidades.Fiscal.Cupom;
using Entidades.Fiscal.NotaFiscalEletronica;
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
        public static readonly string PADRÂO_ARQUIVO = "*.tdm";
        public static readonly string DESCRIÇÃO = "Importação de TDM's de varejo";

        public ImportadorSaídaTDMVarejo()
        {
        }

        public override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);

            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);
            
            SortedSet<string> idsCadastrados = new SortedSet<string>(SaídaFiscal.ObterIdsCadastrados());

            int arquivosProcessados = 0;
            foreach (string arquivo in arquivos)
            {
                try
                {
                    thread.ReportProgress(100 * arquivosProcessados++ / arquivos.Count);

                    List<CupomFiscal> cupons = Interpretador.InterpretaArquivo(arquivo).CuponsFiscais;
                    foreach (CupomFiscal cupom in cupons)
                    {
                        DocumentoFiscal entrada = new AdaptadorVarejo(cupom).Transformar();

                        if (idsCadastrados.Contains(entrada.Id))
                        {
                            resultado.ArquivosIgnorados.Add(new KeyValuePair<string, Motivo>(ObterDescrição(arquivo, entrada), Motivo.ChaveJáImportada));
                            continue;
                        }

                        entrada.Cadastrar();
                        idsCadastrados.Add(entrada.Id);
                        resultado.ArquivosSucesso.Add(ObterDescrição(arquivo, entrada));
                    }
                }
                catch (Exception erro)
                {
                    resultado.AdicionarFalha(arquivo, erro);
                }
            }

            return resultado;
        }

        private static string ObterDescrição(string arquivo, DocumentoFiscal venda)
        {
            return string.Format("Id {0} @ {1}", venda.Id, arquivo);
        }
    }
}
