using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.ComissãoCálculo
{
    public class Regra
    {
        public static string ObterNome(EnumRegra regra)
        {
            switch (regra)
            {
                case EnumRegra.Varejo:
                    return "Varejo";
                case EnumRegra.AtacadoNãoConsignado:
                    return "Atacado Não Consignado";
                case EnumRegra.AtacadoConsignado:
                    return "Atacado Consignado";
                case EnumRegra.AA:
                    return "Alto-Atacado";
                case EnumRegra.Representante:
                    return "Representante";
                case EnumRegra.RepresentanteParaClienteOutroRepresentante:
                    return "Repr. para cliente de outro Repr.";
                case EnumRegra.RepresentanteParaClienteSemRegião:
                    return "Repr. p/ cli sem região";
                case EnumRegra.CompartilhadaRepresentanteAtacado:
                    return "Compartilhada repr. atacado";
                case EnumRegra.RepresentanteCompra:
                    //return "Representante compra";
                case EnumRegra.Corretor:
                    return "Corretor";
                case EnumRegra.OutrosFuncionarios:
                    return "Vendas p/ outros setores ou func.";
                    
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
