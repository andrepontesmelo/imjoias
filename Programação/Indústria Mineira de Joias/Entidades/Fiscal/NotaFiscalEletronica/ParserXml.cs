using System;
using System.Xml;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ParserXml
    {
        private XmlDocument documento;
        private static readonly string XML_CAMINHO_DET = "/nfeProc/NFe/infNFe/det";

        private string ObterCaminhoRaiz(int vendaItem)
        {
            return XML_CAMINHO_DET + "[" + vendaItem.ToString() + "]/prod";
        }

        private string ObterCaminhoAtributo(int vendaItem, string atributo)
        {
            return ObterCaminhoRaiz(vendaItem) + "/" + atributo;
        }

        private string ObterTexto(string caminho)
        {
            return documento.DocumentElement.SelectSingleNode(caminho).InnerText;
        }

        private decimal ObterDecimal(string caminho)
        {
            return decimal.Parse(ObterTexto(caminho).Replace('.', ','));
        }

        public ParserXml(string arquivo)
        {
            documento = Xml.LerXmlSemNamespaces(arquivo);
        }

        public int QuantidadeVendaItem
        {
            get
            {
                XmlNodeList lista = documento.DocumentElement.SelectNodes(XML_CAMINHO_DET);

                return lista == null ? 0 : lista.Count;
            }
        }

        public TipoUnidade ObterTipoUnidade(string descrição)
        {
            return (TipoUnidade) Enum.Parse(typeof(TipoUnidade), descrição, true);
        }

        public TipoUnidade ObterTipoUnidade(int vendaItem)
        {
            return ObterTipoUnidade(ObterTexto(ObterCaminhoAtributo(vendaItem, "uCom")));
        }

        public string ObterReferência(int vendaItem)
        {
            return ObterTexto(ObterCaminhoAtributo(vendaItem, "cProd"));
        }

        public decimal ObterQuantidadeItens(int vendaItem)
        {
            return ObterDecimal(ObterCaminhoAtributo(vendaItem, "qCom"));
        }

        public decimal ObterValorUnitario(int vendaItem)
        {
            return ObterDecimal(ObterCaminhoAtributo(vendaItem, "vUnCom"));
        }

        public decimal ObterValor(int vendaItem)
        {
            return ObterDecimal(ObterCaminhoAtributo(vendaItem, "vProd"));
        }

        public string ObterDescrição(int vendaItem)
        {
            return ObterTexto(ObterCaminhoAtributo(vendaItem, "xProd"));
        }

        public static ParserXml LerArquivo(string arquivo)
        {
            return new ParserXml(arquivo);
        }
    }
}
