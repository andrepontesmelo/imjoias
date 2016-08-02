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

        public TipoUnidade ObterTipoUnidade(int vendaItem)
        {
            return TipoUnidade.Par;
        }

        public string ObterReferência(int vendaItem)
        {
            return "";
        }

        public int ObterQuantidadeItens(int vendaItem)
        {
            return 0;
        }

        public decimal ObterValorUnitario(int vendaItem)
        {
            return 0;
        }

        public decimal ObterValor(int vendaItem)
        {
            return 0;
        }

        public string ObterDescrição(int vendaItem)
        {
            return "";
        }

        public static ParserXml LerArquivo(string arquivo)
        {
            return new ParserXml(arquivo);
        }
    }
}
