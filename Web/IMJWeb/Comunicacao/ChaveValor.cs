using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMJWeb.Comunicacao
{
    static class ChaveValor
    {
        private const string formatoChaveRepetida = "({1}) {0}";

        /// <summary>
        /// Interpreta os dados separados por tabulação.
        /// </summary>
        /// <param name="dados">Dados separados por tabulação.</param>
        /// <returns>Conjunto de pares contendo chave e valor.</returns>
        public static IDictionary<string, string> Interpretar(string dados)
        {
            string[] partes = dados.Split('\t');

            if (partes.Length % 2 != 0)
                throw new FormatException();

            Dictionary<string, string> pares = new Dictionary<string, string>();

            for (int i = 0; i < partes.Length; i += 2)
            {
                var chave = partes[i];

                for (int j = 2; pares.ContainsKey(chave); j++)
                    chave = string.Format(formatoChaveRepetida, partes[i], j);

                pares.Add(chave, partes[i + 1]);
            }

            return pares;
        }
   }
}