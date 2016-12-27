using Entidades.Fiscal.Exceções;
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
            this.fechamento = fabricação.Fechamento;

            if (fechamento == null)
                throw new FechamentoInexistente(fabricação.Data);

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

            return AbribuirCFOPMovimentaçãoInterna(CalcularValores(resultado));
        }

        private List<SaídaFabricaçãoFiscal> AbribuirCFOPMovimentaçãoInterna(List<SaídaFabricaçãoFiscal> entidades)
        {
            var cfop = FabricaçãoFiscal.CfopPadrãoOperaçõesInternasTO.Valor;

            foreach (var entidade in entidades)
                entidade.CFOP = cfop;

            return entidades;
        }

        private List<SaídaFabricaçãoFiscal> CalcularValores(List<SaídaFabricaçãoFiscal> entidades)
        {
            foreach (var entidade in entidades)
            {
                var mercadoria = hashMercadoriaFechamento[entidade.Referência];
                entidade.Valor = mercadoria.DePeso ? entidade.Peso * mercadoria.Valor : mercadoria.Valor;
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
