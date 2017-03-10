using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Coaf.Inconsistência
{
    public class InconsistênciaPessoaFísica : InconsistênciaPessoa
    {
        public InconsistênciaPessoaFísica(Pessoa.PessoaFísica pessoaFísica) : base(pessoaFísica)
        {
        }

        public bool VerificarCpfVálido()
        {
            throw new NotImplementedException();
        }
    }
}
