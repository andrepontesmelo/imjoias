using System.Collections.Generic;

namespace Entidades.Mercadoria.Componente
{
    public class VinculoMercadoriaComponenteFiscal : VinculoMercadoriaComponente
    {
        private static Dictionary<string, List<VinculoMercadoriaComponenteFiscal>> hashVinculos = null;

        public VinculoMercadoriaComponenteFiscal() { }
        public VinculoMercadoriaComponenteFiscal(string mercadoria, string componente, double quantidade) : base(mercadoria, componente, quantidade)
        {
        }

        public static List<VinculoMercadoriaComponenteFiscal> ObterVinculos(string mercadoria)
        {
            if (hashVinculos == null)
                CriarHashVinculos();

            List<VinculoMercadoriaComponenteFiscal> retorno = null;

            hashVinculos.TryGetValue(mercadoria, out retorno);

            return retorno;
        }

        private static void CriarHashVinculos()
        {
            List<VinculoMercadoriaComponenteFiscal> vinculos = Mapear<VinculoMercadoriaComponenteFiscal>("select * from vinculomercadoriacomponentefiscal");
            hashVinculos = new Dictionary<string, List<VinculoMercadoriaComponenteFiscal>>();

            foreach (VinculoMercadoriaComponenteFiscal vinculo in vinculos)
                ObterOuCriarListaLista(vinculo.Mercadoria).Add(vinculo);
        }

        private static List<VinculoMercadoriaComponenteFiscal> ObterOuCriarListaLista(string mercadoria)
        {
            List<VinculoMercadoriaComponenteFiscal> lista = null;

            if (!hashVinculos.TryGetValue(mercadoria, out lista))
            {
                lista = new List<VinculoMercadoriaComponenteFiscal>();
                hashVinculos[mercadoria] = lista;
            }

            return lista;
        }
    }
}

