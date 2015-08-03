using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// The Levenshtein distance or edit distance between two strings is
    /// given by the minimum number of operations needed to transform one
    /// string into the other, where an operation is an insertion, deletion,
    /// or substitution of a single character. It is named after Vladimir
    /// Levenshtein, who considered this distance in 1965. It is useful in
    /// applications that need to determine how similar two strings are, such
    /// as spell checkers.
    /// </summary>
    /// <remarks>
    /// Fonte: Wikipedia
    /// </remarks>
    public abstract class DistânciaLevenshtein
    {
        private static int Minimum(int a, int b, int c)
        {
            if (a <= b && a <= c)
                return a;
            if (b <= a && b <= c)
                return b;
            return c;
        }

        public static int CalcularDistância(String str1, String str2)
        {
            if (str1 == null) str1 = "";
            if (str2 == null) str2 = "";
            return CalcularDistância(str1.ToCharArray(), str2.ToCharArray());
        }

        private static int CalcularDistância(char[] str1, char[] str2)
        {
            int[][] distance = new int[str1.Length + 1][];

            for (int i = 0; i <= str1.Length; i++)
            {
                distance[i] = new int[str2.Length + 1];
                distance[i][0] = i;
            }
            for (int j = 0; j < str2.Length + 1; j++)
                distance[0][j] = j;

            for (int i = 1; i <= str1.Length; i++)
                for (int j = 1; j <= str2.Length; j++)
                    distance[i][j] = Minimum(distance[i - 1][j] + 1,
                        distance[i][j - 1] + 1, distance[i - 1][j - 1] +
                        ((str1[i - 1] == str2[j - 1]) ? 0 : 1));

            return distance[str1.Length][str2.Length];
        }
    }
}
