using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum.Acompanhamento
{
    /// <summary>
    /// Tratamento de ação sofrida por uma entidade.
    /// </summary>
    /// <param name="tipo">Tipo de declaração da entidade.</param>
    /// <param name="dados">Dados da entidade e da ação.</param>
    public delegate void DbAçãoHandler(Type tipo,  DbAçãoDados dados);
}
