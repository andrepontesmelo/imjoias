using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Exceção disparada por um botão/controlador que não é
    /// suportado na aplicação atual.
    /// </summary>
    public class ExceçãoBotãoNãoSuportado : ApplicationException
    {
        public ExceçãoBotãoNãoSuportado(string msg)
            : base(msg)
        { }
    }
}
