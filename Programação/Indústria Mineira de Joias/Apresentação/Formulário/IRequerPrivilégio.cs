using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Interface para requerimento de privilégios específicos
    /// do funcionário que opera o programa.
    /// </summary>
    public interface IRequerPrivilégio
    {
        /// <summary>
        /// Privilégio(s) necessário(s) para utilização do recurso.
        /// </summary>
        Entidades.Privilégio.Permissão Privilégio { get; set; }
    }
}
