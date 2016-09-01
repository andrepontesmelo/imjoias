using System;
using System.Xml;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ParserXml
    {
        private XmlDocument documento;
        private static readonly string XML_CAMINHO_RAIZ = "/nfeProc/NFe/infNFe";
        private static readonly string XML_CAMINHO_VENDA = XML_CAMINHO_RAIZ + "/ide";
        private static readonly string XML_CAMINHO_ITENS = XML_CAMINHO_RAIZ + "/det";

        private string ObterCaminhoRaiz(int vendaItem)
        {
            return XML_CAMINHO_ITENS + "[" + vendaItem.ToString() + "]/prod";
        }

        private string ObterCaminhoAtributo(int vendaItem, string atributo)
        {
            return ObterCaminhoRaiz(vendaItem) + "/" + atributo;
        }

        private string ObterTexto(string caminho)
        {
            return ObterNó(caminho).InnerText;
        }

        private decimal ObterDecimal(string caminho)
        {
            return decimal.Parse(TrocarSeparaçãoDecimalVirgula(ObterTexto(caminho)));
        }

        private string TrocarSeparaçãoDecimalVirgula(string decimalUsandoPonto)
        {
            return decimalUsandoPonto.Replace('.', ',');
        }

        private int ObterInteiro(string caminho)
        {
            return int.Parse(TrocarSeparaçãoDecimalVirgula(ObterTexto(caminho)));
        }

        public ParserXml(string arquivo)
        {
            documento = Xml.LerXmlSemNamespaces(arquivo);
        }

        public int QuantidadeVendaItem
        {
            get
            {
                XmlNodeList lista = documento.DocumentElement.SelectNodes(XML_CAMINHO_ITENS);

                return lista == null ? 0 : lista.Count;
            }
        }

        public static TipoUnidade ObterTipoUnidade(string descrição)
        {
            if (descrição.ToLower().StartsWith("gr"))
                return TipoUnidade.Grs;

            if (descrição.ToLower().CompareTo("peca") == 0)
                return TipoUnidade.Pca;

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

        private XmlNode ObterNó(string caminho)
        {
            return documento.DocumentElement.SelectSingleNode(caminho);
        }

        public string ObterAtributo(string caminho, string atributo)
        {
            return ObterNó(caminho).Attributes[atributo].Value;
        }

        public string ObterAtributo(string atributo)
        {
            return ObterAtributo(XML_CAMINHO_RAIZ, atributo);
        }

        public string LerId()
        {
            return ObterAtributo("Id");
        }

        private string ObterCaminhoAtributoVenda(string atributo)
        {
            return string.Format("{0}/{1}", XML_CAMINHO_VENDA, atributo);
        }

        public DateTime LerDataEmissão()
        {
            return DateTime.Parse(ObterTexto(ObterCaminhoAtributoVenda("/dhEmi")));
        }

        public int LerNNF()
        {
            return ObterInteiro(ObterCaminhoAtributoVenda("/nNF"));
        }
    }
}
