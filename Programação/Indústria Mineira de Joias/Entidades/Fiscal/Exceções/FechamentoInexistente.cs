using System;

namespace Entidades.Fiscal.Exceções
{
    public class FechamentoInexistente : ExceçãoFiscal
    {
        public FechamentoInexistente(DateTime data) :
            base(string.Format("Não é possível encontrar um fechamento que contemple a data {0}", data.ToShortDateString()))
        {
        }
    }
}
