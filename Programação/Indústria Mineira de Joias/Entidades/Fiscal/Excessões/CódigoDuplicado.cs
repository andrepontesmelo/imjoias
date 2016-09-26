using System;

namespace Entidades.Fiscal.Excessões
{
    public class CódigoDuplicado : Exception
    {
        public CódigoDuplicado(int código) : base(string.Format("O código {0} está duplicado", código))
        {
        }
    }
}
