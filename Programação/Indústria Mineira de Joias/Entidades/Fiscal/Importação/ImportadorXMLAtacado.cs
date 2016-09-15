using Entidades.Fiscal.NotaFiscalEletronica;
using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorXMLAtacado : Importador
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
            List<string> arquivos = ObterArquivos(pasta, PADRÂO_ARQUIVO, opções);
            List<string> arquivosErro = new List<string>();
            List<VendaFiscal> vendas = new List<VendaFiscal>();

            int x = 0;
            foreach (string arquivo in arquivos)
            {
                x++;
                try
                {
                    Console.WriteLine("Lendo arquivo " + arquivo + " " + x.ToString() + " de " + arquivos.Count.ToString());

                    ParserXmlAtacado xml = new ParserXmlAtacado(arquivo);
                    AdaptadorAtacado adaptador = new AdaptadorAtacado(xml);
                    VendaFiscal venda = adaptador.Transformar();
                    vendas.Add(venda);

                } catch (System.Xml.XmlException erroXml)
                {
                    arquivosErro.Add(arquivo);
                }
            }

            Console.WriteLine(arquivosErro.ToString());
        }
    }
}
