using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Acerto
{
    [Flags]
    public enum FórmulaAcerto : uint
    {
        Padrão = 0, 
        IgualAVenda = 0x00000001
    }
}

