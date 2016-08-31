using Acesso.Comum;

namespace Entidades.Mercadoria.Componente
{
    public class VinculoMercadoriaComponenteFiscal : VinculoMercadoriaComponente
    {
        public VinculoMercadoriaComponenteFiscal() { }
        public VinculoMercadoriaComponenteFiscal(string mercadoria, string componente, double quantidade) : base(mercadoria, componente, quantidade)
        {
        }
    }
}
