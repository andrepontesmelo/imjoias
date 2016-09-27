using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ConjuntoAgrupadoMotivo : ConjuntoAgrupado
    {
        public ConjuntoAgrupadoMotivo(StreamWriter escritor) : base(escritor)
        {
        }

        protected override Grupo CriarGrupo(string chave)
        {
            Motivo motivo = (Motivo) Enum.Parse(typeof(Motivo), chave);
            return new GrupoMotivo(motivo, escritor);
        }
    }
}
