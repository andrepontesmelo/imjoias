using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão.Pacotes
{
    class InterpretadorErroImpressão : InterpretadorPacote<Cliente.ControleImpressão, ErroImpressão>
    {
        protected override unsafe void Interpretar(Apresentação.Impressão.Cliente.ControleImpressão sistema, DadosConexão conexão, System.Net.EndPoint origem, byte* buffer)
        {
            ErroImpressão* pacote = (ErroImpressão*)buffer;

            sistema.DispararErroImpressão(pacote->Tipo, pacote->Código);
        }
    }
}
