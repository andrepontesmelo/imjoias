using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ConjuntoAgrupadoExcessão : ConjuntoAgrupado
    {
        public ConjuntoAgrupadoExcessão(StreamWriter escritor) : base(escritor)
        {
        }

        protected override Grupo CriarGrupo(string chave)
        {
            return new GrupoExcessão(chave, escritor);
        }
    }
}
