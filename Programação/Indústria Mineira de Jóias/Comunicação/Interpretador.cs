using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Comunicação.Pacotes;

namespace Comunicação
{
    /// <summary>
    /// Interpreta os pacotes recebidos pela rede.
    /// </summary>
    /// <typeparam name="EstadoComunicação">Enumeração com os possíveis estados da comunicação.</typeparam>
    /// <typeparam name="Comando">Comando da comunicação.</typeparam>
    public abstract class Interpretador<EstadoComunicação, Comando>
    {
        private Dictionary<EstadoComunicação, Dictionary<Comando, IInterpretadorPacote<EstadoComunicação>>> interpretadores;
        private IComunicador sistema;

        protected internal IComunicador Sistema { set { sistema = value; } }

        /// <summary>
        /// Aloca todos os interpretadores de pacotes.
        /// </summary>
        public Interpretador()
        {
            interpretadores = new Dictionary<EstadoComunicação, Dictionary<Comando, IInterpretadorPacote<EstadoComunicação>>>();

            //if (sistema is Servidor.Serviço)
            //{
            //    AdicionarInterpretador(EstadoComunicação.UDP, Comando.ConsultarDisponibilidade, new InterpretadorConsultaDisponibilidade());
            //    AdicionarInterpretador(EstadoComunicação.Normal, Comando.RequisitarImpressão, new InterpretadorRequisiçãoImpressão());
            //}
            //else if (sistema is Cliente.ControleImpressão)
            //{
            //    AdicionarInterpretador(EstadoComunicação.UDP, Comando.Candidatura, new InterpretadorCandidatura());
            //    AdicionarInterpretador(EstadoComunicação.Normal, Comando.ImpressãoCompleta, new InterpretadorImpressãoCompleta());
            //    AdicionarInterpretador(EstadoComunicação.Normal, Comando.ErroImpressão, new InterpretadorErroImpressão());
            //}
            //else
            //    throw new NotSupportedException();
        }

        /// <summary>
        /// Adiciona um interpretador à hash.
        /// </summary>
        /// <param name="estado">Estado da comunicação necessária para tratar o comando.</param>
        /// <param name="comando">Comando a ser tratado.</param>
        /// <param name="interpretador">Interpretador a ser utilizado.</param>
        protected void AdicionarInterpretador(
            EstadoComunicação estado, Comando comando, object interpretador)
        {
            Dictionary<Comando, IInterpretadorPacote<EstadoComunicação>> interpEstado;

            if (!interpretadores.TryGetValue(estado, out interpEstado))
                interpretadores[estado] = interpEstado = new Dictionary<Comando, IInterpretadorPacote<EstadoComunicação>>();

            interpEstado[comando] = (IInterpretadorPacote<EstadoComunicação>)interpretador;
        }

        /// <summary>
        /// Interpreta um buffer, encaminhando o pacote para
        /// o seu respectivo interpretador.
        /// </summary>
        /// <param name="buffer">Buffer recebido.</param>
        /// <param name="qtd">Tamanho do buffer.</param>
        /// <returns>Quantidade de bytes utilizados.</returns>
        public unsafe int Interpretar(DadosConexão<EstadoComunicação> sck, EndPoint remoto, byte[] buffer, int offset, int qtd)
        {
            if (qtd >= 2)
            {
                fixed (byte* fptr = buffer)
                {
                    byte* ptr = fptr + offset;
                    Cabeçalho* cabeçalho = (Cabeçalho*)ptr;
                    byte* dados = ptr + sizeof(Cabeçalho);
                    Dictionary<Comando, IInterpretadorPacote<EstadoComunicação>> interpEstado;

                    if (interpretadores.TryGetValue(sck.Estado, out interpEstado))
                    {
                        IInterpretadorPacote<EstadoComunicação> interpretador;

                        if (interpEstado.TryGetValue(ExtrairComando(dados), out interpretador))
                            return interpretador.Interpretar(sistema, sck, remoto, ptr, qtd);
                        else
                            Console.WriteLine("Comando desconhecido no estado atual!");
                    }
                }
            }

            // Falha!
            return 0;
        }

        protected abstract unsafe Comando ExtrairComando(byte* dados);
    }
}
