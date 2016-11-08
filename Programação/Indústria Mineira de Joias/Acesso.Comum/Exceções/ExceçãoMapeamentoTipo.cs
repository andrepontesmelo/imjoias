using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum.Exceções
{
    class ExceçãoMapeamentoTipo : Exception
    {
        private Type tipoNãoEncontrado;

        public ExceçãoMapeamentoTipo(string msg, Type tipoNãoEncontrado): base(msg)
        {
            this.tipoNãoEncontrado = tipoNãoEncontrado;
            Console.WriteLine("Nova ExceçãoMapeamentoTipo, tipo=" + tipoNãoEncontrado.ToString());
        }

        public Type TipoNãoEncontrado
        {
            get { return tipoNãoEncontrado; }
        }

    }
}
