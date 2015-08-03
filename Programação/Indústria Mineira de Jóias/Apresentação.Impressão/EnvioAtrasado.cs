using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Apresentação.Impressão
{
    /// <summary>
    /// Controla o envio atrasado de mensagens para destinatários.
    /// </summary>
    class EnvioAtrasado : IDisposable
    {
        struct Dados
        {
            public byte[] buffer;
            public EndPoint destino;
            public DateTime quando;

            public Dados(EndPoint destino, byte[] buffer, DateTime quando)
            {
                this.destino = destino;
                this.buffer = buffer;
                this.quando = quando;
            }
        }

        private List<Dados> dados = new List<Dados>();
        private Socket sck;

        public EnvioAtrasado(Socket sck)
        {
            this.sck = sck;
        }

        public void Atrasar(IPEndPoint destino, byte[] buffer, int milissegundos)
        {
            DateTime quando = DateTime.Now.AddMilliseconds(milissegundos);

            lock (dados)
            {
                dados.Add(new Dados(new IPEndPoint(destino.Address, destino.Port), buffer, quando));

                if (dados.Count == 1)
                {
                    Thread thread = new Thread(new ThreadStart(ThreadEnvio));
                    thread.Name = "Envio atrasado de pacotes";
                    thread.IsBackground = true;
                    thread.Priority = ThreadPriority.AboveNormal;
                    thread.Start();
                }
            }
        }

        private void ThreadEnvio()
        {
            bool continuar;

            do
            {
                Dados próximo = dados[0];
                TimeSpan espera;

                lock (dados)
                    foreach (Dados dado in dados)
                        if (próximo.quando > dado.quando)
                            próximo = dado;

                espera = próximo.quando - DateTime.Now;

                if (espera.TotalMilliseconds > 0)
                    Thread.Sleep(espera);

                sck.SendTo(próximo.buffer, próximo.destino);

                lock (dados)
                {
                    dados.Remove(próximo);
                    continuar = dados.Count > 0;
                }
            } while (continuar);
        }

        #region IDisposable Members

        public void Dispose()
        {
            dados.Clear();
        }

        #endregion
    }
}
