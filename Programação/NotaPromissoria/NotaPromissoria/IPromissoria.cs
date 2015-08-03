using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public interface IPromissoria
    {
        int TotalParcelas { get; }
        DateTime PrimeiroVencimento { get; }
        DateTime Data { get; }
        double Quantia { get; }
        string Emitente { get; }
        string Endereço { get; }
        string CPF { get; }
        string CGC { get; }
    }
}
