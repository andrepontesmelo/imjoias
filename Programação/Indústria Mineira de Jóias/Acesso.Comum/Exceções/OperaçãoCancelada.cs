using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum.Exceções
{
    /// <summary>
    /// Exceção levantada quando uma operação sobre uma entidade
    /// é cancelada pelo sistema, por meio do tratamento de eventos
    /// do tipo DbManipulaçãoCancelávelHandler.
    /// </summary>
    public class OperaçãoCancelada : ExceçãoEntidade
    {
        /// <summary>
        /// Constrói a exceção.
        /// </summary>
        /// <param name="entidade">Entidade que gerou exceção.</param>
        public OperaçãoCancelada(Acesso.Comum.DbManipulação entidade)
            : base(entidade)
        {
        }

        public override string Message
        {
            get
            {
                return "A operação no banco de dados foi cancelada pelo sistema.";
            }
        }
    }
}
