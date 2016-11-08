namespace Entidades.Fiscal.Exceções
{
    public class NomeArquivoInválido : ExceçãoFiscal
    {
        public NomeArquivoInválido(string arquivo)
            : base("Não foi possível extrair código NF-e de seis dígitos do nome do arquivo")
        {
        }
    }
}
