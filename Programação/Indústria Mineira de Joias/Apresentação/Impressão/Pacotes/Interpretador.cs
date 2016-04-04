using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Apresentação.Impressão.Estado;
using System.Diagnostics;

namespace Apresentação.Impressão.Pacotes
{
    /// <summary>
    /// Interpreta os pacotes recebidos pela rede.
    /// </summary>
    class Interpretador<TSistema>
    {
        private Dictionary<EstadoComunicação, Dictionary<Comando, IInterpretadorPacote<TSistema>>> interpretadores = new Dictionary<EstadoComunicação, Dictionary<Comando, IInterpretadorPacote<TSistema>>>();
        private TSistema sistema;

        /// <summary>
        /// Aloca todos os interpretadores de pacotes.
        /// </summary>
        public Interpretador(TSistema sistema)
        {
            this.sistema = sistema;

            if (sistema is Servidor.Serviço)
            {
                AdicionarInterpretador(EstadoComunicação.UDP, Comando.ConsultarDisponibilidade, new InterpretadorConsultaDisponibilidade());
                AdicionarInterpretador(EstadoComunicação.Normal, Comando.RequisitarImpressão, new InterpretadorRequisiçãoImpressão());
                AdicionarInterpretador(EstadoComunicação.Normal, Comando.RequisitarRelatório, new InterpretadorRequisiçãoRelatório());
            }
            else if (sistema is Cliente.ControleImpressão)
            {
                AdicionarInterpretador(EstadoComunicação.UDP, Comando.Candidatura, new InterpretadorCandidatura());
                AdicionarInterpretador(EstadoComunicação.Normal, Comando.ImpressãoCompleta, new InterpretadorImpressãoCompleta());
                AdicionarInterpretador(EstadoComunicação.Normal, Comando.ErroImpressão, new InterpretadorErroImpressão());
            }
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Adiciona um interpretador à hash.
        /// </summary>
        /// <param name="estado">Estado da comunicação necessária para tratar o comando.</param>
        /// <param name="comando">Comando a ser tratado.</param>
        /// <param name="interpretador">Interpretador a ser utilizado.</param>
        private void AdicionarInterpretador(EstadoComunicação estado, Comando comando, object interpretador)
        {
            Dictionary<Comando, IInterpretadorPacote<TSistema>> interpEstado;

            if (!interpretadores.TryGetValue(estado, out interpEstado))
                interpretadores[estado] = interpEstado = new Dictionary<Comando, IInterpretadorPacote<TSistema>>();

            interpEstado[comando] = (IInterpretadorPacote<TSistema>)interpretador;
        }

        /// <summary>
        /// Interpreta um buffer, encaminhando o pacote para
        /// o seu respectivo interpretador.
        /// </summary>
        /// <param name="buffer">Buffer recebido.</param>
        /// <param name="qtd">Tamanho do buffer.</param>
        /// <returns>Quantidade de bytes utilizados.</returns>
        public unsafe int Interpretar(DadosConexão sck, EndPoint remoto, byte[] buffer, int offset, int qtd)
        {
            if (qtd >= 2)
            {
                fixed (byte* fptr = buffer)
                {
                    byte* ptr = fptr + offset;
                    Cabeçalho* cabeçalho = (Cabeçalho*)ptr;
                    Dictionary<Comando, IInterpretadorPacote<TSistema>> interpEstado;

                    if (interpretadores.TryGetValue(sck != null ? sck.Estado : EstadoComunicação.UDP, out interpEstado))
                    {
                        IInterpretadorPacote<TSistema> interpretador;

                        if (interpEstado.TryGetValue(cabeçalho->comando, out interpretador))
                            return interpretador.Interpretar(sistema, sck, remoto, ptr, qtd);
                        else
                        {
                            Console.WriteLine("Comando desconhecido no estado atual!");
                            Debug.Fail("Comando desconhecido");
                        }
                    }
                }
            }

            // Falha!
            return 0;
        }
    }
}
