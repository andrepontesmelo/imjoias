using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Verificação
{
    class Inconsistência
    {
        enum Tipo
        {
            ReferênciaNãoEncontrada,
            CotaçãoIncorreta,
            PagamentoNãoCoincideComValorDaVenda
        }
    }
}
