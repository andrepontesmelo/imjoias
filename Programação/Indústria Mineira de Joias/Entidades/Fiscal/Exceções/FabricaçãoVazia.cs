namespace Entidades.Fiscal.Exceções
{
    public class FabricaçãoVazia : ExceçãoFiscal
    {
        public FabricaçãoVazia() : base("Não é possível fazer uma fabricação vazia.")
        {
        }
    }
}
