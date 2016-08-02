using System.Xml;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ParserXml
    {
        private XmlDocument documento;

        public ParserXml(string arquivo)
        {
            documento = Xml.LerXmlSemNamespaces(arquivo);
        }

        public int QuantidadeVendaItem => documento.DocumentElement.SelectNodes("/nfeProc/NFe/infNFe/det").Count;

        public static ParserXml LerArquivo(string arquivo)
        {
            return new ParserXml(arquivo);
        }
    }
}
