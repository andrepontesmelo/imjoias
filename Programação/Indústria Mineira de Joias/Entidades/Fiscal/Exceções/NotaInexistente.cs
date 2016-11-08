namespace Entidades.Fiscal.Exceções
{
    public class NotaInexistente : ExceçãoFiscal
    {
        public NotaInexistente(string id) : 
            base(string.Format("Tentativa de cancelamento de nota inexistente: {0}", id))
        {
        }
    }
}
