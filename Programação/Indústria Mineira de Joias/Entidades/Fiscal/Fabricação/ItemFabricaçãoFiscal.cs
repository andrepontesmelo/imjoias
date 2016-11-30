using Acesso.Comum;
using System;

namespace Entidades.Fiscal.Fabricação
{
    public class ItemFabricaçãoFiscal : DbManipulaçãoAutomática, IEquatable<ItemFabricaçãoFiscal>
    {
        [DbChavePrimária(true)]
        protected int codigo;

        protected string referencia;
        protected decimal quantidade;
        protected decimal valor;

        public string Referência
        {
            get { return referencia; }
            set { referencia = value; DefinirDesatualizado(); }
        }

        public decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public int Código => codigo;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Mercadoria.Mercadoria Mercadoria => 
            Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia);

        public ItemFabricaçãoFiscal()
        {
        }

        public ItemFabricaçãoFiscal(string referencia, decimal quantidade, decimal valor)
        {
            this.referencia = referencia;
            this.quantidade = quantidade;
            this.valor = valor;
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
