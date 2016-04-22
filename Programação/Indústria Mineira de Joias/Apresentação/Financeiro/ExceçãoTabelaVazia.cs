using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// Exceção levantada indicando que a tabela de preço
    /// não fora definida.
    /// </summary>
    public class ExceçãoTabelaVazia : ApplicationException
    {
        public ExceçãoTabelaVazia()
            : base("A tabela de preço não foi definida.")
        { }
    }
}
