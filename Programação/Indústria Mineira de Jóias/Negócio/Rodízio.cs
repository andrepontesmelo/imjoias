using System;
using System.Collections.Generic;
using Entidades;
using Entidades.Pessoa;
using Entidades.Configura��o;

namespace Neg�cio
{
    /// <summary>
    /// Controle de rod�zio de atendentes para um determinado setor de atendimento.
    /// </summary>
    public abstract class Rod�zio
    {
        /// <summary>
        /// Setor em que se realiza o rod�zio.
        /// </summary>
        protected Setor setor;

        /// <summary>
        /// Fila de atendentes.
        /// </summary>
        protected LinkedList<Funcion�rio> atendentes;

        /// <summary>
        /// Contador utilizado para ordenar o rod�zio no banco de dados.
        /// </summary>
        /// <remarks>
        /// Este contador n�o � utilizado pelo software, sendo utilizado para
        /// recupera��o da ordem do rod�zio.</remarks>
        protected uint contador = 0;

        public delegate bool AtendimentoCallback(Atendimento atendimento);

        /// <summary>
        /// Evento disparado para confirmar o pr�ximo atendimento.
        /// </summary>
        /// <remarks>
        /// Altera��es no atendente refletem diretamente no rod�zio.
        /// </remarks>
        public event AtendimentoCallback ConfirmandoAtendimento;

        /// <summary>
        /// Constr�i o controle de rod�zio.
        /// </summary>
        /// <param name="setor">Setor de atendimento.</param>
        protected Rod�zio(Setor setor)
        {
            //Funcion�rio[] vetor;

            this.setor = setor;
            this.atendentes = new LinkedList<Funcion�rio>(setor.ObterAtendentes());
            
            //    vetor = setor.ObterAtendentes();

            //foreach (Funcion�rio funcion�rio in vetor)
            //    atendentes.AddLast(funcion�rio);

            foreach (Funcion�rio funcion�rio in atendentes)
            {
                funcion�rio.Rod�zio = contador++;
                funcion�rio.AtualizarRod�zio();
            }
        }

        #region Singleton

        /// <summary>
        /// Hash para recupera��o de inst�ncias �nicas por c�digo de setor.
        /// </summary>
        private static Dictionary<long, Rod�zio> hashRod�zio;

        /// <summary>
        /// Obt�m a inst�ncia exclusiva de rod�zio para um setor espec�fico.
        /// </summary>
        /// <param name="setor">Setor cujo rod�zio ser� obtido.</param>
        /// <returns>Rod�zio do setor.</returns>
        public static Rod�zio ObterRod�zio(Setor setor)
        {
            Rod�zio rod�zio;

            if (hashRod�zio == null)
                hashRod�zio = new Dictionary<long, Rod�zio>();

            if (hashRod�zio.TryGetValue(setor.C�digo, out rod�zio))
                return rod�zio;
            

            Configura��oGlobal<string> tipoRod�zio = new Configura��oGlobal<string>("Rod�zio", "PAcP");
            Configura��oGlobal<string> tipoRod�zioSetor = new Configura��oGlobal<string>("Rod�zio - " + setor.Nome, tipoRod�zio.Valor);

            if (string.Compare(tipoRod�zioSetor.Valor, "PAcP", true) == 0)
                rod�zio = new Rod�zioPAcP(setor);

            else if (string.Compare(tipoRod�zioSetor.Valor, "PAtP", true) == 0)
                rod�zio = new Rod�zioPAtP(setor);

            else
                rod�zio = new Rod�zioPAcP(setor);

            hashRod�zio.Add(setor.C�digo, rod�zio);

            return rod�zio;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Setor de atendimento.
        /// </summary>
        public Setor Setor { get { return setor; } }

        /// <summary>
        /// Lista de atendentes, ordenados pelo rod�zio.
        /// </summary>
        public LinkedList<Funcion�rio> Atendentes
        {
            get { return atendentes; }
            set
            {
                atendentes = value;

                foreach (Funcion�rio funcion�rio in atendentes)
                {
                    funcion�rio.Rod�zio = contador++;
                    funcion�rio.AtualizarRod�zio();
                }
            }
        }

        #endregion

        /// <summary>
        /// Obt�m o pr�ximo atendimento.
        /// </summary>
        /// <returns></returns>
        public abstract Atendimento ObterPr�ximoAtendimento();

        /// <summary>
        /// Passa atendente para o final do rod�zio.
        /// </summary>
        protected virtual void RealizarRod�zio(Funcion�rio atendente)
        {
            atendente.Rod�zio = contador++;
            atendente.AtualizarRod�zio();
            atendentes.Remove(atendente);
            atendentes.AddLast(atendente);
        }

        /// <summary>
        /// Registra o in�cio de atendimento do atendente ao cliente.
        /// </summary>
        protected static void IniciarAtendimento(Visita visita, Funcion�rio atendente)
        {
            atendente.Situa��o = EstadoFuncion�rio.Atendendo;

            if (!visita.Espera.HasValue)
                try
                {
                    visita.Espera = Convert.ToUInt32(((TimeSpan)(DadosGlobais.Inst�ncia.HoraDataAtual - visita.Entrada)).TotalSeconds);
                }
                catch (OverflowException)
                {
                    visita.Espera = UInt32.MaxValue;
                }

            visita.Atendente = atendente;
            visita.Atualizar();
        }

        /// <summary>
        /// Obt�m o pr�ximo atendente dispon�vel.
        /// </summary>
        /// <returns>Pr�ximo atendente dispon�vel.</returns>
        protected virtual Funcion�rio ObterPr�ximoAtendenteDispon�vel()
        {
            foreach (Funcion�rio atendente in atendentes)
                if (atendente.Situa��o == EstadoFuncion�rio.Dispon�vel || ((atendente.Situa��o == EstadoFuncion�rio.Desconhecido || atendente.Situa��o == EstadoFuncion�rio.Atendendo) && !atendente.EmAtendimento))
                    return atendente;

            return null;
        }

        public static void RegistrarAtendimento(Visita visita, Funcion�rio funcion�rio)
        {
            IniciarAtendimento(visita, funcion�rio);

            foreach (Rod�zio rod�zio in hashRod�zio.Values)
                if (rod�zio.Atendentes.Contains(funcion�rio))
                    rod�zio.RealizarRod�zio(funcion�rio);
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
        /// alterar cont�do do par�metro.
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
