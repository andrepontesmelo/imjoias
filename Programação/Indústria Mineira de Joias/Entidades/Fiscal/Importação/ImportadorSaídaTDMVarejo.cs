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
                        DocumentoFiscal saída = new AdaptadorVarejo(cupom).Transformar();

                        if (idsCadastrados.Contains(saída.Id))
                        {
                            resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.ChaveJáImportada, saída.Id));
                            continue;
                        }

                        saída.Cadastrar();
                        idsCadastrados.Add(saída.Id);

                        resultado.ArquivosSucesso.Adicionar(new Arquivo(arquivo, saída.Id));
                    }
                }
                catch (Exception erro)
                {
                    resultado.AdicionarFalha(arquivo, erro);
                }
            }

            return resultado;
        }
    }
}
