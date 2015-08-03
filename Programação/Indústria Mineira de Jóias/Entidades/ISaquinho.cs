using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public interface ISaquinho
    {
        double Quantidade { get; }
        Entidades.Mercadoria.Mercadoria Mercadoria { get; }
        double Peso { get; }

        string Identifica��oAgrup�vel();

        ISaquinho Clone(double novaQuantidade);

      
    }
}