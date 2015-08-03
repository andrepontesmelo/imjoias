
using System;
using System.Collections.Generic;
using Entidades;
using Entidades.Pessoa;
using Entidades.Configuração;

namespace Negócio
{
    /// <summary>
    /// Controle de rodízio de atendentes para um determinado setor de atendimento,
    /// sendo que o primeiro a atender é o próximo (PAtP).
    /// </summary>
    public class RodízioPAtP : Rodízio
    {
        public RodízioPAtP(Setor setor)
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
            Atendimento atendimento;

            visita = Visita.ObterPróximaVisitaEsperando(setor);
            atendente = ObterPróximoAtendenteDisponível();

            if (visita != null && atendente != null)
            {
                atendimento = new Atendimento(visita, atendente);

                if (ConfirmarAtendimento(atendimento))
                {

                    /* Neste ponto, o atendente pode ter sido trocado
                     * durante o tratamento de evento.
                     * -- Júlio, 24/06/2006
                     */
                    atendente = atendimento.Atendente;

                    IniciarAtendimento(visita, atendente);
                    RealizarRodízio(atendente);
                }
                return atendimento;
            }
            else
                return null;
        }
    }
}
