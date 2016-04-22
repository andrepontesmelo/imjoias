using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Estatística
{
    /// <summary>
    /// Implementa métodos que permite a plotagem do objeto
    /// em gráficos com seqüências.
    /// </summary>
    public interface IPlotávelSeqüência : IPlotável
    {
        /// <summary>
        /// Obtém a legenda da seqüência.
        /// </summary>
        /// <returns>Legenda da seqüência.</returns>
        string ObterSeqüênciaPlotagem();
    }
}
