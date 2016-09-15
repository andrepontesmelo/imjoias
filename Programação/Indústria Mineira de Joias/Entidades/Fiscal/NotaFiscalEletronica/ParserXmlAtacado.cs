using System;
using System.Globalization;
using System.Xml;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ParserXmlAtacado
    {
        private XmlDocument documento;
        private static readonly string XML_CAMINHO_RAIZ = "/nfeProc/NFe/infNFe";
        private static readonly string XML_CAMINHO_VENDA = XML_CAMINHO_RAIZ + "/ide";
        private static readonly string XML_CAMINHO_ITENS = XML_CAMINHO_RAIZ + "/det";
        private static readonly string XML_CAMINHO_TOTAIS = XML_CAMINHO_RAIZ + "/total/ICMSTot";
        private static readonly CultureInfo CULTURA_AMERICANA = new CultureInfo("en-US");

        internal decimal LerValorTotal()
        {
            return ObterDecimal(XML_CAMINHO_TOTAIS + "/vNF");
        }

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

        internal int ObterCFOP(int vendaItem)
        {
            return ObterInteiro(ObterCaminhoAtributo(vendaItem, "CFOP"));
        }

        private decimal ObterDecimal(string caminho)
        {
            decimal valor = 0;
            string texto = ObterTexto(caminho);

            bool ok = decimal.TryParse(texto, NumberStyles.Any, CULTURA_AMERICANA, out valor);

            if (!ok)
                throw new Exception(string.Format("{0} não pode ser transformado em decimal.", texto));
            
            return valor;
        }

        private int ObterInteiro(string caminho)
        {
            int valor = 0;
            string texto = ObterTexto(caminho);

            bool ok = int.TryParse(texto, NumberStyles.Any, CULTURA_AMERICANA, out valor);

            if (!ok)
                throw new Exception(string.Format("{0} não pode ser transformado em inteiro.", texto));

            return valor;
        }

        public ParserXmlAtacado(string arquivo)
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

        public static ParserXmlAtacado LerArquivo(string arquivo)
        {
            return new ParserXmlAtacado(arquivo);
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

        public bool LerCancelamento()
        {
            return ObterNó("/nfeProc/protNFe/infProt")["TRetCancNFe"] != null;
        }
    }
}
