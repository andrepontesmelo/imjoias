using System;

namespace Entidades.Fiscal.Exceções
{
    public class CódigoDuplicado : ExceçãoFiscal
    {
        public CódigoDuplicado(int código) : base(string.Format("O código {0} está duplicado", código))
        {
        }
    }
}
