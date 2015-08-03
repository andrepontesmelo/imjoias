using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão.Pacotes
{
    static class Útil
    {
        public static unsafe int PreencherString(char* destino, int tamanhoDestino, string origem)
        {
            int tamanho = (Math.Min(origem.Length, tamanhoDestino));

            for (int i = 0; i < tamanho; i++)
                destino[i] = origem[i];

            return tamanho;
        }

        public static unsafe string RecuperarString(char* origem, int tamanho)
        {
            string str = "";

            for (int i = 0; i < tamanho; i++)
                str += origem[i];

            return str;
        }
    }
}
