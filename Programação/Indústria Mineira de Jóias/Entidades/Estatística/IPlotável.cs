using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Estatística
{
    /// <summary>
    /// Implementa métodos que permite a plotagem do objeto
    /// em gráficos.
    /// </summary>
    public interface IPlotável
    {
        /// <summary>
        /// Obtém valor para plotagem no eixo Y.
        /// </summary>
        /// <returns>Valor para plotagem.</returns>
        double ObterValorPlotagem();
    }
}
