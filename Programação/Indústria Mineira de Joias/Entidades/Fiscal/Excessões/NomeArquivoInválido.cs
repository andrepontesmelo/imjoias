using System;

namespace Entidades.Fiscal.Excessões
{
    public class NomeArquivoInválido : Exception
    {
        public NomeArquivoInválido(string arquivo)
            : base("Não foi possível extrair código NF-e de seis dígitos do nome do arquivo")
        {
        }
    }
}
