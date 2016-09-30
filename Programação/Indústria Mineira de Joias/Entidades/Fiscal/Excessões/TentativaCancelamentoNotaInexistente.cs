using System;

namespace Entidades.Fiscal.Excessões
{
    public class TentativaCancelamentoNotaInexistente : Exception
    {
        public TentativaCancelamentoNotaInexistente(string id) : 
            base(string.Format("Tentativa de cancelamento de nota inexistente: {0}", id))
        {
        }
    }
}
