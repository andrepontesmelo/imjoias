using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.ComissãoCálculo
{
    public class Regra
    {
        public static string ObterNome(long regra)
        {
            switch (regra)
            {
                case 0:
                    return "Varejo";
                case 1:
                    return "Atacado Não Consignado";
                case 2:
                    return "Atacado Consignado";
                case 3:
                    return "Alto-Atacado";
                case 4:
                    return "Representante";
                case 5:
                    return "Repr. para cliente de outro Repr.";
                case 6:
                    return "Repr. p/ cli sem região";
                case 7:
                    return "Compartilhada repr. atacado";
                case 8:
                    return "Corretor";
                case 9:
                    return "Vendas p/ outros setores ou func.";
                    
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
