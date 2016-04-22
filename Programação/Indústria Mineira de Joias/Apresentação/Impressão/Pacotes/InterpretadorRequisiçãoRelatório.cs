using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Apresentação.Impressão.Estado;

namespace Apresentação.Impressão.Pacotes
{
    class InterpretadorRequisiçãoRelatório : InterpretadorPacote<Servidor.Serviço, RequisiçãoRelatório>
    {
        protected override unsafe void Interpretar(Apresentação.Impressão.Servidor.Serviço sistema, DadosConexão cliente, System.Net.EndPoint origem, byte* buffer)
        {
            RequisiçãoRelatório* pacote = (RequisiçãoRelatório*)buffer;

            if (cliente != null)
            {
                DadosRelatório dados = new DadosRelatório(pacote->Tipo, pacote->PeríodoInicial, pacote->PeríodoFinal, pacote->ApenasConserto, pacote->PeríodoPrevisão);
                dados.Cópias = pacote->Cópias;
                dados.Collated = pacote->Collated;
                dados.PágInicial = pacote->PágInicial;
                dados.PágFinal = pacote->PágFinal;
                dados.ApenasConsertos = pacote->ApenasConserto;

                sistema.Imprimir(cliente, pacote->Nome, dados);
            }
            else
                Console.WriteLine("Requisições de impressão via UDP não são permitidas.");
        }
    }
}