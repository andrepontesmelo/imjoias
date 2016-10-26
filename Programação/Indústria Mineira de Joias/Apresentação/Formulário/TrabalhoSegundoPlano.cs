using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Classe abstrata para criação de um trabalho em
    /// segundo plano.
    /// </summary>
    public abstract class TrabalhoSegundoPlano
    {
        protected volatile bool trabalhando = false;
#if DEBUG
        protected DateTime dtInício;
#endif

        private delegate void AsyncTrabalho();
        private AsyncTrabalho métodoTrabalho;
        private AsyncCallback callbackTrabalho;

        public event EventHandler TrabalhoTerminado;

        public TrabalhoSegundoPlano()
        {
            métodoTrabalho = new AsyncTrabalho(RealizarTrabalho);
            callbackTrabalho = new AsyncCallback(CallbackRealizarTrabalho);
        }

        /// <summary>
        /// Inicia o trabalho em segundo plano,
        /// se já não estiver em execução.
        /// </summary>
        public void IniciarTrabalho()
        {
            lock (this)
                if (!trabalhando)
                {
                    métodoTrabalho.BeginInvoke(callbackTrabalho, null);
                    trabalhando = true;
#if DEBUG
                    Console.WriteLine("Iniciando trabalho em segundo plano...");
                    dtInício = DateTime.Now;
#endif
                }
        }

        /// <summary>
        /// Realiza o trabalho em segundo plano.
        /// </summary>
        protected abstract void RealizarTrabalho();

        /// <summary>
        /// Chamado ao terminar de executar o método em segundo plano.
        /// </summary>
        /// <param name="resultado"></param>
        private void CallbackRealizarTrabalho(IAsyncResult resultado)
        {
            métodoTrabalho.EndInvoke(resultado);

#if DEBUG
            TimeSpan ts = DateTime.Now - dtInício;
            Console.WriteLine("Terminado trabalho em segundo plano: {0} ms", ts.Milliseconds);
#endif
            lock (this)
            {
                trabalhando = false;

                if (DeveReiniciar())
                {
#if DEBUG
                    Console.WriteLine("Reiniciando trabalho em segundo plano...");
#endif
                    IniciarTrabalho();
                }
            }

            AoTerminar();
        }

        /// <summary>
        /// Verifica se o processo deve ser reiniciado.
        /// </summary>
        protected virtual bool DeveReiniciar()
        {
            return false;
        }

        /// <summary>
        /// Ocorre ao terminar processamento em segundo plano.
        /// </summary>
        protected virtual void AoTerminar()
        {
            if (TrabalhoTerminado != null)
                TrabalhoTerminado(this, EventArgs.Empty);
        }
    }
}
