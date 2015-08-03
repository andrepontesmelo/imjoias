using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

namespace Apresentação.Impressão.Pacotes
{
    interface IInterpretadorPacote<TSistema>
    {
        unsafe int Interpretar(TSistema sistema, DadosConexão sck, EndPoint origem, byte* buffer, int qtd);
    }

    abstract class InterpretadorPacote<TSistema, TPacote> : IInterpretadorPacote<TSistema> where TPacote: struct
    {
        /// <summary>
        /// Interpreta o pacote.
        /// </summary>
        /// <param name="pacote">Pacote a ser interpretado.</param>
        /// <returns>Quantidade de bytes utilizados.</returns>
        public unsafe int Interpretar(TSistema sistema, DadosConexão conexão, EndPoint remoto, byte* buffer, int qtd)
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
                for (int i = 1; i < tpacote; i++)
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
                Console.WriteLine("Tamanho do pacote inválido para {0}.", typeof(TPacote).Name);
                return 0;
            }
        }

        protected abstract unsafe void Interpretar(TSistema sistema, DadosConexão conexão, EndPoint origem, byte* buffer);
    }
}
