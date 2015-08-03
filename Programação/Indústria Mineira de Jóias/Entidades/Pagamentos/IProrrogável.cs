using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Pagamentos
{
    public interface IProrrogável
    {
        DateTime? ProrrogadoPara { get; }
    }
}
