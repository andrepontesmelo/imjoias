using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using Comunicação.Pacotes;

namespace Comunicação
{
    public interface IInterpretadorPacote<EstadoComunicação>
    {
        unsafe int Interpretar(IComunicador sistema, DadosConexão<EstadoComunicação> sck, EndPoint origem, byte* buffer, int qtd);
    }

    public abstract class InterpretadorPacote<TPacote, EstadoComunicação> 
        : IInterpretadorPacote<EstadoComunicação>
        where TPacote : struct
    {
        /// <summary>
        /// Interpreta o pacote.
        /// </summary>
        /// <param name="pacote">Pacote a ser interpretado.</param>
        /// <returns>Quantidade de bytes utilizados.</returns>
        public unsafe int Interpretar(IComunicador sistema, DadosConexão<EstadoComunicação> conexão, EndPoint remoto, byte* buffer, int qtd)
        {
            int tpacote = Marshal.SizeOf(typeof(TPacote));

            if (qtd >= tpacote)
            {
#if DEBUG
                Console.WriteLine("Interpretando pacote do tipo {0} de {1} bytes",
                    typeof(TPacote).Name, tpacote);
#endif
                Cabeçalho* cabeçalho = (Cabeçalho*)buffer;
                byte chksum = 0;

                // Validar o checksum.
                for (int i = tpacote - sizeof(Cabeçalho); i < tpacote; i++)
                    chksum ^= (byte)unchecked(buffer[i] + (byte)i);

                if (cabeçalho->chksum == chksum)
                {
                    Interpretar(sistema, conexão, remoto, buffer);
                    return tpacote;
                }
                else
                {
                    Console.WriteLine("Erro de checksum!");
                    return 0;
                }
            }
            else
            {
                Console.Error.WriteLine("Tamanho do pacote inválido para {0}.", typeof(TPacote).Name);
                return 0;
            }
        }

        protected abstract unsafe void Interpretar(
            IComunicador sistema, DadosConexão<EstadoComunicação> conexão, EndPoint origem, byte* buffer);
    }
}
