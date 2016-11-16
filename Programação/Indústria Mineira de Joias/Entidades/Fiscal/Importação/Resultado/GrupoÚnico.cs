using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class GrupoÚnico : Grupo
    {
        public GrupoÚnico(StreamWriter escritor) : base(escritor)
        {
        }

        internal override string Título => "";
    }
}
