using System;
using System.Xml;
using Programa.ProtetorTela.UI;
using System.Text.RegularExpressions;

namespace Programa.ProtetorTela.Rss
{
    /// <summary>
    /// Representation of an Item element in an RSS 2.0 XML document.
    /// Zero or more RssItems are contained in an RssChannel.
    /// </summary>
    public class RssItem : IItem
    {
        private readonly string title;
        private readonly string description;
        private readonly string link;

        public string Title { get { return title; } }
        public string Description { get { return description; } }
        public string Link { get { return link; } }


        /// <summary>
        /// Build an RSSItem from an XmlNode representing an Item element inside an RSS 2.0 XML document.
        /// </summary>
        /// <param name="itemNode"></param>
        internal RssItem(XmlNode itemNode)
        {
            XmlNode selected;
            selected = itemNode.SelectSingleNode("title");
            if (selected != null)
                title = ExtrairDescrição(selected.InnerText);

            selected = itemNode.SelectSingleNode("description");
            if (selected != null)
                description = ExtrairDescrição(selected.InnerText);

            selected = itemNode.SelectSingleNode("link");
            if (selected != null)
                link = selected.InnerText;
        }

        /// <summary>
        /// Extrai a descrição, removendo as TAGs Html.
        /// </summary>
        private string ExtrairDescrição(string entrada)
        {
            string saída = "";
            string tagElemento = "", escapeElemento = "";
            bool tag = false;
            bool escape = false;

            foreach (char c in entrada)
                switch (c)
                {
                    case '<':
                        tag = true;
                        tagElemento = "";
                        break;

                    case '>':
                        tag = false;
                        saída += ProcessarTag(tagElemento);
                        break;

                    case '&':
                        escape = true;
                        escapeElemento = "";
                        break;

                    case ';':
                    case ' ':
                        if (escape)
                        {
                            escape = false;
                            saída += ProcessarEscape(escapeElemento);
                            break;
                        }
                        else
                            goto default;

                    default:
                        if (tag)
                            tagElemento += c;
                        else if (escape)
                            escapeElemento += c;
                        else
                            saída += c;
                        break;
                }

            return saída.Trim(' ', '\n');
        }

        /// <summary>
        /// Processa uma TAG Html.
        /// </summary>
        private static string ProcessarTag(string elemento)
        {
            string[] palavras = elemento.Split(' ');

            palavras[0] = palavras[0].ToUpper();

            if (palavras[0] == "BR" || palavras[0] == "/TD" || palavras[0] == "/TR")
                return "\n";

            if (palavras[0] == "P")
                return "\n\n";

            return "";
        }

        private static string ProcessarEscape(string elemento)
        {
            if (elemento == "nbsp")
                return " ";

            if (elemento == "atilde")
                return "ã";

            if (elemento == "aacute")
                return "á";

            if (elemento == "eacute")
                return "é";

            if (elemento == "iacute")
                return "í";

            if (elemento == "oacute")
                return "ó";

            if (elemento == "uacute")
                return "ú";

            if (elemento == "ccedil")
                return "ç";

            return elemento + " ";
        }
    }
}