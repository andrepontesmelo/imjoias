using System;
using System.Collections.Generic;
using System.Text;

using Entidades.Pessoa;

namespace Entidades.Privilégio
{
    /// <summary>
    /// Exceção levantada quando funcionário não possui permissão(ões)
    /// necessária(s) para utilização de um determinado recurso.
    /// </summary>
    public class PermissãoNegada : ApplicationException
    {
        private Funcionário funcionário;

        public PermissãoNegada(Funcionário funcionário, string mensagem)
            : base(mensagem)
        {
            this.funcionário = funcionário;
        }

        public PermissãoNegada(Funcionário funcionário)
            : this(funcionário, "Autorização negada ao funcionário.")
        { }

        public Funcionário Funcionário
        {
            get { return funcionário; }
        }
    }
}
