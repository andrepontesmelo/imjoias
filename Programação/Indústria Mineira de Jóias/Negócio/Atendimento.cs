using System;
using System.Collections.Generic;
using System.Text;

using Entidades;
using Entidades.Pessoa;

namespace Negócio
{
    /// <summary>
    /// Estrutuar que descreve o início de um atendimento.
    /// </summary>
    public class Atendimento
    {
        /// <summary>
        /// Visita vinculado ao cliente.
        /// </summary>
        private Visita visita;

        /// <summary>
        /// Atendente.
        /// </summary>
        private Funcionário atendente;

        #region Propriedades

        /// <summary>
        /// Registro da visita no banco de dados.
        /// </summary>
        public Visita Visita
        {
            get { return visita; }
        }

        /// <summary>
        /// Primeiro atendente.
        /// </summary>
        public Funcionário Atendente
        {
            get { return atendente; }
            set { atendente = value; }
        }

        #endregion

        /// <summary>
        /// Constrói a estrutura de atendimento.
        /// </summary>
        /// <param name="visita">Visita vinculada ao cliente.</param>
        /// <param name="atendente">Atendente do cliente.</param>
        public Atendimento(Visita visita, Funcionário atendente)
        {
            this.visita = visita;
            this.atendente = atendente;
        }
    }
}
