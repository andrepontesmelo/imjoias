using System;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ParserXml
    {
        private XmlDocument documento;

        public ParserXml(string arquivo)
        {
            // Remover namespaces xml
            string conteudo = System.IO.File.ReadAllText(arquivo);
            string filtro = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            conteudo = Regex.Replace(conteudo, filtro, "");

            documento = new XmlDocument();
            documento.LoadXml(conteudo);
        }

        public int QuantidadeVendaItem
        {
            get
            {
                return documento.DocumentElement.SelectNodes("/nfeProc/NFe/infNFe/det").Count;
            }
        }

        public static ParserXml LerArquivo(string arquivo)
        {
            return new ParserXml(arquivo);
        }
    }
}
