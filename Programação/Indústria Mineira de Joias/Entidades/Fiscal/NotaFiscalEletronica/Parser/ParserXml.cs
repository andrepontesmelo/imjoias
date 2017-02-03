using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace Entidades.Fiscal.NotaFiscalEletronica.Parser
{
    public abstract class ParserXml
    {
        protected XmlDocument documento;

        public ParserXml(string arquivo)
        {
            documento = LerXmlSemNamespaces(arquivo);
        }

        protected XmlNode ObterNó(string caminho)
        {
            return documento.DocumentElement.SelectSingleNode(caminho);
        }

        protected string ObterTexto(string caminho)
        {
            XmlNode nó = ObterNó(caminho);

            return nó?.InnerText;
        }

        protected bool Existe(string caminho)
        {
            return ObterNó(caminho) != null;
        }

        public string ObterAtributo(string caminho, string atributo)
        {
            return ObterNó(caminho).Attributes[atributo].Value;
        }

        private XmlDocument LerXmlSemNamespaces(string arquivo)
        {
            string conteudo = System.IO.File.ReadAllText(arquivo);
            string filtroRemoçãoNamespaces = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            conteudo = Regex.Replace(conteudo, filtroRemoçãoNamespaces, "");

            XmlDocument documento = new XmlDocument();
            documento.LoadXml(conteudo);

            return documento;
        }
    }
}
