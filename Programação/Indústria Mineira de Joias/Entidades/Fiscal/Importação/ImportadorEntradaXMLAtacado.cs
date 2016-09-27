using Entidades.Fiscal.Importação.Resultado;
using Entidades.Fiscal.NotaFiscalEletronica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorEntradaXMLAtacado : Importador
    {
        public static readonly string PADRÂO_ARQUIVO = "*.xml";

        public static readonly string DESCRIÇÃO = "Importação de XMLs de entrada de atacado";

        public ImportadorEntradaXMLAtacado()
        {
        }

        public override ResultadoImportação ImportarArquivos(string pasta, SearchOption opções, BackgroundWorker thread)
        {
            ResultadoImportação resultado = new ResultadoImportação(DESCRIÇÃO);
            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);
            SortedSet<string> idsCadastrados = new SortedSet<string>(EntradaFiscal.ObterIdsCadastrados());

            foreach (string arquivo in arquivos)
            {
                try
                {
                    AtualizarPorcentagem(thread, resultado, arquivos);

                    DocumentoFiscal venda = new AdaptadorAtacadoEntrada(new ParserXmlAtacado(arquivo)).Transformar();

                    if (idsCadastrados.Contains(venda.Id))
                    {
                        resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.ChaveJáImportada, venda.Id));
                        continue;
                    }

                    if (venda.EmitidoPorEstaEmpresa)
                    {
                        resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.NotaEmitidaOutraEmpresa, venda.Id));
                        continue;
                    }

                    venda.Cadastrar();
                    idsCadastrados.Add(venda.Id);
                    resultado.ArquivosSucesso.Adicionar(new Arquivo(arquivo, venda.Id));
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
