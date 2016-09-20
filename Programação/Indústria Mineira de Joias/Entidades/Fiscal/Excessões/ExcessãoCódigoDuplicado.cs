using System;

namespace Entidades.Fiscal.NotaFiscalEletronica.Excessões
{
    public class ExcessãoCódigoDuplicado : Exception
    {
        public ExcessãoCódigoDuplicado(int código) : base(string.Format("O código {0} está duplicado", código))
        {
        }
    }
}
