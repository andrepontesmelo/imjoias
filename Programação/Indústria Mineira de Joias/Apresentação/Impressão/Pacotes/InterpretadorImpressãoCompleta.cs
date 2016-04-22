using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão.Pacotes
{
    class InterpretadorImpressãoCompleta : InterpretadorPacote<Cliente.ControleImpressão, ImpressãoCompleta>
    {
        protected override unsafe void Interpretar(Apresentação.Impressão.Cliente.ControleImpressão sistema, DadosConexão sck, System.Net.EndPoint origem, byte* buffer)
        {
            ImpressãoCompleta* pacote = (ImpressãoCompleta*)buffer;

            sistema.DispararImpressãoCompleta(pacote->Tipo, pacote->Código);
        }
    }
}
