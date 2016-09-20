using Acesso.Comum;

namespace Entidades.Mercadoria.Componente
{
    public abstract class VinculoMercadoriaComponente : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        protected string mercadoria;

        [DbChavePrimária(false)]
        protected string componente;

        protected double quantidade;

        public VinculoMercadoriaComponente()
        {
        }

        public VinculoMercadoriaComponente(string mercadoria, string componente, double quantidade)
        {
            this.mercadoria = mercadoria;
            this.componente = componente;
            this.quantidade = quantidade;
        }

        public string Componente => componente;
        public double Quantidade => quantidade;
        public string Mercadoria => mercadoria;
    }
}
