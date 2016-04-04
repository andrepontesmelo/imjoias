using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Apresentação.Impressão.Estado;

namespace Apresentação.Impressão.Pacotes
{
    class InterpretadorRequisiçãoImpressão : InterpretadorPacote<Servidor.Serviço, RequisiçãoImpressão>
    {
        protected override unsafe void Interpretar(Apresentação.Impressão.Servidor.Serviço sistema, DadosConexão cliente, System.Net.EndPoint origem, byte* buffer)
        {
            RequisiçãoImpressão* pacote = (RequisiçãoImpressão*)buffer;

            if (cliente != null)
            {
                DadosDocumento dados = new DadosDocumento(pacote->Tipo, pacote->CódigoDocumento);
                dados.Cópias = pacote->Cópias;
                dados.Collated = pacote->Collated;
                dados.PágInicial = pacote->PágInicial;
                dados.PágFinal = pacote->PágFinal;

                //if (pacote->Tipo == TipoDocumento.Pedido)
                //    throw new NotSupportedException("Não é possível imprimir pedido pela requisição de impressão padrão.");

                //if (pacote->Tipo == TipoDocumento.Acerto)
                //{
                //    cliente.ObjEstado = new Estado.EstadoAcerto(dados, pacote->Nome);
                //    cliente.Estado = EstadoComunicação.PreparandoAcerto;
                //}
                //else
                    sistema.Imprimir(cliente, pacote->Nome, dados);
            }
            else
                Console.WriteLine("Requisições de impressão via UDP não são permitidas.");
        }
    }
}
