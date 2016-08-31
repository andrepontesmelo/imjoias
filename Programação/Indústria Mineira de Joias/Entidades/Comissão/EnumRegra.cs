using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Comissão
{
    public enum EnumRegra : long
    {
        Varejo = 0,
        AtacadoNãoConsignado = 1,
        AtacadoConsignado = 2,
        AA = 3,
        Representante = 4,
        RepresentanteParaClienteOutroRepresentante = 5,
        RepresentanteParaClienteSemRegião = 6,
        CompartilhadaRepresentanteAtacado = 7,
        RepresentanteCompra = 8,
        Corretor = 9,
        OutrosClientes = 10,
        FuncionárioCompra = 11
    }
}
