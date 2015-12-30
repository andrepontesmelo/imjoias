using System;
using System.Collections.Generic;
using Entidades;
using Entidades.Pessoa;
using Entidades.Configuração;

namespace Negócio
{
    /// <summary>
    /// Controle de rodízio de atendentes para um determinado setor de atendimento.
    /// </summary>
    public abstract class Rodízio
    {
        /// <summary>
        /// Setor em que se realiza o rodízio.
        /// </summary>
        protected Setor setor;

        /// <summary>
        /// Fila de atendentes.
        /// </summary>
        protected LinkedList<Funcionário> atendentes;

        /// <summary>
        /// Contador utilizado para ordenar o rodízio no banco de dados.
        /// </summary>
        /// <remarks>
        /// Este contador não é utilizado pelo software, sendo utilizado para
        /// recuperação da ordem do rodízio.</remarks>
        protected uint contador = 0;

        public delegate bool AtendimentoCallback(Atendimento atendimento);

        /// <summary>
        /// Evento disparado para confirmar o próximo atendimento.
        /// </summary>
        /// <remarks>
        /// Alterações no atendente refletem diretamente no rodízio.
        /// </remarks>
        public event AtendimentoCallback ConfirmandoAtendimento;

        /// <summary>
        /// Constrói o controle de rodízio.
        /// </summary>
        /// <param name="setor">Setor de atendimento.</param>
        protected Rodízio(Setor setor)
        {
            //Funcionário[] vetor;

            this.setor = setor;
            this.atendentes = new LinkedList<Funcionário>(setor.ObterAtendentes());
            
            //    vetor = setor.ObterAtendentes();

            //foreach (Funcionário funcionário in vetor)
            //    atendentes.AddLast(funcionário);

            foreach (Funcionário funcionário in atendentes)
            {
                funcionário.Rodízio = contador++;
                funcionário.AtualizarRodízio();
            }
        }

        #region Singleton

        /// <summary>
        /// Hash para recuperação de instâncias únicas por código de setor.
        /// </summary>
        private static Dictionary<long, Rodízio> hashRodízio;

        /// <summary>
        /// Obtém a instância exclusiva de rodízio para um setor específico.
        /// </summary>
        /// <param name="setor">Setor cujo rodízio será obtido.</param>
        /// <returns>Rodízio do setor.</returns>
        public static Rodízio ObterRodízio(Setor setor)
        {
            Rodízio rodízio;

            if (hashRodízio == null)
                hashRodízio = new Dictionary<long, Rodízio>();

            if (hashRodízio.TryGetValue(setor.Código, out rodízio))
                return rodízio;
            

            ConfiguraçãoGlobal<string> tipoRodízio = new ConfiguraçãoGlobal<string>("Rodízio", "PAcP");
            ConfiguraçãoGlobal<string> tipoRodízioSetor = new ConfiguraçãoGlobal<string>("Rodízio - " + setor.Nome, tipoRodízio.Valor);

            if (string.Compare(tipoRodízioSetor.Valor, "PAcP", true) == 0)
                rodízio = new RodízioPAcP(setor);

            else if (string.Compare(tipoRodízioSetor.Valor, "PAtP", true) == 0)
                rodízio = new RodízioPAtP(setor);

            else
                rodízio = new RodízioPAcP(setor);

            hashRodízio.Add(setor.Código, rodízio);

            return rodízio;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Setor de atendimento.
        /// </summary>
        public Setor Setor { get { return setor; } }

        /// <summary>
        /// Lista de atendentes, ordenados pelo rodízio.
        /// </summary>
        public LinkedList<Funcionário> Atendentes
        {
            get { return atendentes; }
            set
            {
                atendentes = value;

                foreach (Funcionário funcionário in atendentes)
                {
                    funcionário.Rodízio = contador++;
                    funcionário.AtualizarRodízio();
                }
            }
        }

        #endregion

        /// <summary>
        /// Obtém o próximo atendimento.
        /// </summary>
        /// <returns></returns>
        public abstract Atendimento ObterPróximoAtendimento();

        /// <summary>
        /// Passa atendente para o final do rodízio.
        /// </summary>
        protected virtual void RealizarRodízio(Funcionário atendente)
        {
            atendente.Rodízio = contador++;
            atendente.AtualizarRodízio();
            atendentes.Remove(atendente);
            atendentes.AddLast(atendente);
        }

        /// <summary>
        /// Registra o início de atendimento do atendente ao cliente.
        /// </summary>
        protected static void IniciarAtendimento(Visita visita, Funcionário atendente)
        {
            atendente.Situação = EstadoFuncionário.Atendendo;

            if (!visita.Espera.HasValue)
                try
                {
                    visita.Espera = Convert.ToUInt32(((TimeSpan)(DadosGlobais.Instância.HoraDataAtual - visita.Entrada)).TotalSeconds);
                }
                catch (OverflowException)
                {
                    visita.Espera = UInt32.MaxValue;
                }

            visita.Atendente = atendente;
            visita.Atualizar();
        }

        /// <summary>
        /// Obtém o próximo atendente disponível.
        /// </summary>
        /// <returns>Próximo atendente disponível.</returns>
        protected virtual Funcionário ObterPróximoAtendenteDisponível()
        {
            foreach (Funcionário atendente in atendentes)
                if (atendente.Situação == EstadoFuncionário.Disponível || ((atendente.Situação == EstadoFuncionário.Desconhecido || atendente.Situação == EstadoFuncionário.Atendendo) && !atendente.EmAtendimento))
                    return atendente;

            return null;
        }

        public static void RegistrarAtendimento(Visita visita, Funcionário funcionário)
        {
            IniciarAtendimento(visita, funcionário);

            foreach (Rodízio rodízio in hashRodízio.Values)
                if (rodízio.Atendentes.Contains(funcionário))
                    rodízio.RealizarRodízio(funcionário);
        }

        /// <summary>
        /// Sinaliza o encerramento de um atendimento.
        /// </summary>
        /// <param name="visita"></param>
        public virtual void EncerrarAtendimento(Visita visita)
        {
        }

        /// <summary>
        /// Confirma atendimento a ser realizado, podendo
        /// alterar contúdo do parâmetro.
        /// </summary>
        /// <returns>
        /// Se foi aceito o atendimento.
        /// </returns>
        /// <param name="atendimento">Atendimento a ser iniciado.</param>
        protected bool ConfirmarAtendimento(Atendimento atendimento)
        {
            if (ConfirmandoAtendimento != null)
                return ConfirmandoAtendimento(atendimento);

            return false;
        }
    }
}
