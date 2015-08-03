
using System;
using System.Collections.Generic;
using Entidades;
using Entidades.Pessoa;
using Entidades.Configura��o;

namespace Neg�cio
{
    /// <summary>
    /// Controle de rod�zio de atendentes para um determinado setor de atendimento,
    /// sendo que o primeiro a atender � o pr�ximo (PAtP).
    /// </summary>
    public class Rod�zioPAtP : Rod�zio
    {
        public Rod�zioPAtP(Setor setor)
            : base(setor)
        { }

        /// <summary>
        /// Obt�m o pr�ximo atendimento.
        /// </summary>
        /// <returns></returns>
        public override Atendimento ObterPr�ximoAtendimento()
        {
            Visita visita;
            Funcion�rio atendente;
            Atendimento atendimento;

            visita = Visita.ObterPr�ximaVisitaEsperando(setor);
            atendente = ObterPr�ximoAtendenteDispon�vel();

            if (visita != null && atendente != null)
            {
                atendimento = new Atendimento(visita, atendente);

                if (ConfirmarAtendimento(atendimento))
                {

                    /* Neste ponto, o atendente pode ter sido trocado
                     * durante o tratamento de evento.
                     * -- J�lio, 24/06/2006
                     */
                    atendente = atendimento.Atendente;

                    IniciarAtendimento(visita, atendente);
                    RealizarRod�zio(atendente);
                }
                return atendimento;
            }
            else
                return null;
        }
    }
}
