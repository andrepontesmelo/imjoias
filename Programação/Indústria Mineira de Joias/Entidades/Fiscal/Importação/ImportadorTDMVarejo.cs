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
    public class ImportadorTDMVarejo : Importador
    {
        public static readonly string PADRÂO_ARQUIVO = "*.tdm";
        public static readonly string DESCRIÇÃO = "Importação de TDM's de varejo";

        public ImportadorTDMVarejo()
        {
        }

        public override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);

            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);
            
            SortedSet<string> idsCadastrados = new SortedSet<string>(VendaFiscal.ObterIdsCadastrados());

            int arquivosProcessados = 0;
            foreach (string arquivo in arquivos)
            {
                try
                {
                    thread.ReportProgress(100 * arquivosProcessados++ / arquivos.Count);

                    List<CupomFiscal> cupons = Interpretador.InterpretaArquivo(arquivo).CuponsFiscais;
                    foreach (CupomFiscal cupom in cupons)
                    {
                        VendaFiscal venda = new AdaptadorVarejo(cupom).Transformar();

                        if (idsCadastrados.Contains(venda.Id))
                        {
                            resultado.ArquivosIgnorados.Add(ObterDescrição(arquivo, venda));
                            continue;
                        }

                        venda.Cadastrar();
                        idsCadastrados.Add(venda.Id);
                        resultado.ArquivosSucesso.Add(ObterDescrição(arquivo, venda));
                    }
                }
                catch (Exception erro)
                {
                    resultado.AdicionarFalha(arquivo, erro);
                }
            }

            return resultado;
        }

        private static string ObterDescrição(string arquivo, VendaFiscal venda)
        {
            return string.Format("Id {0} @ {1}", venda.Id, arquivo);
        }
    }
}
