namespace Entidades.Fiscal.NotaFiscalEletronica.Parser
{
    public class ParserXmlAtacadoCancelamento : ParserXml
    {
        public ParserXmlAtacadoCancelamento(string arquivo) : base(arquivo)
        {
        }

        public string Id => ObterAtributo("/procCancNFe/cancNFe/infCanc", "Id");
        public bool Cancelamento => Existe("/procCancNFe/cancNFe/infCanc");
    }
}
