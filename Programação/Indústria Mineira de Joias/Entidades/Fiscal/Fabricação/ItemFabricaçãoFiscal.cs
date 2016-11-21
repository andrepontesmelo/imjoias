using Acesso.Comum;
using System;

namespace Entidades.Fiscal.Fabricação
{
    public class ItemFabricaçãoFiscal : DbManipulaçãoSimples, IEquatable<ItemFabricaçãoFiscal>
    {
        protected string referencia;
        protected decimal quantidade;

        public string Referência => referencia;
        public decimal Quantidade => quantidade;

        public Mercadoria.Mercadoria Mercadoria => 
            Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia);

        public ItemFabricaçãoFiscal()
        {
        }

        public ItemFabricaçãoFiscal(string referencia, decimal quantidade)
        {
            this.referencia = referencia;
            this.quantidade = quantidade;
        }

        public bool Equals(ItemFabricaçãoFiscal outro)
        {
            return this.referencia.Equals(outro.referencia) && this.quantidade.Equals(outro.quantidade);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", referencia, quantidade);
        }
    }
}
