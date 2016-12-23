using System;
using System.Collections.Generic;

namespace Entidades.Fiscal.Fabricação
{
    public class ControladorFabricaçãoAutomática
    {
        private FabricaçãoFiscal fabricação;
        private Fechamento fechamento;
        private Dictionary<string, MercadoriaFechamento> hashMercadoriaFechamento;
        private Dictionary<string, Inventário> hashInventário;

        public ControladorFabricaçãoAutomática(FabricaçãoFiscal fabricação)
        {
            this.fabricação = fabricação;
            this.fechamento = Fechamento.Obter(fabricação.Data);
            this.hashMercadoriaFechamento = MercadoriaFechamento.ObterHash(fechamento.Código);
            this.hashInventário = Inventário.ObterHash(fechamento);
        }

        public List<SaídaFabricaçãoFiscal> CalcularProduçãoNecessária(List<DocumentoFiscal> entidades)
        {
            var resultado = new List<SaídaFabricaçãoFiscal>();
            var saídasAgrupadas = DocumentoFiscal.Agrupar(entidades, hashMercadoriaFechamento);

            foreach (SaídaFabricaçãoFiscal item in saídasAgrupadas.Values)
            {
                var itemProduzido = CalcularProdução(item);

                if (itemProduzido != null)
                    resultado.Add(itemProduzido);
            }

            return CalcularValores(resultado);
        }

        private List<SaídaFabricaçãoFiscal> CalcularValores(List<SaídaFabricaçãoFiscal> entidades)
        {
            foreach (SaídaFabricaçãoFiscal saída in entidades)
            {
                var mercadoria = hashMercadoriaFechamento[saída.Referência];
                saída.Valor = mercadoria.DePeso ? saída.Peso * mercadoria.Valor : mercadoria.Valor;
            }

            return entidades;
        }

        private SaídaFabricaçãoFiscal CalcularProdução(SaídaFabricaçãoFiscal item)
        {
            Inventário inventário = ObterItem(item);

            decimal qtdSaída = item.Quantidade;
            decimal qtdProduzir = qtdSaída;

            return qtdProduzir > 0 ? item : null;
        }

        private Inventário ObterItem(SaídaFabricaçãoFiscal item)
        {
            Inventário inventário;

            if (!hashInventário.TryGetValue(item.Referência, out inventário))
            {
                inventário = new Inventário();
                hashInventário[item.Referência] = inventário;
            }

            return inventário;
        }
    }
}
