using System;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class ExcessãoNãoPodeExtrairNfeNomeArquivo : Exception
    {
        public ExcessãoNãoPodeExtrairNfeNomeArquivo(string arquivo)
            : base(string.Format("Não foi possível extrair código nfe do arquivo {0}", arquivo))
        {
            Console.WriteLine(Message);
        }
    }
}
