using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum.Exceções
{
    /// <summary>
    /// Exceção indicando que a entidade não foi encontrada.
    /// </summary>
    [Serializable]
    public class EntidadeNãoEncontrada : ExceçãoEntidade
    {
        public EntidadeNãoEncontrada()
            : base(null, "Entidade não encontrada.")
        { }
    }
}
