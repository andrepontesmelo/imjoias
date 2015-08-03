using System;
using System.Collections.Generic;
using Entidades;
using Entidades.Pessoa;
using Entidades.Configuração;

namespace Negócio
{
    /// <summary>
    /// Controle de rodízio de atendentes para um determinado setor de atendimento,
    /// sendo que o primeiro a acabar é o próximo (PAcP).
    /// </summary>
    public class RodízioPAcP : Rodízio
    {
        public RodízioPAcP(Setor setor)
            : base(setor)
        { }

        /// <summary>
        /// Obtém o próximo atendimento.
        /// </summary>
        /// <returns></returns>
        public override Atendimento ObterPróximoAtendimento()
        {
            Visita visita;
            Funcionário atendente;
            Atendimento atendimento = null;

            visita = Visita.ObterPróximaVisitaEsperando(setor);
            atendente = ObterPróximoAtendenteDisponível();

            if (visita != null && atendente != null)
            {
                atendimento = new Atendimento(visita, atendente);

                bool atendimentoCancelado = !ConfirmarAtendimento(atendimento);

                /* Neste ponto, o atendente pode ter sido trocado
                 * durante o tratamento de evento.
                 * -- Júlio, 24/06/2006
                 */
                if (!atendimentoCancelado)
                {
                    atendente = atendimento.Atendente;

                    IniciarAtendimento(visita, atendente);
                    RealizarRodízio(atendente);
                }
            }

            return atendimento;
        }

        /// <summary>
        /// Chamado ao encerrar um atendimento.
        /// </summary>
        public override void EncerrarAtendimento(Visita visita)
        {
            if (visita.Atendente != null && !visita.AtendimentoForaDoRodízio)
                RealizarRodízio(visita.Atendente);
        }
    }
}
