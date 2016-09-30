namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ParserXmlAtacadoCancelamento
    {
        private string arquivo;

        public ParserXmlAtacadoCancelamento(string arquivo)
        {
            this.arquivo = arquivo;
        }

        public bool Cancelamento => true;

        public string Id { get; set; }
    }
}
