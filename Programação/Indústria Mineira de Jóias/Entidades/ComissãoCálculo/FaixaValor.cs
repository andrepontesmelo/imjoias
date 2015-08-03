using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ComissãoCálculo
{
    public class FaixaValor
    {
        public char Faixa { get; set; }
        public double Valor { get; set; }

        public FaixaValor(char faixa, double valor)
        {
            this.Faixa = faixa;
            this.Valor = valor;
        }
    }
}
