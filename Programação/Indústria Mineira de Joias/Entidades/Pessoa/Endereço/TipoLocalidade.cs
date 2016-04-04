using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Pessoa.Endereço
{
    /* ATENÇÃO: Não mudar a numeração!!!
     * Risco de corromper o banco de dados.
     */
    public enum TipoLocalidade
    {
        Desconhecido = 0,
        Município = 1,
        Distrito = 2,
        Povoado = 3,
        RegiãoAdministrativa = 4
    }
}
