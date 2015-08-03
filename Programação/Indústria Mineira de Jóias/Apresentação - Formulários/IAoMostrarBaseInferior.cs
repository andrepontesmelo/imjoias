using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Interface que expõe método a ser chamado sempre
    /// que uma base inferior for exibida.
    /// </summary>
    public interface IAoMostrarBaseInferior
    {
        /// <summary>
        /// Ocorre ao exibir a base inferior pela primeira vez.
        /// </summary>
        /// <param name="baseInferior">Base inferior exibida.</param>
        void AoExibirDaPrimeiraVez(BaseInferior baseInferior);

        /// <summary>
        /// Ocorre ao exibir a base inferior.
        /// </summary>
        /// <param name="baseInferior">Base inferior exibida.</param>
        void AoExibir(BaseInferior baseInferior);
    }
}
