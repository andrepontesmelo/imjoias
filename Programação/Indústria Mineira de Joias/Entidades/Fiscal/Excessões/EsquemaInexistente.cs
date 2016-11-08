using System;

namespace Entidades.Fiscal.Excessões
{
    public class EsquemaInexistente : Exception
    {
        public EsquemaInexistente(string nomeEsquema) : base(string.Format("O esquema {0} não existe.", nomeEsquema))
        {
        }
    }
}
