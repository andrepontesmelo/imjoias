using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal
{
    public class ImportadorXMLAtacado
    {
        public static readonly string PADRÂO_ARQUIVO = "*.xml";

        public ImportadorXMLAtacado()
        {
        }


        public void ImportarXmls(string pasta)
        {
            ImportarXmls(pasta, SearchOption.AllDirectories);
        }


        public void ImportarXmls(string pasta, SearchOption opções)
        {
            List<string> arquivos = ObterArquivos(pasta, opções);
            List<string> arquivosErro = new List<string>();
            int x = 0;
            foreach (string arquivo in arquivos)
            {
                x++;
                try
                {
                    NotaFiscalEletronica.ParserXml xml = new NotaFiscalEletronica.ParserXml(arquivo);
                    Console.WriteLine("Lendo arquivo " + arquivo + " " + x.ToString() + " de " + arquivos.Count.ToString());
                    Console.WriteLine("Itens:  " + xml.QuantidadeVendaItem.ToString());

                    for (int i = 1; i <= xml.QuantidadeVendaItem; i++)
                    {
                        Console.WriteLine(xml.ObterReferência(i).ToString());
                        Console.WriteLine(xml.ObterDescrição(i).ToString());
                        Console.WriteLine(xml.ObterQuantidadeItens(i).ToString());
                        Console.WriteLine(xml.ObterTipoUnidade(i).ToString());
                        Console.WriteLine(xml.ObterValor(i).ToString());
                        Console.WriteLine(xml.ObterValorUnitario(i).ToString());
                    }
                } catch (System.Xml.XmlException erroXml)
                {
                    arquivosErro.Add(arquivo);
                }
            }

            Console.WriteLine(arquivosErro.ToString());
        }

        private List<string> ObterArquivos(string pasta, SearchOption opções)
        {
            List<string> arquivos = new List<string>();
            foreach (string arquivo in Directory.EnumerateFiles(pasta, PADRÂO_ARQUIVO, opções))
                arquivos.Add(arquivo);

            return arquivos;
        }
    }
}
