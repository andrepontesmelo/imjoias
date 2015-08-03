using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum.Cache
{
    /// <summary>
    /// Define que a cache não deve realizar cópia do objeto.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NãoCopiarCache : Attribute
    {
    }
}
