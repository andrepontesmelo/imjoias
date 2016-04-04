using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão
{
    public enum Comando : byte
    {
        /* NÃO MUDAR ORDEM! */
        ConsultarDisponibilidade,
        Candidatura,
        RequisitarImpressão,
        ImpressãoCompleta,
        ErroImpressão,
        RequisitarRelatório,
        // Acrescentar novos aqui!
        Desconhecido
    }
}
