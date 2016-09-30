using Entidades.Fiscal.Excessões;
using System;
using System.Globalization;
using System.Xml;

namespace Entidades.Fiscal.NotaFiscalEletronica.Parser
{
    public class ParserXmlAtacado : ParserXml
    {
        private static readonly string XML_CAMINHO_RAIZ = "/nfeProc/NFe/infNFe";
        private static readonly string XML_CAMINHO_VENDA = XML_CAMINHO_RAIZ + "/ide";
        private static readonly string XML_CAMINHO_EMITENTE = XML_CAMINHO_RAIZ + "/emit";
        private static readonly string XML_CAMINHO_ITENS = XML_CAMINHO_RAIZ + "/det";
        private static readonly string XML_CAMINHO_TOTAIS = XML_CAMINHO_RAIZ + "/total/ICMSTot";
        private static readonly CultureInfo CULTURA_AMERICANA = new CultureInfo("en-US");

        public ParserXmlAtacado(string arquivo) : base(arquivo)
        {
        }

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
                throw new FormatException(string.Format("{0} não pode ser transformado em decimal.", texto));

            return valor;
        }

        private int ObterInteiro(string caminho)
        {
            int valor = 0;
            string texto = ObterTexto(caminho);

            bool ok = int.TryParse(texto, NumberStyles.Any, CULTURA_AMERICANA, out valor);

            if (!ok)
                throw new FormatException(string.Format("{0} não pode ser transformado em inteiro.", texto));

            return valor;
        }

        public int QuantidadeVendaItem
        {
            get
            {
                XmlNodeList lista = documento.DocumentElement.SelectNodes(XML_CAMINHO_ITENS);

                return lista == null ? 0 : lista.Count;
            }
        }

        public TipoUnidade ObterTipoUnidade(int vendaItem)
        {
            return TipoUnidadeInterpretação.Interpretar(ObterTexto(ObterCaminhoAtributo(vendaItem, "uCom")));
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
            string caminho = ObterCaminhoAtributoVenda("dhEmi");
            string caminhoVersão2 = ObterCaminhoAtributoVenda("dEmi");

            if (Existe(caminho))
                return DateTime.Parse(ObterTexto(caminho));

            if (Existe(caminhoVersão2))
                return DateTime.Parse(ObterTexto(caminhoVersão2));

            throw new XmlIncompatível("Data de emissão da NF-e não foi encontrada");
        }

        public string LerCNPJEmitente()
        {
            return ObterTexto(XML_CAMINHO_EMITENTE + "/CNPJ");
        }

        public int LerNNF()
        {
            return ObterInteiro(ObterCaminhoAtributoVenda("nNF"));
        }
    }
}
