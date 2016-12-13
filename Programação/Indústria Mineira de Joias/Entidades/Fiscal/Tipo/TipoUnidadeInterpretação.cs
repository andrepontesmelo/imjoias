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

            if (descrição.ToLower().StartsWith("cxa"))
                return TipoUnidadeSistema.Cxa;

            if (descrição.ToLower().StartsWith("par"))
                return TipoUnidadeSistema.Par;

            if (descrição.ToLower().StartsWith("klt"))
                return TipoUnidadeSistema.Klt;

            TipoUnidadeSistema tipo;
            if (!Enum.TryParse<TipoUnidadeSistema>(descrição, out tipo))
                tipo = TipoUnidadeSistema.Un;

            return tipo;
        }
    }
}
