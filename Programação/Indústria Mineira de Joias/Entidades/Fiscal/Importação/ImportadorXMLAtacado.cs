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

        public static readonly string DESCRIÇÃO = "Importação de XML's de atacado";

        public ImportadorXMLAtacado()
        {
        }

        public override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);

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
                    resultado.AdicionarFalha(arquivo, erro);
                }
            }

            return resultado;
        }
    }
}
