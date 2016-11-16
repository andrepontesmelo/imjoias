namespace Entidades.Fiscal.Exceções
{
    public class ProduçãoVazia : ExceçãoFiscal
    {
        public ProduçãoVazia() : base("Não é possível fazer uma produção vazia.")
        {
        }
    }
}
