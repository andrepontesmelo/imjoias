using System.Collections.Generic;

namespace Entidades.Fiscal.Fabricação
{
    public class ApuradorFabricação
    {
        private Dictionary<string, Inventário> hashInventário;
        FabricaçãoFiscal fabricação;

        public ApuradorFabricação(FabricaçãoFiscal fabricação)
        {
            this.fabricação = fabricação;
            var fechamento = Fechamento.Obter(fabricação.Data);
            hashInventário = Inventário.ObterHash(fechamento);
        }

        public decimal ObterInventário(ItemFabricaçãoFiscal item)
        {
            Inventário i;
            return hashInventário.TryGetValue(item.Referência, out i) ? i.Quantidade : 0;
        }

        public decimal ObterInventárioAnterior(ItemFabricaçãoFiscal item)
        {
            return ObterInventário(item) - item.Quantidade;
        }

        public decimal ObterApuração(ItemFabricaçãoFiscal item)
        {
            return ObterInventário(item) - 2 * item.Quantidade;
        }
    }
}
