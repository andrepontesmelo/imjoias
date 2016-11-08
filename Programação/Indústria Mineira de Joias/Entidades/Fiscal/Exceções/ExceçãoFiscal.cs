using System;

namespace Entidades.Fiscal.Exceções
{
    public abstract class ExceçãoFiscal : Exception
    {
        public ExceçãoFiscal() : base()
        {
        }

        public ExceçãoFiscal(string mensagem) : base(mensagem)
        {
        }
    }
}
