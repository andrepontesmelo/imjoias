using Acesso.Comum;
using System;

namespace Entidades.Fiscal.Produção
{
    public class ItemProduçãoFiscal : DbManipulaçãoSimples, IEquatable<ItemProduçãoFiscal>
    {
        protected string referencia;
        protected decimal quantidade;

        public string Referência => referencia;
        public decimal Quantidade => quantidade;

        public Mercadoria.Mercadoria Mercadoria => 
            Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia);

        public ItemProduçãoFiscal()
        {
        }

        public bool Equals(ItemProduçãoFiscal outro)
        {
            return this.referencia.Equals(outro.referencia) && this.quantidade.Equals(outro.quantidade);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", referencia, quantidade);
        }
    }
}
