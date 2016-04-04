using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Formulários
{
    public interface IEditorItem<TipoItem>
    {
        TipoItem Item { get; set; }
    }
}
