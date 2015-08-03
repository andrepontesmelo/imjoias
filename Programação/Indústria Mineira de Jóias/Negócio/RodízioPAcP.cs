using System;
using System.Collections.Generic;
using Entidades;
using Entidades.Pessoa;
using Entidades.Configura��o;

namespace Neg�cio
{
    /// <summary>
    /// Controle de rod�zio de atendentes para um determinado setor de atendimento,
    /// sendo que o primeiro a acabar � o pr�ximo (PAcP).
    /// </summary>
    public class Rod�zioPAcP : Rod�zio
    {
        public Rod�zioPAcP(Setor setor)
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
            Atendimento atendimento = null;

            visita = Visita.ObterPr�ximaVisitaEsperando(setor);
            atendente = ObterPr�ximoAtendenteDispon�vel();

            if (visita != null && atendente != null)
            {
                atendimento = new Atendimento(visita, atendente);

                bool atendimentoCancelado = !ConfirmarAtendimento(atendimento);

                /* Neste ponto, o atendente pode ter sido trocado
                 * durante o tratamento de evento.
                 * -- J�lio, 24/06/2006
                 */
                if (!atendimentoCancelado)
                {
                    atendente = atendimento.Atendente;

                    IniciarAtendimento(visita, atendente);
                    RealizarRod�zio(atendente);
                }
            }

            return atendimento;
        }

        /// <summary>
        /// Chamado ao encerrar um atendimento.
        /// </summary>
        public override void EncerrarAtendimento(Visita visita)
        {
            if (visita.Atendente != null && !visita.AtendimentoForaDoRod�zio)
                RealizarRod�zio(visita.Atendente);
        }
    }
}
