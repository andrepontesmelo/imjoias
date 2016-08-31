using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Comissão.Impressão
{
    public class Filtro
    {
        private DateTime? dataInicial;

        public DateTime? DataInicial
        {
            get { return dataInicial; }
            set { dataInicial = value; }
        }
        private DateTime? dataFinal;

        public DateTime? DataFinal
        {
            get { return dataFinal; }
            set { dataFinal = value; }
        }
        private Entidades.Pessoa.Pessoa funcionário;

        public Entidades.Pessoa.Pessoa Funcionário
        {
            get { return funcionário; }
            set { funcionário = value; }
        }

        public Filtro(DateTime? dataInicial, DateTime? dataFinal, Entidades.Pessoa.Pessoa funcionário)
        {
            this.dataInicial = dataInicial;
            this.dataFinal = dataFinal;
            this.funcionário = funcionário;
        }
    }
}
