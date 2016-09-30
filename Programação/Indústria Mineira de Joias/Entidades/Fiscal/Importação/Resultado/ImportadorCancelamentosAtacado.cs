using Entidades.Fiscal.Excessões;
using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ImportadorCancelamentosAtacado : Importador
    {
        public static readonly string DESCRIÇÃO = "Importação de cancelamentos de saída de atacado";
        public static readonly string PADRÂO_ARQUIVO = "*.xml";

        SortedSet<string> idsJáCancelados;
        SortedSet<string> idsSaídas;

        public ImportadorCancelamentosAtacado()
        {
            idsJáCancelados = new SortedSet<string>(SaídaFiscal.ObterIds(TipoSaída.NFe, true));
            idsSaídas = new SortedSet<string>(SaídaFiscal.ObterIds(TipoSaída.NFe, null));
        }

        protected override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);
            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);

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
                ParserXmlAtacadoCancelamento parser = new ParserXmlAtacadoCancelamento(arquivo);

                if (!parser.Cancelamento)
                {
                    resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.NãoÉCancelamento));
                    return;
                }

                string id = SaídaFiscal.ObterIdNfe(parser.Id);

                if (idsJáCancelados.Contains(id))
                {
                    resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.CancelamentoJáRegistrado, id));
                    return;
                }

                if (!idsSaídas.Contains(id))
                { 
                    throw new TentativaCancelamentoNotaInexistente(id);
                }

                SaídaFiscal.Cancelar(id);
                resultado.ArquivosSucesso.Adicionar(new Arquivo(arquivo, id));
                idsJáCancelados.Add(id);
            }
            catch (Exception erro)
            {
                resultado.AdicionarFalha(arquivo, erro);
            }
        }
    }
}
