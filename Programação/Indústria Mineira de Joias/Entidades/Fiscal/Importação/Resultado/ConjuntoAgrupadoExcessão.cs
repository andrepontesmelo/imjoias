using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ConjuntoAgrupadoExceção : ConjuntoAgrupado
    {
        public ConjuntoAgrupadoExceção(StreamWriter escritor) : base(escritor)
        {
        }

        protected override Grupo CriarGrupo(string chave)
        {
            return new GrupoExceção(chave, escritor);
        }
    }
}
