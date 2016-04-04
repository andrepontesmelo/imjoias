using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Apresentação.Impressão.Servidor;
using System.Net.Sockets;

namespace Apresentação.Impressão.Pacotes
{
    /// <summary>
    /// Interpreta uma requisição de impressão.
    /// </summary>
    class InterpretadorConsultaDisponibilidade : InterpretadorPacote<Serviço, ConsultaDisponibilidade>
    {
        protected override unsafe void Interpretar(Serviço servidor, DadosConexão sck, EndPoint origem, byte* buffer)
        {
            ConsultaDisponibilidade* pacote = (ConsultaDisponibilidade*)buffer;

            servidor.CandidatarSe(origem, pacote->Tipo);
        }
    }
}
