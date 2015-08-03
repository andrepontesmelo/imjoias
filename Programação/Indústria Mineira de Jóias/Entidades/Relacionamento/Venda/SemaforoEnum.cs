using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Relacionamento.Venda
{
    public enum SemaforoEnum : int
    {
        NãoQuitado,
        Cobrança,
        Quitado,
        ComissãoFechada,
        DoDia,
        Nfe
    }
}
