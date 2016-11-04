using System;

namespace Entidades.Fiscal.Tipo
{
    public class TipoUnidadeInterpretação
    {
        public static TipoUnidadeSistema Interpretar(string descrição)
        {
            if (descrição.ToLower().StartsWith("gr"))
                return TipoUnidadeSistema.Grs;

            if (descrição.ToLower().StartsWith("pc") || 
                    descrição.ToLower().CompareTo("peca") == 0)
                return TipoUnidadeSistema.Pca;

            if (descrição.ToLower().StartsWith("bob"))
                return TipoUnidadeSistema.Un;

            if (descrição.ToLower().StartsWith("ca7"))
                return TipoUnidadeSistema.Pca;


            return (TipoUnidadeSistema) Enum.Parse(typeof(TipoUnidadeSistema), descrição, true);
        }
    }
}
