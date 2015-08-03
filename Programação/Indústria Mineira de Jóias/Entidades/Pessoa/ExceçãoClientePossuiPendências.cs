using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Pessoa
{
    [global::System.Serializable]
    public class ExceçãoClientePossuiPendências : ApplicationException
    {
        private Entidades.Pessoa.Pessoa pessoa;

        public ExceçãoClientePossuiPendências(Entidades.Pessoa.Pessoa pessoa, string mensagem)
            : base(mensagem)
        {
            this.pessoa = pessoa;
        }

        public Entidades.Pessoa.Pessoa Cliente
        {
            get { return pessoa; }
        }
    }
}
