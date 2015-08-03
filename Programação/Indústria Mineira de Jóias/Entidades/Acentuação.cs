using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Entidades
{
    /// <summary>
    /// Retira acentuação de string.
    /// </summary>
    /// <remarks>
    /// Fonte: posted on Wednesday, September 28, 2005 10:23 AM por fbcjunior 
    /// http://thespoke.net/blogs/fbcjunior/archive/2005/09/28/474998.aspx
    /// </remarks>
    public sealed class Acentuação
    {
        const string Acentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
        const string SemAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

        private Regex regAcentuação;
        private Dictionary<string, string> dicStr;

        private static Acentuação singleton;

        public static Acentuação Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new Acentuação();

                return singleton;
            }
        }

        private Acentuação()
        {
            regAcentuação = new Regex("[" + Acentos + "]", RegexOptions.Compiled);

            dicStr = new Dictionary<string, string>(StringComparer.Ordinal);

            for (int i = 0; i < Acentos.Length; i++)
                dicStr.Add(Acentos[i].ToString(), SemAcentos[i].ToString());
        }

        private string TirarAcento(Match match)
        {
            return dicStr[match.Value];
        }

        public string TirarAcentos(string str)
        {
            if (str == null) return null;
            return regAcentuação.Replace(str, new MatchEvaluator(TirarAcento));
        }

        public static int CompararSemAcentos(string str1, string str2)
        {
            Acentuação acentuação = Singleton;

            return string.Compare(acentuação.TirarAcentos(str1), acentuação.TirarAcentos(str2));
        }

        public static int CompararSemAcentos(string str1, string str2, bool ignoreCase)
        {
            Acentuação acentuação = Singleton;

            return string.Compare(acentuação.TirarAcentos(str1), acentuação.TirarAcentos(str2), ignoreCase);
        }
    }
}
