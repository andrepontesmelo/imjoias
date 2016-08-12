using Acesso.Comum;
using Acesso.Comum.Cache;

namespace Entidades.Moedas
{
    public class MoedaObtenção : Moeda
    {
        private static MoedaObtenção instância;

        private MoedaObtenção()
        {
        }

        public static MoedaObtenção Instância
        {
            get
            {
                if (instância == null)
                    instância = new MoedaObtenção();

                return instância;
            }
        }

        public virtual new Moeda ObterMoeda(uint código)
        {
            return MapearÚnicaLinha<Moeda>(
                "SELECT * FROM moeda WHERE codigo = " + DbTransformar(código));
        }

        public virtual new Moeda[] ObterMoedas()
        {
            return Mapear<Moeda>(
                "SELECT * FROM moeda ORDER BY nome").ToArray();
        }

        public virtual new Moeda ObterMoeda(MoedaSistema moeda)
        {
            return ObterMoeda((uint)moeda);
        }
    }
}
