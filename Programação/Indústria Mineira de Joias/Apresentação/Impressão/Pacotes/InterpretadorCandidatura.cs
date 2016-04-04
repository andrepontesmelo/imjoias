using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Impressão.Cliente;
using System.Net.Sockets;

namespace Apresentação.Impressão.Pacotes
{
    class InterpretadorCandidatura : InterpretadorPacote<ControleImpressão, Candidatura>
    {
        protected override unsafe void Interpretar(ControleImpressão sistema, DadosConexão sck, System.Net.EndPoint origem, byte* buffer)
        {
            Candidatura* pacote = (Candidatura*)buffer;

            if (sistema.Tipo == pacote->Tipo)
                sistema.AvaliarCandidatura(origem, new DadosCandidatura(
                    pacote->Máquina, pacote->Nome,
                    pacote->CPU, pacote->RAM,
                    pacote->Velocidade, pacote->Colorido));
        }
    }
}
