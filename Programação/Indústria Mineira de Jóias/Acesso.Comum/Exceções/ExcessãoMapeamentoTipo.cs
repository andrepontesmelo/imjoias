using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum.Exceções
{
    class ExcessãoMapeamentoTipo : Exception
    {
        private Type tipoNãoEncontrado;

        public ExcessãoMapeamentoTipo(string msg, Type tipoNãoEncontrado): base(msg)
        {
            this.tipoNãoEncontrado = tipoNãoEncontrado;
            Console.WriteLine("Nova ExcessãoMapeamentoTipo, tipo=" + tipoNãoEncontrado.ToString());
        }

        public Type TipoNãoEncontrado
        {
            get { return tipoNãoEncontrado; }
        }

    }
}
