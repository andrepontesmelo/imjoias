using System;

namespace Entidades.Fiscal.Tipo
{
    public class TipoUnidadeInterpretação
    {
        public static TipoUnidade Interpretar(string descrição)
        {
            if (descrição.ToLower().StartsWith("gr"))
                return TipoUnidade.Grs;

            if (descrição.ToLower().StartsWith("pc") || 
                    descrição.ToLower().CompareTo("peca") == 0)
                return TipoUnidade.Pca;

            return (TipoUnidade) Enum.Parse(typeof(TipoUnidade), descrição, true);
        }
    }
}
