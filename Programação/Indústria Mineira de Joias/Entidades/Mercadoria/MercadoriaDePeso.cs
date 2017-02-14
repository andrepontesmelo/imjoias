using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Mercadoria
{
    public class MercadoriaDePeso : DbManipulaçãoSimples
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

        public MercadoriaDePeso()
        {
        }

        private static HashSet<string> CarregarHash()
        {
            HashSet<string> resultado = new HashSet<string>();
            List<MercadoriaDePeso> lista = Mapear<MercadoriaDePeso>("select referencia from mercadoria_depeso");

            foreach (MercadoriaDePeso mercadoria in lista)
                resultado.Add(mercadoria.referencia);

            return resultado;
        }
    }
}
