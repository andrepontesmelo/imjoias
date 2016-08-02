namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ParserXml
    {
        public ParserXml(string arquivo)
        {
        }

        public int QuantidadeVendaItem
        {
            get
            {
                return 0;
            }
        }

        public static ParserXml LerArquivo(string arquivo)
        {
            return new ParserXml(arquivo);
        }
    }
}
