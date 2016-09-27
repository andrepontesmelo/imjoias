using Entidades.Fiscal.NotaFiscalEletronica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorSaídaXMLAtacado : Importador
    {
        public static readonly string PADRÂO_ARQUIVO = "*.xml";

        public static readonly string DESCRIÇÃO = "Importação de XMLs de saída de atacado";

        public ImportadorSaídaXMLAtacado()
        {
        }

        public override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);

            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);
            
            SortedSet<string> idsCadastrados = new SortedSet<string>(SaídaFiscal.ObterIdsCadastrados());

            foreach (string arquivo in arquivos)
            {
                try
                {
                    AtualizarPorcentagem(thread, resultado, arquivos);

                    DocumentoFiscal saída = new AdaptadorAtacadoSaída(new ParserXmlAtacado(arquivo)).Transformar();

                    if (idsCadastrados.Contains(saída.Id))
                    {
                        resultado.ArquivosIgnorados.Add(new KeyValuePair<string, Motivo>(arquivo, Motivo.ChaveJáImportada));
                        continue;
                    }

                    if (!saída.EmitidoPorEstaEmpresa)
                    {
                        resultado.ArquivosIgnorados.Add(new KeyValuePair<string, Motivo>(arquivo, Motivo.NotaEmitidaOutraEmpresa));
                        continue;
                    }

                    saída.Cadastrar();
                    idsCadastrados.Add(saída.Id);
                    resultado.ArquivosSucesso.Add(arquivo);
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
