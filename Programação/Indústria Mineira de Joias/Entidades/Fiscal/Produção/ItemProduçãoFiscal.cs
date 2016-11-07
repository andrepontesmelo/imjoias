using Acesso.Comum;

namespace Entidades.Fiscal.Produção
{
    public class ItemProduçãoFiscal : DbManipulaçãoSimples
    {
        protected string referencia;
        protected decimal quantidade;

        public decimal Quantidade => quantidade;

        public Mercadoria.Mercadoria Mercadoria => 
            Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia);


        public ItemProduçãoFiscal()
        {
        }
    }
}
