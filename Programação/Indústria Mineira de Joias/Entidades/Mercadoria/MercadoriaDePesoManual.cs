using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Mercadoria
{
    public class MercadoriaDePesoManual : DbManipulaçãoSimples
    {
        private string referencia;

        private static HashSet<string> hash = null;

        public static HashSet<string> Hash
        {
            get
            {
                if (hash == null)
                    hash = CarregarHash();

                return hash;
            }
        }

        public MercadoriaDePesoManual()
        {
        }

        public static bool PesoManual(string referênciaNumérica)
        {
            return Hash.Contains(referênciaNumérica);
        }

        private static HashSet<string> CarregarHash()
        {
            HashSet<string> resultado = new HashSet<string>();
            List<MercadoriaDePesoManual> lista = Mapear<MercadoriaDePesoManual>("select referencia from mercadoria_depeso");

            foreach (MercadoriaDePesoManual mercadoria in lista)
                resultado.Add(mercadoria.referencia);

            return resultado;
        }
    }
}
