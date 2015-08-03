using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Estatística
{
    /// <summary>
    /// Implementa métodos que permite a plotagem em gráfico
    /// e impressão de rótulo no eixo X.
    /// </summary>
    public interface IPlotávelRotulado : IPlotável
    {
        string ObterRótulo();
    }
}
