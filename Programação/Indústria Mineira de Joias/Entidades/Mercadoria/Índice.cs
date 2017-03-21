using System;

namespace Entidades.Mercadoria
{
    public class Índice
    {
        private const int CASAS_ARREDONDAMENTO = 2;

        public static double Calcular(double coeficiente, double peso, bool dePeso, bool arrendondar)
        {
            peso = arrendondar ? Math.Round(peso, CASAS_ARREDONDAMENTO) : peso;

            double resultado = coeficiente;

            if (dePeso)
                resultado *= peso;

            if (arrendondar)
                resultado = Math.Round(resultado, CASAS_ARREDONDAMENTO);

            return resultado;
        }

        public static double Calcular(double coeficiente, double peso, bool dePeso)
        {
            return Calcular(coeficiente, peso, dePeso, false);
        }
    }
}
