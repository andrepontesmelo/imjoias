using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum.Cache
{
    /// <summary>
    /// Define que a cache n�o deve realizar c�pia do objeto.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class N�oCopiarCache : Attribute
    {
    }
}
