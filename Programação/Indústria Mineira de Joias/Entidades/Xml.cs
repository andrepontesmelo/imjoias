using System.Text.RegularExpressions;
using System.Xml;

namespace Entidades
{
    public class Xml
    {
        public static XmlDocument LerXmlSemNamespaces(string arquivo)
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
