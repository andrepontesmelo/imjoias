namespace Entidades.Fiscal.Exceções
{
    public class EsquemaInexistente : ExceçãoFiscal
    {
        public EsquemaInexistente(string nomeEsquema) : base(string.Format("O esquema {0} não existe.", nomeEsquema))
        {
        }
    }
}
